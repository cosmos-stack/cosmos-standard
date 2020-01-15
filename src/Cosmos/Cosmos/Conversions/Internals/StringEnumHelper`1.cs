using System;
using System.Collections.Generic;

namespace Cosmos.Conversions.Internals {
    /// <summary>
    /// Internal core conversion helper from string to Enum
    /// </summary>
    public static class StringEnumHelper<TEnum> where TEnum : struct {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool Is(string str, bool ignoreCase = false, Action<TEnum> action = null) {
            var result = Enum.TryParse(str, ignoreCase, out TEnum @enum);

            if (result)
                action?.Invoke(@enum);

            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="enumAct"></param>
        /// <returns></returns>
        public static bool Is(
            string str,
            IEnumerable<IConversionTry<string, TEnum>> tries,
            bool ignoreCase = false,
            Action<TEnum> enumAct = null) {
            return _Helper.IsXXX(str, string.IsNullOrWhiteSpace, (s, act) => Is(s, ignoreCase, act), tries, enumAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TEnum To(string str, bool ignoreCase = false, TEnum defaultVal = default) {
            return Enum.TryParse(str, ignoreCase, out TEnum @enum) ? @enum : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static TEnum To(string str, IEnumerable<IConversionImpl<string, TEnum>> impls, bool ignoreCase = false) {
            return _Helper.ToXXX(str, (s, act) => Is(s, ignoreCase, act), impls);
        }
    }
}