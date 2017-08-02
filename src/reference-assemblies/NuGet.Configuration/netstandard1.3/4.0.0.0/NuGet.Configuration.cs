[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("Microsoft Corporation. All rights reserved.")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("NuGet's client configuration settings implementation.")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.0.2283")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.0-rtm-2283")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("NuGet")]
[assembly:System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.InteropServices.ComVisibleAttribute(false)]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.3")]
namespace NuGet.Configuration
{
    public static partial class ConfigurationConstants
    {
        public static readonly string ActivePackageSourceSectionName;
        public static readonly string ApiKeys;
        public static readonly string BeginIgnoreMarker;
        public static readonly string ClearTextPasswordToken;
        public static readonly string Config;
        public static readonly string ConfigurationDefaultsFile;
        public static readonly string CredentialsSectionName;
        public static readonly string DefaultPushSource;
        public static readonly string DisabledPackageSources;
        public static readonly string Enabled;
        public static readonly string EndIgnoreMarker;
        public static readonly string FallbackPackageFolders;
        public static readonly string HostKey;
        public static readonly string KeyAttribute;
        public static readonly string NoProxy;
        public static readonly string PackageRestore;
        public static readonly string PackageSources;
        public static readonly string PasswordKey;
        public static readonly string PasswordToken;
        public static readonly string ProtocolVersionAttribute;
        public static readonly string UserKey;
        public static readonly string UsernameToken;
        public static readonly string ValueAttribute;
    }
    public partial class ConfigurationDefaults
    {
        public ConfigurationDefaults(string directory, string configFile) { }
        public string DefaultPackageRestoreConsent { get { throw null; } }
        public System.Collections.Generic.IEnumerable<NuGet.Configuration.PackageSource> DefaultPackageSources { get { throw null; } }
        public string DefaultPushSource { get { throw null; } }
        public static NuGet.Configuration.ConfigurationDefaults Instance { get { throw null; } }
    }
    public enum CredentialRequestType
    {
        Forbidden = 2,
        Proxy = 0,
        Unauthorized = 1,
    }
    public static partial class EncryptionUtility
    {
        public static string DecryptString(string encryptedString) { throw null; }
        public static string EncryptString(string value) { throw null; }
        public static string GenerateUniqueToken(string caseInsensitiveKey) { throw null; }
    }
    public partial interface ICredentialCache
    {
        void Add(System.Uri uri, System.Net.ICredentials credentials);
        System.Net.ICredentials GetCredentials(System.Uri uri);
    }
    public partial interface ICredentialService
    {
        bool HandlesDefaultCredentials { get; }
        System.Threading.Tasks.Task<System.Net.ICredentials> GetCredentialsAsync(System.Uri uri, System.Net.IWebProxy proxy, NuGet.Configuration.CredentialRequestType type, string message, System.Threading.CancellationToken cancellationToken);
    }
    public partial interface IExtensionLocator
    {
        System.Collections.Generic.IEnumerable<string> FindCredentialProviders();
        System.Collections.Generic.IEnumerable<string> FindExtensions();
    }
    public partial interface IMachineWideSettings
    {
        System.Collections.Generic.IEnumerable<NuGet.Configuration.Settings> Settings { get; }
    }
    public partial interface IPackageSourceProvider
    {
        string ActivePackageSourceName { get; }
        string DefaultPushSource { get; }
        event System.EventHandler PackageSourcesChanged;
        void DisablePackageSource(NuGet.Configuration.PackageSource source);
        bool IsPackageSourceEnabled(NuGet.Configuration.PackageSource source);
        System.Collections.Generic.IEnumerable<NuGet.Configuration.PackageSource> LoadPackageSources();
        void SaveActivePackageSource(NuGet.Configuration.PackageSource source);
        void SavePackageSources(System.Collections.Generic.IEnumerable<NuGet.Configuration.PackageSource> sources);
    }
    public partial interface IProxyCache
    {
        void Add(System.Net.IWebProxy proxy);
        System.Net.IWebProxy GetProxy(System.Uri uri);
    }
    public partial interface IProxyCredentialCache : System.Net.ICredentials
    {
        System.Guid Version { get; }
        void UpdateCredential(System.Uri proxyAddress, System.Net.NetworkCredential credentials);
    }
    public partial interface ISettings
    {
        string FileName { get; }
        System.Collections.Generic.IEnumerable<NuGet.Configuration.ISettings> Priority { get; }
        string Root { get; }
        event System.EventHandler SettingsChanged;
        bool DeleteSection(string section);
        bool DeleteValue(string section, string key);
        System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, string>> GetNestedValues(string section, string subSection);
        System.Collections.Generic.IList<NuGet.Configuration.SettingValue> GetSettingValues(string section, bool isPath=false);
        string GetValue(string section, string key, bool isPath=false);
        void SetNestedValues(string section, string subSection, System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, string>> values);
        void SetValue(string section, string key, string value);
        void SetValues(string section, System.Collections.Generic.IReadOnlyList<NuGet.Configuration.SettingValue> values);
        void UpdateSections(string section, System.Collections.Generic.IReadOnlyList<NuGet.Configuration.SettingValue> values);
    }
    public partial class NuGetConfigurationException : System.Exception
    {
        public NuGetConfigurationException(string message) { }
        public NuGetConfigurationException(string message, System.Exception innerException) { }
    }
    public static partial class NuGetConstants
    {
        public static readonly string AddV3TrackFile;
        public static readonly string DefaultConfigContent;
        public static readonly string DefaultGalleryServerUrl;
        public static readonly string DefaultSymbolServerUrl;
        public static readonly string FeedName;
        public static readonly string ManifestExtension;
        public static readonly string ManifestSymbolsExtension;
        public static readonly string NuGetHostName;
        public static readonly string NuGetSolutionSettingsFolder;
        public static readonly string PackageExtension;
        public static readonly string PackageReferenceFile;
        public static readonly string ReadmeFileName;
        public static readonly string SymbolsExtension;
        public static readonly string V1FeedUrl;
        public static readonly string V2FeedUrl;
        public static readonly string V2LegacyFeedUrl;
        public static readonly string V2LegacyOfficialPackageSourceUrl;
        public static readonly string V3FeedUrl;
    }
    public partial class NuGetPathContext : NuGet.Common.INuGetPathContext
    {
        public NuGetPathContext() { }
        public System.Collections.Generic.IReadOnlyList<string> FallbackPackageFolders { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string HttpCacheFolder { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string UserPackageFolder { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static NuGet.Configuration.NuGetPathContext Create(NuGet.Configuration.ISettings settings) { throw null; }
        public static NuGet.Configuration.NuGetPathContext Create(string settingsRoot) { throw null; }
    }
    public partial class NullSettings : NuGet.Configuration.ISettings
    {
        public NullSettings() { }
        public string FileName { get { throw null; } }
        public static NuGet.Configuration.NullSettings Instance { get { throw null; } }
        public System.Collections.Generic.IEnumerable<NuGet.Configuration.ISettings> Priority { get { throw null; } }
        public string Root { get { throw null; } }
        public event System.EventHandler SettingsChanged { add { } remove { } }
        public bool DeleteSection(string section) { throw null; }
        public bool DeleteValue(string section, string key) { throw null; }
        public System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, string>> GetNestedValues(string section, string subSection) { throw null; }
        public System.Collections.Generic.IList<NuGet.Configuration.SettingValue> GetSettingValues(string section, bool isPath) { throw null; }
        public string GetValue(string section, string key, bool isPath=false) { throw null; }
        public void SetNestedValues(string section, string key, System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, string>> values) { }
        public void SetValue(string section, string key, string value) { }
        public void SetValues(string section, System.Collections.Generic.IReadOnlyList<NuGet.Configuration.SettingValue> values) { }
        public void UpdateSections(string section, System.Collections.Generic.IReadOnlyList<NuGet.Configuration.SettingValue> values) { }
    }
    public partial class PackageSource : System.IEquatable<NuGet.Configuration.PackageSource>
    {
        public const int DefaultProtocolVersion = 2;
        public PackageSource(string source) { }
        public PackageSource(string source, string name) { }
        public PackageSource(string source, string name, bool isEnabled) { }
        public PackageSource(string source, string name, bool isEnabled, bool isOfficial, bool isPersistable=true) { }
        public NuGet.Configuration.PackageSourceCredential Credentials { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Description { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool IsEnabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool IsHttp { get { throw null; } }
        public bool IsLocal { get { throw null; } }
        public bool IsMachineWide { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool IsOfficial { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool IsPersistable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Configuration.ISettings Origin { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public int ProtocolVersion { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Source { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Uri SourceUri { get { throw null; } }
        public System.Uri TrySourceAsUri { get { throw null; } }
        public NuGet.Configuration.PackageSource Clone() { throw null; }
        public bool Equals(NuGet.Configuration.PackageSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PackageSourceCredential
    {
        public PackageSourceCredential(string source, string username, string passwordText, bool isPasswordClearText) { }
        public bool IsPasswordClearText { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Password { get { throw null; } }
        public string PasswordText { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Source { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Username { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static NuGet.Configuration.PackageSourceCredential FromUserInput(string source, string username, string password, bool storePasswordInClearText) { throw null; }
        public bool IsValid() { throw null; }
    }
    public partial class PackageSourceProvider : NuGet.Configuration.IPackageSourceProvider
    {
        public PackageSourceProvider(NuGet.Configuration.ISettings settings) { }
        public PackageSourceProvider(NuGet.Configuration.ISettings settings, System.Collections.Generic.IDictionary<NuGet.Configuration.PackageSource, NuGet.Configuration.PackageSource> migratePackageSources) { }
        public PackageSourceProvider(NuGet.Configuration.ISettings settings, System.Collections.Generic.IDictionary<NuGet.Configuration.PackageSource, NuGet.Configuration.PackageSource> migratePackageSources, System.Collections.Generic.IEnumerable<NuGet.Configuration.PackageSource> configurationDefaultSources) { }
        public string ActivePackageSourceName { get { throw null; } }
        public string DefaultPushSource { get { throw null; } }
        public NuGet.Configuration.ISettings Settings { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public event System.EventHandler PackageSourcesChanged { add { } remove { } }
        public void DisablePackageSource(NuGet.Configuration.PackageSource source) { }
        public bool IsPackageSourceEnabled(NuGet.Configuration.PackageSource source) { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Configuration.PackageSource> LoadPackageSources() { throw null; }
        public void SaveActivePackageSource(NuGet.Configuration.PackageSource source) { }
        public void SavePackageSources(System.Collections.Generic.IEnumerable<NuGet.Configuration.PackageSource> sources) { }
    }
    public partial class ProxyCache : NuGet.Configuration.IProxyCache, NuGet.Configuration.IProxyCredentialCache, System.Net.ICredentials
    {
        public ProxyCache(NuGet.Configuration.ISettings settings, NuGet.Common.IEnvironmentVariableReader environment) { }
        public static NuGet.Configuration.ProxyCache Instance { get { throw null; } }
        public System.Guid Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [System.ObsoleteAttribute("Retained for backcompat only. Use UpdateCredential instead")]
        public void Add(System.Net.IWebProxy proxy) { }
        public System.Net.NetworkCredential GetCredential(System.Uri proxyAddress, string authType) { throw null; }
        public System.Net.IWebProxy GetProxy(System.Uri sourceUri) { throw null; }
        public NuGet.Configuration.WebProxy GetUserConfiguredProxy() { throw null; }
        public void UpdateCredential(System.Uri proxyAddress, System.Net.NetworkCredential credentials) { }
    }
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public partial class Resources
    {
        internal Resources() { }
        public static string Argument_Cannot_Be_Null_Or_Empty { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        public static string Error_EncryptionUnsupported { get { throw null; } }
        public static string Error_NoWritableConfig { get { throw null; } }
        public static string FileDoesNotExist { get { throw null; } }
        public static string InvalidNullSettingsOperation { get { throw null; } }
        public static string MustContainAbsolutePath { get { throw null; } }
        public static string PackageSource_Invalid { get { throw null; } }
        public static string RelativeEnvVarPath { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Resources.ResourceManager ResourceManager { get { throw null; } }
        public static string Settings_FileName_Cannot_Be_A_Path { get { throw null; } }
        public static string ShowError_ConfigInvalidOperation { get { throw null; } }
        public static string ShowError_ConfigInvalidXml { get { throw null; } }
        public static string ShowError_ConfigRootInvalid { get { throw null; } }
        public static string ShowError_ConfigUnauthorizedAccess { get { throw null; } }
        public static string Unknown_Config_Exception { get { throw null; } }
        public static string UnsupportedDecryptPassword { get { throw null; } }
        public static string UnsupportedEncryptPassword { get { throw null; } }
        public static string UserSettings_UnableToParseConfigFile { get { throw null; } }
    }
    public partial class Settings : NuGet.Configuration.ISettings
    {
        public static readonly string DefaultSettingsFileName;
        public static readonly string[] OrderedSettingsFileNames;
        public static readonly string[] SupportedMachineWideConfigExtension;
        public Settings(string root) { }
        public Settings(string root, string fileName) { }
        public Settings(string root, string fileName, bool isMachineWideSettings) { }
        public string ConfigFilePath { get { throw null; } }
        public string FileName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IEnumerable<NuGet.Configuration.ISettings> Priority { get { throw null; } }
        public string Root { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public event System.EventHandler SettingsChanged { add { } remove { } }
        public bool DeleteSection(string section) { throw null; }
        public bool DeleteValue(string section, string key) { throw null; }
        public static System.Tuple<string, string> GetFileNameAndItsRoot(string root, string settingsPath) { throw null; }
        public System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, string>> GetNestedValues(string section, string subSection) { throw null; }
        public System.Collections.Generic.IList<NuGet.Configuration.SettingValue> GetSettingValues(string section, bool isPath=false) { throw null; }
        public string GetValue(string section, string key, bool isPath=false) { throw null; }
        public static NuGet.Configuration.ISettings LoadDefaultSettings(string root) { throw null; }
        public static NuGet.Configuration.ISettings LoadDefaultSettings(string root, string configFileName, NuGet.Configuration.IMachineWideSettings machineWideSettings) { throw null; }
        public static NuGet.Configuration.ISettings LoadDefaultSettings(string root, string configFileName, NuGet.Configuration.IMachineWideSettings machineWideSettings, bool loadAppDataSettings, bool useTestingGlobalPath) { throw null; }
        public static System.Collections.Generic.IEnumerable<NuGet.Configuration.Settings> LoadMachineWideSettings(string root, params string[] paths) { throw null; }
        public static NuGet.Configuration.ISettings LoadSpecificSettings(string root, string configFileName) { throw null; }
        public void SetNestedValues(string section, string key, System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, string>> values) { }
        public void SetValue(string section, string key, string value) { }
        public void SetValues(string section, System.Collections.Generic.IReadOnlyList<NuGet.Configuration.SettingValue> values) { }
        public void UpdateSections(string section, System.Collections.Generic.IReadOnlyList<NuGet.Configuration.SettingValue> values) { }
    }
    public static partial class SettingsUtility
    {
        public static readonly string ConfigSection;
        public static readonly string DefaultGlobalPackagesFolderPath;
        public static bool DeleteConfigValue(NuGet.Configuration.ISettings settings, string key) { throw null; }
        public static string GetConfigValue(NuGet.Configuration.ISettings settings, string key, bool decrypt=false, bool isPath=false) { throw null; }
        public static string GetDecryptedValue(NuGet.Configuration.ISettings settings, string section, string key, bool isPath=false) { throw null; }
        public static string GetDefaultPushSource(NuGet.Configuration.ISettings settings) { throw null; }
        public static System.Collections.Generic.IReadOnlyList<string> GetFallbackPackageFolders(NuGet.Configuration.ISettings settings) { throw null; }
        public static string GetGlobalPackagesFolder(NuGet.Configuration.ISettings settings) { throw null; }
        public static string GetHttpCacheFolder() { throw null; }
        public static string GetRepositoryPath(NuGet.Configuration.ISettings settings) { throw null; }
        public static void SetConfigValue(NuGet.Configuration.ISettings settings, string key, string value, bool encrypt=false) { }
        public static void SetEncryptedValue(NuGet.Configuration.ISettings settings, string section, string key, string value) { }
    }
    public partial class SettingValue
    {
        public SettingValue(string key, string value, NuGet.Configuration.ISettings origin, bool isMachineWide, int priority=0) { }
        public SettingValue(string key, string value, NuGet.Configuration.ISettings origin, bool isMachineWide, string originalValue, int priority=0) { }
        public SettingValue(string key, string value, bool isMachineWide, int priority=0) { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalData { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool IsMachineWide { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Key { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Configuration.ISettings Origin { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string OriginalValue { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public int Priority { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Value { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class WebProxy : System.Net.IWebProxy
    {
        public WebProxy(string proxyAddress) { }
        public WebProxy(System.Uri proxyAddress) { }
        public System.Collections.Generic.IReadOnlyList<string> BypassList { get { throw null; } set { } }
        public System.Net.ICredentials Credentials { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Uri ProxyAddress { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Uri GetProxy(System.Uri destination) { throw null; }
        public bool IsBypassed(System.Uri uri) { throw null; }
    }
    public partial class XPlatMachineWideSetting : NuGet.Configuration.IMachineWideSettings
    {
        public XPlatMachineWideSetting() { }
        public System.Collections.Generic.IEnumerable<NuGet.Configuration.Settings> Settings { get { throw null; } }
    }
}
