# Adding a new Runtime Identifier (RID) to source-build

This document describes how to add a new Runtime Identifier (also
called runtime id or even just RID) to source-build. You might find
this useful if you see an error like this when building source-build:

```
error NETSDK1083: The specified RuntimeIdentifier 'foo.bar-x64' is not recognized.
```

# Assumptions

- .NET (coreclr, source-build, etc) already supports this new OS.

  For example, this could be a new version of a Linux distribution
  that's already known to work. Or it could be a fork of another Linux
  distribution which is expected to work

- source-build computes the RID correctly

  Source-build computes the RID, at least on Linux, by looking at
  `/etc/os-release` and running `${VERSION}.${VERSION_ID}-$(uname
  -m)`. If the result of this computation itself is wrong (for example
  a rolling Linux distro doesn't use `VERSION_ID`), the steps in this
  doc wont be sufficient.

- We just need to add things to the RID graph

  This isn't a brand new platform, just a slight tweak to an existing
  one.

# Step-by-step fix

This error message is generally from the rolysn build:

```
error NETSDK1083: The specified RuntimeIdentifier 'foo.bar-x64' is not recognized.
```

It means that the SDK that's being used to build roslyn doesn't have
the RID in it's RID graph. We can fix that.

The RID is generally present in 2 places:

1. `RuntimeIdentifierGraph.json` in a built-SDK

2. `Microsoft.NETCore.Platforms/runtime.json` in the source
   repositories (dotnet/runtime or dotnet/corefx)

Generally fixing the second one is sufficient.

Here's how to fix it.

1. Grab the source code of dotnet/runtime or dotnet/corefx

   For .NET Core (3.1 or earlier):

   ```
   git clone https://github.com/dotnet/corefx
   cd corefx
   git checkout release/$version
   ```

   For .NET (5 or later):


   ```
   git clone https://github.com/dotnet/runtime
   cd runtime
   git checkout release/$version
   ```

2. Add your new RID to `Microsoft.NETCore.Platforms`'s
   `runtimeGroups.props` file

   If you are adding a new Linux distro, the chagne might look
   something like this:

   ```diff
   --- a/pkg/Microsoft.NETCore.Platforms/runtimeGroups.props
   +++ b/pkg/Microsoft.NETCore.Platforms/runtimeGroups.props
   @@ -40,6 +40,11 @@
          <TreatVersionsAsCompatible>false</TreatVersionsAsCompatible>
        </RuntimeGroup>

   +    <RuntimeGroup Include="exherbo">
   +      <Parent>linux</Parent>
   +      <Architectures>x64</Architectures>
   +    </RuntimeGroup>
   +
        <RuntimeGroup Include="fedora">
          <Parent>linux</Parent>
          <Architectures>x64;arm64</Architectures>
   ```

   If you are just adding a new version, it might look like this:

   ```diff
   --- a/pkg/Microsoft.NETCore.Platforms/runtimeGroups.props
   +++ b/pkg/Microsoft.NETCore.Platforms/runtimeGroups.props
   @@ -43,7 +43,7 @@
        <RuntimeGroup Include="fedora">
          <Parent>linux</Parent>
          <Architectures>x64;arm64</Architectures>
   -      <Versions>23;24;25;26;27;28;29;30;31;32;33;34</Versions>
   +      <Versions>23;24;25;26;27;28;29;30;31;32;33;34;35</Versions>
          <TreatVersionsAsCompatible>false</TreatVersionsAsCompatible>
        </RuntimeGroup>
   ```

   Then build dotnet/runtime or dotnet/corefx with the
   `/p:UpdateRuntimeFiles=true` flag:

   ```
   ./build.sh /p:UpdateRuntimeFiles=true
   ```

   Building should result in a patch that updates
   `runtimeGroups.props`, but also `runtime.json` and
   `runtime.compatiblity.json`.

3. Commit the results and generate a patch:

   ```
   git commit -a ...
   git format-patch -1 HEAD
   ```

   Here's an [example
   result](https://src.fedoraproject.org/rpms/dotnet3.1/raw/43e957aabcbcef730c9433b817be947a7820ae67/f/corefx-43032-fedora-35-rid.patch)
   of a real patch generated though this approach.

   You might also want to create a PR to get this change included into
   the main .NET repositories. That will save you the trouble of
   having to update this patch yourself in the future.

4. Add that patch to source-build

   For .NET Core 3.1 or earlier, add the patch to `patches/corefx/`

   For .NET 5, add the patch to `patches/runtime/`

5. Build source-build

   Use your regular build steps, such as `./build.sh`. source-build
   will apply the new patch and build a new SDK with the new RID
   added.
