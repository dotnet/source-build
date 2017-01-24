#!/bin/bash

set -euo pipefail

usage()
{
    echo "Build .NET Core product"
    echo "build.sh [options]"
    echo ""
    echo "Options"
    echo " -s|--netcore_sdk_path [.NET Core SDK Path]"
    echo " -f|--netcore_sharedframework_path"
    echo " -o|--output_folder [output folder]"
    echo " -h|--help"
}

create_output_folder() {
  if [[ ! -d $OUTPUTFOLDER ]]; then
    mkdir -p $OUTPUTFOLDER
  fi

  cp -r $NETCORESDKPATH/* $OUTPUTFOLDER
}

create_sdk_folder() {
  declare -a SHAREDVERSIONS=()
  declare -a VERSIONPARTS=()

  NETCORESHAREDPATHROOT=$OUTPUTFOLDER/shared/Microsoft.NETCore.App
  SHAREDVERSIONS=($(ls $NETCORESHAREDPATHROOT))
  SHAREDFRAMEWORKVERSION=${SHAREDVERSIONS[0]}

  # original shared framework folder
  NETCORESHAREDPATH=$NETCORESHAREDPATHROOT/$SHAREDFRAMEWORKVERSION

  IFS=. read -a VERSIONPARTS <<< "$SHAREDFRAMEWORKVERSION"
  MAJOR=${VERSIONPARTS[0]}
  MINOR=${VERSIONPARTS[1]}
  REV=${VERSIONPARTS[2]}
  REV=$((REV+1))

  SHAREDFRAMEWORKVERSION="$MAJOR.$MINOR.$REV"

  # roll forward shared framework folder
  ROLLFORWARDNETCORESHAREDPATH=$NETCORESHAREDPATHROOT/$SHAREDFRAMEWORKVERSION
  echo "Roll forward net core shared framework folder: $ROLLFORWARDNETCORESHAREDPATH"
}

seed_roll_forward_shared_framework_folder() {
  echo "Seeding..."
  if [[ ! -d $ROLLFORWARDNETCORESHAREDPATH ]]; then
    mkdir $ROLLFORWARDNETCORESHAREDPATH
  fi
  echo "Copy $NETCORESHAREDPATH..."
  # seed with assemblies from previous shared folder
  cp -rf $NETCORESHAREDPATH/* $ROLLFORWARDNETCORESHAREDPATH 
 
  echo "Update Shared framework Assemblies..."
  # update the shared framework assemblies
  cp -f $NETCORESHAREDFRAMEWORKPATH/shared/Microsoft.NETCore.App/*/*.so $ROLLFORWARDNETCORESHAREDPATH 
  cp -f $NETCORESHAREDFRAMEWORKPATH/shared/Microsoft.NETCore.App/*/*.dll $ROLLFORWARDNETCORESHAREDPATH

  echo "Replace Host files..."
  # replace host assemblies with older versions
  cp -f $NETCORESHAREDPATH/libhost*.so $ROLLFORWARDNETCORESHAREDPATH

  echo "Update Microsoft.NETCore.App.deps.json for shared framework changes..."
  cp -f $scriptRoot/../targets/Microsoft.NETCore.App.deps.json $ROLLFORWARDNETCORESHAREDPATH

  echo "Remove Shared Framework entries from SDK deps.json..."
du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.Collections\.NonGeneric\.dll.*//g' $file; done
du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.Collections\.Specialized\.dll.*//g' $file; done
du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.ComponentModel\.EventBasedAsync\.dll.*//g' $file; done
du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.ComponentModel\.Primitives\.dll.*//g' $file; done
du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.ComponentModel\.TypeConverter\.dll.*//g' $file; done
du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.Diagnostics\.Contracts\.dll.*//g' $file; done
du -a $OUTPUTFOLDER/sdk | awk '{print $2}' | grep '\.deps\.json$' | while IFS= read file; do sed -i.bak 's/.*System\.Resources\.Writer\.dll.*//g' $file; done

  echo "Seeding completed."
}


scriptRoot="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

NETCORESDKPATH=""
SDKVERSION=""
OUTPUTFOLDER=""
ADDITIONALARGS=()

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
      -o|--output_folder)
      OUTPUTFOLDER="$2"
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

NETCORESHAREDPATH=$NETCORESDKPATH/shared

create_output_folder
create_sdk_folder
seed_roll_forward_shared_framework_folder

echo "Created NETCore Patch folder at $OUTPUTFOLDER"
