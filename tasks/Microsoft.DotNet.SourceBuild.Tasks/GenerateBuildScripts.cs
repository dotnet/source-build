using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;


namespace Microsoft.DotNet.Build.Tasks
{
    /*
     * This task adds a source to a well-formed NuGet.Config file. If a source with `SourceName` is already present, then
     * the path of the source is changed. Otherwise, the source is added as the first source in the list, after any clear
     * elements (if present).
     */
    public class GenerateBuildScripts : Task
    {
        [Required]
        public string PathToScript { get; set; }
        
        [Required]
        public string ShellExtension { get; set; }

        public override bool Execute()
        {
            StringBuilder sb = new StringBuilder();
            if (ShellExtension == ".cmd") {
                sb.AppendLine("@if not defined _echo @echo off");
                sb.AppendLine("setlocal");
                sb.AppendLine("set Platform=");
                sb.AppendLine("set _toolRuntime=%TOOLRUNTIME_DIR%");
                sb.AppendLine(@"set _dotnet=%_toolRuntime%\dotnetcli\dotnet.exe");
                sb.AppendLine(@"echo Running: %_dotnet% % _toolRuntime%\run.exe %~dp0config.json %*");
                sb.AppendLine(@"call %_dotnet% % _toolRuntime%\run.exe %~dp0config.json %*");
                sb.AppendLine("if NOT[%ERRORLEVEL%] ==[0](");
                sb.AppendLine("exit / b 1");
                sb.AppendLine(")");
                sb.AppendLine("exit / b 0");
            }
            if(ShellExtension == ".sh")
            {
                sb.AppendLine("#!/usr/bin/env bash");
                sb.AppendLine("working_tree_root=\"$(cd \"$( dirname \"${BASH_SOURCE[0]}\" )\" && pwd )\"");
                sb.AppendLine("set Platform=");
                sb.AppendLine("toolRuntime=$TOOLRUNTIME_DIR");
                sb.AppendLine("dotnet=$toolRuntime/dotnetcli/dotnet");
                sb.AppendLine("echo \"Running: $dotnet $toolRuntime / run.exe $working_tree_root / config.json $*\"");
                sb.AppendLine("$dotnet $toolRuntime/run.exe $working_tree_root/config.json $*");
                sb.AppendLine("if [ $? -ne 0 ];then");
                sb.AppendLine("exit 1");
                sb.AppendLine("fi");
                sb.AppendLine("exit 0");
            }

            File.WriteAllText(PathToScript, sb.ToString());
        
            return true;
        }
    }
}
