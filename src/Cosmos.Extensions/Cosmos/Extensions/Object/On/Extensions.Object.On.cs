using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    public static partial class ObjectExtensions {
        /// <summary>
        /// Is On
        /// </summary>
        /// <param name="source"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsOn(this byte source, params byte[] list) => IsOn<byte>(source, list);

        /// <summary>
        /// Is On
        /// </summary>
        /// <param name="source"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsOn(this short source, params short[] list) => IsOn<short>(source, list);

        /// <summary>
        /// Is On
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsOn<T>(this T source, params T[] list) where T : IComparable => list.Any(t => t.CompareTo(source) == 0);

        /// <summary>
        /// Is On
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsOn<T>(this T source, IEnumerable<T> list) where T : IComparable => list.Any(item => item.CompareTo(source) == 0);

        /// <summary>
        /// Is On
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsOn<T>(this T source, HashSet<T> list) where T : IComparable => list.Contains(source);

        /// <summary>
        /// Is On and ignore case
        /// </summary>
        /// <param name="source"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsOnIgnoreCase(this string source, params string[] list) => list.Any(source.EqualsIgnoreCase);
    }
}