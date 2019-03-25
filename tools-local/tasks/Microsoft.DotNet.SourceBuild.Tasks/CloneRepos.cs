using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microsoft.DotNet.SourceBuild.Tasks
{
    public class CloneRepos : Microsoft.Build.Utilities.Task
    {
        [Required]
        public string SourceRoot { get; set; }

        [Required]
        public string GitRoot { get; set; }

        [Required]
        public string SpecFile { get; set; }

        private IEnumerable<RepoSpec> RepoSpecs { get; set; }
        private bool ResetAll { get; set; }
        private bool CheckoutAll { get; set; }

        public override bool Execute()
        {
            EnsureGit();
            Directory.CreateDirectory(SourceRoot);
            Directory.CreateDirectory(GitRoot);
            RepoSpecs = ReadSpecFile(SpecFile);

            Parallel.ForEach(RepoSpecs, d =>
            {
                if (Directory.Exists(Path.Combine(GitRoot, d.Name + ".git")))
                {
                    if (!Directory.Exists(Path.Combine(SourceRoot, d.Name)))
                    {
                        Directory.CreateDirectory(Path.Combine(SourceRoot, d.Name));
                        File.WriteAllText(Path.Combine(SourceRoot, d.Name, ".git"), $"gitdir: {Path.Combine(GitRoot, d.Name + ".git")}");

                        var checkoutSuccess = CheckoutRepo(Path.Combine(SourceRoot, d.Name), d.Hash, true).Result;
                        if (!checkoutSuccess)
                        {
                            Log.LogError($"Checking out {d.Hash} in repo {Path.Combine(SourceRoot, d.Name)} failed.");
                        }
                    }
                    Log.LogMessage(MessageImportance.High, $"About to fetch {d.Url} to {Path.Combine(GitRoot, d.Name)}");
                    var fetchSuccess = FetchRepo(d.Url, Path.Combine(SourceRoot, d.Name)).Result;
                    if (!fetchSuccess)
                    {
                        Log.LogError($"Fetching {d.Url} into {Path.Combine(GitRoot, d.Name)} failed.");
                    }
                    Log.LogMessage(MessageImportance.High, $"Done fetching {d.Url} to {Path.Combine(GitRoot, d.Name)}");
                }
                else
                {
                    Log.LogMessage(MessageImportance.High, $"About to clone {d.Url} to {Path.Combine(SourceRoot, d.Name)}");
                    var cloneSuccess = CloneRepo(d.Url, GitRoot, SourceRoot, d.Name).Result;
                    if (!cloneSuccess)
                    {
                        Log.LogError($"Cloning {d.Url} into {Path.Combine(SourceRoot, d.Name)} failed.");
                    }
                    Log.LogMessage(MessageImportance.High, $"Done cloning {d.Url} to {Path.Combine(SourceRoot, d.Name)}");

                    var checkoutSuccess = CheckoutRepo(Path.Combine(SourceRoot, d.Name), d.Hash, false).Result;
                    if (!checkoutSuccess)
                    {
                        Log.LogError($"Checking out {d.Hash} in repo {Path.Combine(SourceRoot, d.Name)} failed.");
                    }
                }

                CheckForDirtyRepo(SourceRoot, d.Name).Wait();
            });

            return !Log.HasLoggedErrors;
        }

        private async System.Threading.Tasks.Task CheckForDirtyRepo(string sourceRoot, string name)
        {
            var masterSetting = Environment.GetEnvironmentVariable("SOURCE_BUILD_SKIP_SUBMODULE_CHECK");
            if (masterSetting == "1" || masterSetting == "true" || masterSetting == "yes")
            {
                return;
            }

            await CheckForModificationsInRepo(sourceRoot, name);
            await CheckForMismatchedRepo(sourceRoot, name);
        }

        private async System.Threading.Tasks.Task CheckForMismatchedRepo(string sourceRoot, string name)
        {
            var path = Path.Combine(sourceRoot, name);
            var currentHash = (await RunExternalGitCommand("rev-parse --verify HEAD")).StdOut;
            var spec = RepoSpecs.Single(r => r.Name == name);
            if (spec.Hash != currentHash)
            {
                if (CheckoutAll)
                {
                    await CheckoutRepo(path, spec.Hash, true);
                }
                var setting = Environment.GetEnvironmentVariable("SOURCE_BUILD_MISMATCHED_SUBMODULE_BEHAVIOR");
                var mergeBase = "missing commit";
                // check if the repo has the commit we're looking for
                if ((await RunExternalGitCommand($"cat-file -e {spec.Hash}^{{commit}}", path)).Success)
                {
                    mergeBase = (await RunExternalGitCommand($"git merge-base HEAD {spec.Hash}", path)).StdOut;
                    Log.LogMessage(MessageImportance.High, $"got merge base ({mergeBase})");
                }
                if (string.IsNullOrWhiteSpace(setting) || setting == "prompt" || setting == "warn")
                {
                    if (mergeBase != spec.Hash)
                    {
                        // diverged
                        Log.LogWarning($"submodule {name}, currently at {currentHash}, has diverged from the expected hash {spec.Hash}.  If you are changing this submodule's branch or moving it backward, this is expected.");
                    }
                    else
                    {
                        // ahead
                        Log.LogWarning($"submodule {name}, currently at {currentHash}, is ahead of the expected hash {spec.Hash}.  If you are updating this submodule, this is expected.");
                    }
                }
                if (string.IsNullOrWhiteSpace(setting))
                {
                    DoPromptForCheckout(sourceRoot, name, spec.Hash, true);
                }
                else
                {
                    if (setting == "prompt")
                    {
                        DoPromptForCheckout(sourceRoot, name, spec.Hash, false);
                    }
                    else if (setting == "warn" || setting == "ignore")
                    {
                        // warn handled above, nothing to do for ignore
                    }
                    else if (setting == "reset")
                    {
                        await CheckoutRepo(path, spec.Hash, true);
                    }
                    else
                    {
                        Log.LogWarning($"value {setting} for environment variable SOURCE_BUILD_MISMATCHED_SUBMODULE_BEHAVIOR is not valid.");
                        DoPromptForCheckout(sourceRoot, name, spec.Hash, true);
                    }
                }
            }
        }

        private async System.Threading.Tasks.Task CheckForModificationsInRepo(string sourceRoot, string name)
        {
            var path = Path.Combine(sourceRoot, name);

            // staged changes and unstaged modifications
            var dirty = !(await RunExternalGitCommand($"git diff-index --quiet HEAD --", path)).Success;
            // untracked list
            var untracked = (await RunExternalGitCommand($"git ls-files --others --exclude-standard", path)).StdOut;

            if (dirty || !string.IsNullOrWhiteSpace(untracked))
            {
                if (ResetAll)
                {
                    await CleanAndResetRepo(path);
                }
                else
                {
                    var setting = Environment.GetEnvironmentVariable("SOURCE_BUILD_DIRTY_SUBMODULE_BEHAVIOR");
                    if (string.IsNullOrWhiteSpace(setting))
                    {
                        Log.LogWarning($"Modifications found in repo {name}");
                        DoPromptForCleanAndReset(sourceRoot, name, true);
                    }
                    else
                    {
                        if (setting == "prompt")
                        {
                            DoPromptForCleanAndReset(sourceRoot, name, false);
                        }
                        else if (setting == "warn")
                        {
                            Log.LogWarning($"Modifications found in repo {name}");
                        }
                        else if (setting == "reset")
                        {
                            await CleanAndResetRepo(path);
                        }
                        else if (setting == "ignore")
                        {

                        }
                        else
                        {
                            Log.LogWarning($"value {setting} for environment variable SOURCE_BUILD_DIRTY_SUBMODULE_BEHAVIOR is not valid.");
                            DoPromptForCleanAndReset(sourceRoot, name, true);
                        }
                    }
                }
            }
        }

        private async void DoPromptForCheckout(string sourceRoot, string name, string expectedHash, bool printExtraInfo)
        {
            if (printExtraInfo)
            {
                Console.WriteLine("You can set the behavior used when submodules differ from the expected hash using the SOURCE_BUILD_MISMATCHED_SUBMODULE_BEHAVIOR environment variable.  Options:");
                Console.WriteLine("prompt: default behavior.  ask for each mismatched repo.");
                Console.WriteLine("ignore: do not run this check.  patches may fail to apply unless you set SkipPatches=true.");
                Console.WriteLine("warn: warn only and continue.");
                Console.WriteLine("reset: checkout the submodule to the expected hash.  this will lose uncommitted changes by default and without warning.");
            }
            var answer = ReadKeyWithRetry($"Would you like me to checkout {name} to the expected hash {expectedHash} (this will lose ALL uncommitted changes)? [N]o / [y]es / [a]ll / [q]uit >", new[] { 'n', 'y', 'a', 'q' });
            if (answer == 'y')
            {
                await CheckoutRepo(Path.Combine(sourceRoot, name), expectedHash, true);
            }
            else if (answer == 'a')
            {
                CheckoutAll = true;
                await CheckoutRepo(Path.Combine(sourceRoot, name), expectedHash, true);
            }
            else if (answer == 'q')
            {
                throw new OperationCanceledException($"User canceled build after checking repo {name} for mismatch.");
            }
        }

        private async void DoPromptForCleanAndReset(string sourceRoot, string name, bool printExtraInfo)
        {
            if (printExtraInfo)
            {
                Console.WriteLine("You can set the behavior used when modifications are found using the SOURCE_BUILD_DIRTY_SUBMODULE_BEHAVIOR environment variable.  Options:");
                Console.WriteLine("prompt: default behavior.  ask for each dirty repo.");
                Console.WriteLine("ignore: do not run this check.  patches may fail to apply unless you set SkipPatches=true.");
                Console.WriteLine("warn: warn only and continue.");
                Console.WriteLine("reset: clean and reset the repo.  this will lose uncommitted changes by default and without warning.");
            }
            var answer = ReadKeyWithRetry($"Would you like me to clean and reset {name} (this will lose ALL uncommitted changes)? [N]o / [y]es / [a]ll / [q]uit >", new[] { 'n', 'y', 'a', 'q' });
            if (answer == 'y')
            {
                await CleanAndResetRepo(Path.Combine(sourceRoot, name));
            }
            else if (answer == 'a')
            {
                ResetAll = true;
                await CleanAndResetRepo(Path.Combine(sourceRoot, name));
            }
            else if (answer == 'q')
            {
                throw new OperationCanceledException($"User canceled build after checking repo {name} for modifications.");
            }
        }

        private char ReadKeyWithRetry(string prompt, char[] allowedAnswers)
        {
            throw new NotImplementedException();
        }

        private async Task<(bool Success, string StdOut, string StdErr)> RunExternalGitCommand(string args, string workingDir = null)
        {
            Log.LogMessage(MessageImportance.High, $"Beginning git command {args} in {workingDir}");
            workingDir = workingDir ?? Environment.CurrentDirectory;
            var psi = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = args,
                CreateNoWindow = true,
                WorkingDirectory = workingDir,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            };
            Log.LogCommandLine($"{psi.FileName} {psi.Arguments}");
            Log.LogMessage(MessageImportance.High, $"Should be logging command line: {psi.FileName} {psi.Arguments}");
            var p = Process.Start(psi);
            var stdOut = await p.StandardOutput.ReadToEndAsync();
            var stdErr = await p.StandardError.ReadToEndAsync();
            p.WaitForExit();
            Log.LogMessage(MessageImportance.High, $"Finished git command {args} in {workingDir}");
            if (p.ExitCode == 0)
            {
                Log.LogMessage(MessageImportance.High, $"Should be logging content: {stdOut}");
                Log.LogMessage(MessageImportance.High, $"Should be logging content: {stdErr}");
                Log.LogMessage("git command", null, null, null, 0, 0, 0, 0, MessageImportance.Low, stdOut);
                return (true, stdOut, stdErr);
            }
            else
            {
                Log.LogError("git command", p.ExitCode, null, null, 0, 0, 0, 0, $"command {psi.FileName} {psi.Arguments} in directory {psi.WorkingDirectory} failed.  Command output follows:");
                Log.LogError(stdOut);
                Log.LogError(stdErr);
                return (false, stdOut, stdErr);
            }
        }

        private async Task<bool> CheckoutRepo(string path, string hash, bool force = false)
        {
            var forceArg = force ? "-f" : "";
            return (await RunExternalGitCommand($"checkout {forceArg} {hash}", path)).Success &&
                   (await RunExternalGitCommand($"submodule update --init --recursive", path)).Success;
        }

        private async Task<bool> CloneRepo(string url, string gitRoot, string sourceRoot, string repoName)
        {
            return (await RunExternalGitCommand($"clone --separate-git-dir={gitRoot}/{repoName}.git --recursive {url} {sourceRoot}/{repoName}")).Success;
        }

        private async Task<bool> FetchRepo(string url, string path)
        {
            return (await RunExternalGitCommand($"fetch {url}", path)).Success;
        }

        private async Task<bool> CleanAndResetRepo(string path)
        {
            return (await RunExternalGitCommand($"clean -fxd", path)).Success &&
                   (await RunExternalGitCommand($"reset --hard HEAD", path)).Success;
        }

        private async void EnsureGit()
        {
            try
            {
                var gitExists = (await RunExternalGitCommand("--version")).Success;
            }
            catch (Exception e)
            {
                Log.LogError("git does not appear to be installed or working.  See error message for details.");
                Log.LogErrorFromException(e, true, true, null);
                throw;
            }
        }

        private static IEnumerable<RepoSpec> ReadSpecFile(string filePath)
        {
            var doc = XDocument.Load(filePath);
            foreach (var dep in doc.Element("Dependencies").Element("ToolsetDependencies").Elements("Dependency").Concat(doc.Element("Dependencies").Element("ProductDependencies").Elements("Dependency")))
            {
                if (!string.IsNullOrWhiteSpace(dep.Element("SkipClone")?.Value) && dep.Element("SkipClone").Value.ToLowerInvariant() == "true")
                {
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(dep.Element("RepoName")?.Value))
                {
                    yield return new RepoSpec(dep.Element("Uri").Value, dep.Element("RepoName").Value, dep.Element("Sha").Value);
                }
                else
                {
                    yield return new RepoSpec(dep.Element("Uri").Value, dep.Element("Sha").Value);
                }
            }
        }

        private class RepoSpec
        {
            internal string Url { get; set; }
            internal string Name { get; set; }
            internal string Hash { get; set; }

            public RepoSpec(string url, string hash) : this(url, url.Substring(url.LastIndexOf('/') + 1), hash)
            {
            }

            public RepoSpec(string url, string name, string hash)
            {
                this.Url = url;
                this.Name = name;
                this.Hash = hash;
            }

            public override bool Equals(object obj)
            {
                var other = obj as RepoSpec;
                if (other == null)
                {
                    return false;
                }
                return other.Url == this.Url && other.Name == this.Name;
            }

            public override int GetHashCode()
            {
                return this.Url.GetHashCode() ^ this.Name.GetHashCode();
            }

            public override string ToString()
            {
                return $"{this.Url} ({this.Name}) @ {this.Hash}";
            }
        }
    }
}
