[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Text.Encoding.dll")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Text.Encoding.dll")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.30319.17929")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.30319.17929")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Text.Encoding.dll")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Text
{
    public abstract partial class Decoder
    {
        protected Decoder() { }
        public virtual void Convert(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed) { bytesUsed = default(int); charsUsed = default(int); completed = default(bool); }
        public abstract int GetCharCount(byte[] bytes, int index, int count);
        public virtual int GetCharCount(byte[] bytes, int index, int count, bool flush) { throw null; }
        public abstract int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
        public virtual int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, bool flush) { throw null; }
        public virtual void Reset() { }
    }
    public sealed partial class DecoderFallbackException : System.ArgumentException
    {
        public DecoderFallbackException() { }
        public DecoderFallbackException(string message) { }
        public DecoderFallbackException(string message, byte[] bytesUnknown, int index) { }
        public DecoderFallbackException(string message, System.Exception innerException) { }
        public byte[] BytesUnknown { get { throw null; } }
        public int Index { get { throw null; } }
    }
    public abstract partial class Encoder
    {
        protected Encoder() { }
        public virtual void Convert(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, int byteCount, bool flush, out int charsUsed, out int bytesUsed, out bool completed) { charsUsed = default(int); bytesUsed = default(int); completed = default(bool); }
        public abstract int GetByteCount(char[] chars, int index, int count, bool flush);
        public abstract int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush);
    }
    public sealed partial class EncoderFallbackException : System.ArgumentException
    {
        public EncoderFallbackException() { }
        public EncoderFallbackException(string message) { }
        public EncoderFallbackException(string message, System.Exception innerException) { }
        public char CharUnknown { get { throw null; } }
        public char CharUnknownHigh { get { throw null; } }
        public char CharUnknownLow { get { throw null; } }
        public int Index { get { throw null; } }
    }
    public abstract partial class Encoding
    {
        protected Encoding() { }
        public static System.Text.Encoding BigEndianUnicode { get { throw null; } }
        public static System.Text.Encoding Unicode { get { throw null; } }
        public static System.Text.Encoding UTF8 { get { throw null; } }
        public virtual string WebName { get { throw null; } }
        public static byte[] Convert(System.Text.Encoding srcEncoding, System.Text.Encoding dstEncoding, byte[] bytes) { throw null; }
        public static byte[] Convert(System.Text.Encoding srcEncoding, System.Text.Encoding dstEncoding, byte[] bytes, int index, int count) { throw null; }
        public override bool Equals(object value) { throw null; }
        public virtual int GetByteCount(char[] chars) { throw null; }
        public abstract int GetByteCount(char[] chars, int index, int count);
        public virtual int GetByteCount(string s) { throw null; }
        public virtual byte[] GetBytes(char[] chars) { throw null; }
        public virtual byte[] GetBytes(char[] chars, int index, int count) { throw null; }
        public abstract int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex);
        public virtual byte[] GetBytes(string s) { throw null; }
        public virtual int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex) { throw null; }
        public virtual int GetCharCount(byte[] bytes) { throw null; }
        public abstract int GetCharCount(byte[] bytes, int index, int count);
        public virtual char[] GetChars(byte[] bytes) { throw null; }
        public virtual char[] GetChars(byte[] bytes, int index, int count) { throw null; }
        public abstract int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
        public virtual System.Text.Decoder GetDecoder() { throw null; }
        public virtual System.Text.Encoder GetEncoder() { throw null; }
        public static System.Text.Encoding GetEncoding(string name) { throw null; }
        public override int GetHashCode() { throw null; }
        public abstract int GetMaxByteCount(int charCount);
        public abstract int GetMaxCharCount(int byteCount);
        public virtual byte[] GetPreamble() { throw null; }
        public virtual string GetString(byte[] bytes, int index, int count) { throw null; }
    }
}
