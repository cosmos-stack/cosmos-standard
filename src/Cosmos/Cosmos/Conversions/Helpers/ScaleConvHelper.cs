using System;
using System.Linq;

namespace Cosmos.Conversions.Helpers
{
    internal static class ScaleConvHelper
    {
        private const int BITS_IN_LONG = 64;
        private const string DIGITS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static ScaleConvHelper()
        {
            DigitArray = DIGITS.ToCharArray();
        }

        private static long ThingsToLong(string things, int baseOfSource)
        {
            if (string.IsNullOrWhiteSpace(things))
                return 0L;
#if NETFRAMEWORK || NETSTANDARD
            var currentDigits = DIGITS.AsSpan().Slice(0, baseOfSource).ToArray();
#else
            var currentDigits = DIGITS.AsSpan().Slice(0, baseOfSource);
#endif
            var val = 0L;
            things = things.Trim().ToUpperInvariant();
            for (var i = 0; i < things.Length; i++)
            {
                if (currentDigits.Contains(things[i]))
                {
                    try
                    {
                        val += (long) Math.Pow(baseOfSource, i) * GetCharIndex(things[things.Length - i - 1]);
                    }
                    catch
                    {
                        throw new OverflowException("An overflow occurred during operation.");
                    }
                }
                else
                {
                    throw new ArgumentException($"The argument \"{things[i]}\" is not in {baseOfSource} system.");
                }
            }

            return val;
        }

        private static string LongToThings(long value, int baseOfTarget)
        {
            int digitsIndex;
            var longPositive = Math.Abs(value);
            var digitsOut = new char[BITS_IN_LONG - 1];

            for (digitsIndex = 0; digitsIndex <= BITS_IN_LONG; digitsIndex++)
            {
                if (longPositive == 0)
                    break;
                digitsOut[digitsOut.Length - digitsIndex - 1] = DigitArray[longPositive % baseOfTarget];
                longPositive /= baseOfTarget;
            }

            return new string(digitsOut, digitsOut.Length - digitsIndex, digitsIndex);
        }

        public static string ThingsToThings(string things, int baseOfSource, int baseOfTarget)
        {
            if (string.IsNullOrWhiteSpace(things))
                return string.Empty;
            if (baseOfSource < 2 || baseOfSource > 36)
                throw new ArgumentException($"The baseOfSource radix \"{baseOfSource}\" is not in the range 2..36.");
            if (baseOfTarget < 2 || baseOfTarget > 36)
                throw new ArgumentException($"The baseOfTarget radix \"{baseOfTarget}\" is not in the range 2..36.");
            if (baseOfSource == baseOfTarget)
                return things;
            var val = ThingsToLong(things, baseOfSource);
            return LongToThings(val, baseOfTarget);
        }

        private static int GetCharIndex(char value)
        {
            for (var i = 0; i < DIGITS.Length; i++)
                if (DIGITS[i] == value)
                    return i;
            return 0;
        }

        private static readonly char[] DigitArray;
    }
}