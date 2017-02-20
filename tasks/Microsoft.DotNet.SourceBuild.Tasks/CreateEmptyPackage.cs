using System;
using System.IO;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Versioning;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.DotNet.SourceBuild.Tasks
{
    public class CreateEmptyPackage : Task
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Version { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Authors { get; set; }
        [Required]
        public string Owners { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string OutputDirectory { get; set; }
        public string RuntimeIdentifier { get; set; }
        public string PlaceHolderFile { get; set; }
        public override bool Execute()
        {
            try
            {
                PackageBuilder builder = new PackageBuilder();

                builder.Populate(CreateManifest().Metadata);
                builder.PopulateFiles(Path.GetDirectoryName(PlaceHolderFile), new List<ManifestFile>()
                {
                    new ManifestFile()
                    {
                        Source = PlaceHolderFile,
                        Target = "lib"
                    }
                });
                string nupkgOutputDirectory = OutputDirectory;

                string nupkgFilename = $"{Id}.{Version}.nupkg";
                if(!string.IsNullOrEmpty(RuntimeIdentifier))
                {
                    nupkgFilename = $"runtime.{RuntimeIdentifier}.{nupkgFilename}";
                }
                string nupkgPath = Path.Combine(nupkgOutputDirectory, nupkgFilename);
                string directory = Path.GetDirectoryName(nupkgPath);
                if(!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                using (var fileStream = File.Create(nupkgPath))
                {
                    builder.Save(fileStream);
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                Log.LogErrorFromException(ex);
            }

            return !Log.HasLoggedErrors;
        }

        private Manifest CreateManifest()
        {
            Manifest manifest;
            manifest = new Manifest(new ManifestMetadata());

            ManifestMetadata manifestMetadata = manifest.Metadata;
            manifestMetadata.Authors = Authors?.Split(';');
            manifestMetadata.Description = Description;
            manifestMetadata.Id = Id;
            manifestMetadata.Owners = Owners?.Split(';');
            manifestMetadata.Title = Title;
            manifestMetadata.Version = Version != null ? new NuGetVersion(Version) : null;
            return manifest;
        }
    }
}
