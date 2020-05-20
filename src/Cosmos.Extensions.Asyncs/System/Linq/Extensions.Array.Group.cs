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
        /// <summary>
        /// Group by
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<IGrouping<TKey, TSource>>> GroupBy<TSource, TKey>(
            this Task<TSource[]> source,
            Func<TSource, TKey> keySelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, Enumerable.GroupBy, cancellationToken);
        }

        /// <summary>
        /// Group by
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<IGrouping<TKey, TSource>>> GroupBy<TSource, TKey>(
            this Task<TSource[]> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, comparer, Enumerable.GroupBy, cancellationToken);
        }

        /// <summary>
        /// Group by
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<IGrouping<TKey, TElement>>> GroupBy<TSource, TKey, TElement>(
            this Task<TSource[]> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, elementSelector, Enumerable.GroupBy, cancellationToken);
        }

        /// <summary>
        /// Group by
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<IGrouping<TKey, TElement>>> GroupBy<TSource, TKey, TElement>(
            this Task<TSource[]> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, elementSelector, comparer, Enumerable.GroupBy, cancellationToken);
        }

        /// <summary>
        /// Group by
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="resultSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TResult>(
            this Task<TSource[]> source,
            Func<TSource, TKey> keySelector,
            Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, resultSelector, Enumerable.GroupBy, cancellationToken);
        }

        /// <summary>
        /// Group by
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="resultSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TElement, TResult>(
            this Task<TSource[]> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, elementSelector, resultSelector, Enumerable.GroupBy, cancellationToken);
        }

        /// <summary>
        /// Group by
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="resultSelector"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TResult>(
            this Task<TSource[]> source,
            Func<TSource, TKey> keySelector,
            Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, resultSelector, comparer, Enumerable.GroupBy, cancellationToken);
        }

        /// <summary>
        /// Group by
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="resultSelector"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TElement, TResult>(
            this Task<TSource[]> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, elementSelector, resultSelector, comparer, Enumerable.GroupBy, cancellationToken);
        }

        /// <summary>
        /// Group join
        /// </summary>
        /// <param name="outer"></param>
        /// <param name="inner"></param>
        /// <param name="outerKeySelector"></param>
        /// <param name="innerKeySelector"></param>
        /// <param name="resultSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TOuter"></typeparam>
        /// <typeparam name="TInner"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(
            this Task<TOuter[]> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(outer, inner, outerKeySelector, innerKeySelector, resultSelector, Enumerable.GroupJoin, cancellationToken);
        }

        /// <summary>
        /// Group join
        /// </summary>
        /// <param name="outer"></param>
        /// <param name="inner"></param>
        /// <param name="outerKeySelector"></param>
        /// <param name="innerKeySelector"></param>
        /// <param name="resultSelector"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TOuter"></typeparam>
        /// <typeparam name="TInner"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(
            this Task<TOuter[]> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer, Enumerable.GroupJoin, cancellationToken);
        }
    }
}