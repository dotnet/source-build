using System;
using System.IO;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet.Packaging;
using NuGet.Packaging.Core;

namespace Microsoft.DotNet.Build.Tasks
{
    public class WriteVersionsFile : Task
    {
        [Required]
        public ITaskItem[] NugetPackages { get; set; }

        [Required]
        public string OutputPath { get; set; }

        public override bool Execute()
        {
            using (Stream outStream = File.Open(OutputPath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(outStream, new UTF8Encoding(false)))
                {
                    foreach (ITaskItem nugetPackage in NugetPackages)
                    {
                        using (PackageArchiveReader par = new PackageArchiveReader(nugetPackage.GetMetadata("FullPath")))
                        {
                            PackageIdentity packageIdentity = par.GetIdentity();
                            sw.WriteLine($"{packageIdentity.Id} {packageIdentity.Version}");
                        }
                    }
                }
            }

            return true;
        }
    }
}
