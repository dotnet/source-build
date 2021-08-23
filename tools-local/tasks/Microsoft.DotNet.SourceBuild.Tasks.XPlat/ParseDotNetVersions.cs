// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.DotNet.Build.Tasks
{
    /*
     * This task parses the versions in a .NET SDK
     */
    public class ParseDotNetVersions : Task
    {
        [Required]
        public string SdkRootDirectory { get; set; }

        [Output]
        public string SdkVersion { get; set; }
        [Output]
        public string AspNetCoreVersion { get; set; }
        [Output]
        public string RuntimeVersion { get; set; }

        public override bool Execute()
        {

            var pathToDotNet = Path.Join(SdkRootDirectory, "dotnet");
            SdkVersion = ExecuteDotNetCommand(SdkRootDirectory,
                                              pathToDotNet,
                                              new List<string> { "--list-sdks" })
                            .First()
                            .Split(" ")
                            .First();
            AspNetCoreVersion = ExecuteDotNetCommand(SdkRootDirectory,
                                                     pathToDotNet,
                                                     new List<string> { "--list-runtimes" })
                                    .Where(line => line.Contains("Microsoft.AspNetCore.App"))
                                    .First()
                                    .Split(" ")
                                    .Skip(1)
                                    .First();
            RuntimeVersion = ExecuteDotNetCommand(SdkRootDirectory,
                                                  pathToDotNet,
                                                  new List<string> { "--list-runtimes"})
                                .Where(line => line.Contains("Microsoft.NETCore.App"))
                                .First()
                                .Split(" ")
                                .Skip(1)
                                .First();

            return true;
        }

        /// <summary>
        /// Executes a dotnet command and returns the result.
        /// </summary>
        /// <param name="workingDirectory">The working directory for the dotnet command.</param>
        /// <param name="command">The complete path to the dotnet command to execute.</param>
        /// <param name="argumentList">The arguments to the dotnet command to execute.</param>
        /// <returns>An array of the output lines of the dotnet command.</returns>
        private string[] ExecuteDotNetCommand(string workingDirectory, string command, List<string> argumentList)
        {
            string[] returnData;
            Process _process = new Process();
            _process.StartInfo.FileName = command;
            foreach (string argument in argumentList)
            {
                _process.StartInfo.ArgumentList.Add(argument);
            }
            _process.StartInfo.WorkingDirectory = workingDirectory;
            _process.StartInfo.RedirectStandardOutput = true;
            _process.StartInfo.UseShellExecute = false;
            _process.Start();
            returnData = _process.StandardOutput.ReadToEnd().Split('\n');
            _process.WaitForExit();
            return returnData;
        }

    }
}
