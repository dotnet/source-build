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
complicated feed management allowing for stabilized rebuilds.

Official builds publish the monster nupkg, and downstream repos restore the
monster nupkg then use the contents. Note that an official build must produce
its Microsoft build outputs *and* the source-build monster nupkg, or it fails.
This ensures downstream repos have access to the source-built intermediates.

## Too large?

If the artifacts are too large for our NuGet feeds to handle, we can:

1. Split the monster nupkg along some logical line, and produce multiple for a
   single repo.
2. Split some artifacts to a tarball that is published to an auxiliary feed.
   * Extra infra development necessary: secure transport of this tarball,
     implementing caching, etc.
   * Not recommended.
