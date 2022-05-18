# Updating patches for servicing

## Introduction

During servicing, patches often have to be updated to account for
new version numbers or other changes in the contributing repos.
In servicing, usually these will be small changes, but there will
be occasional large changes, especially when doing feature-band upgrades.

## Process

1. Clone the source-build repo and update the version of contributing repos as
  appropriate for the branch.
1. Build the repo as normal.  If the build succeeds, no patch
  changes were necessary and you're done.
1. Otherwise, you will see errors like:

    ```
    EXEC : error : patch failed: Directory.Build.props:408 [/home/chris/dotnet_source-build/repos/aspnetcore.proj]
    EXEC : error : Directory.Build.props: patch does not apply [/home/chris/dotnet_source-build/repos/aspnetcore.proj]
      /dotnet/source-build/repos/Directory.Build.targets(83,5): error MSB3073:
    The command "git --work-tree=/dotnet/source-build/artifacts/src/aspnetcore.d1fa2cb155ab9226f20b87ab0d7a1eb16b8a8b69/
    apply --ignore-whitespace --whitespace=nowarn /home/chris/dotnet_source-build/patches/aspnetcore/0005-Exclude-some-projects-from-source-build.patch"
    exited with code 1. [/home/chris/dotnet_source-build/repos/aspnetcore.proj]
    ```

    - `/dotnet/source-build/patches/aspnetcore/0005-Exclude-some-projects-from-source-build.patch`
    is the patch that no longer works.
    - `aspnetcore` is the failing repo.
    - `Directory.Build.props` is the file that is the patch is failing on.
    - `d1fa2cb155ab9226f20b87ab0d7a1eb16b8a8b69` is the hash of the updated repo.
1. `cd` to the source directory for the failing repo.  For 3.1 and
  5.0, this is `artifacts/src/<reponame>` (no trailing `.<sha>`).
  For 6.0, this is `src/<reponame>`.
1. `git checkout -f` the hash of the repo from above, then
  `git clean -fxd` to make sure you're in a clean state.
1. `git am ../../../patches/<reponame>/*` to attempt to apply all
  patches.  You should get a failure like:

    ```
    Applying: Don't call dotnet without path
    Applying: Use non-portable NETCoreAppRuntime for crossgen
    Applying: Exclude analyzer for source-build
    Applying: Import PackageVersions.props
    Applying: Exclude some projects from source-build
    error: patch failed: Directory.Build.props:18
    error: Directory.Build.props: patch does not apply
    Patch failed at 0005 Exclude some projects from source-build
    hint: Use 'git am --show-current-patch=diff' to see the failed patch
    When you have resolved this problem, run "git am --continue".
    If you prefer to skip this patch, run "git am --skip" instead.
    To restore the original branch and stop patching, run "git am --abort".
    ```

1. `git am --show-current-patch` will show the patch that git is
  currently attempting to apply.  Make these changes in the failing
  file, adjusting for any updates required.  Git will typically apply
  any changes in the patch to other files, but if not, you may have
  to use `git apply-patch`, `patch`, or manually apply those changes as well.
1. `git add` all files involved in the patch, then `git am --continue`.
  If another patch fails, repeat the process.  If the patching
  succeeds all the way through, you're done.
1. Extract the patches using `git format-patch --zero-commit --no-signature -o ../../../patches/<reponame> <updated hash>`.
1. `git add` the changed patch files at the top level of the repo
  and commit them with your other changes.