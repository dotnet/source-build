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
        public string SpecFile { get; set; }

        public override bool Execute()
        {
            EnsureGit();

            Parallel.ForEach(ReadSpecFile(SpecFile), async d =>
            {
                var cloneSuccess = await CloneRepo(d.Url, Path.Combine(SourceRoot, d.Name));
                if (!cloneSuccess)
                {
                    Log.LogError($"Cloning {d.Url} into {Path.Combine(SourceRoot, d.Name)} failed.");
                }
                var checkoutSuccess = await CheckoutRepo(Path.Combine(SourceRoot, d.Name), d.Hash);
                if (!checkoutSuccess)
                {
                    Log.LogError($"Checking out {d.Hash} in repo {Path.Combine(SourceRoot, d.Name)} failed.");
                }
            });

            return !Log.HasLoggedErrors;
        }

        private async Task<bool> RunExternalGitCommand(string args, string workingDir = null)
        {
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
            var p = Process.Start(psi);
            p.WaitForExit();
            if (p.ExitCode == 0)
            {
                Log.LogMessage("git command", null, null, null, 0, 0, 0, 0, MessageImportance.Low, await p.StandardOutput.ReadToEndAsync());
                return true;
            }
            else
            {
                Log.LogError("git command", p.ExitCode, null, null, 0, 0, 0, 0, $"command {psi.FileName} {psi.Arguments} in directory {psi.WorkingDirectory} failed.  Command output follows:");
                Log.LogError(await p.StandardOutput.ReadToEndAsync());
                Log.LogError(await p.StandardError.ReadToEndAsync());
                return false;
            }
        }

        private async Task<bool> CheckoutRepo(string path, string hash)
        {
            return await RunExternalGitCommand($"checkout {hash}") &&
                   await RunExternalGitCommand($"submodule update --init --recursive");
        }

        private async Task<bool> CloneRepo(string url, string path)
        {
            return await RunExternalGitCommand($"clone --recursive {url} {path}");
        }

        private async void EnsureGit()
        {
            try
            {
                var gitExists = await RunExternalGitCommand("--version");
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
