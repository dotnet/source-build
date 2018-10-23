import jobs.generation.ArchivalSettings;
import jobs.generation.Utilities;

def project = GithubProject;
def branch = GithubBranchName;
loggingOptions = "";

def addArchival(def job) {
  def archivalSettings = new ArchivalSettings()
  // non-tarball builds just build in the root workspace directory.
  // tarball builds clone to source-build, build from there, and then
  // additionally build from a tarball-output directory.
  // Grab these logs from all of those locations.
  [ "", "source-build/", "tarball-output/"].each { logRoot ->
    archivalSettings.addFiles("${logRoot}bin/logs/*")
    archivalSettings.addFiles("${logRoot}bin/prebuilt-report/**/*")
    archivalSettings.addFiles("${logRoot}bin/conflict-report/**/*")
    archivalSettings.addFiles("${logRoot}bin/msbuild-debug/**/*")
    archivalSettings.addFiles("${logRoot}src/**/*.binlog")
    archivalSettings.addFiles("${logRoot}src/**/*.log")
    archivalSettings.addFiles("${logRoot}init-tools.log")
    archivalSettings.addFiles("${logRoot}msbuild.log")
    archivalSettings.addFiles("${logRoot}testing-smoke/smoke-test.log")
  }

  archivalSettings.setFailIfNothingArchived()
  archivalSettings.setAlwaysArchive()

  Utilities.addArchival(job, archivalSettings)
}

def setMachineAffinity(job, os) {
  // Map os to queue:  If the os is present,
  // use the specified queue, otherwise,
  // fall back to the old behavior.
  def queueMap = [
    'Fedora28': 'Fedora.28.Amd64.Open'
  ]

  def queueName = queueMap.get(os)

  if (queueName != null) {
    Utilities.setMachineAffinity(job, queueName)
  }
  else {
    Utilities.setMachineAffinity(job, os, "latest-or-auto")
  }
}

def getDockerImageForOs(os) {
  def imageMap = [
    'RHEL7.2': 'microsoft/dotnet-buildtools-prereqs:rhel7_prereqs_2',
    'CentOS7.1': 'microsoft/dotnet-buildtools-prereqs:centos-7-b46d863-20180719033416',
    'Fedora28': 'microsoft/dotnet-buildtools-prereqs:fedora-28-c103199-20180628122443',
  ]
  return imageMap.get(os)
}

def addBuildStepsAndSetMachineAffinity(def job, String os, String configuration, boolean portable, boolean runInDocker) {
  smokeTestExcludes = "";
  if (os == "OSX10.12") {
    // Dev certs doesn't seem to work in these platforms. https://github.com/dotnet/source-build/issues/560
    smokeTestExcludes += " --excludeWebHttpsTests";
  }

  job.with {
    steps {
      if (runInDocker) {
        def imageName = getDockerImageForOs(os);
      
        shell("git submodule update --init --recursive");
        shell("docker run -u=\"\$(id -u):\$(id -g)\" -t --sig-proxy=true -e HOME=/opt/code/home -v \$(pwd):/opt/code --rm -w /opt/code ${imageName} /opt/code/build.sh /p:Configuration=${configuration} ${loggingOptions}");
        shell("docker run -u=\"\$(id -u):\$(id -g)\" -t --sig-proxy=true -e HOME=/opt/code/home -v \$(pwd):/opt/code --rm -w /opt/code ${imageName} /opt/code/smoke-test.sh --minimal --configuration ${configuration} ${smokeTestExcludes}");

        // Only Ubuntu Jenkins machines have Docker
        setMachineAffinity(job, "Ubuntu16.04");
      }
      else {
        if (os == "Windows_NT") {
          batchFile("git submodule update --init --recursive");
          batchFile(".\\build.cmd /p:Configuration=${configuration} /p:PortableBuild=${portable} /p:FailOnPrebuiltBaselineError=true ${loggingOptions}")
        }
        else {
          shell("git submodule update --init --recursive");
          shell("./build.sh /p:Configuration=${configuration} /p:PortableBuild=${portable} /p:FailOnPrebuiltBaselineError=true ${loggingOptions}");
          shell("./smoke-test.sh --minimal --configuration ${configuration} ${smokeTestExcludes}");
        }
        setMachineAffinity(job, os);
      }
    };
  };


}

