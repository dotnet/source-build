#!/bin/bash
set -euo pipefail

print-help ()
{
  echo "Uses a template to draft a release announcement and outputs it into a file."
  echo
  echo "Options:"
  echo "--template FILE       The base template to use for the announcement"
  echo "--channel CHANNEL     Release channel, e.g. '8.0'"
  echo "                      Note that when 6.0/7.0, dotnet/installer is targeted, otherwise dotnet/dotnet"
  echo "--release RELEASE     Programmatic name of the release, e.g. '8.0.0.preview-1'"
  echo "--release-name NAME   Human readable name of the release, e.g. '.NET 8 Preview 1'"
  echo "--sdk-version VERSION The .NET SDK version that is being released"
  echo "--runtime-version VER The .NET runtime version that is being released"
  echo "--tag TAG             The release tag, e.g. v8.0.0-preview.1"
  echo "--prerelease          (Optional) Whether this is a preview release"
  echo "--help, -h            (Optional) print this help message and exit"
  echo
}

template=''
channel=''
release=''
release_name=''
sdk_version=''
runtime_version=''
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
    --release )
      release="$2"
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
: "${release:?Missing --release}"
: "${release_name:?Missing --release-name}"
: "${sdk_version:?Missing --sdk-version}"
: "${runtime_version:?Missing --runtime-version}"
: "${tag:?Missing --tag}"

# Set environment variables that go in the announcement template
export TAG="$tag"
export RELEASE="$release"
export RELEASE_NAME="$release_name"
export RUNTIME_VERSION="$runtime_version"
export RELEASE_CHANNEL="$channel"
export SDK_VERSION="$sdk_version"
export RELEASE_DATE=$(date +"%B %Y") # e.g. "March 2022"

if [[ "$channel" == '6.0' || "$channel" == '7.0' ]]; then
    export TAG_URL="https://github.com/dotnet/installer/releases/tag/$tag"
else
    export TAG_URL="https://github.com/dotnet/dotnet/releases/tag/$tag"
fi

if [[ "$prerelease" == true ]]; then
  export RELEASE_NOTES_URL="https://github.com/dotnet/core/blob/main/release-notes/$RELEASE_CHANNEL/preview/$RELEASE.md"

  # Removes the build number so that 8.0.100-preview.3.23178.7 becomes 8.0.100-preview.3
  export SDK_VERSION_SHORT=$(echo "$SDK_VERSION" | sed 's/\(.*preview\.[0-9]\+\).*/\1/')
  export RUNTIME_VERSION_SHORT=$(echo "$RUNTIME_VERSION" | sed 's/\(.*preview\.[0-9]\+\).*/\1/')
else
  export RELEASE_NOTES_URL="https://github.com/dotnet/core/blob/main/release-notes/$RELEASE_CHANNEL/$RUNTIME_VERSION/$SDK_VERSION.md"
  export SDK_VERSION_SHORT="$SDK_VERSION"
  export RUNTIME_VERSION_SHORT="$RUNTIME_VERSION"
fi

envsubst < "$template"
