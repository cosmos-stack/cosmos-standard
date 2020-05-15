using System;
using System.Globalization;
using Cosmos.Conversions;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text {
    /// <summary>
    /// String determiner extensions
    /// </summary>
    public static partial class StringDeterminerExtensions {
        /// <summary>
        /// Is nullable
        /// </summary>
        /// <param name="s"></param>
        /// <param name="action"></param>
        /// <param name="isNullAction"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="provider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullable<T>(
            this string s,
            Action<T> action = null,
            Action isNullAction = null,
            bool ignoreCase = false,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider provider = null) where T : struct {
            return s is null && NullableFunc()(isNullAction)
                || Is(s, ignoreCase.X(), action, format, numberStyle, dateTimeStyle, provider);
        }

        /// <summary>
        /// Is nullable
        /// </summary>
        /// <param name="s"></param>
        /// <param name="type"></param>
        /// <param name="action"></param>
        /// <param name="isNullAction"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static bool IsNullable(
            this string s,
            Type type,
            Action<object> action = null,
            Action isNullAction = null,
            bool ignoreCase = false,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider provider = null) {
            return s is null && NullableFunc()(isNullAction)
                || Is(s, type, ignoreCase.X(), action, format, numberStyle, dateTimeStyle, provider);
        }

        private static Func<Action, bool> NullableFunc() => act => {
            act?.Invoke();
            return true;
        };
    }
}