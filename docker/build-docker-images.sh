#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'
SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"

if [ -z "${1:-}" ]; then
    echo "usage: $0 <image-base-name>"
    exit 1
fi

IMAGE_NAME=$1
IMAGE_TIMESTAMP=$(date +%Y%m%d%H%M%S)

for DIR in $SCRIPT_ROOT/*; do
    if [ -d $DIR ]; then
        (set -x ; docker build -t "$IMAGE_NAME:$(basename $DIR).$IMAGE_TIMESTAMP" $DIR)
    fi
done
