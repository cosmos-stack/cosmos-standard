// Description: Async extension methods for LINQ (Language Integrated Query).
// Website & Documentation: https://github.com/zzzprojects/LINQ-Async
// Forum: https://github.com/zzzprojects/LINQ-Async/issues
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/*
 * Reference to:
 *  ZZZProjects/LINQ-Async
 *  Author: JonathanMagnan
 *  URL: https://github.com/zzzprojects/LINQ-Async
 *  MIT
 */

namespace System.Linq
{
    public static partial class Extensions
    {
        public static Task<IOrderedEnumerable<TSource>> ThenByAsync<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, Enumerable.ThenBy, cancellationToken);
        }

        public static Task<IOrderedEnumerable<TSource>> ThenByAsync<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, comparer, Enumerable.ThenBy, cancellationToken);
        }

        public static Task<IOrderedEnumerable<TSource>> ThenByDescendingAsync<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, Enumerable.ThenByDescending, cancellationToken);
        }

        public static Task<IOrderedEnumerable<TSource>> ThenByDescendingAsync<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, comparer, Enumerable.ThenByDescending, cancellationToken);
        }
    }
}
