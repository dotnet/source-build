using System;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.DotNet.PlatformAbstractions;

namespace Microsoft.DotNet.Build.Tasks
{
    /*
     * Used Vendoed code from Microsoft.DotNet.PlatformAbstractions.
     * Long term we should use that library once it is clear how to
     * get MSBuild on core to be able to load the dependent assembly.
     */
    public class GetHostRid : Task
    {
        [Output]
        public string Rid { get; set; }

        public override bool Execute()
        {
            Rid = RuntimeEnvironment.GetRuntimeIdentifier();
            return true;
        }
    }
}
