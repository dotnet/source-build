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

| Patch name | Status| Type | Disposition | Responsibility | Notes | Issue
| --- | --- | --- | --- | --- | --- | ---
arcade/0001-Fix-InternalsVisibleTo-generation.patch | ![cp] Merged | One-off | Incorporate | source-build | Patch was needed only for cli-migrate signing issues.  Have PR out to Arcade anyway as it's a reasonable fix.
arcade/0002-Exclude-test-projects-from-source-build.patch | ![cp] Fixed upstream | ProjRemoval | Incorporate | Repo |  | https://github.com/dotnet/arcade/issues/3014
arcade/0003-Remove-projects-that-increased-prebuilts.patch | ![cp] Merged | ProjRemoval | Incorporate | Repo |  | 
arcade/0004-Use-alternate-workaround-for-bootstrapping-Arcade.patch | ![ns] No action | One-off | Soft-patch | source-build | Allows us to use the bootstrap version of arcade.  Will be fixed eventually by toolset bootstrapping. | 
aspnet-razor/0001-Remove-Internal.AspNetCore.Sdk-avoid-prebuilt.patch | ![cp] Not needed | Prebuilt | Incorporate | Repo |  | 
aspnet-razor/0002-Add-reference-assemblies-to-allow-net46-build.patch | ![cp] Not needed | Build | Incorporate | Repo |  | 
cli/0001-Implement-PVP-repo-API.patch | ![cp] Fixed upstream | Flow | Incorporate | Repo |  | https://github.com/dotnet/cli/issues/11518
cli/0002-Exclude-test-projects-from-source-build.patch | ![cp] Fixed upstream | ProjRemoval | Incorporate | Repo |  | 
cli/0003-Add-repo-specific-target-emptying-file.patch | ![ot] In PR | Build | Incorporate | Repo |  | 
cli/0004-Consolidate-Newtonsoft.Json-versions.patch | ![pl] Needs upstream fix | No-op | Remove | source-build | Rebased after CLI took the fix but due to a whitespace diff this patch remained although it does nothing. | 
cli/0005-Disable-signing.patch | ![cp] Fixed upstream | Build | Repo | source-build |  | 
cli/0006-Remove-keys-from-InternalsVisibleTo.patch | ![cp] Fixed upstream | Build | Repo | source-build |  | 
cli/0007-Consolidate-CommandLine-versions.patch | ![cp] Removed | Bug | RepoRemoval | Repo | This was an additional workaround for the cli-migrate signing issue and should go away when that does. | 
cli/0008-Add-LangVersion-to-CLI.patch | ![pl] May no longer be needed | ToolCompat | Remove | source-build |  | 
cli/0009-Revert-to-using-Newtonsoft.Json.patch | ![cp] Removed | ToolCompat | Remove | source-build |  | 
clicommandlineparser/0001-Remove-test-and-sample-projects-from-solution.patch | ![cp] Fixed upstream | ProjRemoval | Incorporate | Repo |  | 
clicommandlineparser/0002-Add-PackageProjectUrl-to-avoid-new-SDK-warning.patch | ![cp] Not needed | ToolCompat | Remove | source-build |  | 
clicommandlineparser/0003-Ignore-LicenseUrl-warning.patch | ![cp] Not needed | ToolCompat | Remove | source-build |  | 
cli-migrate/0001-Ignore-NU5125-warning-error-for-2.1.500-SDK.patch | ![cp] Repo removed | ToolCompat | RepoRemoval | source-build |  | 
cli-migrate/0002-Partial-revert-of-0943def486e13fb376c7cc4a78ff2f9d82.patch | ![cp] Repo removed | ToolCompat | RepoRemoval | source-build |  | 
cli-migrate/0003-Remove-test-projects-from-build.patch | ![cp] Repo removed | ProjRemoval | RepoRemoval | source-build |  | 
cli-migrate/0004-Add-PackageProjectUrl-to-fix-warning.patch | ![cp] Repo removed | ToolCompat | RepoRemoval | source-build |  | 
cli-migrate/0005-add-PVP-import.patch | ![cp] Repo removed | Flow | RepoRemoval | source-build |  | 
cli-migrate/0006-fix-package-version-properties.patch | ![cp] Repo removed | Flow | RepoRemoval | source-build |  | 
cli-migrate/0007-Add-LicenseExpression-for-new-warning.patch | ![cp] Repo removed | ToolCompat | RepoRemoval | source-build |  | 
coreclr/0001-Allow-separate-tool-and-SDK-directories.patch | ![ot] Working with Jarret | Build | Incorporate | Repo |  | https://github.com/dotnet/coreclr/issues/25058
corefx/0001-Remove-publishing-package-that-source-build-doesn-t-.patch | ![cp] Merged | Build | Incorporate | Repo |  | https://github.com/dotnet/corefx/issues/38412
core-sdk/0001-Don-t-reset-blob-URL-if-we-pass-it-in.patch | ![cp] Merged | Build | Incorporate | Repo |  | https://github.com/dotnet/core-sdk/issues/2398
core-sdk/0002-Don-t-copy-over-packages-if-there-are-no-packages-to.patch | ![cp] Merged | Build | Incorporate | Repo |  | 
core-sdk/0003-Remove-test-projects-from-solution.patch | ![cp] Fixed upstream | ProjRemoval | Incorporate | Repo |  | 
core-sdk/0004-Add-PVP-import.patch | ![cp] Fixed upstream | Flow | Incorporate | Repo |  | 
core-sdk/0005-Allow-specifying-CoreSetupRid.patch | ![cp] Merged | Build | Incorporate | Repo |  | 
core-setup/0001-Copy-run.cmd-changes-from-corefx.patch | ![pl] In progress | Build | Remove | Repo | This will go away once core-setup switches to Arcade. | https://github.com/dotnet/core-setup/issues/6762
core-setup/0002-Disable-licenseUrl-warning.patch | ![cp] No longer needed | ToolCompat | Remove | source-build |  | 
core-setup/0003-Disable-overriding-CentOS-as-RHEL.patch | ![pl] In progress | Bug | Incorporate | Repo | | 
core-setup/0003-Import-dependencies-props-after-eng-Versions-props.patch | ![pl] In progress | Flow | Incorporate | Repo | May also go away with the Arcade switch. | 
linker/0001-Add-an-option-to-use-reflection-heuristics-during-ma.patch | ![ns] No action | One-off | Fork | source-build | Patches in a feature needed by other repos that the maintainers rejected a PR for. | 
linker/0002-Exclude-test-projects-from-source-build.patch | ![ns] No action | ProjRemoval | Fork | source-build |  | 
msbuild/0001-Add-PackageLicenseExpression.patch | ![cp] No longer needed | ToolCompat | Remove | source-build |  | https://github.com/microsoft/msbuild/issues/4428
msbuild/0002-Enable-full-framework-builds-for-SDK.patch | ![pl] Needs ref asm | Build | Remove | source-build |  | 
msbuild/0003-Don-t-overwrite-source-build-s-MS.NETCore.Compilers-.patch | ![cp] Fixed upstream | Flow | Incorporate | Repo |  | 
nuget-client/0001-Update-Reference-Assemblies-package-to-get-net472-ve.patch | ![ot] Working with Fernando | Build | Incorporate | Repo |  | https://github.com/NuGet/Home/issues/8214
nuget-client/0002-use-netcoreapp2.1-to-match-netstandard.patch | ![cp] Removed | One-off | Remove | source-build |  | 
nuget-client/0003-Add-roslyn-tools-restore-source-back-to-NuGet.Config.patch | ![ns] No action | ToolCompat | Remove | source-build |  | 
roslyn/0001-Don-t-append-description-from-source-information-bec.patch | ![pl] Needs SourceLink uptake | Build | Incorporate | source-build | | https://github.com/dotnet/source-build/issues/1075
roslyn/0002-Add-repository-properties-for-new-SDK-warning.patch | ![cp] No longer needed | ToolCompat | Remove | source-build |  | 
sdk/0001-Upgrade-to-netcoreapp2.1.patch | ![ot] In PR | ToolCompat | Unknown | source-build |  | https://github.com/dotnet/sdk/issues/3317
sdk/0002-Add-missing-PlatformAbstractions-reference.patch | ![pl] Nick believes unneeded | Bug | Incorporate | source-build |  | 
sdk/0003-Consolidate-versions.patch | ![pl] Nick believes unneeded | Coherence | Incorporate | source-build |  | 
templating/0001-Don-t-build-test-projects-when-building-from-source.patch | ![ot] Being worked on | ProjRemoval | Incorporate | Repo |  | https://github.com/dotnet/templating/issues/1927
templating/0002-Fix-casing-in-template-projects.patch | ![cp] Fixed upstream | Bug | Incorporate | Repo |  | 
templating/0003-Use-source-built-version-of-Newtonsoft.Json.patch | ![ot] Talking about correct fix | Flow | Incorporate | Repo |  | 
toolset/0001-Exclude-test-projects-from-source-build.patch | ![cp] Fixed upstream | ProjRemoval | Incorporate | Repo |  | https://github.com/dotnet/toolset/issues/1178
vstest/0001-Conditionally-remove-uap-from-TargetFramework-and-co.patch | ![pl] Talking about correct fix | Build | Incorporate | Repo |  | https://github.com/microsoft/vstest/issues/2050
vstest/0002-Remove-unneccessary-projects-from-sln.patch | ![pl] Talking about correct fix | ProjRemoval | Incorporate | Repo |  | 
websdk/0001-Remove-test-project.patch | ![cp] Merged | ProjRemoval | Incorporate | Repo |  | https://github.com/aspnet/websdk/issues/702
xliff-tasks/0001-Hardcode-version-until-we-fix-Arcade.patch | ![ot] In progress on our side | Build | SourceBuildFix | source-build |  | https://github.com/dotnet/source-build/issues/1076


**Repo BAR status**

The Build Asset Registry is used to inform source-build about what version of each repo we want to build.  Publishing to BAR is simple for Arcade repos.  We also have an example build that publishes to BAR without Arcade: https://github.com/dotnet/source-build-reference-packages/blob/master/eng/common/templates/job/publish-build-assets.yml.

Not publishing to BAR, not planning to be:
- application-insights (not owned by us and doesn't change often)
- aspnet/common (obsolete)
- newtonsoft-json (not owned by us)

Not on Arcade or BAR:
- VSTest

On Arcade but not BAR:
- xliff-tasks (https://github.com/dotnet/xliff-tasks/issues/114)


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
