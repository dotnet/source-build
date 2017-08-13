[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Diagnostics.StackTrace")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Diagnostics.StackTrace")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24301.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24301.01. Commit Hash: 4ed15a98d1c957ae661d490ccfcfe77f4ed31d5a")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Diagnostics.StackTrace")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Diagnostics
{
    public sealed partial class StackFrame
    {
        internal StackFrame() { }
        public const int OFFSET_UNKNOWN = -1;
        public int GetFileColumnNumber() { throw null; }
        public int GetFileLineNumber() { throw null; }
        public string GetFileName() { throw null; }
        public int GetILOffset() { throw null; }
        public System.Reflection.MethodBase GetMethod() { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class StackFrameExtensions
    {
        public static System.IntPtr GetNativeImageBase(this System.Diagnostics.StackFrame stackFrame) { throw null; }
        public static System.IntPtr GetNativeIP(this System.Diagnostics.StackFrame stackFrame) { throw null; }
        public static bool HasILOffset(this System.Diagnostics.StackFrame stackFrame) { throw null; }
        public static bool HasMethod(this System.Diagnostics.StackFrame stackFrame) { throw null; }
        public static bool HasNativeImage(this System.Diagnostics.StackFrame stackFrame) { throw null; }
        public static bool HasSource(this System.Diagnostics.StackFrame stackFrame) { throw null; }
    }
    public sealed partial class StackTrace
    {
        public StackTrace(System.Exception exception, bool needFileInfo) { }
        public System.Diagnostics.StackFrame[] GetFrames() { throw null; }
        public override string ToString() { throw null; }
    }
}
