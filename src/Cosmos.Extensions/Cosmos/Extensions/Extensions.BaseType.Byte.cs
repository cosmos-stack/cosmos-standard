using System;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    public static partial class BaseTypeExtensions {
        /// <summary>
        /// Convert byte array to string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetString(this byte[] bytes, Encoding encoding = null) =>
            bytes is null ? throw new ArgumentNullException(nameof(bytes)) : encoding.Fixed().GetString(bytes);

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
        public static byte[] ToBase64Bytes(this byte[] bytes, Encoding encoding = null) 
            => bytes.ToBase64String().ToBytes(encoding);

        /// <summary>
        /// Convert base64 byte array to normal byte array
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] DecodeBase64ToBytes(this byte[] bytes, Encoding encoding = null)
            => bytes.GetString(encoding).FromBase64StringToBytes();

        /// <summary>
        /// Convert base64 byte array to normal string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string DecodeBase64ToString(this byte[] bytes, Encoding encoding = null)
            => bytes.GetString(encoding).FromBase64String();
    }
}