param
(
    [Parameter(Mandatory=$false)][string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [Parameter(Mandatory=$false)][string]$ToolsLocalPath = (Join-Path $RepositoryRoot "Tools"),
    [Parameter(Mandatory=$false)][string]$CliLocalPath = (Join-Path $ToolsLocalPath "dotnetcli"),
    [Parameter(Mandatory=$false)][string]$SharedFrameworkSymlinkPath = (Join-Path $ToolsLocalPath "dotnetcli\shared\Microsoft.NETCore.App\version"),
    [Parameter(Mandatory=$false)][string]$SharedFrameworkVersion = "<auto>",
    [Parameter(Mandatory=$false)][string]$Architecture = "<auto>",
    [switch]$Force = $false
)

$rootToolVersions = Join-Path $RepositoryRoot ".toolversions"
$bootstrapComplete = Join-Path $ToolsLocalPath "bootstrap.complete"

# if the force switch is specified delete the semaphore file if it exists
if ($Force -and (Test-Path $bootstrapComplete))
{
    del $bootstrapComplete
}

# if the semaphore file exists and is identical to the specified version then exit
if (Test-Path $bootstrapComplete)
{
    if (((Get-Content $rootToolVersions) -eq $Null) -and ((Get-Content $bootstrapComplete) -eq $Null))
    {
        exit 0
    }

    if ((Compare-Object (Get-Content $rootToolVersions) (Get-Content $bootstrapComplete)) -eq 0)
    {
        exit 0
    }
}

$initCliScript = "dotnet-install.ps1"
$dotnetInstallPath = Join-Path $ToolsLocalPath $initCliScript

# blow away the tools directory so we can start from a known state
if (Test-Path $ToolsLocalPath)
{
    # if the bootstrap.ps1 script was downloaded to the tools directory don't delete it
    rd -recurse -force $ToolsLocalPath -exclude "bootstrap.ps1"
}
else
{
    mkdir $ToolsLocalPath | Out-Null
}

# download CLI boot-strapper script
Invoke-WebRequest "https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0/scripts/obtain/dotnet-install.ps1" -UseDefaultCredentials -OutFile $dotnetInstallPath

# load the version of the CLI
$rootCliVersion = Join-Path $RepositoryRoot ".cliversion"
$dotNetCliVersion = Get-Content $rootCliVersion

if (-Not (Test-Path $CliLocalPath))
{
    mkdir $CliLocalPath | Out-Null
}

# now execute the script
Write-Host "$dotnetInstallPath -Version $dotNetCliVersion -InstallDir $CliLocalPath -Architecture ""$Architecture"""
Invoke-Expression "$dotnetInstallPath -Version $dotNetCliVersion -InstallDir $CliLocalPath -Architecture ""$Architecture"""
if ($LastExitCode -ne 0)
{
    Write-Output "The .NET CLI installation failed with exit code $LastExitCode"
    exit $LastExitCode
}

# create a junction to the shared FX version directory. this is
# so we have a stable path to dotnet.exe regardless of version.
$runtimesPath = Join-Path $CliLocalPath "shared\Microsoft.NETCore.App"
if ($SharedFrameworkVersion -eq "<auto>")
{
    $SharedFrameworkVersion = Get-ChildItem $runtimesPath -Directory | % { New-Object System.Version($_) } | Sort-Object -Descending | Select-Object -First 1
}
$junctionTarget = Join-Path $runtimesPath $SharedFrameworkVersion
$junctionParent = Split-Path $SharedFrameworkSymlinkPath -Parent
if (-Not (Test-Path $junctionParent))
{
    mkdir $junctionParent | Out-Null
}
if (-Not (Test-Path $SharedFrameworkSymlinkPath))
{
    cmd.exe /c mklink /j $SharedFrameworkSymlinkPath $junctionTarget | Out-Null
}

# write semaphore file
copy $rootToolVersions $bootstrapComplete
