// ReSharper disable once CheckNamespace

namespace Cosmos {
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions {
        /// <summary>
        /// Include Letters
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IncludeLetters(this string text) //ver
        {
            return text.IncludeLetters(0);
        }

        /// <summary>
        /// Include Letters
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool IncludeLetters(this string text, int minCount) //ver
        {
            var count = 0;
            foreach (var car in text) {
                if (char.IsLetter(car))
                    count++;

                if (count >= minCount)
                    return true;
            }

            return false;
        }

    }
}