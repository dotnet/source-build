#!/bin/bash
set -euo pipefail

print-help ()
{
   echo "Updates the VMR"
   echo
   echo "Syntax: ./update-vmr.sh --releaseChannel 7.0 --sdkVersion 7.0.100 --upstream <valid git url> --sources dotnet-sdk-source.tar.gz"
   echo
   echo "options:"
   echo "--releaseChannel, -r  The .NET SDK release channel (e.g. 6.0)"
   echo "--sdkVersion, -v      The .NET SDK version (e.g. 6.0.110)"
   echo "--upstream, -u        A valid git URL to the upstream repo to update from and push to"
   echo "--sources, -s         Either directory or a tarball with sources to update the VMR with"
   echo "--isDryRun, -d        (Optional) If set, then don't push results to upstream"
   echo "--help, -h            (Optional) print this help message and exit"
   echo
}

SHORT=r:v:u:t:dh
LONG=releaseChannel:,sdkVersion:,upstream:,tarball:,isDryRun,help

OPTS=$(getopt --options $SHORT --long $LONG --name "$0" -- "$@")
if [ $? != 0 ] ; then echo "Failed to parse options." >&2 ; exit 1 ; fi
eval set -- "$OPTS"

is_dry_run='false'

while true ; do
  case "$1" in
    -h | --help )
      print-help
      exit 0
      ;;
    -r | --releaseChannel )
      release_channel="$2"
      shift 2
      ;;
    -v | --sdkVersion )
      sdk_version="$2"
      shift 2
      ;;
    -u | --upstream )
      upstream_url="$2"
      shift 2
      ;;
    -t | --tarball )
      source_location="$2"
      shift 2
      ;;
    -d | --isDryRun )
      is_dry_run=true
      shift
      ;;
    -- )
      shift
      break
      ;;
    *)
      echo "Internal error! Are you missing required arguments?"
      exit 1
      ;;
  esac
done

: ${release_channel:?Missing --releaseChannel}
: ${sdk_version:?Missing --sdkVersion}
: ${upstream_url:?Missing --upstream}
: ${source_location:?Missing --sources}

month_year=$(date +"%b%Y" -d "+1 month" | sed 's/.*/\L&/') # e.g. aug2022

# replace the last two characters in sdk_version with xx
branch_version=$(echo ${sdk_version} | sed 's/..$/xx/')
target_branch="release/${branch_version}" # e.g. release/6.0.1xx
new_branch_name="dev/${sdk_version}-${month_year}"

# Check if source_location is dir or a tarball
if [ -d "${source_location}" ]; then
  echo "Source location is a directory, will use it as is."
  vmr_path="${source_location}"

  git -C "${vmr_path}" checkout "${target_branch}"
  git -C "${vmr_path}" checkout -b "${new_branch_name}"

elif [ -f "${source_location}" ]; then
  echo "Source location is a tarball, will extract it."
  vmr_path="$(pwd)/dotnet-vmr"
  rm -rf "${vmr_path}"

  git init "${vmr_path}"

  git -C "${vmr_path}" remote add upstream "${upstream_url}"
  git -C "${vmr_path}" fetch upstream "${target_branch}" --depth=1
  git -C "${vmr_path}" checkout "${target_branch}"
  git -C "${vmr_path}" checkout -b "${new_branch_name}"

  # delete all contents except the .git folder
  # otherwise we won't catch deleted files in a commit
  ls | grep -v ".git" | xargs rm -rf
  tar -xzf "${source_location}" -C "${vmr_path}"

  git -C "${vmr_path}" add -f .

  git -C "${vmr_path}" config user.email "dotnet-maestro[bot]@users.noreply.github.com"
  git -C "${vmr_path}" config user.name "dotnet-maestro[bot]"
  git -C "${vmr_path}" commit -m "Update to .NET ${sdk_version}"

else
  echo "##vso[task.logissue type=error]Source location ${source_location} is neither a directory nor a tarball. Exiting..."
  exit 1
fi

if [ "$is_dry_run" = true ]; then
  echo "Doing a dry run, not pushing to upstream. List of changes:"
  git -C "${vmr_path}" log --name-status HEAD^..HEAD
else
  echo "Pushing branch to upstream."
  git -C "${vmr_path}" push -u upstream "${new_branch_name}"
fi
