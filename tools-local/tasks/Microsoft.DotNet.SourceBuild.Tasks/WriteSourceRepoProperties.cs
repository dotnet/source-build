// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.DotNet.SourceBuild.Tasks.Models;
using NuGet.Versioning;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Microsoft.DotNet.Build.Tasks
{
    public class WriteSourceRepoProperties : Task
    {
        [Required]
        public string VersionDetailsPath { get; set; }

        [Required]
        public string GitDirPath { get; set; }

        [Required]
        public string SourceDirPath { get; set; }

        [Required]
        public string SourceBuildMetadataPath { get; set; }

        public override bool Execute()
        {
            var serializer = new XmlSerializer(typeof(VersionDetails));
            VersionDetails versionDetails = null;
            using (var stream = File.OpenRead(VersionDetailsPath))
            {
                versionDetails = (VersionDetails)serializer.Deserialize(stream);
            }

            foreach(var dep in versionDetails.ToolsetDependencies.Concat(versionDetails.ProductDependencies))
            {
                Log.LogMessage(MessageImportance.Normal, $"[{DateTimeOffset.Now}] Starting dependency {dep.ToString()}");
                var repoPath = DeriveRepoPath(SourceDirPath, dep.Uri, dep.Sha);
                var repoGitDir = DeriveRepoGitDirPath(GitDirPath, dep.Uri);
                try
                {
                    WriteMinimalMetadata(repoPath, dep.Uri, dep.Sha);
                    WriteSourceBuildMetadata(SourceBuildMetadataPath, repoGitDir, dep);
                    if (File.Exists(Path.Combine(repoPath, ".gitmodules")))
                    {
                        HandleSubmodules(repoPath, repoGitDir, dep);
                    }
                }
                catch (Exception e)
                {
                    Log.LogErrorFromException(e, true, true, null);
                }
            }

            return !Log.HasLoggedErrors;
        }

        private static void WriteSourceBuildMetadata(string sourceBuildMetadataPath, string repoGitDir, Dependency dependency)
        {
            var propsPath = Path.Combine(sourceBuildMetadataPath, $"{GetRepoNameOrDefault(dependency)}.props");
            var commitCount = GetCommitCount(repoGitDir, dependency.Sha);
            var (officialBuildId, releaseLabel) = GetVersionInfo(dependency.Version, commitCount);
            var content = new StringBuilder();
            content.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            content.AppendLine("<Project>");
            content.AppendLine("  <PropertyGroup>");
            content.AppendLine($"    <GitCommitHash>{dependency.Sha}</GitCommitHash>");
            content.AppendLine($"    <GitCommitCount>{commitCount}</GitCommitCount>");
            content.AppendLine($"    <GitCommitDate>{GetCommitDate(repoGitDir, dependency.Sha)}</GitCommitDate>");
            content.AppendLine($"    <OfficialBuildId>{officialBuildId}</OfficialBuildId>");
            content.AppendLine($"    <OutputPackageVersion>{dependency.Version}</OutputPackageVersion>");
            content.AppendLine($"    <PreReleaseLabel>{releaseLabel}</PreReleaseLabel>");
            content.AppendLine("  </PropertyGroup>");
            content.AppendLine("</Project>");
            File.WriteAllText(propsPath, content.ToString());
        }

        private static (string, string) GetVersionInfo(string version, string commitCount)
        {
            var nugetVersion = new NuGetVersion(version);

            if (!string.IsNullOrWhiteSpace(nugetVersion.Release))
            {
                var releaseParts = nugetVersion.Release.Split('-', '.');
                if (releaseParts.Length == 2)
                {
                    if (releaseParts[1].TrimStart('0') == commitCount)
                    {
                        // core-sdk does this - OfficialBuildId is only used for their fake package and not in anything shipped
                        return (DateTime.Now.ToString("yyyyMMdd.1"), releaseParts[0]);
                    }
                    else
                    {
                        // NuGet does this - arbitrary build IDs
                        return (releaseParts[1], releaseParts[0]);
                    }
                }
                else if (releaseParts.Length == 3)
                {
                    if (int.TryParse(releaseParts[1], out int datePart) && int.TryParse(releaseParts[2], out int buildPart))
                    {
                        return ($"20{((datePart / 1000))}{((datePart % 1000) / 50):D2}{(datePart % 50):D2}.{buildPart}", releaseParts[0]);
                    }
                }
            }
            else
            {
                // finalized version number (x.y.z) - probably not our code
                // VSTest, Application Insights, Newtonsoft.Json do this
                return (DateTime.Now.ToString("yyyyMMdd.1"), string.Empty);
            }

            throw new FormatException($"Can't derive a build ID from version {version} (commit count {commitCount})");
        }

        private static object GetRepoNameOrDefault(Dependency dependency)
        {
            if (dependency.RepoName != null)
            {
                return dependency.RepoName;
            }
            var repoUrl = dependency.Uri;
            if (repoUrl.EndsWith(".git"))
            {
                repoUrl = repoUrl.Substring(0, repoUrl.Length - ".git".Length);
            }
            return repoUrl.Substring(repoUrl.LastIndexOf("/") + 1);
        }

        private static string GetCommitCount(string gitDir, string hash)
        {
            return RunGitCommand($"rev-list --count {hash}", gitDir: gitDir);
        }

        private static string GetCommitDate(string gitDir, string hash)
        {
            return RunGitCommand($"log -1 --format=%cd --date=short", gitDir: gitDir);
        }

        private static string RunGitCommand(string command, string workTree = null, string gitDir = null)
        {
            // Windows Git requires these to be before the command
            if (workTree != null)
            {
                command = $"--work-tree={workTree} {command}";
            }
            if (gitDir != null)
            {
                command = $"--git-dir={gitDir} {command}";
            }
            var psi = new ProcessStartInfo { FileName = "git", Arguments = command, RedirectStandardOutput = true, RedirectStandardError = true, UseShellExecute = false, CreateNoWindow = true };
            var p = new Process { StartInfo = psi };
            p.Start();
            var output = p.StandardOutput.ReadToEnd();
            var error = p.StandardError.ReadToEnd();
            p.WaitForExit();
            if (p.ExitCode != 0)
            {
                throw new InvalidOperationException($"git command {command} failed with exit code {p.ExitCode} and error {error ?? "<blank>"}");
            }
            return output.Trim();
        }

        private static string DeriveRepoGitDirPath(string gitDirPath, string repoUrl)
        {
            if (repoUrl.EndsWith(".git"))
            {
                repoUrl = repoUrl.Substring(0, repoUrl.Length - ".git".Length);
            }

            return Path.Combine(gitDirPath, $"{repoUrl.Substring(repoUrl.LastIndexOf("/") + 1)}.git");
        }

        private static void HandleSubmodules(string sourceDirPath, string gitDirPath, Dependency dependency)
        {
            var gitModulesPath = Path.Combine(sourceDirPath, ".gitmodules");
            var gitModules = File.ReadAllText(gitModulesPath);
            // This is a fun one.
            // Start with header [submodule "name"]
            // Then we have any number of parameters we don't care about, like
            //      branch = release/3.0
            //      url = https://example.com/project.git
            // Then we have the one we do care about:
            //      path = some/file/path
            // Then we have possibly more stuff we don't care about.
            // And finally we non-consuming anchor to either the next submodule header "[" or the end of the input so we stop capturing.
            var gitModuleRegex = new Regex(@"\[\s*submodule\s+""(?<submoduleName>.+?)""\](\s+\w+\s*=\s*(.+?)\s)*?\s+path\s*=\s*(?<submodulePath>.+?)\s(\w+\s*=\s*(.+?)\s)*?(?=(\[|$))", RegexOptions.Singleline);
            foreach (Match m in gitModuleRegex.Matches(gitModules))
            {
                HandleSubmodule(sourceDirPath, gitDirPath, dependency.Sha, m.Groups["submoduleName"].Value, m.Groups["submodulePath"].Value.Trim());
            }
        }

        private static void HandleSubmodule(string sourceDirPath, string gitDirPath, string parentRepoSha, string submoduleName, string submodulePath)
        {
            var submoduleSha = GetSubmoduleCommit(gitDirPath, parentRepoSha, submodulePath);
            var headDirectory = Path.Combine(sourceDirPath, ".git", "modules", submoduleName);
            var headPath = Path.Combine(headDirectory, "HEAD");
            Directory.CreateDirectory(headDirectory);
            File.WriteAllText(headPath, submoduleSha);
        }

        private static void WriteMinimalMetadata(string repoPath, string repoUrl, string hash)
        {
            var fakeGitDirPath = Path.Combine(repoPath, ".git");
            var fakeGitConfigPath = Path.Combine(fakeGitDirPath, "config");
            var fakeGitHeadPath = Path.Combine(fakeGitDirPath, "HEAD");

            Directory.CreateDirectory(fakeGitDirPath);
            File.WriteAllText(fakeGitHeadPath, hash);
            File.WriteAllText(fakeGitConfigPath, $"[remote \"origin\"]{Environment.NewLine}url = \"{repoUrl}\"");
        }

        private static string DeriveRepoPath(string sourceDirPath, string repoUrl, string hash)
        {
            if (repoUrl.EndsWith(".git"))
            {
                repoUrl = repoUrl.Substring(0, repoUrl.Length - ".git".Length);
            }

            // hash could actually be a branch or tag, make it filename-safe
            hash = hash.Replace('/', '-').Replace('\\', '-').Replace('?', '-').Replace('*', '-').Replace(':', '-').Replace('|', '-').Replace('"', '-').Replace('<', '-').Replace('>', '-');
            return Path.Combine(sourceDirPath, $"{repoUrl.Substring(repoUrl.LastIndexOf("/") + 1)}.{hash}");
        }

        private static string GetSubmoduleCommit(string gitDirPath, string parentRepoSha, string submodulePath)
        {
            var gitObjectList = RunGitCommand($"ls-tree {parentRepoSha} {submodulePath}", gitDir: gitDirPath);
            var submoduleRegex = new Regex(@"\d{6}\s+commit\s+(?<submoduleSha>[a-fA-F0-9]{40})\s+(.+)");
            var submoduleMatch = submoduleRegex.Match(gitObjectList);
            if (!submoduleMatch.Success)
            {
                throw new InvalidDataException($"Couldn't find a submodule commit in {gitObjectList} for {submodulePath}");
            }
            return submoduleMatch.Groups["submoduleSha"].Value;
        }
    }
}
