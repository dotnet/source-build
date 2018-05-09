// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Xml.Linq;

namespace Microsoft.DotNet.SourceBuild.Tasks.UsageReport
{
    public class UsageAnnotation
    {
        public string SourceBuildPackageIdCreator { get; set; }
        public string ProdConPackageIdCreator { get; set; }
        public string InEarlierReleaseExactPrebuilt { get; set; }
        public bool EndsUpInOutput { get; set; }

        public IEnumerable<XObject> CreatePackageAnnotations()
        {
            if (!string.IsNullOrEmpty(SourceBuildPackageIdCreator))
            {
                yield return new XElement(
                    nameof(SourceBuildPackageIdCreator),
                    new XText(SourceBuildPackageIdCreator));
            }
            if (!string.IsNullOrEmpty(ProdConPackageIdCreator))
            {
                yield return new XElement(
                    nameof(ProdConPackageIdCreator),
                    new XText(ProdConPackageIdCreator));
            }
            if (!string.IsNullOrEmpty(InEarlierReleaseExactPrebuilt))
            {
                yield return new XElement(
                    nameof(InEarlierReleaseExactPrebuilt),
                    new XText(InEarlierReleaseExactPrebuilt));
            }
            if (EndsUpInOutput)
            {
                yield return new XAttribute("PoisonEndsUpInOutput", true);
            }
        }
    }
}
