using System;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Conversions.Scale;
using Cosmos.Conversions.StringDeterminers;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// Conversion extensions
    /// </summary>
    public static partial class ConversionExtensions {
        /// <summary>
        /// To ASCII
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static string CastToASCII(this byte[] bytes)
            => ByteConverter.ToASCII(bytes);

        /// <summary>
        /// Convert char to ascii value
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static int CastToASCII(this char c) {
            int num;
            var num2 = Convert.ToInt32(c);
            if (num2 < 0x80) {
                return num2;
            }

            byte[] buffer;
            // ReSharper disable once InconsistentNaming
            var fileIOEncoding = Encoding.UTF8;

            char[] chars = {c};
            if (fileIOEncoding.GetMaxByteCount(1) == 1) {
                buffer = new byte[1];
                var num3 = fileIOEncoding.GetBytes(chars, 0, 1, buffer, 0);
                return buffer[0];
            }

            buffer = new byte[2];
            if (fileIOEncoding.GetBytes(chars, 0, 1, buffer, 0) == 1) {
                return buffer[0];
            }

            if (BitConverter.IsLittleEndian) {
                byte num4 = buffer[0];
                buffer[0] = buffer[1];
                buffer[1] = num4;
            }

            num = BitConverter.ToInt16(buffer, 0);

            return num;
        }

        /// <summary>
        /// To binary
        /// </summary>
        /// <param name="byte"></param>
        /// <returns></returns>
        public static string CastToBinary(this byte @byte)
            => ByteConverter.ToBinary(@byte);

        /// <summary>
        /// To binary
        /// </summary>
        /// <param name="decimal"></param>
        /// <returns></returns>
        public static string CastToBinary(this int @decimal)
            => DecimalismConverter.ToBinary(@decimal);

        /// <summary>
        /// To binary
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string CastToBinary(this string hex)
            => HexadecimalConverter.ToBinary(hex);

        /// <summary>
        /// To decimalism
        /// </summary>
        /// <param name="highAddrByte"></param>
        /// <param name="lowAddrByte"></param>
        /// <returns></returns>
        public static int CastToDecimalism(this byte highAddrByte, byte lowAddrByte)
            => ByteConverter.ToDecimalism(highAddrByte, lowAddrByte);

        /// <summary>
        /// To decimalism
        /// </summary>
        /// <param name="highAddrByte"></param>
        /// <param name="lowAddrByte"></param>
        /// <param name="isRadix"></param>
        /// <returns></returns>
        public static int CastToDecimalism(this byte highAddrByte, byte lowAddrByte, bool isRadix)
            => ByteConverter.ToDecimalism(highAddrByte, lowAddrByte, isRadix);

        /// <summary>
        /// To decimalism
        /// </summary>
        /// <param name="scaleStr"></param>
        /// <param name="fromStyle"></param>
        /// <returns></returns>
        public static int CastToDecimalism(this string scaleStr, ScaleStyles fromStyle = ScaleStyles.Hexadecimal) {
            return fromStyle switch {
                ScaleStyles.Binary      => BinaryConverter.ToDecimalism(scaleStr),
                ScaleStyles.Hexadecimal => HexadecimalConverter.ToDecimalism(scaleStr),
                _                       => StringIntDeterminer.To(scaleStr)
            };
        }

        /// <summary>
        /// To hexadecimal
        /// </summary>
        /// <param name="byte"></param>
        /// <returns></returns>
        public static string CastToHexadecimal(this byte @byte)
            => ByteConverter.ToHexadecimal(@byte);

        /// <summary>
        /// To hexadecimal
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string CastToHexadecimal(this byte[] bytes)
            => ByteConverter.ToHexadecimal(bytes);

        /// <summary>
        /// To hexadecimal
        /// </summary>
        /// <param name="highAddrByte"></param>
        /// <param name="lowAddrByte"></param>
        /// <returns></returns>
        public static string CastToHexadecimal(this byte highAddrByte, byte lowAddrByte)
            => ByteConverter.ToHexadecimal(highAddrByte, lowAddrByte);

        /// <summary>
        /// To hexadecimal
        /// </summary>
        /// <param name="decimal"></param>
        /// <returns></returns>
        public static string CastToHexadecimal(this int @decimal)
            => DecimalismConverter.ToHexadecimal(@decimal);

        /// <summary>
        /// To hexadecimal
        /// </summary>
        /// <param name="decimal"></param>
        /// <param name="formatLength"></param>
        /// <returns></returns>
        public static string CastToHexadecimal(this int @decimal, int formatLength)
            => DecimalismConverter.ToHexadecimal(@decimal, formatLength);

        /// <summary>
        /// To hexadecimal
        /// </summary>
        /// <param name="scaleStr"></param>
        /// <param name="fromStyle"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string CastToHexadecimal(this string scaleStr, ScaleStyles fromStyle = ScaleStyles.Binary, Encoding encoding = null) {
            return fromStyle switch {
                ScaleStyles.Binary => BinaryConverter.ToHexadecimal(scaleStr),
                ScaleStyles.String => HexadecimalConverter.FromString(scaleStr, encoding),
                _                  => scaleStr
            };
        }
    }
}