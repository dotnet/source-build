#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

# resolve $SOURCE until the file is no longer a symlink
source="${BASH_SOURCE[0]}"
scriptroot="$( cd -P "$( dirname "$source" )" && pwd )"
while [[ -h $source ]]; do
  scriptroot="$( cd -P "$( dirname "$source" )" && pwd )"
  source="$(readlink "$source")"

  # if $source was a relative symlink, we need to resolve it relative to the path where the
  # symlink file was located
  [[ $source != /* ]] && source="$scriptroot/$source"
done

scriptroot="$( cd -P "$( dirname "$source" )" && pwd )"

"$scriptroot/../../eng/common/build.sh" --pack -c Release --warnaserror false $@ /p:Projects="$scriptroot/package.proj"
