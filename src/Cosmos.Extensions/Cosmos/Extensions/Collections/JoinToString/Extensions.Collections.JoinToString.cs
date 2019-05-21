using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class CollectionExtensions
    {
        public static string JoinToString(this IEnumerable<string> list)
        {
            return JoinToString<string>(list, ",", t => true, s => s);
        }

        public static string JoinToString(this IEnumerable<string> list, string delimiter)
        {
            return JoinToString<string>(list, delimiter, t => true, s => s);
        }

        public static string JoinToString(this IEnumerable<string> list, Func<string, bool> predicate, Func<string, string> replaceFunc = null)
        {
            return JoinToString<string>(list, ",", predicate, s => s, replaceFunc);
        }

        public static string JoinToString(this IEnumerable<string> list, string delimiter, Func<string, bool> predicate, Func<string, string> replaceFunc = null)
        {
            return JoinToString<string>(list, delimiter, predicate, s => s, replaceFunc);
        }

        public static string JoinToString<T>(this IEnumerable<T> list)
        {
            return JoinToString(list, ",", t => true, t => $"{t}");
        }

        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter)
        {
            return JoinToString(list, delimiter, t => true, t => $"{t}");
        }

        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter, Func<T, bool> predicate, Func<T, T> replaceFunc = null)
        {
            return JoinToString(list, delimiter, predicate, s => $"{s}", replaceFunc);
        }

        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter, ITypeConverter<T, string> converter, Func<T, T> replaceFunc = null)
        {
            return JoinToString(list, delimiter, t => true, converter.To, replaceFunc);
        }

        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter, Func<T, string> to, Func<T, T> replaceFunc = null)
        {
            return JoinToString(list, delimiter, t => true, to, replaceFunc);
        }

        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter, Func<T, bool> predicate, ITypeConverter<T, string> converter, Func<T, T> replaceFunc = null)
        {
            return JoinToString(list, delimiter, predicate, converter.To, replaceFunc);
        }

        public static string JoinOnePerLine<T>(this IEnumerable<T> list)
        {
            return JoinToString(list, Environment.NewLine, t => true, t => $"{t}") + Environment.NewLine;
        }

        public static string JoinToStringFormat<T>(this IEnumerable<T> list) where T : IFormattable
        {
            return list.JoinToStringFormat(",");
        }

        public static string JoinToStringFormat<T>(this IEnumerable<T> list, string delimiter) where T : IFormattable
        {
            return list.JoinToStringFormat(delimiter, null);
        }

        public static string JoinToStringFormat<T>(this IEnumerable<T> list, string delimiter, IFormatProvider info) where T : IFormattable
        {
            return JoinToString(list, delimiter, t => true, t => t.ToString(null, info));
        }

        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter, Func<T, bool> predicate, Func<T, string> to, Func<T, T> replaceFunc = null)
        {
            if (list == null)
                return string.Empty;
            bool head = true;
            var sb = new StringBuilder();

            foreach (var item in list)
            {
                var checker = item;
                if (!(predicate?.Invoke(checker) ?? true))
                {
                    if (replaceFunc == null)
                        continue;
                    else
                        checker = replaceFunc(item);
                }

                if (head)
                {
                    head = false;
                }
                else
                {
                    sb.Append(delimiter);
                }

                sb.Append(to(checker));
            }

            return sb.ToString();
        }
    }
}
