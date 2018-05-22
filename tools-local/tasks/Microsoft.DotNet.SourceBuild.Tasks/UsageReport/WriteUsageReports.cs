// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Build.Framework;
using Microsoft.DotNet.Build.Tasks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Task = Microsoft.Build.Utilities.Task;

namespace Microsoft.DotNet.SourceBuild.Tasks.UsageReport
{
    public class WriteUsageReports : Task
    {
        private const string SnapshotPrefix = "PackageVersions.props.pre.";
        private const string SnapshotSuffix = ".xml";

        /// <summary>
        /// Source usage data JSON file.
        /// </summary>
        [Required]
        public string DataFile { get; set; }

        [Required]
        public string OutputDirectory { get; set; }

        /// <summary>
        /// A set of "PackageVersions.props.pre.{repo}.xml" files. They are analyzed to find
        /// packages built during source-build, and which repo built them. This info is added to the
        /// report. New packages are associated to a repo by going through each PVP in ascending
        /// file modification order.
        /// </summary>
        public ITaskItem[] PackageVersionPropsSnapshots { get; set; }

        /// <summary>
        /// Infos that associate packages to the ProdCon build they're from.
        /// 
        /// %(PackageId): Identity of the package.
        /// %(OriginBuildName): Name of the build that produced this package.
        /// </summary>
        public ITaskItem[] ProdConPackageInfos { get; set; }

        /// <summary>
        /// Path to a ProdCon build manifest file (build.xml) as an alternative way to pass
        /// ProdConPackageInfos items.
        /// </summary>
        public string ProdConBuildManifestFile { get; set; }

        /// <summary>
        /// Infos for packages that were approved as prebuilts in an earlier release.
        /// 
        /// %(PackageId): Identity of the package.
        /// %(PackageVersion): Version of the package.
        /// %(Release): Name of the earlier release, e.g. "2.0".
        /// </summary>
        public ITaskItem[] PreviousReleasePrebuiltPackageInfos { get; set; }

        /// <summary>
        /// File containing the results of poisoning the prebuilts. Example format:
        /// 
        /// MATCH: output built\dotnet-sdk-...\System.Collections.dll(hash 4b...31) matches one of:
        ///     intermediate\netstandard.library.2.0.1.nupkg\build\...\System.Collections.dll
        /// 
        /// The usage report reads this file, looking for 'intermediate\*.nupkg' to annotate.
        /// </summary>
        public string PoisonedReportFile { get; set; }

        public override bool Execute()
        {
            UsageData data = JObject.Parse(File.ReadAllText(DataFile)).ToObject<UsageData>();

            IEnumerable<RepoOutput> sourceBuildRepoOutputs = GetSourceBuildRepoOutputs();

            // Map package id to the build name that created them in a ProdCon build.
            var prodConPackageOrigin = new Dictionary<string, string>(
                StringComparer.OrdinalIgnoreCase);

            foreach (ITaskItem item in ProdConPackageInfos ?? Enumerable.Empty<ITaskItem>())
            {
                AddProdConPackage(
                    prodConPackageOrigin,
                    item.GetMetadata("PackageId"),
                    item.GetMetadata("OriginBuildName"));
            }

            if (File.Exists(ProdConBuildManifestFile))
            {
                var xml = XElement.Parse(File.ReadAllText(ProdConBuildManifestFile));
                foreach (var x in xml.Descendants("Package"))
                {
                    AddProdConPackage(
                        prodConPackageOrigin,
                        x.Attribute("Id")?.Value,
                        x.Attribute("OriginBuildName")?.Value);
                }
            }

            PreviousReleasePrebuilt[] previousReleasePrebuilts = PreviousReleasePrebuiltPackageInfos
                ?.Select(item => new PreviousReleasePrebuilt
                {
                    Id = item.GetMetadata("PackageId"),
                    Version = item.GetMetadata("PackageVersion"),
                    Release = item.GetMetadata("Release")
                })
                .ToArray();

            var poisonNupkgFilenames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            if (File.Exists(PoisonedReportFile))
            {
                foreach (string line in File.ReadAllLines(PoisonedReportFile))
                {
                    string[] segments = line.Split('\\');
                    if (segments.Length > 2 &&
                        segments[0].Trim() == "intermediate" &&
                        segments[1].EndsWith(".nupkg"))
                    {
                        poisonNupkgFilenames.Add(Path.GetFileNameWithoutExtension(segments[1]));
                    }
                }
            }

            foreach (Usage usage in data.Usages)
            {
                string[] identity = usage.PackageIdentity.Split('/');
                if (identity.Length != 2)
                {
                    Log.LogWarning(
                        $"Data file contains invalid package identity '{usage.PackageIdentity}'. " +
                        "Expected 2 segments when split by '/'.");
                    continue;
                }

                string id = identity[0];
                string version = identity[1];

                string pvpIdent = WriteBuildOutputProps.GetPropertyName(id);

                var sourceBuildCreator = new StringBuilder();
                foreach (RepoOutput output in sourceBuildRepoOutputs)
                {
                    foreach (PackageVersionPropsElement p in output.Built)
                    {
                        if (p.Name.Equals(pvpIdent, StringComparison.OrdinalIgnoreCase))
                        {
                            if (sourceBuildCreator.Length != 0)
                            {
                                sourceBuildCreator.Append(" ");
                            }
                            sourceBuildCreator.Append(output.Repo);
                            sourceBuildCreator.Append(" ");
                            sourceBuildCreator.Append(p.Name);
                            sourceBuildCreator.Append("/");
                            sourceBuildCreator.Append(p.Version);
                        }
                    }
                }

                prodConPackageOrigin.TryGetValue(id, out string prodConCreator);

                string previousReleasePrebuilt = previousReleasePrebuilts
                    ?.FirstOrDefault(p => p.Matches(id, version))
                    ?.Release;

                usage.Annotation = new UsageAnnotation
                {
                    SourceBuildPackageIdCreator = sourceBuildCreator.ToString(),
                    ProdConPackageIdCreator = prodConCreator,
                    InEarlierReleaseExactPrebuilt = previousReleasePrebuilt,
                    EndsUpInOutput = poisonNupkgFilenames.Contains($"{id}.{version}")
                };
            }

            Directory.CreateDirectory(OutputDirectory);

            File.WriteAllText(
                Path.Combine(OutputDirectory, "UsageSummary.xml"),
                data.CreateSummaryReport().ToString());

            File.WriteAllText(
                Path.Combine(OutputDirectory, "UsageDetails.xml"),
                data.CreateDetailedReport().ToString());

            return !Log.HasLoggedErrors;
        }

