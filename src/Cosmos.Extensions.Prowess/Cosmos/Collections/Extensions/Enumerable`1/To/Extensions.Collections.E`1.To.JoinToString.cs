using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Joiners;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Collection extensions
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Join to string
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string JoinToString(this IEnumerable<string> list) =>
            JoinToString<string>(list, ",", t => true, s => s);

        /// <summary>
        /// Join to string
        /// </summary>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string JoinToString(this IEnumerable<string> list, string delimiter) =>
            JoinToString<string>(list, delimiter, t => true, s => s);

        /// <summary>
        /// Join to string
        /// </summary>
        /// <param name="list"></param>
        /// <param name="predicate"></param>
        /// <param name="replaceFunc"></param>
        /// <returns></returns>
        public static string JoinToString(this IEnumerable<string> list, Func<string, bool> predicate, Func<string, string> replaceFunc = null) =>
            JoinToString(list, ",", predicate, s => s, replaceFunc);

        /// <summary>
        /// Join to string
        /// </summary>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <param name="predicate"></param>
        /// <param name="replaceFunc"></param>
        /// <returns></returns>
        public static string JoinToString(this IEnumerable<string> list, string delimiter, Func<string, bool> predicate, Func<string, string> replaceFunc = null) =>
            JoinToString(list, delimiter, predicate, s => s, replaceFunc);

        /// <summary>
        /// Join to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string JoinToString<T>(this IEnumerable<T> list) =>
            JoinToString(list, ",", t => true, t => $"{t}");

        /// <summary>
        /// Join to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter) =>
            JoinToString(list, delimiter, t => true, t => $"{t}");

        /// <summary>
        /// Join to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <param name="predicate"></param>
        /// <param name="replaceFunc"></param>
        /// <returns></returns>
        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter, Func<T, bool> predicate, Func<T, T> replaceFunc = null) =>
            JoinToString(list, delimiter, predicate, s => $"{s}", replaceFunc);

        /// <summary>
        /// Join to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <param name="converter"></param>
        /// <param name="replaceFunc"></param>
        /// <returns></returns>
        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter, ITypeConverter<T, string> converter, Func<T, T> replaceFunc = null) =>
            JoinToString(list, delimiter, t => true, converter.To, replaceFunc);

        /// <summary>
        /// Join to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <param name="to"></param>
        /// <param name="replaceFunc"></param>
        /// <returns></returns>
        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter, Func<T, string> to, Func<T, T> replaceFunc = null) =>
            JoinToString(list, delimiter, t => true, to, replaceFunc);

        /// <summary>
        /// Join to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <param name="predicate"></param>
        /// <param name="converter"></param>
        /// <param name="replaceFunc"></param>
        /// <returns></returns>
        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter, Func<T, bool> predicate, ITypeConverter<T, string> converter,
            Func<T, T> replaceFunc = null) =>
            JoinToString(list, delimiter, predicate, converter.To, replaceFunc);

        /// <summary>
        /// Join to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string JoinOnePerLine<T>(this IEnumerable<T> list) =>
            JoinToString(list, Environment.NewLine, t => true, t => $"{t}") + Environment.NewLine;

        /// <summary>
        /// Join to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string JoinToStringFormat<T>(this IEnumerable<T> list) where T : IFormattable =>
            list.JoinToStringFormat(",");

        /// <summary>
        /// Join to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string JoinToStringFormat<T>(this IEnumerable<T> list, string delimiter) where T : IFormattable =>
            list.JoinToStringFormat(delimiter, null);

        /// <summary>
        /// Join to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string JoinToStringFormat<T>(this IEnumerable<T> list, string delimiter, IFormatProvider info) where T : IFormattable =>
            JoinToString(list, delimiter, t => true, t => t.ToString(null, info));

        /// <summary>
        /// Join to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <param name="predicate"></param>
        /// <param name="to"></param>
        /// <param name="replaceFunc"></param>
        /// <returns></returns>
        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter, Func<T, bool> predicate, Func<T, string> to, Func<T, T> replaceFunc = null)
        {
            if (list is null)
                return string.Empty;

            var sb = new StringBuilder();

            CommonJoinUtils.JoinToString(sb, (c, s) => c.Append(s), list, delimiter, predicate, to, replaceFunc);

            return sb.ToString();
        }
    }
}