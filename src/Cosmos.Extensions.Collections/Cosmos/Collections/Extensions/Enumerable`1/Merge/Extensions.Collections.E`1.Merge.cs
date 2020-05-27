using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    public static partial class CollectionExtensions
    {
        /// <summary>
        /// Merge<br />
        /// 合并集合
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            if (left is null) throw new ArgumentNullException(nameof(left));
            foreach (var item in left)
                yield return item;
            if (right is null)
                yield break;
            foreach (var item in right)
                yield return item;
        }

        /// <summary>
        /// Merge<br />
        /// 合并集合
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="limit"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> left, IEnumerable<T> right, int limit)
        {
            if (left is null) throw new ArgumentNullException(nameof(left));
            foreach (var item in left)
                yield return item;
            if (right is null)
                yield break;
            if (limit <= 0)
            {
                foreach (var item in right)
                    yield return item;
            }
            else
            {
                var counter = 0;
                foreach (var item in right)
                {
                    if (counter++ >= limit)
                        yield break;
                    yield return item;
                }
            }
        }
    }
}