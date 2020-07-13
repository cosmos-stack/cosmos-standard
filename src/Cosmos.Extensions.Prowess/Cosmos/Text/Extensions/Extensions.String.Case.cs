using Cosmos.Collections;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    public static partial class StringExtensions
    {
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