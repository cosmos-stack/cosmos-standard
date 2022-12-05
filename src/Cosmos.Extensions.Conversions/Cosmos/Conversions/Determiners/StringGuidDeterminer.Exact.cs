using Cosmos.Conversions.Common;

namespace Cosmos.Conversions.Determiners;

/// <summary>
/// Internal core conversion helper from string to Guid
/// </summary>
public static partial class StringGuidDeterminer
{
    /// <summary>
    /// Exact Guid Determiner
    /// </summary>
    public static class Exact
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            string format,
            Action<Guid> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            return Guid.TryParseExact(text, format, out var guid)
                       .IfTrueThenInvoke(matchedCallback, guid);
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <param name="tries"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            string format,
            IEnumerable<IConversionTry<string, Guid>> tries,
            Action<Guid> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace, (s, act) => Is(s, format, act), tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid To(
            string text,
            string format,
            Guid defaultVal = default)
        {
            if (string.IsNullOrWhiteSpace(text))
                return defaultVal;

            return Guid.TryParseExact(text, format, out var guid) ? guid : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static Guid To(
            string text,
            string format,
            IEnumerable<IConversionImpl<string, Guid>> impls)
        {
            return ValueConverter.ToXxx(text, (s, act) => Is(s, format, act), impls);
        }
    }
}