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
        /// Cast <see cref="object"/> to given type.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object CastTo(this object obj, Type targetType) => XConv.To(obj, obj.GetType(), targetType, TypeHelper.GetDefaultValue(targetType));

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
            XConv.To(str, TypeClass.StringClass, targetType, defaultVal);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="str"></param>
        /// <param name="targetType"></param>
        /// <param name="defaultVal"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static object CastTo(this string str, Type targetType, CastingContext context, object defaultVal = default) =>
            XConv.To(str, TypeClass.StringClass, targetType, defaultVal, context);

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
    }
}