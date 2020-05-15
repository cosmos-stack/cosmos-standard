using System;
using System.Collections.Generic;
using Cosmos.Conversions.Core;

namespace Cosmos.Conversions.Determiners {
    /// <summary>
    /// Internal core conversion helper from string to boolean
    /// </summary>
    internal static class StringBooleanDeterminer {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="booleanAct"></param>
        /// <returns></returns>
        public static bool Is(string str, Action<bool> booleanAct = null) {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            var result = bool.TryParse(str, out var boolean);
            if (!result)
                result = ValueDeterminer.IsXxxAgain<bool>(str);
            if (result)
                booleanAct?.Invoke(boolean);
            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="booleanAct"></param>
        /// <returns></returns>
        public static bool Is(string str, IEnumerable<IConversionTry<string, bool>> tries, Action<bool> booleanAct = null) =>
            ValueDeterminer.IsXXX(str, string.IsNullOrWhiteSpace, Is, tries, booleanAct);

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static bool To(string str, bool defaultVal = default) {
            if (string.IsNullOrWhiteSpace(str))
                return defaultVal;
            return bool.TryParse(str, out var boolean) ? boolean : ValueConverter.ToXxxAgain(str, defaultVal);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static bool To(string str, IEnumerable<IConversionImpl<string, bool>> impls) =>
            ValueConverter.ToXxx(str, Is, impls);
    }
}