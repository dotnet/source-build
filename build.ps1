$SCRIPT_ROOT = "$PSScriptRoot"
$SdkVersion = Get-Content (Join-Path $SCRIPT_ROOT "DotnetCLIVersion.txt")

$env:DOTNET_CLI_TELEMETRY_OPTOUT = 1
$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = 1
$env:NUGET_PACKAGES = "$ScriptRoot\packages\"

& "$SCRIPT_ROOT\init-tools.cmd"

$CLIPATH = "$SCRIPT_ROOT\Tools\dotnetcli"
$SDKPATH = "$CLIPATH\sdk\$SdkVersion"

& "$CLIPATH\dotnet" restore "$SCRIPT_ROOT\tasks\Microsoft.DotNet.SourceBuild.Tasks\Microsoft.DotNet.SourceBuild.Tasks.csproj"
& "$CLIPATH\dotnet" build "$SCRIPT_ROOT\tasks\Microsoft.DotNet.SourceBuild.Tasks\Microsoft.DotNet.SourceBuild.Tasks.csproj"

Remove-Item -Recurse -Force "$NUGET_PACKAGES"

& "$CLIPATH\dotnet" "$SDKPATH/MSBuild.dll" "$SCRIPT_ROOT/build.proj" "$@" /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true
& "$CLIPATH\dotnet" "$SDKPATH/MSBuild.dll" "$SCRIPT_ROOT/build.proj" "$@" /t:GenerateRootFs
& "$CLIPATH\dotnet" "$SDKPATH/MSBuild.dll" "$SCRIPT_ROOT/build.proj" /flp:v=detailed /clp:v=detailed @args
