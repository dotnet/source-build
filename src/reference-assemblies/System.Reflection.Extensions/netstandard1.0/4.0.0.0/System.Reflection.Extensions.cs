[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Reflection.Extensions")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Reflection.Extensions")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Reflection.Extensions")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Reflection
{
    public static partial class CustomAttributeExtensions
    {
        public static System.Attribute GetCustomAttribute(this System.Reflection.Assembly element, System.Type attributeType) { throw null; }
        public static System.Attribute GetCustomAttribute(this System.Reflection.MemberInfo element, System.Type attributeType) { throw null; }
        public static System.Attribute GetCustomAttribute(this System.Reflection.MemberInfo element, System.Type attributeType, bool inherit) { throw null; }
        public static System.Attribute GetCustomAttribute(this System.Reflection.Module element, System.Type attributeType) { throw null; }
        public static System.Attribute GetCustomAttribute(this System.Reflection.ParameterInfo element, System.Type attributeType) { throw null; }
        public static System.Attribute GetCustomAttribute(this System.Reflection.ParameterInfo element, System.Type attributeType, bool inherit) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Attribute> GetCustomAttributes(this System.Reflection.Assembly element) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Attribute> GetCustomAttributes(this System.Reflection.Assembly element, System.Type attributeType) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Attribute> GetCustomAttributes(this System.Reflection.MemberInfo element) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Attribute> GetCustomAttributes(this System.Reflection.MemberInfo element, bool inherit) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Attribute> GetCustomAttributes(this System.Reflection.MemberInfo element, System.Type attributeType) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Attribute> GetCustomAttributes(this System.Reflection.MemberInfo element, System.Type attributeType, bool inherit) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Attribute> GetCustomAttributes(this System.Reflection.Module element) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Attribute> GetCustomAttributes(this System.Reflection.Module element, System.Type attributeType) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Attribute> GetCustomAttributes(this System.Reflection.ParameterInfo element) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Attribute> GetCustomAttributes(this System.Reflection.ParameterInfo element, bool inherit) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Attribute> GetCustomAttributes(this System.Reflection.ParameterInfo element, System.Type attributeType) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Attribute> GetCustomAttributes(this System.Reflection.ParameterInfo element, System.Type attributeType, bool inherit) { throw null; }
        public static System.Collections.Generic.IEnumerable<T> GetCustomAttributes<T>(this System.Reflection.Assembly element) where T : System.Attribute { throw null; }
        public static System.Collections.Generic.IEnumerable<T> GetCustomAttributes<T>(this System.Reflection.MemberInfo element) where T : System.Attribute { throw null; }
        public static System.Collections.Generic.IEnumerable<T> GetCustomAttributes<T>(this System.Reflection.MemberInfo element, bool inherit) where T : System.Attribute { throw null; }
        public static System.Collections.Generic.IEnumerable<T> GetCustomAttributes<T>(this System.Reflection.Module element) where T : System.Attribute { throw null; }
        public static System.Collections.Generic.IEnumerable<T> GetCustomAttributes<T>(this System.Reflection.ParameterInfo element) where T : System.Attribute { throw null; }
        public static System.Collections.Generic.IEnumerable<T> GetCustomAttributes<T>(this System.Reflection.ParameterInfo element, bool inherit) where T : System.Attribute { throw null; }
        public static T GetCustomAttribute<T>(this System.Reflection.Assembly element) where T : System.Attribute { throw null; }
        public static T GetCustomAttribute<T>(this System.Reflection.MemberInfo element) where T : System.Attribute { throw null; }
        public static T GetCustomAttribute<T>(this System.Reflection.MemberInfo element, bool inherit) where T : System.Attribute { throw null; }
        public static T GetCustomAttribute<T>(this System.Reflection.Module element) where T : System.Attribute { throw null; }
        public static T GetCustomAttribute<T>(this System.Reflection.ParameterInfo element) where T : System.Attribute { throw null; }
        public static T GetCustomAttribute<T>(this System.Reflection.ParameterInfo element, bool inherit) where T : System.Attribute { throw null; }
        public static bool IsDefined(this System.Reflection.Assembly element, System.Type attributeType) { throw null; }
        public static bool IsDefined(this System.Reflection.MemberInfo element, System.Type attributeType) { throw null; }
        public static bool IsDefined(this System.Reflection.MemberInfo element, System.Type attributeType, bool inherit) { throw null; }
        public static bool IsDefined(this System.Reflection.Module element, System.Type attributeType) { throw null; }
        public static bool IsDefined(this System.Reflection.ParameterInfo element, System.Type attributeType) { throw null; }
        public static bool IsDefined(this System.Reflection.ParameterInfo element, System.Type attributeType, bool inherit) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct InterfaceMapping
    {
        public System.Reflection.MethodInfo[] InterfaceMethods;
        public System.Type InterfaceType;
        public System.Reflection.MethodInfo[] TargetMethods;
        public System.Type TargetType;
    }
    public static partial class RuntimeReflectionExtensions
    {
        public static System.Reflection.MethodInfo GetMethodInfo(this System.Delegate del) { throw null; }
        public static System.Reflection.MethodInfo GetRuntimeBaseDefinition(this System.Reflection.MethodInfo method) { throw null; }
        public static System.Reflection.EventInfo GetRuntimeEvent(this System.Type type, string name) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Reflection.EventInfo> GetRuntimeEvents(this System.Type type) { throw null; }
        public static System.Reflection.FieldInfo GetRuntimeField(this System.Type type, string name) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Reflection.FieldInfo> GetRuntimeFields(this System.Type type) { throw null; }
        public static System.Reflection.InterfaceMapping GetRuntimeInterfaceMap(this System.Reflection.TypeInfo typeInfo, System.Type interfaceType) { throw null; }
        public static System.Reflection.MethodInfo GetRuntimeMethod(this System.Type type, string name, System.Type[] parameters) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Reflection.MethodInfo> GetRuntimeMethods(this System.Type type) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Reflection.PropertyInfo> GetRuntimeProperties(this System.Type type) { throw null; }
        public static System.Reflection.PropertyInfo GetRuntimeProperty(this System.Type type, string name) { throw null; }
    }
}
