import jobs.generation.Utilities;

def project = GithubProject;
def branch = GithubBranchName;

def addBuildStepsAndSetMachineAffinity(def job, String os, String configuration) {
  job.with {
    steps {
      if (os == "Windows_NT") {
        batchFile("git submodule update --init --recursive");
        batchFile(".\\build.cmd /p:Configuration=${configuration} /p:IsJenkinsBuild=true")
      }
      else {
        shell("git submodule update --init --recursive");
        shell("./build.sh /p:Configuration=${configuration} /p:IsJenkinsBuild=true")
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

["RHEL7.2", "Windows_NT", "CentOS7.1"].each { os ->
  addPullRequestJob(project, branch, os, "Release", true);
  addPullRequestJob(project, branch, os, "Debug", false);
};

// Per push, run all the jobs
["Ubuntu14.04", "RHEL7.2", "Windows_NT", "CentOS7.1", "OSX10.12"].each { os ->
  ["Release", "Debug"].each { configuration ->
    addPushJob(project, branch, os, configuration);
  };
};

[true, false].each { isPR ->
  ["Linux_ARM", "Tizen"].each { os->
    ["Release", "Debug"].each { configuration ->
      
      def shortJobName = "${os}_${configuration}";
      def contextString = "${os} ${configuration}";
      def triggerPhrase = "(?i).*test\\W+${contextString}.*";
      
      def newJob = job(Utilities.getFullJobName(project, shortJobName, isPR)){
        steps{
            shell("git submodule update --init --recursive");
            shell("./init-tools.sh")
            if(os == "Linux_ARM"){
              shell("./arm-ci.sh arm ./build.sh /p:Platform=arm /p:Configuration=${configuration} /p:IsJenkinsBuild=true")
            }
            if(os == "Tizen"){
              shell("./arm-ci.sh armel ./build.sh /p:Platform=armel /p:Configuration=${configuration} /p:IsJenkinsBuild=true")
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

