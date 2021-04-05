using System.Text;
using Cosmos.Text;

namespace Cosmos.Conversions
{
    public static class ScaleHelper
    {
        private static string Reverse(string val, int bitLength)
        {
            if (string.IsNullOrWhiteSpace(val))
                return val;
            var left = val.Length % bitLength;
            if (left > 0)
                val = $"{'0'.Repeat(left)}{val}";
            var builder = new StringBuilder();
            for (var i = val.Length - bitLength; i >= 0; i -= bitLength)
                builder.Append(val.Substring(i, bitLength));
            return builder.ToString();
        }

        public static string ReverseHex(string hexVal) => Reverse(hexVal, 2);

        public static string ReverseBin(string binVal) => Reverse(binVal, 8);
    }
}