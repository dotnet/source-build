[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Resources.ResourceManager")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Resources.ResourceManager")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Resources.ResourceManager")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Resources
{
    [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
    public partial class MissingManifestResourceException : System.Exception
    {
        public MissingManifestResourceException() { }
        public MissingManifestResourceException(string message) { }
        public MissingManifestResourceException(string message, System.Exception inner) { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1), AllowMultiple=false)]
    [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
    public sealed partial class NeutralResourcesLanguageAttribute : System.Attribute
    {
        public NeutralResourcesLanguageAttribute(string cultureName) { }
        public string CultureName { get { throw null; } }
    }
    [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
    public partial class ResourceManager
    {
        public ResourceManager(string baseName, System.Reflection.Assembly assembly) { }
        public ResourceManager(System.Type resourceSource) { }
        public string GetString(string name) { throw null; }
        public virtual string GetString(string name, System.Globalization.CultureInfo culture) { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1), AllowMultiple=false)]
    [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
    public sealed partial class SatelliteContractVersionAttribute : System.Attribute
    {
        public SatelliteContractVersionAttribute(string version) { }
        public string Version { get { throw null; } }
    }
}
