# Arcade-powered source-build implementation plan

To get each repo building with the new source-build sustainability plan, [Arcade-Powered Source-Build](./README.md), each repo will go through several stages. Some stages have dependencies on upstream repos, so this process will be completed in dependency order with some exceptions.

Below, the repo status is in a graph to show the dependencies and make it easy to tell which repos are ready to work on. There's also a table, for searchable and more detailed status. These will both be kept up to date.

> ![](https://pointillism.io/dotnet/source-build/blob/main/Documentation/planning/arcade-powered-source-build/img/implementation-plan-graph.dot.svg)
> [source (img/implementation-plan-graph.dot)](img/implementation-plan-graph.dot)

| Tier | Repo | Owner | Input intermediate packages available | (Stage 1)<br>Local build infra merged | (Stage 2)<br>CI implemented | (Stage 3)<br>Artifacts greenlit | (Stage 4)<br>Prebuilt regressions blocked |
| --- | --- | --- | :---: | :---: | :---: | :---: | :---: |
| sbrp | [source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages) | [Dan Seefeldt](https://github.com/dseefeld) | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2192) |
| Tools | [sourcelink](https://github.com/dotnet/sourcelink) | [Tomas Matousek](https://github.com/tmat) | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/) |
| Tools | [arcade](https://github.com/dotnet/arcade) | [Mark Wilkie](https://github.com/markwilkie) | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/) |
| 1 | *[application-insights](https://github.com/dotnet/source-build/tree/master/src)*<sup>1</sup> | ? | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2193) |
| 1 | *[cssparser](https://github.com/dotnet/source-build/tree/master/src)*<sup>1</sup> | ? | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2193) |
| 1 | *[humanizer](https://github.com/dotnet/source-build/tree/master/src)*<sup>1</sup> | ? | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2193) |
| 1 | *[netcorecli-fsc](https://github.com/dotnet/source-build/tree/master/src)*<sup>1</sup> | [Chris Rummel](https://github.com/crummel) | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2193) |
| 1 | *[newtonsoft-json](https://github.com/dotnet/source-build/tree/master/src)*<sup>1</sup> | [Chris Rummel](https://github.com/crummel) | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2193) |
| 1 | *[newtonsoft-json901](https://github.com/dotnet/source-build/tree/master/src)*<sup>1</sup> | [Chris Rummel](https://github.com/crummel) | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2193) |
| 1 | [aspnet-xdt](https://github.com/dotnet/xdt) | [Vijay Ramakrishnan](https://github.com/vijayrkn) | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2194) |
| 1 | [clicommandlineparser](https://github.com/dotnet/clicommandlineparser) | [Sarah Oslund](https://github.com/sfoslund) |  ✔️ |  ✔️ |  ✔️ | | [issue](https://github.com/dotnet/source-build/issues/2195) |
| 1 | [command-line-api](https://github.com/dotnet/command-line-api) | ? |  ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2196) |
| 1 | [diagnostics](https://github.com/dotnet/diagnostics) | [Juan Hoyes](https://github.com/hoyosjs) | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2197) |
| 1 | [roslyn](https://github.com/dotnet/roslyn) | [Fred Silberberg](https://github.com/333fred) | ✔️ | ✔️ | ✔️ | | [issue](https://github.com/dotnet/source-build/issues/2198) |
| 1 | [symreader](https://github.com/dotnet/symreader) | [Tomas Matousek](https://github.com/tmat) | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2199) |
| 1 | [test-templates](https://github.com/dotnet/test-templates) | ? | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2200) |
| 1 | [xliff-tasks](https://github.com/dotnet/xliff-tasks) | [Mark Wilkie](https://github.com/markwilkie) | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2201) |
| 2 | [linker](https://github.com/mono/linker) | [Dan Seefeldt](https://github.com/dseefeld) | ✔️ | ✔️ | ✔️ | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2202) |
| 2 | [msbuild](https://github.com/dotnet/msbuild) | [Ben Villalobos](https://github.com/BenVillalobos) | | ✔️ | ✔️ | | [issue](https://github.com/dotnet/source-build/issues/2203) |
| 2 | [NuGet.Client](https://github.com/NuGet/NuGet.Client) | [Fernando Aguilar Reyes](https://github.com/dominoFire) | ✔️ | [issue](https://github.com/dotnet/source-build/issues/2069)<br>⏱[PR](https://github.com/NuGet/NuGet.Client/pull/4105) | | | [issue](https://github.com/dotnet/source-build/issues/2204) |
| 2 | [runtime](https://github.com/dotnet/runtime) | [Jared Parsons](https://github.com/jaredpar) | | [issue](https://github.com/dotnet/source-build/issues/2052)<br>⏱[PR](https://github.com/dotnet/runtime/pull/53294) | | | [issue](https://github.com/dotnet/source-build/issues/2205) |
| 2 | [templating](https://github.com/dotnet/templating) | [Vlada Shubina](https://github.com/vlada-shubina) | | ✔️ | ✔️ | | [issue](https://github.com/dotnet/source-build/issues/2206) |
| 3 | [roslyn-analyzers](https://github.com/dotnet/roslyn-analyzers) | [Jonathon Marolf](https://github.com/jmarolf) | | ✔️ | [Official build issue](https://github.com/dotnet/roslyn-analyzers/issues/5136)<br>⏱[PR](https://github.com/dotnet/roslyn-analyzers/pull/5153) | | [issue](https://github.com/dotnet/source-build/issues/2207) |
| 4 | [aspnetcore](https://github.com/dotnet/aspnetcore) | [John Luo](https://github.com/JunTaoLuo) | | ✔️ | [Official build not publising issue](https://github.com/dotnet/aspnetcore/issues/33343)<br>⏱[PR](https://github.com/dotnet/aspnetcore/pull/33558) | | [issue](https://github.com/dotnet/source-build/issues/2208) |
| 5 | [fsharp](https://github.com/dotnet/fsharp) | [Brett Forsgren](https://github.com/brettfo) | | ✔️ | [Patches issue](https://github.com/dotnet/fsharp/issues/11435) | | [issue](https://github.com/dotnet/source-build/issues/2209) |
| 5 | [sdk](https://github.com/dotnet/sdk) | [Sarah Oslund](https://github.com/sfoslund) / [Vijay Ramakrishnan](https://github.com/vijayrkn)(web)| | ✔️ | ✔️ | | [issue](https://github.com/dotnet/source-build/issues/2211) |
| 5 | [vstest](https://github.com/microsoft/vstest) | [Jakub Jares](https://github.com/nohwnd) | | ✔️ | [CI issue](https://github.com/microsoft/vstest/issues/2929)<br>[Patch issue](https://github.com/microsoft/vstest/issues/2930)<br>⏱[PR](https://github.com/microsoft/vstest/pull/2939) | | [issue](https://github.com/dotnet/source-build/issues/2210) |
| 6 | [installer](https://github.com/dotnet/installer) | [Sarah Oslund](https://github.com/sfoslund) | | ✔️ | ✔️ | | [issue](https://github.com/dotnet/source-build/issues/2212) |

| Status | Description |
| --- | --- |
| ✔️ | Complete |
| ⏱ | In progress |
| ❗ | At Risk |

> <sup>1</sup> — Source will be maintained in central dotnet/source-build repo. It is not feasible to add full arcade-powered source-build infrastructure in some cases.

## Stage descriptions

  - **(1) Local build infra merged**
    - (Source-build) Submit PR introducing local build infra. May include `.patch` files.
    - (**Repo team**) Review PR and merge.
      - Merging into main/master strongly preferred.
      - If a dev branch is created, the repo team must merge it into main/master before ending stage (3).
	- Exit criteria:
	  - Local dev build works.
	  - Source-build intermediate packages are produced.
		- Intermediate packages contain the same set of packages as the in-progress 6.0 branch or the 5.0 branch.
	  - Prebuilts are reviewed (best effort basis).
	    - It will be difficult to determine if all prebuilts are correct before we have the whole graph building.
		- Packages built earlier in the source-build graph should not be using external prebuilts if the source-build intermediates for those are ready.
	  - If the target repo already has source-build CI, it is upgraded to ArPow.
    - After completing this step:
	    - Log an issue in the target repo to remove source-build patches.
	    - Log an issue in the target repo to enable source-build CI.
  - **(2) CI implemented** (PR + Official)
    - (**Repo team**) Submit PR adding source-build CI jobs and merge.
      - Let us know, and send us a link to an official build that includes the changes. We will start on (3).
    - *Async (**Repo team**) Incorporate `.patch` files into repo.*
      - *High impact: if these patch files have conflicts, CI fails.*
    - Exit criteria:
      - All source-build patches are removed.
      - Source-build CI in the target repo is green and runs on PRs and checkins.
  - **(3) Artifacts greenlit** for downstream usage
    - (Source-build) Validate "intermediate nupkg" artifact and logs.
    - (Source-build) Preliminary check for unexpected prebuilt usage.
    - (Source-build + **repo team**) Fix up problems if found.
    - Exit criteria:
      - CI is reviewed.
      - CI runs on release builds, checkins, and PRs.
      - Intermediate packages are produced and published to BAR.
      - Source-build team verifies that all expected packages are included in the intermediate packages.
  - **(4) Prebuilt regressions blocked**
    - (Source-build) Submit PR enabling prebuilt baseline enforcement.
      - Prebuilt binary usage is expected because this is a "production build", not a "tarball build".
      - Prebuilt usage baseline enforcement prevents prebuilt regression.
      - We will only do this once enforcement errors are actionable.
      - Exit criteria:
        - A prebuilt baseline is established with specific packages and versions (not wildcards).
        - New prebuilt detection is enabled in CI in the target repo.
    - (**Repo team**) Review PR and merge.
