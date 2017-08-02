[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Xml.XPath.XDocument")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Xml.XPath.XDocument")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Xml.XPath.XDocument")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Xml.XPath
{
    public static partial class Extensions
    {
        public static System.Xml.XPath.XPathNavigator CreateNavigator(this System.Xml.Linq.XNode node) { throw null; }
        public static System.Xml.XPath.XPathNavigator CreateNavigator(this System.Xml.Linq.XNode node, System.Xml.XmlNameTable nameTable) { throw null; }
        public static object XPathEvaluate(this System.Xml.Linq.XNode node, string expression) { throw null; }
        public static object XPathEvaluate(this System.Xml.Linq.XNode node, string expression, System.Xml.IXmlNamespaceResolver resolver) { throw null; }
        public static System.Xml.Linq.XElement XPathSelectElement(this System.Xml.Linq.XNode node, string expression) { throw null; }
        public static System.Xml.Linq.XElement XPathSelectElement(this System.Xml.Linq.XNode node, string expression, System.Xml.IXmlNamespaceResolver resolver) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Xml.Linq.XElement> XPathSelectElements(this System.Xml.Linq.XNode node, string expression) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Xml.Linq.XElement> XPathSelectElements(this System.Xml.Linq.XNode node, string expression, System.Xml.IXmlNamespaceResolver resolver) { throw null; }
    }
    public static partial class XDocumentExtensions
    {
        public static System.Xml.XPath.IXPathNavigable ToXPathNavigable(this System.Xml.Linq.XNode node) { throw null; }
    }
}
