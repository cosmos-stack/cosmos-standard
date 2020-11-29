using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Cosmos.Optionals.Internals;
using Cosmos.Reflection;
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
        /// Return a safe <see cref="string"/> value.
        /// 获取 Null安全 的字符串
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static string SafeValue(this string @string) => Strings.AvoidNull(@string).Trim();

        /// <summary>
        /// Return a safe <see cref="Encoding"/> value.<br />
        /// 返回一个 <see cref="Encoding"/> 安全值。
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static Encoding SafeValue(this Encoding encoding) => encoding ?? Encoding.UTF8;

        /// <summary>
        /// Return a safe <see cref="Encoding"/> value.<br />
        /// 返回一个 <see cref="Encoding"/> 安全值。
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Encoding SafeValue(this Encoding encoding, Encoding defaultVal) => encoding ?? defaultVal ?? Encoding.UTF8;

        #endregion

        #region SafeString

        /// <summary>
        /// Return a safe <see cref="string"/> value.<br />
        /// 安全获取字符串类型
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static string SafeString(this object @object)
        {
            return @object switch
            {
                string str => str.SafeValue(),
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
        public static string SafeString(this object @object, string defaultVal)
        {
            var @string = @object.SafeString();
            return string.IsNullOrWhiteSpace(@string) ? defaultVal : @string;
        }

        /// <summary>
        /// To remove space and return a safe <see cref="string"/> value.<br />
        /// 安全移除空白字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SafeTrim(this string str) => str?.Trim();

        #endregion

        #region SafeDateTime

        /// <summary>
        /// Return a safe <see cref="DateTime"/> value.<br />
        /// 获取安全时间类型
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static DateTime? SafeDateTime(this object @object)
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
        public static DateTime SafeDateTime(this object @object, DateTime defaultValue) =>
            @object.SafeDateTime().SafeValue(defaultValue);

        #endregion

        #region SafeGuid

        /// <summary>
        /// Return a safe <see cref="Guid"/> value.<br />
        /// 获取安全的 Guid 类型
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static Guid? SafeGuid(this object @object) => @object as Guid?;

        /// <summary>
        /// Return a safe <see cref="Guid"/> value.<br />
        /// 获取安全的 Guid 类型
        /// </summary>
        /// <param name="object"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Guid SafeGuid(this object @object, Guid defaultValue) => @object.SafeGuid().SafeValue(defaultValue);

        #endregion

        #region SafeQueryable

        /// <summary>
        /// Return a safe <see cref="IQueryable{T}"/> value.<br />
        /// 安全获得 <see cref="IQueryable{T}"/> 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable<T> SafeQueryable<T>(this IQueryable<T> @query) =>
            CollectionHelper.IsNullOrEmpty(query) ? new List<T>().AsQueryable() : query;

        /// <summary>
        /// Return a safe <see cref="IQueryable{T}"/> value.<br />
        /// 安全获得 <see cref="IQueryable{T}"/> 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IQueryable<T> SafeQueryable<T>(this IEnumerable<T> enumerable) =>
            enumerable.AsQueryable().SafeQueryable();

        /// <summary>
        /// Return a safe <see cref="IQueryable{T}"/> value.<br />
        /// 安全获得 <see cref="IQueryable{T}"/> 集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable SafeQueryable(this IQueryable query) => 
            CollectionHelper.IsNullOrEmpty(query) ? new List<object>().AsQueryable() : query;

        /// <summary>
        /// Return a safe <see cref="IQueryable{T}"/> value.<br />
        /// 安全获得 <see cref="IQueryable{T}"/> 集合
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IQueryable SafeQueryable(this IEnumerable enumerable) =>
            enumerable.AsQueryable().SafeQueryable();

        #endregion

        #region SafeDictionary

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

        #region SafeType

        /// <summary>
        /// Return a non-nullable type version for the given <see cref="Type"/>.<br />
        /// 获取所给定的可空类型的不可空类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type SafeType(this Type type) => TypeConv.GetNonNullableType(type);

        #endregion
    }
}