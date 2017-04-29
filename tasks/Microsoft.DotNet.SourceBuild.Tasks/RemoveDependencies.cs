using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.DotNet.Build.Tasks
{
    /*
     * This task updates the `runtimes` section of a project.json file to only include the RID passed to the
     * `ReplacementRuntimeId` property. If `FilterRuntimeId` is set, then only runtime sections which include
     * that RID are updated. Project.json files without a runtime section are not modified by this task.
     */
    public class RemoveDependencies : Task
    {
        [Required]
        public ITaskItem[] DependenciesToRemove { get; set; }

        [Required]
        public string ProjectJsonFile { get; set; }

        public override bool Execute()
        {

            JObject root = ProjectJsonUtils.ReadProject(ProjectJsonFile);
            JProperty depsSection = root.Descendants().OfType<JProperty>().Where(property => property.Name == "dependencies").FirstOrDefault();

            if (depsSection == null)
            {
                return false;
            }

            foreach (ITaskItem item in DependenciesToRemove)
            {
                string depToRemove = item.ItemSpec;
                JObject depsObject = (JObject)depsSection.Value;

                if (!depsObject.Descendants().OfType<JProperty>().Any(property => property.Name == depToRemove))
                {
                    continue ;
                }
                depsObject.Remove(depToRemove);
            }
            ProjectJsonUtils.WriteProject(root, ProjectJsonFile);

            return true;
        }
    }
}
