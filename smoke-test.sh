#!/usr/bin/env bash
set -euo pipefail

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
VERSION_PREFIX=3.1
# See https://github.com/dotnet/source-build/issues/579, this version
# needs to be compatible with the runtime produced from source-build
DEV_CERTS_VERSION_DEFAULT=3.0.0-preview8-28405-07

# Use uname to determine what the CPU is.
cpuName=$(uname -p)
# Some Linux platforms report unknown for platform, but the arch for machine.
if [[ "$cpuName" == "unknown" ]]; then
  cpuName=$(uname -m)
fi

case $cpuName in
  aarch64)
    buildArch=arm64
    ;;
  amd64|x86_64)
    buildArch=x64
    ;;
  armv*l)
    buildArch=arm
    ;;
  i686)
    buildArch=x86
    ;;
  *)
    echo "Unknown CPU $cpuName detected, treating it as x64"
    buildArch=x64
    ;;
esac

__ROOT_REPO=$(cat "$SCRIPT_ROOT/artifacts/obj/rootrepo.txt" | sed 's/\r$//') # remove CR if mounted repo on Windows drive
targetRid=$(cat "$SCRIPT_ROOT/artifacts/obj/${buildArch}/Release/TargetInfo.props" | grep -i targetrid | sed -E 's|\s*</?TargetRid>\s*||g')
executingUserHome=${HOME:-}

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

projectOutput=false
keepProjects=false
dotnetDir=""
configuration="Release"
excludeNonWebTests=false
excludeWebTests=false
excludeWebNoHttpsTests=false
excludeWebHttpsTests=false
excludeLocalTests=false
excludeOnlineTests=false
devCertsVersion="$DEV_CERTS_VERSION_DEFAULT"
testingDir="$SCRIPT_ROOT/testing-smoke"
cliDir="$testingDir/builtCli"
logFile="$testingDir/smoke-test.log"
restoredPackagesDir="$testingDir/packages"
testingHome="$testingDir/home"
archiveRestoredPackages=false
archivedPackagesDir="$testingDir/smoke-test-packages"
smokeTestPrebuilts="$SCRIPT_ROOT/packages/smoke-test-packages"
runningOnline=false
runningHttps=false

function usage() {
    echo ""
    echo "usage:"
    echo "  --dotnetDir                    the directory from which to run dotnet"
    echo "  --configuration                the configuration being tested (default=Release)"
    echo "  --targetRid                    override the target rid to use when needed (e.g. for self-contained publish tests)"
    echo "  --projectOutput                echo dotnet's output to console"
    echo "  --keepProjects                 keep projects after tests are complete"
    echo "  --minimal                      run minimal set of tests - local sources only, no web"
    echo "  --excludeNonWebTests           don't run tests for non-web projects"
    echo "  --excludeWebTests              don't run tests for web projects"
    echo "  --excludeWebNoHttpsTests       don't run web project tests with --no-https"
    echo "  --excludeWebHttpsTests         don't run web project tests with https using dotnet-dev-certs"
    echo "  --excludeLocalTests            exclude tests that use local sources for nuget packages"
    echo "  --excludeOnlineTests           exclude test that use online sources for nuget packages"
    echo "  --devCertsVersion <version>    use dotnet-dev-certs <version> instead of default $DEV_CERTS_VERSION_DEFAULT"
    echo "  --prodConBlobFeedUrl <url>     override the prodcon blob feed specified in ProdConFeed.txt, removing it if empty"
    echo "  --archiveRestoredPackages      capture all restored packages to $archivedPackagesDir"
    echo "environment:"
    echo "  prodConBlobFeedUrl    override the prodcon blob feed specified in ProdConFeed.txt, removing it if empty"
    echo ""
}

