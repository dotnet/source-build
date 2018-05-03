[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Reflection.Context")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Reflection.Context")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Reflection.Context")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Reflection.Context
{
    public abstract partial class CustomReflectionContext : System.Reflection.ReflectionContext
    {
        protected CustomReflectionContext() { }
        protected CustomReflectionContext(System.Reflection.ReflectionContext source) { }
        protected virtual System.Collections.Generic.IEnumerable<System.Reflection.PropertyInfo> AddProperties(System.Type type) { throw null; }
        protected System.Reflection.PropertyInfo CreateProperty(System.Type propertyType, string name, System.Func<object, object> getter, System.Action<object, object> setter) { throw null; }
        protected System.Reflection.PropertyInfo CreateProperty(System.Type propertyType, string name, System.Func<object, object> getter, System.Action<object, object> setter, System.Collections.Generic.IEnumerable<System.Attribute> propertyCustomAttributes, System.Collections.Generic.IEnumerable<System.Attribute> getterCustomAttributes, System.Collections.Generic.IEnumerable<System.Attribute> setterCustomAttributes) { throw null; }
        protected virtual System.Collections.Generic.IEnumerable<object> GetCustomAttributes(System.Reflection.MemberInfo member, System.Collections.Generic.IEnumerable<object> declaredAttributes) { throw null; }
        protected virtual System.Collections.Generic.IEnumerable<object> GetCustomAttributes(System.Reflection.ParameterInfo parameter, System.Collections.Generic.IEnumerable<object> declaredAttributes) { throw null; }
        public override System.Reflection.Assembly MapAssembly(System.Reflection.Assembly assembly) { throw null; }
        public override System.Reflection.TypeInfo MapType(System.Reflection.TypeInfo type) { throw null; }
    }
}
