using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.DotNet.Build.Tasks
{
    public class WriteBuildOutputProps : Task
    {
        [Required]
        public ITaskItem[] NuGetPackages { get; set; }

        [Required]
        public string OutputPath { get; set; }

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
                .GroupBy(identity => identity.Id)
                .Select(g => g.OrderBy(id => id.Version).Last())
                .OrderBy(id => id.Id)
                .ToArray();

            Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));

            var invalidElementNameCharRegex = new Regex(@"(^|[^A-Za-z0-9])(?<FirstPartChar>.)");

            using (var outStream = File.Open(OutputPath, FileMode.Create))
            using (var sw = new StreamWriter(outStream, new UTF8Encoding(false)))
            {
                sw.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
                sw.WriteLine(@"<Project ToolsVersion=""14.0"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">");
                sw.WriteLine(@"  <PropertyGroup>");
                foreach (PackageIdentity packageIdentity in latestPackages)
                {
                    string formattedId = invalidElementNameCharRegex.Replace(
                        packageIdentity.Id,
                        match => match.Groups?["FirstPartChar"].Value.ToUpperInvariant()
                            ?? string.Empty);

                    string propertyName = $"{formattedId}PackageVersion";

                    sw.WriteLine($"    <{propertyName}>{packageIdentity.Version}</{propertyName}>");
                }
                sw.WriteLine(@"  </PropertyGroup>");
                sw.WriteLine(@"</Project>");
            }

            return true;
        }
    }
}
