using System.Runtime.CompilerServices;
using System.Text;
using CosmosStack.Conversions.Helpers;

namespace CosmosStack.Conversions
{
    /// <summary>
    /// Hex Utilities <br />
    /// 十六进制工具
    /// </summary>
    public static class Hex
    {
        /// <summary>
        /// Byte array to hex string <br />
        /// 将字节数组转换为十六进制字符串
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
        /// Hex string to byte <br />
        /// 将十六进制字符串转换为字节数组
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
        /// Reverse high and low positions. <br />
        /// 高低位交换
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
    /// Hex extensions <br />
    /// 十六进制工具扩展
    /// </summary>
    public static class HexExtensions
    {
        /// <summary>
        /// Byte array to hex string <br />
        /// 将字节数组转换为十六进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToHexString(this byte[] bytes) => Hex.ToString(bytes);

        /// <summary>
        /// Hex string to byte <br />
        /// 将十六进制字符串转换为字节数组
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this string hex) => Hex.ToBytes(hex);
    }
}