while :; do
    if [ $# -le 0 ]; then
        break
    fi

    lowerI="$(echo "$1" | awk '{print tolower($0)}')"
    case $lowerI in
        "-?"|-h|--help)
            usage
            exit 0
            ;;
        --dotnetdir)
            shift
            dotnetDir="$1"
            ;;
        --configuration)
            shift
            configuration="$1"
            ;;
        --targetrid)
            shift
            targetRid="$1"
            ;;
        --projectoutput)
            projectOutput=true
            ;;
        --keepprojects)
            keepProjects=true
            ;;
        --minimal)
            excludeOnlineTests=true
            ;;
        --excludenonwebtests)
            excludeNonWebTests=true
            ;;
        --excludewebtests)
            excludeWebTests=true
            ;;
        --excludewebnohttpstests)
            excludeWebNoHttpsTests=true
            ;;
        --excludewebhttpstests)
            excludeWebHttpsTests=true
            ;;
        --excludelocaltests)
            excludeLocalTests=true
            ;;
        --excludeonlinetests)
            excludeOnlineTests=true
            ;;
        --devcertsversion)
            shift
            devCertsVersion="$1"
            ;;
        --prodconblobfeedurl)
            shift
            prodConBlobFeedUrl="$1"
            ;;
        --archiverestoredpackages)
            archiveRestoredPackages=true
            ;;
        *)
            echo "Unrecognized argument '$1'"
            usage
            exit 1
            ;;
    esac

    shift
done

prodConBlobFeedUrl="${prodConBlobFeedUrl-$(cat "$SCRIPT_ROOT/ProdConFeed.txt")}"

function doCommand() {
    lang=$1
    proj=$2
    shift; shift;

    echo "starting language $lang, type $proj" | tee -a smoke-test.log

    dotnetCmd=${dotnetDir}/dotnet
    mkdir "${lang}_${proj}"
    cd "${lang}_${proj}"

    newArgs="new $proj -lang $lang"

    while :; do
        if [ $# -le 0 ]; then
            break
        fi
        case "$1" in
            --new-arg)
                shift
                newArgs="$newArgs $1"
                ;;
            *)
                break
                ;;
        esac
        shift
    done

    while :; do
        if [ $# -le 0 ]; then
            break
        fi

        binlogOnlinePart="local"
        binlogHttpsPart="nohttps"
        if [ "$runningOnline" == "true" ]; then
            binlogOnlinePart="online"
        fi
        if [ "$runningHttps" == "true" ]; then
            binlogHttpsPart="https"
        fi

        binlogPrefix="$testingDir/${lang}_${proj}_${binlogOnlinePart}_${binlogHttpsPart}_"
        binlog="${binlogPrefix}$1.binlog"
        echo "    running $1" | tee -a "$logFile"

        if [ "$1" == "new" ]; then
            if [ "$projectOutput" == "true" ]; then
                "${dotnetCmd}" $newArgs --no-restore | tee -a "$logFile"
            else
                "${dotnetCmd}" $newArgs --no-restore >> "$logFile" 2>&1
            fi
        elif [[ "$1" == "run" && "$proj" =~ ^(web|mvc|webapi|razor)$ ]]; then
            if [ "$projectOutput" == "true" ]; then
                "${dotnetCmd}" $1 &
            else
                "${dotnetCmd}" $1 >> "$logFile" 2>&1 &
            fi
            webPid=$!
            killCommand="pkill -SIGTERM -P $webPid"
            echo "    waiting up to 30 seconds for web project with pid $webPid..."
            echo "    to clean up manually after an interactive cancellation, run: $killCommand"
            for seconds in $(seq 30); do
                if [ "$(tail -n 1 "$logFile")" = 'Application started. Press Ctrl+C to shut down.' ]; then
                    echo "    app ready for shutdown after $seconds seconds"
                    break
                fi
                sleep 1
            done
            echo "    stopping $webPid" | tee -a "$logFile"
            $killCommand
            wait $!
            echo "    terminated with exit code $?" | tee -a "$logFile"
        elif [ "$1" == "publish" ]; then
            runPublishScenarios() {
                "${dotnetCmd}" publish --self-contained false /bl:"${binlogPrefix}publish-fx-dep.binlog"
                "${dotnetCmd}" publish --self-contained true -r $targetRid /bl:"${binlogPrefix}publish-self-contained-${targetRid}.binlog"
                "${dotnetCmd}" publish --self-contained true -r linux-${buildArch} /bl:"${binlogPrefix}publish-self-contained-portable.binlog"
            }
            if [ "$projectOutput" == "true" ]; then
                runPublishScenarios | tee -a "$logFile"
            else
                runPublishScenarios >> "$logFile" 2>&1
            fi
        else
            if [ "$projectOutput" == "true" ]; then
                "${dotnetCmd}" $1 /bl:"$binlog" | tee -a "$logFile"
            else
                "${dotnetCmd}" $1 /bl:"$binlog" >> "$logFile" 2>&1
            fi
        fi
        if [ $? -eq 0 ]; then
            echo "    $1 succeeded" >> "$logFile"
        else
            echo "    $1 failed with exit code $?" | tee -a "$logFile"
        fi

        shift
    done

    cd ..

    if [ "$keepProjects" == "false" ]; then
       rm -rf "${lang}_${proj}"
    fi

    echo "finished language $lang, type $proj" | tee -a smoke-test.log
}

