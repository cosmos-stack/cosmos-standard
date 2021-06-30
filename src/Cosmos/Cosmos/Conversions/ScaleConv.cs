using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Cosmos.Conversions.Helpers;

// ReSharper disable InconsistentNaming

namespace Cosmos.Conversions
{
    /// <summary>
    /// Scale convert utilities
    /// </summary>
    public static class ScaleConv
    {
        /// <summary>
        /// X-2-X convert entry.
        /// </summary>
        /// <param name="things"></param>
        /// <param name="baseOfSource"></param>
        /// <param name="baseOfTarget"></param>
        /// <returns></returns>
        public static string X2X(string things, int baseOfSource, int baseOfTarget)
        {
            return ScaleConvHelper.ThingsToThings(things, baseOfSource, baseOfTarget);
        }

        /// <summary>
        /// Convert binary value to decimal value. <br />
        /// 二进制值转换为十进制值
        /// </summary>
        /// <example>in: 101110; out: 46</example>
        /// <param name="binaryThings"></param>
        /// <returns></returns>
        public static int BinToDec(string binaryThings)
        {
            return Convert.ToInt32(ScaleConvHelper.ThingsToThings(binaryThings, 2, 10));
        }

        /// <summary>
        /// Convert binary value to hexadecimal value. <br />
        /// 二进制值转换为十六进制值
        /// </summary>
        /// <example>in: 101110; out: 2E</example>
        /// <param name="binaryThings"></param>
        /// <returns></returns>
        public static string BinToHex(string binaryThings)
        {
            return ScaleConvHelper.ThingsToThings(binaryThings, 2, 16);
        }

        /// <summary>
        /// Convert decimal value to binary value. <br />
        /// 十进制值转换为二进制值
        /// </summary>
        /// <example>in: 46; out: 101110</example>
        /// <example>in: 128; out: 10000000</example>
        /// <param name="decimalThings"></param>
        /// <returns></returns>
        public static string DecToBin(string decimalThings)
        {
            return ScaleConvHelper.ThingsToThings(decimalThings, 10, 2);
        }

        /// <summary>
        /// Convert decimal value to binary value. <br />
        /// 十进制值转换为二进制值
        /// </summary>
        /// <example>in: 46; out: 101110</example>
        /// <example>in: 128; out: 10000000</example>
        /// <param name="decimalThings"></param>
        /// <returns></returns>
        public static string DecToBin(byte decimalThings)
        {
            return ScaleConvHelper.ThingsToThings(decimalThings.ToString(), 10, 2);
        }

        /// <summary>
        /// Convert decimal value to hexadecimal value. <br />
        /// 十进制值转换为十六进制值
        /// </summary>
        /// <example>in: 46; out: 2E</example>
        /// <param name="decimalThings"></param>
        /// <returns></returns>
        public static string DecToHex(string decimalThings)
        {
            return ScaleConvHelper.ThingsToThings(decimalThings, 10, 16);
        }

        /// <summary>
        /// Convert decimal value to hexadecimal value. <br />
        /// 十进制值转换为十六进制值
        /// </summary>
        /// <example>in: 46; out: 002E</example>
        /// <param name="decimalThings"></param>
        /// <param name="formatLength"></param>
        /// <returns></returns>
        public static string DecToHex(string decimalThings, int formatLength)
        {
            var system16Val = ScaleConvHelper.ThingsToThings(decimalThings, 10, 16);
            return system16Val.Length > formatLength
                ? system16Val
                : system16Val.PadLeft(formatLength, '0');
        }

        /// <summary>
        /// Convert decimal value to hexadecimal value. <br />
        /// 十进制值转换为十六进制值
        /// </summary>
        /// <example>in: 46; out: 2E</example>
        /// <param name="decimalThings"></param>
        /// <returns></returns>
        public static string DecToHex(byte decimalThings)
        {
            return ScaleConvHelper.ThingsToThings(decimalThings.ToString(), 10, 16);
        }

        /// <summary>
        /// Convert high address 'h' and low address 'l' decimal value to hexadecimal value. <br />
        /// 十进制值转换为十六进制值
        /// </summary>
        /// <example>in: (byte)65, (byte)66; out: 4142</example>
        /// <example>in: (byte)66, (byte)65; out: 4241</example>
        /// <param name="highThings"></param>
        /// <param name="lowThings"></param>
        /// <returns></returns>
        public static string DecToHex(byte highThings, byte lowThings)
        {
            return $"{DecToHex(highThings)}{DecToHex(lowThings)}";
        }

        /// <summary>
        /// Convert hexadecimal value to decimal value. <br />
        /// 十六进制值转换为十进制值
        /// </summary>
        /// <example>in: 2E; out: 46</example>
        /// <param name="hexadecimalThings"></param>
        /// <returns></returns>
        public static string HexToDec(string hexadecimalThings)
        {
            return ScaleConvHelper.ThingsToThings(hexadecimalThings, 16, 10);
        }

        /// <summary>
        /// Convert hexadecimal value to binary value. <br />
        /// 十六进制值转换为二进制值
        /// </summary>
        /// <example>in: 2E; out: 101110</example>
        /// <param name="hexadecimalThings"></param>
        /// <returns></returns>
        public static string HexToBin(string hexadecimalThings)
        {
            return ScaleConvHelper.ThingsToThings(hexadecimalThings, 16, 2);
        }

        /// <summary>
        /// Convert letters to hexadecimal value. <br />
        /// 将字符转换为十六进制值
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string LettersToHex(string letters, Encoding encoding = null)
        {
            return BitConverter.ToString((encoding ?? Encoding.UTF8).GetBytes(letters)).Replace("-", " ");
        }

        /// <summary>
        /// Convert hexadecimal value to letters. <br />
        /// 将十六进制值转换为字符
        /// </summary>
        /// <param name="hexadecimalThings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HexToLetters(string hexadecimalThings, Encoding encoding = null)
        {
            var mc = Regex.Matches(hexadecimalThings, @"(?i)[\da-f]{2}");
            var bytes = new byte[mc.Count];
            for (var i = 0; i < mc.Count; i++)
            {
                if (!byte.TryParse(mc[i].Value, NumberStyles.HexNumber, null, out bytes[i]))
                    bytes[i] = 0;
            }

            return (encoding ?? Encoding.UTF8).GetString(bytes);
        }

        /// <summary>
        /// Convert long hexadecimal value to decimal bytes value. <br />
        /// 长十六进制字符串值转换为十进制 byte 值
        /// </summary>
        /// <example>in: 2E3D; out: result[0] is 46, result[1] is 61</example>
        /// <param name="hexadecimalThings"></param>
        /// <returns></returns>
        public static byte[] LongHexToDecBytes(string hexadecimalThings)
        {
            var mc = Regex.Matches(hexadecimalThings, @"(?i)[\da-f]{2}");
            return (from Match m in mc select Convert.ToByte(m.Value, 16)).ToArray();
        }

        /// <summary>
        /// Convert decimal bytes value to long hexadecimal value. <br />
        /// 十进制 byte 值转换为长十六进制字符串值
        /// </summary>
        /// <example>in: new byte[] {65 , 66, 67}; out: 414243</example>
        /// <param name="decimalBytes"></param>
        /// <returns></returns>
        public static string DecBytesToLongHex(byte[] decimalBytes)
        {
            var sb = new StringBuilder();
            foreach (var decimalThings in decimalBytes)
                sb.Append(DecToHex(decimalThings.ToString())).Append(" ");
            return sb.Length > 0 ? sb.ToString(0, sb.Length - 1) : string.Empty;
        }
    }
}