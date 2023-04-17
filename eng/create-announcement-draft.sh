#!/bin/bash
set -euo pipefail

print-help ()
{
  echo "Uses a template to draft a release announcement and outputs it into a file."
  echo
  echo "Options:"
  echo "--template            The base template to use for the announcement"
  echo "--channel             Release channel, e.g. '8.0'"
  echo "                      Note that when 6.0/7.0, dotnet/installer is targeted, otherwise dotnet/dotnet"
  echo "--release-name        Human readable name of the release, e.g. '.NET 8 Preview 1'"
  echo "--release-version     Version of the release, e.g. '8.0.0-preview.3'"
  echo "--runtime-version     The .NET runtime version that is being released"
  echo "--sdk-version         The .NET SDK version that is being released"
  echo "--tag                 The release tag, e.g. v8.0.0-preview.1"
  echo "--prerelease          (Optional) Whether this is a preview release"
  echo "--help, -h            (Optional) Print this help message and exit"
  echo
}

template=''
channel=''
release_name=''
release_version=''
runtime_version=''
sdk_version=''
tag=''
prerelease=false

while [[ $# -gt 0 ]]; do
  opt="$(echo "$1" | tr "[:upper:]" "[:lower:]")"
  case "$opt" in
    -h | --help )
      print-help
      exit 0
      ;;
    --template )
      template="$2"
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
    --release-version )
      release_version="$2"
      shift 2
      ;;
    --runtime-version )
      runtime_version="$2"
      shift 2
      ;;
    --sdk-version )
      sdk_version="$2"
      shift 2
      ;;
    --tag )
      tag="$2"
      shift 2
      ;;
    --prerelease )
      prerelease=true
      shift 1
      ;;
    *)
      echo "Invalid argument $1"
      exit 1
      ;;
  esac
done

: "${template:?Missing --template}"
: "${channel:?Missing --channel}"
: "${release_name:?Missing --release-name}"
: "${release_version:?Missing --release-version}"
: "${runtime_version:?Missing --runtime-version}"
: "${sdk_version:?Missing --sdk-version}"
: "${tag:?Missing --tag}"

# Set environment variables that go in the announcement template
export TAG="$tag"
export RELEASE_NAME="$release_name"
export RELEASE_VERSION="$release_version"
export RUNTIME_VERSION="$runtime_version"
export RELEASE_CHANNEL="$channel"
export SDK_VERSION="$sdk_version"
export RELEASE_NOTES_URL="https://github.com/dotnet/core/blob/main/release-notes/$RELEASE_CHANNEL/$RUNTIME_VERSION/$SDK_VERSION.md"
export RELEASE_DATE=$(date +"%B %Y") # e.g. "March 2022"

if [[ "$prerelease" == true ]]; then
  # E.g. .NET 8.0 Preview 3 April 2023 Update - .NET 8.0.0-preview.3 and SDK 8.0.100-preview.3
  export TITLE="$RELEASE_NAME $RELEASE_DATE Update - .NET $RELEASE_VERSION and SDK $RELEASE_VERSION"
else
  # E.g. .NET 7.0 April 2023 Update - .NET 7.0.5 and SDK 7.0.105
  export TITLE=".NET $RELEASE_CHANNEL - .NET $RUNTIME_VERSION and SDK $SDK_VERSION"
fi

if [[ "$channel" == '6.0' || "$channel" == '7.0' ]]; then
  export TAG_URL="https://github.com/dotnet/installer/releases/tag/$tag"
else
  export TAG_URL="https://github.com/dotnet/dotnet/releases/tag/$tag"
fi

envsubst < "$template"
