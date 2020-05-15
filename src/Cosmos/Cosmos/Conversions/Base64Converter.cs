using System;
using System.Text;

namespace Cosmos.Conversions {
    /// <summary>
    /// Base64 Conversion Utilities
    /// </summary>
    public static class Base64Conversion {
        // ReSharper disable once InconsistentNaming
        private const string BASE64 = "===========================================+=+=/0123456789=======ABCDEFGHIJKLMNOPQRSTUVWXYZ====/=abcdefghijklmnopqrstuvwxyz=====";

        /// <summary>
        /// Convert from <see cref="string"/> to base64 <see cref="string"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase64String(string str, Encoding encoding = null) =>
            ToBase64String(encoding.SafeValue().GetBytes(str));

        /// <summary>
        /// Convert from <see cref="string"/> to base64 <see cref="string"/>.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBase64String(byte[] bytes) =>
            Convert.ToBase64String(bytes);

        /// <summary>
        /// Convert from base64 <see cref="string"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="base64String"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase64String(string base64String, Encoding encoding = null) =>
            encoding.SafeValue().GetString(FromBase64StringToBytes(base64String));

        /// <summary>
        /// Convert from base64 <see cref="string"/> to <see cref="byte"/> array.
        /// </summary>
        /// <param name="base64String"></param>
        public static byte[] FromBase64StringToBytes(string base64String) =>
            Convert.FromBase64String(base64String);

        /// <summary>
        /// Convert from <see cref="string"/> to base64url <see cref="string"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase64UrlString(string str, Encoding encoding = null) =>
            ToBase64UrlString(encoding.SafeValue().GetBytes(str));

        /// <summary>
        /// Convert from <see cref="string"/> to base64url <see cref="string"/>.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBase64UrlString(byte[] bytes) =>
            new StringBuilder(Convert.ToBase64String(bytes).TrimEnd('=')).Replace('+', '-').Replace('/', '_').ToString();

        /// <summary>
        /// Convert from base64url <see cref="string"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="base64UrlString"></param>
        /// <param name="encoding"></param>
        public static string FromBase64UrlString(string base64UrlString, Encoding encoding = null)
            => encoding.SafeValue().GetString(FromBase64UrlStringToBytes(base64UrlString));

        /// <summary>
        /// Convert from base64url <see cref="string"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="base64UrlString"></param>
        public static byte[] FromBase64UrlStringToBytes(string base64UrlString) {
            var sb = new StringBuilder();
            foreach (var c in base64UrlString) {
                if (c >= 128) continue;
                var k = BASE64[c];
                if (k == '=') continue;
                sb.Append(k);
            }

            var len = sb.Length;
            var padChars = (len % 4) == 0 ? 0 : (4 - (len % 4));
            if (padChars > 0) sb.Append(string.Empty.PadRight(padChars, '='));
            return Convert.FromBase64String(sb.ToString());
        }

        private static Encoding SafeValue(this Encoding encoding) => encoding ?? Encoding.UTF8;
    }
}