// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Microsoft.DotNet.SourceBuild.Tasks.UsageReport
{
    public abstract class UsageGrouping
    {
        public class Package : UsageGrouping
        {
            public override string Type => nameof(Package);
            public override string GetKey(Usage u) => u.PackageIdentity;

            public override XElement CreateNode(Usage usage, IEnumerable<XObject> children)
            {
                IEnumerable<XObject> annotations = usage
                    ?.Annotation.CreatePackageAnnotations()
                    ?? Enumerable.Empty<XObject>();

                return base.CreateNode(usage, annotations.Concat(children));
            }
        }

        public class AssetsFile : UsageGrouping
        {
            public override string Type => nameof(AssetsFile);
            public override string GetKey(Usage u) => u.AssetsFile;
        }

        public class Project : UsageGrouping
        {
            public override string Type => nameof(Project);
            public override string GetKey(Usage u) => u.ProjectDirectory;
        };

        public abstract string Type { get; }
        public abstract string GetKey(Usage usage);

        public virtual XElement CreateNode(Usage usage, IEnumerable<XObject> children)
        {
            var node = new XElement(Type);
            node.Add(new XAttribute("Name", GetKey(usage)));
            node.Add(children);
            return node;
        }
    }
}
