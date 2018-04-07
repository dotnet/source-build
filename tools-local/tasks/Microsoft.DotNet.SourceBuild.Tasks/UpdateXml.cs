// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet.Packaging;
using NuGet.Packaging.Core;

namespace Microsoft.DotNet.Build.Tasks
{
    // Takes a path to a path to an XML file and a
    // string that is an Xpath to an element and updates
    // the contents of the element with the new value provided. 
    public class UpdateXml : Task
    {
        [Required]
        public string XmlFilePath { get; set; }

        [Required]
        public string PathToElement { get; set; }

        [Required]
        public string NewElementValue { get; set; }

        public override bool Execute()
        {
            XDocument doc = XDocument.Load(XmlFilePath);

            UpdateElement(doc, PathToElement.Split('/'), NewElementValue);

            var outFile = File.OpenWrite(XmlFilePath);
            doc.Save(outFile);
            return true;
        }
        private void UpdateElement(XContainer element, string[] path, string value)
        {
            foreach (var item in element.Elements(path[0]))
            {
                if (path.Length == 1) 
                {
                    item.Value = value;
                    return;
                }
                UpdateElement(item, path.Skip(1).ToArray(), value);
            }
        }
    }
}
