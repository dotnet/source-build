# Arcade-powered source-build implementation plan

To get each repo building with the new source-build sustainability plan, [Arcade-Powered Source-Build](./README.md), each repo will go through several stages. Some stages have dependencies on upstream repos, so this process will be completed in dependency order with some exceptions.

Below, the repo status is in a graph to show the dependencies and make it easy to tell which repos are ready to work on. There's also a table, for searchable and more detailed status. These will both be kept up to date.

> ![](https://pointillism.io/dotnet/source-build/blob/master/Documentation/planning/arcade-powered-source-build/img/implementation-plan-graph.dot.svg)  
> [source (img/implementation-plan-graph.dot)](img/implementation-plan-graph.dot)

| Tier | Repo | Owner | Input intermediate packages available | (Stage 1)<br>Local build infra merged | (Stage 2)<br>CI implemented | (Stage 3)<br>Artifacts greenlit | (Stage 4)<br>Prebuilt regressions blocked |
| --- | --- | --- | :---: | :---: | :---: | :---: | :---: |
| sbrp | [source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages) | [Dan Seefeldt](https://github.com/dseefeld) | ✔️ | ✔️ | ✔️ | ✔️ | |
| Tools | [sourcelink](https://github.com/dotnet/sourcelink) | [Tomas Matousek](https://github.com/tmat) | ✔️ | ✔️ | ✔️ | ✔️ | |
| Tools | [arcade](https://github.com/dotnet/arcade) | [Mark Wilkie](https://github.com/markwilkie) | ✔️ | ✔️ | ✔️ | ✔️ | |
| 1 | *[application-insights](https://github.com/dotnet/source-build/tree/master/src)*<sup>1</sup> | ? | ✔️ | ✔️ | ✔️ | ✔️ | |
| 1 | *[cssparser](https://github.com/dotnet/source-build/tree/master/src)*<sup>1</sup> | ? | ✔️ | ✔️ | ✔️ | ✔️ | |
| 1 | *[humanizer](https://github.com/dotnet/source-build/tree/master/src)*<sup>1</sup> | ? | ✔️ | ✔️ | ✔️ | ✔️ | |
| 1 | *[netcorecli-fsc](https://github.com/dotnet/source-build/tree/master/src)*<sup>1</sup> | [Chris Rummel](https://github.com/crummel) | ✔️ | ✔️ | ✔️ | ✔️ | |
| 1 | *[newtonsoft-json](https://github.com/dotnet/source-build/tree/master/src)*<sup>1</sup> | [Chris Rummel](https://github.com/crummel) | ✔️ | ✔️ | ✔️ | ✔️ | |
| 1 | *[newtonsoft-json901](https://github.com/dotnet/source-build/tree/master/src)*<sup>1</sup> | [Chris Rummel](https://github.com/crummel) | ✔️ | ✔️ | ✔️ | ✔️ | |
| 1 | [aspnet-xdt](https://github.com/dotnet/xdt) | [Vijay Ramakrishnan](https://github.com/vijayrkn) | ✔️ | ✔️ | ✔️ | | |
| 1 | [clicommandlineparser](https://github.com/dotnet/clicommandlineparser) | [Sarah Oslund](https://github.com/sfoslund) | ✔️ | ✔️ | | | |
| 1 | [command-line-api](https://github.com/dotnet/command-line-api) | ? | ✔️ | ⏱ [PR](https://github.com/dotnet/command-line-api/pull/1204) | | | |
| 1 | [diagnostics](https://github.com/dotnet/diagnostics) | [Juan Hoyes](https://github.com/hoyosjs) | ✔️ | ✔️ | | | |
| 1 | [roslyn](https://github.com/dotnet/roslyn) | [Fred Silberberg](https://github.com/333fred) | | ⏱ | | | |
| 1 | [symreader](https://github.com/dotnet/symreader) | [Tomas Matousek](https://github.com/tmat) | ✔️ | ✔️ | ✔️ | | |
| 1 | [test-templates](https://github.com/dotnet/test-templates) | ? | ✔️ | ✔️ | ✔️ | ✔️ | |
| 1 | [xliff-tasks](https://github.com/dotnet/xliff-tasks) | [Mark Wilkie](https://github.com/markwilkie) | ✔️ | ✔️ | ✔️ | ✔️ | |
| 2 | [linker](https://github.com/mono/linker) | [Dan Seefeldt](https://github.com/dseefeld) | ✔️ | ✔️ | ✔️ | | |
| 2 | [msbuild](https://github.com/dotnet/msbuild) | [Ben Villalobos](https://github.com/BenVillalobos) | | | | | |
| 2 | [NuGet.Client](https://github.com/NuGet/NuGet.Client) | [Fernando Aguilar Reyes](https://github.com/dominoFire) | | | | | |
| 2 | [runtime](https://github.com/dotnet/runtime) | [Jared Parsons](https://github.com/jaredpar) | | | | | |
| 2 | [templating](https://github.com/dotnet/templating) | [Vlada Shubina](https://github.com/vlada-shubina) | | ✔️ | | | |
| 3 | [roslyn-analyzers](https://github.com/dotnet/roslyn-analyzers) | [Jonathon Marolf](https://github.com/jmarolf) | | | | | |
| 4 | [aspnetcore](https://github.com/dotnet/aspnetcore) | [John Luo](https://github.com/JunTaoLuo) | | | | | |
| 4 | [websdk](https://github.com/dotnet/sdk) | [Vijay Ramakrishnan](https://github.com/vijayrkn) | | | | | |
| 5 | [fsharp](https://github.com/dotnet/fsharp) | [Brett Forsgren](https://github.com/brettfo) | | | | | |
| 5 | [sdk](https://github.com/dotnet/sdk) | [Sarah Oslund](https://github.com/sfoslund) | | | | | |
| 5 | [vstest](https://github.com/microsoft/vstest) | [Jakub Jares](https://github.com/nohwnd) | | | | | |
| 6 | [installer](https://github.com/dotnet/installer) | [Sarah Oslund](https://github.com/sfoslund) | | | | | |

| Status | Description |
| --- | --- |
| ✔️ | Complete |
| ⏱ | In progress |
| ❗ | At Risk |

> <sup>1</sup> — Source will be maintained in central dotnet/source-build repo. It is not feasible to add full arcade-powered source-build infrastructure in some cases.

## Stage descriptions:
  - **(1) Local build infra merged**
    - (Source-build) Submit PR introducing local build infra. May include `.patch` files.
    - (**Repo team**) Review PR and merge.
      - Merging into main/master strongly preferred.
      - If a dev branch is created, the repo team must merge it into main/master before ending stage (3).
  - **(2) CI implemented** (PR + Official)
    - (**Repo team**) Submit PR adding source-build CI jobs and merge.
      - Let us know, and send us a link to an official build that includes the changes. We will start on (3).
    - *Async (**Repo team**) Incorporate `.patch` files into repo.*
      - *High impact: if these patch files have conflicts, CI fails.*
  - **(3) Artifacts greenlit** for downstream usage
    - (Source-build) Validate "intermediate nupkg" artifact and logs.
    - (Source-build) Preliminary check for unexpected prebuilt usage.
    - (Source-build + **repo team**) Fix up problems if found.
  - **(4) Prebuilt regressions blocked**
    - (Source-build) Submit PR enabling prebuilt baseline enforcement.
      - Prebuilt binary usage is expected because this is a "production build", not a "tarball build".
      - Prebuilt usage baseline enforcement prevents prebuilt regression.
      - We will only do this once enforcement errors are actionable.
    - (**Repo team**) Review PR and merge.
