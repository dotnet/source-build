# .NET Core Build Script Documentation

The following document includes documentation for the build scripts. Over time, this README is expected to just be a TOC as the instructions move into separate docs.

## Building the .NET Core SDK

The scripts are supported on Windows, macOS and Linux. The scripts are based on PowerShell on Windows and Bash on macOS and Linux.

### Build on Windows

```console
./build.ps1
```

### Build on Linux or macOS

```console
./build.sh
```

## Building .NET Core SDK and a Source tarball

You can build the .NET Core SDK and generate a source tarball in a specific directory. This script is bash-only and is intended to be run on Linux.

```console
./build-source-tarball.sh <path-to-tarball-root>
```
