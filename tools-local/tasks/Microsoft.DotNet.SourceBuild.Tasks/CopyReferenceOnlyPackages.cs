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
    /// For each nupkg directory under the PackageCacheDir, find all directories containing only
    /// dlls under the /ref/ folder.  These are packages that contain references only.
    /// Copies all found expanded reference-only packages to the destination directory, excluding
    /// the .nupkg file.  The .nupkg file is deleted from the PackageCacheDir so it doesn't end up
    /// in prebuilts.
    /// </summary>
    public class CopyReferenceOnlyPackages : Task
    {
        /// <summary>
        /// Package cache dir containing prebuilt nupkgs. Path is expected to be like:
        /// 
        /// {PackageCacheDir}/{lowercase id}/{version}/{lowercase id}.{version}.nupkg
        ///
        /// This code assumes that these are expanded packages loaded from nuget.
        /// </summary>
        [Required]
        public string PackageCacheDir { get; set; }

        /// <summary>
        /// The destination directory for the reference packages.
        /// </summary>
        [Required]
        public string DestinationDir { get; set; }
        public override bool Execute()
        {
            DateTime startTime = DateTime.Now;

            var referenceOnlyPackageDirectories = Directory.EnumerateFiles(PackageCacheDir, "*.nupkg", SearchOption.AllDirectories)
                .Where(nupkgFilePath =>
                {
                    // Get all files in the nupkg path and normalize directory separators
                    var nupkgFiles = Directory.EnumerateFiles(Path.GetDirectoryName(nupkgFilePath), "*.*", SearchOption.AllDirectories).Select(f => f.Replace("\\","/"));

                    // Do not include directories that contain exes, shared object files, OSX dynamic libraries
                    // or profiling data
                    string[] extensionsToExclude = { ".exe", ".dylib", ".so", ".profdata", ".pgd" };
                    string[] pathsToExclude = { "testdata" };
                    
                    // Return directories that, if containing dlls, only have dlls in the
                    // ref folder.
                    return
                        !nupkgFiles.Any(file => extensionsToExclude.Contains(Path.GetExtension(file)) || pathsToExclude.Any(path => file.Contains(path))) &&
                        nupkgFiles
                            .Where(file => String.Equals(Path.GetExtension(file), ".dll", StringComparison.OrdinalIgnoreCase))
                            .All(dir => dir.Contains(@"/ref/"));
                })
                .Select(f => Path.GetDirectoryName(f));

            foreach (var dir in referenceOnlyPackageDirectories)
            {
                Log.LogMessage(
                    MessageImportance.High,
                    $"{dir}");
                Directory.CreateDirectory(dir.Replace(PackageCacheDir, DestinationDir));
                foreach (string dirPath in Directory.EnumerateDirectories(dir, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(PackageCacheDir, DestinationDir));
                }
                if (Directory.EnumerateFiles(dir, "*.dll", SearchOption.AllDirectories).Count() > 0)
                {
                    Log.LogMessage(
                        MessageImportance.High,
                            $"Found dlls in {dir}.");
                }
                foreach (var file in Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories).Where(f => !f.EndsWith(".nupkg") && !f.EndsWith(".nupkg.sha512")))
                {
                    File.Copy(file, file.Replace(PackageCacheDir, DestinationDir));
                }
                // Remove nupkgs for the packages that were copied so they don't end up in prebuilts
                foreach (var file in Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories).Where(f => f.EndsWith(".nupkg")))
                {
                    File.Delete(file);
                }
            }

            foreach (var file in Directory.EnumerateFiles(DestinationDir, "*.nuspec", SearchOption.AllDirectories))
            {
                Log.LogMessage(MessageImportance.High, $"Adding <files> section to {file}");
                var fileText = File.ReadAllText(file);
                File.WriteAllText(file, fileText.Replace("</package>", "<files><file src=\".\\**\\*.*\"/></files>\n</package>"));
            }
            // Report status on the task
            Log.LogMessage(
                MessageImportance.High,
                "Identified reference-only packages. " +
                    $"Found {referenceOnlyPackageDirectories.Count()} packages.  Took {DateTime.Now - startTime} ");

            return !Log.HasLoggedErrors;
        }

    }
}
