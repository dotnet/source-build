# Cross-Building

Cross-building is the process of building .NET on a host machine for a target
OS and/or CPU architecture that differs from the host. For example, compiling
`linux-arm64` binaries on an `x64` host, or building for a specific Linux
distribution using a container image that provides a dedicated sysroot.

A sysroot is a self-contained root filesystem for the target platform. It
contains the headers, libraries, and other files needed to compile and link
code for that target. Cross-build container images provided by the .NET team
(see [dotnet-buildtools-prereqs-docker](https://github.com/dotnet/dotnet-buildtools-prereqs-docker))
typically place the sysroot at a well-known path and expose it via the
`ROOTFS_DIR` environment variable.

## When is Cross-Building Required?

Cross-building is required when any of the following are true:

- The **target CPU architecture** differs from the host (e.g. building
  `linux-arm64` on an `x64` machine).
- The **target OS or Linux distribution** requires a dedicated sysroot that is
  provided by a cross-build container image via the `ROOTFS_DIR` environment
  variable, even when the host and target share the same CPU architecture
  (e.g. building `linux-x64` inside an
  `azurelinux-3.0-net10.0-cross-amd64` container).

## Enabling Cross-Building

When `ROOTFS_DIR` is set, you must pass `/p:CrossBuild=true` to the build
command. Without this flag, the runtime build will not use the sysroot when
searching for native dependencies such as OpenSSL, causing the build to fail.

## Example: Building linux-x64 in a Cross-Build Container

```bash
docker run \
  --rm \
  --volume /path/to/dotnet:/dotnet \
  --workdir /dotnet \
  --env ROOTFS_DIR=/crossrootfs/x64 \
  mcr.microsoft.com/dotnet-buildtools/prereqs:azurelinux-3.0-net10.0-cross-amd64 \
  ./build.sh \
    --clean-while-building \
    --source-only \
    --arch x64 \
    --os linux \
    /p:CrossBuild=true
```

## Example: Building linux-arm64 on an x64 Host

```bash
docker run \
  --rm \
  --volume /path/to/dotnet:/dotnet \
  --workdir /dotnet \
  --env ROOTFS_DIR=/crossrootfs/arm64 \
  mcr.microsoft.com/dotnet-buildtools/prereqs:azurelinux-3.0-net10.0-cross-arm64 \
  ./build.sh \
    --clean-while-building \
    --source-only \
    --arch arm64 \
    --os linux \
    /p:CrossBuild=true
```

> **Note:** `/p:CrossBuild=true` is only required when `ROOTFS_DIR` is set.
> It is not needed when building natively on the target platform.
