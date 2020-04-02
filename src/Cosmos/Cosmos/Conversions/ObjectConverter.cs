using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AspectCore.Extensions.Reflection;
using Cosmos.Conversions.StringDeterminers;

namespace Cosmos.Conversions {
    /// <summary>
    /// Object Conversion Utilities
    /// </summary>
    public static class ObjectConverter {
        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj) => obj?.ToString() ?? string.Empty;

        /// <summary>
        /// Convert from an <see cref="object"/> to another type of <see cref="object"/> instance.
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object To(object fromObj, Type targetType) => To(fromObj, targetType, targetType.GetDefaultValue());

        /// <summary>
        /// Convert from an <see cref="object"/> to another type of <see cref="object"/> instance.
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="targetType"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static object To(object fromObj, Type targetType, object defaultVal) {

            if (fromObj is null)
                return defaultVal;

            if (fromObj is string && string.IsNullOrWhiteSpace(fromObj.ToString()))
                return defaultVal;
            
            var fromObjType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            try {
                if (fromObjType.Name.ToLower() == "guid")
                    return GuidConverter.ToGuid(fromObj);

                if (fromObjType.GetTypeInfo().IsEnum)
                    return Enum.Parse(fromObjType, fromObj.ToString());

                if (fromObj is string fromStr && decimal.TryParse(fromStr, out var decimalVal))
                    return Convert.ChangeType(decimalVal, fromObjType);

                if (fromObj is IConvertible)
                    return Convert.ChangeType(fromObj, fromObjType);

                return fromObj;

            } catch {

                return defaultVal;

            }
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to another type of <see cref="object"/> instance.
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="targetTypeInfo"></param>
        /// <returns></returns>
        public static object To(object fromObj, TypeInfo targetTypeInfo) => To(fromObj, targetTypeInfo.AsType(), default);

        /// <summary>
        /// Convert from an <see cref="object"/> to another type of <see cref="object"/> instance.
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="targetTypeInfo"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static object To(object fromObj, TypeInfo targetTypeInfo, object defaultVal) => To(fromObj, targetTypeInfo.AsType(), defaultVal);

        /// <summary>
        /// Convert from an <see cref="object"/> to a TTo instance.
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObj"></param>
        /// <returns></returns>
        public static TTo To<TTo>(object fromObj) => To<TTo>(fromObj, default);

        /// <summary>
        /// Convert from an <see cref="object"/> to a TTo instance.
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TTo To<TTo>(object fromObj, TTo defaultValue) {
            try {
                return (TTo) To(fromObj, typeof(TTo), defaultValue);
            } catch {
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert from string to a TTo instances list.
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="listStr"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static IEnumerable<TTo> ToList<TTo>(string listStr, char splitChar = ',') {

            var results = new List<TTo>();

            if (string.IsNullOrWhiteSpace(listStr)) {
                return results;
            }

            var array = listStr.Split(splitChar);
            results.AddRange(from each in array where !string.IsNullOrWhiteSpace(each) select To<TTo>(each));

            return results;
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj, DateTime defaultVal = default) {

            if (obj is null)
                return defaultVal;

            if (obj is string str)
                return StringDateTimeDeterminer.To(str);
            
            str = obj.ToString();
            if (StringDateTimeDeterminer.Is(str))
                return StringDateTimeDeterminer.To(str, defaultVal: defaultVal);

            try {
                return Convert.ToDateTime(obj);
            } catch {
                return defaultVal;
            }
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(object obj) {

            if (obj is null)
                return null;

            if (obj is string str && StringDateTimeDeterminer.Is(str))
                return StringDateTimeDeterminer.To(str);

            str = obj.ToString();
            if (StringDateTimeDeterminer.Is(str))
                return StringDateTimeDeterminer.To(str);

            if (DateTime.TryParse(str, out var ret))
                return ret;

            return null;
        }
    }
}