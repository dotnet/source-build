﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Versioning;
using System;
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

        public const string CreationTimePropertyName = "BuildOutputPropsCreationTime";

        [Required]
        public ITaskItem[] NuGetPackages { get; set; }

        [Required]
        public string OutputPath { get; set; }

        /// <summary>
        /// Adds a second PropertyGroup to the output XML containing a property with the time of
        /// creation in UTC DateTime Ticks. This can be used to track creation time in situations
        /// where file metadata isn't reliable or preserved.
        /// </summary>
        public bool IncludeCreationTimeProperty { get; set; }

        /// <summary>
        /// Package id/versions to add to the build output props, which may not exist as nupkgs.
        /// 
        /// %(Identity): Package identity.
        /// %(Version): Package version.
        /// </summary>
        public ITaskItem[] ExtraPackageInfo { get; set; }

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
                sw.WriteLine(@"  </PropertyGroup>");
                if (IncludeCreationTimeProperty)
                {
                    sw.WriteLine(@"  <PropertyGroup>");
                    sw.WriteLine($@"    <{CreationTimePropertyName}>{DateTime.UtcNow.Ticks}</{CreationTimePropertyName}>");
                    sw.WriteLine(@"  </PropertyGroup>");
                }
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
