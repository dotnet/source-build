[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Runtime.Handles")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Runtime.Handles")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Runtime.Handles")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace Microsoft.Win32.SafeHandles
{
    [System.Security.SecurityCriticalAttribute]
    public sealed partial class SafeWaitHandle : System.Runtime.InteropServices.SafeHandle
    {
        public SafeWaitHandle(System.IntPtr existingHandle, bool ownsHandle) : base (default(System.IntPtr), default(bool)) { }
        public override bool IsInvalid { [System.Security.SecurityCriticalAttribute]get { throw null; } }
        [System.Security.SecurityCriticalAttribute]
        protected override bool ReleaseHandle() { throw null; }
    }
}
namespace System.IO
{
    public enum HandleInheritability
    {
        Inheritable = 1,
        None = 0,
    }
}
namespace System.Runtime.InteropServices
{
    [System.Security.SecurityCriticalAttribute]
    public abstract partial class CriticalHandle : System.IDisposable
    {
        protected System.IntPtr handle;
        protected CriticalHandle(System.IntPtr invalidHandleValue) { }
        public bool IsClosed { get { throw null; } }
        public abstract bool IsInvalid { get; }
        [System.Security.SecuritySafeCriticalAttribute]
        public void Dispose() { }
        [System.Security.SecurityCriticalAttribute]
        protected virtual void Dispose(bool disposing) { }
        ~CriticalHandle() { }
        protected abstract bool ReleaseHandle();
        protected void SetHandle(System.IntPtr handle) { }
        public void SetHandleAsInvalid() { }
    }
    [System.Security.SecurityCriticalAttribute]
    public abstract partial class SafeHandle : System.IDisposable
    {
        protected System.IntPtr handle;
        protected SafeHandle(System.IntPtr invalidHandleValue, bool ownsHandle) { }
        public bool IsClosed { get { throw null; } }
        public abstract bool IsInvalid { get; }
        [System.Security.SecurityCriticalAttribute]
        public void DangerousAddRef(ref bool success) { }
        public System.IntPtr DangerousGetHandle() { throw null; }
        [System.Security.SecurityCriticalAttribute]
        public void DangerousRelease() { }
        [System.Security.SecuritySafeCriticalAttribute]
        public void Dispose() { }
        [System.Security.SecurityCriticalAttribute]
        protected virtual void Dispose(bool disposing) { }
        ~SafeHandle() { }
        protected abstract bool ReleaseHandle();
        protected void SetHandle(System.IntPtr handle) { }
        [System.Security.SecurityCriticalAttribute]
        public void SetHandleAsInvalid() { }
    }
}
namespace System.Threading
{
    public static partial class WaitHandleExtensions
    {
        [System.Security.SecurityCriticalAttribute]
        public static Microsoft.Win32.SafeHandles.SafeWaitHandle GetSafeWaitHandle(this System.Threading.WaitHandle waitHandle) { throw null; }
        [System.Security.SecurityCriticalAttribute]
        public static void SetSafeWaitHandle(this System.Threading.WaitHandle waitHandle, Microsoft.Win32.SafeHandles.SafeWaitHandle value) { }
    }
}
