[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Reflection.TypeExtensions")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Reflection.TypeExtensions")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.6.23123.00")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.6.23123.00 built by: PROJECTKREL")]
[assembly:System.Reflection.AssemblyMetadataAttribute("", "")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Reflection.TypeExtensions")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Reflection
{
    public static partial class AssemblyExtensions
    {
        public static System.Type[] GetExportedTypes(this System.Reflection.Assembly assembly) { throw null; }
        public static System.Reflection.Module[] GetModules(this System.Reflection.Assembly assembly) { throw null; }
        public static System.Type[] GetTypes(this System.Reflection.Assembly assembly) { throw null; }
    }
    [System.FlagsAttribute]
    public enum BindingFlags
    {
        DeclaredOnly = 2,
        FlattenHierarchy = 64,
        IgnoreCase = 1,
        Instance = 4,
        NonPublic = 32,
        Public = 16,
        Static = 8,
    }
    public static partial class EventInfoExtensions
    {
        public static System.Reflection.MethodInfo GetAddMethod(this System.Reflection.EventInfo eventInfo) { throw null; }
        public static System.Reflection.MethodInfo GetAddMethod(this System.Reflection.EventInfo eventInfo, bool nonPublic) { throw null; }
        public static System.Reflection.MethodInfo GetRaiseMethod(this System.Reflection.EventInfo eventInfo) { throw null; }
        public static System.Reflection.MethodInfo GetRaiseMethod(this System.Reflection.EventInfo eventInfo, bool nonPublic) { throw null; }
        public static System.Reflection.MethodInfo GetRemoveMethod(this System.Reflection.EventInfo eventInfo) { throw null; }
        public static System.Reflection.MethodInfo GetRemoveMethod(this System.Reflection.EventInfo eventInfo, bool nonPublic) { throw null; }
    }
    public static partial class MethodInfoExtensions
    {
        public static System.Reflection.MethodInfo GetBaseDefinition(this System.Reflection.MethodInfo method) { throw null; }
    }
    public static partial class PropertyInfoExtensions
    {
        public static System.Reflection.MethodInfo[] GetAccessors(this System.Reflection.PropertyInfo property) { throw null; }
        public static System.Reflection.MethodInfo[] GetAccessors(this System.Reflection.PropertyInfo property, bool nonPublic) { throw null; }
        public static System.Reflection.MethodInfo GetGetMethod(this System.Reflection.PropertyInfo property) { throw null; }
        public static System.Reflection.MethodInfo GetGetMethod(this System.Reflection.PropertyInfo property, bool nonPublic) { throw null; }
        public static System.Reflection.MethodInfo GetSetMethod(this System.Reflection.PropertyInfo property) { throw null; }
        public static System.Reflection.MethodInfo GetSetMethod(this System.Reflection.PropertyInfo property, bool nonPublic) { throw null; }
    }
    public static partial class TypeExtensions
    {
        public static System.Reflection.ConstructorInfo GetConstructor(this System.Type type, System.Type[] types) { throw null; }
        public static System.Reflection.ConstructorInfo[] GetConstructors(this System.Type type) { throw null; }
        public static System.Reflection.ConstructorInfo[] GetConstructors(this System.Type type, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Reflection.MemberInfo[] GetDefaultMembers(this System.Type type) { throw null; }
        public static System.Reflection.EventInfo GetEvent(this System.Type type, string name) { throw null; }
        public static System.Reflection.EventInfo GetEvent(this System.Type type, string name, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Reflection.EventInfo[] GetEvents(this System.Type type) { throw null; }
        public static System.Reflection.EventInfo[] GetEvents(this System.Type type, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Reflection.FieldInfo GetField(this System.Type type, string name) { throw null; }
        public static System.Reflection.FieldInfo GetField(this System.Type type, string name, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Reflection.FieldInfo[] GetFields(this System.Type type) { throw null; }
        public static System.Reflection.FieldInfo[] GetFields(this System.Type type, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Type[] GetGenericArguments(this System.Type type) { throw null; }
        public static System.Type[] GetInterfaces(this System.Type type) { throw null; }
        public static System.Reflection.MemberInfo[] GetMember(this System.Type type, string name) { throw null; }
        public static System.Reflection.MemberInfo[] GetMember(this System.Type type, string name, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Reflection.MemberInfo[] GetMembers(this System.Type type) { throw null; }
        public static System.Reflection.MemberInfo[] GetMembers(this System.Type type, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Reflection.MethodInfo GetMethod(this System.Type type, string name) { throw null; }
        public static System.Reflection.MethodInfo GetMethod(this System.Type type, string name, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Reflection.MethodInfo GetMethod(this System.Type type, string name, System.Type[] types) { throw null; }
        public static System.Reflection.MethodInfo[] GetMethods(this System.Type type) { throw null; }
        public static System.Reflection.MethodInfo[] GetMethods(this System.Type type, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Type GetNestedType(this System.Type type, string name, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Type[] GetNestedTypes(this System.Type type, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Reflection.PropertyInfo[] GetProperties(this System.Type type) { throw null; }
        public static System.Reflection.PropertyInfo[] GetProperties(this System.Type type, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Reflection.PropertyInfo GetProperty(this System.Type type, string name) { throw null; }
        public static System.Reflection.PropertyInfo GetProperty(this System.Type type, string name, System.Reflection.BindingFlags bindingAttr) { throw null; }
        public static System.Reflection.PropertyInfo GetProperty(this System.Type type, string name, System.Type returnType) { throw null; }
        public static System.Reflection.PropertyInfo GetProperty(this System.Type type, string name, System.Type returnType, System.Type[] types) { throw null; }
        public static bool IsAssignableFrom(this System.Type type, System.Type c) { throw null; }
        public static bool IsInstanceOfType(this System.Type type, object o) { throw null; }
    }
}
