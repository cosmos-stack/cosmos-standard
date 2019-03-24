using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        public static int DiffCharsCount(this string text, string toCheck)
        {
            GuardParameterForDiffOnlyOneChar(text, toCheck);

            var res = 0;
            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] != toCheck[i])
                    res++;
            }
            return res;
        }

        public static int DiffCharsCountIgnoreCase(this string text, string toCheck)
        {
            GuardParameterForDiffOnlyOneChar(text, toCheck);

            var res = 0;
            for (var i = 0; i < text.Length; i++)
            {
                if (!text[i].EqualsIgnoreCase(toCheck[i]))
                    res++;
            }
            return res;
        }

        private static void GuardParameterForDiffOnlyOneChar(string text, string check)
        {
            if (text.Length != check.Length)
                throw new ArgumentException("The parameter for 'DiffOnlyOneChar' must have the same length");

        }
    }
}
