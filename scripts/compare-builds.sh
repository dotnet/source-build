#!/bin/bash

# Tests to compare 2 SDK builds - generally a Microsoft-built SDK and
# a source-build SDK. This should help us find issues/surprises before
# we ship out a source-built SDK.
#
# See --help for more details, including usage

set -euo pipefail
IFS=$'\n\t'

# Filter out some directories that are special and source-build only:
# - reference-packages/
# - source-built-artifacts/
paths_to_ignore_regex='\.\/reference-packages|\./source-built-artifacts'

function usage() {
    echo ""
    echo "usage: $0 SDK1_TARBALL SDK2_TARBALL"
    echo ""
    echo "Compare 2 SDK builds to spot differences and potential regressions or other bugs."
}

function print_sdk_contents() {
    sdk=$1
    if [ -d "$sdk" ]; then
        pushd "$sdk" >/dev/null
        # We use two find invocation so we can add a / to the directories to match the file listing from tar
        (find . -type d -print | sed -e 's|$|/|'; find . '!' -type d -print) \
            | sort -u \
            | grep -v -E "$paths_to_ignore_regex"
        popd >/dev/null
    else
        if [[ "$sdk" =~ .*tar\.gz ]]; then
            tar tf "$sdk" | sort -u | grep -v -E "$paths_to_ignore_regex"
        else
            echo "error: Unknown file type ${sdk}"
            exit 1
        fi
    fi
}

function cleanup() {
    if [ -d "$workdir" ]; then
        rm -rf "$workdir"
    fi
}

positional_args=()
while :; do
    if [ $# -le 0 ]; then
        break
    fi
    lowerI="$(echo "$1" | awk '{print tolower($0)}')"
    case $lowerI in
        "-?"|-h|--help)
            usage
            exit 0
            ;;
        *)
            positional_args+=("$1")
            ;;
    esac

    shift
done

sdk1=${positional_args[0]:-}
if [[ -z ${sdk1} ]]; then
    echo "error: missing argument."
    usage
    exit 1
fi
sdk1=$(readlink -f "$sdk1")

sdk2=${positional_args[1]:-}
if [[ -z ${sdk2} ]]; then
    echo "error: missing argument."
    usage
    exit 1
fi
sdk2=$(readlink -f "$sdk2")

workdir=$(mktemp -d)
file1="${workdir}/sdk-at-$(echo "$sdk1" | sed -e 's|/|-|g')"
file2="${workdir}/sdk-at-$(echo "$sdk2" | sed -e 's|/|-|g')"

print_sdk_contents "$sdk1" > "$file1"
print_sdk_contents "$sdk2" > "$file2"

echo "--- $sdk1"
echo "+++ $sdk2"

trap cleanup EXIT

# The files noare not part of any repository. We could use plain `diff` here,
# but it's not available on some platforms.
git diff --no-index "$file1" "$file2" | tail -n +3