function setupDevCerts() {
    echo "Setting up dotnet-dev-certs $devCertsVersion to generate dev certificate" | tee -a "$logFile"
    (
        set -x
        "$dotnetDir/dotnet" tool install -g dotnet-dev-certs --version "$devCertsVersion" --add-source https://dotnet.myget.org/F/dotnet-core/api/v3/index.json
        export DOTNET_ROOT="$dotnetDir"
        "$testingHome/.dotnet/tools/dotnet-dev-certs" https
    ) >> "$logFile" 2>&1
}

function runAllTests() {
    # Run tests for each language and template
    if [ "$excludeNonWebTests" == "false" ]; then
        doCommand C# console new restore build run publish
        doCommand C# classlib new restore build publish
        doCommand C# xunit new restore test
        doCommand C# mstest new restore test

        doCommand VB console new restore build run publish
        doCommand VB classlib new restore build publish
        doCommand VB xunit new restore test
        doCommand VB mstest new restore test

        doCommand F# console new restore build run publish
        doCommand F# classlib new restore build publish
        doCommand F# xunit new restore test
        doCommand F# mstest new restore test
    fi

    if [ "$excludeWebTests" == "false" ]; then
        if [ "$excludeWebNoHttpsTests" == "false" ]; then
            runningHttps=false
            runWebTests --new-arg --no-https
        fi

        if [ "$excludeWebHttpsTests" == "false" ]; then
            runningHttps=true
            setupDevCerts
            runWebTests
        fi
    fi
}

function runWebTests() {
    doCommand C# web "$@" new restore build run publish
    doCommand C# mvc "$@" new restore build run publish
    doCommand C# webapi "$@" new restore build run publish
    doCommand C# razor "$@" new restore build run publish

    doCommand F# web "$@" new restore build run publish
    doCommand F# mvc "$@" new restore build run publish
    doCommand F# webapi "$@" new restore build run publish
}

function resetCaches() {
    rm -rf "$testingHome"
    mkdir "$testingHome"

    HOME="$testingHome"

    # clean restore path
    rm -rf "$restoredPackagesDir"

    # Copy NuGet plugins if running user has HOME and we have auth. In particular, the auth plugin.
    if [ "${internalPackageFeedPat:-}" ] && [ "${executingUserHome:-}" ]; then
        cp -r "$executingUserHome/.nuget/" "$HOME/.nuget/" || :
    fi
}

function setupProdConFeed() {
    if [ "$prodConBlobFeedUrl" ]; then
        sed -i.bakProdCon "s|PRODUCT_CONTRUCTION_PACKAGES|$prodConBlobFeedUrl|g" "$testingDir/NuGet.Config"
    else
        sed -i.bakProdCon "/PRODUCT_CONTRUCTION_PACKAGES/d" "$testingDir/NuGet.Config"
    fi
}

function setupSmokeTestFeed() {
    # Setup smoke-test-packages if they exist
    if [ -e "$smokeTestPrebuilts" ]; then
        sed -i.bakSmokeTestFeed "s|SMOKE_TEST_PACKAGE_FEED|$smokeTestPrebuilts|g" "$testingDir/NuGet.Config"
    else
        sed -i.bakSmokeTestFeed "/SMOKE_TEST_PACKAGE_FEED/d" "$testingDir/NuGet.Config"
    fi
}

