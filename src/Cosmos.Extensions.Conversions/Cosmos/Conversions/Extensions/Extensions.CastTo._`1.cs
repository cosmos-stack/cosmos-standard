using System;
using System.Globalization;
using Cosmos.Conversions.Core;
using Cosmos.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions
{
    /// <summary>
    /// Extensions for CastTo opts
    /// </summary>
    public static partial class CastToExtensions
    {
        /// <summary>
        /// Convert object to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CastTo<T>(this object obj) =>
            XConv.To(obj, obj?.GetType() ?? typeof(object), typeof(T)).As<T>();

        /// <summary>
        /// Convert object to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CastTo<T>(this object obj, T defaultVal) =>
            XConv.To(obj, obj?.GetType() ?? typeof(object), typeof(T), defaultVal).As<T>();

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CastTo<T>(this string str, T defaultVal = default) where T : class => XConv.To(str, defaultVal);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="context"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CastTo<T>(this string str, CastingContext context, T defaultVal = default) where T : class =>
            XConv.To(str, defaultVal, context);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="defaultVal"></param>
        /// <param name="format"></param>
        /// <param name="numberStyles"></param>
        /// <param name="dateTimeStyles"></param>
        /// <param name="formatProvider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CastTo<T>(this string str, IgnoreCase ignoreCase, T defaultVal = default,
            string format = null, NumberStyles? numberStyles = null, DateTimeStyles? dateTimeStyles = null,
            IFormatProvider formatProvider = null) where T : struct
        {
            T result = default;
            return str.Is<T>(ignoreCase, t => result = t, format, numberStyles, dateTimeStyles, formatProvider)
                ? result
                : defaultVal;
        }

        /// <summary>
        /// Cast to nullable
        /// </summary>
        /// <param name="str"></param>
        /// <param name="context"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? CastToNullable<T>(this string str, CastingContext context = default) where T : struct
        {
            T? result = default;
            context ??= CastingContext.DefaultContext;

            return str.IsNullable<T>((t) => result = t, () => result = null,
                context.IgnoreCase.X(), context.Format, context.NumberStyles, context.DateTimeStyles, context.FormatProvider)
                ? result
                : null;
        }

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyles"></param>
        /// <param name="dateTimeStyles"></param>
        /// <param name="formatProvider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? CastToNullable<T>(this string str, IgnoreCase ignoreCase,
            string format = null, NumberStyles? numberStyles = null, DateTimeStyles? dateTimeStyles = null,
            IFormatProvider formatProvider = null) where T : struct
        {
            T? result = default;
            return str.IsNullable<T>((t) => result = t, () => result = null,
                ignoreCase.X(), format, numberStyles, dateTimeStyles, formatProvider)
                ? result
                : null;
        }
    }
}