        private IEnumerable<RepoOutput> GetSourceBuildRepoOutputs()
        {
            if (PackageVersionPropsSnapshots == null)
            {
                return Enumerable.Empty<RepoOutput>();
            }

            var pvpSnapshotFiles = PackageVersionPropsSnapshots
                .Select(item => item.ItemSpec)
                .OrderBy(File.GetLastWriteTimeUtc)
                .Select(file =>
                {
                    string filename = Path.GetFileName(file);
                    return new
                    {
                        Repo = filename.Substring(
                            SnapshotPrefix.Length,
                            filename.Length - SnapshotPrefix.Length - SnapshotSuffix.Length),
                        PackageVersionProp = PackageVersionPropsElement.ParseFileElements(file)
                    };
                })
                .ToArray();

            return pvpSnapshotFiles.Skip(1)
                .Zip(pvpSnapshotFiles, (pvp, prev) => new RepoOutput
                {
                    Repo = prev.Repo,
                    Built = pvp.PackageVersionProp.Except(prev.PackageVersionProp).ToArray()
                })
                .ToArray();
        }

        private void AddProdConPackage(
            Dictionary<string, string> packageOrigin,
            string id,
            string origin)
        {
            if (!string.IsNullOrEmpty(id) &&
                !string.IsNullOrEmpty(origin))
            {
                packageOrigin[id] = origin;
            }
        }

        private class RepoOutput
        {
            public string Repo { get; set; }
            public PackageVersionPropsElement[] Built { get; set; }
        }

        private struct PackageVersionPropsElement
        {
            public static PackageVersionPropsElement[] ParseFileElements(string file)
            {
                return XElement.Parse(File.ReadAllText(file))
                    // Get the single PropertyGroup
                    .Nodes().OfType<XElement>()
                    .First()
                    // Get all *PackageVersion property elements.
                    .Nodes().OfType<XElement>()
                    .Select(x => new PackageVersionPropsElement(
                        x.Name.LocalName,
                        x.Nodes().OfType<XText>().First().Value))
                    .ToArray();
            }

            public string Name { get; }
            public string Version { get; }

            public PackageVersionPropsElement(string name, string version)
            {
                Name = name;
                Version = version;
            }
        }

        private class PreviousReleasePrebuilt
        {
            public string Id { get; set; }
            public string Version { get; set; }
            public string Release { get; set; }

            public bool Matches(string id, string version) =>
                Id.Equals(id, StringComparison.OrdinalIgnoreCase) &&
                Version.Equals(version, StringComparison.OrdinalIgnoreCase);
        }
    }
}
