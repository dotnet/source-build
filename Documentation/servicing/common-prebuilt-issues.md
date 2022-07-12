# Common prebuilt issues and how to resolve them

### Old Microsoft.NETCore.Targets versions

These will show up like:

```
runtime.placeholder-rid.System.Collections.4.3.0
runtime.placeholder-rid.System.Diagnostics.Tracing.4.3.0
runtime.placeholder-rid.System.Globalization.4.3.0
runtime.placeholder-rid.System.Globalization.Calendars.4.3.0
runtime.placeholder-rid.System.IO.4.3.0
runtime.placeholder-rid.System.Reflection.4.3.0
runtime.placeholder-rid.System.Reflection.Primitives.4.3.0
runtime.placeholder-rid.System.Resources.ResourceManager.4.3.0
runtime.placeholder-rid.System.Runtime.4.3.0
runtime.placeholder-rid.System.Runtime.Handles.4.3.0
runtime.placeholder-rid.System.Runtime.InteropServices.4.3.0
runtime.placeholder-rid.System.Text.Encoding.4.3.0
runtime.placeholder-rid.System.Text.Encoding.Extensions.4.3.0
runtime.placeholder-rid.System.Threading.Tasks.4.3.0
runtime.placeholder-rid.System.Diagnostics.Debug.4.3.0
runtime.placeholder-rid.System.IO.FileSystem.4.3.0
runtime.placeholder-rid.System.Private.Uri.4.3.0
runtime.placeholder-rid.System.Runtime.Extensions.4.3.0
```

Typically this means someone solved a component governance issue by adding a new reference to an older System package that brought in an old version if MS.NETCore.Targets, which in turn brings in all of these old runtime packages.  The solution is to add a reference to a newer MS.NETCore.Targets version as [was done in ASP.NET](https://github.com/dotnet/source-build/blob/82416e7d9b7551a4d975505e1f561bb192112050/patches/aspnetcore/0018-Add-Microsoft.NETCore.Targets-explicit-reference-to-.patch).

### WinForms or WPF templates

```
Microsoft.Dotnet.Wpf.ProjectTemplates
Microsoft.Dotnet.Wpf.ProjectTemplates
```

core-sdk has changed the way they reference these a couple times.  Likely a change is needed in [this patch](https://github.com/dotnet/source-build/blob/82416e7d9b7551a4d975505e1f561bb192112050/patches/core-sdk/0008-don-t-restore-winforms-and-wpf-templates.patch) to exclude these templates that source-build doesn't need.

### NuGet/MSBuild/Roslyn/other tooling

Likely this is a new reference that needs to be pinned to a version of the reference package that we have.  See [this Arcade patch](https://github.com/dotnet/source-build/blob/82416e7d9b7551a4d975505e1f561bb192112050/patches/arcade/0007-Update-NuGetVersion-to-Reference-Package-version.patch) for an example.