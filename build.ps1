[CmdletBinding(PositionalBinding=$false)]
Param(
  [switch] $test,
  [Parameter(ValueFromRemainingArguments=$true)][String[]]$captured_args
)

Set-StrictMode -version 2.0
$ErrorActionPreference = "Stop"

# Handy function for executing a command in powershell and throwing if it
# fails.
#
# Use this when the full command is known at script authoring time and
# doesn't require any dynamic argument build up.  Example:
#
#   Exec-Block { & $msbuild Test.proj }
#
# Original sample came from: http://jameskovacs.com/2010/02/25/the-exec-problem/
function Exec-Block([scriptblock]$cmd) {
    & $cmd

    # Need to check both of these cases for errors as they represent different items
    # - $?: did the powershell script block throw an error
    # - $lastexitcode: did a windows command executed by the script block end in error
    if ((-not $?) -or ($lastexitcode -ne 0)) {
        throw "Command failed to execute: $cmd"
    }
}

$SCRIPT_ROOT = "$PSScriptRoot"
$SdkVersion = Get-Content (Join-Path $SCRIPT_ROOT "DotnetCLIVersion.txt")
$env:SDK_VERSION = $SdkVersion

$key = Get-Item -LiteralPath Registry::HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control -ErrorAction SilentlyContinue
if ($key.GetValue('ContainerType', $null) -ne $null)
{
    $env:DotNetRunningInDocker = 1
}

if (-NOT $test -and ([string]::IsNullOrWhiteSpace($env:SOURCE_BUILD_SKIP_SUBMODULE_CHECK) -or $env:SOURCE_BUILD_SKIP_SUBMODULE_CHECK -eq "0" -or $env:SOURCE_BUILD_SKIP_SUBMODULE_CHECK -eq "false"))
{
  Exec-Block { & $SCRIPT_ROOT\check-submodules.ps1 } | Out-Host
}

$env:SDK_VERSION = $SdkVersion
$env:DOTNET_CLI_TELEMETRY_OPTOUT = 1
$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = 1
$env:DOTNET_MULTILEVEL_LOOKUP = 0
$env:NUGET_PACKAGES = "$SCRIPT_ROOT\packages\"

Exec-Block { & "$SCRIPT_ROOT\init-tools.cmd" } | Out-Host

$CLIPATH = "$SCRIPT_ROOT\Tools\dotnetcli"
$SDKPATH = "$CLIPATH\sdk\$SdkVersion"

if ($test)
{
	$captured_args += "/t:RunTests"
}

if (-Not ($captured_args.Contains("/t:") -or $captured_args.Contains("RootRepo")))
{
  Exec-Block { & "$CLIPATH\dotnet" "$SDKPATH/MSBuild.dll" "$SCRIPT_ROOT/build.proj" /flp:v=diag /bl /clp:v=m /p:RootRepo=arcade $captured_args } | Out-Host
  taskkill /f /im dotnet.exe
}
Exec-Block { & "$CLIPATH\dotnet" "$SDKPATH/MSBuild.dll" "$SCRIPT_ROOT/build.proj" /flp:v=diag /bl /clp:v=m $captured_args } | Out-Host
