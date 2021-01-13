using System;
using System.Collections.Generic;
using Cosmos.Conversions.Common;

namespace Cosmos.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to Guid
    /// </summary>
    public static class StringGuidDeterminer
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text, 
            Action<Guid> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;
            var result = Guid.TryParse(text, out var guid);
            if (result)
                matchedCallback?.Invoke(guid);
            return result;
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
            IEnumerable<IConversionTry<string, Guid>> tries,
            Action<Guid> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace, Is, tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid To(
            string text,
            Guid defaultVal = default)
        {
            if (string.IsNullOrWhiteSpace(text))
                return defaultVal;
            return Guid.TryParse(text, out var guid) ? guid : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static Guid To(
            string text, 
            IEnumerable<IConversionImpl<string, Guid>> impls)
        {
            return ValueConverter.ToXxx(text, Is, impls);
        }

        /// <summary>
        /// Exact Guid Determiner
        /// </summary>
        public static class Exact
        {
            /// <summary>
            /// Is
            /// </summary>
            /// <param name="text"></param>
            /// <param name="format"></param>
            /// <param name="matchedCallback"></param>
            /// <returns></returns>
            public static bool Is(
                string text,
                string format,
                Action<Guid> matchedCallback = null)
            {
                if (string.IsNullOrWhiteSpace(text))
                    return false;
                var result = Guid.TryParseExact(text, format, out var guid);
                if (result)
                    matchedCallback?.Invoke(guid);
                return result;
            }

            /// <summary>
            /// Is
            /// </summary>
            /// <param name="text"></param>
            /// <param name="format"></param>
            /// <param name="tries"></param>
            /// <param name="matchedCallback"></param>
            /// <returns></returns>
            public static bool Is(
                string text,
                string format,
                IEnumerable<IConversionTry<string, Guid>> tries,
                Action<Guid> matchedCallback = null)
            {
                return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace, (s, act) => Is(s, format, act), tries, matchedCallback);
            }

            /// <summary>
            /// To
            /// </summary>
            /// <param name="text"></param>
            /// <param name="format"></param>
            /// <param name="defaultVal"></param>
            /// <returns></returns>
            public static Guid To(
                string text,
                string format,
                Guid defaultVal = default)
            {
                if (string.IsNullOrWhiteSpace(text))
                    return defaultVal;
                return Guid.TryParse(text, out var guid) ? guid : defaultVal;
            }

            /// <summary>
            /// To
            /// </summary>
            /// <param name="text"></param>
            /// <param name="format"></param>
            /// <param name="impls"></param>
            /// <returns></returns>
            public static Guid To(
                string text, 
                string format, 
                IEnumerable<IConversionImpl<string, Guid>> impls)
            {
                return ValueConverter.ToXxx(text, (s, act) => Is(s, format, act), impls);
            }
        }
    }
}