import jobs.generation.Utilities;
import jobs.generation.ArchivalSettings;

def project = GithubProject;
def branch = GithubBranchName;
loggingOptions = "/clp:v=detailed /p:MinimalConsoleLogOutput=false";

def addArchival(def job) {
  def archivalSettings = new ArchivalSettings()
  archivalSettings.addFiles("src/**/artifacts/**/log/*.binlog")
  archivalSettings.addFiles("testing-smoke/smoke-test.log")
  archivalSettings.setFailIfNothingArchived()
  archivalSettings.setArchiveOnFailure()

  Utilities.addArchival(job, archivalSettings)
}

def addBuildStepsAndSetMachineAffinity(def job, String os, String configuration) {
  job.with {
    steps {
      if (os == "Windows_NT") {
        batchFile("git submodule update --init --recursive");
        batchFile(".\\build.cmd /p:Configuration=${configuration} ${loggingOptions}")
      }
      else {
        shell("git submodule update --init --recursive");
        shell("./build.sh /p:Configuration=${configuration} ${loggingOptions}");
        smokeTestExcludes = "";
        if (os == "Fedora24" || os == "OSX10.12") {
          // Dev certs doesn't seem to work in these platforms. https://github.com/dotnet/source-build/issues/560
          smokeTestExcludes += " --excludeWebHttpsTests";
        }
        shell("./smoke-test.sh --minimal --projectOutput --configuration ${configuration} ${smokeTestExcludes}");
      }
    };
  };

  if (os == "Fedora28") {
    Utilities.setMachineAffinity(job, "Fedora.28.Amd64.Open");
  }
  else {
    Utilities.setMachineAffinity(job, os, "latest-or-auto");
  }
}

def addPullRequestJob(String project, String branch, String os, String configuration, boolean runByDefault)
{
  def newJobName = Utilities.getFullJobName(project, "${os}_${configuration}", true);
  def contextString = "${os} ${configuration}";
  def triggerPhrase = "(?i).*test\\W+${contextString}.*";

  def newJob = job(newJobName);

  addBuildStepsAndSetMachineAffinity(newJob, os, configuration);
  addArchival(newJob);
  Utilities.standardJobSetup(newJob, project, true, "*/${branch}");
  Utilities.setJobTimeout(newJob, 180);
  Utilities.addGithubPRTriggerForBranch(newJob, branch, contextString, triggerPhrase, !runByDefault);
}

def addPushJob(String project, String branch, String os, String configuration)
{
    def shortJobName = "${os}_${configuration}";

    def newJobName = Utilities.getFullJobName(project, shortJobName, false);
    def newJob = job(newJobName);

    addBuildStepsAndSetMachineAffinity(newJob, os, configuration);
    addArchival(newJob);
    Utilities.standardJobSetup(newJob, project, false, "*/${branch}");
    Utilities.setJobTimeout(newJob, 180);
    Utilities.addGithubPushTrigger(newJob);
}

["Ubuntu16.04", "Fedora28", "Debian8.4", "RHEL7.2", "CentOS7.1", "OSX10.12"].each { os ->
  addPullRequestJob(project, branch, os, "Release", true);
  addPullRequestJob(project, branch, os, "Debug", false);
};

// Per push, run all the jobs
["Ubuntu16.04", "Fedora28", "Debian8.4", "RHEL7.2", "Windows_NT", "CentOS7.1", "OSX10.12"].each { os ->
  ["Release", "Debug"].each { configuration ->
    addPushJob(project, branch, os, configuration);
  };
};

// Tarball builds that are not enforced to be offline
[true, false].each { isPR ->
  ["RHEL7.2", "CentOS7.1"].each { os ->
    ["Release", "Debug"].each { configuration ->

      def shortJobName = "${os}_Tarball_${configuration}";
      def contextString = "${os} Tarball ${configuration}";
      def triggerPhrase = "(?i).*test\\W+${contextString}.*";

      def newJob = job(Utilities.getFullJobName(project, shortJobName, isPR)){
        steps{
            shell("cd ./source-build;git submodule update --init --recursive");
            shell("cd ./source-build;./build.sh /p:ArchiveDownloadedPackages=true /p:Configuration=${configuration} ${loggingOptions}");
            shell("cd ./source-build;./build-source-tarball.sh ../tarball-output --skip-build");

            shell("cd ./tarball-output;./build.sh /p:Configuration=${configuration} ${loggingOptions}")
            shell("cd ./tarball-output;./smoke-test.sh --minimal --projectOutput --configuration ${configuration}")
        }
      }

      Utilities.setMachineAffinity(newJob, os, 'latest-or-auto');

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

// Tarball builds that are enforced offline with unshare
[true, false].each { isPR ->
  ["RHEL7.2"].each { os->
    ["Release", "Debug"].each { configuration ->

      def shortJobName = "${os}_Unshared_${configuration}";
      def contextString = "${os} Unshared ${configuration}";
      def triggerPhrase = "(?i).*test\\W+${contextString}.*";

      def newJob = job(Utilities.getFullJobName(project, shortJobName, isPR)){
        steps{
            shell("cd ./source-build;git submodule update --init --recursive");
            // First build the product itself
            shell("docker run -u=\"\$(id -u):\$(id -g)\" -t --sig-proxy=true -e HOME=/opt/code/home -v \$(pwd)/source-build:/opt/code --rm -w /opt/code microsoft/dotnet-buildtools-prereqs:rhel7_prereqs_2 /opt/code/build.sh /p:ArchiveDownloadedPackages=true /p:Configuration=${configuration} ${loggingOptions}");
            // Have to make this directory before volume-sharing it unlike non-docker build - existing directory is really only a warning in build-source-tarball.sh
            shell("mkdir tarball-output");
            // now build the tarball
            shell("docker run -u=\"\$(id -u):\$(id -g)\" -t --sig-proxy=true -e HOME=/opt/code/home --network none -v \$(pwd)/source-build:/opt/code -v \$(pwd)/tarball-output:/opt/tarball --rm -w /opt/code microsoft/dotnet-buildtools-prereqs:rhel7_prereqs_2 /opt/code/build-source-tarball.sh /opt/tarball --skip-build");
            // now build from the tarball offline and without access to the regular non-tarball build
            shell("docker run -u=\"\$(id -u):\$(id -g)\" -t --sig-proxy=true -e HOME=/opt/tarball/home --network none -v \$(pwd)/tarball-output:/opt/tarball --rm -w /opt/tarball microsoft/dotnet-buildtools-prereqs:rhel7_prereqs_2 /opt/tarball/build.sh /p:Configuration=${configuration} ${loggingOptions}");
            // finally, run a smoke-test on the result
            shell("docker run -u=\"\$(id -u):\$(id -g)\" -t --sig-proxy=true -e HOME=/opt/tarball/home -v \$(pwd)/tarball-output:/opt/tarball --rm -w /opt/tarball microsoft/dotnet-buildtools-prereqs:rhel7_prereqs_2 /opt/tarball/smoke-test.sh --minimal --projectOutput --configuration ${configuration}");
        }
      }

      // Only Ubuntu Jenkins machines have Docker
      Utilities.setMachineAffinity(newJob, "Ubuntu16.04", 'latest-or-auto');

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

