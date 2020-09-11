using System;
using System.Text;
using Cosmos.Conversions;

namespace Cosmos.Text
{
    public static class ByteBase64Extensions
    {
        /// <summary>
        /// Convert normal byte normal to base64 byte array
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] ToBase64Bytes(this byte[] bytes, Encoding encoding = null)
        {
            return bytes.ToBase64String().ToBytes(encoding);
        }

        /// <summary>
        /// To base64 char array
        /// </summary>
        /// <param name="inArray"></param>
        /// <param name="offsetIn"></param>
        /// <param name="length"></param>
        /// <param name="outArray"></param>
        /// <param name="offsetOut"></param>
        /// <returns></returns>
        public static int ToBase64CharArray(this byte[] inArray, int offsetIn, int length, char[] outArray, int offsetOut)
        {
            return Convert.ToBase64CharArray(inArray, offsetIn, length, outArray, offsetOut);
        }

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
        public static int ToBase64CharArray(this byte[] inArray, int offsetIn, int length, char[] outArray, int offsetOut, Base64FormattingOptions options)
        {
            return Convert.ToBase64CharArray(inArray, offsetIn, length, outArray, offsetOut, options);
        }

        /// <summary>
        /// Convert byte[] to base64 string
        /// </summary>
        /// <param name="inArray"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] inArray)
        {
            return Base64Conv.ToBase64String(inArray);
        }

        /// <summary>
        /// Convert byte[] to base64 string
        /// </summary>
        /// <param name="inArray"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] inArray, Base64FormattingOptions options)
        {
            return Convert.ToBase64String(inArray, options);
        }

        /// <summary>
        /// Convert byte[] to base64 string
        /// </summary>
        /// <param name="inArray"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] inArray, int offset, int length)
        {
            return Convert.ToBase64String(inArray, offset, length);
        }

        /// <summary>
        /// Convert byte[] to base64 string.
        /// </summary>
        /// <param name="inArray"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] inArray, int offset, int length, Base64FormattingOptions options)
        {
            return Convert.ToBase64String(inArray, offset, length, options);
        }
    }
}