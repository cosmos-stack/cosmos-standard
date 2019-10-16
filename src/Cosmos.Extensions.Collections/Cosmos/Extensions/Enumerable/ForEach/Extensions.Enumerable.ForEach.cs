using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// 对集合内每一项元素都进行一次操作
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ForEachItem<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action?.Invoke(item);
                yield return item;
            }
        }
    }
}