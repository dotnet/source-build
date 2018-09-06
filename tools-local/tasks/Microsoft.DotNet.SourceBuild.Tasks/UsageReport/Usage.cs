﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using NuGet.Packaging.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Microsoft.DotNet.SourceBuild.Tasks.UsageReport
{
    public class Usage
    {
        public PackageIdentity PackageIdentity { get; set; }

        public string AssetsFile { get; set; }

        /// <summary>
        /// The Runtime ID this package is for, or null. Runtime packages (are assumed to) have the
        /// id 'runtime.{rid}.{rest of id}'. We can't use a simple regex to grab this value since
        /// the RID may have '.' in it, so this is saved in the build context where possible RIDs
        /// are read from Microsoft.NETCore.Platforms.
        /// </summary>
        public string RuntimePackageRid { get; set; }

        public XElement ToXml() => new XElement(
            nameof(Usage),
            PackageIdentity.ToXElement().Attributes(),
            AssetsFile.ToXAttributeIfNotNull("File"),
            RuntimePackageRid.ToXAttributeIfNotNull("Rid"));

        public static Usage Parse(XElement xml) => new Usage
        {
            PackageIdentity = XmlParsingHelpers.ParsePackageIdentity(xml),
            AssetsFile = xml.Attribute("File")?.Value,
            RuntimePackageRid = xml.Attribute("Rid")?.Value
        };

        public static Usage Create(
            string assetsFile,
            PackageIdentity identity,
            IEnumerable<string> possibleRuntimePackageRids)
        {
            return new Usage
            {
                AssetsFile = assetsFile,
                PackageIdentity = identity,
                RuntimePackageRid = possibleRuntimePackageRids
                    .Where(rid => identity.Id.StartsWith($"runtime.{rid}.", StringComparison.Ordinal))
                    .OrderByDescending(rid => rid.Length)
                    .FirstOrDefault()
            };
        }

        public PackageIdentity GetIdentityWithoutRid()
        {
            if (!string.IsNullOrEmpty(RuntimePackageRid))
            {
                string prefix = $"runtime.{RuntimePackageRid}.";
                if (PackageIdentity.Id.StartsWith(prefix, StringComparison.Ordinal))
                {
                    return new PackageIdentity(
                        PackageIdentity.Id
                            .Remove(0, prefix.Length)
                            .Insert(0, "runtime.placeholder-rid."),
                        PackageIdentity.Version);
                }
            }
            return PackageIdentity;
        }

        public override string ToString() =>
            $"{PackageIdentity.Id} {PackageIdentity.Version} " +
            (string.IsNullOrEmpty(RuntimePackageRid) ? "" : $"({RuntimePackageRid}) ") +
            (string.IsNullOrEmpty(AssetsFile) ? "with unknown use" : $"used by '{AssetsFile}'");
    }
}
