## Source-Build Prebuilt Removal Status Overview

Last source-build Build Date: 2019-09-25

Last updated: 2019-09-27

For more detailed information, see: [SourceBuildPrebuiltReport](https://msit.powerbi.com/groups/dc6359c5-e96a-44ce-9d86-0af7fab1c15e/dashboards/73f852d5-4ca7-45d7-8e5c-977c2da3b11c/reports/64e989dd-8072-4d84-8268-140bde0cbc7d/ReportSection4ba78a029c61708d6808)

<!--TrackingTable-->
| Repo/Issue | Owner | Overall Status | # of Patches | # of Prebuilts | Comments |
| :--- | :--- | :--- |  :---: | :---: | --- |
| [ApplicationInsights-dotnet][900] | Sergey Kanzhelev | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [arcade][970] | Mark Wilke | ![ot] On Track | 13 | 1 |
| [AspNetCore-Tooling][1150] | John Luo | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [AspNetCore][1150] | John Luo | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [cli][880] | Nick Guerrera | ![cp] Complete | 3 | - |  All direct-dependency prebuilts removed.
| [cliCommandLineParser][976] | Nick Guerrera | ![cp] Complete | 1 | - | All direct-dependency prebuilts removed.
| [cli-migrate][881] | Nick Guerrera | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [common][882] | John Luo | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [coreclr][883] | Jeff Schwartz | ![cp] Complete | 2 | - | All direct-dependency prebuilts removed.
| [corefx][884] | Eric St. John | ![cp] Complete | 3 | - | All direct-dependency prebuilts removed.
| [core-sdk][972] | Nick Guerrera | ![cp] Complete | 6 | - | All direct-dependency prebuilts removed.
| [core-setup][885] | Davis Goodin | ![cp] Complete | 3 | - | All direct-dependency prebuilts removed.
| [linker][887] | Dan Seefeldt | ![cp] Complete | 4 | - | All direct-dependency prebuilts removed.
| [Extensions][1132] | John Luo | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [msbuild][888] | Nick Guerrera | ![cp] Complete | 4 | - | All direct-dependency prebuilts removed.
| [Newtonsoft.Json][889] | Chris Rummel | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [NuGet.Client][890] | Rob Relyea | ![cp] Complete | 6 | - | All direct-dependency prebuilts removed.
| [roslyn][891] | Jared Parsons / Fred Silberberg | ![cp] Complete | 4 | - | All direct-dependency prebuilts removed.
| [roslyn-tools][892] | Tomas Matousek | ![cp] Complete | - | - | Repo removed
| [sdk][893] | Nick Guerrera | ![cp] Complete | 3 | - | All direct-dependency prebuilts removed.
| [source-build-infra][975] | Dan Seefeldt | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [standard][894] | Eric St. John | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [templating][895] | Vijay Ramakrishnan | ![cp] Complete | 1 | - | All direct-dependency prebuilts removed.
| [Tools][974] | Dan Seefeldt | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [toolset][973] | Nick Guerrera | ![cp] Complete | 2 | - | All direct-dependency prebuilts removed.
| [tools-local tasks][971] | Dan Seefeldt | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [fsharp][886] | Brett Forsgren | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [vstest][896] | Shiva Shankar Thangadurai / Sarabjot Singh | ![cp] Complete | 4 | - | All direct-dependency prebuilts removed.
| [websdk][897] | Vijay Ramakrishnan | ![cp] Complete | 1 | - | All direct-dependency prebuilts removed.
| xdt | John Luo | ![cp] Complete | - | - | No direct-dependency prebuilts.
| [xliff-tasks][899] | Tom Meschter | ![cp] Complete | 1 | - | All direct-dependency prebuilts removed.

<br/>

| Status   | Description |
| -------- | ----------- |
| ![ns] Not Started | Team has not started on prebuilts |
| ![pl] Planned | Prebuilts have been categorized and issues have been logged to remove |
| ![ot] On Track | Engineers are working through issues to remove prebuilts |
| ![ar] At Risk  | Prebuilt removal tasks not on track for completion or blocked |
| ![cp] Complete | All prebuilts removed |
| ![bn] Bounced | Previously complete, but new prebuilts have emerged |

[ns]: https://img.icons8.com/office/16/000000/medium-risk.png
[pl]: https://img.icons8.com/office/16/000000/gantt-chart.png
[ot]: https://img.icons8.com/office/16/000000/gps-device.png
[ar]: https://img.icons8.com/office/16/000000/high-risk.png
[cp]: https://img.icons8.com/office/16/000000/checked.png
[bn]: https://img.icons8.com/office/16/000000/return--v2.png

<br/>

<!--RepoCommitsAndDates-->
| Repo | Latest Commit | Commit Date
| --- | --- | ---
ApplicationInsights-dotnet | 53b80940842204f78708a538628288ff5d741a1d | 2017-12-21 
arcade | 8f3c22397990aeb20a88690b51dad4b33f21e7ff | 2019-07-15 
AspNetCore | aee5e4080331553ea9dfb7fb388b6d72f715bf6a | 2019-09-15 
AspNetCore-Tooling | 16b0ca4a5838c39c8852e6cf144232597e2bee2e | 2019-09-14 
cli | e72d84f73adcbfa0054df27fbb21505295a55dcb | 2019-09-17 
cliCommandLineParser | 0e89c2116ad28e404ba56c14d1c3f938caa25a01 | 2019-04-08 
common | 6e37cdfe96ac8b06a923242120169fafacd720e6 | 2018-11-02 
core-sdk | 04339c3a262a2e313f9431edd3805ce71e08b92e | 2019-09-18 
core-setup | 7d57652f33493fa022125b7f63aad0d70c52d810 | 2019-09-12 
coreclr | 922429db0144dd6f3b4324805464dae82857512a | 2019-09-12 
corefx | 4ac4c0367003fe3973a3648eb0715ddb0e3bbcea | 2019-09-12 
Extensions | 0b951c16de0f39e13cce8372e11c28eb90576662 | 2019-09-13 
fsharp | 0422ff293bb2cc722fe5021b85ef50378a9af823 | 2019-09-04 
linker | 1127689f262d52ea8ff68ef03d706fa62b3b40a1 | 2019-07-30 
msbuild | 0f4c62feac0a5726f63b56472de7b1c1527459fc | 2019-09-13 
Newtonsoft.Json | cac0690ad133c5e166ce5642dc71175791404fad | 2019-06-19 
Newtonsoft.Json | e43dae94c26f0c30e9095327a3a9eac87193923d | 2018-05-31 
NuGet.Client | b75150f2f4127a77a166c9552845e86fb24a3282 | 2019-09-17 
roslyn | 66a912c9463eebe832cf742d2fe8bb2e1a4600ec | 2019-09-12 
sdk | b3a343bf8ed65f5208c5bb86c632856c5d107b1d | 2019-09-17 
source-build-reference-packages | 857a0b4e42652ed16d839eec2f9095a5aa3737b2 | 2019-09-24 
sourcelink | 51310e65e75010467993f793e1739d1a1dad50c5 | 2019-07-01 
standard | a5b5f2e1e369972c8ff1e2183979fab6099f52ef | 2019-09-12 
templating | b2663fb07294f5d6cf3caa927d58f7cbebf7d626 | 2019-09-14 
toolset | 33026f95de81116aefd79b4ec4c8071090a02480 | 2019-09-18 
vstest | 55e7e45431c9c05656c999b902686e7402664573 | 2019-09-12 
websdk | 002ea5ca7c699d925281abd8307556ec8eccb530 | 2019-09-15 
xdt | c01a538851a8ab1a1fbeb2e6243f391fff7587b4 | 2019-04-30 
xliff-tasks | 173ee3bd61c9549557eefa3cfb718bdef157cb87 | 2019-05-02 

**Prebuilts**

Prebuilts are dependencies that a repo has on binary files that are not built from source.  All packages included in the distro are built by the distro and the source requirements are inclusive of build tools and build dependencies. The default position for inclusion in a distro is no pre-built binaries though there are proper exceptional cases to bootstrap builds.

**Patches**

Patches are created in source-build when a repo's code doesn't build as-is. Patches are required to keep source-build moving forward and building on new product builds. As patches are created, issues are opened in the corresponding repo to incorporate the code and remove the patch.

| Repo | Patch name | Type | Disposition | Responsibility | Notes | Issue
| --- | --- | --- | --- | --- | --- | ---
Repo | Patch name | Type | Disposition | Responsibility | Notes | Issue |  | 
arcade | 0001-Enable-sourcelink-in-sourcebuild.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/arcade/pull/4022 |  | 
arcade | 0002-Do-not-build-.NET-Fx-binaries-in-source-build.patch | Prebuilt | Remove | Source-build | Will be unneeded after Aditya's ref assmebly work is done | https://github.com/dotnet/arcade/pull/4047 | ProjRemoval | 8
arcade | 0003-Remove-adding-fake-dependencies-for-CoreFX-partial-p.patch | ToolCompat | SourceBuildUptake | Repo | Merged | https://github.com/dotnet/arcade/pull/3811 | Build | 9
arcade | 0004-Changing-GetLastStablePackage-logic-in-order-to-allo.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/source-build/pull/1237 | Prebuilt | 29
arcade | 0004-Import-PackageVersions-props-if-exists.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/source-build/pull/1237 | Flow | 6
arcade | 0005-Fix-packaging-targets-3857.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/source-build/pull/1237 | Bug | 5
arcade | 0005-Update-SystemNetHttpPackageVersion.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/source-build/pull/1237 | ToolCompat | 21
arcade | 0006-Allow-VersionPrefix-to-include-an-optionally-provide.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/source-build/pull/1237 | One-off | 2
arcade | 0007-Fix-missing-in-MSBuild-function-call-to-calculate-Ve.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/source-build/pull/1237 | Coherence | 0
arcade | 0008-Produce-a-non-stable-version-if-package-is-non-shipp.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/source-build/pull/1237 | No-op | 0
arcade | 0009-Switch-IsShipping-IsShippingPackage-3909.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/source-build/pull/1237 | Total | 80
arcade | 0010-Compute-IsShipping-before-version-strings-are-comput.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/source-build/pull/1237 |  | 
arcade | 0011-Adding-switch-to-UpdatePackageIndex-Task-that-will-U.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/source-build/pull/1237 |  | 
arcade | 0012-Remove-reference-to-Microsoft-CodeAnalysis-in-Packag.patch | Prebuilt | Incorporate | Repo | New |  |  | 
aspnetcore | 0001-Exclude-analyzer-for-source-build.patch | Prebuilt | Unknown | Source-build | In PR |  | Incorporate | 32
aspnetcore | 0002-Import-PackageVersions.props.patch | Flow | Remove | Source-build | Merged |  | Remove | 13
aspnetcore | 0003-Exclude-some-projects-from-source-build.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/aspnet/AspNetCore/pull/14631 | SourceBuildFix | 0
aspnetcore | 0004-Match-new-NuGet-MSBuild-version.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/aspnet/AspNetCore/pull/14631 | SourceBuildUptake | 25
aspnetcore | 0005-Fix-version-number.patch | Bug | RepoFix | Repo | In PR | https://github.com/aspnet/AspNetCore/issues/14677 | Soft-patch | 0
aspnetcore | 0006-Remove-Yarn-dependency-not-used-in-source-build.patch | Prebuilt | Unknown | Source-build | In PR | https://github.com/dotnet/source-build/issues/1276 | Unknown | 4
aspnetcore | 0007-Don-t-call-out-to-dotnet-with-no-path.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/arcade/pull/4032 | RepoRemoval | 0
aspnetcore-tooling | 0001-Import-PackageVersions.props.patch | Flow | Remove | Source-build | Merged |  | Fork | 4
aspnetcore-tooling | 0002-Pin-MSBuild-version-to-reference-versions.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/aspnet/AspNetCore-Tooling/pull/1190 | Total | 78
aspnetcore-tooling | 0003-Remove-fullfx.patch | Prebuilt | Remove | Source-build | Will be unneeded after Aditya's ref assmebly work is done | https://github.com/aspnet/AspNetCore-Tooling/pull/1191 |  | 
aspnet-extensions | 0001-Target-framework-changes.patch | Build | Remove | Source-build | Will be unneeded after Aditya's ref assmebly work is done |  |  | 
aspnet-extensions | 0002-Fix-packing-on-nix-systems.patch | Build | SourceBuildUptake | Repo | Has been upstreamed |  | Repo | 36
aspnet-extensions | 0006-Do-not-build-.NET-Fx-binaries-in-source-build.patch | Prebuilt | Incorporate | Repo |  |  | source-build | 45
aspnet-xdt | 0001-Don-t-build-tests-in-source-build.patch | ProjRemoval | Incorporate | Repo | In PR | https://github.com/aspnet/xdt/pull/164 | Unknown | 0
aspnet-xdt | 0002-Do-not-build-NET-Fx-binaries-in-source-build.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/aspnet/xdt/pull/164 | Total | 81
cli | 0002-Fix-package-version-property-name.patch | Bug | Incorporate | Repo | In PR | https://github.com/dotnet/cli/pull/12781 |  | 
cli | 0003-Don-t-call-dotnet-without-path.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/arcade/pull/4032 | Merged | 29
cli | 0005-Exclude-test-projects-from-source-build.patch | ProjRemoval | Incorporate | Repo | In PR | https://github.com/dotnet/cli/pull/12781 | In PR | 33
clicommandlineparser | 0001-Remove-test-and-sample-projects-from-solution.patch | ProjRemoval | Unknown | Source-build | CliCommandLineParser has been static for a while - was it going to be removed? |  | Possible fix | 8
coreclr | 0001-Allow-separate-tool-and-SDK-directories.patch | Build | Remove | Source-build | Merged |  | Needs research | 6
coreclr | 0007-Exclude-optdata-from-source-build.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/dotnet/source-build/pull/1277 | New | 2
corefx | 0001-Enable-sourcelink-in-source-build.patch | ToolCompat | SourceBuildUptake | Repo | Has been upstreamed |  | Total | 82
corefx | 0002-Enable-tests-for-CoreFX-in-s-b.patch | UnitTesting | Incorporate | Joint | We're not doing this the way CoreFX would prefer, so we need to work with them to find a better solution | https://github.com/dotnet/source-build/issues/1198 |  | 
corefx | 0003-Check-in-package-baseline-so-all-build-nodes-see-the.patch | Bug | Incorporate | Repo | In PR | https://github.com/dotnet/arcade/pull/4012 |  | 
corefx | 0004-Conditionally-include-runtime.native.System.Data.Sql.patch | Prebuilt | Incorporate | Repo | In PR |  |  | 
core-sdk | 0001-Exclude-test-project-from-source-build.patch | ProjRemoval | Incorporate | Repo | In PR | https://github.com/dotnet/core-sdk/pull/5072 |  | Complete or in PR
core-sdk | 0003-Don-t-add-target-rid-to-NetCoreRuntimePackRids.patch | Bug | Incorporate | Repo | In PR | https://github.com/dotnet/core-sdk/issues/5071 |  | Believe to be fixed but requires code flow
core-sdk | 0003-Fix-removing-Windows-templates-for-non-Windows-RIDs.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/dotnet/core-sdk/pull/5072 |  | Requires investigation or significant work
core-sdk | 0003-Remove-debian-package-generation.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/dotnet/core-sdk/issues/5073 |  | 
core-sdk | 0004-Patch-ASP.NET-directory.patch | Build | Remove | Source-build | Merged | https://github.com/dotnet/source-build/pull/1260 |  | 
core-sdk | 0005-Don-t-call-dotnet-without-path.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/arcade/pull/4032 |  | 
core-setup | 0001-Use-pinned-version-of-MSBuild-reference-assemblies.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/dotnet/core-setup/pull/8432 |  | 
core-setup | 0002-Try-ExcludeFromSourceBuild-in-windowsdesktop.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/dotnet/core-setup/pull/8432 |  | 
core-setup | 0003-Pin-NuGetProjectModel-to-a-specific-version.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/dotnet/core-setup/pull/8432 |  | 
fsharp | 0001-Don-t-install-old-SDK.patch | Build | Incorporate | Repo | In PR | https://github.com/dotnet/fsharp/pull/7685 |  | 
fsharp | 0002-Pin-S.R.Emit-to-a-ref-version.patch | Coherency | Remove | Source-build | Should no longer be needed |  |  | 
linker | 0001-Add-an-option-to-use-reflection-heuristics-during-ma.patch | ToolCompat | Fork | Source-build | Long-standing permanent patch; they're still talking about whether to take it | https://github.com/mono/linker/issues/626 |  | 
linker | 0002-Exclude-test-projects-from-source-build.patch | ProjRemoval | Fork | Source-build | Hard to impose this on Mono; plan to carry locally or fork |  |  | 
linker | 0003-Don-t-add-sources-when-building-offline.patch | Build | Fork | Source-build | Hard to impose this on Mono; plan to carry locally or fork |  |  | 
linker | 0004-Use-new-versions-of-MSBuild-reference-assemblies.patch | Prebuilt | Fork | Source-build | Hard to impose this on Mono; plan to carry locally or fork |  |  | 
msbuild | 0001-Do-not-build-for-.NET-Fx-in-source-build.patch | Prebuilt | Remove | Source-build | Will be unneeded after Aditya's ref assmebly work is done |  |  | 
msbuild | 0002-Add-Microsoft.Build.Localization-to-msbuild-for-sour.patch | Prebuilt | SourceBuildUptake | Repo | Has been upstreamed | https://github.com/microsoft/msbuild/pull/4777 |  | 
msbuild | 0003-Remove-dotnet-call-with-no-path.patch | ToolCompat | SourceBuildUptake | Source-build | Merged | https://github.com/dotnet/arcade/pull/4032 |  | 
msbuild | 0003-Source-build-should-use-prebuilt-System.CodeDom-and-.patch | Prebuilt | SourceBuildUptake | Source-build | Has been upstreamed |  |  | 
nuget-client | 0002-Dont-include-extra-CoreCLR-DLLs.patch | Build | Unknown | Source-build | Will be needed until we can do ILMerge in source-build |  |  | 
nuget-client | 0002-MSBuild-package-versions-for-dotnet-Source-Build-285.patch | Flow | SourceBuildUptake | Source-build | Has been upstreamed |  |  | 
nuget-client | 0003-Pin-newtonsoft-json-to-a-specific-version.patch | Prebuilt | SourceBuildUptake | Source-build | In PR | https://github.com/NuGet/NuGet.Client/pull/3067/files |  | 
nuget-client | 0004-Removed-unneeded-feeds.patch | Build | SourceBuildUptake | Source-build | In PR | https://github.com/NuGet/NuGet.Client/pull/3067/files |  | 
nuget-client | 0005-New-version-of-ref-assemblies.patch | Prebuilt | SourceBuildUptake | Source-build | In PR | https://github.com/NuGet/NuGet.Client/pull/3067/files |  | 
nuget-client | 0006-Do-not-build-NET-Fx-binaries-in-source-build.patch | Prebuilt | Remove | Source-build | Will be unneeded after Aditya's ref assmebly work is done | https://github.com/NuGet/NuGet.Client/pull/3067/files |  | 
roslyn | 0001-Conditionally-remove-net472-from-TargetFrameworks.patch | Prebuilt | Remove | Source-build | Will be unneeded after Aditya's ref assmebly work is done | https://github.com/dotnet/roslyn/pull/39026 |  | 
roslyn | 0002-Fix-switch-expression-for-preview8-SDK.patch | ToolCompat | SouceBuildUptake | Source-build | Fixed by SDK update |  |  | 
roslyn | 0003-Do-not-build-NET-Fx-binaries-in-source-build.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/dotnet/roslyn/pull/39026 |  | 
roslyn | 0004-Import-PackageVersions-props-if-exists.patch | Flow | Remove | Source-build | Merged |  |  | 
sdk | 0001-Add-missing-PlatformAbstractions-reference.patch | Bug | Incorporate | Repo | Chris to open PR |  |  | 
sdk | 0002-Use-ref-only-msbuild-packages.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/dotnet/sdk/pull/3709 |  | 
sdk | 0003-Don-t-call-dotnet-without-path.patch | ToolCompat | SourceBuildUpdtake | Source-build | Merged | https://github.com/dotnet/arcade/pull/4032 |  | 
sourcelink | 0001-Exclude-test-projects.patch | ProjRemoval | Incorporate | Repo | In PR | https://github.com/dotnet/sourcelink/pull/431 |  | 
sourcelink | 0002-Do-not-build-and-package-.NET-Fx-binaries-in-source-.patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/dotnet/sourcelink/pull/431 |  | 
templating | 0001-Don-t-call-dotnet-with-no-path.patch | ToolCompat | SourceBuildUpdtake | Source-build | Same as aspnetcore #0007 | https://github.com/dotnet/arcade/pull/4032 |  | 
toolset | 0001-Exclude-test-projects-from-source-build.patch | ProjRemoval | Incorporate | Repo | In PR | https://github.com/dotnet/toolset/pull/3050 |  | 
toolset | 0002-Remove-WindowsDesktop-dependency.patch | ProjRemoval | Incorporate | Repo | In PR | https://github.com/dotnet/toolset/pull/3050 |  | 
vstest | 0001-Update-vstest-build-script-to-add-binlogs.patch | One-off | Incorporate | Repo | In PR | https://github.com/microsoft/vstest/pull/2211 |  | 
vstest | 0002-Remove-reference-to-System.Runtime.CompilerServices..patch | Prebuilt | Incorporate | Repo | In PR | https://github.com/microsoft/vstest/pull/2211 |  | 
vstest | 0003-Update-the-license-for-nuget-packages-to-point-to-MI.patch | One-off | Incorporate | Repo | Issue logged | https://github.com/microsoft/vstest/issues/2212 |  | 
vstest | 0004-Fix-Extensions-FileSystemGlobbing-version.patch | Flow | Incorporate | Repo | In PR | https://github.com/microsoft/vstest/pull/2211 |  | 
websdk | 0001-Add-PVP-import.patch | Flow | Remove | Source-build | Merged |  |  | 
xliff-tasks | 0001-Remove-unneeded-feeds.patch | Build | SourceBuildUptake | Source-build | Has been upstreamed |  |  | 


**Repo BAR status**

The Build Asset Registry is used to inform source-build about what version of each repo we want to build.  Publishing to BAR is simple for Arcade repos.  We also have an example build that publishes to BAR without Arcade: https://github.com/dotnet/source-build-reference-packages/blob/master/eng/common/templates/job/publish-build-assets.yml.

Not publishing to BAR, not planning to be:
- application-insights (not owned by us and doesn't change often)
- aspnet/common (obsolete)
- newtonsoft-json (not owned by us)


<!--StartOfIssuesList-->
[900]: https://github.com/dotnet/source-build/issues/900
[970]: https://github.com/dotnet/source-build/issues/970
[880]: https://github.com/dotnet/source-build/issues/880
[881]: https://github.com/dotnet/source-build/issues/881
[976]: https://github.com/dotnet/source-build/issues/976
[882]: https://github.com/dotnet/source-build/issues/882
[883]: https://github.com/dotnet/source-build/issues/883
[884]: https://github.com/dotnet/source-build/issues/884
[972]: https://github.com/dotnet/source-build/issues/972
[885]: https://github.com/dotnet/source-build/issues/885
[886]: https://github.com/dotnet/source-build/issues/886
[887]: https://github.com/dotnet/source-build/issues/887
[888]: https://github.com/dotnet/source-build/issues/888
[889]: https://github.com/dotnet/source-build/issues/889
[890]: https://github.com/dotnet/source-build/issues/890
[891]: https://github.com/dotnet/source-build/issues/891
[892]: https://github.com/dotnet/source-build/issues/892
[893]: https://github.com/dotnet/source-build/issues/893
[894]: https://github.com/dotnet/source-build/issues/894
[895]: https://github.com/dotnet/source-build/issues/895
[975]: https://github.com/dotnet/source-build/issues/975
[971]: https://github.com/dotnet/source-build/issues/971
[973]: https://github.com/dotnet/source-build/issues/973
[974]: https://github.com/dotnet/source-build/issues/974
[896]: https://github.com/dotnet/source-build/issues/896
[897]: https://github.com/dotnet/source-build/issues/897
[899]: https://github.com/dotnet/source-build/issues/899
[1132]: https://github.com/dotnet/source-build/issues/1132
[1150]: https://github.com/dotnet/source-build/issues/1150
