import jobs.generation.Utilities;
import jobs.generation.InternalUtilities;

def project = GithubProject;
def branch = GithubBranchName;

def addBuildStepsAndSetMachineAffinity(def job, String os, String configuration) {
  def buildString = "";

  if (os == "Windows_NT") {
    buildString = ".\build.cmd /p:Configuration=${configuration}";
  }
  else {
    buildString = "./build.sh /p:Configuration=${configuration}";
  }

  job.with {
    steps {
      shell("git submodule init");
      shell("git submodule update");
      shell(buildString);
    };
  };

  Utilities.setMachineAffinity(job, os, "latest-or-auto");
}

def addPullRequestJob(String project, String branch, String os, String configuration, boolean runByDefault)
{
  def newJobName = InternalUtilities.getFullJobName(project, "${os}_${configuration}", true);
  def contextString = "${os} ${configuration}";
  def triggerPhrase = "(?i).*test\\W+${contextString}.*";

  def newJob = job(newJobName);

  addBuildStepsAndSetMachineAffinity(newJob, os, configuration);
  InternalUtilities.standardJobSetup(newJob, project, true, "*/${branch}");
  Utilities.addGithubPRTriggerForBranch(newJob, branch, contextString, triggerPhrase, !runByDefault);
}

def addPushJob(String project, String branch, String os, String configuration)
{
    def shortJobName = "${os}_${configuration}";

    def newJobName = InternalUtilities.getFullJobName(project, shortJobName, false);
    def newJob = job(newJobName);

    addBuildStepsAndSetMachineAffinity(newJob, os, configuration);
    InternalUtilities.standardJobSetup(newJob, project, false, "*/${branch}");
    Utilities.addGithubPushTrigger(newJob);
}

["Ubuntu14.04", "RHEL7.2", "Windows_NT"].each { os ->
  addPullRequestJob(project, branch, os, "Release", true);
  addPullRequestJob(project, branch, os, "Debug", false);
};

// Per push, run all the jobs
["Ubuntu14.04", "RHEL7.2", "Windows_NT"].each { os ->
  ["Release", "Debug"].each { configuration ->
    addPushJob(project, branch, os, configuration);
  };
};
