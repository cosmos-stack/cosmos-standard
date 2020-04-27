using System;
using System.Globalization;
using System.Reflection;
using Cosmos.Conversions;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// Conversion extensions
    /// </summary>
    public static partial class ConversionExtensions {

        /// <summary>
        /// Convert object to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object CastTo(this object obj, Type targetType) => ObjectConverter.To(obj, targetType);

        /// <summary>
        /// Convert object to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="targetType"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static object CastTo(this object obj, Type targetType, object defaultVal) => ObjectConverter.To(obj, targetType, defaultVal);

        /// <summary>
        /// Convert object to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object CastTo(this object obj, TypeInfo targetType) => ObjectConverter.To(obj, targetType);

        /// <summary>
        /// Convert object to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="targetType"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static object CastTo(this object obj, TypeInfo targetType, object defaultVal) => ObjectConverter.To(obj, targetType, defaultVal);

        /// <summary>
        /// Convert object to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CastTo<T>(this object obj) => ObjectConverter.To<T>(obj);

        /// <summary>
        /// Convert object to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CastTo<T>(this object obj, T defaultVal) => ObjectConverter.To(obj, defaultVal);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="enumTye"></param>
        /// <param name="validation"></param>
        /// <returns></returns>
        public static object CastTo(object fromObj, Type enumTye, EnumValidation validation) => EnumsNET.Enums.ToObject(enumTye, fromObj, validation);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="formatProvider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CastTo<T>(
            this string str,
            IgnoreCase ignoreCase = IgnoreCase.FALSE,
            T defaultVal = default,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider formatProvider = null) where T : struct {

            T result = default;

            return str.Is<T>(ignoreCase, t => result = t, format, numberStyle, dateTimeStyle, formatProvider)
                ? result
                : defaultVal;
        }

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CastTo<T>(this string str, T defaultVal = default) where T : class {
            T result = default;
            return str.Is<T>(t => result = t) ? result : defaultVal;
        }

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="context"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CastTo<T>(this string str, CastingContext context = default, T defaultVal = default) where T : class =>
            str.CastTo(typeof(T), context, defaultVal).AsOrDefault(defaultVal);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <param name="defaultVal"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static object CastTo(this string str, Type type, CastingContext context = default, object defaultVal = default) {
            if (context is null)
                context = DefaultContext;

            return CastTo(
                str,
                type,
                context.IgnoreCase,
                defaultVal,
                context.Format,
                context.NumberStyles,
                context.DateTimeStyles,
                context.FormatProvider);
        }

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <param name="defaultVal"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static object CastTo(
            this string str,
            Type type,
            IgnoreCase ignoreCase = IgnoreCase.FALSE,
            object defaultVal = default,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider formatProvider = null) {

            object result = default;

            if (type.IsValueType && defaultVal is null)
                defaultVal = Activator.CreateInstance(type);

            return str.Is(type, ignoreCase, t => result = t, format, numberStyle, dateTimeStyle, formatProvider)
                ? result
                : defaultVal;
        }

        /// <summary>
        /// Cast to nullable
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="formatProvider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? CastToNullable<T>(
            this string str,
            IgnoreCase ignoreCase = IgnoreCase.FALSE,
            T? defaultVal = default,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider formatProvider = null) where T : struct {

            T? result = default;

            return str.IsNullable<T>((t) => result = t, () => result = null, ignoreCase.X(), format, numberStyle, dateTimeStyle, formatProvider)
                ? result
                : defaultVal;
        }

        /// <summary>
        /// Cast to nullable
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="defaultVal"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static object CastToNullable(
            this string str,
            Type type,
            IgnoreCase ignoreCase = IgnoreCase.FALSE,
            object defaultVal = default,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider formatProvider = null) {

            object result = default;

            return str.IsNullable(type, (t) => result = t, () => result = null, ignoreCase.X(), format, numberStyle, dateTimeStyle, formatProvider)
                ? result
                : defaultVal;
        }
    }
}