using System;
using System.Linq;
using System.Text;

namespace Cosmos.Guava
{
    public static class Strings
    {
        public static string NullToEmpty(string @string)
        {
            if (@string.IsNullOrEmpty())
                return string.Empty;
            return @string;
        }

        public static string EmptyToNull(string @string)
        {
            if (@string.IsNullOrEmpty())
                return null;
            return @string;
        }

        public static string CommonPrefix(string left, string right)
        {
            if (string.IsNullOrWhiteSpace(left) || string.IsNullOrWhiteSpace(right))
                return string.Empty;

            var sb = new StringBuilder();
            var rangeTimes = left.Length < right.Length ? left.Length : right.Length;
            for (var i = 0; i < rangeTimes; i++)
            {
                if (left[i] != right[i])
                    break;

                sb.Append(left[i]);
            }

            return sb.ToString();
        }

        public static string CommonSuffix(string left, string right)
        {
            if (string.IsNullOrWhiteSpace(left) || string.IsNullOrWhiteSpace(right))
                return string.Empty;

            var sb = new StringBuilder();
            var rangeTimes = left.Length < right.Length ? left.Length : right.Length;
            int leftPointer = left.Length - 1, rightPointer = right.Length - 1;
            for (var i = 0; i < rangeTimes; i++, leftPointer--, rightPointer--)
            {
                if (left[leftPointer] != right[rightPointer])
                    break;
                sb.Append(left[leftPointer]);
            }

            return sb.ToReverseString();
        }

        public static string Repeat(string source, int times)
        {
            return source.Repeat(times);
        }

        public static string Repeat(char source, int times)
        {
            return source.Repeat(times);
        }

        public static string PadStart(string source, int width, char appendChar)
        {
            return source.PadLeft(width, appendChar);
        }

        public static string PadEnd(string source, int width, char appendChar)
        {
            return source.PadRight(width, appendChar);
        }
    }
}
