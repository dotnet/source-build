import jobs.generation.Utilities;

def project = GithubProject;
def branch = GithubBranchName;
loggingOptions = "/clp:v=detailed /p:MinimalConsoleLogOutput=false";

def addBuildStepsAndSetMachineAffinity(def job, String os, String configuration) {
  job.with {
    steps {
      if (os == "Windows_NT") {
        batchFile("git submodule update --init --recursive");
        batchFile(".\\build.cmd /p:Configuration=${configuration} ${loggingOptions}")
      }
      else {
        shell("git submodule update --init --recursive");
        shell("./build.sh /p:Configuration=${configuration} ${loggingOptions}")
      }
    };
  };

  Utilities.setMachineAffinity(job, os, "latest-or-auto");
}

def addPullRequestJob(String project, String branch, String os, String configuration, boolean runByDefault)
{
  def newJobName = Utilities.getFullJobName(project, "${os}_${configuration}", true);
  def contextString = "${os} ${configuration}";
  def triggerPhrase = "(?i).*test\\W+${contextString}.*";

  def newJob = job(newJobName);

  addBuildStepsAndSetMachineAffinity(newJob, os, configuration);
  Utilities.standardJobSetup(newJob, project, true, "*/${branch}");
  Utilities.addGithubPRTriggerForBranch(newJob, branch, contextString, triggerPhrase, !runByDefault);
}

def addPushJob(String project, String branch, String os, String configuration)
{
    def shortJobName = "${os}_${configuration}";

    def newJobName = Utilities.getFullJobName(project, shortJobName, false);
    def newJob = job(newJobName);

    addBuildStepsAndSetMachineAffinity(newJob, os, configuration);
    Utilities.standardJobSetup(newJob, project, false, "*/${branch}");
    Utilities.addGithubPushTrigger(newJob);
}

["Ubuntu16.04", "Fedora24", "Debian8.4", "RHEL7.2", "Windows_NT", "CentOS7.1", "OSX10.12"].each { os ->
  addPullRequestJob(project, branch, os, "Release", true);
  addPullRequestJob(project, branch, os, "Debug", false);
};

// Per push, run all the jobs
["Ubuntu16.04", "Fedora24", "Debian8.4", "RHEL7.2", "Windows_NT", "CentOS7.1", "OSX10.12"].each { os ->
  ["Release", "Debug"].each { configuration ->
    addPushJob(project, branch, os, configuration);
  };
};

[true, false].each { isPR ->
  ["RHEL7.2"].each { os->
    ["Release", "Debug"].each { configuration ->

      def shortJobName = "${os}_Offline_${configuration}";
      def contextString = "${os} Offline ${configuration}";
      def triggerPhrase = "(?i).*test\\W+${contextString}.*";

      def newJob = job(Utilities.getFullJobName(project, shortJobName, isPR)){
        steps{
            shell("cd ./source-build;git submodule update --init --recursive");
            shell("cd ./source-build;./build.sh /p:ArchiveDownloadedPackages=true /p:Configuration=${configuration} ${loggingOptions}");
            shell("cd ./source-build;./build-source-tarball.sh ../tarball-output --skip-build");

            // For now, perform offline build up to corefx until we work through issues with other repos
            shell("cd ./tarball-output;./build.sh /p:RootRepo=corefx /p:Configuration=${configuration} ${loggingOptions}")
        }
      }

      Utilities.setMachineAffinity(newJob, os, 'latest-or-auto');

      Utilities.standardJobSetup(newJob, project, isPR, "*/${branch}");

      // Clone into the source-build directory
      Utilities.addScmInSubDirectory(newJob, project, isPR, 'source-build');
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

[true, false].each { isPR ->
  ["Linux_ARM"].each { os->
    ["Release", "Debug"].each { configuration ->

      def shortJobName = "${os}_${configuration}";
      def contextString = "${os} ${configuration}";
      def triggerPhrase = "(?i).*test\\W+${contextString}.*";

      def newJob = job(Utilities.getFullJobName(project, shortJobName, isPR)){
        steps{
            shell("git submodule update --init --recursive");
            shell("./init-tools.sh")
            if(os == "Linux_ARM"){
              shell("./arm-ci.sh arm ./build.sh /p:Platform=arm /p:Configuration=${configuration} ${loggingOptions}")
            }
            if(os == "Tizen"){
              shell("./arm-ci.sh armel ./build.sh /p:Platform=armel /p:Configuration=${configuration} ${loggingOptions}")
            }
        }
      }

      Utilities.setMachineAffinity(newJob, 'Ubuntu', 'arm-cross-latest');

      Utilities.standardJobSetup(newJob, project, isPR, "*/${branch}");
      if(isPR){
        //We run Tizen Release and Ubuntu ARM Release
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


