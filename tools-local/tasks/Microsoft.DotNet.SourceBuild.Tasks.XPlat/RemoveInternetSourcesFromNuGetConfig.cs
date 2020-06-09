// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
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
    public class RemoveInternetSourcesFromNuGetConfig : Task
    {
        [Required]
        public string NuGetConfigFile { get; set; }

        public bool OfflineBuild { get; set; }

        public override bool Execute()
        {
            XDocument d = XDocument.Load(NuGetConfigFile);
            XElement packageSourcesElement = d.Root.Descendants().First(e => e.Name == "packageSources");

            IEnumerable<XElement> local = packageSourcesElement.Descendants().Where(e =>
            {
                if (e.Name == "add")
                {
                    if (OfflineBuild)
                    {
                        return !(e.Attribute("value").Value.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || e.Attribute("value").Value.StartsWith("https://", StringComparison.OrdinalIgnoreCase));
                    }
                    else
                    {
                        return !(e.Attribute("value").Value.StartsWith("https://pkgs.dev.azure.com/dnceng/_packaging", StringComparison.OrdinalIgnoreCase));
                    }
                }

                return true;
            });

            packageSourcesElement.ReplaceNodes(local.ToArray());

            using (FileStream fs = new FileStream(NuGetConfigFile, FileMode.Create, FileAccess.ReadWrite))
            {
                d.Save(fs);
            }

            return true;
        }
    }
}
