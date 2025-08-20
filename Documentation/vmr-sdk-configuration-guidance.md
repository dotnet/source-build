# SDK Configuration for Offline Builds

This document provides guidance for implementing offline SDK resolution support in the VMR's `prep-source-build.sh` script.

## Problem Summary

The `init-detect-binaries.proj` file requires SDK resolution (specifically `Microsoft.Build.NoTargets`) before it can execute, but offline builds cannot access online NuGet feeds to download these SDKs.

## Proposed Solution

Factor the SDK configuration logic from `build.sh` and `init-source-only.proj` to be shared with prep-source-build scenarios.

## Implementation Approach

### 1. Extract Shared SDK Configuration Logic

Create a shared function or target that configures offline SDK resolution:

```bash
# Function to configure offline SDK resolution
configure_offline_sdks() {
    local packages_dir="$1"
    local nuget_config_path="$2"
    
    if [[ -n "$packages_dir" && -d "$packages_dir" ]]; then
        # Add SourceBuildReferencePackages to NuGet sources
        local sbrp_dir="$packages_dir/SourceBuildReferencePackages"
        if [[ -d "$sbrp_dir" ]]; then
            echo "Configuring offline SDK sources: $sbrp_dir"
            # Add logic to update NuGet.config with offline sources
            # This should mirror the logic in build.sh lines 492-532
        fi
    fi
}
```

### 2. MSBuild Target for SDK Resolution

Create a shared MSBuild target that can be imported by both `init-source-only.proj` and `init-detect-binaries.proj`:

```xml
<!-- File: eng/OfflineSdkResolution.targets -->
<Project>
  <PropertyGroup Condition="'$(BinariesPackagesDir)' != '' and Exists('$(BinariesPackagesDir)/SourceBuildReferencePackages')">
    <RestoreSources>$(RestoreSources);$(BinariesPackagesDir);$(BinariesPackagesDir)/SourceBuildReferencePackages</RestoreSources>
  </PropertyGroup>
  
  <!-- Configure SDK resolution for offline scenarios -->
  <PropertyGroup Condition="'$(DotNetBuildOffline)' == 'true'">
    <MSBuildSDKsPath Condition="'$(MSBuildSDKsPath)' == ''">$(BinariesPackagesDir)/SourceBuildReferencePackages</MSBuildSDKsPath>
  </PropertyGroup>
</Project>
```

### 3. Update prep-source-build.sh

The prep script should call the shared SDK configuration function:

```bash
# In prep-source-build.sh, before calling init-detect-binaries.proj
if [[ -n "$packagesDir" ]]; then
    configure_offline_sdks "$packagesDir" "NuGet.config"
    export DotNetBuildOffline=true
fi
```

### 4. Update init-detect-binaries.proj

Import the shared targets:

```xml
<Project Sdk="Microsoft.Build.NoTargets">
  <Import Project="OfflineSdkResolution.targets" />
  <!-- rest of the project -->
</Project>
```

## Testing

1. Test offline prep with `--with-packages` option
2. Verify SDK resolution works without network access
3. Ensure binary detection still functions correctly
4. Test with sandboxed build environments

## References

- [build.sh SDK configuration (lines 492-532)](https://github.com/dotnet/dotnet/blob/5603682699a5c75aa68a2d829b17c0959dff5439/build.sh#L492-L532)
- [init-source-only.proj SDK logic (lines 141-175)](https://github.com/dotnet/dotnet/blob/5603682699a5c75aa68a2d829b17c0959dff5439/eng/init-source-only.proj#L141-L175)
- [Issue discussion](https://github.com/dotnet/dotnet/issues/2009)