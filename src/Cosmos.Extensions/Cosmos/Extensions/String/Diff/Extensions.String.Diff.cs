using System;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Diff chars' count
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Diff chars' count ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
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

        [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
        private static void GuardParameterForDiffOnlyOneChar(string text, string check)
        {
            if (text.Length != check.Length)
                throw new ArgumentException("The parameter for 'DiffOnlyOneChar' must have the same length");

        }
    }
}
