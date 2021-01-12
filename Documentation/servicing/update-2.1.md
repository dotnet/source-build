# Running 2.1 auto-update

## Internal: Running 2.1 auto-update using build definition

1.  Open https://dev.azure.com/dnceng/internal/_build/index?definitionId=248
1.  Find the ProdCon build number, in the format `YYYYMMDD-##`.
    * This is the date of the first time this build spun. If the date seems old, this is probably because it's been respun.
1.  Press "Run pipeline"
1.  Set the `pb.manifest.build` variable to the `YYYYMMDD-##` build number.
1.  Press "Run"
1.  Open the build and wait for it to complete.
1.  Find the auto-update PR at <https://dev.azure.com/dnceng/internal/_git/dotnet-source-build/pullrequests?_a=active>.

## Public: Running 2.1 auto-update from dotnet/versions

This is how to update using a public ProdCon manifest, like <https://github.com/dotnet/versions/tree/master/build-info/dotnet/product/cli/release/2.1.6>.

Always look for full-versioned dirs. The 2.1 and 2.2 directories are prerelease/daily builds. If you can, wait until you hear internally that a build is done to make sure the update isn't a waste of time or picking the wrong build. Then:

1.  Branch off the latest 2.1/2.2 commit in GitHub.
1.  Make sure your submodules are pristine. (`git submodule update --init --recursive`)
1.  Edit dependencies.props to set the updater to update from the dotnet/versions directory path: `<BasePath>build-info/dotnet/product/cli/release/2.1.6</BasePath>` in the following context:
    ```xml
    <DependencyInfo Include="ProdCon" Condition="'$(UpdateFromManifestFile)' == ''">
      <DependencyType>Orchestrated build</DependencyType>
      <BasePath>build-info/dotnet/product/cli/release/2.1.6</BasePath>
      <CurrentRef>$(ProdConCurrentRef)</CurrentRef>
      <VersionsRepoOwner>dotnet</VersionsRepoOwner>
      <VersionsRepo>versions</VersionsRepo>
    </DependencyInfo>
    <DependencyInfo Include="ProdCon" Condition="'$(UpdateFromManifestFile)' != ''">
      <DependencyType>Orchestrated build file</DependencyType>
      <Path>$(UpdateFromManifestFile)</Path>
    </DependencyInfo>
    ```
1.  Change the versions for ASP.NET in dependencies.props to match the latest release:
    ```xml
    <MicrosoftAspNetCoreAllPackageVersion>2.1.16</MicrosoftAspNetCoreAllPackageVersion>
    <MicrosoftAspNetCoreAppPackageVersion>2.1.16</MicrosoftAspNetCoreAppPackageVersion>
    ```
1.  Run:
    ```
    .\build.cmd /t:InitBuild /p:SkipPatches=true
    ```
    * This sets up necessary tooling but avoids patching, since patches can prevent submodule checkouts.
1.  Run:
    ```
    .\build.cmd /t:UpdateDependencies /p:UpdateFromManifestFile=$(manifestFile) /clp:v=n
    ```
    * Warnings about "Unable to find a desired hash for …" are normal.
      * It just means that repo wasn't in the manifest for this particular ProdCon build.
    * Errors are not normal.
1.  Commit all changes, submit a PR.
    * Example: https://github.com/dotnet/source-build/pull/840
