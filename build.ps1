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
$Sdk3Version = Get-Content (Join-Path $SCRIPT_ROOT "Dotnet3CLIVersion.txt")
$env:SDK_VERSION = $SdkVersion
$env:SDK3_VERSION = $Sdk3Version

$key = Get-Item -LiteralPath Registry::HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control -ErrorAction SilentlyContinue
if ($key.GetValue('ContainerType', $null) -ne $null)
{
    $env:DotNetRunningInDocker = 1
}

if (-NOT $test -and ([string]::IsNullOrWhiteSpace($env:SOURCE_BUILD_SKIP_SUBMODULE_CHECK) -or $env:SOURCE_BUILD_SKIP_SUBMODULE_CHECK -eq "0" -or $env:SOURCE_BUILD_SKIP_SUBMODULE_CHECK -eq "false"))
{
  Exec-Block { & $SCRIPT_ROOT\check-submodules.ps1 } | Out-Host
}

$env:DOTNET_CLI_TELEMETRY_OPTOUT = 1
$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = 1
$env:DOTNET_MULTILEVEL_LOOKUP = 0
$env:NUGET_PACKAGES = "$SCRIPT_ROOT\packages\"

Exec-Block { & "$SCRIPT_ROOT\init-tools.cmd" } | Out-Host

# While Arcade works as an SDK so we can use our SourceBuiltSdkOverride, BuildTools does not.
# Additionally, a few repos expect BuildTools and Arcade to be in the same directories.
# We don't build BuildTools, so we copy the existing BuildTools into the source-built folder so it can live with Arcade.
# This source-built folder is only used during the build and thrown away after that, so there's no rish of contaminating
# the shipping product with BuildTools binaries.
if (-Not (Test-Path "$SCRIPT_ROOT\Tools\source-built")) {
  Copy-Item -Recurse "$SCRIPT_ROOT\Tools" (Join-Path $env:TEMP "source-built")
  Move-Item (Join-Path $env:TEMP "source-built") "$SCRIPT_ROOT\Tools"
}

$CLIPATH = "$SCRIPT_ROOT\Tools\dotnetcli"
$SDKPATH = "$CLIPATH\sdk\$SdkVersion"

if ($test)
{
    $captured_args += "/t:RunTests"
}

Exec-Block { & "$CLIPATH\dotnet" "$SDKPATH/MSBuild.dll" "$SCRIPT_ROOT/build.proj" /flp:v=diag /bl /clp:v=m $captured_args } | Out-Host
