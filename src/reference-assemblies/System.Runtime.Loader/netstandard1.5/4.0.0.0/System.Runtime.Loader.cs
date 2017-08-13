[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Runtime.Loader")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Runtime.Loader")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Runtime.Loader")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Reflection.Metadata
{
    public static partial class AssemblyExtensions
    {
        [System.CLSCompliantAttribute(false)]
        public unsafe static bool TryGetRawMetadata(this System.Reflection.Assembly assembly, out byte* blob, out int length) { blob = default(byte*); length = default(int); throw null; }
    }
}
namespace System.Runtime.Loader
{
    public abstract partial class AssemblyLoadContext
    {
        protected AssemblyLoadContext() { }
        public static System.Runtime.Loader.AssemblyLoadContext Default { get { throw null; } }
        public event System.Func<System.Runtime.Loader.AssemblyLoadContext, System.Reflection.AssemblyName, System.Reflection.Assembly> Resolving { add { } remove { } }
        public event System.Action<System.Runtime.Loader.AssemblyLoadContext> Unloading { add { } remove { } }
        public static System.Reflection.AssemblyName GetAssemblyName(string assemblyPath) { throw null; }
        public static System.Runtime.Loader.AssemblyLoadContext GetLoadContext(System.Reflection.Assembly assembly) { throw null; }
        protected abstract System.Reflection.Assembly Load(System.Reflection.AssemblyName assemblyName);
        public System.Reflection.Assembly LoadFromAssemblyName(System.Reflection.AssemblyName assemblyName) { throw null; }
        public System.Reflection.Assembly LoadFromAssemblyPath(string assemblyPath) { throw null; }
        public System.Reflection.Assembly LoadFromNativeImagePath(string nativeImagePath, string assemblyPath) { throw null; }
        public System.Reflection.Assembly LoadFromStream(System.IO.Stream assembly) { throw null; }
        public System.Reflection.Assembly LoadFromStream(System.IO.Stream assembly, System.IO.Stream assemblySymbols) { throw null; }
        protected virtual System.IntPtr LoadUnmanagedDll(string unmanagedDllName) { throw null; }
        protected System.IntPtr LoadUnmanagedDllFromPath(string unmanagedDllPath) { throw null; }
        public void SetProfileOptimizationRoot(string directoryPath) { }
        public void StartProfileOptimization(string profile) { }
    }
}
