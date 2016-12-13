using System;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.DotNet.Build.Tasks
{
    public class GetHostRid : Task
    {
        [Output]
        public string Rid { get; set; }

        public override bool Execute()
        {
            string[] lines = File.ReadAllLines("/etc/os-release");
            DistroInfo result = new DistroInfo();
            foreach (string line in lines)
            {
                if (line.StartsWith("ID=", StringComparison.Ordinal))
                {
                    result.Id = line.Substring(3).Trim('"', '\'');
                }
                else if (line.StartsWith("VERSION_ID=", StringComparison.Ordinal))
                {
                    result.VersionId = line.Substring(11).Trim('"', '\'');
                }
            }

            Rid = $"{(result.Id ?? "").ToLowerInvariant()}.{(result.VersionId ?? "").ToLowerInvariant()}-x64";

            return true;
        }
    }

    class DistroInfo
    {
        public string Id;
        public string VersionId;
    }
}
