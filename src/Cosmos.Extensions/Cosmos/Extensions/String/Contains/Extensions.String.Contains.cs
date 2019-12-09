// ReSharper disable once CheckNamespace

namespace Cosmos {
    public static partial class StringExtensions {
        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="text"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool Contains(this string text, string[] values) {
            for (var i = 0; i < values.Length; i++) {
                if (text.Contains(values[i]))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="text"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static bool Contains(this string text, char character) {
            for (var i = 0; i < text.Length; i++) {
                if (i == character)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="text"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static bool Contains(this string text, char[] characters) {
            for (var i = 0; i < characters.Length; i++) {
                if (text.Contains(characters[i]))
                    return true;
            }

            return false;
        }
    }
}