// ReSharper disable once CheckNamespace

namespace Cosmos {
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions {
        /// <summary>
        /// Contains only digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ContainsOnlyDigits(this string text) //ver
        {
            foreach (var car in text) {
                if (!char.IsDigit(car)) return false;
            }

            return true;
        }

        /// <summary>
        /// Not Contains Digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool NotContainsDigits(this string text) //Ver
        {
            foreach (var car in text) {
                if (char.IsDigit(car)) return false;
            }

            return true;
        }

        /// <summary>
        /// Contains digit
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ContainsDigit(this string text) //ver
        {
            foreach (var car in text) {
                if (char.IsDigit(car)) return true;
            }

            return false;
        }

        /// <summary>
        /// Include digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IncludeDigits(this string text) //ver
        {
            return text.IncludeDigits(0);
        }

        /// <summary>
        /// Include digits
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool IncludeDigits(this string text, int minCount) //ver
        {
            var count = 0;
            foreach (var car in text) {
                if (char.IsDigit(car))
                    count++;

                if (count >= minCount)
                    return true;
            }

            return false;
        }
    }
}