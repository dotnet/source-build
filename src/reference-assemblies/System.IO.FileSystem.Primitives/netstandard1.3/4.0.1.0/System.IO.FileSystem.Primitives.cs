[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.IO.FileSystem.Primitives")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.IO.FileSystem.Primitives")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.IO.FileSystem.Primitives")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.IO
{
    [System.FlagsAttribute]
    public enum FileAccess
    {
        Read = 1,
        ReadWrite = 3,
        Write = 2,
    }
    [System.FlagsAttribute]
    public enum FileAttributes
    {
        Archive = 32,
        Compressed = 2048,
        Device = 64,
        Directory = 16,
        Encrypted = 16384,
        Hidden = 2,
        IntegrityStream = 32768,
        Normal = 128,
        NoScrubData = 131072,
        NotContentIndexed = 8192,
        Offline = 4096,
        ReadOnly = 1,
        ReparsePoint = 1024,
        SparseFile = 512,
        System = 4,
        Temporary = 256,
    }
    public enum FileMode
    {
        Append = 6,
        Create = 2,
        CreateNew = 1,
        Open = 3,
        OpenOrCreate = 4,
        Truncate = 5,
    }
    [System.FlagsAttribute]
    public enum FileShare
    {
        Delete = 4,
        Inheritable = 16,
        None = 0,
        Read = 1,
        ReadWrite = 3,
        Write = 2,
    }
}
