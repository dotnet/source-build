[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.IO.FileSystem.Watcher")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.IO.FileSystem.Watcher")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.IO.FileSystem.Watcher")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.IO
{
    public partial class ErrorEventArgs : System.EventArgs
    {
        public ErrorEventArgs(System.Exception exception) { }
        public virtual System.Exception GetException() { throw null; }
    }
    public delegate void ErrorEventHandler(object sender, System.IO.ErrorEventArgs e);
    public partial class FileSystemEventArgs : System.EventArgs
    {
        public FileSystemEventArgs(System.IO.WatcherChangeTypes changeType, string directory, string name) { }
        public System.IO.WatcherChangeTypes ChangeType { get { throw null; } }
        public string FullPath { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public delegate void FileSystemEventHandler(object sender, System.IO.FileSystemEventArgs e);
    public partial class FileSystemWatcher : System.IDisposable
    {
        public FileSystemWatcher() { }
        public FileSystemWatcher(string path) { }
        public FileSystemWatcher(string path, string filter) { }
        public bool EnableRaisingEvents { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public bool IncludeSubdirectories { get { throw null; } set { } }
        public int InternalBufferSize { get { throw null; } set { } }
        public System.IO.NotifyFilters NotifyFilter { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public event System.IO.FileSystemEventHandler Changed { add { } remove { } }
        public event System.IO.FileSystemEventHandler Created { add { } remove { } }
        public event System.IO.FileSystemEventHandler Deleted { add { } remove { } }
        public event System.IO.ErrorEventHandler Error { add { } remove { } }
        public event System.IO.RenamedEventHandler Renamed { add { } remove { } }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected void OnChanged(System.IO.FileSystemEventArgs e) { }
        protected void OnCreated(System.IO.FileSystemEventArgs e) { }
        protected void OnDeleted(System.IO.FileSystemEventArgs e) { }
        protected void OnError(System.IO.ErrorEventArgs e) { }
        protected void OnRenamed(System.IO.RenamedEventArgs e) { }
        public System.IO.WaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes changeType) { throw null; }
        public System.IO.WaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes changeType, int timeout) { throw null; }
    }
    [System.FlagsAttribute]
    public enum NotifyFilters
    {
        Attributes = 4,
        CreationTime = 64,
        DirectoryName = 2,
        FileName = 1,
        LastAccess = 32,
        LastWrite = 16,
        Security = 256,
        Size = 8,
    }
    public partial class RenamedEventArgs : System.IO.FileSystemEventArgs
    {
        public RenamedEventArgs(System.IO.WatcherChangeTypes changeType, string directory, string name, string oldName) : base (default(System.IO.WatcherChangeTypes), default(string), default(string)) { }
        public string OldFullPath { get { throw null; } }
        public string OldName { get { throw null; } }
    }
    public delegate void RenamedEventHandler(object sender, System.IO.RenamedEventArgs e);
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, Size=1)]
    public partial struct WaitForChangedResult
    {
        public System.IO.WatcherChangeTypes ChangeType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string OldName { get { throw null; } set { } }
        public bool TimedOut { get { throw null; } set { } }
    }
    [System.FlagsAttribute]
    public enum WatcherChangeTypes
    {
        All = 15,
        Changed = 4,
        Created = 1,
        Deleted = 2,
        Renamed = 8,
    }
}
