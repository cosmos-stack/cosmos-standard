using System;
using System.Globalization;
using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;
using Cosmos.Reflection;
using Cosmos.Text;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Cosmos casting extensions
    /// </summary>
    public static class CastingExtensions
    {
        #region 0

        /// <summary>
        /// Cast <see cref="object"/> to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object CastTo(this object obj, Type targetType) => XConv.To(obj, obj.GetType(), targetType, TypeDeterminer.GetDefaultValue(targetType));

        /// <summary>
        /// Cast <see cref="object"/> to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="targetType"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static object CastTo(this object obj, Type targetType, object defaultVal) => XConv.To(obj, obj.GetType(), targetType, defaultVal);

        /// <summary>
        /// Cast <see cref="object"/> to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="sourceType"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object CastTo(this object obj, Type sourceType, Type targetType) => XConv.To(obj, sourceType, targetType);

        /// <summary>
        /// Cast <see cref="object"/> to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="sourceType"></param>
        /// <param name="targetType"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static object CastTo(this object obj, Type sourceType, Type targetType, object defaultVal) => XConv.To(obj, sourceType, targetType, defaultVal);

        /// <summary>
        /// Cast <see cref="object"/> to the given type of <see cref="Enum"/>.
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="enumTye"></param>
        /// <param name="validation"></param>
        /// <returns></returns>
        public static object CastTo(object fromObj, Type enumTye, EnumsNET.EnumValidation validation) => EnumsNET.Enums.ToObject(enumTye, fromObj, validation);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="targetType"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static object CastTo(this string str, Type targetType, object defaultVal = default) =>
            XConv.To(str, TypeClass.StringClazz, targetType, defaultVal);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="targetType"></param>
        /// <param name="defaultVal"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static object CastTo(this string str, Type targetType, CastingContext context, object defaultVal = default) =>
            XConv.To(str, TypeClass.StringClazz, targetType, defaultVal, context);

        /// <summary>
        /// Cast to nullable
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static object CastToNullable(this string str, Type type, CastingContext context = null)
        {
            object result = default;
            context ??= CastingContext.DefaultContext;

            return str.IsNullable(type, (t) => result = t, () => result = null,
                context.IgnoreCase.X(), context.Format, context.NumberStyles, context.DateTimeStyles, context.FormatProvider)
                ? result
                : null;
        }

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyles"></param>
        /// <param name="dateTimeStyles"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static object CastToNullable(this string str, Type type, IgnoreCase ignoreCase,
            string format = null, NumberStyles? numberStyles = null, DateTimeStyles? dateTimeStyles = null,
            IFormatProvider formatProvider = null)
        {
            object result = default;
            return str.IsNullable(type, (t) => result = t, () => result = null,
                ignoreCase.X(), format, numberStyles, dateTimeStyles, formatProvider)
                ? result
                : null;
        }

        #endregion

        #region 1

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

        #endregion

        #region 2

        /// <summary>
        /// Cast <see cref="object"/> to the TEnum.
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="validation"></param>
        /// <typeparam name="TObject"></typeparam>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static TEnum CastTo<TObject, TEnum>(TObject fromObj, EnumsNET.EnumValidation validation) where TEnum : struct, Enum =>
            EnumsNET.Enums.ToObject<TEnum>(fromObj, validation);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <returns></returns>
        public static TTo CastTo<TFrom, TTo>(TFrom fromObj, TTo defaultVal = default) => XConv.To(fromObj, defaultVal);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="context"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <returns></returns>
        public static TTo CastTo<TFrom, TTo>(TFrom fromObj, CastingContext context, TTo defaultVal = default) => XConv.To(fromObj, defaultVal, context);

        #endregion
    }
}