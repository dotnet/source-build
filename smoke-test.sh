#!/bin/bash
set -euo pipefail

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
TARBALL_PREFIX=dotnet-sdk-
VERSION_PREFIX=2.1

projectOutput=false
keepProjects=false
dotnetDir=""
configuration="Release"
excludeWebTests=false
excludeLocalTests=false
excludeOnlineTests=false
testingDir="$SCRIPT_ROOT/testing-smoke"
cliDir="$testingDir/builtCli"
logFile="$testingDir/smoke-test.log"
restoredPackagesDir="$testingDir/packages"

function usage() {
    echo ""
    echo "usage:"
    echo "  --dotnetDir             the directory from which to run dotnet"
    echo "  --configuration         the configuration being tested (default=Release)"
    echo "  --projectOutput         echo dotnet's output to console"
    echo "  --keepProjects          keep projects after tests are complete"
    echo "  --minimal               run minimal set of tests - local sources only, no web"
    echo "  --excludeWebTests       don't run tests for web projects"
    echo "  --excludeLocalTests     exclude tests that use local sources for nuget packages"
    echo "  --excludeOnlineTests    exclude test that use online sources for nuget packages"
    echo ""
}

while :; do
    if [ $# -le 0 ]; then
        break
    fi

    lowerI="$(echo $1 | awk '{print tolower($0)}')"
    case $lowerI in
        -?|-h|--help)
            usage
            exit 1
            ;;
        --dotnetdir)
            shift
            dotnetDir="$1"
            ;;
        --configuration)
            shift
            configuration="$1"
            ;;
        --projectoutput)
            projectOutput=true
            ;;
        --keepprojects)
            keepProjects=true
            ;;
        --minimal)
            excludeWebTests=true
            excludeOnlineTests=true
            ;;
        --excludewebtests)
            excludeWebTests=true
            ;;
        --excludelocaltests)
            excludeLocalTests=true
            ;;
        --excludeonlinetests)
            excludeOnlineTests=true
            ;;
        *)
            usage
            exit 1
            ;;
    esac

    shift
done


function doCommand() {
    lang=$1
    proj=$2
    shift; shift;

    echo "starting language $lang, type $proj" | tee -a smoke-test.log

    dotnetCmd=${dotnetDir}/dotnet
    mkdir "${lang}_${proj}"
    cd "${lang}_${proj}"

    while :; do
        if [ $# -le 0 ]; then
            break
        fi

        echo "    running $1" | tee -a "$logFile"

        if [ "$1" == "new" ]; then
            if [ "$projectOutput" == "true" ]; then
                "${dotnetCmd}" new $proj -lang $lang | tee -a "$logFile"
            else
                "${dotnetCmd}" new $proj -lang $lang >> "$logFile" 2>&1
            fi
        elif [[ "$1" == "run" && "$proj" =~ ^(web|mvc|webapi|razor)$ ]]; then
            if [ "$projectOutput" == "true" ]; then
                "${dotnetCmd}" $1 &
            else
                "${dotnetCmd}" $1 >> "$logFile" 2>&1 &
            fi
            webPid=$!
            echo "    waiting 20 seconds for web project with pid $webPid"
            sleep 20
            echo "    sending SIGINT to $webPid"
            pkill -SIGINT -P $webPid
            wait $!
            echo "    terminated with exit code $?"
        else
            if [ "$projectOutput" == "true" ]; then
                "${dotnetCmd}" $1 | tee -a "$logFile"
            else
                "${dotnetCmd}" $1 >> "$logFile" 2>&1
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

function runAllTests() {
    # Run tests for each language and template
    doCommand C# console new restore run
    doCommand C# classlib new restore build
    doCommand C# xunit new restore test
    doCommand C# mstest new restore test
     
    doCommand VB console new restore run
    doCommand VB classlib new restore build
    doCommand VB xunit new restore test
    doCommand VB mstest new restore test

    doCommand F# console new restore run
    doCommand F# classlib new restore build
    doCommand F# xunit new restore test
    doCommand F# mstest new restore test
     
    if [ "$excludeWebTests" == "false" ]; then
        doCommand C# web new restore run
        doCommand C# mvc new restore run
        doCommand C# webapi new restore run
        doCommand C# razor new restore run

        doCommand F# web new restore run
        doCommand F# mvc new restore run
        doCommand F# webapi new restore run
    fi
}

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

# Unzip dotnet if the dotnetDir is not specified
if [ "$dotnetDir" == "" ]; then
    OUTPUT_DIR="$SCRIPT_ROOT/bin/x64/$configuration/"
    DOTNET_TARBALL="$(ls ${OUTPUT_DIR}dotnet-sdk-${VERSION_PREFIX}*)"

    mkdir -p "$cliDir"
    tar xzf "$DOTNET_TARBALL" -C "$cliDir"
    dotnetDir="$cliDir"
else
    if ! [[ "$dotnetDir" = /* ]]; then
       dotnetDir="$SCRIPT_ROOT/$dotnetDir"
    fi
fi

# setup restore path
export NUGET_PACKAGES="$restoredPackagesDir"
SOURCE_BUILT_PKGS_PATH="$SCRIPT_ROOT/bin/obj/x64/$configuration/blob-feed/packages/"

# Run all tests, local restore sources first, online restore sources second
if [ "$excludeLocalTests" == "false" ]; then
    # Setup NuGet.Config with local restore source
    if [ -e "$SCRIPT_ROOT/smoke-testNuGet.Config" ]; then
        cp "$SCRIPT_ROOT/smoke-testNuGet.Config" "$testingDir/NuGet.Config"
        sed -i.bak "s|SOURCE_BUILT_PACKAGES|$SOURCE_BUILT_PKGS_PATH|g" "$testingDir/NuGet.Config"
        echo "$testingDir/NuGet.Config Contents:"
        cat "$testingDir/NuGet.Config"
    fi
    echo "RUN ALL TESTS - LOCAL RESTORE SOURCE"
    runAllTests
    echo "LOCAL RESTORE SOURCE - ALL TESTS PASSED!"
fi

# clean restore path
rm -rf "$restoredPackagesDir"

if [ "$excludeOnlineTests" == "false" ]; then
    # Setup NuGet.Config to use online restore sources
    if [ -e "$SCRIPT_ROOT/smoke-testNuGet.Config" ]; then
        cp "$SCRIPT_ROOT/smoke-testNuGet.Config" "$testingDir/NuGet.Config"
        sed -i.bak "/SOURCE_BUILT_PACKAGES/d" "$testingDir/NuGet.Config"
        echo "$testingDir/NuGet.Config Contents:"
        cat "$testingDir/NuGet.Config"
    fi
    echo "RUN ALL TESTS - ONLINE RESTORE SOURCE"
    runAllTests
    echo "ONLINE RESTORE SOURCE - ALL TESTS PASSED!"
fi

rm -rf "$cliDir"

echo "ALL TESTS PASSED!"
