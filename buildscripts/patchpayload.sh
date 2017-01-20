#!/bin/bash
set -euo pipefail

preparePatching()
{
  echo "Preparing patch..."
  PATCHPAYLOAD="$CLIPAYLOAD.patch"
  mkdir $PATCHPAYLOAD
  cp $CPARGS --recursive --force $CLIPAYLOAD/* $PATCHPAYLOAD
  
  PATCHPAYLOADSHAREDROOT="$PATCHPAYLOAD/shared/Microsoft.NETCore.App"
  SHAREDVERSIONS=($(ls --reverse $PATCHPAYLOADSHAREDROOT))
  PATCHPAYLOADSHAREDPATH="$PATCHPAYLOADSHAREDROOT/${SHAREDVERSIONS[0]}"
  
  PATCHPAYLOADSDKROOT="$PATCHPAYLOAD/sdk"
  SDKVERSIONS=($(ls --reverse $PATCHPAYLOADSDKROOT))
  PATCHPAYLOADSDKPATH="$PATCHPAYLOADSDKROOT/${SDKVERSIONS[0]}"
  
  PATCHPAYLOADHOSTROOT="$PATCHPAYLOAD/host/fxr"
  HOSTVERSIONS=($(ls --reverse $PATCHPAYLOADHOSTROOT))
  PATCHPAYLOADHOSTPATH="$PATCHPAYLOADHOSTROOT/${HOSTVERSIONS[0]}"
}

patchCoreClr()
{
   echo "Patching runtime binaries..."
   cp $CPARGS $CORECLRBINDIR/*so "$PATCHPAYLOADSHAREDPATH"
   cp $CPARGS "$CORECLRBINDIR/corerun" "$PATCHPAYLOADSHAREDPATH"
   cp $CPARGS "$CORECLRBINDIR/crossgen" "$PATCHPAYLOADSHAREDPATH"
}

patchCoreFx()
{
   echo "Patching framework binaries..."
   cp $CPARGS $COREFXBINDIR/System.* "$PATCHPAYLOADSHAREDPATH"
}

patchCoreSetup()
{
  echo "Patching SDK binaries..."
  cp $CPARGS "$CORESETUPBINDIR/dotnet" "$PATCHPAYLOAD"
  cp $CPARGS "$CORESETUPBINDIR/dotnet" "$PATCHPAYLOADSHAREDPATH"
  cp $CPARGS "$CORESETUPBINDIR/libhostpolicy.so" "$PATCHPAYLOADSHAREDPATH"
  cp $CPARGS "$CORESETUPBINDIR/libhostfxr.so" "$PATCHPAYLOADSHAREDPATH"
  cp $CPARGS "$CORESETUPBINDIR/libhostpolicy.so" "$PATCHPAYLOADSDKPATH"
  cp $CPARGS "$CORESETUPBINDIR/libhostfxr.so" "$PATCHPAYLOADSDKPATH"
  cp $CPARGS "$CORESETUPBINDIR/libhostfxr.so" "$PATCHPAYLOADHOSTPATH"
}

finalizePatching()
{
  echo "Finalizing patch..."
  cp --recursive --force $PATCHPAYLOAD/* $CLIPAYLOAD
  rm -dfr $PATCHPAYLOAD
}

CLIPAYLOAD=""
CORECLRBINDIR=""
COREFXBINDIR=""
CORESETUPBINDIR=""
CPARGS="--force"

while [[ $# -gt 0 ]]
  do
    key="$1"

    case $key in
      -p|--netcore_sdk_path)
      CLIPAYLOAD="$2"
      shift 2
      ;;
      -c|--coreclr_repo_path)
      CORECLRBINDIR="$2/bin/Product/Linux.x64.Release"
      shift 2
      ;;
      -f|--corefx_repo_path)
      COREFXBINDIR="$2/bin/Linux.x64.Release/native"
      #Older builds of corefx place binaries in "Native" instead of "native"
      if [[ ! -d $COREFXBINDIR ]]; then
        COREFXBINDIR="$2/bin/Linux.x64.Release/Native"
      fi
      shift 2
      ;;
      -s|--coresetup_repo_path)
      CORESETUPOSPATH=($(ls $2/artifacts))
      CORESETUPBINDIR="$2/artifacts/${CORESETUPOSPATH[0]}/corehost"
      shift 2
      ;;
      -v|--verbose)
      CPARGS="$CPARGS --verbose"
      shift 1
      ;;
      *)
      echo "Unknown argument specified '$key'."
      exit 1
    esac
done

missingdir="0"
if [[ ! -d $CLIPAYLOAD ]]; then
  echo "Error: Unable to find CLI directory to patch, specify CLI directory with the '--netcore_sdk_path' option."
  missingdir="1"
fi
if [[ ! -d $CORECLRBINDIR ]]; then
  echo "Error: Unable to find CoreClr bin directory, specify CoreClr repo path with the '--coreclr_repo_path' option."
  missingdir="1"
fi
if [[ ! -d $COREFXBINDIR ]]; then
  echo "Error: Unable to find CoreFx bin directory, specify CoreFx repo path with the '--corefx_repo_path' option."
  missingdir="1"
fi
if [[ ! -d $CORESETUPBINDIR ]]; then
  echo "Error: Unable to find CoreSetup bin directory, specify CoreSetup repo path with the '--coresetup_repo_path' option."
  missingdir="1"
fi
if [[ "$missingdir" == "1" ]]; then
  exit 1
fi

preparePatching
patchCoreClr
patchCoreFx
patchCoreSetup
finalizePatching

exit 0