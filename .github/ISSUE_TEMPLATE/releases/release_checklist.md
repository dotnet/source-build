# .NET Core Release Checklist

<!--
  To start the checklist for a new release:
  - Open a new issue in dotnet/release (private repo):
      - Issue title: Source-build {runtime-version} / {sdk-version} {Month} {Year} Servicing
  - Paste a copy of the below checklist.

-->

<!--
  Enter the version tracked by this checklist.
-->
# {runtime-version} / {sdk-version}

1. - [ ] Create a OneNote page in the NET Core Acquisition and Deployment
    OneNote > source-build > Servicing > Retrospective > "May 2022"
    (for example) to take ongoing notes on problems with the process,
    workarounds, and fixes.
      - This is useful to make sure context is available to review later.
        It may end up blank if the release goes very smoothly.
      - There are other notes on servicing in this OneNote. It may be
        useful to review if something goes wrong to see if it's been fixed
        before.
1. - [ ] Work in the [dotnet-source-build](https://dnceng.visualstudio.com/internal/_git/dotnet-source-build?path=%2F&version=GBmain&_a=contents)
         repo.
1. - [ ] Ensure [internal/release/3.1](https://dnceng.visualstudio.com/internal/_git/dotnet-source-build?path=/&version=GBinternal/release/3.1&_a=history)
         branch contains all commits made to the public [release/3.1](https://github.com/dotnet/source-build/commits/release/3.1) GitHub branch during this servicing cycle.
         branch.
1. - [ ] Update to new version.
      - [/Documentation/servicing/update-3.1.md](https://github.com/dotnet/source-build/tree/release/3.1/Documentation/servicing/update-3.1.md)
      - Start a new working branch off of [internal/release/3.1](https://dnceng.visualstudio.com/internal/_git/dotnet-source-build?path=/&version=GBinternal/release/3.1&_a=history) and open a PR for WIP so others can
        easily look if needed and CI starts running.
        - Use the branch name `dev/<youralias>/<SDK-version>-<month name><YYYY>`.
          This is necessary because some branch protection kicks in on branches
          with "release" in the name.
1. - [ ] Version update cleanup and confirmations
      - [ ] Verify that the `PrivateSourceBuiltArtifactsPackageVersion` in
            `eng/Versions.props` matches the previous version of the
            release artifacts.
        - These can be found in the `dotnetcli` storage account in the `source-build-artifacts`
          blob container.  The access key for this storage account
          is in Azure Keyvault in the `EngKeyVault` vault in the
          "Dotnet Engineering Services" subscription.  You can access
          the key vault with [VaultExplorer](https://aka.ms/ve) and
          the storage account with [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/).
          Use the latest version of the artifacts in the branch we
          are building, which should be from the latest released
          version.  For example, when building 3.1.419, use
          `Private.SourceBuilt.Artifacts.0.1.0-3.1.418-1728976-20220420.1.tar.gz`.
          The version number is `0.1.0-3.1.418-1728976-20220420.1`.
      - [ ] In `global.json`, update `dotnet` to the latest released 3.1 SDK
            version. It should be one version behind the version we are building.
            For example, if we are building 3.1.214, then the line should read
            `"dotnet": "3.1.213"`.
      - [ ] Update feeds:
        - [ ] If new feeds were added to NuGet.config (i.e. [there's a diff
              in NuGet.config](https://github.com/dotnet/source-build/commit/f07ff3ab98992e460ae605f609783f3abba20601#diff-9c5952957709545aad811b400e7e516eebade1e44fc4fbc23203403ffeb92c34)),
              copy them to [smoke-testNuGet.config](https://github.com/dotnet/source-build/blob/release/3.1/smoke-testNuGet.Config)
              and the `VSS_NUGET_EXTERNAL_FEED_ENDPOINTS` section in `build.sh`.
        - [ ] Add the servicing feed to build.sh and smoke-testNuGet.config
          1. The URL will look like this: <https://pkgs.dev.azure.com/dnceng/internal/_packaging/3.1.419-servicing.22219.28-shipping/nuget/v3/index.json>
          1. In build.sh, add this feed to the `VSS_NUGET_EXTERNAL_FEED_ENDPOINTS`.
          1. In smoke-testNuGet.config, add another feed entry that looks like
             the others, with key="5.0.408-servicing.22219.28-shipping"
             (for example) and value as the servicing url.
      - [ ] In `eng/Version.Details.Xml`, verify that the `<Sha>` tag for all
            repos were updated, except for these expected to usually be stable:
        - arcade
        - sourcelink
        - aspnet-xdt
        - cliCommandLineParser
        - xliff-tasks
        - Newtonsoft.Json
        - common
        - Roslyn (except for feature band updates)
        - MSBuild (except for feature band updates)
        - NuGet-client (except for feature band updates)
        - fsharp (except for feature band updates)
        - VSTest (except for feature band updates)
1. - [ ] [Regenerate patches as necessary](patch-updates.md).
      - Run `./build.sh` to begin clone and patch application and see what,
        if anything, needs to be regenerated.
      - ASP.NET will always need to be regenerated because it contains a
        version number that needs to be updated.  The version should be updated
        to the SDK version being built.  See <https://github.com/dotnet/source-build/blob/release/3.1/patches/aspnetcore/0006-Fix-version-number.patch>.
1. - [ ] [Generate a PAT for AzDo](https://dev.azure.com/dnceng/_usersSettings/tokens).
      - This should include the `dnceng` organization.
      - Scope should include Read for Code and Packages.
1. - [ ] Start building locally (for quick diagnosis) and in CI (for super
         clean build) and iterate towards a green build.
      - For local builds:
        - Set environment variable `internalPackageFeedPat` to the PAT generated in the previous step.
          - E.g. run `export internalPackageFeedPat;read internalPackageFeedPat`
            and paste the PAT. This sets up your running shell for an authenticated
            build. Passing `/p:` isn't sufficient.
        - Run `build.sh /p:AzDoPat=$internalPackageFeedPat`.
      - For CI builds:
        - To run CI, from [dnceng/internal/source-build-pre-arcade-CI](https://dev.azure.com/dnceng/internal/_build?definitionId=251),
          click "Run pipeline" and select your dev/… branch under "Branch/tag",
          then click "Run".
        - If you are unsure if your build will be successful, you can run only
          the centos71_* stages to save resources by selecting "Stages to run"
          in the run dialog.
1. - [ ] Review prebuilt baseline diff and iterate builds to drive to zero.
      - Prebuilts are packages used in a source-build that come from outside
        of source-build.  These are not allowed by our Linux partners so we
        have to eliminate them before shipping.
      - If there's a prebuilt issue in a build, it will fail with an error
        similar to:

          ```text
          /src/repos/Directory.Build.targets(639,5): warning : 3 new packages
            used not in baseline! See report at /src/artifacts/prebuilt-report/baseline-comparison.xml
            for more information. Package IDs are: [/src/repos/known-good.proj]
          /src/repos/Directory.Build.targets(639,5): warning : Microsoft.DotNet.Web.ItemTemplates.3.1.24
            [/src/repos/known-good.proj]
          /src/repos/Directory.Build.targets(639,5): warning : Microsoft.DotNet.Web.ProjectTemplates.3.1.3.1.24
            [/src/repos/known-good.proj]
          /src/repos/Directory.Build.targets(639,5): warning : Microsoft.DotNet.Web.Spa.ProjectTemplates.3.1.3.1.24
            [/src/repos/known-good.proj]
          /src/repos/Directory.Build.targets(639,5): warning : Prebuilt usages
            are different from the baseline. If detected changes are acceptable,
            update baseline with: [/src/repos/known-good.proj]
          /src/repos/Directory.Build.targets(639,5): warning : cp '/src/artifacts/prebuilt-report/generated-new-baseline.xml'
            '/src/tools-local/prebuilt-baseline-online.xml' [/src/repos/known-good.proj]
          ```

      - The full prebuilt report can be found in the log artifacts under
        prebuilt-reports/tarball/artifacts/prebuilt-report/annotated-usage.xml.
        This will include where each prebuilt is coming from.
      - Find an explanation for each change in each (online/offline) baseline.
        - If possible, figure out the cause and fix.
          - One typical case is just an update from the previous-previous
            version to the previous version.  For instance, when building
            3.1.25 some templates will go from 3.1.23 to 3.1.24.  These are
            okay to just update to the new previous verison.
          - If a package is entirely new these usually came in from source
            changes in the contributing repo.  We can ask the repo owners to
            look at these and help us get rid of the new prebuilt.
          - Discuss with repo or code owner if the fix is a new patch.
          - This may require adding packages to dotnet/source-build-reference-packages.
        - If the baseline change is due to the change in patch version, make
          sure there's an issue tracking fixing the instability, or start
          tracking it.
        - If in doubt, talk to the team. Someone might have already encountered
          a similar diff in the past.  The Source-Build Teams channel is a good
          place to start the conversation, or the dotnetADTeam DL.
1. - [ ] Add team members crummel, LoganBussell, and msimons as reviewers to
         the PR. Get acceptance.
      - Note: Don't merge the PR.  This is just used to generate the pre-embargo-date
        tarball for our partners.  This will be ported to the public repo
        later and become the official release.
1. - [ ] Download the artifacts from the centos71_Online_BaseTarball PR
         validation build onto a machine with Bash.
      - From the "Artifacts" page, navigate to "Tarball centos71_Online_BaseTarball"
        and download the `base_tarball_*.tar.gz` and `tarball_*-smoke-test-prereqs.tar.gz`
        files.
      - The smoke-test prereqs are platform-independent but should be taken
        from this non-portable build, *not* CentOS7 Offline Portable.
      - Can use <https://github.com/dotnet/source-build/blob/release/3.1/scripts/fetch-azdo-artifact-tarball.sh>
        as a library.
        - E.g. download the tarballs with `download_tarball`, and fix them up
          with `fix_azdo_tarball` if necessary.
1. - [ ] Rename tarball and smoke-test prereqs to human-friendly names.
         (Can use `rename_tarball_inner_dir`.)
      - Refer to previous release's email threads for naming pattern.
1. - [ ] Upload tarballs and smoke-test prereqs to the `dotnetclimsrc` blob
         storage under the `source-build` container in `red-hat/3.1/` under a
         new folder named for the runtime and SDK version.  The access key for
         this blob storage is in the `EngKeyVault` vault in the "Dotnet
         Engineering Services" subscription.
1. - [ ] Complete manual validation steps
      - For 3.1, the build is poison-checked during the CI build.  If you get
        an error related to "leak detection" or "CheckForPoison", get the source-build
        team involved as these can be difficult to diagnose and fix.
      - [ ] Verify the packs included in the SDK are from source-build-reference-packages,
        not source-build.
        - After smoke-tests have run, in `testing-smoke/builtCli`, run
          `strings sdk/<version>/Sdks/Microsoft.NET.Sdk/tools/net472/Microsoft.CSharp.dll
          | grep "built by"` and make sure this includes `built by: SOURCEBUILD`.
      - [ ] Verify the packs included in the SDK have XML documentation comments
        - From the `testing-smoke/builtCli` directory, run `ls packs/Microsoft.NETCore.App.Ref/<version>/ref/netcoreapp3.1/*.xml`.
          There should be about 110 XML files here.
        - From the `testing-smoke/builtCli` directory, run `ls packs/Microsoft.AspNetCore.App.Ref/<version>/ref/netcoreapp3.1/*.xml`.
          There should be about 130 XML files here.
        - Issue tracking automation of this: [#1579](https://github.com/dotnet/source-build/issues/1579)
      - [ ] Re-validate the SHA1s in the `eng/Version.Details.xml` file with
        the manifest in VSU share dir.
      - [ ] Review the file list diff between Microsoft-built SDK and source-built
        SDK in smoke-test output.
        - For internal builds, smoke-test fails to acquire the Microsoft-built
          SDK. Manually acquire the Microsoft-built SDK from the build email
          you should have received, then run `scripts/compare-builds.sh`
          yourself to get the output to review.
          - [#1631](https://github.com/dotnet/source-build/issues/1631)
            tracks a fix.
        - Use <https://gist.github.com/omajid/9111a9310d452b3594b770d4ca8a3d87>
          as a loose baseline.
          - [#1630](https://github.com/dotnet/source-build/issues/1630) tracks
            a checked-in baseline.
1. - [ ] Complete manual smoke-testing on our primary testing platforms:
      - [ ] RHEL 7 VM
      - [ ] RHEL 8 VM
      - [ ] Fedora 30 - VM or [Docker](mcr.microsoft.com/dotnet-buildtools/prereqs:fedora-30-38e0f29-20191126135223)
      - [ ] CentOS 7 - VM or [Docker](mcr.microsoft.com/dotnet-buildtools/prereqs:centos-7-3e800f1-20190501005343)
      - [ ] CentOS 8 - VM or [Docker](mcr.microsoft.com/dotnet-buildtools/prereqs:centos-8-daa5116-20200325130212)
      - [ ] Debian 9 - VM or [Docker](mcr.microsoft.com/dotnet-buildtools/prereqs:debian-stretch-d61254f-20190807161114)
1. - [ ] [Source-build team] Send the tarball to partners. Include info about
     how certain we are that this will be the final Microsoft build.
      - Never overwrite a tarball. At least change the blob storage virtual
        dir to represent a new build. This can help avoid timing issues and
        make it more obvious if stale links were accidentally re-sent rather
        than new ones.
1. - [ ] SYNC POINT: Wait for Microsoft build release.
      - Wait for dotnet/announcements post. `Watch` the repo to get emails so
        you don't have to poll.
        - Example: <https://github.com/dotnet/announcements/issues/160>.
1. - [ ] In a dev branch on your GitHub fork of source-build, clean up.
      - [ ] Convert internal URIs to public in `eng/Version.Details.xml`.
        - `https://dev.azure.com/dnceng/internal/_git/<org>-<repo>` => `https://github.com/<org>/<repo>`
      - [ ] Remove internal package feeds from source-build.
        - `/NuGet.Config`
        - `/smoke-testNuGet.Config`
        - Do not remove from subrepos. The build infra removes these sources
          automatically while modifying each subrepo nuget.config file.
1. - [ ] Push the servicing branch to your GitHub fork and submit a
         source-build PR.
1. - [ ] If a build hits `fatal: reference is not a tree: cb5f173b`,
        [make the commit available on a fork and switch to it temporarily](https://github.com/dotnet/source-build/tree/release/3.1/Documentation/servicing/make-commit-available.md).
1. - [ ] Add crummel, MichaelSimons, and lbussell as reviewers.
1. - [ ] When CI is green and two reviewers approve, merge.
      - Avoid squash/rebase: nice to preserve commit hashes. However, there
        are no known dependencies on *source-build* commits being preserved.
1. - [ ] Create and push tags on the post-merge commit. [/Documentation/servicing/tagging.md](https://github.com/dotnet/source-build/tree/release/3.1/Documentation/servicing/tagging.md)
1. - [ ] Create a GitHub release on the tag with SDK versioning.
      - Go to <https://github.com/dotnet/source-build/tags>
      - Expand the SDK-versioned tag's message and copy it
      - Click `...` on the right on the SDK-versioned tag and press "Create release"
      - Paste into the release title
      - Click submit.
1. - [ ] [Source-build team] Notify distro maintainers and partners about
     the release tags
1. - [ ] Download merged Private.SourceBuilt.Artifacts.XX.tar.gz files from
     the prepare-artifacts leg in source-build-rolling-CI.
1. - [ ] Upload merged Private.SourceBuilt.Artifacts.XX.tar.gz file to dotnetcli
     account source-built-artifacts blob container.
      - Never overwrite a tarball. Use a sub-patch version if one already
        exists, e.g. `0.1.0-3.1.105.1`.
1. - [ ] If there's a respin (for any reason: source-build infra fixes or
     upstream repo problems):
      - Go back in this process checklist as far as necessary.
      - When tagging, make sure to create a new tag. A sub-patch version tag
        for SDK and runtime must be generated. E.g - v3.1.400.1-SDK
1. - [ ] Clean up retrospective notes if necessary.
