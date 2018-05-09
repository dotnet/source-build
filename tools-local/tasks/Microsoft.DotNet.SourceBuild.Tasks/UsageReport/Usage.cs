// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.DotNet.SourceBuild.Tasks.UsageReport
{
    public class Usage
    {
        public string ProjectDirectory { get; set; }
        public string AssetsFile { get; set; }
        public string PackageIdentity { get; set; }

        public UsageAnnotation Annotation { get; set; }
    }
}
