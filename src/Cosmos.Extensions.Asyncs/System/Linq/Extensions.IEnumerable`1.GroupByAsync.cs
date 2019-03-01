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
        public static Task<IEnumerable<IGrouping<TKey, TSource>>> GroupByAsync<TSource, TKey>(
         this IEnumerable<TSource> source,
         Func<TSource, TKey> keySelector,
         CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, Enumerable.GroupBy, cancellationToken);
        }

        public static Task<IEnumerable<IGrouping<TKey, TSource>>> GroupByAsync<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, comparer, Enumerable.GroupBy, cancellationToken);
        }

        public static Task<IEnumerable<IGrouping<TKey, TElement>>> GroupByAsync<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, elementSelector, Enumerable.GroupBy, cancellationToken);
        }

        public static Task<IEnumerable<IGrouping<TKey, TElement>>> GroupByAsync<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, elementSelector, comparer, Enumerable.GroupBy, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> GroupByAsync<TSource, TKey, TResult>(
             this IEnumerable<TSource> source,
             Func<TSource, TKey> keySelector,
             Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
             CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, resultSelector, Enumerable.GroupBy, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> GroupByAsync<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, elementSelector, resultSelector, Enumerable.GroupBy, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> GroupByAsync<TSource, TKey, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, resultSelector, comparer, Enumerable.GroupBy, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> GroupByAsync<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, elementSelector, resultSelector, comparer, Enumerable.GroupBy, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> GroupJoinAsync<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(outer, inner, outerKeySelector, innerKeySelector, resultSelector, Enumerable.GroupJoin, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> GroupJoinAsync<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer, Enumerable.GroupJoin, cancellationToken);
        }
    }
}
