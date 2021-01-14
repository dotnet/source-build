## Making a commit that exists on a repo network available to source-build

On release day, there might be errors like this:

```
fatal: reference is not a tree: cb5f173b9696d9d00a544b953d95190ab3b56df2
```

```
This commit does not belong to any branch on this repository, and may belong to a fork outside of the repository.
```

To unblock this:

1. Go to your fork of the corresponding GitHub repo, e.g. https://github.com/dagood/runtime
1. Add `/tree/{commit}` to the URL, e.g. https://github.com/dagood/runtime/tree/cb5f173b9696d9d00a544b953d95190ab3b56df2
   * If the commit isn't available, then it hasn't been made public yet and the release is blocked.
1. Click the branch dropdown.
1. Type in a name for a branch to create, e.g. `release/5.0.2`
   * The name doesn't matter, a branch just needs to exist.
1. Press Enter to create the branch.
1. Edit the repo's URI in `Version.Details.xml` to use your fork, e.g. https://github.com/dagood/runtime
1. CI should now get past this point.
   * It may fail on another repo if multiple haven't been tagged properly.
1. ...Later, check the commit's availability in the non-fork repo, and switch the URI back to the official repository when possible.

This is intended to temporarily unblock CI so it can continue to validate the build and flush out further problems. The commit's unavailability on the official repo should also be communicated to the release team so it can be fixed as soon as possible.
