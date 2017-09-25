# Automatic dependency flow Repo API

Repos must implement these arguments to participate in the orchestrated dependency flow.


# Dependency version input arguments

## `/p:DotNetPackageVersionPropsPath=<path>`
Directs the repo build to use a [package version props](contracts.md#package-version-props) file at `path`. The versions in the file must be used instead of any defaults the repo would ordinarily depend on.

### Recommended implementation
Use the build dependency props format for all `PackageReference`s that may be satisfied by another repo that is being orchestrated:

```xml
<PackageReference Include="System.Collections.Immutable"
                  Version="$(SystemCollectionsImmutablePackageVersion)" />
```

Store all defaults in a centralized `.props` file, and import `DotNetPackageVersionPropsPath` if specified to override the defaults:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <SystemCollectionsImmutablePackageVersion>1.5.0-preview1-25712-02</SystemCollectionsImmutablePackageVersion>
    <!-- ...All NuGet package dependency versions. --->
  </PropertyGroup>

  <!-- Override isolated build dependency versions with product build's. -->
  <Import Project="$(DotNetPackageVersionPropsPath)"
          Condition="'$(DotNetPackageVersionPropsPath)' != ''" />
</Project>
```


# Source override arguments

## `/p:DotNetBuildOffline=<bool>`
Directs the repo to skip online sources if `bool` is `true`.

## `/p:DotNetRestoreSourcePropsPath=<path>`
Directs the repo to use the semicolon-delimited sources in the `DotNetRestoreSources` property specified by the [restore source props](contracts.md#restore-source-props) file at `path`. The sources should be the highest priority NuGet package sources. Unless otherwise specified by `DotNetBuildOffline`, the repo may also use its default sources.

### Recommended implementation
Import `DotNetRestoreSourcePropsPath` as an MSBuild props file, and use properties similar to the following to define restore sources:

```xml
<Project>
  <Import Project="'$(DotNetRestoreSourcePropsPath)'"
          Condition="'$(DotNetRestoreSourcePropsPath)' != ''"/>

  <PropertyGroup>
    <RestoreSources>$(DotNetRestoreSources)</RestoreSources>
    <RestoreSources Condition="'$(DotNetBuildOffline)' != 'true'">
      $(RestoreSources);
      https://dotnet.myget.org/F/dotnet-buildtools/api/v3/index.json;
      https://dotnet.myget.org/F/dotnet-core/api/v3/index.json;
      https://api.nuget.org/v3/index.json
    </RestoreSources>
  </PropertyGroup>
</Project>
```

If the repo doesn't use [NuGet MSBuild targets](https://docs.microsoft.com/en-us/nuget/schema/msbuild-targets#restore-target) to restore, there's more work to use the `RestoreSources` property. For example, to pass `--source` args, `RestoreSources` can be `Include`d in an Item element to split it, then formatted.

There is no known reasonable way to use NuGet.Config files, satisfy this API, *and* avoid duplicating the default source information. The recommendation is to not use NuGet.Config.

## `/p:DotNetAssetRootUrl=<url>`
Directs the repo to get binary assets from a given base `url`. For example, installers and lzma files. The scheme can be `http[s]` or `file`. The url ends with a `/`.

### Conventions
Repos must cooperate to establish conventions. Core-Setup needs to implement `DotNetOutputBlobFeedDir` in a way that allows CLI to find its binaries in `DotNetAssetRootUrl`.

### Recommended implementation
Use the AssetRoot properties if they are defined. Example (adapted from [CLI's build/BundledRuntimes.props](https://github.com/dotnet/cli/blob/4fe4c4d28a5171946311ca3ebf65af95180eb11f/build/BundledRuntimes.props)):

```xml
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <!-- SharedFrameworkVersion is defined elsewhere by a Core-Setup package version. -->
    <CombinedFrameworkHostCompressedFileName>dotnet-runtime-$(SharedFrameworkVersion)-$(SharedFrameworkRid)$(ArchiveExtension)</CombinedFrameworkHostCompressedFileName>
  </PropertyGroup>

  <PropertyGroup>
    <CoreSetupBlobRootUrl Condition="'$(DotNetAssetRootUrl)' != ''">$(DotNetAssetRootUrl)</CoreSetupBlobRootUrl>
    <CoreSetupBlobRootUrl Condition="'$(CoreSetupBlobRootUrl)' == ''">https://dotnetcli.azureedge.net/dotnet/</CoreSetupBlobRootUrl>

    <CoreSetupRootUrl>$(CoreSetupBlobRootUrl)Runtime/</CoreSetupRootUrl>

    <CoreSetupBlobAccessTokenParam Condition="'$(DotNetAssetRootAccessTokenSuffix)' != ''">$(DotNetAssetRootAccessTokenSuffix)</CoreSetupBlobAccessTokenParam>
  </PropertyGroup>

  <ItemGroup>
    <_DownloadAndExtractItem Include="CombinedSharedHostAndFrameworkArchive">
      <Url>$(CoreSetupRootUrl)$(SharedFrameworkVersion)/$(CombinedFrameworkHostCompressedFileName)$(CoreSetupBlobAccessTokenParam)</Url>
    </_DownloadAndExtractItem>
  </ItemGroup>
</Project>
```

The above assumes that Core-Setup publishes outputs to `$(DotNetOutputBlobFeedDir)assets/Runtime/<SharedFrameworkVersion>/`.

## `/p:DotNetAssetRootAccessTokenSuffix=<query string>`
Directs the repo to append `query string` to any URL constructed using the `DotNetAssetRootUrl`.

Recommended implementation is included in the `DotNetAssetRootUrl` section.


# Output placement arguments

## `/p:DotNetOutputBlobFeedDir=<target directory>`
Directs the repo to place all outputs in the blob feed located at `target directory`, following blob feed structure.

### Recommended implementation
Place NuGet library packages (`*.nupkg`) directly in `$(DotNetOutputBlobFeedDir)packages/`.

Place all other assets, such as installers, lzma files, and NuGet symbol packages (`*.symbols.nupkg`), in `$(DotNetOutputBlobFeedDir)assets/`.

BuildTools can be configured to do this by setting the `PackageOutputPath` and `SymbolPackageOutputPath` MSBuild properties.
