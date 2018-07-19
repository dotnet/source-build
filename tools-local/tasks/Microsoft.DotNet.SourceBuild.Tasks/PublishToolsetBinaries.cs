// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// This is mostly a duplicate of PublishCoreSetupBinaries with a
// different regex (because version numbers are formatted differently
// between core-setup and toolset).
// https://github.com/dotnet/source-build/issues/554 tracks figuring
// out a better process for doing this.

using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet.Packaging;
using NuGet.Packaging.Core;

namespace Microsoft.DotNet.Build.Tasks
{
    public class PublishToolsetBinaries : Task
    {
        [Required]
        public ITaskItem[] Binaries { get; set; }

        [Required]
        public string DestinationFolderTemplate { get; set; }

        public override bool Execute()
        {
            // This regular expression is crafted to extract the semver component from the artifacts
            // that Core-Setup produces. They have filenames like this (note the two formats!)
            //   dotnet-runtime-rhel.7-x64.2.0.0-preview2-25401-9.tar.gz
            //   dotnet-runtime-2.0.0-preview2-25401-9-rhel.7-x64.tar.gz
            // the "semver" capture would be 2.0.0-beta-001545-00 in this case.
            const string VersionMatchRegex = @"(\.|-)(?'semver'[0-9]+\.[0-9]+\.[0-9]+(-[A-Za-z0-9]+(-[0-9]+(-[0-9]+)?)?)?)";

            bool anyErrors = false;

            foreach (ITaskItem binary in Binaries)
            {
                string binaryFullPath = binary.GetMetadata("FullPath");
                string binaryFileName = Path.GetFileName(binaryFullPath);
                string version = Regex.Match(binaryFileName, VersionMatchRegex).Groups["semver"].Value;

                if (version == "")
                {
                    Log.LogError($"Could not extract version information from {binaryFileName}");
                    anyErrors = true;
                    continue;
                }

                string destinationFolder = DestinationFolderTemplate.Replace("{version}", version);

                Directory.CreateDirectory(destinationFolder);
                File.Copy(binaryFullPath, Path.Combine(destinationFolder, binaryFileName), overwrite: true);
            }

            return !anyErrors;
        }
    }
}
