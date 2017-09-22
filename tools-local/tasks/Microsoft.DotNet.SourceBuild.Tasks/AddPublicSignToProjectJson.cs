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
     * This task updates project.json files to public sign using a specified key.
     */
    public class AddPublicSignToProjectJson : Task
    {
        [Required]
        public ITaskItem[] ProjectJsonFiles { get; set; }

        [Required]
        public string KeyFilePath { get; set; }

        public override bool Execute()
        {
            foreach (ITaskItem item in ProjectJsonFiles)
            {
                string pathToProjectJson = item.GetMetadata("FullPath");

                JObject root = ProjectJsonUtils.ReadProject(pathToProjectJson);
                JObject buildOptions = (JObject)root["buildOptions"];

                if (buildOptions == null)
                {
                    root["buildOptions"] = JObject.FromObject(new Dictionary<string, string>() { { "publicSign", "true" }, { "keyFile", KeyFilePath } });
                }
                else
                {
                    AddOrReplacePropertyValue(buildOptions, "publicSign", new JValue("true"));
                    AddOrReplacePropertyValue(buildOptions, "keyFile", new JValue(KeyFilePath));

                    buildOptions.Remove("delaySign");
                }

                ProjectJsonUtils.WriteProject(root, pathToProjectJson);
            }

            return true;
        }

        private static void AddOrReplacePropertyValue(JObject obj, string propertyName, JValue propertyValue)
        {
            JProperty property = obj.Descendants().OfType<JProperty>().Where(p => p.Name == propertyName).FirstOrDefault();

            if (property != null)
            {
                property.Value = propertyValue;
            }
            else
            {
                obj[propertyName] = propertyValue;
            }
        }
    }
}
