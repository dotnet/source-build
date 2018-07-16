#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

getIndexedSubmoduleSha() {
    (
        cd "$DIR"
        git ls-tree HEAD src/cli | awk '{print $3}'
    )
}

SOURCE="${BASH_SOURCE[0]}"
while [ -h "$SOURCE" ]; do # resolve $SOURCE until the file is no longer a symlink
  DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"
  SOURCE="$(readlink "$SOURCE")"
  [[ $SOURCE != /* ]] && SOURCE="$DIR/$SOURCE" # if $SOURCE was a relative symlink, we need to resolve it relative to the path where the symlink file was located
done
DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"

BASE_SHA=${1:-$(getIndexedSubmoduleSha)}
REPO_NAME=$(basename $(pwd))
PATCHES_DIR=$DIR/patches/$REPO_NAME

if [ ! -d $PATCHES_DIR ]; then
    mkdir -p $PATCHES_DIR
fi

$(rm $PATCHES_DIR/*.patch || true)

git format-patch -N -o $PATCHES_DIR $BASE_SHA

git reset --hard $BASE_SHA
