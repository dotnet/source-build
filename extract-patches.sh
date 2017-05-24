#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

SOURCE="${BASH_SOURCE[0]}"
while [ -h "$SOURCE" ]; do # resolve $SOURCE until the file is no longer a symlink
  DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"
  SOURCE="$(readlink "$SOURCE")"
  [[ $SOURCE != /* ]] && SOURCE="$DIR/$SOURCE" # if $SOURCE was a relative symlink, we need to resolve it relative to the path where the symlink file was located
done
DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"

BASE_SHA=$1
REPO_NAME=$(basename $(pwd))
PATCHES_DIR=$DIR/patches/$REPO_NAME

if [ ! -d $PATCHES_DIR ]; then
    mkdir -p $PATCHES_DIR
fi

$(rm $PATCHES_DIR/*.patch || true)

git format-patch -o $PATCHES_DIR $BASE_SHA

git reset --hard $BASE_SHA
