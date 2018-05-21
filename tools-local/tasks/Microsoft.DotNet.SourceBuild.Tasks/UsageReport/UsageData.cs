// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Microsoft.DotNet.SourceBuild.Tasks.UsageReport
{
    public class UsageData
    {
        public string[] UnusedPackages { get; set; }
        public Usage[] Usages { get; set; }

        public XElement CreateSummaryReport()
        {
            return new XElement(
                "UsageSummary",
                GroupsToElements(
                    Usages,
                    new UsageGrouping.Package(),
                    new UsageGrouping.Project()));
        }

        public XElement CreateDetailedReport()
        {
            return new XElement(
                "UsageDetails",
                new XElement(
                    "Unknown",
                    UnusedPackages.Select(id => Node("Package", id, null))),
                new XElement(
                    "PackageUsages",
                    GroupsToElements(
                        Usages,
                        new UsageGrouping.Package(),
                        new UsageGrouping.Project(),
                        new UsageGrouping.AssetsFile())),
                new XElement(
                    "ProjectUsages",
                    GroupsToElements(
                        Usages,
                        new UsageGrouping.Project(),
                        new UsageGrouping.Package(),
                        new UsageGrouping.AssetsFile())));
        }

        private static IEnumerable<XElement> GroupsToElements(
            IEnumerable<Usage> usages,
            params UsageGrouping[] groupings)
        {
            return GroupsToElementsCore(usages, groupings);
        }

        private static IEnumerable<XElement> GroupsToElementsCore(
            IEnumerable<Usage> usages,
            IEnumerable<UsageGrouping> groupings)
        {
            if (!groupings.Any())
            {
                return null;
            }
            UsageGrouping grouping = groupings.First();
            return usages
                .GroupBy(grouping.GetKey)
                .OrderBy(g => g.Key)
                .Select(g => grouping.CreateNode(
                    g.First(),
                    GroupsToElementsCore(g, groupings.Skip(1))));
        }

        private static XElement Node(string type, string name, IEnumerable<XElement> children)
        {
            var node = new XElement(type, children);

            if (!string.IsNullOrEmpty(name))
            {
                node.Add(new XAttribute("Name", name));
            }

            return node;
        }
    }
}
