using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Cosmos.Optionals.Internals;
using Cosmos.Text;

namespace Cosmos.Optionals
{
    /// <summary>
    /// Optionals extensions
    /// </summary>
    public static class SafeValueExtensions
    {
        #region SafeValue

        /// <summary>
        /// Return a safe value<br />
        /// 安全返回值
        /// </summary>
        /// <param name="value"> 可空值 </param>
        public static T SafeValue<T>(this T? value) where T : struct => value.GetValueOrDefault();

        /// <summary>
        /// Return a safe value<br />
        /// 安全返回值
        /// <para>如果可空值真为空，则返回默认值</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T SafeValue<T>(this T? value, T defaultValue) where T : struct => value.GetValueOrDefault(defaultValue);

        /// <summary>
        /// Return a safe value<br />
        /// 安全返回值
        /// <para>如果可空值真为空，则返回默认值</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValFunc"></param>
        /// <returns></returns>
        public static T SafeValue<T>(this T? value, Func<T> defaultValFunc) where T : struct => value.GetValueOrDefault(defaultValFunc?.Invoke() ?? default);

        /// <summary>
        /// Return a safe value<br />
        /// 安全返回值
        /// <para>如果可空值真为空，则返回默认值</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="condition"></param>
        /// <param name="defaultValFunc"></param>
        /// <param name="elseValFunc"></param>
        /// <returns></returns>
        public static T SafeValue<T>(this T? value, Func<T?, bool> condition, Func<T> defaultValFunc, Func<T> elseValFunc) where T : struct
        {
            if (condition?.Invoke(value) ?? false)
                return defaultValFunc?.Invoke() ?? default;
            return value.SafeValue(elseValFunc);
        }

        /// <summary>
        /// Return a safe value<br />
        /// 安全返回值
        /// </summary>
        /// <param name="value"> 可空值 </param>
        /// <param name="result"></param>
        public static bool TrySafeValue<T>(this T? value, out T result) where T : struct
        {
            result = value ?? default;
            return value.HasValue;
        }

        #endregion

        #region SafeRefValue

        /// <summary>
        /// Return a safe value<br />
        /// 安全返回值
        /// <para>如果可空值真为空，则返回默认值</para>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeRefValue<T>(this T value, T defaultValue) where T : class => value ?? defaultValue;

        /// <summary>
        /// Return a safe value<br />
        /// 安全返回值
        /// <para>如果可空值真为空，则返回默认值</para>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeRefValue<T>(this T value, Func<T> defaultValFunc) where T : class => value ?? (defaultValFunc?.Invoke() ?? default(T));

        /// <summary>
        /// Return a safe value<br />
        /// 安全返回值
        /// <para>如果可空值真为空，则返回默认值</para>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="condition"></param>
        /// <param name="defaultValFunc"></param>
        /// <param name="elseValFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeRefValue<T>(this T value, Func<T, bool> condition, Func<T> defaultValFunc, Func<T> elseValFunc) where T : class
        {
            if (condition?.Invoke(value) ?? false)
                return defaultValFunc?.Invoke();
            return value.SafeRefValue(elseValFunc);
        }

        #endregion

        #region SafeEncodingValue

        /// <summary>
        /// Return a safe <see cref="Encoding"/> value.<br />
        /// 返回一个 <see cref="Encoding"/> 安全值。
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static Encoding SafeEncodingValue(this Encoding encoding) => encoding ?? Encoding.UTF8;

        /// <summary>
        /// Return a safe <see cref="Encoding"/> value.<br />
        /// 返回一个 <see cref="Encoding"/> 安全值。
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Encoding SafeEncodingValue(this Encoding encoding, Encoding defaultVal) => encoding ?? defaultVal ?? Encoding.UTF8;

        #endregion

        #region SafeStringValue

        /// <summary>
        /// Return a safe <see cref="string"/> value.
        /// 获取 Null安全 的字符串
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static string SafeStringValue(this string @string) => Strings.AvoidNull(@string).Trim();

