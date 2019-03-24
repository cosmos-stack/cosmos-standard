using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class CollectionExtensions
    {
        public static string JoinToString(this IEnumerable<string> list, string delimiter)
        {
            if (list == null)
                return string.Empty;

            var listTyped = list as IList<string>;
            var sb = listTyped == null ? new StringBuilder() : new StringBuilder(listTyped.Sum(x => x.Length) + delimiter.Length * listTyped.Count);

            bool primero = true;

            foreach (var x in list)
            {
                if (primero)
                {
                    primero = false;
                }
                else
                {
                    sb.Append(delimiter);
                }
                sb.Append(x);
            }

            return sb.ToString();
        }

        public static string JoinToString<T>(this IEnumerable<T> list)
        {
            return list.JoinToString(",");
        }

        public static string JoinOnePerLine<T>(this IEnumerable<T> list)
        {
            return list.JoinToString(Environment.NewLine) + Environment.NewLine;
        }

        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter)
        {
            if (list == null)
                return string.Empty;

            var sb = list is IList<T> ? new StringBuilder(((IList<T>)list).Count * 5) : new StringBuilder();

            bool primero = true;

            foreach (T x in list)
            {
                if (primero)
                {
                    primero = false;
                }
                else
                {
                    sb.Append(delimiter);
                }
                sb.Append(x);
            }

            return sb.ToString();
        }

        public static string JoinToStringFormat<T>(this IEnumerable<T> list)
            where T : IFormattable
        {
            return list.JoinToStringFormat(",");
        }

        public static string JoinToStringFormat<T>(this IEnumerable<T> list, string delimiter)
            where T : IFormattable
        {
            return list.JoinToStringFormat(delimiter, null);
        }

        public static string JoinToStringFormat<T>(this IEnumerable<T> list, string delimiter, IFormatProvider info)
            where T : IFormattable
        {

            var sb = new StringBuilder();

            bool primero = true;

            foreach (T x in list)
            {
                if (primero)
                {
                    primero = false;
                }
                else
                {
                    sb.Append(delimiter);
                }
                sb.Append(x.ToString(null, info));
            }

            return sb.ToString();
        }
    }
}
