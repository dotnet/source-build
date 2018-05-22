// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Build.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Task = Microsoft.Build.Utilities.Task;

namespace Microsoft.DotNet.SourceBuild.Tasks.UsageReport
{
    public class WritePackageUsageData : Task
    {
        /// <summary>
        /// %(PackageId): Identity of the package.
        /// %(PackageVersion): Version of the package.
        /// </summary>
        [Required]
        public ITaskItem[] NuGetPackageInfos { get; set; }

        /// <summary>
        /// Project directories to scan for project.assets.json files. If these directories contain
        /// one another, the project.assets.json files is reported as belonging to the first project
        /// directory that contains it. For useful results, put the leafmost directories first.
        /// </summary>
        [Required]
        public string[] ProjectDirectories { get; set; }

        /// <summary>
        /// Output usage data JSON file path.
        /// </summary>
        [Required]
        public string DataFile { get; set; }

        public override bool Execute()
        {
            string[] packageIdentities = NuGetPackageInfos
                .Select(item => $"{item.GetMetadata("PackageId")}/{item.GetMetadata("PackageVersion")}")
                .ToArray();

            // Remove trailing slash from dir to avoid EnumerateFiles method adding slash twice,
            // which would cause multiple unique paths per file and break the hash set.
            ProjectDirectories = ProjectDirectories
                .Where(Directory.Exists)
                .Select(dir => dir.TrimEnd('/', '\\'))
                .ToArray();

            Log.LogMessage(MessageImportance.High, "Finding project.assets.json files...");

            Dictionary<string, IEnumerable<string>> projectDirAssetFiles = ProjectDirectories
                .ToDictionary(
                    dir => dir,
                    dir => Directory.EnumerateFiles(
                        dir,
                        "project.assets.json",
                        SearchOption.AllDirectories));

            Log.LogMessage(MessageImportance.High, "Reading usage info...");

            var assetFileUsages = new ConcurrentDictionary<string, Usage[]>();

            Parallel.ForEach(
                projectDirAssetFiles.Values.SelectMany(v => v).Distinct(),
                assetsFile =>
                {
                    string contents = File.ReadAllText(assetsFile);

                    assetFileUsages.TryAdd(
                        assetsFile,
                        packageIdentities
                            .Where(id => IsIdentityInText(id, contents))
                            .Select(id => new Usage
                            {
                                AssetsFile = assetsFile,
                                PackageIdentity = id
                            })
                            .ToArray());
                });

            Log.LogMessage(MessageImportance.High, "Associating usage info with projects...");

            var usedAssetFiles = new HashSet<string>();
            var usages = new List<Usage>();

            foreach (string dir in ProjectDirectories)
            {
                foreach (string assetsFile in projectDirAssetFiles[dir])
                {
                    if (usedAssetFiles.Add(assetsFile))
                    {
                        foreach (var usage in assetFileUsages[assetsFile])
                        {
                            usage.ProjectDirectory = dir;
                            usages.Add(usage);
                        }
                    }
                }
            }

            Log.LogMessage(MessageImportance.High, $"Writing data to '{DataFile}'...");

            Directory.CreateDirectory(Path.GetDirectoryName(DataFile));

            string[] unused = packageIdentities
                .Where(id => !usages.Any(u => IsIdentityEqual(id, u.PackageIdentity)))
                .ToArray();

            var data = new UsageData
            {
                UnusedPackages = unused,
                Usages = usages.ToArray()
            };

            File.WriteAllText(DataFile, JsonConvert.SerializeObject(data, Formatting.Indented));

            return !Log.HasLoggedErrors;
        }

        private static bool IsIdentityEqual(string identity, string other)
        {
            return string.Equals(identity, other, StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsIdentityInText(string identity, string text)
        {
            return text.IndexOf(identity, StringComparison.OrdinalIgnoreCase) != -1;
        }
    }
}
