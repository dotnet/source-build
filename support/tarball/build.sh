#!/bin/bash
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

echo "Expanding BuildTools dependencies into packages directory..."
# init-tools tries to copy from its script directory to Tools, which in this case is a copy to
# itself. This is an error. To avoid the error, use a temp dir that we immediately delete.
TEMP_TOOLS_DIR="$SCRIPT_ROOT/ToolsTemp"
PREBUILT_PACKAGE_SOURCE="$SCRIPT_ROOT/prebuilt/nuget-packages"
(
    # Log the commands that run.
    set -x

    "$CLI_ROOT/dotnet" restore "$SCRIPT_ROOT/init-tools.msbuild" --no-cache --packages "$SCRIPT_ROOT/packages" --source "$PREBUILT_PACKAGE_SOURCE" || exit $?

    export __INIT_TOOLS_RESTORE_ARGS="--source $PREBUILT_PACKAGE_SOURCE" || exit $?
    "$SCRIPT_ROOT/Tools/init-tools.sh" "$SCRIPT_ROOT" "$SCRIPT_ROOT/Tools/dotnetcli/dotnet" "$TEMP_TOOLS_DIR" "$SCRIPT_ROOT/packages" || exit $?

    rm -rf "$TEMP_TOOLS_DIR" || exit $?
) > "$SCRIPT_ROOT/init-tools.log" 2>&1 || (
    cat "$SCRIPT_ROOT/init-tools.log"
    echo "ERROR: Failed to expand BuildTools dependencies. Detailed log above."
    exit 1
)

$CLI_ROOT/dotnet $CLI_ROOT/sdk/$CLI_VERSION/MSBuild.dll $SCRIPT_ROOT/tools-local/init-build.proj /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true ${MSBUILD_ARGUMENTS[@]} "$@"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$CLI_VERSION/MSBuild.dll $SCRIPT_ROOT/build.proj ${MSBUILD_ARGUMENTS[@]} "$@"
