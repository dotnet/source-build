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

                if(UseWindowsConvention)
                {
                    cmdList.Add($"set {item.GetMetadata("Identity").ToUpper()}_VERSION_URL=file://{item.GetMetadata("VersionFile")}");
                }
                else
                {
                    cmdList.Add($"{item.GetMetadata("Identity").ToUpper()}_VERSION_URL=file://{item.GetMetadata("VersionFile")}");
                }
            
            }
            
            if(UseWindowsConvention)
            {
                Command = String.Join(" & ", cmdList);
            }
            else
            {
                Command = String.Join(" ", cmdList);
            }

            return true;
        }
    }
}
