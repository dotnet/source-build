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
    public class ChangeRuntimesSection : Task
    {
        [Required]
        public ITaskItem[] ProjectJsonFiles { get; set; }

        [Required]
        public string ReplacementRuntimeId { get; set; }

        public string FilterRuntimeId { get; set; }


        public override bool Execute()
        {
            foreach (ITaskItem item in ProjectJsonFiles)
            {
                string pathToProjectJson = item.GetMetadata("FullPath");

                JObject root = ReadProject(pathToProjectJson);
                JProperty runtimeSection = root.Descendants().OfType<JProperty>().Where(property => property.Name == "runtimes").FirstOrDefault();

                if (runtimeSection == null)
                {
                    continue;
                }

                JObject ridObject = (JObject)runtimeSection.Value;

                if (!string.IsNullOrEmpty(FilterRuntimeId) && !ridObject.Descendants().OfType<JProperty>().Any(property => property.Name == FilterRuntimeId))
                {
                    continue ;
                }

                Dictionary<string, JObject> obj = new Dictionary<string, JObject>();
                obj[ReplacementRuntimeId] = new JObject();

                runtimeSection.Value = JObject.FromObject(obj);

                WriteProject(root, pathToProjectJson);
            }

            return true;
        }

        private static JObject ReadProject(string projectJsonPath)
        {
            using (TextReader projectFileReader = File.OpenText(projectJsonPath))
            {
                JsonTextReader projectJsonReader = new JsonTextReader(projectFileReader);
                JsonSerializer serializer = new JsonSerializer();

                return serializer.Deserialize<JObject>(projectJsonReader);
            }
        }

        private static void WriteProject(JObject projectRoot, string projectJsonPath)
        {
            string projectJson = JsonConvert.SerializeObject(projectRoot, Formatting.Indented);

            File.WriteAllText(projectJsonPath, projectJson + Environment.NewLine);
        }
    }
}
