# Patching Guidelines

There are times when the source build product will have build errors, functional
defects, poison leaks, prebuilts, etc. Ideally, the underlying issues
would be addressed at the source of the problem (e.g. within the product repos)
and flow into source build. The reality is that repo fixes can take a long
 time to flow into source build. This can block source build development
(e.g. builds, tests, feature development, etc.). To avoid these delays source
patches are applied within source-build to the repo source. These patches are
intended to be ephemeral until the repo fixes flow in.

This document provides guidance for creating and managing source build patches.

## Creating Patches

To create a repo patch file, first commit your changes to the source repo (e.g.
runtime, aspnetcore) as normal, then run this command inside the repo to generate
a patch file inside the repo:

```sh
git format-patch --zero-commit --no-signature -1
```

Then, move the patch file into the `src/SourceBuild/patches/<repo>` directory of the
following repo:

* [.NET 9.0+] [sdk](https://github.com/dotnet/sdk/tree/main/src/SourceBuild/patches)
* [.NET 8.0] [installer](https://github.com/dotnet/installer/tree/main/src/SourceBuild/patches)

If an existing directory for the repo does not already exist, you will need to
create one.

> If you define `PATCH_DIR` to point at the `patches` directory, you can use
> `-o` to place the patch file directly in the right directory:
>
> ```sh
> git format-patch --zero-commit --no-signature -1 -o "$PATCH_DIR/<repo>"
> ```

## Applying Patches

To apply a patch, or multiple patches, use `git am` while inside the target
repo. For example, to apply *all* `sdk` patches onto a fresh clone of the `sdk`
repository that has already been checked out to the correct commit, use:

```sh
git am "$PATCH_DIR/sdk/*"
```

This creates a Git commit with the patch contents, so you can easily amend a
patch or create a new commit on top that you can be sure will apply cleanly.

> **Note:** The VMR has all of the `src/SourceBuild/patches` applied. This is done
as part of the [synchronization process](https://github.com/dotnet/arcade/blob/main/Documentation/UnifiedBuild/VMR-Design-And-Operation.md#source-build-patches).

## Patch Guidelines

1. **Documentation**

    The patch file name and `Subject` should indicate the purpose of the patch. It
    is often helpful to explain the problem/build issue the patch addresses.

1. **Naming Conventions**

    After generating the patch file, the numeric prefix of the filename may need to
    be changed. By convention, new patches should be one number above the largest
    number that already exists in the patch file directory.

    > **Note:** If there's a gap in the number sequence, do not fix it (generally
    speaking), to avoid unnecessary diffs and potential merge conflicts.

1. **Backport**

    All patches should have an issue or PR opened to address/backport the patch before
    openings PRs that add new patches.  All patches are required to include a link
    in its `Subject` to the backport issue/PR in the following format:

    `Backport: <github issue/pr link>`

    Example:

    ``` text
    From 0000000000000000000000000000000000000000 Mon Sep 17 00:00:00 2001
    From: John Doe <JohnDoe@email.com>
    Date: Mon, 17 Jul 2023 15:10:02 +0000
    Subject: [PATCH] Updates to work with the latest command-line APIs

    Backport: https://github.com/dotnet/sourcelink/pull/1068
    ```

1. **Consult Repo Experts**

    It is a good practive to include repo owners or subject matter experts when
    authoring patches and include them as a required reviewer.

## Resolving Patch Conflicts

Dependency flow PRs into the installer repo can cause patch conflicts (e.g. the
patch will fail to apply). These conflicts come in two forms.

1. The patch was backported - when this happen, the backported patch will need to
be deleted.

1. The code being changed or surrounding code was changed - when this happens, the
patch will need to be updated. This can be done by manually updating the patch or
by re-applying the changes to the repo and recreating the patch.

## Unified Build Plans

The [Unified Build](https://github.com/dotnet/arcade/blob/main/Documentation/UnifiedBuild/README.md)
project will add support for source edits in the [VMR](https://github.com/dotnet/dotnet).
This will eliminate the need for patches as the required changes can be directly made in
the VMR. All changes made to the VMR will automatically flow to the associated repos.
