[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("Microsoft Corporation. All rights reserved.")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("The core data structures for NuGet.Packaging")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("3.5.0.1996")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("3.5.0-rtm-1996")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("NuGet")]
[assembly:System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.InteropServices.ComVisibleAttribute(false)]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.3")]
namespace NuGet.Packaging.Core
{
    public delegate string ExtractPackageFileDelegate(string sourceFile, string targetPath, System.IO.Stream fileStream);
    public partial interface INuspecCoreReader
    {
        string GetId();
        NuGet.Packaging.Core.PackageIdentity GetIdentity();
        System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>> GetMetadata();
        NuGet.Versioning.NuGetVersion GetMinClientVersion();
        System.Collections.Generic.IReadOnlyList<NuGet.Packaging.Core.PackageType> GetPackageTypes();
        NuGet.Versioning.NuGetVersion GetVersion();
    }
    public partial interface IPackageCoreReader : System.IDisposable
    {
        System.Collections.Generic.IEnumerable<string> CopyFiles(string destination, System.Collections.Generic.IEnumerable<string> packageFiles, NuGet.Packaging.Core.ExtractPackageFileDelegate extractFile, NuGet.Common.ILogger logger, System.Threading.CancellationToken token);
        System.Collections.Generic.IEnumerable<string> GetFiles();
        System.Collections.Generic.IEnumerable<string> GetFiles(string folder);
        NuGet.Packaging.Core.PackageIdentity GetIdentity();
        NuGet.Versioning.NuGetVersion GetMinClientVersion();
        System.IO.Stream GetNuspec();
        string GetNuspecFile();
        System.Collections.Generic.IReadOnlyList<NuGet.Packaging.Core.PackageType> GetPackageTypes();
        System.IO.Stream GetStream(string path);
    }
    public partial class NuspecCoreReader : NuGet.Packaging.Core.NuspecCoreReaderBase
    {
        public NuspecCoreReader(System.IO.Stream stream) : base (default(string)) { }
        public NuspecCoreReader(System.Xml.Linq.XDocument xml) : base (default(string)) { }
        public virtual System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependency> GetDependencies() { throw null; }
    }
    public abstract partial class NuspecCoreReaderBase : NuGet.Packaging.Core.INuspecCoreReader
    {
        protected const string DevelopmentDependency = "developmentDependency";
        protected const string Id = "id";
        protected const string Metadata = "metadata";
        protected const string MinClientVersion = "minClientVersion";
        protected const string Version = "version";
        public NuspecCoreReaderBase(System.IO.Stream stream) { }
        public NuspecCoreReaderBase(System.IO.Stream stream, bool leaveStreamOpen) { }
        public NuspecCoreReaderBase(string path) { }
        public NuspecCoreReaderBase(System.Xml.Linq.XDocument xml) { }
        protected System.Xml.Linq.XElement MetadataNode { get { throw null; } }
        protected System.Collections.Generic.Dictionary<string, string> MetadataValues { get { throw null; } }
        public System.Xml.Linq.XDocument Xml { get { throw null; } }
        public virtual bool GetDevelopmentDependency() { throw null; }
        public virtual string GetId() { throw null; }
        public virtual NuGet.Packaging.Core.PackageIdentity GetIdentity() { throw null; }
        public virtual System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>> GetMetadata() { throw null; }
        public virtual string GetMetadataValue(string name) { throw null; }
        public virtual NuGet.Versioning.NuGetVersion GetMinClientVersion() { throw null; }
        public virtual System.Collections.Generic.IReadOnlyList<NuGet.Packaging.Core.PackageType> GetPackageTypes() { throw null; }
        public virtual NuGet.Versioning.NuGetVersion GetVersion() { throw null; }
        public virtual bool IsServiceable() { throw null; }
    }
    public static partial class NuspecUtility
    {
        public static readonly string PackageType;
        public static readonly string PackageTypeName;
        public static readonly string PackageTypes;
        public static readonly string PackageTypeVersion;
        public static readonly string Serviceable;
        public static System.Collections.Generic.IReadOnlyList<NuGet.Packaging.Core.PackageType> GetPackageTypes(System.Xml.Linq.XElement metadataNode, bool useMetadataNamespace) { throw null; }
        public static bool IsServiceable(System.Xml.Linq.XElement metadataNode) { throw null; }
    }
    public partial class PackageType : System.IEquatable<NuGet.Packaging.Core.PackageType>
    {
        public static readonly NuGet.Packaging.Core.PackageType Dependency;
        public static readonly NuGet.Packaging.Core.PackageType DotnetCliTool;
        public static readonly System.Version EmptyVersion;
        public static readonly NuGet.Packaging.Core.PackageType Legacy;
        public PackageType(string name, System.Version version) { }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Version Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Equals(NuGet.Packaging.Core.PackageType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(NuGet.Packaging.Core.PackageType a, NuGet.Packaging.Core.PackageType b) { throw null; }
        public static bool operator !=(NuGet.Packaging.Core.PackageType a, NuGet.Packaging.Core.PackageType b) { throw null; }
    }
    public partial class PackagingException : System.Exception
    {
        public PackagingException(string message) { }
        public PackagingException(string message, System.Exception innerException) { }
    }
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public partial class Strings
    {
        internal Strings() { }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        public static string InvalidPackageTypeVersion { get { throw null; } }
        public static string MissingMetadataNode { get { throw null; } }
        public static string MissingNuspec { get { throw null; } }
        public static string MissingPackageTypeName { get { throw null; } }
        public static string MultipleNuspecFiles { get { throw null; } }
        public static string MultiplePackageTypes { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Resources.ResourceManager ResourceManager { get { throw null; } }
        public static string StringCannotBeNullOrEmpty { get { throw null; } }
    }
}
