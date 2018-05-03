[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("Microsoft Corporation. All rights reserved.")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("NuGet's implementation for reading nupkg package and nuspec package specification files.")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("3.5.0.1996")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("3.5.0-rtm-1996")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("NuGet")]
[assembly:System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.InteropServices.ComVisibleAttribute(false)]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.3")]
namespace NuGet.Packaging
{
    public static partial class CollectionExtensions
    {
        public static void AddRange<T>(this System.Collections.Generic.ICollection<T> collection, System.Collections.Generic.IEnumerable<T> items) { }
    }
    public partial class FallbackPackagePathInfo
    {
        public FallbackPackagePathInfo(string id, NuGet.Versioning.NuGetVersion version, NuGet.Packaging.VersionFolderPathResolver resolver) { }
        public string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Packaging.VersionFolderPathResolver PathResolver { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Versioning.NuGetVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class FallbackPackagePathResolver
    {
        public FallbackPackagePathResolver(NuGet.Common.INuGetPathContext pathContext) { }
        public FallbackPackagePathResolver(string userPackageFolder, System.Collections.Generic.IEnumerable<string> fallbackPackageFolders) { }
        public string GetPackageDirectory(string packageId, NuGet.Versioning.NuGetVersion version) { throw null; }
        public string GetPackageDirectory(string packageId, string version) { throw null; }
        public NuGet.Packaging.FallbackPackagePathInfo GetPackageInfo(string packageId, NuGet.Versioning.NuGetVersion version) { throw null; }
    }
    public partial class FrameworkAssemblyReference
    {
        public FrameworkAssemblyReference(string assemblyName, System.Collections.Generic.IEnumerable<NuGet.Frameworks.NuGetFramework> supportedFrameworks) { }
        public string AssemblyName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IEnumerable<NuGet.Frameworks.NuGetFramework> SupportedFrameworks { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public static partial class FrameworkNameUtility
    {
        public static System.Runtime.Versioning.FrameworkName ParseFrameworkFolderName(string path, bool strictParsing, out string effectivePath) { effectivePath = default(string); throw null; }
        public static System.Runtime.Versioning.FrameworkName ParseFrameworkNameFromFilePath(string filePath, out string effectivePath) { effectivePath = default(string); throw null; }
    }
    public static partial class FrameworksExtensions
    {
        public static string GetFrameworkString(this NuGet.Frameworks.NuGetFramework self) { throw null; }
    }
    public partial interface INuspecReader : NuGet.Packaging.Core.INuspecCoreReader
    {
        System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> GetDependencyGroups();
        System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetFrameworkReferenceGroups();
        string GetLanguage();
        System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetReferenceGroups();
    }
    public partial interface IPackageContentReader
    {
        System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetBuildItems();
        System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetContentItems();
        System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetFrameworkItems();
        System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetLibItems();
        System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> GetPackageDependencies();
        System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetReferenceItems();
        System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetToolItems();
    }
    public partial interface IPackageFile
    {
        string EffectivePath { get; }
        string Path { get; }
        System.Runtime.Versioning.FrameworkName TargetFramework { get; }
        System.IO.Stream GetStream();
    }
    public partial interface IPackageMetadata
    {
        System.Collections.Generic.IEnumerable<string> Authors { get; }
        System.Collections.Generic.IEnumerable<NuGet.Packaging.ManifestContentFiles> ContentFiles { get; }
        string Copyright { get; }
        System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> DependencyGroups { get; }
        string Description { get; }
        bool DevelopmentDependency { get; }
        System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkAssemblyReference> FrameworkReferences { get; }
        System.Uri IconUrl { get; }
        string Id { get; }
        string Language { get; }
        System.Uri LicenseUrl { get; }
        System.Version MinClientVersion { get; }
        System.Collections.Generic.IEnumerable<string> Owners { get; }
        System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageReferenceSet> PackageAssemblyReferences { get; }
        System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageType> PackageTypes { get; }
        System.Uri ProjectUrl { get; }
        string ReleaseNotes { get; }
        bool RequireLicenseAcceptance { get; }
        bool Serviceable { get; }
        string Summary { get; }
        string Tags { get; }
        string Title { get; }
        NuGet.Versioning.NuGetVersion Version { get; }
    }
    public partial interface IPackageResolver
    {
        System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageIdentity> Resolve(System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageIdentity> targets, System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependencyInfo> availablePackages, System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageReference> installedPackages, System.Threading.CancellationToken token);
        System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageIdentity> Resolve(System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageIdentity> targets, System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependencyInfo> availablePackages, System.Threading.CancellationToken token);
        System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageIdentity> Resolve(System.Collections.Generic.IEnumerable<string> targets, System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependencyInfo> availablePackages, System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageReference> installedPackages, System.Threading.CancellationToken token);
        System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageIdentity> Resolve(System.Collections.Generic.IEnumerable<string> targets, System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependencyInfo> availablePackages, System.Threading.CancellationToken token);
    }
    public partial class Manifest
    {
        public Manifest(NuGet.Packaging.ManifestMetadata metadata) { }
        public Manifest(NuGet.Packaging.ManifestMetadata metadata, System.Collections.Generic.ICollection<NuGet.Packaging.ManifestFile> files) { }
        public System.Collections.Generic.ICollection<NuGet.Packaging.ManifestFile> Files { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool HasFilesNode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Packaging.ManifestMetadata Metadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static NuGet.Packaging.Manifest Create(NuGet.Packaging.IPackageMetadata metadata) { throw null; }
        public static NuGet.Packaging.Manifest ReadFrom(System.IO.Stream stream, bool validateSchema) { throw null; }
        public static NuGet.Packaging.Manifest ReadFrom(System.IO.Stream stream, System.Func<string, string> propertyProvider, bool validateSchema) { throw null; }
        public void Save(System.IO.Stream stream) { }
        public void Save(System.IO.Stream stream, bool validate) { }
        public void Save(System.IO.Stream stream, bool validate, int minimumManifestVersion) { }
        public void Save(System.IO.Stream stream, int minimumManifestVersion) { }
        public static void Validate(NuGet.Packaging.Manifest manifest) { }
    }
    public partial class ManifestContentFiles
    {
        public ManifestContentFiles() { }
        public string BuildAction { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string CopyToOutput { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Exclude { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Flatten { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Include { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class ManifestFile
    {
        public ManifestFile() { }
        public string Exclude { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Source { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Target { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<string> Validate() { throw null; }
    }
    public partial class ManifestMetadata : NuGet.Packaging.IPackageMetadata
    {
        public ManifestMetadata() { }
        public ManifestMetadata(NuGet.Packaging.IPackageMetadata copy) { }
        public System.Collections.Generic.IEnumerable<string> Authors { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.ManifestContentFiles> ContentFiles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Copyright { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> DependencyGroups { get { throw null; } set { } }
        public string Description { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool DevelopmentDependency { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkAssemblyReference> FrameworkReferences { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Uri IconUrl { get { throw null; } }
        public string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Language { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Uri LicenseUrl { get { throw null; } }
        public System.Version MinClientVersion { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string MinClientVersionString { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<string> Owners { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageReferenceSet> PackageAssemblyReferences { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageType> PackageTypes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Uri ProjectUrl { get { throw null; } }
        public string ReleaseNotes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool RequireLicenseAcceptance { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Serviceable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Summary { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Tags { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Title { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Versioning.NuGetVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public void SetIconUrl(string iconUrl) { }
        public void SetLicenseUrl(string licenseUrl) { }
        public void SetProjectUrl(string projectUrl) { }
        public System.Collections.Generic.IEnumerable<string> Validate() { throw null; }
    }
    public static partial class ManifestSchemaUtility
    {
        public static string GetSchemaNamespace(int version) { throw null; }
        public static int GetVersionFromNamespace(string @namespace) { throw null; }
        public static bool IsKnownSchema(string schemaNamespace) { throw null; }
    }
    public static partial class ManifestVersionUtility
    {
        public const int DefaultVersion = 1;
        public const int SemverVersion = 3;
        public const int TargetFrameworkSupportForDependencyContentsAndToolsVersion = 4;
        public const int TargetFrameworkSupportForReferencesVersion = 5;
        public const int XdtTransformationVersion = 6;
        public static int GetManifestVersion(NuGet.Packaging.ManifestMetadata metadata) { throw null; }
    }
    public partial class MinClientVersionException : NuGet.Packaging.Core.PackagingException
    {
        public MinClientVersionException(string message) : base (default(string)) { }
    }
    public static partial class MinClientVersionUtility
    {
        public static NuGet.Versioning.NuGetVersion GetNuGetClientVersion() { throw null; }
        public static bool IsMinClientVersionCompatible(NuGet.Packaging.Core.NuspecCoreReaderBase nuspecReader) { throw null; }
        public static bool IsMinClientVersionCompatible(NuGet.Versioning.NuGetVersion packageMinClientVersion) { throw null; }
        public static void VerifyMinClientVersion(NuGet.Packaging.Core.NuspecCoreReaderBase nuspecReader) { }
    }
    public partial class NuspecReader : NuGet.Packaging.Core.NuspecCoreReaderBase
    {
        public NuspecReader(System.IO.Stream stream) : base (default(string)) { }
        public NuspecReader(System.IO.Stream stream, NuGet.Frameworks.IFrameworkNameProvider frameworkProvider, bool leaveStreamOpen) : base (default(string)) { }
        public NuspecReader(string path) : base (default(string)) { }
        public NuspecReader(string path, NuGet.Frameworks.IFrameworkNameProvider frameworkProvider) : base (default(string)) { }
        public NuspecReader(System.Xml.Linq.XDocument xml) : base (default(string)) { }
        public NuspecReader(System.Xml.Linq.XDocument xml, NuGet.Frameworks.IFrameworkNameProvider frameworkProvider) : base (default(string)) { }
        public string GetAuthors() { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.ContentFilesEntry> GetContentFiles() { throw null; }
        public string GetCopyright() { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> GetDependencyGroups() { throw null; }
        public string GetDescription() { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetFrameworkReferenceGroups() { throw null; }
        public string GetIconUrl() { throw null; }
        public string GetLanguage() { throw null; }
        public string GetLicenseUrl() { throw null; }
        public string GetOwners() { throw null; }
        public string GetProjectUrl() { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetReferenceGroups() { throw null; }
        public string GetReleaseNotes() { throw null; }
        public bool GetRequireLicenseAcceptance() { throw null; }
        public string GetSummary() { throw null; }
        public string GetTags() { throw null; }
        public string GetTitle() { throw null; }
    }
    public partial class PackageArchiveReader : NuGet.Packaging.PackageReaderBase
    {
        public PackageArchiveReader(System.IO.Compression.ZipArchive zipArchive) : base (default(NuGet.Frameworks.IFrameworkNameProvider)) { }
        public PackageArchiveReader(System.IO.Compression.ZipArchive zipArchive, NuGet.Frameworks.IFrameworkNameProvider frameworkProvider, NuGet.Frameworks.IFrameworkCompatibilityProvider compatibilityProvider) : base (default(NuGet.Frameworks.IFrameworkNameProvider)) { }
        public PackageArchiveReader(System.IO.Stream stream) : base (default(NuGet.Frameworks.IFrameworkNameProvider)) { }
        public PackageArchiveReader(System.IO.Stream stream, NuGet.Frameworks.IFrameworkNameProvider frameworkProvider, NuGet.Frameworks.IFrameworkCompatibilityProvider compatibilityProvider) : base (default(NuGet.Frameworks.IFrameworkNameProvider)) { }
        public PackageArchiveReader(System.IO.Stream stream, bool leaveStreamOpen) : base (default(NuGet.Frameworks.IFrameworkNameProvider)) { }
        public PackageArchiveReader(System.IO.Stream stream, bool leaveStreamOpen, NuGet.Frameworks.IFrameworkNameProvider frameworkProvider, NuGet.Frameworks.IFrameworkCompatibilityProvider compatibilityProvider) : base (default(NuGet.Frameworks.IFrameworkNameProvider)) { }
        public PackageArchiveReader(string filePath, NuGet.Frameworks.IFrameworkNameProvider frameworkProvider=null, NuGet.Frameworks.IFrameworkCompatibilityProvider compatibilityProvider=null) : base (default(NuGet.Frameworks.IFrameworkNameProvider)) { }
        public override System.Collections.Generic.IEnumerable<string> CopyFiles(string destination, System.Collections.Generic.IEnumerable<string> packageFiles, NuGet.Packaging.Core.ExtractPackageFileDelegate extractFile, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        protected override void Dispose(bool disposing) { }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.ZipFilePair> EnumeratePackageEntries(System.Collections.Generic.IEnumerable<string> packageFiles, string packageDirectory) { throw null; }
        public string ExtractFile(string packageFile, string targetFilePath, NuGet.Common.ILogger logger) { throw null; }
        public override System.Collections.Generic.IEnumerable<string> GetFiles() { throw null; }
        public override System.Collections.Generic.IEnumerable<string> GetFiles(string folder) { throw null; }
        public override System.IO.Stream GetStream(string path) { throw null; }
    }
    public partial class PackageBuilder : NuGet.Packaging.IPackageMetadata
    {
        public PackageBuilder() { }
        public PackageBuilder(System.IO.Stream stream, string basePath) { }
        public PackageBuilder(System.IO.Stream stream, string basePath, System.Func<string, string> propertyProvider) { }
        public PackageBuilder(string path, System.Func<string, string> propertyProvider, bool includeEmptyDirectories) { }
        public PackageBuilder(string path, string basePath, System.Func<string, string> propertyProvider, bool includeEmptyDirectories) { }
        public System.Collections.Generic.ISet<string> Authors { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.ICollection<NuGet.Packaging.ManifestContentFiles> ContentFiles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Copyright { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.ObjectModel.Collection<NuGet.Packaging.PackageDependencyGroup> DependencyGroups { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Description { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool DevelopmentDependency { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.ICollection<NuGet.Packaging.IPackageFile> Files { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.ObjectModel.Collection<NuGet.Packaging.FrameworkAssemblyReference> FrameworkReferences { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool HasSnapshotVersion { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Uri IconUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Language { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Uri LicenseUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Version MinClientVersion { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        System.Collections.Generic.IEnumerable<string> NuGet.Packaging.IPackageMetadata.Authors { get { throw null; } }
        System.Collections.Generic.IEnumerable<NuGet.Packaging.ManifestContentFiles> NuGet.Packaging.IPackageMetadata.ContentFiles { get { throw null; } }
        System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> NuGet.Packaging.IPackageMetadata.DependencyGroups { get { throw null; } }
        System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkAssemblyReference> NuGet.Packaging.IPackageMetadata.FrameworkReferences { get { throw null; } }
        System.Collections.Generic.IEnumerable<string> NuGet.Packaging.IPackageMetadata.Owners { get { throw null; } }
        System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageReferenceSet> NuGet.Packaging.IPackageMetadata.PackageAssemblyReferences { get { throw null; } }
        System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageType> NuGet.Packaging.IPackageMetadata.PackageTypes { get { throw null; } }
        string NuGet.Packaging.IPackageMetadata.Tags { get { throw null; } }
        public string OutputName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.ISet<string> Owners { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.ICollection<NuGet.Packaging.PackageReferenceSet> PackageAssemblyReferences { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.ICollection<NuGet.Packaging.Core.PackageType> PackageTypes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Uri ProjectUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.Dictionary<string, string> Properties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string ReleaseNotes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool RequireLicenseAcceptance { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Serviceable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Summary { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.ISet<string> Tags { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IList<NuGet.Frameworks.NuGetFramework> TargetFrameworks { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Title { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Versioning.NuGetVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public void AddFiles(string basePath, string source, string destination, string exclude=null) { }
        public void Populate(NuGet.Packaging.ManifestMetadata manifestMetadata) { }
        public void PopulateFiles(string basePath, System.Collections.Generic.IEnumerable<NuGet.Packaging.ManifestFile> files) { }
        public void Save(System.IO.Stream stream) { }
        public static void ValidateDependencyGroups(NuGet.Versioning.SemanticVersion version, System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> dependencies) { }
        public static void ValidateReferenceAssemblies(System.Collections.Generic.IEnumerable<NuGet.Packaging.IPackageFile> files, System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageReferenceSet> packageAssemblyReferences) { }
    }
    public partial class PackageExtractionContext
    {
        public PackageExtractionContext(NuGet.Common.ILogger logger) { }
        public bool CopySatelliteFiles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Common.ILogger Logger { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Packaging.PackageSaveMode PackageSaveMode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool UseLegacyPackageInstallPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Packaging.XmlDocFileSaveMode XmlDocFileSaveMode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public static partial class PackageExtractor
    {
        public static System.Collections.Generic.IEnumerable<string> CopySatelliteFiles(NuGet.Packaging.Core.PackageIdentity packageIdentity, NuGet.Packaging.PackagePathResolver packagePathResolver, NuGet.Packaging.PackageSaveMode packageSaveMode, NuGet.Packaging.PackageExtractionContext packageExtractionContext, System.Threading.CancellationToken token) { throw null; }
        public static System.Collections.Generic.IEnumerable<string> ExtractPackage(NuGet.Packaging.PackageReaderBase packageReader, System.IO.Stream packageStream, NuGet.Packaging.PackagePathResolver packagePathResolver, NuGet.Packaging.PackageExtractionContext packageExtractionContext, System.Threading.CancellationToken token) { throw null; }
        public static System.Collections.Generic.IEnumerable<string> ExtractPackage(System.IO.Stream packageStream, NuGet.Packaging.PackagePathResolver packagePathResolver, NuGet.Packaging.PackageExtractionContext packageExtractionContext, System.Threading.CancellationToken token) { throw null; }
        public static System.Threading.Tasks.Task InstallFromSourceAsync(System.Func<System.IO.Stream, System.Threading.Tasks.Task> copyToAsync, NuGet.Packaging.VersionFolderPathContext versionFolderPathContext, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class PackageFileExtractor
    {
        public PackageFileExtractor(System.Collections.Generic.IEnumerable<string> packageFiles, NuGet.Packaging.XmlDocFileSaveMode xmlDocFileSaveMode) { }
        public string ExtractPackageFile(string source, string target, System.IO.Stream stream) { throw null; }
    }
    public partial class PackageFolderReader : NuGet.Packaging.PackageReaderBase
    {
        public PackageFolderReader(System.IO.DirectoryInfo folder) : base (default(NuGet.Frameworks.IFrameworkNameProvider)) { }
        public PackageFolderReader(System.IO.DirectoryInfo folder, NuGet.Frameworks.IFrameworkNameProvider frameworkProvider, NuGet.Frameworks.IFrameworkCompatibilityProvider compatibilityProvider) : base (default(NuGet.Frameworks.IFrameworkNameProvider)) { }
        public PackageFolderReader(string folderPath) : base (default(NuGet.Frameworks.IFrameworkNameProvider)) { }
        public PackageFolderReader(string folderPath, NuGet.Frameworks.IFrameworkNameProvider frameworkProvider, NuGet.Frameworks.IFrameworkCompatibilityProvider compatibilityProvider) : base (default(NuGet.Frameworks.IFrameworkNameProvider)) { }
        public override System.Collections.Generic.IEnumerable<string> CopyFiles(string destination, System.Collections.Generic.IEnumerable<string> packageFiles, NuGet.Packaging.Core.ExtractPackageFileDelegate extractFile, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        protected override void Dispose(bool disposing) { }
        public override System.Collections.Generic.IEnumerable<string> GetFiles() { throw null; }
        public override System.Collections.Generic.IEnumerable<string> GetFiles(string folder) { throw null; }
        public override string GetNuspecFile() { throw null; }
        public override System.IO.Stream GetStream(string path) { throw null; }
    }
    public static partial class PackageHelper
    {
        public static System.Collections.Generic.IEnumerable<NuGet.Packaging.ZipFilePair> GetInstalledPackageFiles(NuGet.Packaging.PackageArchiveReader packageReader, NuGet.Packaging.Core.PackageIdentity packageIdentity, NuGet.Packaging.PackagePathResolver packagePathResolver, NuGet.Packaging.PackageSaveMode packageSaveMode) { throw null; }
        public static System.Tuple<string, System.Collections.Generic.IEnumerable<NuGet.Packaging.ZipFilePair>> GetInstalledSatelliteFiles(NuGet.Packaging.PackageArchiveReader packageReader, NuGet.Packaging.PackagePathResolver packagePathResolver, NuGet.Packaging.PackageSaveMode packageSaveMode) { throw null; }
        public static System.Collections.Generic.IEnumerable<string> GetSatelliteFiles(NuGet.Packaging.PackageReaderBase packageReader, NuGet.Packaging.PackagePathResolver packagePathResolver, out string runtimePackageDirectory) { runtimePackageDirectory = default(string); throw null; }
        public static bool IsAssembly(string path) { throw null; }
        public static bool IsManifest(string path) { throw null; }
        public static bool IsNuspec(string path) { throw null; }
        public static bool IsPackageFile(string packageFileName, NuGet.Packaging.PackageSaveMode packageSaveMode) { throw null; }
        public static bool IsRoot(string path) { throw null; }
        public static bool IsSatellitePackage(NuGet.Packaging.Core.IPackageCoreReader packageReader, out NuGet.Packaging.Core.PackageIdentity runtimePackageIdentity, out string packageLanguage) { runtimePackageIdentity = default(NuGet.Packaging.Core.PackageIdentity); packageLanguage = default(string); throw null; }
    }
    public static partial class PackageIdValidator
    {
        public static bool IsValidPackageId(string packageId) { throw null; }
        public static void ValidatePackageId(string packageId) { }
    }
    public static partial class PackagePathHelper
    {
        public static string GetInstalledPackageFilePath(NuGet.Packaging.Core.PackageIdentity packageIdentity, NuGet.Packaging.PackagePathResolver packagePathResolver) { throw null; }
        public static System.Collections.Generic.IEnumerable<string> GetPackageLookupPaths(NuGet.Packaging.Core.PackageIdentity packageIdentity, NuGet.Packaging.PackagePathResolver packagePathResolver) { throw null; }
    }
    public partial class PackagePathResolver
    {
        public PackagePathResolver(string rootDirectory, bool useSideBySidePaths=true) { }
        protected internal string Root { get { throw null; } }
        public bool UseSideBySidePaths { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string GetInstalledPackageFilePath(NuGet.Packaging.Core.PackageIdentity packageIdentity) { throw null; }
        public string GetInstalledPath(NuGet.Packaging.Core.PackageIdentity packageIdentity) { throw null; }
        public string GetInstallPath(NuGet.Packaging.Core.PackageIdentity packageIdentity) { throw null; }
        public string GetManifestFileName(NuGet.Packaging.Core.PackageIdentity packageIdentity) { throw null; }
        public string GetPackageDirectoryName(NuGet.Packaging.Core.PackageIdentity packageIdentity) { throw null; }
        public string GetPackageFileName(NuGet.Packaging.Core.PackageIdentity packageIdentity) { throw null; }
    }
    public abstract partial class PackageReaderBase : NuGet.Packaging.Core.IPackageCoreReader, NuGet.Packaging.IPackageContentReader, System.IDisposable
    {
        public PackageReaderBase(NuGet.Frameworks.IFrameworkNameProvider frameworkProvider) { }
        public PackageReaderBase(NuGet.Frameworks.IFrameworkNameProvider frameworkProvider, NuGet.Frameworks.IFrameworkCompatibilityProvider compatibilityProvider) { }
        public virtual NuGet.Packaging.NuspecReader NuspecReader { get { throw null; } }
        public abstract System.Collections.Generic.IEnumerable<string> CopyFiles(string destination, System.Collections.Generic.IEnumerable<string> packageFiles, NuGet.Packaging.Core.ExtractPackageFileDelegate extractFile, NuGet.Common.ILogger logger, System.Threading.CancellationToken token);
        public void Dispose() { }
        protected abstract void Dispose(bool disposing);
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetBuildItems() { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetContentItems() { throw null; }
        public bool GetDevelopmentDependency() { throw null; }
        protected System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetFileGroups(string folder) { throw null; }
        public abstract System.Collections.Generic.IEnumerable<string> GetFiles();
        public abstract System.Collections.Generic.IEnumerable<string> GetFiles(string folder);
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetFrameworkItems() { throw null; }
        public virtual NuGet.Packaging.Core.PackageIdentity GetIdentity() { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetLibItems() { throw null; }
        public virtual NuGet.Versioning.NuGetVersion GetMinClientVersion() { throw null; }
        public virtual System.IO.Stream GetNuspec() { throw null; }
        public virtual string GetNuspecFile() { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> GetPackageDependencies() { throw null; }
        public virtual System.Collections.Generic.IReadOnlyList<NuGet.Packaging.Core.PackageType> GetPackageTypes() { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetReferenceItems() { throw null; }
        public abstract System.IO.Stream GetStream(string path);
        public System.Collections.Generic.IEnumerable<NuGet.Frameworks.NuGetFramework> GetSupportedFrameworks() { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> GetToolItems() { throw null; }
        public bool IsServiceable() { throw null; }
    }
    public static partial class PackageReaderExtensions
    {
        public static System.Collections.Generic.IEnumerable<string> GetPackageFiles(this NuGet.Packaging.Core.IPackageCoreReader packageReader, NuGet.Packaging.PackageSaveMode packageSaveMode) { throw null; }
        public static System.Collections.Generic.IEnumerable<string> GetSatelliteFiles(this NuGet.Packaging.IPackageContentReader packageReader, string packageLanguage) { throw null; }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{PackageIdentity} {TargetFramework}")]
    public partial class PackageReference
    {
        public PackageReference(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Frameworks.NuGetFramework targetFramework) { }
        public PackageReference(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Frameworks.NuGetFramework targetFramework, bool userInstalled) { }
        public PackageReference(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Frameworks.NuGetFramework targetFramework, bool userInstalled, bool developmentDependency, bool requireReinstallation) { }
        public PackageReference(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Frameworks.NuGetFramework targetFramework, bool userInstalled, bool developmentDependency, bool requireReinstallation, NuGet.Versioning.VersionRange allowedVersions) { }
        public NuGet.Versioning.VersionRange AllowedVersions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool HasAllowedVersions { get { throw null; } }
        public bool IsDevelopmentDependency { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool IsUserInstalled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Packaging.Core.PackageIdentity PackageIdentity { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool RequireReinstallation { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Frameworks.NuGetFramework TargetFramework { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class PackageReferenceSet
    {
        public PackageReferenceSet(NuGet.Frameworks.NuGetFramework targetFramework, System.Collections.Generic.IEnumerable<string> references) { }
        public PackageReferenceSet(System.Collections.Generic.IEnumerable<string> references) { }
        public PackageReferenceSet(string targetFramework, System.Collections.Generic.IEnumerable<string> references) { }
        public System.Collections.Generic.IReadOnlyCollection<string> References { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Frameworks.NuGetFramework TargetFramework { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Validate() { throw null; }
    }
    [System.FlagsAttribute]
    public enum PackageSaveMode
    {
        Defaultv2 = 6,
        Defaultv3 = 7,
        Files = 4,
        None = 0,
        Nupkg = 2,
        Nuspec = 1,
    }
    public static partial class PackagesConfig
    {
        public static readonly string allowedVersionsAttributeName;
        public static readonly string developmentDependencyAttributeName;
        public static readonly string IdAttributeName;
        public static readonly string MinClientAttributeName;
        public static readonly string PackageNodeName;
        public static readonly string PackagesNodeName;
        public static readonly string RequireInstallAttributeName;
        public static readonly string TargetFrameworkAttributeName;
        public static readonly string UserInstalledAttributeName;
        public static readonly string VersionAttributeName;
        public static bool BoolAttribute(System.Xml.Linq.XElement node, string name, bool defaultValue=false) { throw null; }
        public static bool HasAttributeValue(System.Xml.Linq.XElement node, string attributeName, string targetValue, out System.Xml.Linq.XElement element) { element = default(System.Xml.Linq.XElement); throw null; }
        public static bool TryGetAttribute(System.Xml.Linq.XElement node, string name, out string value) { value = default(string); throw null; }
    }
    public partial class PackagesConfigReader
    {
        public PackagesConfigReader(NuGet.Frameworks.IFrameworkNameProvider frameworkMappings, System.IO.Stream stream, bool leaveStreamOpen) { }
        public PackagesConfigReader(NuGet.Frameworks.IFrameworkNameProvider frameworkMappings, System.Xml.Linq.XDocument xml) { }
        public PackagesConfigReader(System.IO.Stream stream) { }
        public PackagesConfigReader(System.IO.Stream stream, bool leaveStreamOpen) { }
        public PackagesConfigReader(System.Xml.Linq.XDocument xml) { }
        public NuGet.Versioning.NuGetVersion GetMinClientVersion() { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageReference> GetPackages() { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageReference> GetPackages(bool allowDuplicatePackageIds) { throw null; }
    }
    public partial class PackagesConfigReaderException : NuGet.Packaging.Core.PackagingException
    {
        public PackagesConfigReaderException(string message) : base (default(string)) { }
        public PackagesConfigReaderException(string message, System.Exception innerException) : base (default(string)) { }
    }
    public partial class PackagesConfigWriter : System.IDisposable
    {
        public PackagesConfigWriter(System.IO.Stream stream, bool createNew) { }
        public PackagesConfigWriter(System.IO.Stream stream, bool createNew, NuGet.Frameworks.IFrameworkNameProvider frameworkMappings) { }
        public PackagesConfigWriter(string fullPath, bool createNew) { }
        public PackagesConfigWriter(string fullPath, bool createNew, NuGet.Frameworks.IFrameworkNameProvider frameworkMappings) { }
        public void AddPackageEntry(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Frameworks.NuGetFramework targetFramework) { }
        public void AddPackageEntry(NuGet.Packaging.PackageReference entry) { }
        public void AddPackageEntry(string packageId, NuGet.Versioning.NuGetVersion version, NuGet.Frameworks.NuGetFramework targetFramework) { }
        public void Dispose() { }
        public void RemovePackageEntry(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Frameworks.NuGetFramework targetFramework) { }
        public void RemovePackageEntry(NuGet.Packaging.PackageReference entry) { }
        public void RemovePackageEntry(string packageId, NuGet.Versioning.NuGetVersion version, NuGet.Frameworks.NuGetFramework targetFramework) { }
        public void UpdateOrAddPackageEntry(System.Xml.Linq.XDocument originalConfig, NuGet.Packaging.PackageReference newEntry) { }
        public void UpdatePackageEntry(NuGet.Packaging.PackageReference oldEntry, NuGet.Packaging.PackageReference newEntry) { }
        public void WriteFile(string fullPath) { }
        public void WriteMinClientVersion(NuGet.Versioning.NuGetVersion version) { }
    }
    public partial class PackagesConfigWriterException : NuGet.Packaging.Core.PackagingException
    {
        public PackagesConfigWriterException(string message) : base (default(string)) { }
        public PackagesConfigWriterException(string message, System.Exception innerException) : base (default(string)) { }
    }
    public static partial class PackagingConstants
    {
        public static readonly string AgnosticFramework;
        public static readonly string AnyFramework;
        public static readonly string ContentFilesDefaultBuildAction;
        public static readonly string ManifestExtension;
        public static readonly string TargetFrameworkPropertyKey;
        public static partial class Folders
        {
            public static readonly string Analyzers;
            public static readonly string Build;
            public static readonly string Content;
            public static readonly string ContentFiles;
            public static readonly string Lib;
            public static readonly string Native;
            public static readonly string Ref;
            public static readonly string Runtimes;
            public static readonly string Tools;
            public static string[] Known { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        }
    }
    public partial class PhysicalPackageFile : NuGet.Packaging.IPackageFile
    {
        public PhysicalPackageFile() { }
        public PhysicalPackageFile(System.IO.MemoryStream stream) { }
        public string EffectivePath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Path { get { throw null; } }
        public string SourcePath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Runtime.Versioning.FrameworkName TargetFramework { get { throw null; } }
        public string TargetPath { get { throw null; } set { } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public System.IO.Stream GetStream() { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class StreamExtensions
    {
        public static string CopyToFile(this System.IO.Stream inputStream, string fileFullPath) { throw null; }
    }
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public partial class Strings
    {
        internal Strings() { }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        public static string ErrorDuplicatePackages { get { throw null; } }
        public static string ErrorInvalidAllowedVersions { get { throw null; } }
        public static string ErrorInvalidMinClientVersion { get { throw null; } }
        public static string ErrorInvalidPackageVersion { get { throw null; } }
        public static string ErrorNullOrEmptyPackageId { get { throw null; } }
        public static string ErrorUnableToDeleteFile { get { throw null; } }
        public static string Error_InvalidTargetFramework { get { throw null; } }
        public static string FailedFileTime { get { throw null; } }
        public static string FailToLoadPackagesConfig { get { throw null; } }
        public static string FailToWritePackagesConfig { get { throw null; } }
        public static string FallbackFolderNotFound { get { throw null; } }
        public static string InvalidNuspecElement { get { throw null; } }
        public static string InvalidNuspecEntry { get { throw null; } }
        public static string InvalidPackageFrameworkFolderName { get { throw null; } }
        public static string Log_InstallingPackage { get { throw null; } }
        public static string MinClientVersionAlreadyExist { get { throw null; } }
        public static string MissingNuspec { get { throw null; } }
        public static string MultipleNuspecFiles { get { throw null; } }
        public static string MustContainAbsolutePath { get { throw null; } }
        public static string PackageEntryAlreadyExist { get { throw null; } }
        public static string PackageEntryNotExist { get { throw null; } }
        public static string PackageMinVersionNotSatisfied { get { throw null; } }
        public static string PackagesNodeNotExist { get { throw null; } }
        public static string PackageStreamShouldBeSeekable { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Resources.ResourceManager ResourceManager { get { throw null; } }
        public static string StringCannotBeNullOrEmpty { get { throw null; } }
        public static string UnableToAddEntry { get { throw null; } }
        public static string UnableToParseClientVersion { get { throw null; } }
    }
    public partial class VersionFolderPathContext
    {
        public VersionFolderPathContext(NuGet.Packaging.Core.PackageIdentity package, string packagesDirectory, NuGet.Common.ILogger logger, NuGet.Packaging.PackageSaveMode packageSaveMode, NuGet.Packaging.XmlDocFileSaveMode xmlDocFileSaveMode) { }
        public NuGet.Common.ILogger Logger { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Packaging.Core.PackageIdentity Package { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Packaging.PackageSaveMode PackageSaveMode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string PackagesDirectory { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Packaging.XmlDocFileSaveMode XmlDocFileSaveMode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class VersionFolderPathResolver
    {
        public VersionFolderPathResolver(string path) { }
        public string GetHashPath(string packageId, NuGet.Versioning.NuGetVersion version) { throw null; }
        public string GetInstallPath(string packageId, NuGet.Versioning.NuGetVersion version) { throw null; }
        public string GetManifestFileName(string packageId, NuGet.Versioning.NuGetVersion version) { throw null; }
        public string GetManifestFilePath(string packageId, NuGet.Versioning.NuGetVersion version) { throw null; }
        public string GetPackageDirectory(string packageId, NuGet.Versioning.NuGetVersion version) { throw null; }
        public string GetPackageFileName(string packageId, NuGet.Versioning.NuGetVersion version) { throw null; }
        public string GetPackageFilePath(string packageId, NuGet.Versioning.NuGetVersion version) { throw null; }
        public string GetVersionListDirectory(string packageId) { throw null; }
        public string GetVersionListPath(string packageId) { throw null; }
    }
    public static partial class XElementExtensions
    {
        public static System.Collections.Generic.IEnumerable<System.Xml.Linq.XElement> ElementsNoNamespace(this System.Xml.Linq.XContainer container, string localName) { throw null; }
        public static System.Xml.Linq.XElement Except(this System.Xml.Linq.XElement source, System.Xml.Linq.XElement target) { throw null; }
        public static string GetOptionalAttributeValue(this System.Xml.Linq.XElement element, string localName, string namespaceName=null) { throw null; }
    }
    public enum XmlDocFileSaveMode
    {
        Compress = 2,
        None = 0,
        Skip = 1,
    }
    public static partial class XmlUtility
    {
        public static System.Xml.Linq.XDocument LoadSafe(System.IO.Stream input) { throw null; }
        public static System.Xml.Linq.XDocument LoadSafe(System.IO.Stream input, bool ignoreWhiteSpace) { throw null; }
    }
    public static partial class ZipArchiveExtensions
    {
        public static System.Collections.Generic.IEnumerable<string> GetFiles(this System.IO.Compression.ZipArchive zipArchive) { throw null; }
        public static System.IO.Compression.ZipArchiveEntry LookupEntry(this System.IO.Compression.ZipArchive zipArchive, string path) { throw null; }
        public static System.IO.Stream OpenFile(this System.IO.Compression.ZipArchive zipArchive, string path) { throw null; }
        public static string SaveAsFile(this System.IO.Compression.ZipArchiveEntry entry, string fileFullPath, NuGet.Common.ILogger logger) { throw null; }
        public static void UpdateFileTimeFromEntry(this System.IO.Compression.ZipArchiveEntry entry, string fileFullPath, NuGet.Common.ILogger logger) { }
    }
    public partial class ZipFilePair
    {
        public ZipFilePair(string fileFullPath, System.IO.Compression.ZipArchiveEntry entry) { }
        public string FileFullPath { get { throw null; } }
        public System.IO.Compression.ZipArchiveEntry PackageEntry { get { throw null; } }
        public bool IsInstalled() { throw null; }
    }
}
namespace NuGet.Packaging.PackageCreation.Resources
{
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public partial class NuGetResources
    {
        internal NuGetResources() { }
        public static string CannotCreateEmptyPackage { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        public static string DependencyHasInvalidVersion { get { throw null; } }
        public static string DuplicateDependenciesDefined { get { throw null; } }
        public static string IncompatibleSchema { get { throw null; } }
        public static string InvalidPackageId { get { throw null; } }
        public static string Manifest_DependenciesHasMixedElements { get { throw null; } }
        public static string Manifest_ExcludeContainsInvalidCharacters { get { throw null; } }
        public static string Manifest_IdMaxLengthExceeded { get { throw null; } }
        public static string Manifest_InvalidMinClientVersion { get { throw null; } }
        public static string Manifest_InvalidPrereleaseDependency { get { throw null; } }
        public static string Manifest_InvalidReference { get { throw null; } }
        public static string Manifest_InvalidReferenceFile { get { throw null; } }
        public static string Manifest_ReferencesHasMixedElements { get { throw null; } }
        public static string Manifest_ReferencesIsEmpty { get { throw null; } }
        public static string Manifest_RequiredElementMissing { get { throw null; } }
        public static string Manifest_RequiredMetadataMissing { get { throw null; } }
        public static string Manifest_RequireLicenseAcceptanceRequiresLicenseUrl { get { throw null; } }
        public static string Manifest_SourceContainsInvalidCharacters { get { throw null; } }
        public static string Manifest_TargetContainsInvalidCharacters { get { throw null; } }
        public static string Manifest_UriCannotBeEmpty { get { throw null; } }
        public static string PackageAuthoring_FileNotFound { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Resources.ResourceManager ResourceManager { get { throw null; } }
        public static string SemVerSpecialVersionTooLong { get { throw null; } }
        public static string UnknownSchemaVersion { get { throw null; } }
    }
}
namespace NuGet.Packaging.PackageExtraction
{
    public static partial class PackageExtractionBehavior
    {
        public static NuGet.Packaging.XmlDocFileSaveMode XmlDocFileSaveMode { get { throw null; } set { } }
    }
}
