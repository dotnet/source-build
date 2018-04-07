// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NuGet.Packaging;
using NuGet.Packaging.Core;

namespace Microsoft.DotNet.Build.Tasks
{
    // Takes a path to a path to a json file and a
    // string that represents a dotted path to an attribute
    // and updates that attribute with the new value provided. 
    public class UpdateJson : Task
    {
        [Required]
        public string JsonFilePath { get; set; }

        [Required]
        public string PathToAttribute { get; set; }

        [Required]
        public string NewAttributeValue { get; set; }

        public override bool Execute()
        {
            JObject jsonObj = JObject.Parse(File.ReadAllText(JsonFilePath));

            UpdateAttribute(jsonObj, PathToAttribute.Split('.'), NewAttributeValue);

            File.WriteAllText(JsonFilePath, jsonObj.ToString());
            return true;
        }
        private void UpdateAttribute(JToken jsonObj, string[] path, string newValue)
        {
            string pathItem = path[0];
            if (jsonObj[pathItem] == null) throw new ArgumentException(string.Format("Path item [{0}] not found in json file.", pathItem), "PathToAttribute");
            if (path.Length == 1) 
            {
                jsonObj[pathItem] = newValue;
                return;
            }
            UpdateAttribute(jsonObj[pathItem], path.Skip(1).ToArray(), newValue);
            
        }
    }
}
