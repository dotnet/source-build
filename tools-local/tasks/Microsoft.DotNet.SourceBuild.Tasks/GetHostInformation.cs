// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.DotNet.PlatformAbstractions;

namespace Microsoft.DotNet.Build.Tasks
{
    /*
     * Used vendored code from Microsoft.DotNet.PlatformAbstractions.
     * Long term we should use that library once it is clear how to
     * get MSBuild on core to be able to load the dependent assembly.
     */
    public class GetHostInformation : Task
    {
        [Output]
        public string Rid { get; set; }

        [Output]
        public string OSName { get; set; }

        public override bool Execute()
        {
            Rid = RuntimeEnvironment.GetRuntimeIdentifier();

            switch (RuntimeEnvironment.OperatingSystemPlatform)
            {
                case Platform.Windows:
                    OSName = "Windows_NT";
                    break;
                case Platform.Linux:
                    OSName = "Linux";
                    break;
                case Platform.Darwin:
                    OSName = "OSX";
                    break;
                case Platform.FreeBSD:
                    OSName = "FreeBSD";
                    break;
                default:
                    Log.LogError("Could not determine display name for platform.");
                    return false;
            }

            return true;
        }
    }
}
