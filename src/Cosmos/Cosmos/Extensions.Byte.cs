using System;
using System.IO;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Byte extensions
    /// </summary>
    public static class ByteExtensions
    {
        #region Encoding

        /// <summary>
        /// Convert byte array to string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetString(this byte[] bytes, Encoding encoding = null) =>
            bytes is null ? throw new ArgumentNullException(nameof(bytes)) : (encoding ?? Encoding.UTF8).GetString(bytes);

        /// <summary>
        /// Convert byte array to string by Utf8
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringByUtf8(this byte[] bytes) => bytes.GetString(Encoding.UTF8);

        /// <summary>
        /// Convert byte array to string by Utf7
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringByUtf7(this byte[] bytes) => bytes.GetString(Encoding.UTF7);

        /// <summary>
        /// Convert byte array to string by Utf32
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringByUtf32(this byte[] bytes) => bytes.GetString(Encoding.UTF32);

        /// <summary>
        /// Convert byte array to string by ASCII
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static string GetStringByASCII(this byte[] bytes) => bytes.GetString(Encoding.ASCII);

        /// <summary>
        /// Convert byte array to string by BigEndian unicode
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringByBigEndianUnicode(this byte[] bytes) => bytes.GetString(Encoding.BigEndianUnicode);

        /// <summary>
        /// Convert byte array to string by default
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringByDefault(this byte[] bytes) => bytes.GetString(Encoding.Default);

        /// <summary>
        /// Convert byte array to string by Unicode
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringByUnicode(this byte[] bytes) => bytes.GetString(Encoding.Unicode);

        /// <summary>
        /// Convert normal byte normal to base64 byte array
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] ToBase64Bytes(this byte[] bytes, Encoding encoding = null) => bytes.ToBase64String().ToBytes(encoding);

        /// <summary>
        /// Convert base64 byte array to normal byte array
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] DecodeBase64ToBytes(this byte[] bytes, Encoding encoding = null) => bytes.GetString(encoding).FromBase64StringToBytes();

        /// <summary>
        /// Convert base64 byte array to normal string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string DecodeBase64ToString(this byte[] bytes, Encoding encoding = null) => bytes.GetString(encoding).FromBase64String();

        #endregion

        #region Min & Max

        /// <summary>
        /// Gets max one.
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static byte Max(this byte val1, byte val2) => Math.Max(val1, val2);

        /// <summary>
        /// Gets min one.
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static byte Min(this byte val1, byte val2) => Math.Min(val1, val2);

        #endregion

        #region Resize

        /// <summary>
        /// Resize
        /// </summary>
        /// <param name="this"></param>
        /// <param name="newSize"></param>
        /// <returns></returns>
        public static byte[] Resize(this byte[] @this, int newSize)
        {
            Array.Resize(ref @this, newSize);
            return @this;
        }

        #endregion

        #region To Base64

        /// <summary>
        /// To base64 char array
        /// </summary>
        /// <param name="inArray"></param>
        /// <param name="offsetIn"></param>
        /// <param name="length"></param>
        /// <param name="outArray"></param>
        /// <param name="offsetOut"></param>
        /// <returns></returns>
        public static int ToBase64CharArray(this byte[] inArray, int offsetIn, int length, char[] outArray, int offsetOut) =>
            Convert.ToBase64CharArray(inArray, offsetIn, length, outArray, offsetOut);

        /// <summary>
        /// To base64 char array
        /// </summary>
        /// <param name="inArray"></param>
        /// <param name="offsetIn"></param>
        /// <param name="length"></param>
        /// <param name="outArray"></param>
        /// <param name="offsetOut"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static int ToBase64CharArray(this byte[] inArray, int offsetIn, int length, char[] outArray, int offsetOut, Base64FormattingOptions options) =>
            Convert.ToBase64CharArray(inArray, offsetIn, length, outArray, offsetOut, options);

        /// <summary>
        /// Convert byte[] to base64 string
        /// </summary>
        /// <param name="inArray"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] inArray) =>
            Base64Converter.ToBase64String(inArray);

        /// <summary>
        /// Convert byte[] to base64 string
        /// </summary>
        /// <param name="inArray"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] inArray, Base64FormattingOptions options) =>
            Convert.ToBase64String(inArray, options);

        /// <summary>
        /// Convert byte[] to base64 string
        /// </summary>
        /// <param name="inArray"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] inArray, int offset, int length) =>
            Convert.ToBase64String(inArray, offset, length);

        /// <summary>
        /// Convert byte[] to base64 string.
        /// </summary>
        /// <param name="inArray"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] inArray, int offset, int length, Base64FormattingOptions options) =>
            Convert.ToBase64String(inArray, offset, length, options);

        #endregion

        #region To MemoryStream

        /// <summary>
        /// Convert byte[] to <see cref="MemoryStream"/>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(this byte[] @this) =>
            new MemoryStream(@this);

        #endregion
    }
}