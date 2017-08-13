[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Reflection.DispatchProxy")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Reflection.DispatchProxy")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.6.24705.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.6.24705.01. Commit Hash: 4d1af962ca0fede10beb01d197367c2f90e92c97")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Reflection.DispatchProxy")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Reflection
{
    public abstract partial class DispatchProxy
    {
        protected DispatchProxy() { }
        public static T Create<T, TProxy>() where TProxy : System.Reflection.DispatchProxy { throw null; }
        protected abstract object Invoke(System.Reflection.MethodInfo targetMethod, object[] args);
    }
}
