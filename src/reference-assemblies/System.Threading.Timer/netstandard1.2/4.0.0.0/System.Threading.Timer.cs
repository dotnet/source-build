[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Threading.Timer")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Threading.Timer")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Threading.Timer")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Threading
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public sealed partial class Timer : System.IDisposable
    {
        public Timer(System.Threading.TimerCallback callback, object state, int dueTime, int period) { }
        public Timer(System.Threading.TimerCallback callback, object state, System.TimeSpan dueTime, System.TimeSpan period) { }
        public bool Change(int dueTime, int period) { throw null; }
        public bool Change(System.TimeSpan dueTime, System.TimeSpan period) { throw null; }
        public void Dispose() { }
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public delegate void TimerCallback(object state);
}
