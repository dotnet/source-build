# Running 3.1 auto-update

## Run update manually

1.  If you haven't already, set up `darc`.
    * Run `eng/common/darc-init.sh`
    * Run `darc authenticate`
1.  Get the build id from the internal build assets.
    1.  For example, in the build directory from email, copy "...\CORE_BUILDS\3.1.X\3.1.201\3.1.201-servicing-015034\manifest.json" locally and open it.
    1.  Find the build for dotnet/core-sdk or dotnet/installer, grab its `barBuildId`.
1.  Run `darc update-dependenices --id <barBuildId> --verbose` in source-build repo root.
    * See https://github.com/dotnet/core-eng/issues/10155 for discussion about using channel vs. build ID.
    * If darc fails on XliffTasks, comment out its `/eng/Version.Details.xml` entry temporarily and try again.
1.  If authenticated feeds were added to `/NuGet.config`, copy them into `/smoke-testNuGet.config`.
1.  Commit changes.
1.  Verify the final state of the repos in `/eng/Version.Details.xml` matches `manifest.json`.