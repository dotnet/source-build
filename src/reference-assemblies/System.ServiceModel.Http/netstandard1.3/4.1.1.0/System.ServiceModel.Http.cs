[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ServiceModel.Http")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ServiceModel.Http")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.6.24702.02")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.6.24702.02. Commit Hash: c544ce29b87bec34deeb5a6e86b9b0b493723d30")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ServiceModel.Http")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.ServiceModel
{
    public partial class BasicHttpBinding : System.ServiceModel.HttpBindingBase
    {
        public BasicHttpBinding() { }
        public BasicHttpBinding(System.ServiceModel.BasicHttpSecurityMode securityMode) { }
        public System.ServiceModel.BasicHttpSecurity Security { get { throw null; } set { } }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingParameterCollection parameters) { throw null; }
        public override System.ServiceModel.Channels.BindingElementCollection CreateBindingElements() { throw null; }
    }
    public enum BasicHttpMessageCredentialType
    {
        Certificate = 1,
        UserName = 0,
    }
    public partial class BasicHttpsBinding : System.ServiceModel.HttpBindingBase
    {
        public BasicHttpsBinding() { }
        public BasicHttpsBinding(System.ServiceModel.BasicHttpsSecurityMode securityMode) { }
        public System.ServiceModel.BasicHttpsSecurity Security { get { throw null; } set { } }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingParameterCollection parameters) { throw null; }
        public override System.ServiceModel.Channels.BindingElementCollection CreateBindingElements() { throw null; }
    }
    public sealed partial class BasicHttpSecurity
    {
        internal BasicHttpSecurity() { }
        public System.ServiceModel.BasicHttpSecurityMode Mode { get { throw null; } set { } }
        public System.ServiceModel.HttpTransportSecurity Transport { get { throw null; } set { } }
    }
    public enum BasicHttpSecurityMode
    {
        Message = 2,
        None = 0,
        Transport = 1,
        TransportCredentialOnly = 4,
        TransportWithMessageCredential = 3,
    }
    public sealed partial class BasicHttpsSecurity
    {
        internal BasicHttpsSecurity() { }
        public System.ServiceModel.BasicHttpsSecurityMode Mode { get { throw null; } set { } }
        public System.ServiceModel.HttpTransportSecurity Transport { get { throw null; } set { } }
    }
    public enum BasicHttpsSecurityMode
    {
        Transport = 0,
        TransportWithMessageCredential = 1,
    }
    public abstract partial class HttpBindingBase : System.ServiceModel.Channels.Binding
    {
        internal HttpBindingBase() { }
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool AllowCookies { get { throw null; } set { } }
        public System.ServiceModel.EnvelopeVersion EnvelopeVersion { get { throw null; } }
        [System.ComponentModel.DefaultValueAttribute((long)524288)]
        public long MaxBufferPoolSize { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(65536)]
        public int MaxBufferSize { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute((long)65536)]
        public long MaxReceivedMessageSize { get { throw null; } set { } }
        public System.Xml.XmlDictionaryReaderQuotas ReaderQuotas { get { throw null; } set { } }
        public override string Scheme { get { throw null; } }
        public System.Text.Encoding TextEncoding { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute((System.ServiceModel.TransferMode)(0))]
        public System.ServiceModel.TransferMode TransferMode { get { throw null; } set { } }
    }
    public enum HttpClientCredentialType
    {
        Basic = 1,
        Certificate = 5,
        Digest = 2,
        InheritedFromHost = 6,
        None = 0,
        Ntlm = 3,
        Windows = 4,
    }
    public sealed partial class HttpTransportSecurity
    {
        public HttpTransportSecurity() { }
        public System.ServiceModel.HttpClientCredentialType ClientCredentialType { get { throw null; } set { } }
    }
    public partial class NetHttpBinding : System.ServiceModel.HttpBindingBase
    {
        public NetHttpBinding() { }
        public NetHttpBinding(System.ServiceModel.BasicHttpSecurityMode securityMode) { }
        public NetHttpBinding(string configurationName) { }
        [System.ComponentModel.DefaultValueAttribute((System.ServiceModel.NetHttpMessageEncoding)(0))]
        public System.ServiceModel.NetHttpMessageEncoding MessageEncoding { get { throw null; } set { } }
        public System.ServiceModel.BasicHttpSecurity Security { get { throw null; } set { } }
        public System.ServiceModel.Channels.WebSocketTransportSettings WebSocketSettings { get { throw null; } }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingParameterCollection parameters) { throw null; }
        public override System.ServiceModel.Channels.BindingElementCollection CreateBindingElements() { throw null; }
    }
    public enum NetHttpMessageEncoding
    {
        Binary = 0,
        Mtom = 2,
        Text = 1,
    }
    public partial class NetHttpsBinding : System.ServiceModel.HttpBindingBase
    {
        public NetHttpsBinding() { }
        public NetHttpsBinding(System.ServiceModel.BasicHttpsSecurityMode securityMode) { }
        [System.ComponentModel.DefaultValueAttribute((System.ServiceModel.NetHttpMessageEncoding)(0))]
        public System.ServiceModel.NetHttpMessageEncoding MessageEncoding { get { throw null; } set { } }
        public System.ServiceModel.BasicHttpsSecurity Security { get { throw null; } set { } }
        public System.ServiceModel.Channels.WebSocketTransportSettings WebSocketSettings { get { throw null; } }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingParameterCollection parameters) { throw null; }
        public override System.ServiceModel.Channels.BindingElementCollection CreateBindingElements() { throw null; }
    }
}
namespace System.ServiceModel.Channels
{
    public sealed partial class HttpRequestMessageProperty : System.ServiceModel.Channels.IMessageProperty
    {
        public HttpRequestMessageProperty() { }
        public System.Net.WebHeaderCollection Headers { get { throw null; } }
        public string Method { get { throw null; } set { } }
        public static string Name { get { throw null; } }
        public string QueryString { get { throw null; } set { } }
        public bool SuppressEntityBody { get { throw null; } set { } }
        System.ServiceModel.Channels.IMessageProperty System.ServiceModel.Channels.IMessageProperty.CreateCopy() { throw null; }
    }
    public sealed partial class HttpResponseMessageProperty : System.ServiceModel.Channels.IMessageProperty
    {
        public HttpResponseMessageProperty() { }
        public System.Net.WebHeaderCollection Headers { get { throw null; } }
        public static string Name { get { throw null; } }
        public System.Net.HttpStatusCode StatusCode { get { throw null; } set { } }
        public string StatusDescription { get { throw null; } set { } }
        System.ServiceModel.Channels.IMessageProperty System.ServiceModel.Channels.IMessageProperty.CreateCopy() { throw null; }
    }
    public partial class HttpsTransportBindingElement : System.ServiceModel.Channels.HttpTransportBindingElement
    {
        public HttpsTransportBindingElement() { }
        protected HttpsTransportBindingElement(System.ServiceModel.Channels.HttpsTransportBindingElement elementToBeCloned) { }
        public bool RequireClientCertificate { get { throw null; } set { } }
        public override string Scheme { get { throw null; } }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override System.ServiceModel.Channels.BindingElement Clone() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
    public partial class HttpTransportBindingElement : System.ServiceModel.Channels.TransportBindingElement
    {
        public HttpTransportBindingElement() { }
        protected HttpTransportBindingElement(System.ServiceModel.Channels.HttpTransportBindingElement elementToBeCloned) { }
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool AllowCookies { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute((System.Net.AuthenticationSchemes)(32768))]
        public System.Net.AuthenticationSchemes AuthenticationScheme { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(65536)]
        public int MaxBufferSize { get { throw null; } set { } }
        public override string Scheme { get { throw null; } }
        [System.ComponentModel.DefaultValueAttribute((System.ServiceModel.TransferMode)(0))]
        public System.ServiceModel.TransferMode TransferMode { get { throw null; } set { } }
        public System.ServiceModel.Channels.WebSocketTransportSettings WebSocketSettings { get { throw null; } set { } }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override bool CanBuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override System.ServiceModel.Channels.BindingElement Clone() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
    public partial interface IHttpCookieContainerManager
    {
        System.Net.CookieContainer CookieContainer { get; set; }
    }
    public sealed partial class WebSocketTransportSettings : System.IEquatable<System.ServiceModel.Channels.WebSocketTransportSettings>
    {
        public const string BinaryMessageReceivedAction = "http://schemas.microsoft.com/2011/02/websockets/onbinarymessage";
        public const string TextMessageReceivedAction = "http://schemas.microsoft.com/2011/02/websockets/ontextmessage";
        public WebSocketTransportSettings() { }
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool DisablePayloadMasking { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(typeof(System.TimeSpan), "00:00:00")]
        public System.TimeSpan KeepAliveInterval { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(null)]
        public string SubProtocol { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute((System.ServiceModel.Channels.WebSocketTransportUsage)(2))]
        public System.ServiceModel.Channels.WebSocketTransportUsage TransportUsage { get { throw null; } set { } }
        public override bool Equals(object obj) { throw null; }
        public bool Equals(System.ServiceModel.Channels.WebSocketTransportSettings other) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public enum WebSocketTransportUsage
    {
        Always = 1,
        Never = 2,
        WhenDuplex = 0,
    }
}
