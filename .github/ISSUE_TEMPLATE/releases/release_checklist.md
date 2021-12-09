# .NET Core Release Checklist

<!--
  To start the checklist for a new release:
  - If it's an internal release, open a new issue in dotnet/core-eng (private repo).
    - Otherwise, open a new issue in dotnet/source-build.
  - Delete lines starting with [Internal] if running a non-internal release.
  - Delete lines starting with [Non-Internal] if running an internal release.
-->

<!--
  Enter the version tracked by this checklist.
-->
# {runtime-version} / {sdk-version}

1.  - [ ] Create a page at ".NET Core A&D" OneNote -> "Servicing" section -> "Retrospective" -> "{Month} {YYYY}" to take ongoing notes on problems with the process, workarounds, and fixes.
      - This is useful to make sure context is available to review later. It may end up blank if the release goes very smoothly.
      - There are other notes on servicing in this OneNote. It may be useful to review if something goes wrong to see if it's been fixed before.
      - [Non-Internal] File GitHub issues as you encounter problems, and link to them from the notes. Provide info in the issue rather than in the notes.
1.  - [ ] Retrieve dotnet/installer commit sha from internal communications for the release.
1.  - [ ] Ensure the official installer and tarball builds have completed for the release's commit sha.
      - [ ] [Installer](https://dev.azure.com/dnceng/internal/_build?definitionId=286) (internal link)
      - [ ] [Tarball](https://dev.azure.com/dnceng/internal/_build?definitionId=1011) (internal link)
        - [ ] Retrieve the source tarball artifact - BlobArtifacts/dotnet-sdk-source-6.0.xxx.tar.gz
1.  - [ ] Run poison report and confirm results.
      - [Automation tracking issue](https://github.com/dotnet/source-build/issues/2652) for this step.
1.  - [ ] Compare source-built to Microsoft build and confirm results.
      - [Automation tracking issue](https://github.com/dotnet/source-build/issues/2653) for this step.
1.  - [ ] [Internal] Gather smoke-test prereqs and package in dotnet-smoke-test-prereqs-6.0.101.tar.gz.
      - [Automation tracking issue](https://github.com/dotnet/source-build/issues/2550) for this step.
1.  - [ ] [Internal] Upload source and smoke-test-prereqs tarball to dotnetclimsrc storage account.
1.  - [ ] Send notification for manual testing.
      - Provide links to source tarball.
1.  - [ ] Notify partners of release.  Include info about how certain we are that this will be the final Microsoft build.
      - [Internal] Send the dotnetclimsrc tarball links to partners.
          - Never overwrite a tarball. At least change the blob storage virtual dir to represent a new build. This can help avoid timing issues and make it more obvious if stale links were accidentally re-sent rather than new ones.
      - [Non-Internal] Send the dotnet/installer commit sha along w/link to publicly built source tarball.  Link to the public instructions for building source-build.
1.  - [ ] SYNC POINT: Wait for Microsoft build release.
1.  - [ ] Update tarball artifacts w/previous release.
      - [ ] global.json
        - [Automation tracking issue](https://github.com/dotnet/source-build/issues/2632) for this step.
      - [ ] Previous source-built artifacts
1.  - [ ] Cleanup any SBRP dependencies - https://github.com/dotnet/source-build-reference-packages/blob/main/eng/Build.props
1.  - [ ] Clean up retrospective notes if necessary.
