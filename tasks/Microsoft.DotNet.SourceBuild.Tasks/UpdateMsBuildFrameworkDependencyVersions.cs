using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Build.Construction;

namespace Microsoft.DotNet.SourceBuild.Tasks
{
    public class UpdateMsBuildFrameworkDependencyVersions : Task
    {
        [Required]
        public string ProjectPath { get; set; }
        [Required]
        public ITaskItem[] NuGetPackages { get; set; }

        public override bool Execute()
        {
            var projectRoot = ProjectRootElement.Open(ProjectPath);

            var packageIdentities = GetPackageIdentityCollection(NuGetPackages);

            Dictionary<ProjectItemElement, string> updatedItems = new Dictionary<ProjectItemElement, string>();
            ProjectElementContainer parent = null;
            foreach(var item in projectRoot.Items)
            {
                if (item.ItemType == "PackageReference")
                {
                    PackageIdentity identity = packageIdentities.FirstOrDefault(p => p.Id == item.Include);

                    if (identity != null)
                    {
                        // Save the PackageReference parent ItemGroup so we can append to it
                        if (parent == null)
                        {
                            parent = item.Parent;
                        }

                        parent.RemoveChild(item);

                        ProjectItemElement newItem = projectRoot.CreateItemElement("PackageReference", identity.Id);
                        updatedItems.Add(newItem, identity.Version.ToNormalizedString());
                    }
                }
            }
            foreach(var item in updatedItems)
            {
                var appendItem = item.Key;
                // we must "root" an item to a parent before we can update its metadata.
                parent.AppendChild(appendItem);
                appendItem.AddMetadata("Version", item.Value, true);
            }

            projectRoot.Save();
            return !Log.HasLoggedErrors;
        }

        IReadOnlyCollection<PackageIdentity> GetPackageIdentityCollection(ITaskItem[] nuGetPackages)
        {
            List<PackageIdentity> packageList = new List<PackageIdentity>();
            foreach(var nuGetPackage in nuGetPackages)
            {
                using (PackageArchiveReader archiveReader = new PackageArchiveReader(nuGetPackage.ItemSpec))
                {
                    PackageIdentity identity = archiveReader.GetIdentity();
                    packageList.Add(identity);
                }
            }
            return packageList;
        }
    }
}
