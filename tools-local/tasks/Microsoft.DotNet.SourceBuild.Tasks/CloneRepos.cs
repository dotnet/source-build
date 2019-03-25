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

        public override bool Execute()
        {
            EnsureGit();
            Directory.CreateDirectory(SourceRoot);
            Directory.CreateDirectory(GitRoot);

            Parallel.ForEach(ReadSpecFile(SpecFile), d =>
            {
                var force = false;
                if (Directory.Exists(Path.Combine(GitRoot, d.Name + ".git")))
                {
                    if (!Directory.Exists(Path.Combine(SourceRoot, d.Name)))
                    {
                        Directory.CreateDirectory(Path.Combine(SourceRoot, d.Name));
                        File.WriteAllText(Path.Combine(SourceRoot, d.Name, ".git"), $"gitdir: {Path.Combine(GitRoot, d.Name + ".git")}");
                        force = true;
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
                }

                var checkoutSuccess = CheckoutRepo(Path.Combine(SourceRoot, d.Name), d.Hash, force).Result;
                if (!checkoutSuccess)
                {
                    Log.LogError($"Checking out {d.Hash} in repo {Path.Combine(SourceRoot, d.Name)} failed.");
                }
            });

            return !Log.HasLoggedErrors;
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
