using System.Text;
using Cosmos.Conversions.Determiners;
using Cosmos.Conversions.Scale;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Cosmos scale extensions
    /// </summary>
    public static class CosmosScaleExtensions
    {
        /// <summary>
        /// To ASCII
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static string CastToASCII(this byte[] bytes) => ByteConverter.ToASCII(bytes);

        /// <summary>
        /// To binary
        /// </summary>
        /// <param name="byte"></param>
        /// <returns></returns>
        public static string CastToBinary(this byte @byte) => ByteConverter.ToBinary(@byte);

        /// <summary>
        /// To binary
        /// </summary>
        /// <param name="decimal"></param>
        /// <returns></returns>
        public static string CastToBinary(this int @decimal) => DecimalismConverter.ToBinary(@decimal);

        /// <summary>
        /// Convert the hexadecimal value to binary. <br />
        /// 将十六进制值转换为二进制。
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string CastToBinary(this string hex) => HexadecimalConverter.ToBinary(hex);

        /// <summary>
        /// Convert the Byte value of the upper address and status address to decimal values. <br />
        /// 将高位地址和地位地址的 Byte 值转换为十进制值。
        /// </summary>
        /// <param name="highAddrByte"></param>
        /// <param name="lowAddrByte"></param>
        /// <returns></returns>
        public static int CastToDecimalism(this byte highAddrByte, byte lowAddrByte) => ByteConverter.ToDecimalism(highAddrByte, lowAddrByte);

        /// <summary>
        /// Convert the Byte value of the upper address and status address to decimal values. <br />
        /// 将高位地址和地位地址的 Byte 值转换为十进制值。
        /// </summary>
        /// <param name="highAddrByte"></param>
        /// <param name="lowAddrByte"></param>
        /// <param name="isRadix"></param>
        /// <returns></returns>
        public static int CastToDecimalism(this byte highAddrByte, byte lowAddrByte, bool isRadix) => ByteConverter.ToDecimalism(highAddrByte, lowAddrByte, isRadix);

        /// <summary>
        /// Convert the value of the given base to decimal. <br />
        /// 将给定进制的值转换为十进制。
        /// </summary>
        /// <param name="scaleStr"></param>
        /// <param name="fromStyle"></param>
        /// <returns></returns>
        public static int CastToDecimalism(this string scaleStr, ScaleStyles fromStyle = ScaleStyles.Hexadecimal)
        {
            return fromStyle switch
            {
                ScaleStyles.Binary => BinaryConverter.ToDecimalism(scaleStr),
                ScaleStyles.Hexadecimal => HexadecimalConverter.ToDecimalism(scaleStr),
                _ => StringIntDeterminer.To(scaleStr)
            };
        }

        /// <summary>
        /// To hexadecimal
        /// </summary>
        /// <param name="byte"></param>
        /// <returns></returns>
        public static string CastToHexadecimal(this byte @byte) => ByteConverter.ToHexadecimal(@byte);

        /// <summary>
        /// To hexadecimal
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string CastToHexadecimal(this byte[] bytes) => ByteConverter.ToHexadecimal(bytes);

        /// <summary>
        /// To hexadecimal
        /// </summary>
        /// <param name="highAddrByte"></param>
        /// <param name="lowAddrByte"></param>
        /// <returns></returns>
        public static string CastToHexadecimal(this byte highAddrByte, byte lowAddrByte) => ByteConverter.ToHexadecimal(highAddrByte, lowAddrByte);

        /// <summary>
        /// To hexadecimal
        /// </summary>
        /// <param name="decimal"></param>
        /// <returns></returns>
        public static string CastToHexadecimal(this int @decimal) => DecimalismConverter.ToHexadecimal(@decimal);

        /// <summary>
        /// To hexadecimal
        /// </summary>
        /// <param name="decimal"></param>
        /// <param name="formatLength"></param>
        /// <returns></returns>
        public static string CastToHexadecimal(this int @decimal, int formatLength) => DecimalismConverter.ToHexadecimal(@decimal, formatLength);

        /// <summary>
        /// To hexadecimal
        /// </summary>
        /// <param name="scaleStr"></param>
        /// <param name="fromStyle"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string CastToHexadecimal(this string scaleStr, ScaleStyles fromStyle = ScaleStyles.Binary, Encoding encoding = null)
        {
            return fromStyle switch
            {
                ScaleStyles.Binary => BinaryConverter.ToHexadecimal(scaleStr),
                ScaleStyles.String => HexadecimalConverter.FromString(scaleStr, encoding),
                _ => scaleStr
            };
        }
    }
}