def addPullRequestJob(String project, String branch, String os, String configuration, boolean portable, boolean runInDocker, boolean runByDefault)
{
  def config = configuration;
  if (portable) {
    config += "_Portable";
  }
  def newJobName = Utilities.getFullJobName(project, "${os}_${config}", true);
  def contextString = "${os} ${configuration}";
  if (portable) {
    contextString += " Portable";
  }
  def triggerPhrase = "(?i).*test\\W+${contextString}.*";

  def newJob = job(newJobName);

  addBuildStepsAndSetMachineAffinity(newJob, os, configuration, portable, runInDocker);
  addArchival(newJob);
  Utilities.standardJobSetup(newJob, project, true, "*/${branch}");
  Utilities.setJobTimeout(newJob, 180);
  Utilities.addGithubPRTriggerForBranch(newJob, branch, contextString, triggerPhrase, !runByDefault);
}

def addPushJob(String project, String branch, String os, String configuration, boolean portable, boolean runInDocker)
{
    def shortJobName = "${os}_${configuration}";
    if (portable) {
      shortJobName += "_Portable";
    }

    def newJobName = Utilities.getFullJobName(project, shortJobName, false);
    def newJob = job(newJobName);

    addBuildStepsAndSetMachineAffinity(newJob, os, configuration, portable, runInDocker);
    addArchival(newJob);
    Utilities.standardJobSetup(newJob, project, false, "*/${branch}");
    Utilities.setJobTimeout(newJob, 180);
    Utilities.addGithubPushTrigger(newJob);
}

["Ubuntu16.04", "Debian8.4", "RHEL7.2", "Windows_NT", "CentOS7.1", "OSX10.12"].each { os ->
  // Release non-portable run by default
  addPullRequestJob(project, branch, os, "Release", false, false, true);
  // Debug non-portable can be triggered
  addPullRequestJob(project, branch, os, "Debug", false, false, false);
  // Release portable can be triggered
  addPullRequestJob(project, branch, os, "Release", true, false, false);
  // Debug portable can be triggered
  addPullRequestJob(project, branch, os, "Release", false, false, true);
  addPullRequestJob(project, branch, os, "Debug", false, false, false);
};

// Pull request jobs that run in Docker
["Fedora28"].each { os ->
  addPullRequestJob(project, branch, os, "Release", false, true, true);
  addPullRequestJob(project, branch, os, "Debug", false, true, false);
};

// Per push, run all the jobs
["Ubuntu16.04", "Debian8.4", "RHEL7.2", "Windows_NT", "CentOS7.1", "OSX10.12"].each { os ->
  ["Release", "Debug"].each { configuration ->
    [true, false].each { portable ->
      addPushJob(project, branch, os, configuration, portable, false);
    };
  };
};
// Push jobs that run in Docker
["Fedora28"].each { os ->
  ["Release", "Debug"].each { configuration ->
    addPushJob(project, branch, os, configuration, false, true);
  };
};

// Tarball builds that are not enforced to be offline
[true, false].each { isPR ->
  ["RHEL7.2", "CentOS7.1"].each { os ->
    ["Release", "Debug"].each { configuration ->
      [true, false].each { portable ->

        def shortJobName = "${os}_Tarball_${configuration}";
        def contextString = "${os} Tarball ${configuration}";
        def poisonProductionBuildArgument = ""
        def poisonConsumptionBuildArugment = ""

        if (portable) {
          shortJobName += "_Portable"
          contextString += " Portable"
        }

        // only run poisoning on one platform for now
        if (os == "CentOS7.1") {
          poisonProductionBuildArgument = "--enable-leak-detection"
          poisonConsumptionBuildArugment = "/p:EnablePoison=true"
        }

        def triggerPhrase = "(?i).*test\\W+${contextString}.*";

        def newJob = job(Utilities.getFullJobName(project, shortJobName, isPR)){
          steps{
              shell("cd ./source-build;git submodule update --init --recursive");
              shell("cd ./source-build;./build.sh /p:ArchiveDownloadedPackages=true /p:Configuration=${configuration} /p:PortableBuild=${portable} ${loggingOptions}");
              shell("cd ./source-build;./build-source-tarball.sh ../tarball-output --skip-build ${poisonProductionBuildArgument}");

              shell("cd ./tarball-output;./build.sh /p:Configuration=${configuration} /p:PortableBuild=${portable} /p:FailOnPrebuiltBaselineError=true ${poisonConsumptionBuildArugment} ${loggingOptions}")
              shell("cd ./tarball-output;./smoke-test.sh --minimal --configuration ${configuration}")
          }
        }

        setMachineAffinity(newJob, os);

        Utilities.standardJobSetup(newJob, project, isPR, "*/${branch}");

        // Increase timeout. The tarball builds can take longer than the 2 hour default.
        Utilities.setJobTimeout(newJob, 240);

        // Clone into the source-build directory
        Utilities.addScmInSubDirectory(newJob, project, isPR, 'source-build');

        addArchival(newJob);
        if(isPR){
          if(configuration == "Release"){
            Utilities.addGithubPRTriggerForBranch(newJob, branch, contextString);
          }
          else{
            Utilities.addGithubPRTriggerForBranch(newJob, branch, contextString, triggerPhrase);
          }
        }
        else{
          Utilities.addGithubPushTrigger(newJob);
        }

      }
    }
  }
}

