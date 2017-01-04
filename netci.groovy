import jobs.generation.Utilities;
import jobs.generation.InternalUtilities;

def project = GithubProject
def branch = GithubBranchName

[true, false].each { isPR ->
    ['Debug', 'Release'].each { configuration ->

        def newJobName = InternalUtilities.getFullJobName(project, configuration, isPR)

        def buildString = """./build.sh /p:Configuration=${configuration}"""

        def newJob = job(newJobName) {
            steps {
                shell("git submodule init")
                shell("git submodule update")
                shell(buildString)
            }
        }

        Utilities.setMachineAffinity(newJob, "Ubuntu14.04", "latest-or-auto")
        InternalUtilities.standardJobSetup(newJob, project, isPR, "*/${branch}")

        if (isPR) {
            Utilities.addGithubPRTriggerForBranch(newJob, branch, "Ubuntu 14.04 ${configuration}")
        }
        else {
            Utilities.addGithubPushTrigger(newJob)
        }
    }
}
