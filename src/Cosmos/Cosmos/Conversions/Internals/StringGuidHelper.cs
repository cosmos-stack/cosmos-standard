using System;
using System.Collections.Generic;

namespace Cosmos.Conversions.Internals {
    /// <summary>
    /// Internal core conversion helper from string to Guid
    /// </summary>
    public static class StringGuidHelper {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="guidAct"></param>
        /// <returns></returns>
        public static bool Is(string str, Action<Guid> guidAct = null) {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            var result = Guid.TryParse(str, out var guid);

            if (result)
                guidAct?.Invoke(guid);

            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="guidAct"></param>
        /// <returns></returns>
        public static bool Is(string str, IEnumerable<IConversionTry<string, Guid>> tries, Action<Guid> guidAct = null) {
            return _Helper.IsXXX(str, string.IsNullOrWhiteSpace, Is, tries, guidAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid To(string str, Guid defaultVal = default) {
            if (string.IsNullOrWhiteSpace(str))
                return defaultVal;

            return Guid.TryParse(str, out var guid) ? guid : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static Guid To(string str, IEnumerable<IConversionImpl<string, Guid>> impls) {
            return _Helper.ToXXX(str, Is, impls);
        }
    }
}