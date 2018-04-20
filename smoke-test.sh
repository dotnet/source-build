#!/bin/bash
set -e

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
TARBALL_PREFIX=dotnet-sdk-
VERSION_PREFIX=2.1
OUTPUT_DIR="$SCRIPT_ROOT/bin/x64/Release/"
DOTNET_TARBALL_REL=$(ls ${OUTPUT_DIR}dotnet-sdk-${VERSION_PREFIX}*)
DOTNET_TARBALL=$(readlink -e ${DOTNET_TARBALL_REL})

projectOutput=false
keepProjects=false
dotnetDir=""
includeWeb=false
testingDir="$SCRIPT_ROOT/testing-smoke"
cliDir="$testingDir/builtCli"
logFile="$testingDir/smoke-test.log"

function usage() {
    echo ""
    echo "usage:"
    echo "  --dotnetDir         the directory from which to run dotnet"
    echo "  --projectOutput     echo dotnet's output to console"
    echo "  --keepProjects      keep projects after tests are complete"
    echo "  --includeWeb        run tests for web projects"
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
        --projectoutput)
            projectOutput=true
            ;;
        --keepprojects)
            keepProjects=true
            ;;
        --includeweb)
            includeWeb=true
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
    mkdir -p "$cliDir"
    tar xzf "$DOTNET_TARBALL" -C "$cliDir"
    dotnetDir="$cliDir"
else
    if ! [[ "$dotnetDir" = /* ]]; then
       dotnetDir="$SCRIPT_ROOT/$dotnetDir"
    fi
fi

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
 
if [ "$includeWeb" == "true" ]; then
    doCommand C# web new restore run
    doCommand C# mvc new restore run
    doCommand C# webapi new restore run
    doCommand C# razor new restore run

    doCommand F# web new restore run
    doCommand F# mvc new restore run
    doCommand F# webapi new restore run
fi

rm -rf "$cliDir"

echo "ALL TESTS PASSED!"
