# Cross-Building

Cross-building is the process of building .NET on a host machine for a target
OS and/or CPU architecture that differs from the host. .NET supports many
cross-build scenarios across different platforms — for example, building
`windows-arm64` on a `windows-x64` host, `browser-wasm` on Linux or Windows,
`android-arm64` on Linux, or `osx-arm64` on `osx-x64`. Each scenario has its
own toolchain requirements.

## ROOTFS_DIR-Based Cross-Builds

For certain Linux and Unix targets (e.g. `linux-arm64`, `freebsd-x64`, `haiku-x64`),
.NET uses a **sysroot** — a self-contained root filesystem for the target platform
that contains the headers and libraries needed to compile and link code for that
target. The path to the sysroot is provided via the `ROOTFS_DIR` environment
variable.

Cross-build container images provided by the .NET team
(see [dotnet-buildtools-prereqs-docker](https://github.com/dotnet/dotnet-buildtools-prereqs-docker))
include a pre-configured sysroot and set `ROOTFS_DIR` to its location.

For these ROOTFS_DIR-based cross builds, `/p:CrossBuild=true` is part of the build model. It is
**automatically inferred** when the host and target OS/architecture differ (e.g. building
`linux-arm64` or `freebsd-x64` on a `linux-x64` host), but must be provided explicitly
when they are the same and a foreign sysroot is used.

## Supported Cross-Build Scenarios

The following table summarizes common .NET cross-build scenarios and whether they
use a `ROOTFS_DIR`-based approach and whether `CrossBuild=true` needs to be
explicitly provided:

| Host → Target | ROOTFS_DIR-based? | CrossBuild inferred automatically? |
|---|---|---|
| linux-x64 → android-arm64 | No | N/A |
| linux-x64 → browser-wasm | No | N/A |
| windows-x64 → browser-wasm | No | N/A |
| windows-x64 → windows-arm64 | No | N/A |
| osx-x64 → osx-arm64 | No | N/A |
| osx-arm64 → osx-x64 | No | N/A |
| osx-arm64 → ios-arm64 | No | N/A |
| osx-arm64 → tvos-arm64 | No | N/A |
| android-x64 → android-arm64 | No | N/A |
| linux-x64 → freebsd-x64 | Yes | Yes |
| linux-x64 → freebsd-arm64 | Yes | Yes |
| linux-x64 → linux-arm64 | Yes | Yes |
| linux-x64 → haiku-x64 | Yes | Yes |
| linux-arm64 → haiku-arm64 | Yes | Yes |
| linux-x64 → linux-x64 (foreign ROOTFS) | Yes | **No** |
| linux-arm64 → linux-arm64 (foreign ROOTFS) | Yes | **No** |

## Explicitly Providing `/p:CrossBuild=true`

The only case where `/p:CrossBuild=true` must be explicitly passed is when the
host and target OS/architecture are the **same**, but you are still performing a
ROOTFS_DIR-based build using a foreign sysroot. This happens when using a
cross-build container image to target a specific Linux distribution with a
dedicated sysroot (e.g. building `linux-x64` inside an
`azurelinux-3.0-net10.0-cross-amd64` container with `ROOTFS_DIR=/crossrootfs/x64`).

Without `/p:CrossBuild=true` in this scenario, the build will not use the sysroot
when searching for native dependencies such as OpenSSL and will fail.

### Example

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
