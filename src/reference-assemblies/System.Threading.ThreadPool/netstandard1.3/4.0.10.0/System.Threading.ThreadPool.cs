[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Threading.ThreadPool")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Threading.ThreadPool")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Threading.ThreadPool")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Threading
{
    public sealed partial class RegisteredWaitHandle
    {
        internal RegisteredWaitHandle() { }
        public bool Unregister(System.Threading.WaitHandle waitObject) { throw null; }
    }
    public static partial class ThreadPool
    {
        [System.Security.SecurityCriticalAttribute]
        public static bool BindHandle(System.Runtime.InteropServices.SafeHandle osHandle) { throw null; }
        public static bool QueueUserWorkItem(System.Threading.WaitCallback callBack) { throw null; }
        public static bool QueueUserWorkItem(System.Threading.WaitCallback callBack, object state) { throw null; }
        public static System.Threading.RegisteredWaitHandle RegisterWaitForSingleObject(System.Threading.WaitHandle waitObject, System.Threading.WaitOrTimerCallback callBack, object state, int millisecondsTimeOutInterval, bool executeOnlyOnce) { throw null; }
        public static System.Threading.RegisteredWaitHandle RegisterWaitForSingleObject(System.Threading.WaitHandle waitObject, System.Threading.WaitOrTimerCallback callBack, object state, long millisecondsTimeOutInterval, bool executeOnlyOnce) { throw null; }
        public static System.Threading.RegisteredWaitHandle RegisterWaitForSingleObject(System.Threading.WaitHandle waitObject, System.Threading.WaitOrTimerCallback callBack, object state, System.TimeSpan timeout, bool executeOnlyOnce) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static System.Threading.RegisteredWaitHandle RegisterWaitForSingleObject(System.Threading.WaitHandle waitObject, System.Threading.WaitOrTimerCallback callBack, object state, uint millisecondsTimeOutInterval, bool executeOnlyOnce) { throw null; }
    }
    public delegate void WaitCallback(object state);
    public delegate void WaitOrTimerCallback(object state, bool timedOut);
}
