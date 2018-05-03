[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyDescriptionAttribute("Abstractions for reading `.deps` files.")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.1.0")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.1-beta")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("Microsoft.Extensions.DependencyModel.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f33a29044fa9d740c9b3213a93e57c84b472c84e0b8a0e1ae48e67a9f8f6de9d5f7f3d52ac23e48ac51801f1dc950abe901da34d2a9e3baadb141a17c77ef3c565dd5ee5054b91cf63bb3c6ab83f72ab3aafe93d0fc3c2348b764fafb0b1c0733de51459aeab46580384bf9d74c4e28164b7cde247f891ba07891c9d872ad2bb")]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.3")]
namespace Microsoft.Extensions.DependencyModel
{
    public partial class CompilationLibrary : Microsoft.Extensions.DependencyModel.Library
    {
        public CompilationLibrary(string type, string name, string version, string hash, System.Collections.Generic.IEnumerable<string> assemblies, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.Dependency> dependencies, bool serviceable) : base (default(string), default(string), default(string), default(string), default(System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.Dependency>), default(bool)) { }
        public CompilationLibrary(string type, string name, string version, string hash, System.Collections.Generic.IEnumerable<string> assemblies, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.Dependency> dependencies, bool serviceable, string path, string hashPath) : base (default(string), default(string), default(string), default(string), default(System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.Dependency>), default(bool)) { }
        public System.Collections.Generic.IReadOnlyList<string> Assemblies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class CompilationOptions
    {
        public CompilationOptions(System.Collections.Generic.IEnumerable<string> defines, string languageVersion, string platform, System.Nullable<bool> allowUnsafe, System.Nullable<bool> warningsAsErrors, System.Nullable<bool> optimize, string keyFile, System.Nullable<bool> delaySign, System.Nullable<bool> publicSign, string debugType, System.Nullable<bool> emitEntryPoint, System.Nullable<bool> generateXmlDocumentation) { }
        public System.Nullable<bool> AllowUnsafe { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string DebugType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static Microsoft.Extensions.DependencyModel.CompilationOptions Default { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Defines { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Nullable<bool> DelaySign { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Nullable<bool> EmitEntryPoint { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Nullable<bool> GenerateXmlDocumentation { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string KeyFile { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string LanguageVersion { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Nullable<bool> Optimize { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Platform { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Nullable<bool> PublicSign { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Nullable<bool> WarningsAsErrors { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct Dependency
    {
        public Dependency(string name, string version) { throw null;}
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Equals(Microsoft.Extensions.DependencyModel.Dependency other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class DependencyContext
    {
        public DependencyContext(Microsoft.Extensions.DependencyModel.TargetInfo target, Microsoft.Extensions.DependencyModel.CompilationOptions compilationOptions, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.CompilationLibrary> compileLibraries, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.RuntimeLibrary> runtimeLibraries, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.RuntimeFallbacks> runtimeGraph) { }
        public Microsoft.Extensions.DependencyModel.CompilationOptions CompilationOptions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Microsoft.Extensions.DependencyModel.CompilationLibrary> CompileLibraries { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Microsoft.Extensions.DependencyModel.RuntimeFallbacks> RuntimeGraph { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Microsoft.Extensions.DependencyModel.RuntimeLibrary> RuntimeLibraries { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public Microsoft.Extensions.DependencyModel.TargetInfo Target { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public Microsoft.Extensions.DependencyModel.DependencyContext Merge(Microsoft.Extensions.DependencyModel.DependencyContext other) { throw null; }
    }
    public static partial class DependencyContextExtensions
    {
        public static System.Collections.Generic.IEnumerable<System.Reflection.AssemblyName> GetDefaultAssemblyNames(this Microsoft.Extensions.DependencyModel.DependencyContext self) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Reflection.AssemblyName> GetDefaultAssemblyNames(this Microsoft.Extensions.DependencyModel.RuntimeLibrary self, Microsoft.Extensions.DependencyModel.DependencyContext context) { throw null; }
        public static System.Collections.Generic.IEnumerable<string> GetDefaultNativeAssets(this Microsoft.Extensions.DependencyModel.DependencyContext self) { throw null; }
        public static System.Collections.Generic.IEnumerable<string> GetDefaultNativeAssets(this Microsoft.Extensions.DependencyModel.RuntimeLibrary self, Microsoft.Extensions.DependencyModel.DependencyContext context) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Reflection.AssemblyName> GetRuntimeAssemblyNames(this Microsoft.Extensions.DependencyModel.DependencyContext self, string runtimeIdentifier) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Reflection.AssemblyName> GetRuntimeAssemblyNames(this Microsoft.Extensions.DependencyModel.RuntimeLibrary self, Microsoft.Extensions.DependencyModel.DependencyContext context, string runtimeIdentifier) { throw null; }
        public static System.Collections.Generic.IEnumerable<string> GetRuntimeNativeAssets(this Microsoft.Extensions.DependencyModel.DependencyContext self, string runtimeIdentifier) { throw null; }
        public static System.Collections.Generic.IEnumerable<string> GetRuntimeNativeAssets(this Microsoft.Extensions.DependencyModel.RuntimeLibrary self, Microsoft.Extensions.DependencyModel.DependencyContext context, string runtimeIdentifier) { throw null; }
    }
    public partial class DependencyContextJsonReader : Microsoft.Extensions.DependencyModel.IDependencyContextReader, System.IDisposable
    {
        public DependencyContextJsonReader() { }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public Microsoft.Extensions.DependencyModel.DependencyContext Read(System.IO.Stream stream) { throw null; }
        public System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.Dependency> ReadTargetLibraryDependencies(Newtonsoft.Json.JsonTextReader reader) { throw null; }
    }
    public partial class DependencyContextWriter
    {
        public DependencyContextWriter() { }
        public void Write(Microsoft.Extensions.DependencyModel.DependencyContext context, System.IO.Stream stream) { }
    }
    public partial interface IDependencyContextReader : System.IDisposable
    {
        Microsoft.Extensions.DependencyModel.DependencyContext Read(System.IO.Stream stream);
    }
    public partial class Library
    {
        public Library(string type, string name, string version, string hash, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.Dependency> dependencies, bool serviceable) { }
        public Library(string type, string name, string version, string hash, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.Dependency> dependencies, bool serviceable, string path, string hashPath) { }
        public System.Collections.Generic.IReadOnlyList<Microsoft.Extensions.DependencyModel.Dependency> Dependencies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Hash { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string HashPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Serviceable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Type { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class ResourceAssembly
    {
        public ResourceAssembly(string path, string locale) { }
        public string Locale { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class RuntimeAssembly
    {
        public RuntimeAssembly(string assemblyName, string path) { }
        public System.Reflection.AssemblyName Name { get { throw null; } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static Microsoft.Extensions.DependencyModel.RuntimeAssembly Create(string path) { throw null; }
    }
    public partial class RuntimeAssetGroup
    {
        public RuntimeAssetGroup(string runtime, System.Collections.Generic.IEnumerable<string> assetPaths) { }
        public RuntimeAssetGroup(string runtime, params string[] assetPaths) { }
        public System.Collections.Generic.IReadOnlyList<string> AssetPaths { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Runtime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class RuntimeFallbacks
    {
        public RuntimeFallbacks(string runtime, System.Collections.Generic.IEnumerable<string> fallbacks) { }
        public RuntimeFallbacks(string runtime, params string[] fallbacks) { }
        public System.Collections.Generic.IReadOnlyList<string> Fallbacks { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Runtime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class RuntimeLibrary : Microsoft.Extensions.DependencyModel.Library
    {
        public RuntimeLibrary(string type, string name, string version, string hash, System.Collections.Generic.IReadOnlyList<Microsoft.Extensions.DependencyModel.RuntimeAssetGroup> runtimeAssemblyGroups, System.Collections.Generic.IReadOnlyList<Microsoft.Extensions.DependencyModel.RuntimeAssetGroup> nativeLibraryGroups, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.ResourceAssembly> resourceAssemblies, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.Dependency> dependencies, bool serviceable) : base (default(string), default(string), default(string), default(string), default(System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.Dependency>), default(bool)) { }
        public RuntimeLibrary(string type, string name, string version, string hash, System.Collections.Generic.IReadOnlyList<Microsoft.Extensions.DependencyModel.RuntimeAssetGroup> runtimeAssemblyGroups, System.Collections.Generic.IReadOnlyList<Microsoft.Extensions.DependencyModel.RuntimeAssetGroup> nativeLibraryGroups, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.ResourceAssembly> resourceAssemblies, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.Dependency> dependencies, bool serviceable, string path, string hashPath) : base (default(string), default(string), default(string), default(string), default(System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.Dependency>), default(bool)) { }
        public System.Collections.Generic.IReadOnlyList<Microsoft.Extensions.DependencyModel.RuntimeAssembly> Assemblies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NativeLibraries { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Microsoft.Extensions.DependencyModel.RuntimeAssetGroup> NativeLibraryGroups { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Microsoft.Extensions.DependencyModel.ResourceAssembly> ResourceAssemblies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Microsoft.Extensions.DependencyModel.RuntimeAssetGroup> RuntimeAssemblyGroups { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class TargetInfo
    {
        public TargetInfo(string framework, string runtime, string runtimeSignature, bool isPortable) { }
        public string Framework { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool IsPortable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Runtime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string RuntimeSignature { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
}
namespace Microsoft.Extensions.DependencyModel.Resolution
{
    public partial class CompositeCompilationAssemblyResolver : Microsoft.Extensions.DependencyModel.Resolution.ICompilationAssemblyResolver
    {
        public CompositeCompilationAssemblyResolver(Microsoft.Extensions.DependencyModel.Resolution.ICompilationAssemblyResolver[] resolvers) { }
        public bool TryResolveAssemblyPaths(Microsoft.Extensions.DependencyModel.CompilationLibrary library, System.Collections.Generic.List<string> assemblies) { throw null; }
    }
    public partial class DotNetReferenceAssembliesPathResolver
    {
        public static readonly string DotNetReferenceAssembliesPathEnv;
        public DotNetReferenceAssembliesPathResolver() { }
        public static string Resolve() { throw null; }
    }
    public partial interface ICompilationAssemblyResolver
    {
        bool TryResolveAssemblyPaths(Microsoft.Extensions.DependencyModel.CompilationLibrary library, System.Collections.Generic.List<string> assemblies);
    }
    public partial class PackageCacheCompilationAssemblyResolver : Microsoft.Extensions.DependencyModel.Resolution.ICompilationAssemblyResolver
    {
        public PackageCacheCompilationAssemblyResolver() { }
        public PackageCacheCompilationAssemblyResolver(string packageCacheDirectory) { }
        public bool TryResolveAssemblyPaths(Microsoft.Extensions.DependencyModel.CompilationLibrary library, System.Collections.Generic.List<string> assemblies) { throw null; }
    }
    public partial class PackageCompilationAssemblyResolver : Microsoft.Extensions.DependencyModel.Resolution.ICompilationAssemblyResolver
    {
        public PackageCompilationAssemblyResolver() { }
        public PackageCompilationAssemblyResolver(string nugetPackageDirectory) { }
        public bool TryResolveAssemblyPaths(Microsoft.Extensions.DependencyModel.CompilationLibrary library, System.Collections.Generic.List<string> assemblies) { throw null; }
    }
    public partial class ReferenceAssemblyPathResolver : Microsoft.Extensions.DependencyModel.Resolution.ICompilationAssemblyResolver
    {
        public ReferenceAssemblyPathResolver() { }
        public ReferenceAssemblyPathResolver(string defaultReferenceAssembliesPath, string[] fallbackSearchPaths) { }
        public bool TryResolveAssemblyPaths(Microsoft.Extensions.DependencyModel.CompilationLibrary library, System.Collections.Generic.List<string> assemblies) { throw null; }
    }
}
namespace System.Collections.Generic
{
    public static partial class CollectionExtensions
    {
        public static System.Collections.Generic.IEnumerable<string> GetDefaultAssets(this System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.RuntimeAssetGroup> self) { throw null; }
        public static Microsoft.Extensions.DependencyModel.RuntimeAssetGroup GetDefaultGroup(this System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.RuntimeAssetGroup> self) { throw null; }
        public static System.Collections.Generic.IEnumerable<string> GetRuntimeAssets(this System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.RuntimeAssetGroup> self, string runtime) { throw null; }
        public static Microsoft.Extensions.DependencyModel.RuntimeAssetGroup GetRuntimeGroup(this System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyModel.RuntimeAssetGroup> self, string runtime) { throw null; }
    }
}
