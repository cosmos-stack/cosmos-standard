using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Hexadecimal Conversion Utilities
    /// </summary>
    public static class HexadecimalConv
    {
        /// <summary>
        /// Convert from hexadecimal to decimalism.
        /// </summary>
        /// <example>in: 2E; out: 46</example>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static int ToDecimalism(string hex) => Convert.ToInt32(hex, 16);

        /// <summary>
        /// Convert from hexadecimal to binary.
        /// </summary>
        /// <example>in: 2E; out: 101110</example>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string ToBinary(string hex) => DecimalismConv.ToBinary(ToDecimalism(hex));

        /// <summary>
        /// Convert from hexadecimal to bytes.
        /// </summary>
        /// <example>in: 2E3D; out: result[0] is 46, result[1] is 61</example>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] ToBytes(string hex)
        {
            var mc = Regex.Matches(hex, @"(?i)[\da-f]{2}");
            return (from Match m in mc select Convert.ToByte(m.Value, 16)).ToArray();
        }

        /// <summary>
        /// Convert from hexadecimal to <see cref="string"/>.
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToString(string hex, Encoding encoding = null)
        {
            hex = hex.Replace(" ", "");
            if (string.IsNullOrWhiteSpace(hex))
            {
                return "";
            }

            var bytes = new byte[hex.Length / 2];
            for (var i = 0; i < hex.Length; i += 2)
            {
                if (!byte.TryParse(hex.Substring(i, 2), NumberStyles.HexNumber, null, out bytes[i / 2]))
                {
                    bytes[i / 2] = 0;
                }
            }

            return encoding.SafeValue().GetString(bytes);
        }

        /// <summary>
        /// Convert from <see cref="string"/> to hexadecimal.
        /// </summary>
        /// <example>in: A; out: 1000001</example>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromString(string str, Encoding encoding = null)
            => BitConverter.ToString(encoding.SafeValue().GetBytes(str)).Replace("-", " ");

        private static Encoding SafeValue(this Encoding encoding) => encoding ?? Encoding.UTF8;
    }
}