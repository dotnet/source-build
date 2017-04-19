#!/usr/bin/env bash

usage()
{
    echo "Usage: $0 --rid <Runtime Identifier>"
    echo ""
    echo "Options:"
    echo "  --rid <Runtime Identifier>         Target Runtime Identifier"

    exit 1
}

set -e

# determine current directory
SOURCE="${BASH_SOURCE[0]}"
while [ -h "$SOURCE" ]; do # resolve $SOURCE until the file is no longer a symlink
  DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"
  SOURCE="$(readlink "$SOURCE")"
  [[ "$SOURCE" != /* ]] && SOURCE="$DIR/$SOURCE" # if $SOURCE was a relative symlink, we need to resolve it relative to the path where the symlink file was located
done

# initialize variables
__project_dir="$( cd -P "$( dirname "$SOURCE" )" && pwd )"
__packages_dir=$__project_dir/packages
__dotnet_path="$__project_dir/Tools/dotnetcli/"
__distro_rid=
SKIP_RESTORE=false

while [ "$1" != "" ]; do
    lowerI="$(echo $1 | awk '{print tolower($0)}')"
    case $lowerI in
        -h|--help)
            usage
            exit 1
            ;;
        --rid)
            shift
            __distro_rid=$1
            ;;
        --skiprestore)
            SKIP_RESTORE=true
            ;;
        --skiptests)
            SKIP_TESTS=true
            ;;
        *)
        echo "Unknown argument to pack.sh $1"
        exit 1
    esac
    shift
done

[ -z $DOTNET_PATH ] || __dotnet_path=$DOTNET_PATH
[ -z $NUGET_PACKAGES ] || __packages_dir=$NUGET_PACKAGES

# setup msbuild
"$__project_dir/init-tools.sh"

if [ "$SKIP_RESTORE"!=true ];then 
    # acquire dependencies
    $__dotnet_path/dotnet restore "$__project_dir/deps" --configfile "$__project_dir/../NuGet.Config" --disable-parallel --packages "$__packages_dir"
fi

# cleanup existing packages
rm -rf $__project_dir/bin

# build to produce nupkgs
__msbuild="$__project_dir/Tools/msbuild.sh"

__targets_param=
if [ "$(uname -s)" == "Darwin" ]; then
    __targets_param="OSGroup=OSX"
else
    __targets_param="OSGroup=Linux"
    if [ -z $__distro_rid ]; then
        echo "Runtime Identifier not defined"
        exit 1
    fi
fi

__common_parameters="/p:$__targets_param /p:DistroRid=$__distro_rid /verbosity:minimal"

if [ $SKIP_TESTS ]; then __common_parameters+=" /t:Build"; fi
if [ ! -z $NUGET_PACKAGES ]; then __common_parameters+=" /p:PackagesDir=$NUGET_PACKAGES"; fi

$__msbuild $__project_dir/tasks/core-setup.tasks.builds $__common_parameters || exit 1

$__msbuild $__project_dir/packages.builds $__common_parameters || exit 1

exit 0