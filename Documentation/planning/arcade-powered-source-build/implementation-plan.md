# Source-build 5.0 Implementation Plan

To get each repo building with the new source-build 5.0 plan, [Arcade-Powered Source-Build](https://github.com/dotnet/source-build/tree/release/3.1/Documentation/planning/arcade-powered-source-build), the following stages will be accomplished.  Below, the repos are placed in a table representing the earliest dependencies are available and work can begin.  Stages can be completed in parallel, but stage 4 may depend on output from stage 6 from previous repos.  The following graph and table will be used to track progress for each repo.

> ![](img/implementation-plan-graph.png)
> [source (img/implementation-plan-graph.dgml)](img/implementation-plan-graph.dgml)

| Tier | Repo | (1) Build from source - 5.0 | (2) Patch Removal | (3) Move build params to eng dir | (4) Input Intermediate Packages Available | (5) Official build | (6) Source-build PR validation | (7) Prebuilt check / enforcement |
| --- | --- | :---: | :---: | :---: | :---: | :---: | :---: | :---: |
| sbrp | Source-build-reference-packages | X | - | | | | | |
| Tools | sourcelink | X | 4 | | | | | |
| Tools | arcade | X | 11 | | | | | |
| 1 | application-insights | X | - | | | | | |
| 1 | aspnet-xdt | X | 2 | | | | | |
| 1 | newtonsoft-json | X | - | | | | | |
| 1 | netcorecli-fsc | X | - | | | | | |
| 1 | newtonsoft-json901 | X | - | | | | | |
| 1 | xliff-tasks | X | 1 | | | | | |
| 1 | clicommandlineparser | X | 1 | | | | | |
| 1 | roslyn | X | 4 | | | | | |
| 2 | linker | X | 3 | | | | | |
| 2 | runtime | X | 10 | | | | | |
| 2 | msbuild | X | 4 | | | | | |
| 2 | nuget-client | X | 8 | | | | | |
| 3 | extensions |  | 1 | | | | | |
| 3 | aspnetcore-tooling |  | 3 | | | | | |
| 3 | aspnetcore |  | 11 | | | | | |
| 3 | websdk |  | 1 | | | | | |
| 2 | templating |  | - | | | | | |
| 4 | sdk |  | 2 + 3(cli) + 3(toolset) | | | | | |
| 4 | vstest |  | 6 | | | | | |
| 4 | fsharp |  | 2 | | | | | |
| 5 | installer |  | 5 | | | | | |

## Stage descriptions:
  - **(1) Build from Source 5.0** – Get repo building from source with 5.0 source
  - **(2) Patch Removal** – Incorporate patches required to build from source into the repo code base.
  - **(3) Move Build Params to Eng Dir** – All source-build specific build parameter from repos/<reponame>.proj moved from source-build repo to repo /eng directory.
  - **(4) Input Intermediate Packages Available** – Indicates upstream intermediate packages are available, and work on this repo can begin.
  - **(5) Official build** – Repo builds in official build, producing source-built intermediate packages.
  - **(6) Source-build PR validation** – Azdo build jobs are added to ensure build-from-source continues running
  - **(7) Prebuilt check / enforcement** – Adds a check to PR validation to ensure that no prebuilts are included when building repo
