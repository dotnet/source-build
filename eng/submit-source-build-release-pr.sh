#!/bin/bash
set -euxo pipefail

time="$(date +%s)"

print-help ()
{
   echo "Submits a PR that updates the source-build artifacts version and
global.json dotnet version. Depends on jq, git, and the gh cli. The gh cli also
must be authenticated, otherwise the GH_TOKEN environment variable must be
set to a GitHub token that has permission to edit the forked repo and submit
a PR in the target repo."
   echo
   echo "Syntax: ./submit-source-build-release-pr.sh --target-repo dotnet/installer --fork-repo dotnet-sb-bot/installer --sdkVersion 6.0.101"
   echo "options:"
   echo "--targetRepo, -t      The repo to submit the PR to"
   echo "--forkRepo, -f        The repo to submit the PR from"
   echo "--sdkVersion, -v      The .NET SDK version to update to"
   echo "--title, -T           The title of the PR"
   echo "--body, -B            The body of the PR"
   echo "--targetBranch, -b    (Optional) branch to submit the PR to, calculated automatically otherwise"
   echo "--globalJson, -g      (Optional) path to the global.json file to update"
   echo "--versionsProps, -p   (Optional) path to the Versions.props file to update"
   echo "--resolvedSourceBuiltArtifactsFileName, -a   (Optional) actul Source Built Artifacts File Name"
   echo "--resolvedSdkArtifactFileName, -s   (Optional) actul Sdk Artifact File Name"
   echo "--setupGitAuth, -G    (Optional) set up git authentication using the gh CLI"
   echo "--help, -h            (Optional) print this help message and exit"
   echo
}

SHORT=t:f:v:T:B:b:g:p:a:s:Gh
LONG=targetRepo:,forkRepo:,sdkVersion:,title:,body:,targetBranch:,globalJson:,versionsProps:,resolvedSourceBuiltArtifactsFileName:,resolvedSdkArtifactFileName:,setupGitAuth,help

OPTS=$(getopt --options $SHORT --long $LONG --name "$0" -- "$@")
if [ $? != 0 ] ; then echo "Failed to parse options." >&2 ; exit 1 ; fi
eval set -- "$OPTS"

global_json_path='src/SourceBuild/content/global.json'
versions_props_path='src/SourceBuild/content/eng/Versions.props'
custom_target_branch=''
setup_git_auth=''
resolved_source_built_artifacts_file_name=''
resolved_sdk_artifact_file_name=''

while true ; do
  case "$1" in
    -h | --help )
      print-help
      exit 0
      ;;
    -G | --setupGitAuth )
      setup_git_auth='true'
      shift
      ;;
    -t | --targetRepo )
      target_repo="$2"
      shift 2
      ;;
    -f | --forkRepo )
      fork_repo="$2"
      shift 2
      ;;
    -v | --sdkVersion )
      sdk_version="$2"
      shift 2
      ;;
    -T | --title )
      title="$2"
      shift 2
      ;;
    -B | --body )
      body="$2"
      shift 2
      ;;
    -g | --globalJson )
      global_json_path="$2"
      shift 2
      ;;
    -p | --versionsProps )
      versions_props_path="$2"
      shift 2
      ;;
    -b | --targetBranch )
      custom_target_branch="$2"
      shift 2
      ;;
    -a | --resolvedSourceBuiltArtifactsFileName )
      resolved_source_built_artifacts_file_name="$2"
      shift 2
      ;;
    -s | --resolvedSdkArtifactFileName )
      resolved_sdk_artifact_file_name="$2"
      shift 2
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

echo "target_repo = $target_repo"
echo "fork_repo = $fork_repo"
echo "sdk_version = $sdk_version"
echo "title = $title"
echo "body = $body"
echo "global_json_path = $global_json_path"
echo "versions_props_path = $versions_props_path"
echo "custom_target_branch = $custom_target_branch"
echo "setup_git_auth = $setup_git_auth"
echo "resolved_source_built_artifacts_file_name = $resolved_source_built_artifacts_file_name"
echo "resolved_sdk_artifact_file_name = $resolved_sdk_artifact_file_name"


