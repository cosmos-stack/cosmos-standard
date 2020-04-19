using System.Text;
using Cosmos.Conversions;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    public static partial class StringExtensions {
        /// <summary>
        /// Convert from base64 <see cref="string"/> to <see cref="byte"/> array.
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static byte[] FromBase64StringToBytes(this string base64String) => Base64Conversion.FromBase64StringToBytes(base64String);

        /// <summary>
        /// Convert from base64 <see cref="string"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="base64String"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase64String(this string base64String, Encoding encoding = null) => Base64Conversion.FromBase64String(base64String, encoding);
    }
}