function copyRestoredPackages() {
    if [ "$archiveRestoredPackages" == "true" ]; then
        mkdir -p "$archivedPackagesDir"
        cp -rf "$restoredPackagesDir"/* "$archivedPackagesDir"
    fi
}

if [ "$__ROOT_REPO" != "known-good" ]; then
    echo "Skipping smoke-tests since cli was not built";
    exit
fi

# Clean up and create directory
if [ -e "$testingDir"  ]; then
    read -p "testing-smoke directory exists, remove it? [Y]es / [n]o" -n 1 -r
    echo
    if [[ $REPLY == "" || $REPLY == " " || $REPLY =~ ^[Yy]$ ]]; then
        rm -rf "$testingDir"
    fi
fi

mkdir -p "$testingDir"
cd "$testingDir"

# Create blank Directory.Build files to avoid traversing to source-build infra.
echo "<Project />" | tee Directory.Build.props > Directory.Build.targets

# Unzip dotnet if the dotnetDir is not specified
if [ "$dotnetDir" == "" ]; then
    OUTPUT_DIR="$SCRIPT_ROOT/artifacts/${buildArch}/$configuration/"
    DOTNET_TARBALL="$(ls ${OUTPUT_DIR}dotnet-sdk-${VERSION_PREFIX}*)"

    mkdir -p "$cliDir"
    tar xzf "$DOTNET_TARBALL" -C "$cliDir"
    dotnetDir="$cliDir"
else
    if ! [[ "$dotnetDir" = /* ]]; then
       dotnetDir="$SCRIPT_ROOT/$dotnetDir"
    fi
fi

echo SDK under test is:
"$dotnetDir/dotnet" --info

# setup restore path
export NUGET_PACKAGES="$restoredPackagesDir"
SOURCE_BUILT_PKGS_PATH="$SCRIPT_ROOT/artifacts/obj/${buildArch}/$configuration/blob-feed/packages/"
export DOTNET_ROOT="$dotnetDir"
# OSX also requires DOTNET_ROOT to be on the PATH
if [ "$(uname)" == 'Darwin' ]; then
    export PATH="$dotnetDir:$PATH"
fi

# Run all tests, local restore sources first, online restore sources second
if [ "$excludeLocalTests" == "false" ]; then
    resetCaches
    runningOnline=false
    # Setup NuGet.Config with local restore source
    if [ -e "$SCRIPT_ROOT/smoke-testNuGet.Config" ]; then
        cp "$SCRIPT_ROOT/smoke-testNuGet.Config" "$testingDir/NuGet.Config"
        sed -i.bak "s|SOURCE_BUILT_PACKAGES|$SOURCE_BUILT_PKGS_PATH|g" "$testingDir/NuGet.Config"
        setupProdConFeed
        setupSmokeTestFeed
        echo "$testingDir/NuGet.Config Contents:"
        cat "$testingDir/NuGet.Config"
    fi
    echo "RUN ALL TESTS - LOCAL RESTORE SOURCE"
    runAllTests
    copyRestoredPackages
    echo "LOCAL RESTORE SOURCE - ALL TESTS PASSED!"
fi

if [ "$excludeOnlineTests" == "false" ]; then
    resetCaches
    runningOnline=true
    # Setup NuGet.Config to use online restore sources
    if [ -e "$SCRIPT_ROOT/smoke-testNuGet.Config" ]; then
        cp "$SCRIPT_ROOT/smoke-testNuGet.Config" "$testingDir/NuGet.Config"
        sed -i.bak "/SOURCE_BUILT_PACKAGES/d" "$testingDir/NuGet.Config"
        setupProdConFeed
        setupSmokeTestFeed
        echo "$testingDir/NuGet.Config Contents:"
        cat "$testingDir/NuGet.Config"
    fi
    echo "RUN ALL TESTS - ONLINE RESTORE SOURCE"
    runAllTests
    copyRestoredPackages
    echo "ONLINE RESTORE SOURCE - ALL TESTS PASSED!"
fi

fullSdkVersion="$($dotnetDir/dotnet --version)"
"$SCRIPT_ROOT/scripts/fetch-microsoft-sdk.sh" "$fullSdkVersion" "microsoft-built-dotnet-sdk-${fullSdkVersion}.tar.gz"
"$SCRIPT_ROOT/scripts/compare-builds.sh" "$dotnetDir" "microsoft-built-dotnet-sdk-${fullSdkVersion}.tar.gz" || true

echo "ALL TESTS PASSED!"
