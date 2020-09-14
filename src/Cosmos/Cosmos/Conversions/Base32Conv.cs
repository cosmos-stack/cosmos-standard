using System;
using System.Text;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Base32 Conversion Utilities
    /// </summary>
    public static class Base32Conv
    {
        /// <summary>
        /// Convert from <see cref="string"/> to base32 <see cref="string"/>.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToBase32String(byte[] bytes)
        {
            if (bytes is null || bytes.Length == 0)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            var charCount = (int) Math.Ceiling(bytes.Length / 5d) * 8;
            var returnArray = new char[charCount];

            byte nextChar = 0, bitsRemaining = 5;
            var arrayIndex = 0;

            foreach (var b in bytes)
            {
                nextChar = (byte) (nextChar | (b >> (8 - bitsRemaining)));
                returnArray[arrayIndex++] = ValueToChar(nextChar);

                if (bitsRemaining < 4)
                {
                    nextChar = (byte) ((b >> (3 - bitsRemaining)) & 31);
                    returnArray[arrayIndex++] = ValueToChar(nextChar);
                    bitsRemaining += 5;
                }

                bitsRemaining -= 3;
                nextChar = (byte) ((b << bitsRemaining) & 31);
            }

            //if we didn't end with a full char
            if (arrayIndex != charCount)
            {
                returnArray[arrayIndex++] = ValueToChar(nextChar);
                while (arrayIndex != charCount) returnArray[arrayIndex++] = '='; //padding
            }

            return new string(returnArray);
        }

        /// <summary>
        /// Convert from <see cref="string"/> to base32 <see cref="string"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase32String(string str, Encoding encoding = null) =>
            ToBase32String(encoding.SafeValue().GetBytes(str));

        /// <summary>
        /// Convert from base32 <see cref="string"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="base32String"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase32String(string base32String, Encoding encoding = null) =>
            encoding.SafeValue().GetString(FromBase32StringToBytes(base32String));

        /// <summary>
        /// Convert from base32 <see cref="string"/> to <see cref="byte"/> array.
        /// </summary>
        /// <param name="base32String"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] FromBase32StringToBytes(string base32String)
        {
            if (base32String is null)
            {
                throw new ArgumentNullException(nameof(base32String));
            }

            base32String = base32String.TrimEnd('=');    //remove padding characters
            var byteCount = base32String.Length * 5 / 8; //this must be TRUNCATED
            var returnArray = new byte[byteCount];

            byte curByte = 0, bitsRemaining = 8;
            var arrayIndex = 0;
            foreach (var c in base32String)
            {
                var cValue = CharToValue(c);

                int mask;
                if (bitsRemaining > 5)
                {
                    mask = cValue << (bitsRemaining - 5);
                    curByte = (byte) (curByte | mask);
                    bitsRemaining -= 5;
                }
                else
                {
                    mask = cValue >> (5 - bitsRemaining);
                    curByte = (byte) (curByte | mask);
                    returnArray[arrayIndex++] = curByte;
                    curByte = (byte) (cValue << (3 + bitsRemaining));
                    bitsRemaining += 3;
                }
            }

            //if we didn't end with a full byte
            if (arrayIndex != byteCount)
            {
                returnArray[arrayIndex] = curByte;
            }

            return returnArray;
        }

        private static int CharToValue(char c)
        {
            var value = (int) c;

            //65-90 == uppercase letters
            if (value < 91 && value > 64)
            {
                return value - 65;
            }

            //50-55 == numbers 2-7
            if (value < 56 && value > 49)
            {
                return value - 24;
            }

            //97-122 == lowercase letters
            if (value < 123 && value > 96)
            {
                return value - 97;
            }

            throw new ArgumentException("Character is not a Base32 character.", nameof(c));
        }

        private static char ValueToChar(byte b)
        {
            if (b < 26)
            {
                return (char) (b + 65);
            }

            if (b < 32)
            {
                return (char) (b + 24);
            }

            throw new ArgumentException("Byte is not a Base32 value.", nameof(b));
        }

        private static Encoding SafeValue(this Encoding encoding) => encoding ?? Encoding.UTF8;
    }
}