#!/usr/bin/env bash

# Library. Source this script or copy-paste it into a shell to import its functions.

# Set up AzDO authentication if not already done in this environment, download a file, and extract
# it to the current dir. Logic is encapsulated to make this function easy to copy-paste to a machine
# that doesn't have a clone of this repository, which is common when downloading a tarball onto a
# fresh machine to validate it.
#
# Usage: download_tarball <url>
#   url: the URL to download. Wrap it in single quotes to avoid issues with special chars.
download_tarball() {
  [ "${azdo_build_pat:-}" ] || read -p 'AzDO dnceng PAT with build read permission: ' -s azdo_build_pat
  (
    set -euo pipefail
    url=$1
    temp_name=${temp_name:-tarball.tar.gz}

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
