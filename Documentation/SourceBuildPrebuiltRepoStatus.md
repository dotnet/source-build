## Source-Build Prebuilt Removal Status Overview

Last source-build Build Date: 2019-05-09

Last updated: 2019-05-21

For more detailed information, see: [SourceBuildPrebuiltReport](https://msit.powerbi.com/groups/dc6359c5-e96a-44ce-9d86-0af7fab1c15e/dashboards/73f852d5-4ca7-45d7-8e5c-977c2da3b11c/reports/64e989dd-8072-4d84-8268-140bde0cbc7d/ReportSection4ba78a029c61708d6808)

<!--TrackingTable-->
| Repo/Issue | Owner | Overall Status | # of Patches | # of Prebuilts | Comments |
| :--- | :--- | :--- |  :---: | :---: | --- |
| [application-insights][900] | Sergey Kanzhelev | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [arcade][970] | Mark Wilke | ![ot] On Track | 7 | 7 |
| [cli][880] | Nick Guerrera | ![ot] On Track | 8 | 1 |
| [clicommandlineparser][976] | Nick Guerrera | ![cp] Complete | 3 | - | All direct-dependency prebuilts removed.
| [cli-migrate][881] | Nick Guerrera | ![ot] On Track | 7 | 1 |
| [common][882] | Nate McMaster | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [coreclr][883] | Russ Keldorph | ![ot] On Track | 1 | 4 |
| [corefx][884] | Eric St. John | ![ot] On Track | 1 | 12 |
| [core-sdk][972] | Nick Guerrera | ![ot] On Track | 5 | 5 |
| [core-setup][885] | Davis Goodin | ![ot] On Track | 4 | 12 |
| [fsharp][886] | Brett Forsgren | ![ot] On Track | - | 8 |
| [linker][887] | Dan Seefeldt | ![ot] On Track | 1 | 2 |
| [msbuild][888] | Nick Guerrera | ![pl] Planned | 3 | 7 |
| [newtonsoft-json][889] | Chris Rummel | ![cp] Complete | 1 | - | All direct-dependency prebuilts removed.
| [nuget-client][890] | Rob Relyea | ![pl] Planned | 2 | 8 |
| [roslyn][891] | Jared Parsons / Fred Silberberg | ![pl] Planned | 2 | 16 |
| [roslyn-tools][892] | Tomas Matousek | ![cp] Complete | - | - | Repo removed
| [sdk][893] | Nick Guerrera | ![ot] On Track | 2 | 2 |
| [source-build-infra][975] | Dan Seefeldt | ![pl] Planned | - | 2 |
| [standard][894] | Eric St. John | ![ot] On Track | - | 2 |
| [templating][895] | Vijay Ramakrishnan | ![pl] Planned | 3 | 3 |
| [Tools][974] | Dan Seefeldt | ![pl] Planned | - | 4 |
| [toolset][973] | Nick Guerrera | ![pl] Planned | 5 | 4 |
| [tools-local tasks][971] | Dan Seefeldt | ![pl] Planned | - | 2 |
| [vstest][896] | Shiva Shankar Thangadurai / Sarabjot Singh | ![pl] Planned | 2 | 20 |
| [websdk][897] | Vijay Ramakrishnan | ![pl] Planned | 3 | 7 |
| [xliff-tasks][899] | Tom Meschter | ![pl] Planned | 1 | 2 |

<br/>

| Status   | Description |
| -------- | ----------- |
| ![ns] Not Started | Team has not started on prebuilts |
| ![pl] Planned | Prebuilts have been categorized and issues have been logged to remove |
| ![ot] On Track | Engineers are working through issues to remove prebuilts |
| ![ar] At Risk  | Prebuilt removal tasks not on track for completion or blocked |
| ![cp] Complete | All prebuilts removed |

[ns]: https://img.icons8.com/office/16/000000/medium-risk.png
[pl]: https://img.icons8.com/office/16/000000/gantt-chart.png
[ot]: https://img.icons8.com/office/16/000000/gps-device.png
[ar]: https://img.icons8.com/office/16/000000/high-risk.png
[cp]: https://img.icons8.com/office/16/000000/checked.png

<br/>

<!--RepoCommitsAndDates-->
| Repo | Latest Commit | Commit Date
| --- | --- | ---
application-insights | 53b80940842204f78708a538628288ff5d741a1d | 2017-12-21
arcade | 4217db4a23ffd15abb3771d635b66162994fb9e4 | 2019-04-05
cli | 204f425b6f061d0b8a01faf46f762ecf71436f68 | 2019-04-12
cli-migrate | 37e3a01aa1df320a286b0a858876f9994fb6bb18 | 2019-01-24
clicommandlineparser | 0e89c2116ad28e404ba56c14d1c3f938caa25a01 | 2019-04-08
common | 6e37cdfe96ac8b06a923242120169fafacd720e6 | 2018-11-02
core-sdk | 118dd862c853ff39694449ac303f5d8ef7d11b24 | 2019-04-16
core-setup | ee54d4cbd2b305eadf6f341bdc9d4abccdb50559 | 2019-04-16
coreclr | d833cacabd67150fe3a2405845429a0ba1b72c12 | 2019-04-12
corefx | dc522ef97fac72e64cd74825b7ef497f82af4624 | 2019-04-12
fsharp | d4e68aef7fa3507d38dd7fe4eca287fc40dd46ce | 2019-04-17
linker | 1b3d8bc8eb5dd3678dd91eb08157c885336aaea0 | 2019-03-14
msbuild | d004974104fde202e633b3c97e0ece3287aa62f9 | 2019-04-05
newtonsoft-json | e43dae94c26f0c30e9095327a3a9eac87193923d | 2018-05-31
nuget-client | 27af96bdb7ba8d6d7ea9ad53fc76cd1d1aa80703 | 2019-03-29
roslyn | 01f3eb103049e2c93e0516c7d50908031deaca74 | 2019-04-09
sdk | 814b7898f9908a88f62706331cf56f1ecc9745eb | 2019-04-10
standard | 8ef5ada20b5343b0cb9e7fd577341426dab76cd8 | 2019-04-08
templating | 0fd9a865045026041f2ea4942eb8c91782193078 | 2019-04-08
toolset | 3165b2579582b6b44aef768c01c3cc9ff4f0bc17 | 2019-04-16
vstest | df96f832f28de9798bf3a1b2d6b7933439e00ae4 | 2018-08-07
websdk | b55d4f4cf22bee7ec9a2ca5f49d54ebf6ee67e83 | 2019-04-16
xliff-tasks | 27d43b762aa6dac3a0a6ba48fe55000942d75c1c | 2017-06-23

**Prebuilts**

Prebuilts are dependencies that a repo has on binary files that are not built from source.  All packages included in the distro are built by the distro and the source requirements are inclusive of build tools and build dependencies. The default position for inclusion in a distro is no pre-built binaries though there are proper exceptional cases to bootstrap builds.

**Patches**

Patches are created in source-build when a repo's code doesn't build as-is. Patches are required to keep source-build moving forward and building on new product builds. As patches are created, issues are opened in the corresponding repo to incorporate the code and remove the patch

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
