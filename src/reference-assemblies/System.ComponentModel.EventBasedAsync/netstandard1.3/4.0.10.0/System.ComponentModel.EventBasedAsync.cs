[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ComponentModel.EventBasedAsync")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ComponentModel.EventBasedAsync")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ComponentModel.EventBasedAsync")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.ComponentModel
{
    public partial class AsyncCompletedEventArgs : System.EventArgs
    {
        public AsyncCompletedEventArgs(System.Exception error, bool cancelled, object userState) { }
        public bool Cancelled { get { throw null; } }
        public System.Exception Error { get { throw null; } }
        public object UserState { get { throw null; } }
        protected void RaiseExceptionIfNecessary() { }
    }
    public delegate void AsyncCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    public sealed partial class AsyncOperation
    {
        internal AsyncOperation() { }
        public System.Threading.SynchronizationContext SynchronizationContext { get { throw null; } }
        public object UserSuppliedState { get { throw null; } }
        ~AsyncOperation() { }
        public void OperationCompleted() { }
        public void Post(System.Threading.SendOrPostCallback d, object arg) { }
        public void PostOperationCompleted(System.Threading.SendOrPostCallback d, object arg) { }
    }
    public static partial class AsyncOperationManager
    {
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Threading.SynchronizationContext SynchronizationContext { get { throw null; } set { } }
        public static System.ComponentModel.AsyncOperation CreateOperation(object userSuppliedState) { throw null; }
    }
    public partial class BackgroundWorker : System.IDisposable
    {
        public BackgroundWorker() { }
        public bool CancellationPending { get { throw null; } }
        public bool IsBusy { get { throw null; } }
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool WorkerReportsProgress { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool WorkerSupportsCancellation { get { throw null; } set { } }
        public event System.ComponentModel.DoWorkEventHandler DoWork { add { } remove { } }
        public event System.ComponentModel.ProgressChangedEventHandler ProgressChanged { add { } remove { } }
        public event System.ComponentModel.RunWorkerCompletedEventHandler RunWorkerCompleted { add { } remove { } }
        public void CancelAsync() { }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected virtual void OnDoWork(System.ComponentModel.DoWorkEventArgs e) { }
        protected virtual void OnProgressChanged(System.ComponentModel.ProgressChangedEventArgs e) { }
        protected virtual void OnRunWorkerCompleted(System.ComponentModel.RunWorkerCompletedEventArgs e) { }
        public void ReportProgress(int percentProgress) { }
        public void ReportProgress(int percentProgress, object userState) { }
        public void RunWorkerAsync() { }
        public void RunWorkerAsync(object argument) { }
    }
    public partial class DoWorkEventArgs : System.EventArgs
    {
        public DoWorkEventArgs(object argument) { }
        public object Argument { get { throw null; } }
        public bool Cancel { get { throw null; } set { } }
        public object Result { get { throw null; } set { } }
    }
    public delegate void DoWorkEventHandler(object sender, System.ComponentModel.DoWorkEventArgs e);
    public partial class ProgressChangedEventArgs : System.EventArgs
    {
        public ProgressChangedEventArgs(int progressPercentage, object userState) { }
        public int ProgressPercentage { get { throw null; } }
        public object UserState { get { throw null; } }
    }
    public delegate void ProgressChangedEventHandler(object sender, System.ComponentModel.ProgressChangedEventArgs e);
    public partial class RunWorkerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {
        public RunWorkerCompletedEventArgs(object result, System.Exception error, bool cancelled) : base (default(System.Exception), default(bool), default(object)) { }
        public object Result { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
        public new object UserState { get { throw null; } }
    }
    public delegate void RunWorkerCompletedEventHandler(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e);
}
