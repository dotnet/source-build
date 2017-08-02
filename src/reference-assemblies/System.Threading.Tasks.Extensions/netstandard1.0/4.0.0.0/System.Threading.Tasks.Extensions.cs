[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Threading.Tasks.Extensions")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Threading.Tasks.Extensions")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Threading.Tasks.Extensions")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
namespace System.Runtime.CompilerServices
{
    public partial struct ConfiguredValueTaskAwaitable<TResult>
    {
        public System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable<TResult>.ConfiguredValueTaskAwaiter GetAwaiter() { throw null; }
        public partial struct ConfiguredValueTaskAwaiter : System.Runtime.CompilerServices.ICriticalNotifyCompletion, System.Runtime.CompilerServices.INotifyCompletion
        {
            public bool IsCompleted { get { throw null; } }
            public TResult GetResult() { throw null; }
            public void OnCompleted(System.Action continuation) { }
            public void UnsafeOnCompleted(System.Action continuation) { }
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct ValueTaskAwaiter<TResult> : System.Runtime.CompilerServices.ICriticalNotifyCompletion, System.Runtime.CompilerServices.INotifyCompletion
    {
        public bool IsCompleted { get { throw null; } }
        public TResult GetResult() { throw null; }
        public void OnCompleted(System.Action continuation) { }
        public void UnsafeOnCompleted(System.Action continuation) { }
    }
}
namespace System.Threading.Tasks
{
    public partial struct ValueTask<TResult> : System.IEquatable<System.Threading.Tasks.ValueTask<TResult>>
    {
        public ValueTask(System.Threading.Tasks.Task<TResult> task) { throw null;}
        public ValueTask(TResult result) { throw null;}
        public bool IsCanceled { get { throw null; } }
        public bool IsCompleted { get { throw null; } }
        public bool IsCompletedSuccessfully { get { throw null; } }
        public bool IsFaulted { get { throw null; } }
        public TResult Result { get { throw null; } }
        public System.Threading.Tasks.Task<TResult> AsTask() { throw null; }
        public System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable<TResult> ConfigureAwait(bool continueOnCapturedContext) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public bool Equals(System.Threading.Tasks.ValueTask<TResult> other) { throw null; }
        public System.Runtime.CompilerServices.ValueTaskAwaiter<TResult> GetAwaiter() { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(System.Threading.Tasks.ValueTask<TResult> left, System.Threading.Tasks.ValueTask<TResult> right) { throw null; }
        public static bool operator !=(System.Threading.Tasks.ValueTask<TResult> left, System.Threading.Tasks.ValueTask<TResult> right) { throw null; }
        public override string ToString() { throw null; }
    }
}
