using System;
using System.Collections.Generic;

namespace Cosmos.Conversions.StringDeterminers {
    /// <summary>
    /// Internal core conversion helper from string to boolean
    /// </summary>
    public static class StringBooleanDeterminer {
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
            _Helper.IsXXX(str, string.IsNullOrWhiteSpace, Is, tries, booleanAct);

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static bool To(string str, bool defaultVal = default) {
            if (string.IsNullOrWhiteSpace(str))
                return defaultVal;

            return bool.TryParse(str, out var boolean) ? boolean : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static bool To(string str, IEnumerable<IConversionImpl<string, bool>> impls) =>
            _Helper.ToXXX(str, Is, impls);
    }
}