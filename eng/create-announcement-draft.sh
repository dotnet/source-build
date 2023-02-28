#!/bin/bash

print-help ()
{
   echo "Uses a template to draft a release announcement and outputs it into a file."
   echo
   echo "Options:"
   echo "--template            The base template to use for the announcement"
   echo "--output-file         The file to output the announcement to"
   echo "--channel             Release channel, e.g. '8.0'"
   echo "--release-name        Human readable name of the release, e.g. '.NET 8 Preview 1'"
   echo "--sdk-version         The .NET SDK version that is being released"
   echo "--runtime-version     The .NET runtime version that is being released"
   echo "--tag                 The release tag, e.g. v8.0.0-preview.1"
   echo "--help, -h            (Optional) print this help message and exit"
   echo
}

LONG=template:,channel:,output-file:,release-name:,sdk-version:,runtime-version:,tag:,help

OPTS=$(getopt --options --long $LONG --name "$0" -- "$@")
if [ $? != 0 ] ; then echo "Failed to parse options." >&2 ; exit 1 ; fi
eval set -- "$OPTS"

template=''
output_file=''
channel=''
release_name=''
sdk_version=''
runtime_version=''
tag=''

while true ; do
  case "$1" in
    -h | --help )
      print-help
      exit 0
      ;;
    --template )
      template="$2"
      shift 2
      ;;
    --output-file )
      output_file="$2"
      shift 2
      ;;
    --channel )
      channel="$2"
      shift 2
      ;;
    --release-name )
      release_name="$2"
      shift 2
      ;;
    --sdk-version )
      sdk_version="$2"
      shift 2
      ;;
    --runtime-version )
      runtime_version="$2"
      shift 2
      ;;
    --tag )
      tag="$2"
      shift 2
      ;;
    *)
      echo "Invalid argument $1"
      exit 1
      ;;
  esac
done

# Set environment variables that go in the announcement template
export TAG="$tag"
export RELEASE_NAME="$release_name"
export RUNTIME_VERSION="$runtime_version"
export RELEASE_CHANNEL="$channel"
export SDK_VERSION="$sdk_version"
export RELEASE_NOTES_URL="https://github.com/dotnet/core/blob/main/release-notes/$RELEASE_CHANNEL/$RUNTIME_VERSION/$SDK_VERSION.md"
export RELEASE_DATE=$(date +"%B %Y") # e.g. "March 2022"

if [[ "$channel" == '6.0' || "$channel" == '7.0' ]]; then
    export TAG_URL="https://github.com/dotnet/installer/releases/tag/$tag"
else
    export TAG_URL="https://github.com/dotnet/dotnet/releases/tag/$tag"
fi

template="$(envsubst < "$template")"

echo "$template" > "$output_file"
