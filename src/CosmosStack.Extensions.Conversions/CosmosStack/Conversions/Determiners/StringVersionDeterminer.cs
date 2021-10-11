using System;
using System.Collections.Generic;
using CosmosStack.Conversions.Common;

namespace CosmosStack.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to version
    /// </summary>
    public static class StringVersionDeterminer
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            Action<Version> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            return Version.TryParse(text, out var n)
                          .IfTrueThenInvoke(matchedCallback, n);
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tries"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            IEnumerable<IConversionTry<string, Version>> tries,
            Action<Version> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace, Is, tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Version To(
            string text,
            Version defaultVal = default)
        {
            if (string.IsNullOrWhiteSpace(text))
                return defaultVal;
            
            return Version.TryParse(text, out var result) ? result : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static Version To(
            string text,
            IEnumerable<IConversionImpl<string, Version>> impls)
        {
            return ValueConverter.ToXxx(text, Is, impls);
        }
    }
}