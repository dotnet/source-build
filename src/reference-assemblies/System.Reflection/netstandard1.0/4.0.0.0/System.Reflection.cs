[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Reflection.dll")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Reflection.dll")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.30319.17929")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.30319.17929")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Reflection.dll")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("System.Reflection.Emit, PublicKey=002400000480000094000000060200000024000052534131000400000100010007D1FA57C4AED9F0A32E84AA0FAEFD0DE9E8FD6AEC8F87FB03766C834C99921EB23BE79AD9D5DCC1DD9AD236132102900B723CF980957FC4E177108FC607774F29E8320E92EA05ECE4E821C0A5EFE8F1645C4C0C93C1AB99285D622CAA652C1DFAD63D745D6F2DE5F17E5EAF0FC4963D261C8A12436518206DC093344D5AD293")]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("System.Reflection.Emit.Lightweight, PublicKey=002400000480000094000000060200000024000052534131000400000100010007D1FA57C4AED9F0A32E84AA0FAEFD0DE9E8FD6AEC8F87FB03766C834C99921EB23BE79AD9D5DCC1DD9AD236132102900B723CF980957FC4E177108FC607774F29E8320E92EA05ECE4E821C0A5EFE8F1645C4C0C93C1AB99285D622CAA652C1DFAD63D745D6F2DE5F17E5EAF0FC4963D261C8A12436518206DC093344D5AD293")]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("System.Runtime.InteropServices, PublicKey=002400000480000094000000060200000024000052534131000400000100010007D1FA57C4AED9F0A32E84AA0FAEFD0DE9E8FD6AEC8F87FB03766C834C99921EB23BE79AD9D5DCC1DD9AD236132102900B723CF980957FC4E177108FC607774F29E8320E92EA05ECE4E821C0A5EFE8F1645C4C0C93C1AB99285D622CAA652C1DFAD63D745D6F2DE5F17E5EAF0FC4963D261C8A12436518206DC093344D5AD293")]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Reflection
{
    public sealed partial class AmbiguousMatchException : System.Exception
    {
        public AmbiguousMatchException() { }
        public AmbiguousMatchException(string message) { }
        public AmbiguousMatchException(string message, System.Exception inner) { }
    }
    public abstract partial class Assembly
    {
        internal Assembly() { }
        public virtual System.Collections.Generic.IEnumerable<System.Reflection.CustomAttributeData> CustomAttributes { get { throw null; } }
        public abstract System.Collections.Generic.IEnumerable<System.Reflection.TypeInfo> DefinedTypes { get; }
        public virtual System.Collections.Generic.IEnumerable<System.Type> ExportedTypes { get { throw null; } }
        public virtual string FullName { get { throw null; } }
        public virtual bool IsDynamic { get { throw null; } }
        public virtual System.Reflection.Module ManifestModule { get { throw null; } }
        public abstract System.Collections.Generic.IEnumerable<System.Reflection.Module> Modules { get; }
        public override bool Equals(object o) { throw null; }
        public override int GetHashCode() { throw null; }
        public virtual System.Reflection.ManifestResourceInfo GetManifestResourceInfo(string resourceName) { throw null; }
        public virtual string[] GetManifestResourceNames() { throw null; }
        public virtual System.IO.Stream GetManifestResourceStream(string name) { throw null; }
        public virtual System.Reflection.AssemblyName GetName() { throw null; }
        public virtual System.Type GetType(string name) { throw null; }
        [System.Security.SecuritySafeCriticalAttribute]
        public static System.Reflection.Assembly Load(System.Reflection.AssemblyName assemblyRef) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum AssemblyContentType
    {
        Default = 0,
        WindowsRuntime = 1,
    }
    public sealed partial class AssemblyName
    {
        public AssemblyName() { }
        [System.Security.SecuritySafeCriticalAttribute]
        public AssemblyName(string assemblyName) { }
        public System.Reflection.AssemblyContentType ContentType { get { throw null; } set { } }
        public string CultureName { get { throw null; } }
        public System.Reflection.AssemblyNameFlags Flags { get { throw null; } set { } }
        public string FullName { [System.Security.SecuritySafeCriticalAttribute]get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Version Version { get { throw null; } set { } }
        public byte[] GetPublicKey() { throw null; }
        [System.Security.SecuritySafeCriticalAttribute]
        public byte[] GetPublicKeyToken() { throw null; }
        public void SetPublicKey(byte[] publicKey) { }
        public void SetPublicKeyToken(byte[] publicKeyToken) { }
        public override string ToString() { throw null; }
    }
    public abstract partial class ConstructorInfo : System.Reflection.MethodBase
    {
        internal ConstructorInfo() { }
        public static readonly string ConstructorName;
        public static readonly string TypeConstructorName;
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public object Invoke(object[] parameters) { throw null; }
    }
    public partial class CustomAttributeData
    {
        internal CustomAttributeData() { }
        public System.Type AttributeType { get { throw null; } }
        public virtual System.Collections.Generic.IList<System.Reflection.CustomAttributeTypedArgument> ConstructorArguments { get { throw null; } }
        public virtual System.Collections.Generic.IList<System.Reflection.CustomAttributeNamedArgument> NamedArguments { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct CustomAttributeNamedArgument
    {
        public bool IsField { get { throw null; } }
        public string MemberName { get { throw null; } }
        public System.Reflection.CustomAttributeTypedArgument TypedValue { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct CustomAttributeTypedArgument
    {
        public System.Type ArgumentType { get { throw null; } }
        public object Value { get { throw null; } }
    }
    public abstract partial class EventInfo : System.Reflection.MemberInfo
    {
        internal EventInfo() { }
        public virtual System.Reflection.MethodInfo AddMethod { get { throw null; } }
        public abstract System.Reflection.EventAttributes Attributes { get; }
        public virtual System.Type EventHandlerType { get { throw null; } }
        public bool IsSpecialName { get { throw null; } }
        public virtual System.Reflection.MethodInfo RaiseMethod { get { throw null; } }
        public virtual System.Reflection.MethodInfo RemoveMethod { get { throw null; } }
        public virtual void AddEventHandler(object target, System.Delegate handler) { }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public virtual void RemoveEventHandler(object target, System.Delegate handler) { }
    }
    public abstract partial class FieldInfo : System.Reflection.MemberInfo
    {
        internal FieldInfo() { }
        public abstract System.Reflection.FieldAttributes Attributes { get; }
        public abstract System.Type FieldType { get; }
        public bool IsAssembly { get { throw null; } }
        public bool IsFamily { get { throw null; } }
        public bool IsFamilyAndAssembly { get { throw null; } }
        public bool IsFamilyOrAssembly { get { throw null; } }
        public bool IsInitOnly { get { throw null; } }
        public bool IsLiteral { get { throw null; } }
        public bool IsPrivate { get { throw null; } }
        public bool IsPublic { get { throw null; } }
        public bool IsSpecialName { get { throw null; } }
        public bool IsStatic { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public static System.Reflection.FieldInfo GetFieldFromHandle(System.RuntimeFieldHandle handle) { throw null; }
        public static System.Reflection.FieldInfo GetFieldFromHandle(System.RuntimeFieldHandle handle, System.RuntimeTypeHandle declaringType) { throw null; }
        public override int GetHashCode() { throw null; }
        public abstract object GetValue(object obj);
        public void SetValue(object obj, object value) { }
    }
    public static partial class IntrospectionExtensions
    {
        public static System.Reflection.TypeInfo GetTypeInfo(this System.Type type) { throw null; }
    }
    public partial interface IReflectableType
    {
        System.Reflection.TypeInfo GetTypeInfo();
    }
    public partial class LocalVariableInfo
    {
        protected LocalVariableInfo() { }
        public virtual bool IsPinned { get { throw null; } }
        public virtual int LocalIndex { get { throw null; } }
        public virtual System.Type LocalType { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class ManifestResourceInfo
    {
        public ManifestResourceInfo(System.Reflection.Assembly containingAssembly, string containingFileName, System.Reflection.ResourceLocation resourceLocation) { }
        public virtual string FileName { get { throw null; } }
        public virtual System.Reflection.Assembly ReferencedAssembly { get { throw null; } }
        public virtual System.Reflection.ResourceLocation ResourceLocation { get { throw null; } }
    }
    public abstract partial class MemberInfo
    {
        internal MemberInfo() { }
        public virtual System.Collections.Generic.IEnumerable<System.Reflection.CustomAttributeData> CustomAttributes { get { throw null; } }
        public abstract System.Type DeclaringType { get; }
        public virtual System.Reflection.Module Module { get { throw null; } }
        public abstract string Name { get; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public abstract partial class MethodBase : System.Reflection.MemberInfo
    {
        internal MethodBase() { }
        public abstract System.Reflection.MethodAttributes Attributes { get; }
        public virtual System.Reflection.CallingConventions CallingConvention { get { throw null; } }
        public virtual bool ContainsGenericParameters { get { throw null; } }
        public bool IsAbstract { get { throw null; } }
        public bool IsAssembly { get { throw null; } }
        public bool IsConstructor { get { throw null; } }
        public bool IsFamily { get { throw null; } }
        public bool IsFamilyAndAssembly { get { throw null; } }
        public bool IsFamilyOrAssembly { get { throw null; } }
        public bool IsFinal { get { throw null; } }
        public virtual bool IsGenericMethod { get { throw null; } }
        public virtual bool IsGenericMethodDefinition { get { throw null; } }
        public bool IsHideBySig { get { throw null; } }
        public bool IsPrivate { get { throw null; } }
        public bool IsPublic { get { throw null; } }
        public bool IsSpecialName { get { throw null; } }
        public bool IsStatic { get { throw null; } }
        public bool IsVirtual { get { throw null; } }
        public abstract System.Reflection.MethodImplAttributes MethodImplementationFlags { get; }
        public override bool Equals(object obj) { throw null; }
        public virtual System.Type[] GetGenericArguments() { throw null; }
        public override int GetHashCode() { throw null; }
        public static System.Reflection.MethodBase GetMethodFromHandle(System.RuntimeMethodHandle handle) { throw null; }
        public static System.Reflection.MethodBase GetMethodFromHandle(System.RuntimeMethodHandle handle, System.RuntimeTypeHandle declaringType) { throw null; }
        public abstract System.Reflection.ParameterInfo[] GetParameters();
        public object Invoke(object obj, object[] parameters) { throw null; }
    }
    public abstract partial class MethodInfo : System.Reflection.MethodBase
    {
        internal MethodInfo() { }
        public virtual System.Reflection.ParameterInfo ReturnParameter { get { throw null; } }
        public virtual System.Type ReturnType { get { throw null; } }
        public virtual System.Delegate CreateDelegate(System.Type delegateType) { throw null; }
        public virtual System.Delegate CreateDelegate(System.Type delegateType, object target) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override System.Type[] GetGenericArguments() { throw null; }
        public virtual System.Reflection.MethodInfo GetGenericMethodDefinition() { throw null; }
        public override int GetHashCode() { throw null; }
        public virtual System.Reflection.MethodInfo MakeGenericMethod(params System.Type[] typeArguments) { throw null; }
    }
    public abstract partial class Module
    {
        internal Module() { }
        public virtual System.Reflection.Assembly Assembly { get { throw null; } }
        public virtual System.Collections.Generic.IEnumerable<System.Reflection.CustomAttributeData> CustomAttributes { get { throw null; } }
        public virtual string FullyQualifiedName { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public override bool Equals(object o) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParameterInfo
    {
        internal ParameterInfo() { }
        public virtual System.Reflection.ParameterAttributes Attributes { get { throw null; } }
        public virtual System.Collections.Generic.IEnumerable<System.Reflection.CustomAttributeData> CustomAttributes { get { throw null; } }
        public virtual object DefaultValue { get { throw null; } }
        public virtual bool HasDefaultValue { get { throw null; } }
        public bool IsIn { get { throw null; } }
        public bool IsOptional { get { throw null; } }
        public bool IsOut { get { throw null; } }
        public bool IsRetval { get { throw null; } }
        public virtual System.Reflection.MemberInfo Member { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual System.Type ParameterType { get { throw null; } }
        public virtual int Position { get { throw null; } }
    }
    public abstract partial class PropertyInfo : System.Reflection.MemberInfo
    {
        internal PropertyInfo() { }
        public abstract System.Reflection.PropertyAttributes Attributes { get; }
        public abstract bool CanRead { get; }
        public abstract bool CanWrite { get; }
        public virtual System.Reflection.MethodInfo GetMethod { get { throw null; } }
        public bool IsSpecialName { get { throw null; } }
        public abstract System.Type PropertyType { get; }
        public virtual System.Reflection.MethodInfo SetMethod { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public virtual object GetConstantValue() { throw null; }
        public override int GetHashCode() { throw null; }
        public abstract System.Reflection.ParameterInfo[] GetIndexParameters();
        public object GetValue(object obj) { throw null; }
        public virtual object GetValue(object obj, object[] index) { throw null; }
        public void SetValue(object obj, object value) { }
        public virtual void SetValue(object obj, object value, object[] index) { }
    }
    public abstract partial class ReflectionContext
    {
        protected ReflectionContext() { }
        public virtual System.Reflection.TypeInfo GetTypeForObject(object value) { throw null; }
        public abstract System.Reflection.Assembly MapAssembly(System.Reflection.Assembly assembly);
        public abstract System.Reflection.TypeInfo MapType(System.Reflection.TypeInfo type);
    }
    public sealed partial class ReflectionTypeLoadException : System.Exception
    {
        public ReflectionTypeLoadException(System.Type[] classes, System.Exception[] exceptions) { }
        public ReflectionTypeLoadException(System.Type[] classes, System.Exception[] exceptions, string message) { }
        public System.Exception[] LoaderExceptions { get { throw null; } }
        public System.Type[] Types { get { throw null; } }
    }
    [System.FlagsAttribute]
    public enum ResourceLocation
    {
        ContainedInAnotherAssembly = 2,
        ContainedInManifestFile = 4,
        Embedded = 1,
    }
    public sealed partial class TargetInvocationException : System.Exception
    {
        public TargetInvocationException(System.Exception inner) { }
        public TargetInvocationException(string message, System.Exception inner) { }
    }
    public sealed partial class TargetParameterCountException : System.Exception
    {
        public TargetParameterCountException() { }
        public TargetParameterCountException(string message) { }
        public TargetParameterCountException(string message, System.Exception inner) { }
    }
    public abstract partial class TypeInfo : System.Reflection.MemberInfo, System.Reflection.IReflectableType
    {
        internal TypeInfo() { }
        public abstract System.Reflection.Assembly Assembly { get; }
        public abstract string AssemblyQualifiedName { get; }
        public abstract System.Reflection.TypeAttributes Attributes { get; }
        public abstract System.Type BaseType { get; }
        public abstract bool ContainsGenericParameters { get; }
        public virtual System.Collections.Generic.IEnumerable<System.Reflection.ConstructorInfo> DeclaredConstructors { get { throw null; } }
        public virtual System.Collections.Generic.IEnumerable<System.Reflection.EventInfo> DeclaredEvents { get { throw null; } }
        public virtual System.Collections.Generic.IEnumerable<System.Reflection.FieldInfo> DeclaredFields { get { throw null; } }
        public virtual System.Collections.Generic.IEnumerable<System.Reflection.MemberInfo> DeclaredMembers { get { throw null; } }
        public virtual System.Collections.Generic.IEnumerable<System.Reflection.MethodInfo> DeclaredMethods { get { throw null; } }
        public virtual System.Collections.Generic.IEnumerable<System.Reflection.TypeInfo> DeclaredNestedTypes { get { throw null; } }
        public virtual System.Collections.Generic.IEnumerable<System.Reflection.PropertyInfo> DeclaredProperties { get { throw null; } }
        public abstract System.Reflection.MethodBase DeclaringMethod { get; }
        public abstract string FullName { get; }
        public abstract System.Reflection.GenericParameterAttributes GenericParameterAttributes { get; }
        public abstract int GenericParameterPosition { get; }
        public abstract System.Type[] GenericTypeArguments { get; }
        public virtual System.Type[] GenericTypeParameters { get { throw null; } }
        public abstract System.Guid GUID { get; }
        public bool HasElementType { get { throw null; } }
        public virtual System.Collections.Generic.IEnumerable<System.Type> ImplementedInterfaces { get { throw null; } }
        public bool IsAbstract { get { throw null; } }
        public bool IsAnsiClass { get { throw null; } }
        public bool IsArray { get { throw null; } }
        public bool IsAutoClass { get { throw null; } }
        public bool IsAutoLayout { get { throw null; } }
        public bool IsByRef { get { throw null; } }
        public bool IsClass { get { throw null; } }
        public abstract bool IsEnum { get; }
        public bool IsExplicitLayout { get { throw null; } }
        public abstract bool IsGenericParameter { get; }
        public abstract bool IsGenericType { get; }
        public abstract bool IsGenericTypeDefinition { get; }
        public bool IsImport { get { throw null; } }
        public bool IsInterface { get { throw null; } }
        public bool IsLayoutSequential { get { throw null; } }
        public bool IsMarshalByRef { get { throw null; } }
        public bool IsNested { get { throw null; } }
        public bool IsNestedAssembly { get { throw null; } }
        public bool IsNestedFamANDAssem { get { throw null; } }
        public bool IsNestedFamily { get { throw null; } }
        public bool IsNestedFamORAssem { get { throw null; } }
        public bool IsNestedPrivate { get { throw null; } }
        public bool IsNestedPublic { get { throw null; } }
        public bool IsNotPublic { get { throw null; } }
        public bool IsPointer { get { throw null; } }
        public bool IsPrimitive { get { throw null; } }
        public bool IsPublic { get { throw null; } }
        public bool IsSealed { get { throw null; } }
        public abstract bool IsSerializable { get; }
        public bool IsSpecialName { get { throw null; } }
        public bool IsUnicodeClass { get { throw null; } }
        public bool IsValueType { get { throw null; } }
        public bool IsVisible { get { throw null; } }
        public abstract string Namespace { get; }
        public virtual System.Type AsType() { throw null; }
        public abstract int GetArrayRank();
        public virtual System.Reflection.EventInfo GetDeclaredEvent(string name) { throw null; }
        public virtual System.Reflection.FieldInfo GetDeclaredField(string name) { throw null; }
        public virtual System.Reflection.MethodInfo GetDeclaredMethod(string name) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<System.Reflection.MethodInfo> GetDeclaredMethods(string name) { throw null; }
        public virtual System.Reflection.TypeInfo GetDeclaredNestedType(string name) { throw null; }
        public virtual System.Reflection.PropertyInfo GetDeclaredProperty(string name) { throw null; }
        public abstract System.Type GetElementType();
        public abstract System.Type[] GetGenericParameterConstraints();
        public abstract System.Type GetGenericTypeDefinition();
        public virtual bool IsAssignableFrom(System.Reflection.TypeInfo typeInfo) { throw null; }
        public virtual bool IsSubclassOf(System.Type c) { throw null; }
        public abstract System.Type MakeArrayType();
        public abstract System.Type MakeArrayType(int rank);
        public abstract System.Type MakeByRefType();
        public abstract System.Type MakeGenericType(params System.Type[] typeArguments);
        public abstract System.Type MakePointerType();
        System.Reflection.TypeInfo System.Reflection.IReflectableType.GetTypeInfo() { throw null; }
    }
}
