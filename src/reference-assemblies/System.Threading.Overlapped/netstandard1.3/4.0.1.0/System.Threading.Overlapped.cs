[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Threading.Overlapped")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Threading.Overlapped")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Threading.Overlapped")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Threading
{
    [System.CLSCompliantAttribute(false)]
    [System.Security.SecurityCriticalAttribute]
    public unsafe delegate void IOCompletionCallback(uint errorCode, uint numBytes, System.Threading.NativeOverlapped* pOVERLAP);
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct NativeOverlapped
    {
        public System.IntPtr EventHandle;
        public System.IntPtr InternalHigh;
        public System.IntPtr InternalLow;
        public int OffsetHigh;
        public int OffsetLow;
    }
    public sealed partial class PreAllocatedOverlapped : System.IDisposable
    {
        [System.CLSCompliantAttribute(false)]
        public PreAllocatedOverlapped(System.Threading.IOCompletionCallback callback, object state, object pinData) { }
        public void Dispose() { }
    }
    public sealed partial class ThreadPoolBoundHandle : System.IDisposable
    {
        internal ThreadPoolBoundHandle() { }
        public System.Runtime.InteropServices.SafeHandle Handle { get { throw null; } }
        [System.CLSCompliantAttribute(false)]
        public unsafe System.Threading.NativeOverlapped* AllocateNativeOverlapped(System.Threading.IOCompletionCallback callback, object state, object pinData) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public unsafe System.Threading.NativeOverlapped* AllocateNativeOverlapped(System.Threading.PreAllocatedOverlapped preAllocated) { throw null; }
        public static System.Threading.ThreadPoolBoundHandle BindHandle(System.Runtime.InteropServices.SafeHandle handle) { throw null; }
        public void Dispose() { }
        [System.CLSCompliantAttribute(false)]
        public unsafe void FreeNativeOverlapped(System.Threading.NativeOverlapped* overlapped) { }
        [System.CLSCompliantAttribute(false)]
        public unsafe static object GetNativeOverlappedState(System.Threading.NativeOverlapped* overlapped) { throw null; }
    }
}
