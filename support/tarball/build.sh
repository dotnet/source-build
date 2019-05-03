#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
CLI_VERSION=$(cat $SCRIPT_ROOT/DotnetCLIVersion.txt)
CLI_ROOT="$SCRIPT_ROOT/Tools/dotnetcli"
export SDK_VERSION=$CLI_VERSION

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export NUGET_PACKAGES="$SCRIPT_ROOT/packages/"

MSBUILD_ARGUMENTS=("/p:OfflineBuild=true" "/flp:v=detailed")

echo "Rebuild reference assemblies"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$CLI_VERSION/MSBuild.dll /bl:initBuildReferenceAssemblies.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:BuildReferenceAssemblies ${MSBUILD_ARGUMENTS[@]} "$@"

echo "Expanding BuildTools dependencies into packages directory..."
# init-tools tries to copy from its script directory to Tools, which in this case is a copy to
# itself. This is an error. To avoid the error, use a temp dir that we immediately delete.
TEMP_TOOLS_DIR="$SCRIPT_ROOT/ToolsTemp"
PREBUILT_PACKAGE_SOURCE="$SCRIPT_ROOT/prebuilt/nuget-packages"
REF_PACKAGE_SOURCE="$SCRIPT_ROOT/reference-packages/packages"
(
    # Log the commands that run.
    set -x

    "$CLI_ROOT/dotnet" restore "$SCRIPT_ROOT/init-tools.msbuild" --no-cache --packages "$SCRIPT_ROOT/packages" --source "$PREBUILT_PACKAGE_SOURCE" --source "$REF_PACKAGE_SOURCE" || exit $?

    export __INIT_TOOLS_RESTORE_ARGS="--source $PREBUILT_PACKAGE_SOURCE --source $REF_PACKAGE_SOURCE" || exit $?
    "$SCRIPT_ROOT/Tools/init-tools.sh" "$SCRIPT_ROOT" "$SCRIPT_ROOT/Tools/dotnetcli/dotnet" "$TEMP_TOOLS_DIR" "$SCRIPT_ROOT/packages" || exit $?

    rm -rf "$TEMP_TOOLS_DIR" || exit $?
) > "$SCRIPT_ROOT/init-tools.log" 2>&1 || (
    cat "$SCRIPT_ROOT/init-tools.log"
    echo "ERROR: Failed to expand BuildTools dependencies. Detailed log above."
    exit 1
)

# If running in Docker, make sure we have the UTF-8 locale or builds will error out.
if [ -e /.dockerenv ]; then
    if [ "$EUID" -ne "0" ]; then
        echo "error: in docker but not root, so can't fix locale"
        exit 1
    fi
    if [ -e /etc/os-release ]; then
        source /etc/os-release
        # work around a bad /etc/apt/sources.list in the image
        if [[ "$ID" == "debian" ]]; then
            printf "deb http://archive.debian.org/debian/ jessie main\ndeb-src http://archive.debian.org/debian/ jessie main\ndeb http://security.debian.org jessie/updates main\ndeb-src http://security.debian.org jessie/updates main" > /etc/apt/sources.list
        fi
        if [[ "$ID" == "debian" || "$ID" == "ubuntu" ]]; then
            apt-get update
            apt-get install -y locales
            localedef -c -i en_US -f UTF-8 en_US.UTF-8
        fi
    fi
fi


$CLI_ROOT/dotnet $CLI_ROOT/sdk/$CLI_VERSION/MSBuild.dll /bl:initWriteDynamicPropsToStaticPropsFiles.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true ${MSBUILD_ARGUMENTS[@]} "$@"
# if we are not running a RootRepo or specific target already, build Arcade first separately
if ! [[ "$@" =~ "RootRepo" || "$@" =~ "/t:" ]]; then
    $CLI_ROOT/dotnet $CLI_ROOT/sdk/$CLI_VERSION/MSBuild.dll /bl:arcadeBuild.binlog $SCRIPT_ROOT/build.proj /p:RootRepo=arcade ${MSBUILD_ARGUMENTS[@]} "$@" /p:FailOnPrebuiltBaselineError=false
    pkill dotnet
    $CLI_ROOT/dotnet $CLI_ROOT/sdk/$CLI_VERSION/MSBuild.dll /bl:build.binlog $SCRIPT_ROOT/build.proj ${MSBUILD_ARGUMENTS[@]} "$@" /p:SkipPatches=true
else
    $CLI_ROOT/dotnet $CLI_ROOT/sdk/$CLI_VERSION/MSBuild.dll /bl:build.binlog $SCRIPT_ROOT/build.proj ${MSBUILD_ARGUMENTS[@]} "$@"
fi
