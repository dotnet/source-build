
param(
    [string] $Configuration = "Debug",
    [string] $Architecture = "x64",
    [string[]] $Targets = @("Build", "Tests"),
    [switch] $Help,
    [switch] $SkipBuild,
    [Parameter(Position=0, ValueFromRemainingArguments=$true)] $ExtraParameters )

if($Help)
{
    Write-Host "Usage: build [[-Help] [-Targets <TARGETS...>] "
    Write-Host ""
    Write-Host "Options:"
    Write-Host "  -Targets <TARGETS...>              Comma separated build targets to run (Build, Tests; Default is a full build and tests)"
    Write-Host "  -Help                              Display this help message"
    Write-Host "  -SkipBuild                         Only initialise tooling and skip product build"
    exit 0
}

#make path absolute
$RepoRoot = "$PSScriptRoot"

$sdkVersion = '1.0.1'
if (!$env:DOTNET_INSTALL_DIR)
{
    $env:DOTNET_INSTALL_DIR="$RepoRoot\.dotnetsdk"
}
$sdkInstallPath = "$env:DOTNET_INSTALL_DIR\sdk-$sdkVersion"

function Install-DotnetSdk([string] $sdkVersion)
{
    Write-Host "# Install .NET Core Sdk versione '$sdkVersion'" -foregroundcolor "magenta"
    $sdkInstallScriptUrl = "https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0/scripts/obtain/dotnet-install.ps1"
    
    Write-Host "Downloading sdk install script '$sdkInstallScriptUrl' to '$env:DOTNET_INSTALL_DIR'"
    New-Item "$env:DOTNET_INSTALL_DIR" -Type directory -ErrorAction Ignore
    try {
      Invoke-WebRequest $sdkInstallScriptUrl -OutFile "$env:DOTNET_INSTALL_DIR\dotnet-install.ps1"
    } catch {
      Write-Host "failed $_.Exception"
      exit 1
    }

    Write-Host "Running sdk install script..."
    Invoke-Expression "$env:DOTNET_INSTALL_DIR/dotnet-install.ps1 -InstallDir $sdkInstallPath -Channel preview -version $sdkVersion"
}

function Run-Cmd
{
  param( [string]$exe, [string]$arguments )
  Write-Host "$exe $arguments" -ForegroundColor "Blue"
  iex "$exe $arguments 2>&1" | Out-Host
  if ($LastExitCode -ne 0) {
    throw "Command failed with exit code $LastExitCode."
  }
  Write-Host ""
}

function Using-Sdk ([string] $sdkVersion)
{
  Write-Host "# Using sdk '$sdkVersion'" -foregroundcolor "magenta"
  $env:Path = "$sdkInstallPath;$env:Path"
  Run-Cmd "dotnet" "--version"
}

# main
Write-Host Checking $sdkInstallPath
if (!(Test-Path $sdkInstallPath))
{
  Install-DotnetSdk $sdkVersion
}
Using-Sdk $sdkVersion
if($SkipBuild)
{
  Write-Host "Skipping dotnet msbuild build.proj /m /v:diag /p:Architecture=" $Architecture $ExtraParameters
  exit 0
}
dotnet msbuild build.proj /m /v:diag /p:Architecture=$Architecture $ExtraParameters
if ($LASTEXITCODE -ne 0) { throw "Failed to build" } 
