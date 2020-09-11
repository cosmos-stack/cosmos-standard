using System;
using System.Text;

namespace Cosmos.Text
{
    public static class StringBytesExtensions
    {
        #region String to Bytes

        /// <summary>
        /// Convert string to byte array
        /// </summary>
        /// <param name="value"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string value, Encoding encoding = null)
        {
            return value is null
                ? throw new ArgumentNullException(nameof(value))
                : (encoding ?? Encoding.UTF8).GetBytes(value);
        }

        /// <summary>
        /// Convert string to byte array by utf8
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToUtf8Bytes(this string value)
        {
            return value.ToBytes(Encoding.UTF8);
        }

        /// <summary>
        /// Convert string to byte array by utf7
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToUtf7Bytes(this string value)
        {
            return value.ToBytes(Encoding.UTF7);
        }

        /// <summary>
        /// Convert string to byte array by utf32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToUtf32Bytes(this string value)
        {
            return value.ToBytes(Encoding.UTF32);
        }

        /// <summary>
        /// Convert string to byte array by ASCII
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static byte[] ToASCIIBytes(this string value)
        {
            return value.ToBytes(Encoding.ASCII);
        }

        /// <summary>
        /// Convert string to byte array by BigEndian Unicode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToBigEndianUnicodeBytes(this string value)
        {
            return value.ToBytes(Encoding.BigEndianUnicode);
        }

        /// <summary>
        /// Convert string to byte array by default
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToDefaultBytes(this string value)
        {
            return value.ToBytes(Encoding.Default);
        }

        /// <summary>
        /// Convert string to byte array by unicode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToUnicodeBytes(this string value)
        {
            return value.ToBytes(Encoding.Unicode);
        }

        #endregion

        #region Bytes to String

        /// <summary>
        /// Convert byte array to string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetString(this byte[] bytes, Encoding encoding = null)
        {
            return bytes is null ? throw new ArgumentNullException(nameof(bytes)) : (encoding ?? Encoding.UTF8).GetString(bytes);
        }

        /// <summary>
        /// Convert byte array to string by Utf8
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringByUtf8(this byte[] bytes)
        {
            return bytes.GetString(Encoding.UTF8);
        }

        /// <summary>
        /// Convert byte array to string by Utf7
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringByUtf7(this byte[] bytes)
        {
            return bytes.GetString(Encoding.UTF7);
        }

        /// <summary>
        /// Convert byte array to string by Utf32
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringByUtf32(this byte[] bytes)
        {
            return bytes.GetString(Encoding.UTF32);
        }

        /// <summary>
        /// Convert byte array to string by ASCII
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static string GetStringByASCII(this byte[] bytes)
        {
            return bytes.GetString(Encoding.ASCII);
        }

        /// <summary>
        /// Convert byte array to string by BigEndian unicode
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringByBigEndianUnicode(this byte[] bytes)
        {
            return bytes.GetString(Encoding.BigEndianUnicode);
        }

        /// <summary>
        /// Convert byte array to string by default
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringByDefault(this byte[] bytes)
        {
            return bytes.GetString(Encoding.Default);
        }

        /// <summary>
        /// Convert byte array to string by Unicode
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringByUnicode(this byte[] bytes)
        {
            return bytes.GetString(Encoding.Unicode);
        }

        #endregion
    }
}