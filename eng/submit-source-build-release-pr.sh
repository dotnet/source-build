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
   echo "--setupGitAuth, -G    (Optional) set up git authentication using the gh CLI"
   echo "--help, -h            (Optional) print this help message and exit"
   echo
}

SHORT=t:f:v:T:B:b:g:p:Gh
LONG=targetRepo:,forkRepo:,sdkVersion:,title:,body:,targetBranch:,globalJson:,versionsProps:,setupGitAuth,help

OPTS=$(getopt --options $SHORT --long $LONG --name "$0" -- "$@")
if [ $? != 0 ] ; then echo "Failed to parse options." >&2 ; exit 1 ; fi
eval set -- "$OPTS"

global_json_path='src/SourceBuild/content/global.json'
versions_props_path='src/SourceBuild/content/eng/Versions.props'
custom_target_branch=''
setup_git_auth=''

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
    | tee "$global_json_path"
sed -i "s#<PrivateSourceBuiltArtifactsPackageVersion>.*</PrivateSourceBuiltArtifactsPackageVersion>#<PrivateSourceBuiltArtifactsPackageVersion>$sdk_version</PrivateSourceBuiltArtifactsPackageVersion>#" $versions_props_path
git add "$global_json_path" "$versions_props_path"

git config --global user.name "dotnet-sb-bot"
git config --global user.email "dotnet-sb-bot@microsoft.com"
git commit -m "update global.json and Versions.props for .NET SDK ${sdk_version}"

# push changes to fork
git push -u origin "${new_branch_name}"

readarray -d '/' -t fork_repo_split <<< "${fork_repo}"
fork_owner="${fork_repo_split[0]}"

# create pull request
gh pr create \
    --head "${fork_owner}:${new_branch_name}" \
    --repo "${target_repo}" \
    --base "${pr_target_branch}" \
    --title "${title}" \
    --body "${body}"
