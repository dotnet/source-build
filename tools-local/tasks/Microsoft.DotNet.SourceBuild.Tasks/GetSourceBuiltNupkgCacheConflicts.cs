// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.IO;
using System.Linq;

namespace Microsoft.DotNet.SourceBuild.Tasks
{
    /// <summary>
    /// For each source-built nupkg info given, ensure that if the package cache contains a package
    /// with the same id and version, the cached nupkg is the same as the source-built one.
    ///
    /// If the package cache contains a package with the same package id and version as a
    /// source-built one, nuget restore short-circuits and doesn't look for the source-built one.
    /// This usually results in prebuilt packages being used, which can either break the build or
    /// end up in the outputs.
    /// </summary>
    public class GetSourceBuiltNupkgCacheConflicts : Task
    {
        /// <summary>
        /// Items containing package id and version of each source-built package.
        /// ReadNuGetPackageInfos is recommended to generate these.
        ///
        /// %(Identity): Path to the original nupkg.
        /// %(PackageId): Identity of the package.
        /// %(PackageVersion): Version of the package.
        /// </summary>
        [Required]
        public ITaskItem[] SourceBuiltPackageInfos { get; set; }

        /// <summary>
        /// Package cache dir containing nupkgs to compare. Path is expected to be like:
        /// 
        /// {PackageCacheDir}/{lowercase id}/{version}/{lowercase id}.{version}.nupkg
        /// </summary>
        [Required]
        public string PackageCacheDir { get; set; }

        [Output]
        public ITaskItem[] ConflictingPackageInfos { get; set; }

        public override bool Execute()
        {
            DateTime startTime = DateTime.Now;

            ConflictingPackageInfos = SourceBuiltPackageInfos
                .Where(item =>
                {
                    string sourceBuiltPath = item.ItemSpec;
                    string id = item.GetMetadata("PackageId");
                    string version = item.GetMetadata("PackageVersion");

                    string packageCachePath = Path.Combine(
                        PackageCacheDir,
                        id.ToLowerInvariant(),
                        version,
                        $"{id.ToLowerInvariant()}.{version}.nupkg");

                    if (!File.Exists(packageCachePath))
                    {
                        Log.LogMessage(
                            MessageImportance.Low,
                            $"OK: Package not found in package cache: {id} {version}");
                        return false;
                    }

                    Log.LogMessage(
                        MessageImportance.Low,
                        $"Package id/version found in package cache, verifying: {id} {version}");

                    bool identical = File.ReadAllBytes(sourceBuiltPath)
                        .SequenceEqual(File.ReadAllBytes(packageCachePath));

                    if (!identical)
                    {
                        Log.LogMessage(
                            MessageImportance.Low,
                            "BAD: Source-built nupkg is not byte-for-byte identical " +
                                $"to nupkg in cache: {id} {version}");
                        return true;
                    }

                    Log.LogMessage(
                        MessageImportance.Low,
                        $"OK: Package in cache is identical to source-built: {id} {version}");
                    return false;
                })
                .ToArray();

            // Tell the user about this task, in case it takes a while.
            Log.LogMessage(
                MessageImportance.High,
                "Checked cache for conflicts with source-built nupkgs. " +
                    $"Took {DateTime.Now - startTime}");

            return !Log.HasLoggedErrors;
        }
    }
}
