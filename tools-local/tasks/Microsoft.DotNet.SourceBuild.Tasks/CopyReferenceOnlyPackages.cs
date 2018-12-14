// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Microsoft.DotNet.SourceBuild.Tasks
{
    /// <summary>
    /// For each nupkg directory under the PackageCacheDir, find all directories containing only
    /// dlls under the /ref/ folder.  These are packages that contain references only.
    /// Copies all found expanded reference-only packages to the destination directory, excluding
    /// the .nupkg file.  
    /// </summary>
    public class CopyReferenceOnlyPackages : Task
    {
        private static readonly string[] extensionsToExclude = { ".exe", ".dylib", ".so", ".profdata", ".pgd", ".a" };
        private static readonly string[] pathsToExclude = { "testdata" };
        private static readonly string refPath = string.Concat(Path.DirectorySeparatorChar, "ref", Path.DirectorySeparatorChar);

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
        /// The destination directory for the dlls in reference packages.
        /// Paths are preserved in the destination.
        /// </summary>
        [Required]
        public string DllDestinationDir { get; set; }

        /// <summary>
        /// The destination directory for the nupkg files identified 
        /// as containing reference-only packages.
        /// </summary>
        [Required]
        public string IdentifiedPackagesDir { get; set; }

        /// <summary>
        /// The destination directory for the reference packages.
        /// </summary>
        [Required]
        public string DestinationDir { get; set; }

        public override bool Execute()
        {
            DateTime startTime = DateTime.Now;

            var referenceOnlyPackageDirectories = EnumerateAllFiles(PackageCacheDir, "*.nupkg")
                .Where(nupkgFilePath =>
                {
                    // Get all files in the nupkg path and normalize directory separators
                    var nupkgFiles = EnumerateAllFiles(Path.GetDirectoryName(nupkgFilePath), "*").ToArray();

                    // Do not include directories that contain exes, shared object files, OSX dynamic libraries
                    // or profiling data.  Also remove binaries with no extension.
                    if (nupkgFiles
                        .Any(
                            file => extensionsToExclude.Contains(Path.GetExtension(file)) 
                            || pathsToExclude.Any(path => file.Contains(path))
                            || (Path.GetExtension(file) == "" && IsBinaryFile(file))
                            )
                        )
                    {
                        return false;
                    }
                    
                    // Return directories that, if containing dlls, only have dlls in the
                    // ref folder
                    return nupkgFiles
                            .Where(file => String.Equals(Path.GetExtension(file), ".dll", StringComparison.OrdinalIgnoreCase))
                            .All(dir => dir.Contains(refPath));
                })
                .Select(Path.GetDirectoryName)
                .ToArray();

            Directory.CreateDirectory(IdentifiedPackagesDir);
            foreach (var dir in referenceOnlyPackageDirectories)
            {
                foreach (var file in EnumerateAllFiles(dir, "*"))
                {
                    if (file.EndsWith(".nupkg")) 
                    {
                        File.Copy(file, Path.Combine(IdentifiedPackagesDir, Path.GetFileName(file)), true);
                    }
                    else if (!file.EndsWith(".nupkg.sha512"))
                    {
                        var destination = file.Replace(PackageCacheDir, DestinationDir);
                        if (file.EndsWith(".dll"))
                        {
                            destination = file.Replace(PackageCacheDir, DllDestinationDir);
                        }
                        Directory.CreateDirectory(Path.GetDirectoryName(destination));
                        File.Copy(file, destination, true);
                        
                        // Add a wildcard for files in each nuspec
                        if (destination.EndsWith(".nuspec"))
                        {
                            var fileText = File.ReadAllText(destination);
                            File.WriteAllText(destination, fileText.Replace("</package>", "<files><file src=\".\\**\\*\"/></files>\n</package>"));
                        }
                    }
                }
            }

            // Report status on the task
            Log.LogMessage(
                MessageImportance.High,
                "Identified reference-only packages. " +
                    $"Found {referenceOnlyPackageDirectories.Count()} packages.  Took {DateTime.Now - startTime} ");

            return !Log.HasLoggedErrors;
        }

        /// <summary>
        /// Enumerate all files in a directory and its sub-directories.
        /// </summary>
        private static IEnumerable<string> EnumerateAllFiles(string path, string searchPattern)
        {
            return Directory.EnumerateFiles(path, searchPattern, SearchOption.AllDirectories);
        }


        /// <summary>
        /// Quick binary file detection.  If file contains double null in the first 512 characters
        /// chances are high that it is binary.  This is only used when files have no extensions.
        /// </summary>
        private static bool IsBinaryFile(string filePath)
        {
            int ch1 = ' ', ch2 = ' ';
            int charCount = 512;
            using (StreamReader stream = new StreamReader(new FileStream(filePath, FileMode.Open)))
            {
                while ((ch1 = stream.Read()) != -1 && charCount-- > 0)
                {
                    if (ch1 == '\0' && ch2 == '\0')
                    {
                        return true;
                    }
                    ch2 = ch1;
                }
            }
            return false;
        }

    }
}
