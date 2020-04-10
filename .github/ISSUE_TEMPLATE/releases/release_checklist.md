# .NET Core Release Checklist

## Release Versions

_The set of .NET Core versions that are being released as a unit._

* 2.1.X: <runtime/SDK>
* 3.1.X: <runtime/SDK>

1. - [ ] Update target branch to new version.
   - For 2.x:
     - [ ] If releasing 2.x, run auto-update (refer to docs).
   - For 3.x:
     - [ ] if maestro auto-PR is active, then verify SHA1s in version.Details with manifest versions in VSU share dir (refer docs), make sure that we match the versions
     - [ ] in-case auto-PR updates are unavailable, checkout a local branch for the pertinent version and run darc updates(refer docs). 
       - [ ] Push this local branch upstream and start the release PR for the N version that is to be released.
1. - [ ] Verify that the `PrivateSourceBuiltArtifactsPackageVersion` in `eng/Versions.props` match N-1 release artifacts
1. - [ ] Verify that `source-build/ProdConFeed.txt` contains the latest feed required for the release. For info on latest feed (refer OneNote)
1. - [ ] Verify that we are building with the appropriate stability and release tag (either none for RTM, or "preview1" etc).  This can apply to the SDK itself as well as the core-setup runtime component. Using a local build:
        
            dotnet --info
            dotnet --version

      - [ ] Verify ASP.NET package versions used in templates are correct (dependencies.props may need to be updated)
      - [ ] Verify MS.NETCore.App packages versions used in downlevel templates are correct (dependencies.props may need to be updated)
1. - [ ] Complete prebuilt and poison audit. Review the baseline changes to find out if there are any new prebuilts. 
1. - [ ] Remove new prebuilts, if any. Ideally any new prebuilts that show up in offline builds have to be removed. In some cases, new prebuilts show up in Production builds but gets purged in offline builds automatically as they are not packaged(they may not be needed for the actual build).
1. - [ ] Stall tagging the release until we have the final validation. Incase of significant delays, notify(PR is ready, waiting on the final validation) the distro maintainer with PR link.
1. - [ ] Re-validate the SHA1s in Versions file with the manifest in VSU share dir
1. - [ ] Tag runtime version (e.g. "v2.1.0-runtime") with an annotated (preferably signed) tag including runtime and SDK versions, e.g. "Release for 2.1.0 runtime and 2.1.300 SDK."
      - `git tag -s v<X.X.X-runtime/SDK> <SHA1>` . E.g - $ git tag -s v2.1.0-runtime c7012bcc8
1. - [ ] Tag SDK version (e.g. "v2.1.300-SDK") with the same annotation, also preferably signed
1. - [ ] Push these tags to GitHub
      - `git push <remote> v2.1.0-runtime && git push <remote> v2.1.300-SDK`
            
            Do not use "git push --tags" unless you have a fresh repo with no other tags - this will push all your tags.
1. - [ ] Incase there's a respin, retag the with the new changes. A sub-patch version tag for SDK and runtime would have to be generated. E.g - v2.1.300.1-SDK
1. - [ ] Notify the distro maintainer/s about the release tags
1. - [ ] Download the tarball from CI
1. - [ ] Upload the tarball to Azure blob feed for source-build

            <Source-build-blob-feed-container>/redhat/<branch_version>/<SDK_version>/dotnet-<sdk_version>-<RID><RID_version>.tar.gz

1. - [ ] Similarly, download Private.SourceBuilt.Artifacts.XX.tar.gz from CI and upload it to source-built-artifacts blob container
1. - [ ] Write a post-mortem for the release
