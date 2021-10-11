using System;
using System.Collections.Generic;
using CosmosStack.Conversions.Common;

namespace CosmosStack.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to char
    /// </summary>
    public static class StringCharDeterminer
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            Action<char> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;
            
            return char.TryParse(text, out var c)
                       .IfFalseThenInvoke(ValueDeterminer.IsXxxAgain<char>, text)
                       .IfTrueThenInvoke(matchedCallback, c);
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
            IEnumerable<IConversionTry<string, char>> tries,
            Action<char> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace, Is, tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static char To(
            string text,
            char defaultVal = default)
        {
            if (text is null)
                return defaultVal;
            return char.TryParse(text, out var c) ? c : ValueConverter.ToXxxAgain(text, defaultVal);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static char To(
            string text,
            IEnumerable<IConversionImpl<string, char>> impls)
        {
            return ValueConverter.ToXxx(text, Is, impls);
        }
    }
}