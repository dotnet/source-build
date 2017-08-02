[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Globalization.Extensions")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Globalization.Extensions")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Globalization.Extensions")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System
{
    public static partial class StringNormalizationExtensions
    {
        public static bool IsNormalized(this string value) { throw null; }
        [System.Security.SecurityCriticalAttribute]
        public static bool IsNormalized(this string value, System.Text.NormalizationForm normalizationForm) { throw null; }
        public static string Normalize(this string value) { throw null; }
        [System.Security.SecurityCriticalAttribute]
        public static string Normalize(this string value, System.Text.NormalizationForm normalizationForm) { throw null; }
    }
}
namespace System.Globalization
{
    public static partial class GlobalizationExtensions
    {
        public static System.StringComparer GetStringComparer(this System.Globalization.CompareInfo compareInfo, System.Globalization.CompareOptions options) { throw null; }
    }
    public sealed partial class IdnMapping
    {
        public IdnMapping() { }
        public bool AllowUnassigned { get { throw null; } set { } }
        public bool UseStd3AsciiRules { get { throw null; } set { } }
        public override bool Equals(object obj) { throw null; }
        public string GetAscii(string unicode) { throw null; }
        public string GetAscii(string unicode, int index) { throw null; }
        public string GetAscii(string unicode, int index, int count) { throw null; }
        public override int GetHashCode() { throw null; }
        public string GetUnicode(string ascii) { throw null; }
        public string GetUnicode(string ascii, int index) { throw null; }
        public string GetUnicode(string ascii, int index, int count) { throw null; }
    }
}
namespace System.Text
{
    public enum NormalizationForm
    {
        FormC = 1,
        FormD = 2,
        FormKC = 5,
        FormKD = 6,
    }
}
