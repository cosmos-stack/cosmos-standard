using System;
using System.Collections.Generic;
using Cosmos.Conversions.Common;

namespace Cosmos.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to Enum
    /// </summary>
    public static class StringEnumDeterminer
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="enumType"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            Type enumType,
            bool ignoreCase = false,
            Action<object> matchedCallback = null)
        {
            return EnumsNET.Enums.TryParse(enumType, text, ignoreCase, out var @enum)
                           .IfTrueThenInvoke(matchedCallback, @enum);
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="text"></param>
        /// <param name="tries"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            Type enumType,
            IEnumerable<IConversionTry<string, object>> tries,
            bool ignoreCase = false,
            Action<object> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace, (s, act) => Is(s, enumType, ignoreCase, act), tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="enumType"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static object To(
            string text,
            Type enumType,
            bool ignoreCase = false,
            object defaultVal = default)
        {
            if (text is null)
                return defaultVal;
            
            return EnumsNET.Enums.TryParse(enumType, text, ignoreCase, out var result)
                ? result
                : defaultVal ?? Activator.CreateInstance(enumType);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="enumType"></param>
        /// <param name="impls"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static object To(
            string text,
            Type enumType,
            IEnumerable<IConversionImpl<string, object>> impls,
            bool ignoreCase = false)
        {
            return ValueConverter.ToXxx(text, (s, act) => Is(s, enumType, ignoreCase, act), impls);
        }
    }
}