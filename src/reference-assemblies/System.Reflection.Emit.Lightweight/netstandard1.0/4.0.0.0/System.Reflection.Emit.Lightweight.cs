[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Reflection.Emit.Lightweight")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Reflection.Emit.Lightweight")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Reflection.Emit.Lightweight")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Reflection.Emit
{
    public sealed partial class DynamicMethod : System.Reflection.MethodInfo
    {
        [System.Security.SecuritySafeCriticalAttribute]
        public DynamicMethod(string name, System.Reflection.MethodAttributes attributes, System.Reflection.CallingConventions callingConvention, System.Type returnType, System.Type[] parameterTypes, System.Reflection.Module m, bool skipVisibility) { }
        [System.Security.SecuritySafeCriticalAttribute]
        public DynamicMethod(string name, System.Reflection.MethodAttributes attributes, System.Reflection.CallingConventions callingConvention, System.Type returnType, System.Type[] parameterTypes, System.Type owner, bool skipVisibility) { }
        [System.Security.SecuritySafeCriticalAttribute]
        public DynamicMethod(string name, System.Type returnType, System.Type[] parameterTypes) { }
        [System.Security.SecuritySafeCriticalAttribute]
        public DynamicMethod(string name, System.Type returnType, System.Type[] parameterTypes, bool restrictedSkipVisibility) { }
        [System.Security.SecuritySafeCriticalAttribute]
        public DynamicMethod(string name, System.Type returnType, System.Type[] parameterTypes, System.Reflection.Module m) { }
        [System.Security.SecuritySafeCriticalAttribute]
        public DynamicMethod(string name, System.Type returnType, System.Type[] parameterTypes, System.Reflection.Module m, bool skipVisibility) { }
        [System.Security.SecuritySafeCriticalAttribute]
        public DynamicMethod(string name, System.Type returnType, System.Type[] parameterTypes, System.Type owner) { }
        [System.Security.SecuritySafeCriticalAttribute]
        public DynamicMethod(string name, System.Type returnType, System.Type[] parameterTypes, System.Type owner, bool skipVisibility) { }
        public override System.Reflection.MethodAttributes Attributes { get { throw null; } }
        public override System.Reflection.CallingConventions CallingConvention { get { throw null; } }
        public override System.Type DeclaringType { get { throw null; } }
        public bool InitLocals { get { throw null; } set { } }
        public override System.Reflection.MethodImplAttributes MethodImplementationFlags { get { throw null; } }
        public override string Name { get { throw null; } }
        public override System.Reflection.ParameterInfo ReturnParameter { get { throw null; } }
        public override System.Type ReturnType { get { throw null; } }
        [System.Security.SecuritySafeCriticalAttribute]
        public sealed override System.Delegate CreateDelegate(System.Type delegateType) { throw null; }
        [System.Security.SecuritySafeCriticalAttribute]
        public sealed override System.Delegate CreateDelegate(System.Type delegateType, object target) { throw null; }
        public System.Reflection.Emit.ILGenerator GetILGenerator() { throw null; }
        [System.Security.SecuritySafeCriticalAttribute]
        public System.Reflection.Emit.ILGenerator GetILGenerator(int streamSize) { throw null; }
        public override System.Reflection.ParameterInfo[] GetParameters() { throw null; }
        public override string ToString() { throw null; }
    }
}
