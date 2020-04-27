// ReSharper disable once CheckNamespace

namespace Cosmos {
    /// <summary>
    /// Char extensions
    /// </summary>
    public static partial class CharExtensions {
        /// <summary>
        /// Is special char between min and max
        /// </summary>
        /// <param name="char"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsBetween(this char @char, char min, char max) {
            var (xiao, da) = Fix(min, max);
            return @char >= xiao && @char <= da;
        }

        private static (char min, char max) Fix(char min, char max) => min >= max ? (max, min) : (min, max);
    }
}