# Enable tests in source-build - design

We need to enable tests in source-build repo, with the following constraints:
- Build test-projects in a separate step, not part of main build
- Run tests in a separate step

We are missing some recent changes in CoreFX repo, that modified how test-project build and test run are executed. Once we move to a newer CoreFX commit, we will need to update `repos/corefx.proj` to set the correct properties and arguments.

Currently there is no way to build just CoreFX tests, you need to build them along other projects, or not build at all, so the immediate plan is to enable test-project build as part of the main build.

## Plan

### Modify `dir.props` file:

Add `RootRepoTests` property to point to `known-good-tests.proj`

```xml
<RootRepoTests>known-good-tests</RootRepoTests>
```

### Add `repos/known-good-tests.proj`

Include only those projects that we can enable for test build and test run, i.e. CoreFX.
Make sure to pass a propery/value to not build dependencies.

### Modify `build.cmd/sh/ps1`

Skip submodule check for `BuildTests` and `RunTests` options

### Modify `build.proj`

Add new targets for building and running tests, i.e. `BuildTests` and `RunTests`.

These targets should run msbuild of RootRepoTests with appropriate parameters, i.e. `BuildTests`, `RunTests`, skip repo references (`SkipRepoReferences=true`)

Until we get required changes for CoreFX repo, `BuildTests` target would not be usable.

### Modify `repos/corefx.proj` - current CoreFX in source build

Set correct arguments (for build command) based on `BuildTests` and `RunTests` options. Test-projects need to be built as part of regular build.

Condition current line that adds `SkipTests` property, to command-line arguments, to not be added for test-run. Arcade reads this property to decide to run tests or not.

Remove:

```xml
<BuildArguments>$(BuildArguments) /p:SkipTests=true</BuildArguments>
```

Add:

```xml
<BuildArguments Condition="'$(RunTests)' != 'true'">$(BuildArguments) /p:SkipTests=true</BuildArguments>
<BuildArguments Condition="'$(RunTests)' != 'true'">$(BuildArguments) /p:BuildTests=true</BuildArguments>
<BuildArguments Condition="'$(RunTests)' == 'true'">$(BuildArguments) -test</BuildArguments>
```

Make other necessary changes so test-run consumes source-built SDK

### Modify `repos/corefx.proj` - after CoreFX commit was updated to bring test-related changes

Set correct arguments (for build command) based on `BuildTests` and `RunTests` options

Condition current line that adds `SkipTests` property, to command-line arguments, to not be added for test-run. Arcade reads this property to decide to run tests or not.

Remove:

```xml
<BuildArguments>$(BuildArguments) /p:SkipTests=true</BuildArguments>
```

Add:

```xml
<BuildArguments Condition="'$(BuildTests)' == 'true'">$(BuildArguments) -buildtests</BuildArguments>
<BuildArguments Condition="'$(RunTests)' != 'true'">$(BuildArguments) /p:SkipTests=true</BuildArguments>
<BuildArguments Condition="'$(RunTests)' == 'true'">$(BuildArguments) -test</BuildArguments>
```

Make other necessary changes so test-run consumes source-built SDK

