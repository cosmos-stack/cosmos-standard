using System;
using System.Collections.Generic;
using Cosmos.Conversions.Common;

namespace Cosmos.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to Enum
    /// </summary>
    public static class StringEnumDeterminer<TEnum> where TEnum : struct
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text, 
            bool ignoreCase = false,
            Action<TEnum> matchedCallback = null)
        {
            var result = Enum.TryParse(text, ignoreCase, out TEnum @enum);
            if (result)
                matchedCallback?.Invoke(@enum);
            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tries"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text, 
            IEnumerable<IConversionTry<string, TEnum>> tries, 
            bool ignoreCase = false, 
            Action<TEnum> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace, (s, act) => Is(s, ignoreCase, act), tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TEnum To(
            string text, 
            bool ignoreCase = false, 
            TEnum defaultVal = default)
        {
            if (text is null)
                return defaultVal;
            return Enum.TryParse(text, ignoreCase, out TEnum @enum) ? @enum : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static TEnum To(
            string text, 
            IEnumerable<IConversionImpl<string, TEnum>> impls, 
            bool ignoreCase = false)
        {
            return ValueConverter.ToXxx(text, (s, act) => Is(s, ignoreCase, act), impls);
        }
    }
}