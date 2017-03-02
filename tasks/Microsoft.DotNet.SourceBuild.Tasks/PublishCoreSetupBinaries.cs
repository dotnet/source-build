using System;
using System.IO;
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

        public override bool Execute()
        {
            // This regular expression is crafted to extract the semver component from the artifacts
            // that Core-Setup produces. They have filenames like this:
            //   dotnet-hostfxr-ubuntu-x64.2.0.0-beta-001545-00.tar.gz
            // the "semver" capture would be 2.0.0-beta-001545-00 in this case.
            const string VersionMatchRegex = @"\.(?'semver'[0-9]+\.[0-9]+\.[0-9]+(-[A-Za-z0-9\-]+)?)";

            foreach (ITaskItem binary in Binaries)
            {
                string binaryFullPath = binary.GetMetadata("FullPath");
                string binaryFileName = Path.GetFileName(binaryFullPath);
                string version = Regex.Match(binaryFileName, VersionMatchRegex).Groups["semver"].Value;

                string destinationFolder = DestinationFolderTemplate.Replace("{version}", version);

                Directory.CreateDirectory(destinationFolder);
                File.Copy(binaryFullPath, Path.Combine(destinationFolder, binaryFileName), overwrite: true);
            }

            return true;
        }
    }
}
