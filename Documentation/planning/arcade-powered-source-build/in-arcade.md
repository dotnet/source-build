# Source-build as a part of the Arcade build

Source-build does a lot of stuff. A sampler:

1. Clones the upstream repos to form a layout.
1. Sets up package cache and source-built intermediate output directories.
1. Orchestrates build order.
1. Provides a number of source-build-specific args to build commands.
1. Runs extra targets before and after each build to fill in missing
   source-build compatibility, if necessary.
1. Builds tarballs--`.tar.gz` file containing everything necessary to build a
   specific version of the SDK from source without prebuilts.
1. Maintains scripts specific to the tarballs to enable scenario like
   bootstrapping.
1. Track prebuilt usage to ensure repos don't pull in dependencies not built
   from source.
1. Automatically decompile and recompile certain dependencies used as prebuilts
   so that they can be maintained as source code even if we don't have the
   original source code.

The main doc discusses why this needs to be done in Arcade. We should also aim
at all of this being doable via a single `./build.sh [...]` command. This allows
source-build to be easily reproducible with a local build, something the project
has been sorely missing and bars all but the most committed and awesome
contributors.

## Additions to the `build.sh` procedure

It seems that source-build can fit into the existing Arcade extension points.

### Tool Restore

This point is normally used to restore tooling that may impact the ordinary
restore by adding MSBuild targets. Source-build can add a step to get
source-build dependencies, with several options:

1. Use transport package. Restores the [intermediate nupkg] and sets it up as a
   restore source.
2. Bring-your-own dependencies. A set of args allow the user (or automation) to
   point to existing intermediates on disk.
3. Build dependencies from source. Instead of downloading intermediates, clone
   the repos and build them all.

Any of those options allows the source-build of the current repo to continue
afterwards with source-built intermediates. Then, source-build sets up
RestoreSources, a Package Version Props, a blob root, and any repo-specific
special requirements.

At this point in the build, we should also have all we need to create a
source-buildable tarball. We should aim to allow the user to create it as early
as possible and cancel the rest of the build, as they may be a distro maintainer
who doesn't actually want to build the repo right now. Unfortunately, there are
some known issues blocking us from creating a source-buildable tarball without
building the product first, tracked by
[source-build#831](https://github.com/dotnet/source-build/issues/831). Until we
find solutions, tarball creation must be done in Publish instead.

### Restore

We need to be careful that no machine-wide caches are used here. Caching a
source-built nupkg may cause unexpected and incredibly hard to detect errors
later on.

### Build/Pack

The slew of source-build args normally passed to the build command should be
moved to Arcade as much as possible. Many of these apply to the Build and Pack
parts of the build process.

### Publish

This seems like a reasonable place to put [intermediate nupkg] creation. Not all
repos use this target so care is needed to make sure this doesn't crash.

Creating an intermediate nupkg involves gathering together all shipped artifacts
(nupkgs and tarballs) into a nupkg. The nupkg the needs to be uploaded to the
build pipeline along with a manifest to indicate to Arcade how to publish it.

We should also ensure here that no prebuilts were used. This is a validation
step, however it's essential for source-build health, and quick to check. The
reason to do this during Publish is that there is no Test phase during a
source-build and we don't know for sure whether any extra prebuilts were
restored until the entire build completes. (It's not guaranteed that all
downloading happens during the Arcade SDK's Restore phase.)

## Supporting a source-built SDK

For bootstrap and N-1 flows, we need to use an SDK from disk. For example, an
SDK that's restored from an [intermediate nupkg]. The problem is that by the
time we've restored the intermediate nupkg, we're already inside processes using
a prebuilt SDK, so we need to launch a new build. A few alternative ways how to
do this (best first):

1. Reclone the current repo somewhere in `artifacts/`, then run `build.sh` with
   extra parameters pointing to the restored SDK.
   * This seems like a complex way to do it, however it ensures a clean repo and
     keeps the logic inside MSBuild code.
   * We already need to be able to clone upstreams in `artifacts` for the "build
     dependencies from source" option. This can leverage that infrastructure.
     The `darc clone` command provided by Arcade should fulfill this role.
   * It may not be necessary to create a fresh clone: this can be investigated
     as a perf optimization.
2. Have the user first call `./build.sh [...]` with some args that bring down
   the new SDK. Then the user calls a second command to use that SDK.
   * Not bad in official builds. However, harder to reproduce locally.
   * We could have an additional script to automate the two calls. This is
     better. We may still need to worry about cleanup logic between the first
     and second call. It is still a departure from the norm of just calling
     build.sh once.
3. Add functionality to `/eng/common/tool.sh` directly to support intermediate
   nupkgs before entering any SDK code.
   * Reinvents a lot of NuGet caching/download/restore logic.
   * Needs to be implemented in tool.sh and tool.ps1 for parity.

## Special per-repo handling

Some repos may have some infra in source-build that is incompatible with arcade.
Any functionality like this should be added to `eng/*.targets` and `eng/*.props`
files.

## Non-Microsoft-maintained repositories

Repos not maintained by Microsoft or the .NET Foundation likely don't use the
Arcade toolset. The simple approach is to fork the repo and add the Arcade
wrapper to allow it to seamlessly take part in the .NET Core SDK source-build.

A "soft" way to fork is to maintain a repo with a single submodule pointing to
the non-Microsoft repo. This wraps it without forking the original repo's
history. The intent would be very clear. However, it would be more difficult to
maintain patches, if any are necessary to add Arcade.


[intermediate nupkg]: intermediate-nupkg.md