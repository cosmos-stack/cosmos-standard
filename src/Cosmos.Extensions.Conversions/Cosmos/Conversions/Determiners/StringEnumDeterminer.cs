using System;
using System.Collections.Generic;
using Cosmos.Conversions.Core;

namespace Cosmos.Conversions.Determiners {
    /// <summary>
    /// Internal core conversion helper from string to Enum
    /// </summary>
    internal static class StringEnumDeterminer {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="s"></param>
        /// <param name="enumType"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="enumAct"></param>
        /// <returns></returns>
        public static bool Is(string s, Type enumType, bool ignoreCase = false, Action<object> enumAct = null) {
            var result = EnumsNET.Enums.TryParse(enumType, s, ignoreCase, out var @enum);
            if (result) 
                enumAct?.Invoke(@enum);
            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="enumAct"></param>
        /// <returns></returns>
        public static bool Is(string str, Type enumType, IEnumerable<IConversionTry<string, object>> tries, bool ignoreCase = false, Action<object> enumAct = null) =>
            ValueDeterminer.IsXXX(str, string.IsNullOrWhiteSpace, (s, act) => Is(s, enumType, ignoreCase, act), tries, enumAct);

        /// <summary>
        /// To
        /// </summary>
        /// <param name="s"></param>
        /// <param name="enumType"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static object To(string s, Type enumType, bool ignoreCase = false, object defaultVal = default) =>
            EnumsNET.Enums.TryParse(enumType, s, ignoreCase, out var result)
                ? result
                : defaultVal ?? Activator.CreateInstance(enumType);

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="enumType"></param>
        /// <param name="impls"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static object To(string str, Type enumType, IEnumerable<IConversionImpl<string, object>> impls, bool ignoreCase = false) =>
            ValueConverter.ToXxx(str, (s, act) => Is(s, enumType, ignoreCase, act), impls);
    }
}