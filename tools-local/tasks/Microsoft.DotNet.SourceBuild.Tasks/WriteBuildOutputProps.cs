// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Versioning;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.DotNet.Build.Tasks
{
    public class WriteBuildOutputProps : Task
    {
        private static readonly Regex InvalidElementNameCharRegex = new Regex(@"(^|[^A-Za-z0-9])(?<FirstPartChar>.)");

        [Required]
        public ITaskItem[] NuGetPackages { get; set; }

        [Required]
        public string OutputPath { get; set; }

        /// <summary>
        /// Package id/versions to add to the build output props, which may not exist as nupkgs.
        /// 
        /// %(Identity): Package identity.
        /// %(Version): Package version.
        /// </summary>
        public ITaskItem[] ExtraPackageInfo { get; set; }

        /// <summary>
        /// Additional assets to be added to the build output props. They are assumed to have the
        /// structure <pathToAsset>/<assetName>/<assetVersion>
        /// i.e. /bin/obj/x64/Release/blobs/Toolset/3.0.100
        /// </summary>
        public string[] AdditionalAssetDirs { get; set; }

        private IEnumerable<PackageIdentity> ExtraPackageIdentities => ExtraPackageInfo
            ?.Select(item => new PackageIdentity(
                item.GetMetadata("Identity"),
                NuGetVersion.Parse(item.GetMetadata("Version"))))
            ?? Enumerable.Empty<PackageIdentity>();

        public override bool Execute()
        {
            PackageIdentity[] latestPackages = NuGetPackages
                .Select(item =>
                {
                    using (var reader = new PackageArchiveReader(item.GetMetadata("FullPath")))
                    {
                        return reader.GetIdentity();
                    }
                })
                .Concat(ExtraPackageIdentities)
                .GroupBy(identity => identity.Id)
                .Select(g => g.OrderBy(id => id.Version).Last())
                .OrderBy(id => id.Id)
                .ToArray();

            var additionalAssets = (AdditionalAssetDirs ?? new string[0])
                .Where(Directory.Exists)
                .Where(dir => Directory.GetDirectories(dir).Count() > 0)
                .Select(dir => new {
                    Name = new DirectoryInfo(dir).Name + "Version",
                    Version = new DirectoryInfo(Directory.EnumerateDirectories(dir).OrderBy(s => s).Last()).Name
                }).ToArray();

            Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));

            using (var outStream = File.Open(OutputPath, FileMode.Create))
            using (var sw = new StreamWriter(outStream, new UTF8Encoding(false)))
            {
                sw.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
                sw.WriteLine(@"<Project ToolsVersion=""14.0"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">");
                sw.WriteLine(@"  <PropertyGroup>");
                foreach (PackageIdentity packageIdentity in latestPackages)
                {
                    string propertyName = GetPropertyName(packageIdentity.Id);

                    sw.WriteLine($"    <{propertyName}>{packageIdentity.Version}</{propertyName}>");
                }
                foreach (var additionalAsset in additionalAssets)
                {
                    sw.WriteLine($"    <{additionalAsset.Name}>{additionalAsset.Version}</{additionalAsset.Name}>");
                }
                sw.WriteLine(@"  </PropertyGroup>");
                sw.WriteLine(@"</Project>");
            }

            return true;
        }

        public static string GetPropertyName(string id)
        {
            string formattedId = InvalidElementNameCharRegex.Replace(
                id,
                match => match.Groups?["FirstPartChar"].Value.ToUpperInvariant()
                    ?? string.Empty);

            return $"{formattedId}PackageVersion";
        }
    }
}
