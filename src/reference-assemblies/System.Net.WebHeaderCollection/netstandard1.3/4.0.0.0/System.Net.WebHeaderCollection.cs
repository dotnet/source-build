[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Net.WebHeaderCollection")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Net.WebHeaderCollection")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Net.WebHeaderCollection")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Net
{
    public enum HttpRequestHeader
    {
        Accept = 20,
        AcceptCharset = 21,
        AcceptEncoding = 22,
        AcceptLanguage = 23,
        Allow = 10,
        Authorization = 24,
        CacheControl = 0,
        Connection = 1,
        ContentEncoding = 13,
        ContentLanguage = 14,
        ContentLength = 11,
        ContentLocation = 15,
        ContentMd5 = 16,
        ContentRange = 17,
        ContentType = 12,
        Cookie = 25,
        Date = 2,
        Expect = 26,
        Expires = 18,
        From = 27,
        Host = 28,
        IfMatch = 29,
        IfModifiedSince = 30,
        IfNoneMatch = 31,
        IfRange = 32,
        IfUnmodifiedSince = 33,
        KeepAlive = 3,
        LastModified = 19,
        MaxForwards = 34,
        Pragma = 4,
        ProxyAuthorization = 35,
        Range = 37,
        Referer = 36,
        Te = 38,
        Trailer = 5,
        TransferEncoding = 6,
        Translate = 39,
        Upgrade = 7,
        UserAgent = 40,
        Via = 8,
        Warning = 9,
    }
    public enum HttpResponseHeader
    {
        AcceptRanges = 20,
        Age = 21,
        Allow = 10,
        CacheControl = 0,
        Connection = 1,
        ContentEncoding = 13,
        ContentLanguage = 14,
        ContentLength = 11,
        ContentLocation = 15,
        ContentMd5 = 16,
        ContentRange = 17,
        ContentType = 12,
        Date = 2,
        ETag = 22,
        Expires = 18,
        KeepAlive = 3,
        LastModified = 19,
        Location = 23,
        Pragma = 4,
        ProxyAuthenticate = 24,
        RetryAfter = 25,
        Server = 26,
        SetCookie = 27,
        Trailer = 5,
        TransferEncoding = 6,
        Upgrade = 7,
        Vary = 28,
        Via = 8,
        Warning = 9,
        WwwAuthenticate = 29,
    }
    public sealed partial class WebHeaderCollection : System.Collections.IEnumerable
    {
        public WebHeaderCollection() { }
        public string[] AllKeys { get { throw null; } }
        public int Count { get { throw null; } }
        public string this[System.Net.HttpRequestHeader header] { get { throw null; } set { } }
        public string this[System.Net.HttpResponseHeader header] { get { throw null; } set { } }
        public string this[string name] { get { throw null; } set { } }
        public void Remove(string name) { }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public override string ToString() { throw null; }
    }
}
