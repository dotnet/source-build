[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("Microsoft Corporation. All rights reserved.")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("NuGet v3 core library.")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.0.2283")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.0-rtm-2283")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("NuGet")]
[assembly:System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.InteropServices.ComVisibleAttribute(false)]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.3")]
namespace NuGet.Repositories
{
    public partial class LocalPackageInfo
    {
        public LocalPackageInfo(string packageId, NuGet.Versioning.NuGetVersion version, string path, string manifestPath, string zipPath) { }
        public string ExpandedPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string ManifestPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Packaging.NuspecReader Nuspec { get { throw null; } }
        public NuGet.Versioning.NuGetVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string ZipPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class LocalPackageSourceInfo
    {
        public LocalPackageSourceInfo(NuGet.Repositories.NuGetv3LocalRepository repository, NuGet.Repositories.LocalPackageInfo package) { }
        public NuGet.Repositories.LocalPackageInfo Package { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Repositories.NuGetv3LocalRepository Repository { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class NuGetv3LocalRepository
    {
        public NuGetv3LocalRepository(string path) { }
        public NuGet.Packaging.VersionFolderPathResolver PathResolver { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string RepositoryRoot { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public void ClearCacheForIds(System.Collections.Generic.IEnumerable<string> packageIds) { }
        public NuGet.Repositories.LocalPackageInfo FindPackage(string packageId, NuGet.Versioning.NuGetVersion version) { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Repositories.LocalPackageInfo> FindPackagesById(string packageId) { throw null; }
    }
    public static partial class NuGetv3LocalRepositoryUtility
    {
        public static NuGet.Repositories.LocalPackageSourceInfo GetPackage(System.Collections.Generic.IReadOnlyList<NuGet.Repositories.NuGetv3LocalRepository> repositories, string id, NuGet.Versioning.NuGetVersion version) { throw null; }
    }
}
