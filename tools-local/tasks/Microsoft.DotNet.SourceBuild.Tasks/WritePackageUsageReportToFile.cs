// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Build.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task = Microsoft.Build.Utilities.Task;

namespace Microsoft.DotNet.SourceBuild.Tasks
{
    public class WritePackageUsageReportToFile : Task
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

        [Required]
        public string OutputDirectory { get; set; }

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

            Log.LogMessage(MessageImportance.High, $"Creating report XML in '{OutputDirectory}'...");

            Directory.CreateDirectory(OutputDirectory);

            File.WriteAllText(Path.Combine(OutputDirectory, "UsageSummary.xml"), new XElement(
                "Usage",
                GroupsToElements(usages, Grouping.Package, Grouping.Project)).ToString());

            IEnumerable<XElement> unused = packageIdentities
                .Where(id => !usages.Any(u => IsIdentityEqual(id, u.PackageIdentity)))
                .Select(id => Node("Package", id, null));

            File.WriteAllText(Path.Combine(OutputDirectory, "UsageDetails.xml"), new XElement(
                "UsageReport",
                new XElement(
                    "Unknown",
                    unused),
                new XElement(
                    "PackageUsages",
                    GroupsToElements(usages, Grouping.Package, Grouping.Project, Grouping.AssetsFile)),
                new XElement(
                    "ProjectUsages",
                    GroupsToElements(usages, Grouping.Project, Grouping.Package, Grouping.AssetsFile))).ToString());

            return !Log.HasLoggedErrors;
        }

        private static IEnumerable<XElement> GroupsToElements(
            IEnumerable<Usage> usages,
            params Grouping[] groupings)
        {
            return GroupsToElementsCore(usages, groupings);
        }

        private static IEnumerable<XElement> GroupsToElementsCore(
            IEnumerable<Usage> usages,
            IEnumerable<Grouping> groupings)
        {
            if (!groupings.Any())
            {
                return null;
            }
            Grouping grouping = groupings.First();
            return usages
                .GroupBy(grouping.GetKey)
                .OrderBy(g => g.Key)
                .Select(g => Node(
                    grouping.Type,
                    g.Key,
                    GroupsToElementsCore(g, groupings.Skip(1))));
        }

        private static XElement Node(string type, string name, IEnumerable<XElement> children)
        {
            var node = new XElement(type, children);

            if (!string.IsNullOrEmpty(name))
            {
                node.Add(new XAttribute("Name", name));
            }

            return node;
        }

        private static bool IsIdentityEqual(string identity, string other)
        {
            return string.Equals(identity, other, StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsIdentityInText(string identity, string text)
        {
            return text.IndexOf(identity, StringComparison.OrdinalIgnoreCase) != -1;
        }

        private class Grouping
        {
            public static readonly Grouping Package = new Grouping
            {
                Type = nameof(Package),
                GetKey = u => u.PackageIdentity
            };

            public static readonly Grouping AssetsFile = new Grouping
            {
                Type = nameof(AssetsFile),
                GetKey = u => u.AssetsFile
            };

            public static readonly Grouping Project = new Grouping
            {
                Type = nameof(Project),
                GetKey = u => u.ProjectDirectory
            };

            public string Type { get; set; }
            public Func<Usage, string> GetKey { get; set; }
        }

        private class Usage
        {
            public string ProjectDirectory { get; set; }
            public string AssetsFile { get; set; }
            public string PackageIdentity { get; set; }
        }
    }
}
