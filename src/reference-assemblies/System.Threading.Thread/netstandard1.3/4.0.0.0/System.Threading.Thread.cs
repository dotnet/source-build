[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Threading.Thread")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Threading.Thread")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Threading.Thread")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Threading
{
    [System.Runtime.InteropServices.ComVisibleAttribute(false)]
    public delegate void ParameterizedThreadStart(object obj);
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public sealed partial class Thread
    {
        public Thread(System.Threading.ParameterizedThreadStart start) { }
        public Thread(System.Threading.ThreadStart start) { }
        public static System.Threading.Thread CurrentThread { get { throw null; } }
        public bool IsAlive { get { throw null; } }
        public bool IsBackground { get { throw null; } set { } }
        public int ManagedThreadId { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Threading.ThreadState ThreadState { get { throw null; } }
        public void Join() { }
        public bool Join(int millisecondsTimeout) { throw null; }
        public static void Sleep(int millisecondsTimeout) { }
        public static void Sleep(System.TimeSpan timeout) { }
        public void Start() { }
        public void Start(object parameter) { }
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public delegate void ThreadStart();
    public sealed partial class ThreadStartException : System.Exception
    {
        internal ThreadStartException() { }
    }
    [System.FlagsAttribute]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public enum ThreadState
    {
        Aborted = 256,
        AbortRequested = 128,
        Background = 4,
        Running = 0,
        Stopped = 16,
        StopRequested = 1,
        Suspended = 64,
        SuspendRequested = 2,
        Unstarted = 8,
        WaitSleepJoin = 32,
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class ThreadStateException : System.Exception
    {
        public ThreadStateException() { }
        public ThreadStateException(string message) { }
        public ThreadStateException(string message, System.Exception innerException) { }
    }
}
