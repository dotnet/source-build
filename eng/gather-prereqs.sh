#!/bin/bash

# This script is used to combine x64 and arm64 tarballs of smoke test prereqs
#   so the same tarball can be used on either architecture.
# Use this in a directory with:
# * x64 prereqs
# * arm64 prereqs
# * any extra *.nupkgs that you want to add

set -euxo pipefail

mkdir x64
mkdir arm64

tar -xzf *smoke*x64*.tar.gz -C x64/
tar -xzf *smoke*arm64*.tar.gz -C arm64/

# copy necessary arm64 packages
cp arm64/*linux-arm64* x64/

# copy extra packages
cp *.nupkg x64/

# create final prereqs tarball
pushd x64
    tar -czf ../dotnet-smoke-test-prereqs.tar.gz .
popd

# cleanup
rm -rf x64/
rm -rf arm64/
