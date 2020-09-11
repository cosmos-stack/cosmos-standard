using System;

namespace Cosmos.Text
{
    public static class StringDiff
    {
        /// <summary>
        /// Diff chars' count
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static int DiffCharsCount(string text, string toCheck)
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
        public static int DiffCharsCountIgnoreCase(string text, string toCheck)
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
        
        /// <summary>
        /// Diff only one char
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool DiffOnlyOneChar(string text, string toCheck)
        {
            GuardParameterForDiffOnlyOneChar(text, toCheck);
            return DiffCharsCount(text, toCheck) == 1;
        }
        
        private static void GuardParameterForDiffOnlyOneChar(string text, string check)
        {
            if (text.Length != check.Length)
                throw new ArgumentException("The parameter for 'DiffOnlyOneChar' must have the same length");
        }
    }
}