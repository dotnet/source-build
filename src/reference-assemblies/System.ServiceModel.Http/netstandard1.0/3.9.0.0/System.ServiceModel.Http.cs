[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ServiceModel.Http.dll")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ServiceModel.Http.dll")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.30319.17931")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.30319.17931")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ServiceModel.Http.dll")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
namespace System.ServiceModel
{
    public partial class BasicHttpBinding : System.ServiceModel.Channels.Binding
    {
        public BasicHttpBinding() { }
        public BasicHttpBinding(System.ServiceModel.BasicHttpSecurityMode securityMode) { }
        public System.ServiceModel.EnvelopeVersion EnvelopeVersion { get { throw null; } }
        public int MaxBufferSize { get { throw null; } set { } }
        public long MaxReceivedMessageSize { get { throw null; } set { } }
        public override string Scheme { get { throw null; } }
        public System.ServiceModel.BasicHttpSecurity Security { get { throw null; } }
        public System.Text.Encoding TextEncoding { get { throw null; } set { } }
        public override System.ServiceModel.Channels.BindingElementCollection CreateBindingElements() { throw null; }
    }
    public enum BasicHttpMessageCredentialType
    {
        Certificate = 1,
        UserName = 0,
    }
    public sealed partial class BasicHttpSecurity
    {
        internal BasicHttpSecurity() { }
        public System.ServiceModel.BasicHttpSecurityMode Mode { get { throw null; } set { } }
    }
    public enum BasicHttpSecurityMode
    {
        None = 0,
        Transport = 1,
        TransportCredentialOnly = 4,
        TransportWithMessageCredential = 3,
    }
}
namespace System.ServiceModel.Channels
{
    public sealed partial class HttpRequestMessageProperty
    {
        public HttpRequestMessageProperty() { }
        public System.Net.WebHeaderCollection Headers { get { throw null; } }
        public string Method { get { throw null; } set { } }
        public static string Name { get { throw null; } }
        public string QueryString { get { throw null; } set { } }
        public bool SuppressEntityBody { get { throw null; } set { } }
    }
    public sealed partial class HttpResponseMessageProperty
    {
        public HttpResponseMessageProperty() { }
        public System.Net.WebHeaderCollection Headers { get { throw null; } }
        public static string Name { get { throw null; } }
        public System.Net.HttpStatusCode StatusCode { get { throw null; } set { } }
        public string StatusDescription { get { throw null; } set { } }
    }
    public partial class HttpsTransportBindingElement : System.ServiceModel.Channels.HttpTransportBindingElement
    {
        public HttpsTransportBindingElement() { }
        protected HttpsTransportBindingElement(System.ServiceModel.Channels.HttpsTransportBindingElement elementToBeCloned) { }
        public override string Scheme { get { throw null; } }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override System.ServiceModel.Channels.BindingElement Clone() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
    public partial class HttpTransportBindingElement : System.ServiceModel.Channels.TransportBindingElement
    {
        public HttpTransportBindingElement() { }
        protected HttpTransportBindingElement(System.ServiceModel.Channels.HttpTransportBindingElement elementToBeCloned) { }
        public int MaxBufferSize { get { throw null; } set { } }
        public override string Scheme { get { throw null; } }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override bool CanBuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override System.ServiceModel.Channels.BindingElement Clone() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
    public partial interface IHttpCookieContainerManager
    {
        System.Net.CookieContainer CookieContainer { get; set; }
    }
}
