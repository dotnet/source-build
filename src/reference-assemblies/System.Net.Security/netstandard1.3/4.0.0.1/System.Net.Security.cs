[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Net.Security")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Net.Security")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.25220.03")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.25220.03. Commit Hash: 5da214b57b4acf660a383acfc71f5ff9c805c1f9")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Net.Security")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Net.Security
{
    public abstract partial class AuthenticatedStream : System.IO.Stream
    {
        protected AuthenticatedStream(System.IO.Stream innerStream, bool leaveInnerStreamOpen) { }
        protected System.IO.Stream InnerStream { get { throw null; } }
        public abstract bool IsAuthenticated { get; }
        public abstract bool IsEncrypted { get; }
        public abstract bool IsMutuallyAuthenticated { get; }
        public abstract bool IsServer { get; }
        public abstract bool IsSigned { get; }
        public bool LeaveInnerStreamOpen { get { throw null; } }
        protected override void Dispose(bool disposing) { }
    }
    public enum EncryptionPolicy
    {
        AllowNoEncryption = 1,
        NoEncryption = 2,
        RequireEncryption = 0,
    }
    public delegate System.Security.Cryptography.X509Certificates.X509Certificate LocalCertificateSelectionCallback(object sender, string targetHost, System.Security.Cryptography.X509Certificates.X509CertificateCollection localCertificates, System.Security.Cryptography.X509Certificates.X509Certificate remoteCertificate, string[] acceptableIssuers);
    public partial class NegotiateStream : System.Net.Security.AuthenticatedStream
    {
        public NegotiateStream(System.IO.Stream innerStream) : base (default(System.IO.Stream), default(bool)) { }
        public NegotiateStream(System.IO.Stream innerStream, bool leaveInnerStreamOpen) : base (default(System.IO.Stream), default(bool)) { }
        public override bool CanRead { get { throw null; } }
        public override bool CanSeek { get { throw null; } }
        public override bool CanTimeout { get { throw null; } }
        public override bool CanWrite { get { throw null; } }
        public virtual System.Security.Principal.TokenImpersonationLevel ImpersonationLevel { get { throw null; } }
        public override bool IsAuthenticated { get { throw null; } }
        public override bool IsEncrypted { get { throw null; } }
        public override bool IsMutuallyAuthenticated { get { throw null; } }
        public override bool IsServer { get { throw null; } }
        public override bool IsSigned { get { throw null; } }
        public override long Length { get { throw null; } }
        public override long Position { get { throw null; } set { } }
        public override int ReadTimeout { get { throw null; } set { } }
        public virtual System.Security.Principal.IIdentity RemoteIdentity { get { throw null; } }
        public override int WriteTimeout { get { throw null; } set { } }
        public virtual System.Threading.Tasks.Task AuthenticateAsClientAsync() { throw null; }
        public virtual System.Threading.Tasks.Task AuthenticateAsClientAsync(System.Net.NetworkCredential credential, System.Security.Authentication.ExtendedProtection.ChannelBinding binding, string targetName) { throw null; }
        public virtual System.Threading.Tasks.Task AuthenticateAsClientAsync(System.Net.NetworkCredential credential, System.Security.Authentication.ExtendedProtection.ChannelBinding binding, string targetName, System.Net.Security.ProtectionLevel requiredProtectionLevel, System.Security.Principal.TokenImpersonationLevel allowedImpersonationLevel) { throw null; }
        public virtual System.Threading.Tasks.Task AuthenticateAsClientAsync(System.Net.NetworkCredential credential, string targetName) { throw null; }
        public virtual System.Threading.Tasks.Task AuthenticateAsClientAsync(System.Net.NetworkCredential credential, string targetName, System.Net.Security.ProtectionLevel requiredProtectionLevel, System.Security.Principal.TokenImpersonationLevel allowedImpersonationLevel) { throw null; }
        public virtual System.Threading.Tasks.Task AuthenticateAsServerAsync() { throw null; }
        public virtual System.Threading.Tasks.Task AuthenticateAsServerAsync(System.Net.NetworkCredential credential, System.Net.Security.ProtectionLevel requiredProtectionLevel, System.Security.Principal.TokenImpersonationLevel requiredImpersonationLevel) { throw null; }
        public virtual System.Threading.Tasks.Task AuthenticateAsServerAsync(System.Net.NetworkCredential credential, System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy policy, System.Net.Security.ProtectionLevel requiredProtectionLevel, System.Security.Principal.TokenImpersonationLevel requiredImpersonationLevel) { throw null; }
        public virtual System.Threading.Tasks.Task AuthenticateAsServerAsync(System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy policy) { throw null; }
        public override void Flush() { }
        public override int Read(byte[] buffer, int offset, int count) { throw null; }
        public override long Seek(long offset, System.IO.SeekOrigin origin) { throw null; }
        public override void SetLength(long value) { }
        public override void Write(byte[] buffer, int offset, int count) { }
    }
    public enum ProtectionLevel
    {
        EncryptAndSign = 2,
        None = 0,
        Sign = 1,
    }
    public delegate bool RemoteCertificateValidationCallback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors);
    public partial class SslStream : System.Net.Security.AuthenticatedStream
    {
        public SslStream(System.IO.Stream innerStream) : base (default(System.IO.Stream), default(bool)) { }
        public SslStream(System.IO.Stream innerStream, bool leaveInnerStreamOpen) : base (default(System.IO.Stream), default(bool)) { }
        public SslStream(System.IO.Stream innerStream, bool leaveInnerStreamOpen, System.Net.Security.RemoteCertificateValidationCallback userCertificateValidationCallback) : base (default(System.IO.Stream), default(bool)) { }
        public SslStream(System.IO.Stream innerStream, bool leaveInnerStreamOpen, System.Net.Security.RemoteCertificateValidationCallback userCertificateValidationCallback, System.Net.Security.LocalCertificateSelectionCallback userCertificateSelectionCallback) : base (default(System.IO.Stream), default(bool)) { }
        public SslStream(System.IO.Stream innerStream, bool leaveInnerStreamOpen, System.Net.Security.RemoteCertificateValidationCallback userCertificateValidationCallback, System.Net.Security.LocalCertificateSelectionCallback userCertificateSelectionCallback, System.Net.Security.EncryptionPolicy encryptionPolicy) : base (default(System.IO.Stream), default(bool)) { }
        public override bool CanRead { get { throw null; } }
        public override bool CanSeek { get { throw null; } }
        public override bool CanTimeout { get { throw null; } }
        public override bool CanWrite { get { throw null; } }
        public virtual bool CheckCertRevocationStatus { get { throw null; } }
        public virtual System.Security.Authentication.CipherAlgorithmType CipherAlgorithm { get { throw null; } }
        public virtual int CipherStrength { get { throw null; } }
        public virtual System.Security.Authentication.HashAlgorithmType HashAlgorithm { get { throw null; } }
        public virtual int HashStrength { get { throw null; } }
        public override bool IsAuthenticated { get { throw null; } }
        public override bool IsEncrypted { get { throw null; } }
        public override bool IsMutuallyAuthenticated { get { throw null; } }
        public override bool IsServer { get { throw null; } }
        public override bool IsSigned { get { throw null; } }
        public virtual System.Security.Authentication.ExchangeAlgorithmType KeyExchangeAlgorithm { get { throw null; } }
        public virtual int KeyExchangeStrength { get { throw null; } }
        public override long Length { get { throw null; } }
        public virtual System.Security.Cryptography.X509Certificates.X509Certificate LocalCertificate { get { throw null; } }
        public override long Position { get { throw null; } set { } }
        public override int ReadTimeout { get { throw null; } set { } }
        public virtual System.Security.Cryptography.X509Certificates.X509Certificate RemoteCertificate { get { throw null; } }
        public virtual System.Security.Authentication.SslProtocols SslProtocol { get { throw null; } }
        public System.Net.TransportContext TransportContext { get { throw null; } }
        public override int WriteTimeout { get { throw null; } set { } }
        public virtual System.Threading.Tasks.Task AuthenticateAsClientAsync(string targetHost) { throw null; }
        public virtual System.Threading.Tasks.Task AuthenticateAsClientAsync(string targetHost, System.Security.Cryptography.X509Certificates.X509CertificateCollection clientCertificates, System.Security.Authentication.SslProtocols enabledSslProtocols, bool checkCertificateRevocation) { throw null; }
        public virtual System.Threading.Tasks.Task AuthenticateAsServerAsync(System.Security.Cryptography.X509Certificates.X509Certificate serverCertificate) { throw null; }
        public virtual System.Threading.Tasks.Task AuthenticateAsServerAsync(System.Security.Cryptography.X509Certificates.X509Certificate serverCertificate, bool clientCertificateRequired, System.Security.Authentication.SslProtocols enabledSslProtocols, bool checkCertificateRevocation) { throw null; }
        public override void Flush() { }
        public override int Read(byte[] buffer, int offset, int count) { throw null; }
        public override long Seek(long offset, System.IO.SeekOrigin origin) { throw null; }
        public override void SetLength(long value) { }
        public void Write(byte[] buffer) { }
        public override void Write(byte[] buffer, int offset, int count) { }
    }
}
namespace System.Security.Authentication
{
    public partial class AuthenticationException : System.Exception
    {
        public AuthenticationException() { }
        public AuthenticationException(string message) { }
        public AuthenticationException(string message, System.Exception innerException) { }
    }
    public partial class InvalidCredentialException : System.Security.Authentication.AuthenticationException
    {
        public InvalidCredentialException() { }
        public InvalidCredentialException(string message) { }
        public InvalidCredentialException(string message, System.Exception innerException) { }
    }
}
namespace System.Security.Authentication.ExtendedProtection
{
    public partial class ExtendedProtectionPolicy
    {
        public ExtendedProtectionPolicy(System.Security.Authentication.ExtendedProtection.PolicyEnforcement policyEnforcement) { }
        public ExtendedProtectionPolicy(System.Security.Authentication.ExtendedProtection.PolicyEnforcement policyEnforcement, System.Security.Authentication.ExtendedProtection.ChannelBinding customChannelBinding) { }
        public ExtendedProtectionPolicy(System.Security.Authentication.ExtendedProtection.PolicyEnforcement policyEnforcement, System.Security.Authentication.ExtendedProtection.ProtectionScenario protectionScenario, System.Collections.ICollection customServiceNames) { }
        public ExtendedProtectionPolicy(System.Security.Authentication.ExtendedProtection.PolicyEnforcement policyEnforcement, System.Security.Authentication.ExtendedProtection.ProtectionScenario protectionScenario, System.Security.Authentication.ExtendedProtection.ServiceNameCollection customServiceNames) { }
        public System.Security.Authentication.ExtendedProtection.ChannelBinding CustomChannelBinding { get { throw null; } }
        public System.Security.Authentication.ExtendedProtection.ServiceNameCollection CustomServiceNames { get { throw null; } }
        public static bool OSSupportsExtendedProtection { get { throw null; } }
        public System.Security.Authentication.ExtendedProtection.PolicyEnforcement PolicyEnforcement { get { throw null; } }
        public System.Security.Authentication.ExtendedProtection.ProtectionScenario ProtectionScenario { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public enum PolicyEnforcement
    {
        Always = 2,
        Never = 0,
        WhenSupported = 1,
    }
    public enum ProtectionScenario
    {
        TransportSelected = 0,
        TrustedProxy = 1,
    }
    public partial class ServiceNameCollection : System.Collections.ICollection, System.Collections.IEnumerable
    {
        public ServiceNameCollection(System.Collections.ICollection items) { }
        public int Count { get { throw null; } }
        bool System.Collections.ICollection.IsSynchronized { get { throw null; } }
        object System.Collections.ICollection.SyncRoot { get { throw null; } }
        public bool Contains(string searchServiceName) { throw null; }
        public System.Collections.IEnumerator GetEnumerator() { throw null; }
        public System.Security.Authentication.ExtendedProtection.ServiceNameCollection Merge(System.Collections.IEnumerable serviceNames) { throw null; }
        public System.Security.Authentication.ExtendedProtection.ServiceNameCollection Merge(string serviceName) { throw null; }
        void System.Collections.ICollection.CopyTo(System.Array array, int index) { }
    }
}
