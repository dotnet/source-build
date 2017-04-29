$env:DOTNET_CLI_TELEMETRY_OPTOUT = 1
$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = 1

$ScriptRoot = "$PSScriptRoot"
$SdkVersion = Get-Content (Join-Path $ScriptRoot ".cliversion")

& "$ScriptRoot\bootstrap\bootstrap.ps1"
& "$ScriptRoot\Tools\dotnetcli\dotnet" restore "$ScriptRoot\tasks\Microsoft.DotNet.SourceBuild.Tasks\Microsoft.DotNet.SourceBuild.Tasks.csproj"
& "$ScriptRoot\Tools\dotnetcli\dotnet" build "$ScriptRoot\tasks\Microsoft.DotNet.SourceBuild.Tasks\Microsoft.DotNet.SourceBuild.Tasks.csproj"
& "$ScriptRoot\Tools\dotnetcli\dotnet" "$ScriptRoot\Tools\dotnetcli\sdk\$SdkVersion\MSBuild.dll" "$ScriptRoot\build.proj" @args /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true
& "$ScriptRoot\Tools\dotnetcli\dotnet" "$ScriptRoot\Tools\dotnetcli\sdk\$SdkVersion\MSBuild.dll" "$ScriptRoot\build.proj" @args /t:Sync
& "$ScriptRoot\Tools\dotnetcli\dotnet" "$ScriptRoot\Tools\dotnetcli\sdk\$SdkVersion\MSBuild.dll" "$ScriptRoot\build.proj" @args /t:Build

