using System;

using System.Collections.Generic;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.DotNet.Build.Tasks
{
    public class SetVersionsEnvironment : Task
    {
        [Required]
        public ITaskItem[] Repositories { get; set; }

        [Required]
        public string OS { get; set; }

        [Output]
        public string Command { get; set; }

        public override bool Execute()
        {
            bool UseWindowsConvention = (OS == "Windows_NT");

            var cmdList = new List<string>();

            foreach (ITaskItem item in Repositories)
            {
                string versionFileMetadata = item.GetMetadata("VersionFile");

                if(String.IsNullOrEmpty(versionFileMetadata))
                {
                    continue;
                }


                string repositoryNameForEnvironmentVariable = item.GetMetadata("Identity").ToUpper().Replace("-", "");

                if(UseWindowsConvention)
                {
                    cmdList.Add($"set {repositoryNameForEnvironmentVariable}_VERSION_URL=file://{item.GetMetadata("VersionFile")}");
                }
                else
                {
                    cmdList.Add($"export {repositoryNameForEnvironmentVariable}_VERSION_URL=file://{item.GetMetadata("VersionFile")}");
                }

            }

            Command = String.Join(" & ", cmdList);
            

            return true;
        }
    }
}
