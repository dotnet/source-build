# Automatic dependency contracts implementation example

The auto dependency flow repo API is implementated in CoreFX and Standard. These PRs contain the repo-side implementation changes:

 * `BuildTools` (common toolset, providing shared MSBuild code)
   * [#1707](https://github.com/dotnet/buildtools/pull/1707) Output placement args, assistance with source override args
 * `Standard`
   * [#523](https://github.com/dotnet/standard/pull/523) Source override args
   * [#525](https://github.com/dotnet/standard/pull/525) Apply a fix found during CoreFX work
 * `CoreFX`
   * [#24378](https://github.com/dotnet/corefx/pull/24378) Dependency version input args
   * [#24528](https://github.com/dotnet/corefx/pull/24528) Source override args

On the `source-build` side, [#219](https://github.com/dotnet/source-build/pull/219) started passing repo API arguments to CoreFX and Standard.

 > Note: This example only demonstrates an implementation of the arguments. The format used to pass the args (`/p:Foo=bar` vs. `-p:Foo=Bar` vs. `-Foo Bar`) is not implemented.
