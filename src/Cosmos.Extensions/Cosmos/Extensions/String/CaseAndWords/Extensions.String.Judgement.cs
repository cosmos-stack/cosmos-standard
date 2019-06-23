using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Is upper
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsUpper(this string text)
        {
            foreach (var ch in text)
            {
                if (!char.IsLetter(ch)
                    || char.IsLower(ch))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Is lower
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsLower(this string text)
        {
            foreach (var ch in text)
            {
                if (char.IsLetter(ch)
                    && char.IsUpper(ch))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Is same words
        /// </summary>
        /// <param name="text"></param>
        /// <param name="check"></param>
        /// <returns></returns>
        public static bool IsSameWords(this string text, string check)
        {
            if (check.IsNullOrEmpty())
                return text.IsNullOrEmpty();

            var wordsText = text.SplitInWords();
            var wordsCheck = check.SplitInWords();

            var wordsTextNotInCheck = wordsText.FindAll(x => !x.IsOn(wordsCheck));
            if (wordsTextNotInCheck.Length > 0)
                return false;

            var wordsCheckNotInText = wordsCheck.FindAll(x => !x.IsOn(wordsText));
            if (wordsCheckNotInText.Length > 0)
                return false;

            return true;
        }
    }
}
