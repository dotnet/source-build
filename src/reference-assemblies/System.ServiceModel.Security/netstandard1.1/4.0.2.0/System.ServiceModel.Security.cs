[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ServiceModel.Security")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ServiceModel.Security")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.6.24702.02")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.6.24702.02. Commit Hash: c544ce29b87bec34deeb5a6e86b9b0b493723d30")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ServiceModel.Security")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.ServiceModel
{
    public partial class DnsEndpointIdentity : System.ServiceModel.EndpointIdentity
    {
        public DnsEndpointIdentity(string dnsName) { }
    }
    public abstract partial class MessageSecurityVersion
    {
        internal MessageSecurityVersion() { }
        public abstract System.ServiceModel.Security.BasicSecurityProfileVersion BasicSecurityProfileVersion { get; }
        public System.ServiceModel.Security.SecureConversationVersion SecureConversationVersion { get { throw null; } }
        public abstract System.ServiceModel.Security.SecurityPolicyVersion SecurityPolicyVersion { get; }
        public System.ServiceModel.Security.SecurityVersion SecurityVersion { get { throw null; } }
        public System.ServiceModel.Security.TrustVersion TrustVersion { get { throw null; } }
        public static System.ServiceModel.MessageSecurityVersion WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10 { get { throw null; } }
        public static System.ServiceModel.MessageSecurityVersion WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11 { get { throw null; } }
        public static System.ServiceModel.MessageSecurityVersion WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10 { get { throw null; } }
    }
    public partial class SpnEndpointIdentity : System.ServiceModel.EndpointIdentity
    {
        public SpnEndpointIdentity(string spnName) { }
        public static System.TimeSpan SpnLookupTime { get { throw null; } set { } }
    }
    public partial class UpnEndpointIdentity : System.ServiceModel.EndpointIdentity
    {
        public UpnEndpointIdentity(string upnName) { }
    }
}
namespace System.ServiceModel.Channels
{
    public sealed partial class LocalClientSecuritySettings
    {
        public LocalClientSecuritySettings() { }
        public System.TimeSpan MaxClockSkew { get { throw null; } set { } }
        public System.TimeSpan ReplayWindow { get { throw null; } set { } }
        public System.TimeSpan TimestampValidityDuration { get { throw null; } set { } }
        public System.ServiceModel.Channels.LocalClientSecuritySettings Clone() { throw null; }
    }
    public abstract partial class SecurityBindingElement : System.ServiceModel.Channels.BindingElement
    {
        internal SecurityBindingElement() { }
        public System.ServiceModel.Security.Tokens.SupportingTokenParameters EndpointSupportingTokenParameters { get { throw null; } }
        public bool IncludeTimestamp { get { throw null; } set { } }
        public System.ServiceModel.Channels.LocalClientSecuritySettings LocalClientSettings { get { throw null; } }
        public System.ServiceModel.MessageSecurityVersion MessageSecurityVersion { get { throw null; } set { } }
        public System.ServiceModel.Channels.SecurityHeaderLayout SecurityHeaderLayout { get { throw null; } set { } }
        protected abstract System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactoryCore<TChannel>(System.ServiceModel.Channels.BindingContext context);
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override bool CanBuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public static System.ServiceModel.Channels.SecurityBindingElement CreateSecureConversationBindingElement(System.ServiceModel.Channels.SecurityBindingElement bootstrapSecurity) { throw null; }
        public static System.ServiceModel.Channels.TransportSecurityBindingElement CreateUserNameOverTransportBindingElement() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SecurityHeaderLayout
    {
        Lax = 1,
        Strict = 0,
    }
    public sealed partial class TransportSecurityBindingElement : System.ServiceModel.Channels.SecurityBindingElement
    {
        public TransportSecurityBindingElement() { }
        protected override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactoryCore<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override System.ServiceModel.Channels.BindingElement Clone() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
}
namespace System.ServiceModel.Security
{
    public abstract partial class BasicSecurityProfileVersion
    {
        internal BasicSecurityProfileVersion() { }
        public static System.ServiceModel.Security.BasicSecurityProfileVersion BasicSecurityProfile10 { get { throw null; } }
    }
    public abstract partial class SecureConversationVersion
    {
        internal SecureConversationVersion() { }
        public static System.ServiceModel.Security.SecureConversationVersion Default { get { throw null; } }
        public System.Xml.XmlDictionaryString Namespace { get { throw null; } }
        public System.Xml.XmlDictionaryString Prefix { get { throw null; } }
        public static System.ServiceModel.Security.SecureConversationVersion WSSecureConversationFeb2005 { get { throw null; } }
    }
    public abstract partial class SecurityPolicyVersion
    {
        internal SecurityPolicyVersion() { }
        public string Namespace { get { throw null; } }
        public string Prefix { get { throw null; } }
        public static System.ServiceModel.Security.SecurityPolicyVersion WSSecurityPolicy11 { get { throw null; } }
    }
    public abstract partial class SecurityVersion
    {
        internal SecurityVersion() { }
        public static System.ServiceModel.Security.SecurityVersion WSSecurity10 { get { throw null; } }
        public static System.ServiceModel.Security.SecurityVersion WSSecurity11 { get { throw null; } }
    }
    public abstract partial class TrustVersion
    {
        internal TrustVersion() { }
        public static System.ServiceModel.Security.TrustVersion Default { get { throw null; } }
        public System.Xml.XmlDictionaryString Namespace { get { throw null; } }
        public System.Xml.XmlDictionaryString Prefix { get { throw null; } }
        public static System.ServiceModel.Security.TrustVersion WSTrustFeb2005 { get { throw null; } }
    }
}
namespace System.ServiceModel.Security.Tokens
{
    public partial class SecureConversationSecurityTokenParameters : System.ServiceModel.Security.Tokens.SecurityTokenParameters
    {
        public SecureConversationSecurityTokenParameters() { }
        public SecureConversationSecurityTokenParameters(System.ServiceModel.Channels.SecurityBindingElement bootstrapSecurityBindingElement) { }
        public System.ServiceModel.Channels.SecurityBindingElement BootstrapSecurityBindingElement { get { throw null; } set { } }
    }
    public abstract partial class SecurityTokenParameters
    {
        internal SecurityTokenParameters() { }
        public System.ServiceModel.Security.Tokens.SecurityTokenParameters Clone() { throw null; }
    }
    public partial class SupportingTokenParameters
    {
        public SupportingTokenParameters() { }
        public System.Collections.ObjectModel.Collection<System.ServiceModel.Security.Tokens.SecurityTokenParameters> Endorsing { get { throw null; } }
        public System.Collections.ObjectModel.Collection<System.ServiceModel.Security.Tokens.SecurityTokenParameters> SignedEncrypted { get { throw null; } }
        public System.ServiceModel.Security.Tokens.SupportingTokenParameters Clone() { throw null; }
    }
    public partial class UserNameSecurityTokenParameters : System.ServiceModel.Security.Tokens.SecurityTokenParameters
    {
        public UserNameSecurityTokenParameters() { }
    }
}
