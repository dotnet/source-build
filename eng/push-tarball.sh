#!/bin/bash
set -euo pipefail

print-help ()
{
   echo "Pushes sources from a given tarball into a given repository"
   echo
   echo "Syntax: ./update-vmr.sh --releaseChannel 7.0 --sdkVersion 7.0.100 --upstream <valid git url> --tarball dotnet-sdk-source.tar.gz"
   echo
   echo "options:"
   echo "--releaseChannel, -r  The .NET SDK release channel (e.g. 6.0)"
   echo "--sdkVersion, -v      The .NET SDK version (e.g. 6.0.110)"
   echo "--upstream, -u        A valid git URL to the upstream repo to update from and push to"
   echo "--tarball, -t         The tarball to update the VMR with"
   echo "--isDryRun, -d        (Optional) If set, then don't push results to upstream"
   echo "--help, -h            (Optional) print this help message and exit"
   echo
}

SHORT=r:v:u:t:d:h
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
      source_tarball="$2"
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
: ${source_tarball:?Missing --tarball}

if [ ! -f "$source_tarball" ]; then
  echo "##vso[task.logissue type=error]File $source_tarball not found on disk. Exiting..."
fi

month_year=$(date +"%b%Y" -d "+14 days" | sed 's/.*/\L&/') # e.g. aug2022

vmr_path="$(pwd)/dotnet-vmr"

# replace the last two characters in sdk_version with xx
branch_version=$(echo "$sdk_version" | sed 's/..$/xx/')
target_branch="release/$branch_version" # e.g. release/6.0.1xx

rm -rf "$vmr_path"
git init "$vmr_path"

pushd "$vmr_path"
  git remote add upstream "$upstream_url"
  git fetch upstream "$target_branch" --depth=1
  git checkout "$target_branch"

  new_branch_name="dev/$sdk_version-$month_year"
  if git fetch upstream "$new_branch_name"; then
    echo "Branch $new_branch_name already exists (possibly from a previous run)"
    git checkout "$new_branch_name"
  else
    echo "Branch $new_branch_name not found in the remote"
    git checkout -b "$new_branch_name"
  fi

  # delete all contents except the .git folder
  # otherwise we won't catch deleted files in a commit
  ls | grep -v ".git" | xargs rm -rf
  tar -xzf "$source_tarball" -C "$vmr_path"

  git config user.email "dotnet-maestro[bot]@users.noreply.github.com"
  git config user.name "dotnet-maestro[bot]"

  # Re-runs should expect the branch being merged previously already
  git add -f .
  git diff --staged --quiet || git commit -m "Update to .NET $sdk_version"

  pr_url=$(echo $upstream_url | sed "s,_git.*,_apis/git/repositories/security-partners-dotnet/pullrequests?api-version=7.0,g")
  data="{
    \"sourceRefName\": \"refs/heads/$new_branch_name\",
    \"targetRefName\": \"refs/heads/$target_branch\",
    \"title\": \"Update to $sdk_version\",
    \"description\": \"Update to $sdk_version\"
  }"

  if [ "$is_dry_run" = true ]; then
    echo "Doing a dry run, not pushing to upstream. List of changes:"
    git log --name-status HEAD^..HEAD || echo "No changes to commit."
    echo "Would push $new_branch_name to $upstream_url"
    echo "Would create PR from $new_branch_name to $target_branch"
    echo "PR creation payload: $data"
    echo "PR creation URL: $pr_url"
  else
    echo "Pushing branch to upstream."
    git push -u upstream "$new_branch_name"

    echo "Creating PR from $new_branch_name to $target_branch"
    curlResult=$(curl -H 'Content-Type: application/json' -d "$data" "$pr_url" 2>/dev/null)
    webUrl=$(jq -r '.repository.webUrl | values' <<< "$curlResult")
    pullRequestId=$(jq -r '.pullRequestId | values' <<< "$curlResult")
    if [ -n "$webUrl" ] && [ -n "$pullRequestId" ]; then
      echo "$webUrl"/pullrequest/"$pullRequestId"
    elif [[ "$curlResult" == *"TF401179"* ]]; then
      echo "##vso[task.logissue type=error]$(jq -r '.message' <<< "$curlResult")"
    else
      echo "##vso[task.logissue type=error]An unexpected error has occurred during the pr request!"
      jq <<< "$curlResult"
    fi
  fi
popd
