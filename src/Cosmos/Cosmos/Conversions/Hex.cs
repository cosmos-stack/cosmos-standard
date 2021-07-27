using System.Runtime.CompilerServices;
using System.Text;
using Cosmos.Conversions.Helpers;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Hex Utilities
    /// </summary>
    public static class Hex
    {
        /// <summary>
        /// Byte array to hex string extension
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToString(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 3);
            for (var i = 0; i < bytes.Length; i++)
                sb.Append(bytes[i].ToString("X2"));
            return sb.ToString();
        }

        /// <summary>
        /// Hex string to byte extension
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] ToBytes(string hex)
        {
            if (hex.Length == 0)
                return new byte[] {0};

            if (hex.Length % 2 == 1)
                hex = "0" + hex;

            var result = new byte[hex.Length / 2];
            for (var i = 0; i < hex.Length / 2; i++)
                result[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);

            return result;
        }

        /// <summary>
        /// Reverse high and low positions.
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Reverse(string hex)
        {
            return ScaleRevHelper.Reverse(hex, 2);
        }
    }

    /// <summary>
    /// Hex extensions
    /// </summary>
    public static class HexExtensions
    {
        /// <summary>
        /// Byte array to hex string extension
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToHexString(this byte[] bytes) => Hex.ToString(bytes);

        /// <summary>
        /// Hex string to byte extension
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this string hex) => Hex.ToBytes(hex);
    }
}