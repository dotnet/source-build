# How to re-bootstrap the toolset used to build the VMR

.NET utilizes itself to build therefore in order to build .NET from source, you
first need to acquire or build a bootstrapping .NET SDK and other tooling such
as arcade. Re-bootstrapping is the term used to describe when the bootstrapped
toolset need to be updated. This document describes the steps to re-bootstrap
the VMR.

# When is it appropriate to re-bootstrap?

As part of the release process, the toolset is updated (e.g. PRs are created via
the release automation). Outside of a release, re-bootstrapping is only permitted
during preview releases. It is not allowed during RC, GA, or servicing releases.
The reason it is not allowed during non-preview releases is because of the negative
impact it has on Linux distro maintainers who source build .NET. It is often a long
and time consuming process for them to re-bootstrap. It is likely to cause
significant delays in the release/availability of .NET within the distros that are
source built.

# Why is re-bootstrap necessary?

Re-bootstrapping is necessary when .NET takes a dependency on new functionality
added within the bootstrap toolset. For example suppose a new compiler feature is
added. In order for a repo to take a dependency on the new feature, a re-bootstrap
would be necessary.

# Steps to re-bootstrap

1. Update previous source-build artifacts
    1. Find a [dotnet-source-build](https://dev.azure.com/dnceng/internal/_build?definitionId=1219)
    with the desired changes.
    1. Retrieve the built SDKs from the following legs:
        1. Alpine\<nnn\>_Online_MsftSdk_x64
        1. CentOSStream\<8\>_Online_MsftSdk_x64
    1. Upload the SDKs to https://dotnetcli.blob.core.windows.net/source-built-artifacts/sdks/
1. Update .NET SDK
    1. Find the [dotnet-installer-official-ci](https://dev.azure.com/dnceng/internal/_build?definitionId=286)
    build that best matches the dotnet-source-build. The following is the suggested
    order of precedence for finding the best match.
        1. A build from the same commit. From a VMR commit, you can find the
        corresponding installer commit by looking at the [source-manifest.json](https://github.com/dotnet/dotnet/blob/main/src/source-manifest.json).
        1. The next passing build after the same commit.
        1. In the odd case where the are no passing builds after the commit, you
        can try using an earlier passing build.
    1. Retrieve the built SDK version from the build.
    1. Update the dotnet version in the [global.json](https://github.com/dotnet/dotnet/blob/main/global.json).
1. Update arcade
    1. Lookup the arcade commit and version. From a VMR commit, you can find the
    corresponding arcade commit/version by looking at the [source-manifest.json](https://github.com/dotnet/dotnet/blob/main/src/source-manifest.json).
    1. Update the arcade SDK version in the [global.json](https://github.com/dotnet/dotnet/blob/main/global.json).
    1. Update the arcade dependency commit and version in the [Version.Details.xml](https://github.com/dotnet/dotnet/blob/main/eng/Version.Details.xml).

[Tracking issue for automating this process.](https://github.com/dotnet/source-build/issues/4246)
