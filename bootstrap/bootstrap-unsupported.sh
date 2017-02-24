#!/bin/bash

set -euo pipefail

NETCORESHAREDFRAMEWORKPATH=""
HIGHESTSHAREDFRAMEWORK=""
MANAGEDCORECLRPATH=""
usage()
{
    echo "Build .NET Core product"
    echo "build.sh [options]"
    echo ""
    echo "Options"
    echo " -s|--netcore_sdk_path [.NET Core SDK path]"
    echo " -f|--netcore_sharedframework_path [Shared framework path]"
    echo " -o|--output_folder [output folder]"
    echo " -x|--corefx_repo_path [Core FX repo root path]"
    echo " -r|--coreclr_repo_path [Core CLR repo root path]"
    echo " -m|--managed_coreclr_path [Core CLR managed binaries path]"
    echo " -h|--help"
}

create_output_folder() {
  if [[ ! -d $OUTPUTFOLDER ]]; then
    mkdir -p $OUTPUTFOLDER
  fi

  cp -r $NETCORESDKPATH/* $OUTPUTFOLDER
}

build_corefx_native() {
  COREFXBINDIR=$COREFXREPOROOT/bin/Linux.x64.Release/Native

  if [[ ! -d "$COREFXBINDIR" ]]; then
    echo "Unable to find CoreFx bin directory, building corefx"
    $COREFXREPOROOT/src/Native/build-native.sh x64 Release
  fi

  echo "Copy native CoreFx binaries into shared framework path"
  cp -f $COREFXBINDIR/*.so $OUTPUTNETCORESHAREDPATH
}

build_coreclr_native() {
  CORECLRBINDIR=$CORECLRREPOROOT/bin/Product/Linux.x64.Release

  if [[ ! -d "$CORECLRBINDIR" ]]; then
    echo "Unable to find CoreClr bin directory, building coreclr"
    $CORECLRREPOROOT/build.sh x64 Release skiptests
  fi

  echo "Copy native CoreClr binaries into shared framework path"
  cp -f $CORECLRBINDIR/*.so $OUTPUTNETCORESHAREDPATH

  # copy over managed mscorlib and system.private.corelib which match native coreclr binaries
  # crossgen the binaries
  if [[ -d "$MANAGEDCORECLRPATH" ]]; then
    pushd $OUTPUTNETCORESHAREDPATH
    cp -f $CORECLRBINDIR/crossgen $OUTPUTNETCORESHAREDPATH
    cp -f $MANAGEDCORECLRPATH/* $OUTPUTNETCORESHAREDPATH
    $OUTPUTNETCORESHAREDPATH/crossgen mscorlib.dll
    $OUTPUTNETCORESHAREDPATH/crossgen System.Private.CoreLib.dll
    popd
  fi
}

get_shared_framework_version() {
  SHAREDVERSIONS=($(ls $OUTPUTNETCORESHAREDPATHROOT))
  SHAREDFRAMEWORKVERSION=""

  if [[ "$SHAREDFRAMEWORKVERSION" == "" ]] && echo ${SHAREDVERSIONS[@]} | grep -q "2\.0\."; then
    echo "2.0 shared framework detected"
    for V in "${SHAREDVERSIONS[@]}"; do
      if echo $V | grep -q "2\.0\."; then
        SHAREDFRAMEWORKVERSION=$V
      fi
    done
  fi
  if [[ "$SHAREDFRAMEWORKVERSION" == "" ]] && echo ${SHAREDVERSIONS[@]} | grep -q "1\.0\."; then
    echo "1.0 shared framework detected"
    for V in "${SHAREDVERSIONS[@]}"; do
      if echo $V | grep -q "1\.0\."; then
        SHAREDFRAMEWORKVERSION=$V
      fi
    done
  fi
  if [[ "$SHAREDFRAMEWORKVERSION" == "" ]] && echo ${SHAREDVERSIONS[@]} | grep -q "1\.1\."; then
    echo "1.1 shared framework detected"
    for V in "${SHAREDVERSIONS[@]}"; do
      if echo $V | grep -q "1\.1\."; then
        SHAREDFRAMEWORKVERSION=$V
      fi
    done
  fi
  if [[ "$SHAREDFRAMEWORKVERSION" == "" ]]; then
    echo "Unable to determine shared framework version to update from $OUTPUTNETCORESHAREDPATHROOT."
    exit 1
  fi
}

get_sdk_folder() {
  declare -a SHAREDVERSIONS=()
  declare -a VERSIONPARTS=()

  OUTPUTNETCORESHAREDPATHROOT=$OUTPUTFOLDER/shared/Microsoft.NETCore.App

  # determine shared framework version to update and store it in $SHAREDFRAMEWORKVERSION
  get_shared_framework_version

  # original shared framework folder
  OUTPUTNETCORESHAREDPATH=$OUTPUTNETCORESHAREDPATHROOT/$SHAREDFRAMEWORKVERSION
}

seed_roll_forward_shared_framework_folder() {
  echo "Seeding..."
 
  if [[ ! "$NETCORESHAREDFRAMEWORKPATH" == "" ]]; then
    echo "Update Shared framework Assemblies..."
    if [[ ! -d "$OUTPUTNETCORESHAREDPATH/tmp" ]]; then
      mkdir $OUTPUTNETCORESHAREDPATH/tmp
    fi
    # save some files we don't want to overwrite
    cp -f $OUTPUTNETCORESHAREDPATH/Microsoft.CodeAnalysis*.dll $OUTPUTNETCORESHAREDPATH/tmp
    cp -f $OUTPUTNETCORESHAREDPATH/libhost*.so $OUTPUTNETCORESHAREDPATH/tmp

    # update the shared framework assemblies
    cp -f $NETCORESHAREDFRAMEWORKPATH/shared/Microsoft.NETCore.App/*/*.so $OUTPUTNETCORESHAREDPATH
    cp -f $NETCORESHAREDFRAMEWORKPATH/shared/Microsoft.NETCore.App/*/*.dll $OUTPUTNETCORESHAREDPATH

    #replace files we saved
    cp -f $OUTPUTNETCORESHAREDPATH/tmp/* $OUTPUTNETCORESHAREDPATH
  fi

  if [[ ! "$NETCORESHAREDFRAMEWORKPATH" == "" ]]; then
    echo "Update Shared framework Assemblies..."
    # Hack until we have CLI running on 2.0 shared framework
    echo "Update Microsoft.NETCore.App.deps.json for shared framework changes..."
    if echo "$SHAREDFRAMEWORKVERSION" | grep -q "1\.0\." || echo "$SHAREDFRAMEWORKVERSION" | grep -q "1\.1\."; then
      cp -f $scriptRoot/Microsoft.NETCore.App.deps.json $OUTPUTNETCORESHAREDPATH

      # Hack until we have CLI running on 2.0 shared framework
      echo "Remove Shared Framework entries from SDK deps.json..."
      du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.Collections\.NonGeneric\.dll.*//g' $file; done
      du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.Collections\.Specialized\.dll.*//g' $file; done
      du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.ComponentModel\.EventBasedAsync\.dll.*//g' $file; done
      du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.ComponentModel\.Primitives\.dll.*//g' $file; done
      du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.ComponentModel\.TypeConverter\.dll.*//g' $file; done
      du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.Diagnostics\.Contracts\.dll.*//g' $file; done
      du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.Resources\.Writer\.dll.*//g' $file; done
    fi
  fi
  echo "Seeding completed."
}

