// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet.Packaging;
using NuGet.Packaging.Core;

namespace Microsoft.DotNet.Build.Tasks
{
    public class PublishCoreSetupBinaries : Task
    {
        [Required]
        public ITaskItem[] Binaries { get; set; }

        [Required]
        public string DestinationFolderTemplate { get; set; }

        [Output]
        public string PublishedVersion { get; set; }

        // This regular expression is crafted to extract the semver component from the artifacts
        // that Core-Setup produces. They have filenames like this (note the two formats!)
        //   dotnet-runtime-rhel.7-x64.2.0.0-preview2-25401-9.tar.gz
        //   dotnet-runtime-2.0.0-preview2-25401-9-rhel.7-x64.tar.gz
        // the "semver" capture would be 2.0.0-preview2-25401-9 in this case.
        protected virtual string VersionMatchRegex => @"(\.|-)(?'semver'[0-9]+\.[0-9]+\.[0-9]+(([-.])[A-Za-z0-9]+)*)";

        // The regular expression is even more of a mess when we try to account for every RID and suffix that may exist.
        // This is a list of bad stuff we should remove that's never part of a version number.  If adding to it, it
        // should include the delimiter immediately before the RID, arch, or extension.
        protected string[] BadAtoms = new[] { @"-x64", @"\.x64",
                                              @"-arm64", @"\.arm64",
                                              @"\.tar", @"\.gz",
                                              @"-rhel\.\d+", @"\.rhel\.\d+",
                                              @"\.centos\.\d+", @"-centos\.\d+",
                                              @"\.fedora\.\d+", @"-fedora\.\d+",
                                              @"-linux", @"\.linux",
                                              @"-osx", @"\.osx",
                                              @"-OSX", @"\.OSX",
                                              @"-osx\.10", @"\.osx\.10",
                                              @"-OSX\.10", @"\.OSX\.10",
                                              @"-osx\.10\.\d+", @"\.osx\.10\.\d+",
                                              @"-OSX\.10\.\d+", @"\.OSX\.10\.\d+",
                                              @"-ubuntu\.\d+\.\d+", @"\.ubuntu\.\d+\.\d+",
                                              @"-debian\.\d+", @"\.debian\.\d+",
                                            };

        public override bool Execute()
        {
            bool anyErrors = false;

            foreach (ITaskItem binary in Binaries)
            {
                string binaryFullPath = binary.GetMetadata("FullPath");
                string binaryFileName = Path.GetFileName(binaryFullPath);
                string version = Regex.Match(binaryFileName, VersionMatchRegex).Groups["semver"].Value;

                foreach (var ba in BadAtoms)
                {
                    version = Regex.Replace(version, ba, "");
                }

                if (version == "")
                {
                    Log.LogError($"Could not extract version information from {binaryFileName}");
                    anyErrors = true;
                    continue;
                }

                string destinationFolder = DestinationFolderTemplate.Replace("{version}", version);

                Directory.CreateDirectory(destinationFolder);
                File.Copy(binaryFullPath, Path.Combine(destinationFolder, binaryFileName), overwrite: true);

                PublishedVersion = version;
            }

            return !anyErrors;
        }
    }
}
