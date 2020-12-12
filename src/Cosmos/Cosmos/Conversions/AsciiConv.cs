using System.Text;

namespace Cosmos.Conversions
{
    internal static class AsciiConvHelper
    {
        public static byte CharToAscii(char @char)
        {
            return (byte) @char;
        }

        public static byte[] StringToAscii(string @string)
        {
            return Encoding.ASCII.GetBytes(@string);
        }

        public static char AsciiToChar(byte @byte)
        {
            return (char) @byte;
        }

        public static string AsciiToString(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes, 0, bytes.Length);
        }
    }

    public static class AsciiConv
    {
        /// <summary>
        /// Convert from bytes to ASCII <see cref="string"/>.
        /// </summary>
        /// <example>in: new byte[] {65, 66, 67}; out: ABC</example>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToAsciiString(byte[] bytes)
        {
            return AsciiConvHelper.AsciiToString(bytes);
        }

        /// <summary>
        /// Convert from ASCII <see cref="string"/> to bytes.
        /// </summary>
        /// <example>in: ABC; out: new byte[] {65, 66, 67}</example>
        /// <param name="asciiStr"></param>
        /// <returns></returns>
        public static byte[] AsciiStringToBytes(string asciiStr)
        {
            return AsciiConvHelper.StringToAscii(asciiStr);
        }
    }
}