## Making a commit that exists on a repo network available to source-build

On release day, there might be errors like this:

```
fatal: reference is not a tree: cb5f173b9696d9d00a544b953d95190ab3b56df2
```

Trying to find them on GitHub (e.g. assembling the URL https://github.com/dotnet/runtime/commit/cb5f173b9696d9d00a544b953d95190ab3b56df2) may show you this:

```
This commit does not belong to any branch on this repository, and may belong to a fork outside of the repository.
```

To unblock source-build CI:

1. Email **.NET Core Project Management** to ask why the commit isn't available.
   * Don't wait for a response: continue with the next step.
1. Go to your fork of the corresponding GitHub repo, e.g. https://github.com/dagood/runtime
1. Add `/tree/{commit}` to the URL, e.g. https://github.com/dagood/runtime/tree/cb5f173b9696d9d00a544b953d95190ab3b56df2
   * Each GitHub repo has a "network" of forks. If a commit is available in any repo in the "network", GitHub lets you navigate to it from any repo in the network.
   * If the commit shows up, that means it's available publicly somewhere in the network.
     * We're going to create a branch on the commit to make it available in a specific place we can maintain.
   * If the commit doesn't show up, then it hasn't been made public yet at all, even on a fork.
     * The commit can be found in the AzDO repo and pushed to GitHub to work around this, but it's not as clear whether the commit *should* be available.
     * Wait for a response from the release team or repo owners before continuing, in this case.
1. Click the branch dropdown.
1. Type in a name for a branch to create, e.g. `release/5.0.2`
   * The name doesn't matter, a branch just needs to exist.
1. Press Enter to create the branch.
1. Edit the repo's URI in `Version.Details.xml` to use your fork, e.g. https://github.com/dagood/runtime
1. CI should now get past this point.
   * It may fail on another repo if multiple haven't been tagged properly.
1. ...Later, check the commit's availability in the non-fork repo, and switch the URI back to the official repository when possible.

This is intended to temporarily unblock CI so it can continue to validate the build and flush out further problems.
