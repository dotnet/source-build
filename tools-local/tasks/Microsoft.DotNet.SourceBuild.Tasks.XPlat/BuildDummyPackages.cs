// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Runtime.Versioning;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet.Packaging;
using NuGet.Packaging.Core;

namespace Microsoft.DotNet.Build.Tasks
{
    public class BuildDummyPackages : Task
    {
        [Required]
        public ITaskItem[] Packages { get; set; }

        [Required]
        public string OutputPath { get; set; }

        public override bool Execute()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));

            foreach (ITaskItem package in Packages)
            {
                string id = package.ItemSpec;
                string version = package.GetMetadata("Version");
                string destination = Path.Combine(OutputPath, $"{id}.{version}.nupkg");

                PackageBuilder builder = new PackageBuilder();
                ManifestMetadata mm = new ManifestMetadata();
                mm.Id = id;
                mm.Version = new NuGet.Versioning.NuGetVersion(version);
                mm.Authors = new string[] { "Microsoft" };
                mm.Description = "This is an empty package to satisfy a transitive dependency. Please do not use this package or publish it.";

                builder.Populate(mm);
                builder.Files.Add(new EmptyPackageFile());

                using (Stream pkg = File.OpenWrite(destination))
                {
                    builder.Save(pkg);
                }

                Log.LogMessage($"Created empty package '{destination}'");
            }

            return !Log.HasLoggedErrors;
        }

        class EmptyPackageFile : IPackageFile
        {
            public string Path => "_._";

            public string EffectivePath => "_._";

            public FrameworkName TargetFramework => new FrameworkName("netstandard", new Version(1,0,0));

            public DateTimeOffset LastWriteTime => DateTimeOffset.Now;

            public Stream GetStream()
            {
                return new MemoryStream();
            }
        }
    }
}
