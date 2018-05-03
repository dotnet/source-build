[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.IO.IsolatedStorage")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.IO.IsolatedStorage")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.IO.IsolatedStorage")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.IO.IsolatedStorage
{
    public partial class IsolatedStorageException : System.Exception
    {
        public IsolatedStorageException() { }
        public IsolatedStorageException(string message) { }
        public IsolatedStorageException(string message, System.Exception inner) { }
    }
    public sealed partial class IsolatedStorageFile : System.IDisposable
    {
        internal IsolatedStorageFile() { }
        public void CopyFile(string sourceFileName, string destinationFileName) { }
        public void CopyFile(string sourceFileName, string destinationFileName, bool overwrite) { }
        public void CreateDirectory(string dir) { }
        public System.IO.IsolatedStorage.IsolatedStorageFileStream CreateFile(string path) { throw null; }
        public void DeleteDirectory(string dir) { }
        public void DeleteFile(string file) { }
        public bool DirectoryExists(string path) { throw null; }
        public void Dispose() { }
        public bool FileExists(string path) { throw null; }
        public System.DateTimeOffset GetCreationTime(string path) { throw null; }
        public string[] GetDirectoryNames() { throw null; }
        public string[] GetDirectoryNames(string searchPattern) { throw null; }
        public string[] GetFileNames() { throw null; }
        public string[] GetFileNames(string searchPattern) { throw null; }
        public System.DateTimeOffset GetLastAccessTime(string path) { throw null; }
        public System.DateTimeOffset GetLastWriteTime(string path) { throw null; }
        public static System.IO.IsolatedStorage.IsolatedStorageFile GetUserStoreForApplication() { throw null; }
        public void MoveDirectory(string sourceDirectoryName, string destinationDirectoryName) { }
        public void MoveFile(string sourceFileName, string destinationFileName) { }
        public System.IO.IsolatedStorage.IsolatedStorageFileStream OpenFile(string path, System.IO.FileMode mode) { throw null; }
        public System.IO.IsolatedStorage.IsolatedStorageFileStream OpenFile(string path, System.IO.FileMode mode, System.IO.FileAccess access) { throw null; }
        public System.IO.IsolatedStorage.IsolatedStorageFileStream OpenFile(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share) { throw null; }
    }
    public partial class IsolatedStorageFileStream : System.IO.Stream
    {
        public IsolatedStorageFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, System.IO.IsolatedStorage.IsolatedStorageFile isf) { }
        public IsolatedStorageFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.IsolatedStorage.IsolatedStorageFile isf) { }
        public IsolatedStorageFileStream(string path, System.IO.FileMode mode, System.IO.IsolatedStorage.IsolatedStorageFile isf) { }
        public override bool CanRead { get { throw null; } }
        public override bool CanSeek { get { throw null; } }
        public override bool CanWrite { get { throw null; } }
        public override long Length { get { throw null; } }
        public override long Position { get { throw null; } set { } }
        protected override void Dispose(bool disposing) { }
        public override void Flush() { }
        public override System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override int Read(byte[] buffer, int offset, int count) { throw null; }
        public override System.Threading.Tasks.Task<int> ReadAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override int ReadByte() { throw null; }
        public override long Seek(long offset, System.IO.SeekOrigin origin) { throw null; }
        public override void SetLength(long value) { }
        public override void Write(byte[] buffer, int offset, int count) { }
        public override System.Threading.Tasks.Task WriteAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override void WriteByte(byte value) { }
    }
}
