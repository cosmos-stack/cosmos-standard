using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to DateTimeOffset
    /// </summary>
    public static class StringDateTimeOffsetDeterminer
    {
        // ReSharper disable once InconsistentNaming
        internal static bool IS(string str) => Is(str);

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            Action<DateTimeOffset> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;
            var result = DateTimeOffset.TryParse(text, formatProvider.SafeDateTime(), style, out var dateTimeOffset);
            if (!result)
                result = ValueDeterminer.IsXxxAgain<DateTimeOffset>(text);
            if (result)
                matchedCallback?.Invoke(dateTimeOffset);
            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tries"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            IEnumerable<IConversionTry<string, DateTimeOffset>> tries,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            Action<DateTimeOffset> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider, act), tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset To(
            string text,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            DateTimeOffset defaultVal = default)
        {
            return DateTimeOffset.TryParse(text, formatProvider.SafeDateTime(), style, out var offset)
                ? offset
                : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static DateTimeOffset To(
            string text,
            IEnumerable<IConversionImpl<string, DateTimeOffset>> impls,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null)
        {
            return ValueConverter.ToXxx(text, (s, act) => Is(s, style, formatProvider.SafeDateTime(), act), impls);
        }

        /// <summary>
        /// Exact DateTimeOffset Determiner
        /// </summary>
        public static class Exact
        {
            /// <summary>
            /// Is
            /// </summary>
            /// <param name="text"></param>
            /// <param name="format"></param>
            /// <param name="style"></param>
            /// <param name="formatProvider"></param>
            /// <param name="matchedCallback"></param>
            /// <returns></returns>
            public static bool Is(
                string text,
                string format,
                DateTimeStyles style = DateTimeStyles.None,
                IFormatProvider formatProvider = null,
                Action<DateTimeOffset> matchedCallback = null)
            {
                if (string.IsNullOrWhiteSpace(text))
                    return false;
                var result = DateTimeOffset.TryParseExact(text, format, formatProvider.SafeDateTime(), style, out var dateTimeOffset);
                if (result)
                    matchedCallback?.Invoke(dateTimeOffset);
                return result;
            }

            /// <summary>
            /// Is
            /// </summary>
            /// <param name="text"></param>
            /// <param name="format"></param>
            /// <param name="tries"></param>
            /// <param name="style"></param>
            /// <param name="formatProvider"></param>
            /// <param name="matchedCallback"></param>
            /// <returns></returns>
            public static bool Is(
                string text,
                string format,
                IEnumerable<IConversionTry<string, DateTimeOffset>> tries,
                DateTimeStyles style = DateTimeStyles.None,
                IFormatProvider formatProvider = null,
                Action<DateTimeOffset> matchedCallback = null)
            {
                return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace,
                    (s, act) => Is(s, format, style, formatProvider, act), tries, matchedCallback);
            }

            /// <summary>
            /// To
            /// </summary>
            /// <param name="text"></param>
            /// <param name="format"></param>
            /// <param name="style"></param>
            /// <param name="formatProvider"></param>
            /// <param name="defaultVal"></param>
            /// <returns></returns>
            public static DateTimeOffset To(
                string text,
                string format,
                DateTimeStyles style = DateTimeStyles.None,
                IFormatProvider formatProvider = null,
                DateTimeOffset defaultVal = default)
            {
                return DateTimeOffset.TryParseExact(text, format, formatProvider.SafeDateTime(), style, out var offset)
                    ? offset
                    : defaultVal;
            }

            /// <summary>
            /// To
            /// </summary>
            /// <param name="text"></param>
            /// <param name="format"></param>
            /// <param name="impls"></param>
            /// <param name="style"></param>
            /// <param name="formatProvider"></param>
            /// <returns></returns>
            public static DateTimeOffset To(
                string text,
                string format,
                IEnumerable<IConversionImpl<string, DateTimeOffset>> impls,
                DateTimeStyles style = DateTimeStyles.None,
                IFormatProvider formatProvider = null)
            {
                return ValueConverter.ToXxx(text, (s, act) => Is(s, format, style, formatProvider.SafeDateTime(), act), impls);
            }
        }
    }
}