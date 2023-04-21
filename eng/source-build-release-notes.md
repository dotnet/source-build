You can build $RELEASE_NAME from the repository by cloning the release tag `$TAG` and following the build instructions in the [main README.md](https://github.com/dotnet/dotnet/blob/$TAG/README.md#building).

```sh
git clone --branch $TAG --depth 1 https://github.com/dotnet/dotnet
(cd dotnet && ./build.sh)
```

Alternatively, you can build from the sources attached to this release. Please note that you'll need to provide the release information to the build script. This can be done directly:
```sh
curl -sSL https://github.com/dotnet/dotnet/archive/refs/tags/$TAG.tar.gz | tar xzf -
(cd dotnet-* && ./build.sh --source-repository https://github.com/dotnet/dotnet --source-version $SOURCE_VERSION)
```

or by downloading the [release manifest](https://github.com/dotnet/dotnet/releases/download/$TAG/release.json) file:

```sh
curl -sSL https://github.com/dotnet/dotnet/archive/refs/tags/$TAG.tar.gz | tar xzf -
curl -Lo release.json https://github.com/dotnet/dotnet/releases/download/$TAG/release.json
(cd dotnet-* && ./build.sh --release-manifest ../release.json)
```

More information on this process can be found in the [dotnet/dotnet repository](https://github.com/dotnet/dotnet/blob/$TAG/README.md#building-from-released-sources).
