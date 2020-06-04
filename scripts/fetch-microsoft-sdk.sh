#!/bin/bash

# Download a .NET Core SDK published by Microsoft.
#
# See --help for more details, including usage

set -euo pipefail
IFS=$'\n\t'

function usage() {
    echo ""
    echo "usage: $0 SDK_VERSION [output-location]"
    echo ""
    echo "Download a particular .NET Core SDK built by Microsoft based on exact version match."
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

sdk_version=${positional_args[0]:-}
if [[ -z ${sdk_version} ]]; then
    echo "error: missing argument."
    usage
    exit 1
fi

output_location=${positional_args[1]:-dotnet-microsoft-built-sdk-${sdk_version}.tar.gz}

install_script_url=https://dot.net/v1/dotnet-install.sh
install_script_dir=$(mktemp -d)
install_script=${install_script_dir}/dotnet-install.sh

# Use curl if available, otherwise use wget
if command -v curl > /dev/null; then
    curl "${install_script_url}" -sSL --retry 10 --create-dirs -o "${install_script}"
else
    wget -q -O "${install_script}" "${install_script_url}"
fi

chmod +x "${install_script}"
url=$("${install_script_dir}/dotnet-install.sh" --dry-run --version "${sdk_version}" | grep https | sed -E 's|.*(https://.*tar.gz)$|\1|' | head -1)
echo "${url}"

# Use curl if available, otherwise use wget
if command -v curl > /dev/null; then
    curl "${url}" -sSL --retry 10 --create-dirs -o "${output_location}"
else
    wget -q -O "${output_location}" "${url}"
fi

rm "${install_script}"
rmdir "${install_script_dir}"
