[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("Microsoft.CSharp")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("Microsoft.CSharp")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("Microsoft.CSharp")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace Microsoft.CSharp.RuntimeBinder
{
    [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
    public static partial class Binder
    {
        public static System.Runtime.CompilerServices.CallSiteBinder BinaryOperation(Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags flags, System.Linq.Expressions.ExpressionType operation, System.Type context, System.Collections.Generic.IEnumerable<Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo> argumentInfo) { throw null; }
        public static System.Runtime.CompilerServices.CallSiteBinder Convert(Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags flags, System.Type type, System.Type context) { throw null; }
        public static System.Runtime.CompilerServices.CallSiteBinder GetIndex(Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags flags, System.Type context, System.Collections.Generic.IEnumerable<Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo> argumentInfo) { throw null; }
        public static System.Runtime.CompilerServices.CallSiteBinder GetMember(Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags flags, string name, System.Type context, System.Collections.Generic.IEnumerable<Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo> argumentInfo) { throw null; }
        public static System.Runtime.CompilerServices.CallSiteBinder Invoke(Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags flags, System.Type context, System.Collections.Generic.IEnumerable<Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo> argumentInfo) { throw null; }
        public static System.Runtime.CompilerServices.CallSiteBinder InvokeConstructor(Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags flags, System.Type context, System.Collections.Generic.IEnumerable<Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo> argumentInfo) { throw null; }
        public static System.Runtime.CompilerServices.CallSiteBinder InvokeMember(Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags flags, string name, System.Collections.Generic.IEnumerable<System.Type> typeArguments, System.Type context, System.Collections.Generic.IEnumerable<Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo> argumentInfo) { throw null; }
        public static System.Runtime.CompilerServices.CallSiteBinder IsEvent(Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags flags, string name, System.Type context) { throw null; }
        public static System.Runtime.CompilerServices.CallSiteBinder SetIndex(Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags flags, System.Type context, System.Collections.Generic.IEnumerable<Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo> argumentInfo) { throw null; }
        public static System.Runtime.CompilerServices.CallSiteBinder SetMember(Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags flags, string name, System.Type context, System.Collections.Generic.IEnumerable<Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo> argumentInfo) { throw null; }
        public static System.Runtime.CompilerServices.CallSiteBinder UnaryOperation(Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags flags, System.Linq.Expressions.ExpressionType operation, System.Type context, System.Collections.Generic.IEnumerable<Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo> argumentInfo) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
    public sealed partial class CSharpArgumentInfo
    {
        internal CSharpArgumentInfo() { }
        public static Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo Create(Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfoFlags flags, string name) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
    [System.FlagsAttribute]
    public enum CSharpArgumentInfoFlags
    {
        Constant = 2,
        IsOut = 16,
        IsRef = 8,
        IsStaticType = 32,
        NamedArgument = 4,
        None = 0,
        UseCompileTimeType = 1,
    }
    [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
    [System.FlagsAttribute]
    public enum CSharpBinderFlags
    {
        BinaryOperationLogical = 8,
        CheckedContext = 1,
        ConvertArrayIndex = 32,
        ConvertExplicit = 16,
        InvokeSimpleName = 2,
        InvokeSpecialName = 4,
        None = 0,
        ResultDiscarded = 256,
        ResultIndexed = 64,
        ValueFromCompoundAssignment = 128,
    }
    public partial class RuntimeBinderException : System.Exception
    {
        public RuntimeBinderException() { }
        public RuntimeBinderException(string message) { }
        public RuntimeBinderException(string message, System.Exception innerException) { }
    }
    public partial class RuntimeBinderInternalCompilerException : System.Exception
    {
        public RuntimeBinderInternalCompilerException() { }
        public RuntimeBinderInternalCompilerException(string message) { }
        public RuntimeBinderInternalCompilerException(string message, System.Exception innerException) { }
    }
}
