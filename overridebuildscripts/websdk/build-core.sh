#!/bin/bash

set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(dirname "${BASH_SOURCE[0]}")"
[[ -z "$DOTNET_INSTALL_DIR" ]] && export DOTNET_INSTALL_DIR="$SCRIPT_ROOT/obj/tools/dotnet"

if [ ! -d $DOTNET_INSTALL_DIR ]; then
    curl -L https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0/scripts/obtain/dotnet-install.sh | bash -s -- --version 1.0.0 --install-dir "$DOTNET_INSTALL_DIR"
fi

export PATH=$DOTNET_INSTALL_DIR:$PATH

$SCRIPT_ROOT/tools/BuildCore.sh