// Tarball builds that are enforced offline with unshare
[true, false].each { isPR ->
  ["RHEL7.2", "CentOS7.1"].each { os->
    ["Release", "Debug"].each { configuration ->
      [true, false].each { portable ->

        def shortJobName = "${os}_Unshared_${configuration}";
        def contextString = "${os} Unshared ${configuration}";
        def poisonProductionBuildArgument = ""
        def poisonConsumptionBuildArugment = ""

        if (portable) {
          shortJobName += "_Portable"
          contextString += " Portable"
        }

        // only run poisoning on one platform for now
        if (os == "CentOS7.1") {
          poisonProductionBuildArgument = "--enable-leak-detection"
          poisonConsumptionBuildArugment = "/p:EnablePoison=true"
        }

        def triggerPhrase = "(?i).*test\\W+${contextString}.*";
        def imageName = getDockerImageForOs(os);

        def newJob = job(Utilities.getFullJobName(project, shortJobName, isPR)){
          steps{
              shell("cd ./source-build;git submodule update --init --recursive");
              // First build the product itself
              shell("docker run -u=\"\$(id -u):\$(id -g)\" -t --sig-proxy=true -e HOME=/opt/code/home -v \$(pwd)/source-build:/opt/code --rm -w /opt/code ${imageName} /opt/code/build.sh /p:ArchiveDownloadedPackages=true /p:Configuration=${configuration} /p:PortableBuild=${portable} /p:ContinueOnPrebuiltBaselineError=true ${loggingOptions}");
              // Have to make this directory before volume-sharing it unlike non-docker build - existing directory is really only a warning in build-source-tarball.sh
              shell("mkdir tarball-output");
              // now build the tarball
              shell("docker run -u=\"\$(id -u):\$(id -g)\" -t --sig-proxy=true -e HOME=/opt/code/home --network none -v \$(pwd)/source-build:/opt/code -v \$(pwd)/tarball-output:/opt/tarball --rm -w /opt/code ${imageName} /opt/code/build-source-tarball.sh /opt/tarball --skip-build ${poisonProductionBuildArgument}");
              // now build from the tarball offline and without access to the regular non-tarball build
              shell("docker run -u=\"\$(id -u):\$(id -g)\" -t --sig-proxy=true -e HOME=/opt/tarball/home --network none -v \$(pwd)/tarball-output:/opt/tarball --rm -w /opt/tarball ${imageName} /opt/tarball/build.sh /p:Configuration=${configuration} /p:PortableBuild=${portable} /p:FailOnPrebuiltBaselineError=true ${poisonConsumptionBuildArugment} ${loggingOptions}");
              // finally, run a smoke-test on the result
              shell("docker run -u=\"\$(id -u):\$(id -g)\" -t --sig-proxy=true -e HOME=/opt/tarball/home -v \$(pwd)/tarball-output:/opt/tarball --rm -w /opt/tarball ${imageName} /opt/tarball/smoke-test.sh --minimal --configuration ${configuration}");
          }
        }

        // Only Ubuntu Jenkins machines have Docker
        setMachineAffinity(newJob, "Ubuntu16.04");

        Utilities.standardJobSetup(newJob, project, isPR, "*/${branch}");

        // Increase timeout. The offline build in Docker takes more than 2 hours.
        Utilities.setJobTimeout(newJob, 240);

        // Clone into the source-build directory
        Utilities.addScmInSubDirectory(newJob, project, isPR, 'source-build');

        addArchival(newJob);
        if(isPR){
          if(configuration == "Release"){
            Utilities.addGithubPRTriggerForBranch(newJob, branch, contextString);
          }
          else{
            Utilities.addGithubPRTriggerForBranch(newJob, branch, contextString, triggerPhrase);
          }
        }
        else{
          Utilities.addGithubPushTrigger(newJob);
        }

      }
    }
  }
}

