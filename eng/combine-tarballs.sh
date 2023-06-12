#!/bin/bash

### Usage: combine-tarballs.sh [OPTIONS] [file1] [file2] ... [fileN]
###
### Combines the contents of multiple tarballs into a single tarball.
###
### Options:
###   --output <FILE>  The destination path of the output tarball
###   --help, -h       (Optional) Print this help message and exit

set -euo pipefail
source="${BASH_SOURCE[0]}"

function print_help () {
  sed -n '/^### /,/^$/p' "$source" | cut -b 5-
}

outputPath=''

if [[ $# -gt 0 ]]; then
  opt="$(echo "$1" | tr "[:upper:]" "[:lower:]")"
  case "$opt" in
    -h | --help )
      print_help
      exit 0
      ;;
    --output )
      outputPath="$2"
      shift 2
      ;;
    *)
    ;;
  esac
else
  print_help
  exit 0
fi

: "${outputPath:?Missing --output}"

tmpDir=$(mktemp -d)

# The rest of the args are the paths to the input tarball
for arg in "$@"
do
  echo "Extracting '${arg}' to '${tmpDir}'"
  tar -xf "${arg}" -C $tmpDir
done

echo "Generating tarball '${outputPath}' from '${tmpDir}'"
tar -cf "${outputPath}" -C $tmpDir .

rm -rf $tmpDir
