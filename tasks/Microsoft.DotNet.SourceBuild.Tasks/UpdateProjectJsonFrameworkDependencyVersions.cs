using System;
using System.IO;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using NuGet.Versioning;

namespace Microsoft.DotNet.Build.Tasks
{
    public class UpdateProjectJsonFrameworkDependencyVersions : Task
    {
        [Required]
        public ITaskItem[] NuGetPackages { get; set; }

        [Required]
        public string ProjectJsonFile { get; set; }

        public override bool Execute()
        {
            JObject projectRoot = ReadProject(ProjectJsonFile);
            string [] frameworks = projectRoot.SelectTokens("frameworks").SelectMany(f => f.Children().Select(c => ((JProperty)c).Name)).ToArray();

            foreach(string framework in frameworks)
            {
                JObject dependencies = GenerateDependencies(projectRoot, NuGetPackages, framework);
                projectRoot = UpdateDependenciesProperty(projectRoot, dependencies, framework);
            }

            WriteProject(projectRoot, ProjectJsonFile);

            return true;
        }

        private static JObject ReadProject(string projectJsonPath)
        {
            using (TextReader projectFileReader = File.OpenText(projectJsonPath))
            {
                var projectJsonReader = new JsonTextReader(projectFileReader);
                var serializer = new JsonSerializer();
                return serializer.Deserialize<JObject>(projectJsonReader);
            }
        }

        private static void WriteProject(JObject projectRoot, string projectJsonPath)
        {
            string projectJson = JsonConvert.SerializeObject(projectRoot, Formatting.Indented) + Environment.NewLine;

            if (!File.Exists(projectJsonPath) || !projectJson.Equals(File.ReadAllText(projectJsonPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(projectJsonPath));
                File.WriteAllText(projectJsonPath, projectJson);
            }
       }

        private JObject GenerateDependencies(JObject projectJsonRoot, ITaskItem [] nugetPackages, string framework)
        {
            var originalDependenciesList = new List<JToken>();
            JObject frameworkDependencies = GetFrameworkDependenciesSection(projectJsonRoot, framework);
            Dictionary<string, NuGetVersion> packageVersions = new Dictionary<string, NuGetVersion>();

            foreach (ITaskItem nugetPackage in nugetPackages)
            {
                using (PackageArchiveReader archiveReader = new PackageArchiveReader(nugetPackage.ItemSpec))
                {
                    PackageIdentity identity = archiveReader.GetIdentity();
                    if(!packageVersions.ContainsKey(identity.Id))
                    {
                        packageVersions.Add(identity.Id, identity.Version);
                    }
                    else
                    {
                        packageVersions[identity.Id] = identity.Version > packageVersions[identity.Id] ? identity.Version : packageVersions[identity.Id];
                    }
                }
            }

            if (frameworkDependencies != null)
            {
                originalDependenciesList = frameworkDependencies.Children().ToList();

                foreach (JProperty property in originalDependenciesList.Select(od => od))
                {
                    if (packageVersions.ContainsKey(property.Name))
                    {
                        Console.WriteLine($"Updating dependency in {ProjectJsonFile}: {property.Name}, {frameworkDependencies[property.Name].ToString()} --> {packageVersions[property.Name].ToString()}");
                        frameworkDependencies[property.Name] = packageVersions[property.Name].ToString();
                    }
                }
            }
            return frameworkDependencies;
        }

        private JObject GetFrameworkDependenciesSection(JObject projectJsonRoot, string framework = null)
        {
            if(string.IsNullOrWhiteSpace(framework))
            {
                return (JObject) projectJsonRoot["dependencies"];
            }
            return (JObject) projectJsonRoot["frameworks"][framework]["dependencies"];
        }
        private JObject UpdateDependenciesProperty(JObject projectJsonRoot, JObject updatedProperties, string framework = null)
        {
            var frameworkPath = string.Empty;
            if (!string.IsNullOrWhiteSpace(framework))
            {
                frameworkPath = "frameworks." + NewtonsoftEscapeJProperty(framework);
            }
            var frameworkPathObject = projectJsonRoot.SelectToken(frameworkPath);
            frameworkPathObject["dependencies"] = updatedProperties;
            return projectJsonRoot;
        }

        private static string NewtonsoftEscapeJProperty(string property)
        {
            if (string.IsNullOrWhiteSpace(property))
            {
                return property;
            }
            if (!property.StartsWith("['") && !property.EndsWith("']"))
            {
                property = "['" + property + "']";
            }
            return property;
        }
    }
}