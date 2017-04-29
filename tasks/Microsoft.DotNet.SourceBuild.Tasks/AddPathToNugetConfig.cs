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
    public class AddPathToNugetConfig : Task
    {
        [Required]
        public string NuGetConfigFile { get; set; }

        [Required]
        public string RepositoryPath { get; set; }

        public override bool Execute()
        {
            XDocument d = XDocument.Load(NuGetConfigFile);
            XElement packageSourcesElement = null;
            bool pathExists = false;
            try
            {
                packageSourcesElement = d.Root.Descendants().First(e => e.Name == "config");
                pathExists = true;
            }
            catch(InvalidOperationException)
            {
                packageSourcesElement = new XElement("config");
            }

            XElement toAdd = new XElement("add", new XAttribute("key", "repositoryPath"), new XAttribute("value", RepositoryPath));
            
            if (pathExists)
            {
                XElement packageReplacementElement = new XElement("config");
                packageReplacementElement.AddFirst(toAdd);
                packageSourcesElement.ReplaceWith(packageReplacementElement);
            }
            else {
                packageSourcesElement.AddFirst(toAdd);
                d.Root.AddFirst(packageSourcesElement);
            }
            using (FileStream fs = new FileStream(NuGetConfigFile, FileMode.Create, FileAccess.ReadWrite))
            {
                d.Save(fs);
            }

            return true;
        }
    }
}
