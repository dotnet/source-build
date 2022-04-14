# Interpreting the poison report

The poison report looks something like this:

```
<PrebuiltLeakReport>
  <File Path="dotnet-sdk-6.0.100/sdk/6.0.0/Roslyn/bincore/runtimes/win/lib/netcoreapp3.1/System.Text.Encoding.CodePages.dll">
    <Type>Hash</Type>
    <Hash>9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08</Hash>
    <Match Package="/home/dotnet-bot/build/previously-source-built/System.Text.Encoding.1.2.3.nupkg" PackageId="System.Text.Encoding" PackageVersion="1.2.3" File="lib/netcoreapp3.1/System.Text.Encoding.CodePages.dll" />
  </File>
  <File Path="dotnet-toolset-internal-6.0.100/Roslyn/bincore/runtimes/win/lib/netcoreapp3.1/System.Reflection.Metadata.dll">
    <Type>AssemblyAttribute</Type>
    <Hash>cf80cd8aed482d5d1527d7dc72fceff84e6326592848447d2dc0b0e87dfc9a90</Hash>
  </File>
  <File Path="Microsoft.DotNet.GenFacades.1.0.0-beta.20316.7/.poisoned">
    <Type>NupkgFile</Type>
    <Hash>e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855</Hash>
  </File>
</PrebuiltLeakReport>
```

The first thing to notice is the different `Type`s.  These can help you track down where the leak came from.  One match can have multiple types, e.g. `<Type>AssemblyAttribute,Hash</Type>`.

## Failure types

### AssemblyAttribute

This means that we detected a custom attribute that source-build adds to each prebuilt and previously-source-built assembly before the build.  This is a *definite* leak - there will not be any false positives.  However, this may not be cause for failure - some categories of assemblies may leak without causing problems:

- Localization assemblies, e.g. .../langcode/Assembly.Resources.dll
- Reference assemblies (these should not ship, but also will very rarely cause problems).
- Test or resource assemblies - these should be removed.

### Hash

Hash failures mean that a file matches the catalog of hashes that we take of existing files before the build.  These are commonly false positives due to shipping static files not produced by the build such as:

- Text files (licenses, templates, etc)
- Empty files (\_.\_)

However, if this is a DLL this is probably a legitimate leak.

### NupkgFile

This type of failure means that a nupkg was copied wholesale to the final output.  This is a definite leak, but very uncommon and likely easy to trace in the binlogs.

## Other metadata

### \<File Path=...\>

This is the location in the output where the leak was detected.  The first component of the path is an archive or package name, e.g. `dotnet-sdk-6.0.100` is `dotnet-sdk-6.0.100.tar.gz` in the `artifacts/<arch>` directory.  Components after that are the file's path within the archive or nupkg.

### \<Hash\>

This is the hash of the failing file.  This is useful to track down the correct file if there are multiple with the same name.  It is included in all cases, even when the failure type is not `Hash`.

### \<Match\>

When available, this describes the file in the source-build *input* that matches the failing file.  For instance:
`<Match Package="/home/dotnet-bot/build/previously-source-built/System.Text.Encoding.1.2.3.nupkg" PackageId="System.Text.Encoding" PackageVersion="1.2.3" File="lib/netcoreapp3.1/System.Text.Encoding.CodePages.dll" />`
means that the failing `System.Text.Encoding.CodePages.dll` matches the hash of the file `lib/netcoreapp3.1/System.Text.Encoding.CodePages.dll` in the previously-source-built package System.Text.Encoding version 1.2.3.  This can help track down the exact *input* file that made it to the final output.