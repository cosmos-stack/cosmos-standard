using System;
using System.Collections.Generic;
using Cosmos.Conversions.Core;

namespace Cosmos.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to Guid
    /// </summary>
    internal static class StringGuidDeterminer
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="guidAct"></param>
        /// <returns></returns>
        public static bool Is(string str, Action<Guid> guidAct = null)
        {
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
        public static bool Is(string str, IEnumerable<IConversionTry<string, Guid>> tries, Action<Guid> guidAct = null) =>
            ValueDeterminer.IsXXX(str, string.IsNullOrWhiteSpace, Is, tries, guidAct);

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid To(string str, Guid defaultVal = default)
        {
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
        public static Guid To(string str, IEnumerable<IConversionImpl<string, Guid>> impls) =>
            ValueConverter.ToXxx(str, Is, impls);

        /// <summary>
        /// Exact Guid Determiner
        /// </summary>
        public static class Exact
        {
            /// <summary>
            /// Is
            /// </summary>
            /// <param name="str"></param>
            /// <param name="format"></param>
            /// <param name="guidAct"></param>
            /// <returns></returns>
            public static bool Is(string str, string format, Action<Guid> guidAct = null)
            {
                if (string.IsNullOrWhiteSpace(str))
                    return false;
                var result = Guid.TryParseExact(str, format, out var guid);
                if (result)
                    guidAct?.Invoke(guid);
                return result;
            }

            /// <summary>
            /// Is
            /// </summary>
            /// <param name="str"></param>
            /// <param name="format"></param>
            /// <param name="tries"></param>
            /// <param name="guidAct"></param>
            /// <returns></returns>
            public static bool Is(string str, string format, IEnumerable<IConversionTry<string, Guid>> tries, Action<Guid> guidAct = null) =>
                ValueDeterminer.IsXXX(str, string.IsNullOrWhiteSpace, (s, act) => Is(s, format, act), tries, guidAct);

            /// <summary>
            /// To
            /// </summary>
            /// <param name="str"></param>
            /// <param name="format"></param>
            /// <param name="defaultVal"></param>
            /// <returns></returns>
            public static Guid To(string str, string format, Guid defaultVal = default)
            {
                if (string.IsNullOrWhiteSpace(str))
                    return defaultVal;
                return Guid.TryParse(str, out var guid) ? guid : defaultVal;
            }

            /// <summary>
            /// To
            /// </summary>
            /// <param name="str"></param>
            /// <param name="format"></param>
            /// <param name="impls"></param>
            /// <returns></returns>
            public static Guid To(string str, string format, IEnumerable<IConversionImpl<string, Guid>> impls) =>
                ValueConverter.ToXxx(str, (s, act) => Is(s, format, act), impls);
        }
    }
}