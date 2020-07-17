# Tagging a release

Set up a signing key if you haven't already:
- Generating a key: <https://docs.github.com/en/github/authenticating-to-github/generating-a-new-gpg-key>
- Adding to GitHub: <https://docs.github.com/en/github/authenticating-to-github/adding-a-new-gpg-key-to-your-github-account>

## Create tags
Create annotated and signed tags with a shared message that includes both the runtime and SDK versions, e.g. "Release for 2.1.0 runtime and 2.1.300 SDK."

You can paste this and fill in the prompts to do this:

```sh
read -p 'Runtime version (X.Y.Z): ' runtimeVersion; \
read -p 'SDK version (X.Y.BZZ): ' sdkVersion; \
read -p 'Commit: ' commit; \
message="Release for $runtimeVersion runtime and $sdkVersion SDK."; \
git tag -s "v${runtimeVersion}-runtime" $commit -m "$message"; \
git tag -s "v${sdkVersion}-SDK" $commit -m "$message"; \
echo "$message"
```

## Review the tags
Look at tag info to spot any oddities. Double-check the versions and signing validity.

```sh
git tag -v "v${runtimeVersion}-runtime"; \
git tag -v "v${sdkVersion}-SDK"
```

## Push the tags
Run fully-specified pushes:

```sh
git push 'git@github.com:dotnet/source-build' "v${runtimeVersion}-runtime" && \
git push 'git@github.com:dotnet/source-build' "v${sdkVersion}-SDK"
```

**Do not use "git push --tags"**. Unless you have a fresh repo with no other tags, this will push all your tags. This risks messing up existing tags on the remote.