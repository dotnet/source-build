#!/bin/bash

### Creates a release announcement in a form of a GitHub discussion in the target repository
###
### Options:
###   --announcement-org <ORG>   The GitHub organization of the target repository
###   --announcement-repo <REPO> Target GitHub repository to create the announcement in
###   --announcement-gist <URL>  URL of a GitHub gist to take the announcement content from
###   --channel <CHANNEL>        Release channel, e.g. 8.0
###   --release <NAME>           Programmatic name of the release, e.g. 8.0.0.preview-1
###   --release-name <NAME>      Human readable name of the release, e.g. .NET 8 Preview 1
###   --sdk-version <VER>        The .NET SDK version that is being released
###   --runtime-version <VER>    The .NET runtime version that is being released
###   --tag <TAG>                The release tag, e.g. v8.0.0-preview.1
###   --dry-run                  (Optional) Runs a script in a dry-run mode that prints out the announcement only
###   --prerelease               (Optional) Whether this is a preview release
###   --help, -h                 (Optional) Print this help message and exit

set -euo pipefail
source="${BASH_SOURCE[0]}"

function print_help () {
  sed -n '/^### /,/^$/p' "$source" | cut -b 5-
}

announcement_org=''
announcement_repo=''
announcement_gist=''
channel=''
release=''
release_name=''
sdk_version=''
runtime_version=''
tag=''
prerelease=false
dry_run=false

while [[ $# -gt 0 ]]; do
  opt="$(echo "$1" | tr "[:upper:]" "[:lower:]")"
  case "$opt" in
    -h | --help )
      print_help
      exit 0
      ;;
    --announcement-org )
      announcement_org="$2"
      shift 2
      ;;
    --announcement-repo )
      announcement_repo="$2"
      shift 2
      ;;
    --announcement-gist )
      announcement_gist="$2"
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
    --dry-run )
      dry_run=true
      shift 1
      ;;
    *)
      echo "Invalid argument $1"
      exit 1
      ;;
  esac
done

: "${announcement_org:?Missing --announcement-org}"
: "${announcement_repo:?Missing --announcement-repo}"
: "${channel:?Missing --channel}"
: "${release:?Missing --release}"
: "${release_name:?Missing --release-name}"
: "${sdk_version:?Missing --sdk-version}"
: "${runtime_version:?Missing --runtime-version}"
: "${tag:?Missing --tag}"

repo_query="query {
  repository(
    owner: \"$announcement_org\"
    name: \"$announcement_repo\"
  ) {
    id
  }
}"

repo_id=$(gh api graphql -f query="$repo_query" --template '{{.data.repository.id}}')
echo "$announcement_org/$announcement_repo repo ID is $repo_id"

categories_query="{
  repository(name: \"$announcement_repo\", owner: \"$announcement_org\") {
    discussionCategories(first: 10) {
      edges {
        node {
          id
          name
        }
      }
    }
  }
}"

category_id=$(gh api graphql -f query="$categories_query" --template '{{range .data.repository.discussionCategories.edges}}{{if eq .node.name "Announcements"}}{{.node.id}}{{end}}{{end}}' )

echo "Discussion category ID is $category_id"

if [[ -z "$announcement_gist" ]]; then
  echo "Loading announcement template from source-build-release-announcement.md"

  prerelease_arg=''
  if [ "$prerelease" = true ]; then
    prerelease_arg='--prerelease'
  fi

  announcement=$("./create-announcement-draft.sh"     \
    --template "source-build-release-announcement.md" \
    --channel "$channel"                              \
    $prerelease_arg                                   \
    --release "$release"                              \
    --release-name "$release_name"                    \
    --runtime-version "$runtime_version"              \
    --sdk-version "$sdk_version"                      \
    --tag "$tag")

  # Get the line in the template that is prefixed with "Title:" and remove the prefix
  title=$(echo "$announcement" | grep "^Title:" | cut -d " " -f2-)
  # Get the inverse of the above selection
  body=$(echo "$announcement" | grep -v "^Title:")

else
  echo "Loading announcement template from gist $announcement_gist"

  # Get title from the gist name
  set +o pipefail # gh fails with 141 but returns the correct output

  title="$(gh gist view "$announcement_gist" --raw | head -n 1)"
  body="$(gh gist view "$announcement_gist" | tail -n +2)"

  if [[ -z "$title" ]]; then
    echo "##vso[task.logissue type=error]Could not get title from gist $announcement_gist"
    exit 1
  fi

  if [[ -z "$body" ]]; then
    echo "##vso[task.logissue type=error]Could not get announcement text from gist $announcement_gist"
    exit 1
  fi

  set -o pipefail
fi

if [ "$dry_run" = true ]; then
  set +x
  echo -e "\n\n\n#########################\n\n"
  echo "Doing a dry run, not submitting announcement."
  echo -e "\n\n#########################\n\n\n"
  echo "Announcement title: $title"
  echo "Announcement body: $body"
else
  # Checking for an already existing announcement
  recent_discussions_query="query {
    repository(
      name: \"$announcement_repo\"
      owner: \"$announcement_org\"
    ) {
      discussions(
        last: 100
        categoryId: \"$category_id\"
        orderBy: { field: UPDATED_AT, direction: DESC }
      ) {
        edges {
          node {
            title
            url
          }
        }
      }
    }
  }"

  recent_discussions=$(gh api graphql -f query="$recent_discussions_query")
  duplicate_discussions=$(echo "$recent_discussions" | jq -r '.data.repository.discussions.edges[] | select(.node.title == "'"$title"'") | .node')

  if [[ -z "$duplicate_discussions" || "$duplicate_discussions" == "null" ]]; then
      create_discussion_query='
        mutation ($repo_id: ID!, $category_id: ID!, $body: String!, $title: String!) {
            createDiscussion(
              input: {
                repositoryId: $repo_id
                categoryId: $category_id
                body: $body
                title: $title
              }
            ) {
              discussion {
                url
              }
            }
        }'

      echo "Submitting announcement"

      create_discussion_url=$(gh api graphql \
          -F repo_id="$repo_id" \
          -F category_id="$category_id" \
          -F body="$body" \
          -F title="$title" \
          -f query="$create_discussion_query" \
          --template '{{.data.createDiscussion.discussion.url}}' )

      echo "Announcement URL: $create_discussion_url"
  else
      duplicate_discussion_url=$(echo "$duplicate_discussions" | jq -r '.url')
      echo "##vso[task.logissue type=warning]Announcement already exists ($duplicate_discussion_url). Skipping submission"
  fi
fi
