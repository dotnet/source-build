# How to run a stage 2 build

This document describes how to perform a stage 2 source build.

## What is a stage 2 build

A **stage 2 build** is when you run a source build, then take the SDK and packages produced by that build and use them to rebuild the product. 
Stage 2 builds are essential for validating a source‑built product.

It’s common for stage 2 builds to surface issues.
For example, if a new Roslyn analyzer is included in the SDK, it can introduce new build errors during the stage 2 build.
These issues must be resolved for the product to be considered **source‑buildable**.

The process of using built SDK and artifacts to rebuild the product is often called **bootstrapping**.
Distribution maintainers use it to initiate the build process: build once using the Microsoft SDK and artifacts, then rebuild using the resulting SDK and artifacts.


## Steps to run a stage 2 build

1. Run a stage 1 build

    ```bash
    git clone https://github.com/dotnet/dotnet.git dotnet1
    pushd dotnet1
    ./prep-source-build.sh
    ./build.sh -sb
    popd
    ```

2. Run a stage 2 build

    ``` bash
    mkdir -p stage1/sdk stage1/packages

    tar -xf dotnet1/artifacts/assets/Release/Private.SourceBuilt.Artifacts.*.tar.gz -C stage1/packages

    tar -xf dotnet1/artifacts/assets/Release/Sdk/*/dotnet-sdk-*.tar.gz -C stage1/sdk

    git clone https://github.com/dotnet/dotnet.git dotnet2
    pushd dotnet2
    ./build.sh -sb --with-packages stage1/packages --with-sdk stage1/sdk
    popd
    ```

    > **Note:** `prep-source-build.sh` is optional for stage 2. It is only needed if you want to remove checked‑in binaries before building.
