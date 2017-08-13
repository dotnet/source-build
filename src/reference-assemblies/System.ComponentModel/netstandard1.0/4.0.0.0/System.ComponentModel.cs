[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ComponentModel")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ComponentModel")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ComponentModel")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System
{
    public partial interface IServiceProvider
    {
        object GetService(System.Type serviceType);
    }
}
namespace System.ComponentModel
{
    public partial class CancelEventArgs : System.EventArgs
    {
        public CancelEventArgs() { }
        public CancelEventArgs(bool cancel) { }
        public bool Cancel { get { throw null; } set { } }
    }
    public partial interface IChangeTracking
    {
        bool IsChanged { get; }
        void AcceptChanges();
    }
    public partial interface IEditableObject
    {
        void BeginEdit();
        void CancelEdit();
        void EndEdit();
    }
    public partial interface IRevertibleChangeTracking : System.ComponentModel.IChangeTracking
    {
        void RejectChanges();
    }
}
