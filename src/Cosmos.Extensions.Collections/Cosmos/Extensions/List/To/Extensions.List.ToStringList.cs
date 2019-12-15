using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Extensions of list
    /// </summary>
    public static partial class ListExtensions {
        /// <summary>
        /// To string list
        /// </summary>
        /// <param name="me"></param>
        /// <param name="stringConverter"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> ToStringList<T>(this IEnumerable<T> me, Func<T, string> stringConverter)
            => me.Select(stringConverter).ToList();
    }
}