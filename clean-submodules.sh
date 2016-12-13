#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

git submodule foreach git clean -dxf
git submodule foreach git reset --hard

