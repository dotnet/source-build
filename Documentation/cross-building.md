# Cross-Building

Cross-building is the process of building .NET for a target platform on a
different host platform. For example, building for `linux-x64` on a host that
uses the `azurelinux-3.0-net10.0-cross-amd64` container image with a
dedicated sysroot.

## When is Cross-Building Required?

Cross-building is required when:

- The build environment uses a cross-build container image (e.g.
  `mcr.microsoft.com/dotnet-buildtools/prereqs:azurelinux-3.0-net10.0-cross-amd64`)
  that provides a sysroot via the `ROOTFS_DIR` environment variable, even when
  building for the same architecture as the host (e.g. `linux-x64`).

## Enabling Cross-Building

When building in a cross-build container with `ROOTFS_DIR` set, you must pass
`/p:CrossBuild=true` to the build command. Without this flag, the runtime build
will not use the sysroot when searching for native dependencies such as OpenSSL,
causing the build to fail.

## Example

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

> **Note:** `/p:CrossBuild=true` is only required when using a cross-build
> container with `ROOTFS_DIR` set. It is not needed when building natively on
> the target platform.
