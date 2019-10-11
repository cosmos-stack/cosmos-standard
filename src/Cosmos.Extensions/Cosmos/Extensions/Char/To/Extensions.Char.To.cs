using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class CharExtensions
    {
        /// <summary>
        /// To create a range from one to another
        /// </summary>
        /// <param name="this"></param>
        /// <param name="toCharacter"></param>
        /// <returns></returns>
        public static IEnumerable<char> To(this char @this, char toCharacter)
        {
            var reverseRequired = @this > toCharacter;

            var first = reverseRequired ? toCharacter : @this;
            var last = reverseRequired ? @this : toCharacter;

            var result = Enumerable.Range(first, last - first + 1).Select(charCode => (char)charCode);

            if (reverseRequired)
            {
                result = result.Reverse();
            }

            return result;
        }

        /// <summary>
        /// Convert char to ascii value
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int ToAsciiValue(this char c)
        {
            int num;
            var num2 = Convert.ToInt32(c);
            if (num2 < 0x80)
            {
                return num2;
            }

            byte[] buffer;
            // ReSharper disable once InconsistentNaming
            var fileIOEncoding = Encoding.UTF8;

            char[] chars = { c };
            if (fileIOEncoding.GetMaxByteCount(1) == 1)
            {
                buffer = new byte[1];
                var num3 = fileIOEncoding.GetBytes(chars, 0, 1, buffer, 0);
                return buffer[0];
            }
            buffer = new byte[2];
            if (fileIOEncoding.GetBytes(chars, 0, 1, buffer, 0) == 1)
            {
                return buffer[0];
            }
            if (BitConverter.IsLittleEndian)
            {
                byte num4 = buffer[0];
                buffer[0] = buffer[1];
                buffer[1] = num4;
            }
            num = BitConverter.ToInt16(buffer, 0);

            return num;
        }
    }
}