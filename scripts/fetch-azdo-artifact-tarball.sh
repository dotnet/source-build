#!/usr/bin/env bash

set -euo pipefail

# Logic is encapsulated to make this function easy to copy-paste to a machine that doesn't have a
# clone of this repository. This may be common when downloading a tarball.
download_tarball() {
  (
    set -euo pipefail
    url=$1
    temp_name=${temp_name:-tarball.tar.gz}

    [ "$azdo_build_pat" ] || read -p 'AzDO dnceng PAT with build read permission: ' -s azdo_build_pat

    echo; echo 'Starting download...'

    curl -o "$temp_name" -u "intentionally_blank:$azdo_build_pat" "$url"
    if tar -xf "$temp_name"; then
      echo "Extracted using tar -xf"
    # Fall back to 'gunzip' as an intermediate to avoid problems found
    # decompressing archives with 'tar' when downloaded directly from AzDO.
    elif gunzip -d < "$temp_name" | tar -zx; then
      echo "Extracted using gunzip"
    else
      echo "Failed to extract $temp_name"
      exit 1
    fi

    rm "$temp_name"
    echo 'Complete!'
  )
}

download_tarball "$@"
