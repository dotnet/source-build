# .NET CoreFX tests run Documentation

The following text includes documentation for the corefx tests run as a part of source-build. Over time, this document may get updated.

## Building the .NET CoreFX tests

Building .NET CoreFX tests require an initial source-build build via `build.{cmd/sh}`

## Under the hood

The initial build command in source-build is expected to produce packages and collateral for subsequent corefx tests run in a two-step process. The second step `./build -test` fires a corefx test build would look like the following under the hood:

```
./build.sh -buildtests -pack -restore -bl -test
```

The aforementioned command can be used to build standalone corefx tests. 

## Exclusion of tests

Any/All the corefx tests can be exluded from the test build run. This could depend on the intention of running the tests. Some of the corefx tests that currently fail as a part of source-build corefx test run are included in the following file. 

```console
source-build/test/exclusions/corefx/linux.docker.rsp
```

The test build supports categorically circumventing the tests as well. For e.g - exluding tests specifically for CI legs. 

## Test Results

Test results are currently located in the collateral that coreFX tests produce within source-build after the test build completes. They are located in:

`source-build/artifacts/src/corefx.<SHA1>/artifacts/bin/<Package>.Tests/netcore-app-Unix-Debug/testResults.xml`

Example:
```
source-build/artifacts/src/corefx.4ac4c0367003fe3973a3648eb0715ddb0e3bbcea/artifacts/bin/
System.Net.Security.Tests/netcoreapp-Unix-Debug/testResults.xml for details!
```