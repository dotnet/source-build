# The source-build intermediate NuGet package

To transfer source-built prebuilts from one repo to the next, we need a
transport format. NuGet packages are a proven method to do so, including
built-in caching, secure restore and push supported by Arcade, and versioning.

## The monster package

We can't publish individual source-built NuGet packages (nupkgs) to the feed
directly. They would conflict with Microsoft-built packages with the same IDs
and versions. These packages also have a reasonable risk of accidentally being
used by devs not familiar with source-build, poisoning the NuGet caches on their
systems.

To address both of these, source-build should assemble a monster nupkg that
contains all the nupkgs and other artifacts produced by the build.

* `source-build.dotnet-runtime.linux-x64.5.0.0-alpha.1.12345.nupkg/`
  * `Microsoft.NETCore.App.Ref.5.0.0-alpha.1.12345.nupkg`
  * `Microsoft.NETCore.App.Runtime.linux-x64.5.0.0-alpha.1.12345.nupkg`
  * `dotnet-runtime-5.0.0-alpha.1.12345-linux-x64.tar.gz`
  * ...

The version number here is the same as the official build's version number. This
makes the official build produce consistent artifacts and prevents overlap in
the same way it's prevented in existing official builds. The nupkg should always
have an unstable version because it's a transport package, helping to avoid
complicated feed management allowing mutation for stabilized rebuilds.

Official builds publish the monster nupkg, and downstream repos restore the
monster nupkg then use the contents. Note that if an official build fails to
produce its Microsoft build outputs *or* the source-build monster nupkg, it must
fail altogether. This ensures downstream repos have uninterrupted access to the
source-built intermediates.

## Too large?

If the artifacts are too large for our NuGet feeds to handle, we can:

1. Split the monster nupkg along some logical line, and produce multiple for a
   single repo.
2. Split some artifacts to a tarball that is published to an auxiliary feed.
   * Extra infra development necessary: secure transport of this tarball,
     implementing caching, etc.
   * Not recommended.

## Addressability with different build args?

With a generic build cache, it's typically important for the build inputs to be
captured and incorporated in how the cache is addressed later. The build and its
artifacts must be deterministic, or else the distro maintainer ends up with
something different and we've failed to do useful validation.

However, the source-build intermediate packages are not a generic build cache. A
given official build version number is *never* built twice by Microsoft, let
alone with unpredictably varying arguments. That immutability is automatically
shared by the source-build official build.
