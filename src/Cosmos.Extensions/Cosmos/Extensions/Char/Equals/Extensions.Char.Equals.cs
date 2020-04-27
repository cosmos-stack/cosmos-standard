// ReSharper disable once CheckNamespace

namespace Cosmos {
    public static partial class CharExtensions {
        /// <summary>
        /// Equals ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this char text, char toCheck) =>
            char.ToUpper(text) == char.ToUpper(toCheck);

        /// <summary>
        /// Equals ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this char? text, char toCheck) =>
            text != null && char.ToUpper(text.Value) == char.ToUpper(toCheck);
    }
}