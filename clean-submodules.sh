#!/bin/bash
set -euo pipefail
IFS=$'\n\t'
SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"

git submodule foreach --recursive git clean -dxf
git submodule foreach --recursive git reset --hard

git clean -dxf "$SCRIPT_ROOT/src/javascriptservices/"
git clean -dxf "$SCRIPT_ROOT/src/netcorecli-fsc/"
git clean -dxf "$SCRIPT_ROOT/src/reference-assemblies/"