        /// <summary>
        /// Return a safe <see cref="string"/> value.<br />
        /// 安全获取字符串类型
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static string SafeStringValue(this object @object)
        {
            return @object switch
            {
                string str => str.SafeStringValue(),
                null => string.Empty,
                _ => @object.ToString()
            };
        }

        /// <summary>
        /// Return a safe <see cref="string"/> value.<br />
        /// 安全获取字符串类型
        /// </summary>
        /// <param name="object"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string SafeStringValue(this object @object, string defaultVal)
        {
            var @string = @object.SafeStringValue();
            return string.IsNullOrWhiteSpace(@string) ? defaultVal : @string;
        }

        /// <summary>
        /// To remove space and return a safe <see cref="string"/> value.<br />
        /// 安全移除空白字符
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string SafeTrimStringValue(this string text) => text?.Trim();

        #endregion

        #region SafeGroupValue

        /// <summary>
        /// To safe group value
        /// </summary>
        /// <param name="match"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string SafeGroupValue(this Match match, string name)
        {
            return match.Groups[name]?.Value;
        }

        #endregion

        #region SafeDateTimeValue

        /// <summary>
        /// Return a safe <see cref="DateTime"/> value.<br />
        /// 获取安全时间类型
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static DateTime? SafeDateTimeValue(this object @object)
        {
            if (@object is DateTime dateTime)
                return dateTime;
            return null;
        }

        /// <summary>
        /// Return a safe <see cref="DateTime"/> value.<br />
        /// 获取安全时间类型
        /// </summary>
        /// <param name="object"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime SafeDateTimeValue(this object @object, DateTime defaultValue) =>
            @object.SafeDateTimeValue().SafeValue(defaultValue);

        #endregion

        #region SafeGuidValue

        /// <summary>
        /// Return a safe <see cref="Guid"/> value.<br />
        /// 获取安全的 Guid 类型
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static Guid? SafeGuidValue(this object @object) => @object as Guid?;

        /// <summary>
        /// Return a safe <see cref="Guid"/> value.<br />
        /// 获取安全的 Guid 类型
        /// </summary>
        /// <param name="object"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Guid SafeGuidValue(this object @object, Guid defaultValue) => @object.SafeGuidValue().SafeValue(defaultValue);

        #endregion

        #region SafeQueryableValue

        /// <summary>
        /// Return a safe <see cref="IQueryable{T}"/> value.<br />
        /// 安全获得 <see cref="IQueryable{T}"/> 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable<T> SafeQueryableValue<T>(this IQueryable<T> @query) =>
            CollectionHelper.IsNullOrEmpty(query) ? new List<T>().AsQueryable() : query;

        /// <summary>
        /// Return a safe <see cref="IQueryable{T}"/> value.<br />
        /// 安全获得 <see cref="IQueryable{T}"/> 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IQueryable<T> SafeQueryableValue<T>(this IEnumerable<T> enumerable) =>
            enumerable.AsQueryable().SafeQueryableValue();

        /// <summary>
        /// Return a safe <see cref="IQueryable{T}"/> value.<br />
        /// 安全获得 <see cref="IQueryable{T}"/> 集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable SafeQueryableValue(this IQueryable query) =>
            CollectionHelper.IsNullOrEmpty(query) ? new List<object>().AsQueryable() : query;

        /// <summary>
        /// Return a safe <see cref="IQueryable{T}"/> value.<br />
        /// 安全获得 <see cref="IQueryable{T}"/> 集合
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IQueryable SafeQueryableValue(this IEnumerable enumerable) =>
            enumerable.AsQueryable().SafeQueryableValue();

        #endregion

        #region SafeDictionaryValue

        /// <summary>
        /// TryGetValue wrapper with option types.
        /// It returns Some of the value when a value for the give key is present
        /// or None other-side
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Maybe<TValue> TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key) =>
            source.TryGetValue(key, out var result)
                ? Optional.Some(result)
                : Optional.None<TValue>();

        #endregion
    }
}