[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ServiceModel.NetTcp.dll")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ServiceModel.NetTcp.dll")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.30319.17929")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.30319.17929")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ServiceModel.NetTcp.dll")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.ServiceModel
{
    public sealed partial class MessageSecurityOverTcp
    {
        public MessageSecurityOverTcp() { }
        [System.ComponentModel.DefaultValueAttribute((System.ServiceModel.MessageCredentialType)(1))]
        public System.ServiceModel.MessageCredentialType ClientCredentialType { get { throw null; } set { } }
    }
    public partial class NetTcpBinding : System.ServiceModel.Channels.Binding
    {
        public NetTcpBinding() { }
        public NetTcpBinding(System.ServiceModel.SecurityMode securityMode) { }
        public NetTcpBinding(string configurationName) { }
        public System.ServiceModel.EnvelopeVersion EnvelopeVersion { get { throw null; } }
        [System.ComponentModel.DefaultValueAttribute((long)524288)]
        public long MaxBufferPoolSize { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(65536)]
        public int MaxBufferSize { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute((long)65536)]
        public long MaxReceivedMessageSize { get { throw null; } set { } }
        public System.Xml.XmlDictionaryReaderQuotas ReaderQuotas { get { throw null; } set { } }
        public override string Scheme { get { throw null; } }
        public System.ServiceModel.NetTcpSecurity Security { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute((System.ServiceModel.TransferMode)(0))]
        public System.ServiceModel.TransferMode TransferMode { get { throw null; } set { } }
        public override System.ServiceModel.Channels.BindingElementCollection CreateBindingElements() { throw null; }
    }
    public sealed partial class NetTcpSecurity
    {
        public NetTcpSecurity() { }
        public System.ServiceModel.MessageSecurityOverTcp Message { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute((System.ServiceModel.SecurityMode)(1))]
        public System.ServiceModel.SecurityMode Mode { get { throw null; } set { } }
        public System.ServiceModel.TcpTransportSecurity Transport { get { throw null; } set { } }
    }
    public enum TcpClientCredentialType
    {
        Certificate = 2,
        None = 0,
        Windows = 1,
    }
    public sealed partial class TcpTransportSecurity
    {
        public TcpTransportSecurity() { }
        [System.ComponentModel.DefaultValueAttribute((System.ServiceModel.TcpClientCredentialType)(1))]
        public System.ServiceModel.TcpClientCredentialType ClientCredentialType { get { throw null; } set { } }
    }
}
namespace System.ServiceModel.Channels
{
    public abstract partial class ConnectionOrientedTransportBindingElement : System.ServiceModel.Channels.TransportBindingElement
    {
        internal ConnectionOrientedTransportBindingElement() { }
        [System.ComponentModel.DefaultValueAttribute(8192)]
        public int ConnectionBufferSize { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(65536)]
        public int MaxBufferSize { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute((System.ServiceModel.TransferMode)(0))]
        public System.ServiceModel.TransferMode TransferMode { get { throw null; } set { } }
        public override bool CanBuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
    public partial class SslStreamSecurityBindingElement : System.ServiceModel.Channels.BindingElement
    {
        public SslStreamSecurityBindingElement() { }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override bool CanBuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override System.ServiceModel.Channels.BindingElement Clone() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
    public sealed partial class TcpConnectionPoolSettings
    {
        internal TcpConnectionPoolSettings() { }
        public string GroupName { get { throw null; } set { } }
        public System.TimeSpan IdleTimeout { get { throw null; } set { } }
        public System.TimeSpan LeaseTimeout { get { throw null; } set { } }
        public int MaxOutboundConnectionsPerEndpoint { get { throw null; } set { } }
    }
    public partial class TcpTransportBindingElement : System.ServiceModel.Channels.ConnectionOrientedTransportBindingElement
    {
        public TcpTransportBindingElement() { }
        protected TcpTransportBindingElement(System.ServiceModel.Channels.TcpTransportBindingElement elementToBeCloned) { }
        public System.ServiceModel.Channels.TcpConnectionPoolSettings ConnectionPoolSettings { get { throw null; } }
        public override string Scheme { get { throw null; } }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override System.ServiceModel.Channels.BindingElement Clone() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
    public partial class WindowsStreamSecurityBindingElement : System.ServiceModel.Channels.BindingElement
    {
        public WindowsStreamSecurityBindingElement() { }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override bool CanBuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override System.ServiceModel.Channels.BindingElement Clone() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
}