scriptRoot="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

NETCORESDKPATH=""
SDKVERSION=""
COREFXREPOROOT=""
CORECLRREPOROOT=""
OUTPUTFOLDER=""

while [[ $# -gt 0 ]]
  do
    key="$1"

    case $key in
      -s|--netcore_sdk_path)
      NETCORESDKPATH="$2"
      shift 2
      ;;
      -f|--netcore_sharedframework_path)
      NETCORESHAREDFRAMEWORKPATH="$2"
      shift 2
      ;;
      -x|--corefx_repo_path)
      COREFXREPOROOT="$2"
      shift 2
      ;;
      -r|--coreclr_repo_path)
      CORECLRREPOROOT="$2"
      shift 2
      ;;
      -o|--output_folder)
      OUTPUTFOLDER="$2"
      shift 2
      ;;
      -m|--managed_coreclr_path)
      MANAGEDCORECLRPATH="$2"
      shift 2
      ;;
      -h|--help)
      usage
      exit 0
      ;;
      *)
      echo "Unknown argument '$1'"
      usage
      exit 1
      shift
    esac
done

OUTPUTNETCORESHAREDPATH=$NETCORESDKPATH/shared

create_output_folder
get_sdk_folder
seed_roll_forward_shared_framework_folder
build_coreclr_native
build_corefx_native

echo "Created NETCore Patch folder at $OUTPUTFOLDER"
