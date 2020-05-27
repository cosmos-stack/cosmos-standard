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
        /// As enumerable async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> AsEnumerableAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.AsEnumerable, cancellationToken);
        }

        /// <summary>
        /// Concat async
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> ConcatAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, Enumerable.Concat, cancellationToken);
        }

        /// <summary>
        /// Default if empty async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> DefaultIfEmptyAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.DefaultIfEmpty, cancellationToken);
        }

        /// <summary>
        /// Default if empty async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> DefaultIfEmptyAsync<TSource>(
            this IEnumerable<TSource> source,
            TSource defaultValue,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, defaultValue, Enumerable.DefaultIfEmpty, cancellationToken);
        }

        /// <summary>
        /// Distinct async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> DistinctAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Distinct, cancellationToken);
        }

        /// <summary>
        /// Distinct async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> DistinctAsync<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, comparer, Enumerable.Distinct, cancellationToken);
        }

        /// <summary>
        /// Except async
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> ExceptAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, Enumerable.Except, cancellationToken);
        }

        /// <summary>
        /// Except async
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> ExceptAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, comparer, Enumerable.Except, cancellationToken);
        }

        /// <summary>
        /// Intersect async
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> IntersectAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, Enumerable.Intersect, cancellationToken);
        }

        /// <summary>
        /// Intersect async
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> IntersectAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, comparer, Enumerable.Intersect, cancellationToken);
        }

        /// <summary>
        /// Join async
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
        public static Task<IEnumerable<TResult>> JoinAsync<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(outer, inner, outerKeySelector, innerKeySelector, resultSelector, Enumerable.Join, cancellationToken);
        }

        /// <summary>
        /// Join async
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
        public static Task<IEnumerable<TResult>> JoinAsync<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer, IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer, Enumerable.Join, cancellationToken);
        }

        /// <summary>
        /// Reverse async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> ReverseAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Reverse, cancellationToken);
        }

        /// <summary>
        /// Union async
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> UnionAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, Enumerable.Union, cancellationToken);
        }

        /// <summary>
        /// Union async
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> UnionAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, comparer, Enumerable.Union, cancellationToken);
        }

        /// <summary>
        /// Where async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> WhereAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.Where, cancellationToken);
        }

        /// <summary>
        /// Where async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> WhereAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.Where, cancellationToken);
        }

        /// <summary>
        /// Zip async
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="resultSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> ZipAsync<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, resultSelector, Enumerable.Zip, cancellationToken);
        }
    }
}