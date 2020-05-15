using System;
using System.Collections.Generic;
using Cosmos.Conversions.Core;

namespace Cosmos.Conversions.Determiners {
    /// <summary>
    /// Internal core conversion helper from string to char
    /// </summary>
    internal static class StringCharDeterminer {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="charAct"></param>
        /// <returns></returns>
        public static bool Is(string str, Action<char> charAct = null) {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            var result = char.TryParse(str, out var c);
            if (!result)
                result = ValueDeterminer.IsXxxAgain<char>(str);
            if (result)
                charAct?.Invoke(c);
            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="charAct"></param>
        /// <returns></returns>
        public static bool Is(string str, IEnumerable<IConversionTry<string, char>> tries, Action<char> charAct = null) =>
            ValueDeterminer.IsXXX(str, string.IsNullOrWhiteSpace, Is, tries, charAct);

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static char To(string str, char defaultVal = default) =>
            char.TryParse(str, out var c) ? c : ValueConverter.ToXxxAgain(str, defaultVal);

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static char To(string str, IEnumerable<IConversionImpl<string, char>> impls) =>
            ValueConverter.ToXxx(str, Is, impls);
    }
}