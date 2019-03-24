using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class BaseTypeExtensions
    {
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

        public static int ToAsciiValue(this char c)
        {
            int num;
            int num2 = Convert.ToInt32(c);
            if (num2 < 0x80)
            {
                return num2;
            }

            byte[] buffer;
            Encoding fileIOEncoding = Encoding.UTF8;

            char[] chars = new char[] { c };
            if (fileIOEncoding.GetMaxByteCount(1) == 1)
            {
                buffer = new byte[1];
                int num3 = fileIOEncoding.GetBytes(chars, 0, 1, buffer, 0);
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