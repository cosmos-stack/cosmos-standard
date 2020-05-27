using Cosmos.Collections;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class BaseTypeExtensions
    {
        /// <summary>
        /// Total letters
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int TotalLetters(this string text) =>
            text.IsNullOrEmpty() ? 0 : text.ToCharArray().FindAll(char.IsLetter).Length;

        /// <summary>
        /// Total lower letters
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int TotalLowerLetters(this string text) =>
            text.IsNullOrEmpty() ? 0 : text.ToCharArray().FindAll(x => char.IsLetter(x) && char.IsLower(x)).Length;

        /// <summary>
        /// Total upper letters
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int TotalUpperLetters(this string text) =>
            text.IsNullOrEmpty() ? 0 : text.ToCharArray().FindAll(x => char.IsLetter(x) && char.IsUpper(x)).Length;

        /// <summary>
        /// Include Letters
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IncludeLetters(this string text) =>
            text.IncludeLetters(0);

        /// <summary>
        /// Include Letters
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool IncludeLetters(this string text, int minCount)
        {
            var count = 0;
            foreach (var car in text)
            {
                if (char.IsLetter(car))
                    count++;

                if (count >= minCount)
                    return true;
            }

            return false;
        }
    }
}