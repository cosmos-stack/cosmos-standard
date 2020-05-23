using System;
using System.Globalization;
using Cosmos.Conversions;
using Cosmos.Conversions.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    /// <summary>
    /// String determiner extensions
    /// </summary>
    public static partial class StringDeterminerExtensions
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="action"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="formatProvider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Is<T>(this string str, IgnoreCase ignoreCase = IgnoreCase.FALSE, Action<T> action = null,
            string format = null, NumberStyles? numberStyle = null, DateTimeStyles? dateTimeStyle = null, IFormatProvider formatProvider = null) where T : struct
        {
            return str.Is(typeof(T), ignoreCase, ValueConverter.ConvertAct(action), format, numberStyle, dateTimeStyle, formatProvider);
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Is<T>(this string str, Action<T> action = null) where T : class =>
            str.Is(typeof(T), IgnoreCase.FALSE, o => action?.Invoke(o.As<T>()));
    }
}