## Source-Build Prebuilt Removal Status Overview

Last source-build Build Date: 2019-06-06

Last updated: 2019-06-06

For more detailed information, see: [SourceBuildPrebuiltReport](https://msit.powerbi.com/groups/dc6359c5-e96a-44ce-9d86-0af7fab1c15e/dashboards/73f852d5-4ca7-45d7-8e5c-977c2da3b11c/reports/64e989dd-8072-4d84-8268-140bde0cbc7d/ReportSection4ba78a029c61708d6808)

<!--TrackingTable-->
| Repo/Issue | Owner | Overall Status | # of Patches | # of Prebuilts | Comments |
| :--- | :--- | :--- |  :---: | :---: | --- |
| [ApplicationInsights-dotnet][900] | Sergey Kanzhelev | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [arcade][970] | Mark Wilke | ![ot] On Track | 5 | 7 |
| [cli][880] | Nick Guerrera | ![cp] Complete | 9 | - | All direct-dependency prebuilts removed.
| [cliCommandLineParser][976] | Nick Guerrera | ![cp] Complete | 3 | - | All direct-dependency prebuilts removed.
| [cli-migrate][881] | Nick Guerrera | ![ot] On Track | 7 | 1 |
| [common][882] | Nate McMaster | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [coreclr][883] | Russ Keldorph | ![ot] On Track | 1 | 4 |
| [corefx][884] | Eric St. John | ![ot] On Track | 1 | 12 |
| [core-sdk][972] | Nick Guerrera | ![ot] On Track | 5 | 4 |
| [core-setup][885] | Davis Goodin | ![ot] On Track | 4 | 13 |
| [linker][887] | Dan Seefeldt | ![ot] On Track | 2 | 2 |
| [msbuild][888] | Nick Guerrera | ![ot] On Track | 3 | 9 |
| [Newtonsoft.Json][889] | Chris Rummel | ![cp] Complete | 1 | - | All direct-dependency prebuilts removed.
| [NuGet.Client][890] | Rob Relyea | ![ot] On Track | 3 | 1 |
| [roslyn][891] | Jared Parsons / Fred Silberberg | ![ot] On Track | 2 | 16 |
| [roslyn-tools][892] | Tomas Matousek | ![cp] Complete | - | - | Repo removed
| [sdk][893] | Nick Guerrera | ![ot] On Track | 3 | 2 |
| [source-build-infra][975] | Dan Seefeldt | ![ot] On Track | - | 2 |
| [standard][894] | Eric St. John | ![ot] On Track | - | 2 |
| [templating][895] | Vijay Ramakrishnan | ![ot] On Track | 3 | 3 |
| [Tools][974] | Dan Seefeldt | ![ot] On Track | - | 4 |
| [toolset][973] | Nick Guerrera | ![ot] On Track | 1 | 4 |
| [tools-local tasks][971] | Dan Seefeldt | ![ot] On Track | - | 2 |
| [visualfsharp][886] | Brett Forsgren | ![ot] On Track | - | 4 |
| [vstest][896] | Shiva Shankar Thangadurai / Sarabjot Singh | ![pl] Planned | 2 | 7 |
| [websdk][897] | Vijay Ramakrishnan | ![ot] On Track | 1 | 7 |
| [xliff-tasks][899] | Tom Meschter | ![ot] On Track | 1 | 2 |

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
ApplicationInsights-dotnet | 53b80940842204f78708a538628288ff5d741a1d | 2017-12-21
arcade | 5e7ce5b394f3477bb0a485a4b761b7742e95be37 | 2019-04-18
cli | 25e4d0da1b94e04ff54f8aca8d459ed39ee77450 | 2019-04-27
cli-migrate | 37e3a01aa1df320a286b0a858876f9994fb6bb18 | 2019-01-24
cliCommandLineParser | 0e89c2116ad28e404ba56c14d1c3f938caa25a01 | 2019-04-08
common | 6e37cdfe96ac8b06a923242120169fafacd720e6 | 2018-11-02
core-sdk | b487ff10aafb8b58eaa2b78a236b1e97999d7a22 | 2019-04-28
core-setup | d91d79a051ec5a5577613b52a9c1aeaccc91d673 | 2019-05-31
coreclr | 4895a06c0dcc5d13f75dd55bdce83f7792d72ba4 | 2019-04-22
corefx | d06ce9d2116cb4bda528822e63d32ce3735ea653 | 2019-04-24
linker | c09c490012b1e11cf6d52a6c6a486d4dc5f401bc | 2019-04-18
msbuild | 62fb89029dac66f73a5ca52363fd11b36f12190b | 2019-04-23
Newtonsoft.Json | e43dae94c26f0c30e9095327a3a9eac87193923d | 2018-05-31
NuGet.Client | 10c6fc8eeee07637c6c97b0ce08ab211ff502c0f | 2019-05-23
roslyn | 79b8271f65609b23e0c0ee1babed6862b7c5ed56 | 2019-04-16
sdk | 7af4517bbcf17b000889c1077ef5976f2b6350ea | 2019-04-25
source-build-reference-packages | 4c0cb49e977ff4a1308875f9c4c3dcb2a5869cb6 | 2019-05-23
standard | 5eee83eaa61eff38f470dc690218bebf73f46e23 | 2019-04-22
templating | e854a58b469c2b4a660fc6e448657d1dd8e40ab9 | 2019-04-19
toolset | a63c2959705e3c01a6c4088aa97bd2690f741fb5 | 2019-04-28
visualfsharp | d1cc85ed116e037fe6e38fc270f9c47c72185806 | 2019-04-19
vstest | 402060be01b134aea1546d3cc3a779ff4d651c5d | 2019-05-16
websdk | caf15dc7949fcfd249f33db1f7027da8fa78fc8b | 2019-04-27
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
