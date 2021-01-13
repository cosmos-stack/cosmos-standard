using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to DateTime
    /// </summary>
    public static class StringDateTimeDeterminer
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
            Action<DateTime> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;
            var result = DateTime.TryParse(text, formatProvider.SafeDateTime(), style, out var dateTime);
            if (!result)
                result = ValueDeterminer.IsXxxAgain<DateTime>(text);
            if (result)
                matchedCallback?.Invoke(dateTime);
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
            IEnumerable<IConversionTry<string, DateTime>> tries,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            Action<DateTime> matchedCallback = null)
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
        public static DateTime To(
            string text,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            DateTime defaultVal = default)
        {
            if (text is null)
                return defaultVal;
            return DateTime.TryParse(text, formatProvider.SafeDateTime(), style, out var dateTime)
                ? dateTime
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
        public static DateTime To(
            string text,
            IEnumerable<IConversionImpl<string, DateTime>> impls,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null)
        {
            return ValueConverter.ToXxx(text, (s, act) => Is(s, style, formatProvider.SafeDateTime(), act), impls);
        }

        /// <summary>
        /// Exact DateTime Determiner
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
                Action<DateTime> matchedCallback = null)
            {
                if (string.IsNullOrWhiteSpace(text))
                    return false;
                var result = DateTime.TryParseExact(text, format, formatProvider.SafeDateTime(), style, out var dateTime);
                if (result)
                    matchedCallback?.Invoke(dateTime);
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
                IEnumerable<IConversionTry<string, DateTime>> tries,
                DateTimeStyles style = DateTimeStyles.None,
                IFormatProvider formatProvider = null,
                Action<DateTime> matchedCallback = null)
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
            public static DateTime To(
                string text,
                string format,
                DateTimeStyles style = DateTimeStyles.None,
                IFormatProvider formatProvider = null,
                DateTime defaultVal = default)
            {
                if (text is null)
                    return defaultVal;
                return DateTime.TryParseExact(text, format, formatProvider.SafeDateTime(), style, out var dateTime)
                    ? dateTime
                    : ValueConverter.ToXxxAgain(text, defaultVal);
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
            public static DateTime To(
                string text,
                string format,
                IEnumerable<IConversionImpl<string, DateTime>> impls,
                DateTimeStyles style = DateTimeStyles.None,
                IFormatProvider formatProvider = null)
            {
                return ValueConverter.ToXxx(text, (s, act) => Is(s, format, style, formatProvider.SafeDateTime(), act), impls);
            }
        }
    }
}