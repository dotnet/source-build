#!/bin/bash
set -e

TARBALL_PREFIX=dotnet-sdk-
VERSION_PREFIX=2.1
OUTPUT_DIR=bin/x64/Release/
DOTNET_TARBALL_REL=$(ls ${OUTPUT_DIR}dotnet-sdk-${VERSION_PREFIX}*)
DOTNET_TARBALL=$(readlink -e ${DOTNET_TARBALL_REL})

projectOutput=false
keepProjects=false
dotnetDir=""
workingDir="$(pwd)"
includeWeb=false

function usage {
    echo ""
    echo "usage:"
    echo "  --dotnetDir         the directory from which to run dotnet"
    echo "  --projectOutput     echo dotnet's output to console"
    echo "  --keepProjects      keep projects after tests are complete"
    echo "  --includeWeb        run tests for web projects"
    echo "  --clean             remove the testing directory if it exists"
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
        --clean)
            cleanFirst=true
            ;;
        *)
            usage
            exit 1
            ;;
    esac

    shift
done


function doCommand {
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

        echo "    running $1" | tee -a ../smoke-test.log

        if [ "$1" == "new" ]; then
            if [ "$projectOutput" == "true" ]; then
                ${dotnetCmd} new $proj -lang $lang 
            else
                ${dotnetCmd} new $proj -lang $lang >> ../smoke-test.log 2>&1
            fi
        elif [[ "$1" == "run" && "$proj" =~ ^(web|mvc|webapi|razor)$ ]]; then
            if [ "$projectOutput" == "true" ]; then
                ${dotnetCmd} $1 &
            else
                ${dotnetCmd} $1 >> ../smoke-test.log 2>&1 &
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
                ${dotnetCmd} $1
            else
                ${dotnetCmd} $1 >> ../smoke-test.log 2>&1
            fi
        fi
        if [ $? -eq 0 ]; then
            echo "    $1 succeeded" >> ../smoke-test.log
        else
            echo "    $1 failed with exit code $?" >> tee -a ../smoke-test.log
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
if [ "$cleanFirst" == "true" ]; then
    rm -rf testing-smoke
fi

mkdir testing-smoke
cd testing-smoke

# Unzip dotnet if the dotnetDir is not specified
if [ "$dotnetDir" == "" ]; then
    mkdir builtCli
    cd builtCli
    tar xzf ${DOTNET_TARBALL}
    cd ..
    dotnetDir="../builtCli/"
else
    if ! [[ "$dotnetDir" = /* ]]; then
       dotnetDir="$workingDir/$dotnetDir" 
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

rm -rf builtCli

echo "ALL TESTS PASSED!"
