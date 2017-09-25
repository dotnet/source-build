# Automatic dependency contracts

This doc describes formats used by the orchestrator to implement automatic dependency flow.

One contract, "package version props", is directly used in builds driven by the orchestrator.

The others, "build output manifest", "build dependency manifest", "repo output manifest", and "repo dependency manifest", may be useful for product build improvements or isolated build dependency flow.

## Terms:
*Automatic dependency flow contracts*: information contracts for dependencies and results. These are manifests containing metadata, not binaries. The contracts are:

 1. [*Package version props*](#package-version-props): an MSBuild file listing the latest version of each package the build has produced using MSBuild-friendly property names.
    * Passed to repo builds to specify which package versions they should depend on.
 1. [*Restore source props*](#restore-source-props): an MSBuild file defining a single property `DotNetRestoreSources`.
 1. [*Build output manifest*](#build-output-manifest): the outputs of a build.
 1. [*Build input manifest*](#build-input-manifest): the inputs to a build.
 1. [*Repo output manifest*](#repo-output-manifest) (*not yet specified*): the outputs this repo would produce if built.
    * This is similar to the Repo API "Produces" contract that has been proposed before.
    * If a repo implements this contract, the repo *must* supply a repo output manifest without building first.
    * Output versions are not required, only identities. Many repos don't know versions until compile-time.
 1. [*Repo input manifest*](#repo-input-manifest) (*not yet specified*): the inputs this repo may take when built.
    * Current focus is on package identities, which are used to discover repo dependencies and assemble the repo build graph.
    * Not specific to a certain build, so it doesn't include version numbers.

See also: [README.md#terms](README.md#terms)


# Package version props

This format allows MSBuild-based repo builds to easily consume NuGet package versions from upstream builds. Repos must import this file and accept the values appropriately.

The file specifies one property for each package. The name is the package identity after being suffixed with `PackageVersion`, chars uppercased to get to PascalCase, and non-alphanumeric characters (assumed to be delimiters) removed. The property value is the full version of the package. Example with a few CoreCLR packages:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="14.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <MicrosoftNETCoreRuntimeCoreCLRPackageVersion>2.1.0-preview2-25701-02</MicrosoftNETCoreRuntimeCoreCLRPackageVersion>
    <RuntimeOsxX64MicrosoftNETCoreRuntimeCoreCLRPackageVersion>2.1.0-preview2-25701-02</RuntimeOsxX64MicrosoftNETCoreRuntimeCoreCLRPackageVersion>
    <TransportMicrosoftNETCoreRuntimeCoreCLRPackageVersion>2.1.0-preview2-25701-02</TransportMicrosoftNETCoreRuntimeCoreCLRPackageVersion>
  </PropertyGroup>
</Project>
```

## Creation based on blob feed
Given a blob feed with `packages/*.nupkg`, all package identities and versions are determined using `NuGet.Packaging.PackageArchiveReader` on the nupkg zips. An MSBuild property is created for each package identity where the value is the latest full version.


# Restore source props

An MSBuild file defining a single property `DotNetRestoreSources`. This file is necessary to avoid issues with escaping: there are various issues trying to pass `;` on the command line to delimit sources. Example:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="14.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <DotNetRestoreSources>
      /git/source-build/bin/obj/x64/Release/blob-feed/packages/;
      /git/source-build/bin/prebuilt/nuget-packages/;
    </DotNetRestoreSources>
  </PropertyGroup>
</Project>
```


# Build output manifest

Declares the outputs of a build. In general, it is JSON annotating the build's blob feed. Example:

```javascript
{
  "output": {
    // The properties inside "output" mimic blob feed file structure.
    "packages/": {
      "Example.1.0.0-prerelease.nupkg": {
        // Required properties. Values are declared in the nupkg's nuspec.
        "identity": "Example",
        "version": "1.0.0-prerelease"
      },
      // Based on filename alone, this could be either:
      // "Has.Revision.1" version "2.0.0" or
      // "Has.Revision" version "1.2.0.0".
      // The values from the nuspec are required to disambiguate.
      "Has.Revision.1.2.0.0.nupkg": {
        "identity": "Has.Revision",
        "version": "1.2.0.0"
      },
      // The repo build may produce or process nupkgs in a way that makes
      // the filename not match the nuspec.
      "Bar-without-version.nupkg": {
        "identity": "Bar",
        "version": "2.0.1-servicing-25623-05"
      }
    },
    "assets/": {
      "dotnet-host-2.0.1-servicing-25615-03-win-x64.msi": { },
      "Microsoft.NETCore.DotNetHost.2.0.1-servicing-25615-03.symbols.nupkg": { }
    }
  }
}
```

There are optional properties that may be included. They aren't used by the orchestrator because it already knows the information, but they are useful for isolated builds:

## (*Optional*) `build-input`
The build input manifest used to produce this build.

## (*Optional*) `publish-metadata`
Information about where the outputs were published.

Publish metadata includes blob feed identity for direct build consumption. A repo may decide to include public output locations. For example, Core-Setup may include installer locations and point to the dotnet-core MyGet feed.

*Format to be specified when needed.*


# Build input manifest

Lists all the inputs for a build.

This is not used by the product build: the orchestrator already knows this information. It is useful for isolated repo builds.

For a deterministic build, this captures every input that could change the output. However, some parts such as commit hash and package dependency versions are "pointers" to data. A build might not be able to run using only a build input manifest: the results can change if the data pointed to is mutable or if the build process can't access the correct storage locations.

```javascript
{
  "repository": {
    "user": "dotnet",
    "name": "core-setup",
    "commit": "152dbe8a4b4e30eee26208ff6a850e9aa73c07f8",
    "branch": "master"
  },
  "build-dependency": [
    {
      "output": {
        "packages/": {
          "Microsoft.NETCore.Runtime.CoreCLR.2.0.2-servicing-25712-01.nupkg": {
            "identity": "Microsoft.NETCore.Runtime.CoreCLR",
            "version": "2.0.2-servicing-25712-01"
          }
          // ...
        }
      }
    },
    {
      "output": {
        "packages/": {
          "Microsoft.Private.CoreFx.NETCoreApp.4.4.2-servicing-25708-01.nupkg": {
            "identity": "Microsoft.Private.CoreFx.NETCoreApp",
            "version": "4.4.2-servicing-25708-01"
          }
          // ...
        }
      }
    }
  ]
  // More to be added as discovered and defined.
}
```

## `build-dependency`
Declares the build output manifest(s) that were passed to perform a build.

Unused dependency info isn't stripped. It is useful to have complete information about a build's dependencies without performing lookups. For example, isolated DotNet Docker builds need to know details about the Core-Setup build that a CLI build used. It would be less complicated/error-prone if the DotNet Docker build could get that info from the build input manifest rather than following a chain of lookups.

Format is an array of build output manifest JSON objects. (Seen above.) If the format were an object with a property for each repo used, that would place an artificial limitation on duplicates: a valid situation like CLI shipping multiple Runtimes in the same build would break the format.


# Repo output manifest

*Format to be specified when needed.*


# Repo input manifest

*Format to be specified when needed.*
