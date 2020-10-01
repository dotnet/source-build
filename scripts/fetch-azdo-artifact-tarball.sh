#!/usr/bin/env bash

# Library. Source this script or copy-paste it into a shell to import its functions.

# Set up AzDO authentication if not already done in this environment, download a file, and extract
# it to the current dir. Logic is encapsulated to make this function easy to copy-paste to a machine
# that doesn't have a clone of this repository, which is common when downloading a tarball onto a
# fresh machine to validate it.
#
# If env var 'azdo_build_pat' isn't detected, prompts to set it. The prompt is intended to help a
# little bit by keeping the PAT off 'history' while also making multiple calls to the function
# convenient. Be aware that the PAT is put into the current shell's env.
#
# Usage: download_tarball <url>
#   url: the URL to download. Wrap it in single quotes to avoid issues with special chars.
#
# Usage: name=<targz-path> download_tarball <url>
#   Downloads the tarball to a specific name/location.
download_tarball() {
  [ "${azdo_build_pat:-}" ] || read -p 'AzDO dnceng PAT with build read permission: ' -s azdo_build_pat
  (
    set -euo pipefail
    url=$1
    name=${name:-tarball.tar.gz}

    echo; echo 'Starting download...'

    # Sometimes tooling converts %-encoding back to spaces. AzDO doesn't like that (400 error), so
    # put the % back. (Full encoding might be better, but we just have spaces to deal with so far.)
    url=${url// /%20}

    curl -fSL -o "$name" -u "intentionally_blank:$azdo_build_pat" "$url"

    echo "Completed download: '$url' -> '$name'"
  )
}

# Extract a tarball into the working directory. This includes a workaround for tarballs downloaded
# from AzDO, which may have been double-compressed by the server.
#
# Usage: name=<tarball-path> extract_tarball
extract_tarball() {
  (
    set -euo pipefail

    if tar -xf "$name"; then
      echo "Extracted using tar -xf"
    # Fall back to 'gunzip' as an intermediate to avoid problems found
    # decompressing archives with 'tar' when downloaded directly from AzDO.
    # AzDO seems to double-compress the tar.gz: https://superuser.com/a/841876
    elif gunzip -d < "$name" | tar -zx; then
      echo "Extracted using gunzip"
    else
      echo "Failed to extract $name"
      exit 1
    fi

    echo "Completed extracting: $name"
  )
}

# Use download_tarball to download a tarball to a temporary file in the working dir, extract the
# tar.gz in the working dir, and delete the temporary file.
#
# Usage: download_extract_tarball <url>
#   url: the URL to download. Wrap it in single quotes to avoid issues with special chars.
download_extract_tarball() {
  (
    set -euo pipefail

    url=$1

    date_now_for_path=$(date +%Y-%m-%d_%H%M%S)
    export name=${name:-tarball-${date_now_for_path}.tar.gz}

    download_tarball "$url"
    extract_tarball

    rm "$name"
    echo "Completed download_extract_tarball."
  )
}

# AzDO sometimes double-compresses tarballs unexpectedly, which can cause problems with
# rename_inner_targz during the release process. This function extracts the tarball file with a
# workaround and re-creates it. Uses a temporary dir in the working directory to store extracted
# contents. The targz file must be in the working dir.
#
# Usage: fix_azdo_tarball <targz-file>
fix_azdo_tarball() {
  (
    set -euo pipefail

    tar=$1
    tar_temp=${tar}-temp-extract

    set -x

    mkdir "$tar_temp"
    (
      cd "$tar_temp"
      name="../$tar" extract_tarball
      rm "../$tar"

      tar --numeric-owner -zcf "../$tar" *
    )
    rm -rf "$tar_temp"
  )
}

# Renames the inner top-level dir inside a tarball to something else. Creates a new tar.gz in the
# working dir that matches the new inner top-level dir. The input tar.gz file must contain only a
# single directory at its root. The working directory must not have any exiting files that match the
# old inner dir name, target inner dir name, or output tarball name.
#
# This is only intended to be useful to manually create a nice-looking final source-build tarball to
# upload to blob storage. We should instead have the build produce a nice name to begin with:
# https://github.com/dotnet/source-build/issues/747
#
# Usage: rename_tarball_inner_dir <targz-name> <target-name>
#   targz-name: The name of the tarball file. Includes extension.
#   target-name:
#     The desired name of the inner dir in the output tar.gz. The output tar.gz is named
#     {target-name}.tar.gz in the working directory.
rename_tarball_inner_dir() {
  (
    set -u

    tar=$1
    target=$2

    first=$(tar -ztf "$tar" | head -1)
    inner=${first%%/*}

    abort_if_exists "$inner"
    abort_if_exists "$target"
    abort_if_exists "$target.tar.gz"

    set -x

    tar -xf "$tar"
    mv "$inner" "$target"
    tar --numeric-owner -zcf "$target.tar.gz" "$target"
    rm -rf "$target"
  )
}

# Renames the given targz so that its filename matches its top-level directory. The output tarball
# ends up in the working dir.
#
# Usage: rename_targz_to_match_first_dir <targz-name>
rename_targz_to_match_first_dir() {
  (
    set -u

    tar=$1
    first_file=$(tar -ztf "$tar" | head -1)
    first_dir=${first_file%%/*}
    tar_dest=${first_dir}.tar.gz

    abort_if_exists "$tar_dest"

    set -x
    mv "$tar" "$tar_dest"
  )
}

abort_if_exists() {
  if [ -a "$1" ]
  then
    echo "Aborting: file exists: $1"
    exit 1
  fi
}
