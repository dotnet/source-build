[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ServiceModel.Security.dll")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ServiceModel.Security.dll")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.30319.17931")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.30319.17931")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ServiceModel.Security.dll")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
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
        public bool IncludeTimestamp { get { throw null; } set { } }
        public System.ServiceModel.Channels.LocalClientSecuritySettings LocalClientSettings { get { throw null; } }
        protected abstract System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactoryCore<TChannel>(System.ServiceModel.Channels.BindingContext context);
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override bool CanBuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public static System.ServiceModel.Channels.TransportSecurityBindingElement CreateUserNameOverTransportBindingElement() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
    public sealed partial class TransportSecurityBindingElement : System.ServiceModel.Channels.SecurityBindingElement
    {
        public TransportSecurityBindingElement() { }
        protected override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactoryCore<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override System.ServiceModel.Channels.BindingElement Clone() { throw null; }
    }
}
