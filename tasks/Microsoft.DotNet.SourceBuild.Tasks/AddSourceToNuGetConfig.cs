using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;


namespace Microsoft.DotNet.Build.Tasks
{
    /*
     * This task adds a source to a well-formed NuGet.Config file. If a source with `SourceName` is already present, then
     * the path of the source is changed. Otherwise, the source is added as the first source in the list, after any clear
     * elements (if present).
     */
    public class AddSourceToNugetConfig : Task
    {
        [Required]
        public string NuGetConfigFile { get; set; }

        [Required]
        public string SourceName { get; set; }

        [Required]
        public string SourcePath { get; set; }
        
        public bool SetClearFlag { get; set; }

        public bool IsOnlySource { get; set; }

        public override bool Execute()
        {
            XDocument d = XDocument.Load(NuGetConfigFile);
            XElement packageSourcesElement = d.Root.Descendants().First(e => e.Name == "packageSources");
            if (IsOnlySource)
            {
                packageSourcesElement.RemoveAll();
            }
            if(SetClearFlag)
            {
                packageSourcesElement.AddFirst(new XElement("clear"));
            }

            XElement toAdd = new XElement("add", new XAttribute("key", SourceName), new XAttribute("value", SourcePath));

            XElement exisitingSourceBuildElement = packageSourcesElement.Descendants().FirstOrDefault(e => e.Name == "add" && e.Attribute(XName.Get("key")).Value == SourceName);
            XElement lastClearElement = packageSourcesElement.Descendants().LastOrDefault(e => e.Name == "clear");

            if (exisitingSourceBuildElement != null)
            {
                exisitingSourceBuildElement.ReplaceWith(toAdd);
            }
            else if (lastClearElement != null)
            {
                lastClearElement.AddAfterSelf(toAdd);
            }
            else
            {
                packageSourcesElement.AddFirst(toAdd);
            }

            using (FileStream fs = new FileStream(NuGetConfigFile, FileMode.Create, FileAccess.Write))
            {
                d.Save(fs);
            }

            return true;
        }
    }
}