if [[ ${setup_git_auth} == true ]]; then
  echo "Setting up git auth"
  gh auth setup-git
fi

if [ -z "${custom_target_branch}" ]; then
  pr_target_branch=$(echo "release/${sdk_version}" | sed 's/..$/xx/')
else
  pr_target_branch="${custom_target_branch}"
fi

fork_url="https://github.com/${fork_repo}"
upstream_url="https://github.com/${target_repo}"

# clone forked repo
repo_dir="repo-${time}" # "dotnet-installer-${time}"
git clone "${fork_url}" "${repo_dir}" --depth 1
cd "${repo_dir}"

# set up upstream remote
git remote add upstream "${upstream_url}"
git fetch upstream "${pr_target_branch}"

# checkout a new branch on fork
monthYear=$(date +"%b%Y" | sed 's/.*/\L&/')
new_branch_name="${sdk_version}-${monthYear}-source-build-${time}"
git checkout -b "${new_branch_name}" "upstream/${pr_target_branch}"

# make pr changes
cat "$global_json_path" \
    | jq --unbuffered ".tools.dotnet=\"${sdk_version}\"" \
    | tee "$global_json_path.new"
mv "$global_json_path.new" "$global_json_path"

# Function to modify the URL in an XML file
# Arguments:
#   1. XML file path
#   2. Element name
#   3. Replacement value
function modify_url_in_xml() {
  local xml_file="$1"
  local element_name="$2"
  local replacement_value="$3"

  # Fetch the URL inside the element
  local url=$(grep -oP "<$element_name>\K.*?(?=<\/$element_name>)" "$xml_file")

  # Replace the very last part of the URL with the provided value
  local new_url=$(echo "$url" | sed "s|/[^/]*$|/$replacement_value|")

  # Update the XML file with the modified URL
  sed -i "s|$url|$new_url|" "$xml_file"

  echo "Modified URL: $new_url"
}

if [[ $sdk_version == "6"* ]]; then
        sed -i "s#<PrivateSourceBuiltArtifactsPackageVersion>.*</PrivateSourceBuiltArtifactsPackageVersion>#<PrivateSourceBuiltArtifactsPackageVersion>$sdk_version</PrivateSourceBuiltArtifactsPackageVersion>#" $versions_props_path
elif [[ $sdk_version == "7"* ]]; then
        sed -i "s#<PrivateSourceBuiltArtifactsPackageVersion>.*</PrivateSourceBuiltArtifactsPackageVersion>#<PrivateSourceBuiltArtifactsPackageVersion>$sdk_version</PrivateSourceBuiltArtifactsPackageVersion>#" $versions_props_path
        sed -i "s#<PrivateSourceBuiltSDKVersion>.*</PrivateSourceBuiltSDKVersion>#<PrivateSourceBuiltSDKVersion>$sdk_version</PrivateSourceBuiltSDKVersion>#" $versions_props_path
elif [[ $sdk_version == "8"* ]]; then
        modify_url_in_xml "$versions_props_path" "PrivateSourceBuiltArtifactsUrl" "$resolved_source_built_artifacts_file_name"
        modify_url_in_xml "$versions_props_path" "PrivateSourceBuiltSdkUrl_CentOS8Stream" "$resolved_sdk_artifact_file_name"
else
        echo "Unexpected SDK version!"
        exit 1
fi

git add "$global_json_path" "$versions_props_path"

git config --global user.name "dotnet-sb-bot"
git config --global user.email "dotnet-sb-bot@microsoft.com"
git commit -m "update global.json and Versions.props for .NET SDK ${sdk_version}"

cat "$versions_props_path"
git diff

# push changes to fork
git push -u origin "${new_branch_name}"

readarray -d '/' -t fork_repo_split <<< "${fork_repo}"
fork_owner="${fork_repo_split[0]}"


# create pull request
# gh pr create \
#     --head "${fork_owner}:${new_branch_name}" \
#     --repo "${target_repo}" \
#     --base "${pr_target_branch}" \
#     --title "${title}" \
#     --body "${body}"
