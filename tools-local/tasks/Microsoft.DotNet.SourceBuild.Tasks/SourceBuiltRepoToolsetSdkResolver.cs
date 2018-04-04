// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.DotNet.SourceBuild.Tasks
{
    public class SourceBuiltRepoToolsetSdkResolver : SdkResolver
    {
        public override string Name => nameof(SourceBuiltRepoToolsetSdkResolver);

        public override int Priority => 0;

        public override SdkResult Resolve(
            SdkReference sdkReference,
            SdkResolverContext resolverContext,
            SdkResultFactory factory)
        {
            string sdkDescription = sdkReference.Name;
            if (!string.IsNullOrEmpty(sdkReference.Version))
            {
                sdkDescription += $" {sdkReference.Version}";
            }
            if (!string.IsNullOrEmpty(sdkReference.MinimumVersion))
            {
                sdkDescription += $" (>= {sdkReference.MinimumVersion})";
            }

            var unresolvableReasons = new List<string>();

            string dir = Environment.GetEnvironmentVariable("RESOLVE_REPO_TOOLSET_SDK_DIR");
            if (string.IsNullOrEmpty(dir))
            {
                unresolvableReasons.Add("No 'RESOLVE_REPO_TOOLSET_SDK_DIR' passed.");
            }

            string version = Environment.GetEnvironmentVariable("RESOLVE_REPO_TOOLSET_SDK_VERSION");
            if (string.IsNullOrEmpty(version))
            {
                unresolvableReasons.Add("No 'RESOLVE_REPO_TOOLSET_SDK_VERSION' passed.");
            }

            if (!sdkReference.Name.Equals("RoslynTools.RepoToolset", StringComparison.OrdinalIgnoreCase))
            {
                unresolvableReasons.Add($"Sdk isn't RoslynTools.RepoToolset: {sdkDescription}");
            }

            if (unresolvableReasons.Any())
            {
                return factory.IndicateFailure(unresolvableReasons.Select(r => $"{r} ({Name})"));
            }

            resolverContext.Logger.LogMessage(
                $"Overriding {sdkDescription} to '{version}' at '{dir}'",
                MessageImportance.High);

            return factory.IndicateSuccess(dir, version);
        }
    }
}
