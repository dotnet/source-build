#!/bin/bash
set -euo pipefail
IFS=$'\n\t'
SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"

remote_ref_name=${remote_ref_name:-vsts}

pat="${1:-}"

if [ -z "$pat" ]; then
    echo "usage: $0 <pat>"
    echo ""
    echo "The PAT should be a devdiv.visualstudio.com VSTS PAT."
    echo "Get one at https://devdiv.visualstudio.com/_details/security/tokens."
    echo ""
    exit 1
fi

get_vsts_url() {
    name=$1
    instance=${2:-devdiv.visualstudio.com}
    project=${3:-DevDiv}

    echo "https://usernameplaceholder:${pat}@${instance}/${project}/_git/${name}/"
}

fetch() {
    name=$1
    remote=$2

    pushd "$SCRIPT_ROOT/src/$name"
    git fetch "$remote" +refs/heads/*:refs/remotes/${remote_ref_name}/*
    popd

}

fetch_vsts() {
    name=$1
    url=${2:-$(get_vsts_url "DotNet-$name-Trusted")}

    fetch "$name" "$url"
}

set -x

fetch_vsts cli
fetch_vsts core-setup
fetch_vsts coreclr
fetch_vsts corefx
