# Leak detection (poisoning)

## Overview

Source-build includes a mechanism for *poisoning* its input files, and then for checking for that poison in the build output.  This allows us to ensure that all output files were built during the build rather than copied directly from the input, which would be an illegal prebuilt usage.

## Before the build

Before the build, the MarkAndCatalogFiles task runs.  This does a few things:

- Record the hash of every file in the source-build binary input directories (prebuilts and previously-source-built, in the future [reference-packages](https://github.com/dotnet/source-build/issues/2817)).  If the file is a zip, tarball, or nupkg, unpack it and do the same thing recursively.
- For managed DLLs, either bare or in an archive, add a custom attribute that marks the file as poisoned.
- For nupkgs, drop a `.poisoned` file.
- Repack the poisoned assemblies and extra files, removing nupkg signatures so they don't fail verification.
- Replace the binary inputs with these new packages and archives.
- Record the hash of each file again, to make sure we will be able to track output files whether they were used poisoned or unpoisoned.

## During the build

There's no change in source-build operation in poisoning mode during the build.

## After the build

After the build, the CheckForPoison task is run on the source-build output directory.  It again unpacks any archives and packages recursively, and checks for all three kinds of markers injected before the build.  It then writes out a [report](poison-report-format.md) that details everything that was found.