using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    public static partial class StringExtensions {
        /// <summary>
        /// Convert string to byte array
        /// </summary>
        /// <param name="value"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string value, Encoding encoding = null) =>
            value is null
                ? throw new ArgumentNullException(nameof(value))
                : encoding.Fixed().GetBytes(value);

        /// <summary>
        /// Convert string to byte array by utf8
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToUtf8Bytes(this string value) => value.ToBytes(Encoding.UTF8);

        /// <summary>
        /// Convert string to byte array by utf7
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToUtf7Bytes(this string value) => value.ToBytes(Encoding.UTF7);

        /// <summary>
        /// Convert string to byte array by utf32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToUtf32Bytes(this string value) => value.ToBytes(Encoding.UTF32);

        /// <summary>
        /// Convert string to byte array by ASCII
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static byte[] ToASCIIBytes(this string value) => value.ToBytes(Encoding.ASCII);

        /// <summary>
        /// Convert string to byte array by BigEndian Unicode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToBigEndianUnicodeBytes(this string value) => value.ToBytes(Encoding.BigEndianUnicode);

        /// <summary>
        /// Convert string to byte array by default
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToDefaultBytes(this string value) => value.ToBytes(Encoding.Default);

        /// <summary>
        /// Convert string to byte array by unicode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToUnicodeBytes(this string value) => value.ToBytes(Encoding.Unicode);
    }
}