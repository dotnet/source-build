# Troubleshooting Offline Builds

This document covers common issues and solutions when building .NET from source in offline environments.

## Microsoft.Build.NoTargets SDK Resolution Issues

### Problem

When running `prep-source-build.sh` in an offline environment (such as a sandboxed build), you may encounter errors like:

```
/path/to/eng/init-detect-binaries.proj : error : Could not resolve SDK "Microsoft.Build.NoTargets"
/path/to/eng/init-detect-binaries.proj : error : SDK resolver "Microsoft.DotNet.MSBuildWorkloadSdkResolver" returned null
/path/to/eng/init-detect-binaries.proj : error : Unable to find package Microsoft.Build.NoTargets. No packages exist with this id in source(s): dotnet-eng, dotnet-libraries, dotnet-public
/path/to/eng/init-detect-binaries.proj : error MSB4236: The SDK 'Microsoft.Build.NoTargets' specified could not be found.
```

This typically affects .NET 10.0.0-preview.6 and later versions.

### Root Cause

The `init-detect-binaries.proj` file requires the `Microsoft.Build.NoTargets` SDK to execute, but in offline builds, this SDK cannot be downloaded from online NuGet feeds. The binary detection tooling itself is configured to use offline restore sources (provided via `--with-packages`), but the project file needs to resolve its SDK dependencies before it can execute.

### Workarounds

#### Option 1: Modify NuGet Configuration

Add both the packages directory and the SourceBuildReferencePackages subdirectory to your NuGet.config:

```xml
<packageSources>
  <add key="PackagesDir" value="path/to/Private.SourceBuilt.Artifacts.x.y.z.rid" />
  <add key="SourceBuildRefPackages" value="path/to/Private.SourceBuilt.Artifacts.x.y.z.rid/SourceBuildReferencePackages" />
</packageSources>
```

Replace `path/to/Private.SourceBuilt.Artifacts.x.y.z.rid` with the actual path to your previously source-built artifacts directory.

#### Option 2: Skip Binary Detection (For Stage 2 Builds)

For stage 2 builds where binary detection may not be critical, you can skip the Arcade SDK import:

```bash
./prep-source-build.sh --with-packages <path> -- -p:SkipArcadeSdkImport=true
```

### Long-term Solution

The proper fix involves factoring the SDK configuration logic from `build.sh` and `init-source-only.proj` to be shared with `prep-source-build.sh` for offline builds. This ensures that required SDKs like `Microsoft.Build.NoTargets` are properly configured for offline scenarios.

## General Offline Build Guidelines

### Network Requirements

Source builds must be self-contained and work in completely offline environments. This is a key requirement for distribution packaging on many Linux distributions.

### Package Sources

All package dependencies must be satisfied by:

1. **Source-Build-Reference-Packages**: Reference packages for building the product
2. **Current Source Built Packages**: Packages produced in the current build
3. **Previous Source Built Packages**: Packages from the previous source build release for bootstrapping

### Best Practices

1. Always use `--with-packages` when running prep in offline environments
2. Ensure your previously source-built artifacts are properly extracted and accessible
3. Verify that SourceBuildReferencePackages are included in your restore sources
4. Test offline builds in isolated environments to catch network dependencies early

### Related Issues

- [Microsoft.Build.NoTargets missing in prep-source-build on 10.0.0-preview.6](https://github.com/dotnet/dotnet/issues/2009)
- [Package Dependency Flow Documentation](./package-dependency-flow.md)
- [Bootstrapping Guidelines](./bootstrapping-guidelines.md)