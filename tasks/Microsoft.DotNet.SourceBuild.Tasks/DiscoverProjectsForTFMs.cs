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
     * This tasks finds all the project.json files that target one or more TFMs
     */
    public class DiscoverProjectsForTFMs : Task
    {
        [Required]
        public string RootDirectory { get; set; }

        [Required]
        public string[] TFMs { get; set; }

        [Output]
        public string[] DiscoveredProjects { get; set; }

        public override bool Execute()
        {
            List<string> discoveredProjects = new List<string>();

            foreach (string path in Directory.GetFiles(RootDirectory, "project.json", SearchOption.AllDirectories))
            {
                if (ProjectTargetsAnyTFM(path, TFMs))
                {
                    discoveredProjects.Add(path);
                }
            }

            DiscoveredProjects = discoveredProjects.ToArray();

            return true;
        }

        private static bool ProjectTargetsAnyTFM(string pathToProjectJson, string[] candidateTFMs)
        {
            JObject project = ProjectJsonUtils.ReadProject(pathToProjectJson);

            return project.Value<JObject>("frameworks").Properties().Select(p => p.Name).Any(tfm => candidateTFMs.Contains(tfm));
        }
    }
}

