[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("Microsoft Corporation. All rights reserved.")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("NuGet v3 core library.")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.0.2283")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.0-rtm-2283")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("NuGet")]
[assembly:System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.InteropServices.ComVisibleAttribute(false)]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.3")]
namespace NuGet.ProjectModel
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct BuildAction : System.IEquatable<NuGet.ProjectModel.BuildAction>
    {
        public static NuGet.ProjectModel.BuildAction AndroidAsset;
        public static NuGet.ProjectModel.BuildAction AndroidResource;
        public static NuGet.ProjectModel.BuildAction ApplicationDefinition;
        public static NuGet.ProjectModel.BuildAction BundleResource;
        public static NuGet.ProjectModel.BuildAction CodeAnalysisDictionary;
        public static NuGet.ProjectModel.BuildAction Compile;
        public static NuGet.ProjectModel.BuildAction Content;
        public static NuGet.ProjectModel.BuildAction DesignData;
        public static NuGet.ProjectModel.BuildAction DesignDataWithDesignTimeCreatableTypes;
        public static NuGet.ProjectModel.BuildAction EmbeddedResource;
        public static NuGet.ProjectModel.BuildAction None;
        public static NuGet.ProjectModel.BuildAction Page;
        public static NuGet.ProjectModel.BuildAction Resource;
        public static NuGet.ProjectModel.BuildAction SplashScreen;
        public bool IsKnown { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Value { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Equals(NuGet.ProjectModel.BuildAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(NuGet.ProjectModel.BuildAction left, NuGet.ProjectModel.BuildAction right) { throw null; }
        public static bool operator !=(NuGet.ProjectModel.BuildAction left, NuGet.ProjectModel.BuildAction right) { throw null; }
        public static NuGet.ProjectModel.BuildAction Parse(string value) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BuildOptions : System.IEquatable<NuGet.ProjectModel.BuildOptions>
    {
        public BuildOptions() { }
        public string OutputName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.ProjectModel.BuildOptions other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class DependencyGraphSpec
    {
        public DependencyGraphSpec() { }
        public DependencyGraphSpec(Newtonsoft.Json.Linq.JObject json) { }
        public Newtonsoft.Json.Linq.JObject Json { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<NuGet.ProjectModel.PackageSpec> Projects { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Restore { get { throw null; } }
        public void AddProject(NuGet.ProjectModel.PackageSpec projectSpec) { }
        public void AddRestore(string projectUniqueName) { }
        public System.Collections.Generic.IReadOnlyList<NuGet.ProjectModel.PackageSpec> GetClosure(string rootUniqueName) { throw null; }
        public string GetHash() { throw null; }
        public System.Collections.Generic.IReadOnlyList<string> GetParents(string rootUniqueName) { throw null; }
        public NuGet.ProjectModel.PackageSpec GetProjectSpec(string projectUniqueName) { throw null; }
        public static NuGet.ProjectModel.DependencyGraphSpec Load(Newtonsoft.Json.Linq.JObject json) { throw null; }
        public static NuGet.ProjectModel.DependencyGraphSpec Load(string path) { throw null; }
        public void Save(string path) { }
        public static System.Collections.Generic.IReadOnlyList<NuGet.ProjectModel.PackageSpec> SortPackagesByDependencyOrder(System.Collections.Generic.IEnumerable<NuGet.ProjectModel.PackageSpec> packages) { throw null; }
        public static NuGet.ProjectModel.DependencyGraphSpec Union(System.Collections.Generic.IEnumerable<NuGet.ProjectModel.DependencyGraphSpec> dgSpecs) { throw null; }
        public NuGet.ProjectModel.DependencyGraphSpec WithoutRestores() { throw null; }
        public NuGet.ProjectModel.DependencyGraphSpec WithoutTools() { throw null; }
        public NuGet.ProjectModel.DependencyGraphSpec WithReplacedSpec(NuGet.ProjectModel.PackageSpec project) { throw null; }
    }
    public partial class ExternalProjectReference : System.IComparable<NuGet.ProjectModel.ExternalProjectReference>, System.IEquatable<NuGet.ProjectModel.ExternalProjectReference>
    {
        public ExternalProjectReference(string uniqueName, NuGet.ProjectModel.PackageSpec packageSpec, string msbuildProjectPath, System.Collections.Generic.IEnumerable<string> projectReferences) { }
        public ExternalProjectReference(string uniqueName, string packageSpecProjectName, string packageSpecPath, string msbuildProjectPath, System.Collections.Generic.IEnumerable<string> projectReferences) { }
        public System.Collections.Generic.IReadOnlyList<string> ExternalProjectReferences { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string MSBuildProjectPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.ProjectModel.PackageSpec PackageSpec { get { throw null; } }
        public string PackageSpecProjectName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string ProjectJsonPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string ProjectName { get { throw null; } }
        public string UniqueName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public int CompareTo(NuGet.ProjectModel.ExternalProjectReference other) { throw null; }
        public bool Equals(NuGet.ProjectModel.ExternalProjectReference other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileFormatException : System.Exception
    {
        public FileFormatException(string message) { }
        public FileFormatException(string message, System.Exception innerException) { }
        public int Column { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public int Line { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static NuGet.ProjectModel.FileFormatException Create(System.Exception exception, Newtonsoft.Json.Linq.JToken value, string path) { throw null; }
        public static NuGet.ProjectModel.FileFormatException Create(string message, Newtonsoft.Json.Linq.JToken value, string path) { throw null; }
    }
    public sealed partial class HashObjectWriter : NuGet.RuntimeModel.IObjectWriter, System.IDisposable
    {
        public HashObjectWriter(NuGet.ProjectModel.IHashFunction hashFunc) { }
        public void Dispose() { }
        public string GetHash() { throw null; }
        public void WriteNameArray(string name, System.Collections.Generic.IEnumerable<string> values) { }
        public void WriteNameValue(string name, bool value) { }
        public void WriteNameValue(string name, int value) { }
        public void WriteNameValue(string name, string value) { }
        public void WriteObjectEnd() { }
        public void WriteObjectStart(string name) { }
    }
    public partial interface IExternalProjectReferenceProvider
    {
        System.Collections.Generic.IReadOnlyList<NuGet.ProjectModel.ExternalProjectReference> GetEntryPoints();
        System.Collections.Generic.IReadOnlyList<NuGet.ProjectModel.ExternalProjectReference> GetReferences(string entryPointPath);
    }
    public partial interface IHashFunction : System.IDisposable
    {
        string GetHash();
        void Update(byte[] data, int offset, int count);
    }
    public partial class IncludeExcludeFiles : System.IEquatable<NuGet.ProjectModel.IncludeExcludeFiles>
    {
        public IncludeExcludeFiles() { }
        public System.Collections.Generic.IReadOnlyList<string> Exclude { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IReadOnlyList<string> ExcludeFiles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IReadOnlyList<string> Include { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IReadOnlyList<string> IncludeFiles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.ProjectModel.IncludeExcludeFiles other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public bool HandleIncludeExcludeFiles(Newtonsoft.Json.Linq.JObject jsonObject) { throw null; }
    }
    public partial class JsonPackageSpecReader
    {
        public static readonly string Files;
        public static readonly string PackageType;
        public static readonly string PackOptions;
        public static readonly string RestoreOptions;
        public JsonPackageSpecReader() { }
        public static NuGet.ProjectModel.PackageSpec GetPackageSpec(Newtonsoft.Json.Linq.JObject json) { throw null; }
        public static NuGet.ProjectModel.PackageSpec GetPackageSpec(Newtonsoft.Json.Linq.JObject rawPackageSpec, string name, string packageSpecPath, string snapshotValue) { throw null; }
        public static NuGet.ProjectModel.PackageSpec GetPackageSpec(System.IO.Stream stream, string name, string packageSpecPath, string snapshotValue) { throw null; }
        public static NuGet.ProjectModel.PackageSpec GetPackageSpec(string name, string packageSpecPath) { throw null; }
        public static NuGet.ProjectModel.PackageSpec GetPackageSpec(string json, string name, string packageSpecPath) { throw null; }
    }
    public static partial class JTokenExtensions
    {
        public static T GetValue<T>(this Newtonsoft.Json.Linq.JToken token, string name) { throw null; }
        public static T[] ValueAsArray<T>(this Newtonsoft.Json.Linq.JToken jToken) { throw null; }
        public static T[] ValueAsArray<T>(this Newtonsoft.Json.Linq.JToken jToken, string name) { throw null; }
    }
    public partial class LockFile : System.IEquatable<NuGet.ProjectModel.LockFile>
    {
        public static readonly char DirectorySeparatorChar;
        public static readonly NuGet.Frameworks.NuGetFramework ToolFramework;
        public LockFile() { }
        public System.Collections.Generic.IList<NuGet.ProjectModel.LockFileLibrary> Libraries { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.LockFileItem> PackageFolders { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.ProjectModel.PackageSpec PackageSpec { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.ProjectFileDependencyGroup> ProjectFileDependencyGroups { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.LockFileTarget> Targets { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public int Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.ProjectModel.LockFile other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public NuGet.ProjectModel.LockFileLibrary GetLibrary(string name, NuGet.Versioning.NuGetVersion version) { throw null; }
        public NuGet.ProjectModel.LockFileTarget GetTarget(NuGet.Frameworks.NuGetFramework framework, string runtimeIdentifier) { throw null; }
        public bool IsValidForPackageSpec(NuGet.ProjectModel.PackageSpec spec) { throw null; }
        public bool IsValidForPackageSpec(NuGet.ProjectModel.PackageSpec spec, int requestLockFileVersion) { throw null; }
    }
    public partial class LockFileContentFile : NuGet.ProjectModel.LockFileItem
    {
        public static readonly string BuildActionProperty;
        public static readonly string CodeLanguageProperty;
        public static readonly string CopyToOutputProperty;
        public static readonly string OutputPathProperty;
        public static readonly string PPOutputPathProperty;
        public LockFileContentFile(string path) : base (default(string)) { }
        public NuGet.ProjectModel.BuildAction BuildAction { get { throw null; } set { } }
        public string CodeLanguage { get { throw null; } set { } }
        public bool CopyToOutput { get { throw null; } set { } }
        public string OutputPath { get { throw null; } set { } }
        public string PPOutputPath { get { throw null; } set { } }
    }
    public partial class LockFileDependencyProvider : NuGet.DependencyResolver.IDependencyProvider
    {
        public LockFileDependencyProvider(NuGet.ProjectModel.LockFile lockFile) { }
        public NuGet.LibraryModel.Library GetLibrary(NuGet.LibraryModel.LibraryRange libraryRange, NuGet.Frameworks.NuGetFramework targetFramework) { throw null; }
        public bool SupportsType(NuGet.LibraryModel.LibraryDependencyTarget libraryType) { throw null; }
    }
    public partial class LockFileFormat
    {
        public static readonly string AssetsFileName;
        public static readonly string LockFileName;
        public static readonly int Version;
        public LockFileFormat() { }
        public NuGet.ProjectModel.LockFile Parse(string lockFileContent, NuGet.Common.ILogger log, string path) { throw null; }
        public NuGet.ProjectModel.LockFile Parse(string lockFileContent, string path) { throw null; }
        public NuGet.ProjectModel.LockFile Read(System.IO.Stream stream, NuGet.Common.ILogger log, string path) { throw null; }
        public NuGet.ProjectModel.LockFile Read(System.IO.Stream stream, string path) { throw null; }
        public NuGet.ProjectModel.LockFile Read(System.IO.TextReader reader, NuGet.Common.ILogger log, string path) { throw null; }
        public NuGet.ProjectModel.LockFile Read(System.IO.TextReader reader, string path) { throw null; }
        public NuGet.ProjectModel.LockFile Read(string filePath) { throw null; }
        public NuGet.ProjectModel.LockFile Read(string filePath, NuGet.Common.ILogger log) { throw null; }
        public string Render(NuGet.ProjectModel.LockFile lockFile) { throw null; }
        public void Write(System.IO.Stream stream, NuGet.ProjectModel.LockFile lockFile) { }
        public void Write(System.IO.TextWriter textWriter, NuGet.ProjectModel.LockFile lockFile) { }
        public void Write(string filePath, NuGet.ProjectModel.LockFile lockFile) { }
    }
    public partial class LockFileItem : System.IEquatable<NuGet.ProjectModel.LockFileItem>
    {
        public LockFileItem(string path) { }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Equals(NuGet.ProjectModel.LockFileItem other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        protected string GetProperty(string name) { throw null; }
        public static implicit operator NuGet.ProjectModel.LockFileItem (string path) { throw null; }
        protected void SetProperty(string name, string value) { }
        public override string ToString() { throw null; }
    }
    public partial class LockFileLibrary : System.IEquatable<NuGet.ProjectModel.LockFileLibrary>
    {
        public LockFileLibrary() { }
        public System.Collections.Generic.IList<string> Files { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool IsServiceable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string MSBuildProject { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Sha512 { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Type { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Versioning.NuGetVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.ProjectModel.LockFileLibrary Clone() { throw null; }
        public bool Equals(NuGet.ProjectModel.LockFileLibrary other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class LockFileRuntimeTarget : NuGet.ProjectModel.LockFileItem
    {
        public static readonly string AssetTypeProperty;
        public static readonly string RidProperty;
        public LockFileRuntimeTarget(string path) : base (default(string)) { }
        public LockFileRuntimeTarget(string path, string runtime, string assetType) : base (default(string)) { }
        public string AssetType { get { throw null; } set { } }
        public string Runtime { get { throw null; } set { } }
    }
    public partial class LockFileTarget : System.IEquatable<NuGet.ProjectModel.LockFileTarget>
    {
        public LockFileTarget() { }
        public System.Collections.Generic.IList<NuGet.ProjectModel.LockFileTargetLibrary> Libraries { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Name { get { throw null; } }
        public string RuntimeIdentifier { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Frameworks.NuGetFramework TargetFramework { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.ProjectModel.LockFileTarget other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class LockFileTargetLibrary : System.IEquatable<NuGet.ProjectModel.LockFileTargetLibrary>
    {
        public LockFileTargetLibrary() { }
        public System.Collections.Generic.IList<NuGet.ProjectModel.LockFileItem> Build { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.LockFileItem> BuildMultiTargeting { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.LockFileItem> CompileTimeAssemblies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.LockFileContentFile> ContentFiles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.Packaging.Core.PackageDependency> Dependencies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Framework { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<string> FrameworkAssemblies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.LockFileItem> NativeLibraries { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.LockFileItem> ResourceAssemblies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.LockFileItem> RuntimeAssemblies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.LockFileRuntimeTarget> RuntimeTargets { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Type { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Versioning.NuGetVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.ProjectModel.LockFileTargetLibrary other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public static partial class LockFileUtilities
    {
        public static NuGet.ProjectModel.LockFile GetLockFile(string lockFilePath, NuGet.Common.ILogger logger) { throw null; }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{Name}")]
    public partial class PackageSpec
    {
        public static readonly NuGet.Versioning.NuGetVersion DefaultVersion;
        public static readonly string PackageSpecFileName;
        public PackageSpec() { }
        public PackageSpec(System.Collections.Generic.IList<NuGet.ProjectModel.TargetFrameworkInformation> frameworks) { }
        public string[] Authors { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string BaseDirectory { get { throw null; } }
        public NuGet.ProjectModel.BuildOptions BuildOptions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<string> ContentFiles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Copyright { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.LibraryModel.LibraryDependency> Dependencies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Description { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string FilePath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool HasVersionSnapshot { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string IconUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool IsDefaultVersion { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Language { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string LicenseUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string[] Owners { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IDictionary<string, string> PackInclude { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.ProjectModel.PackOptions PackOptions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string ProjectUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string ReleaseNotes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool RequireLicenseAcceptance { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.ProjectModel.ProjectRestoreMetadata RestoreMetadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.RuntimeModel.RuntimeGraph RuntimeGraph { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IEnumerable<string>> Scripts { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Summary { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string[] Tags { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.TargetFrameworkInformation> TargetFrameworks { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Title { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Versioning.NuGetVersion Version { get { throw null; } set { } }
        public NuGet.ProjectModel.PackageSpec Clone() { throw null; }
        public bool Equals(NuGet.ProjectModel.PackageSpec other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public static partial class PackageSpecExtensions
    {
        public static NuGet.ProjectModel.ProjectRestoreMetadataFrameworkInfo GetRestoreMetadataFramework(this NuGet.ProjectModel.PackageSpec project, NuGet.Frameworks.NuGetFramework targetFramework) { throw null; }
        public static NuGet.ProjectModel.TargetFrameworkInformation GetTargetFramework(this NuGet.ProjectModel.PackageSpec project, NuGet.Frameworks.NuGetFramework targetFramework) { throw null; }
    }
    public static partial class PackageSpecOperations
    {
        public static void AddOrUpdateDependency(NuGet.ProjectModel.PackageSpec spec, NuGet.Packaging.Core.PackageDependency dependency) { }
        public static void AddOrUpdateDependency(NuGet.ProjectModel.PackageSpec spec, NuGet.Packaging.Core.PackageDependency dependency, System.Collections.Generic.IEnumerable<NuGet.Frameworks.NuGetFramework> frameworksToAdd) { }
        public static void AddOrUpdateDependency(NuGet.ProjectModel.PackageSpec spec, NuGet.Packaging.Core.PackageIdentity identity) { }
        public static void AddOrUpdateDependency(NuGet.ProjectModel.PackageSpec spec, NuGet.Packaging.Core.PackageIdentity identity, System.Collections.Generic.IEnumerable<NuGet.Frameworks.NuGetFramework> frameworksToAdd) { }
        public static bool HasPackage(NuGet.ProjectModel.PackageSpec spec, string packageId) { throw null; }
        public static void RemoveDependency(NuGet.ProjectModel.PackageSpec spec, string packageId) { }
    }
    public partial class PackageSpecReferenceDependencyProvider : NuGet.DependencyResolver.IDependencyProvider
    {
        public PackageSpecReferenceDependencyProvider(System.Collections.Generic.IEnumerable<NuGet.ProjectModel.ExternalProjectReference> externalProjects, NuGet.Common.ILogger logger) { }
        public NuGet.LibraryModel.Library GetLibrary(NuGet.LibraryModel.LibraryRange libraryRange, NuGet.Frameworks.NuGetFramework targetFramework) { throw null; }
        public bool SupportsType(NuGet.LibraryModel.LibraryDependencyTarget libraryType) { throw null; }
    }
    public static partial class PackageSpecUtility
    {
        public static bool IsSnapshotVersion(string version) { throw null; }
        public static NuGet.Versioning.NuGetVersion SpecifySnapshot(string version, string snapshotValue) { throw null; }
    }
    public sealed partial class PackageSpecWriter
    {
        public PackageSpecWriter() { }
        public static void Write(NuGet.ProjectModel.PackageSpec packageSpec, NuGet.RuntimeModel.IObjectWriter writer) { }
        public static void WriteToFile(NuGet.ProjectModel.PackageSpec packageSpec, string filePath) { }
    }
    public partial class PackOptions : System.IEquatable<NuGet.ProjectModel.PackOptions>
    {
        public PackOptions() { }
        public NuGet.ProjectModel.IncludeExcludeFiles IncludeExcludeFiles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IDictionary<string, NuGet.ProjectModel.IncludeExcludeFiles> Mappings { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IReadOnlyList<NuGet.Packaging.Core.PackageType> PackageType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.ProjectModel.PackOptions other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class ProjectFileDependencyGroup : System.IEquatable<NuGet.ProjectModel.ProjectFileDependencyGroup>
    {
        public ProjectFileDependencyGroup(string frameworkName, System.Collections.Generic.IEnumerable<string> dependencies) { }
        public System.Collections.Generic.IEnumerable<string> Dependencies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string FrameworkName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Equals(NuGet.ProjectModel.ProjectFileDependencyGroup other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class ProjectRestoreMetadata : System.IEquatable<NuGet.ProjectModel.ProjectRestoreMetadata>
    {
        public ProjectRestoreMetadata() { }
        public bool CrossTargeting { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<string> FallbackFolders { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.ProjectRestoreMetadataFile> Files { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool LegacyPackagesDirectory { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<string> OriginalTargetFrameworks { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string OutputPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string PackagesPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string ProjectJsonPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string ProjectName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string ProjectPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.ProjectModel.ProjectStyle ProjectStyle { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string ProjectUniqueName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool SkipContentFileWrite { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.Configuration.PackageSource> Sources { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.ProjectRestoreMetadataFrameworkInfo> TargetFrameworks { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool ValidateRuntimeAssets { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.ProjectModel.ProjectRestoreMetadata other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class ProjectRestoreMetadataFile : System.IComparable<NuGet.ProjectModel.ProjectRestoreMetadataFile>, System.IEquatable<NuGet.ProjectModel.ProjectRestoreMetadataFile>
    {
        public ProjectRestoreMetadataFile(string packagePath, string absolutePath) { }
        public string AbsolutePath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string PackagePath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public int CompareTo(NuGet.ProjectModel.ProjectRestoreMetadataFile other) { throw null; }
        public bool Equals(NuGet.ProjectModel.ProjectRestoreMetadataFile other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProjectRestoreMetadataFrameworkInfo : System.IEquatable<NuGet.ProjectModel.ProjectRestoreMetadataFrameworkInfo>
    {
        public ProjectRestoreMetadataFrameworkInfo() { }
        public ProjectRestoreMetadataFrameworkInfo(NuGet.Frameworks.NuGetFramework frameworkName) { }
        public NuGet.Frameworks.NuGetFramework FrameworkName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string OriginalFrameworkName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.ProjectModel.ProjectRestoreReference> ProjectReferences { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.ProjectModel.ProjectRestoreMetadataFrameworkInfo other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProjectRestoreReference : System.IEquatable<NuGet.ProjectModel.ProjectRestoreReference>
    {
        public ProjectRestoreReference() { }
        public NuGet.LibraryModel.LibraryIncludeFlags ExcludeAssets { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.LibraryModel.LibraryIncludeFlags IncludeAssets { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.LibraryModel.LibraryIncludeFlags PrivateAssets { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string ProjectPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string ProjectUniqueName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.ProjectModel.ProjectRestoreReference other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ProjectStyle : ushort
    {
        DotnetCliTool = (ushort)3,
        PackageReference = (ushort)2,
        PackagesConfig = (ushort)5,
        ProjectJson = (ushort)1,
        Standalone = (ushort)4,
        Unknown = (ushort)0,
    }
    public sealed partial class Sha512HashFunction : NuGet.ProjectModel.IHashFunction, System.IDisposable
    {
        public Sha512HashFunction() { }
        public void Dispose() { }
        public string GetHash() { throw null; }
        public void Update(byte[] data, int offset, int count) { }
    }
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public partial class Strings
    {
        internal Strings() { }
        public static string ArgumentNullOrEmpty { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        public static string InvalidDependencyTarget { get { throw null; } }
        public static string InvalidPackageType { get { throw null; } }
        public static string Log_ErrorReadingLockFile { get { throw null; } }
        public static string Log_ErrorReadingProjectJson { get { throw null; } }
        public static string Log_ErrorReadingProjectJsonWithLocation { get { throw null; } }
        public static string Log_InvalidImportFramework { get { throw null; } }
        public static string MissingToolName { get { throw null; } }
        public static string MissingVersionOnDependency { get { throw null; } }
        public static string MissingVersionOnTool { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Resources.ResourceManager ResourceManager { get { throw null; } }
    }
    public partial class TargetFrameworkInformation : System.IEquatable<NuGet.ProjectModel.TargetFrameworkInformation>
    {
        public TargetFrameworkInformation() { }
        public System.Collections.Generic.IList<NuGet.LibraryModel.LibraryDependency> Dependencies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Frameworks.NuGetFramework FrameworkName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.Frameworks.NuGetFramework> Imports { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Warn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.ProjectModel.TargetFrameworkInformation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ToolPathResolver
    {
        public ToolPathResolver(string packagesDirectory) { }
        public ToolPathResolver(string packagesDirectory, bool isLowercase) { }
        public string GetLockFilePath(string packageId, NuGet.Versioning.NuGetVersion version, NuGet.Frameworks.NuGetFramework framework) { throw null; }
        public string GetToolsBasePath() { throw null; }
    }
}
