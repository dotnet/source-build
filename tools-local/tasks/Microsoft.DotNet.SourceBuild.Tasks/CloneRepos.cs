using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.DotNet.SourceBuild.Tasks
{
    public class CloneRepos : Task
    {
        [Required]
        public string SourceRoot { get; set; }

        [Required]
        public string SpecFile { get; set; }

        public override bool Execute()
        {
            EnsureGit();

            foreach (var d in ReadSpecFile(SpecFile))
            {
                var cloneSuccess = CloneRepo(d.Url, Path.Combine(SourceRoot, d.Name));
                if (!cloneSuccess)
                {
                    Log.LogError($"Cloning {d.Url} into {Path.Combine(SourceRoot, d.Name)} failed.");
                }
                var checkoutSuccess = CheckoutRepo(Path.Combine(SourceRoot, d.Name), d.Hash);
                if (!checkoutSuccess)
                {
                    Log.LogError($"Checking out {d.Hash} in repo {Path.Combine(SourceRoot, d.Name)} failed.");
                }
                if (!cloneSuccess || !checkoutSuccess)
                {
                    break;
                }
            }

            return !Log.HasLoggedErrors;
        }

        private bool CheckoutRepo(string path, string hash)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = $"checkout {hash}",
                CreateNoWindow = true,
                WorkingDirectory = path,
            };
            var p = Process.Start(psi);
            p.WaitForExit();
            return p.ExitCode == 0;
        }

        private bool CloneRepo(string url, string path)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = $"clone --recursive {url} {path}",
                CreateNoWindow = true,
            };
            var p = Process.Start(psi);
            p.WaitForExit();
            return p.ExitCode == 0;
        }

        private static void EnsureGit()
        {

        }

        private static IEnumerable<RepoSpec> ReadSpecFile(string filePath)
        {
            var doc = XDocument.Load(filePath);
            foreach (var dep in doc.Element("Dependencies").Element("ToolsetDependencies").Elements("Depedency").Concat(doc.Element("Dependencies").Element("ProductDependencies").Elements("Dependency")))
            {
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
