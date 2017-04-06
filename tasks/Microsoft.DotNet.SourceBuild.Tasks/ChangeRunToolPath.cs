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
    public class ChangeRunToolPath : Task
    {
        [Required]
        public string ConfigJson { get; set; }

        [Required]
        public string ToolPath { get; set; }
        
        [Required]
        public string CurrentProjectPath { get; set; }

        public override bool Execute()
        {
            JObject root = ProjectJsonUtils.ReadProject(ConfigJson);
            JObject osSpecificMsbuild = (JObject)root["tools"]["msbuild"]["osSpecific"];

            string defaultParameters = "/nologo /v:minimal /flp:v=normal /clp:Summary /maxcpucount /nodeReuse:false /l:BinClashLogger,";
            string endOfDefaultParameters = ";LogFile=binclash.log";


            var toolPathUri = new Uri(ToolPath);
            var currentLocationUri = new Uri(CurrentProjectPath);
            AddOrReplacePropertyValue((JObject)osSpecificMsbuild["windows"], "path", new JValue(currentLocationUri.MakeRelativeUri(toolPathUri).ToString()+"/msbuild.cmd"));
            AddOrReplacePropertyValue((JObject)osSpecificMsbuild["unix"], "path", new JValue(currentLocationUri.MakeRelativeUri(toolPathUri).ToString() + "/msbuild.sh"));
            if (Path.GetFullPath(ConfigJson).Contains("corefx"))
            {
                AddOrReplacePropertyValue((JObject)osSpecificMsbuild["windows"], "defaultParameters", new JValue(defaultParameters + currentLocationUri.MakeRelativeUri(new Uri(ToolPath + "\\net46\\Microsoft.DotNet.Build.Tasks.dll")).ToString().Replace("/", "\\") + endOfDefaultParameters));
                AddOrReplacePropertyValue((JObject)osSpecificMsbuild["unix"], "defaultParameters", new JValue(defaultParameters + currentLocationUri.MakeRelativeUri(new Uri(ToolPath + "/Microsoft.DotNet.Build.Tasks.dll")).ToString() + endOfDefaultParameters));
            }
            if (Path.GetFullPath(ConfigJson).Contains("coreclr"))
            {
                AddOrReplacePropertyValue((JObject)root["settings"]["MsBuildEventLogging"], "defaultValue", new JValue("/l:BinClashLogger,"+ currentLocationUri.MakeRelativeUri(new Uri(ToolPath + "\\net45\\Microsoft.DotNet.Build.Tasks.dll")).ToString().Replace("/", "\\") + endOfDefaultParameters));
            }

            ProjectJsonUtils.WriteProject(root, ConfigJson);

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
