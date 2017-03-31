#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

git submodule foreach --recursive git clean -dxf
git submodule foreach --recursive git reset --hard

