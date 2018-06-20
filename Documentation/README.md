# .NET Core Build Script Documentation

The following document includes documentation for the build scripts. Over time, this README is expected to just be a TOC as the instructions move into separate docs.

## Building the .NET Core SDK

The scripts are supported on Windows, macOS and Linux. The scripts are based on PowerShell on Windows and Bash on macOS and Linux.

### Syncing

This repo uses submodules so remember on fresh clones or when updating/switching branches to run

```
git submodule update --init --recursive
```

### Building

```console
./build.{cmd|sh}
```

## Building one repo

By default we build the cli and its dependencies but the default root repository to build can be passed in. For example, if you just want to build the .NET Core Runtime, you would just build the `core-setup` repo and its dependencies:

```console
./build.{cmd|sh} /p:RootRepo=core-setup
```

Sometimes you want to just iterate on a single repo build and not rebuild all dependencies that can be done passing another property.

```console
./build.{cmd|sh} /p:RootRepo=core-setup /p:SkipRepoReferences=true
```

### Cleaning

```console
./clean.{cmd|sh}      # Cleans root binary directory and fully git cleans and hard resets all submodules
./clean.{cmd|sh} -a   # Does a full git clean on the root repo as well as fully git cleans and hard resets all submodules
```

## Building .NET Core SDK and a Source tarball

You can build the .NET Core SDK and generate a source tarball in a specific directory. This script is bash-only and is intended to be run on Linux.

```console
./build-source-tarball.sh <path-to-tarball-root>
tar -czf <tarball-destination> --directory <path-to-tarball-root> "."
```

After this completes, you can take the output tarball to another machine and build .NET Core again without an internet connection.

```console
tar -xf <tarball-destination> -C <path-to-extraction-root>
cd <path-to-extraction-root>
./build.sh
```

`dummy pr`