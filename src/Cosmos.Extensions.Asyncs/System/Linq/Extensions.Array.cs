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

namespace System.Linq {
    /// <summary>
    /// Extensions for array
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// As enumerable{T}
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> AsEnumerable<TSource>(
            this Task<TSource[]> source,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.AsEnumerable, cancellationToken);
        }

        /// <summary>
        /// Cast to...
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> Cast<T, TResult>(
            this Task<T[]> source,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Cast<TResult>, cancellationToken);
        }

        /// <summary>
        /// Concat
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> Concat<TSource>(
            this Task<TSource[]> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(first, second, Enumerable.Concat, cancellationToken);
        }

        /// <summary>
        /// Default if empty
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(
            this Task<TSource[]> source,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.DefaultIfEmpty, cancellationToken);
        }

        /// <summary>
        /// Default if empty
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(
            this Task<TSource[]> source,
            TSource defaultValue,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(source, defaultValue, Enumerable.DefaultIfEmpty, cancellationToken);
        }

        /// <summary>
        /// Distinct
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> Distinct<TSource>(
            this Task<TSource[]> source,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Distinct, cancellationToken);
        }

        /// <summary>
        /// Distinct
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> Distinct<TSource>(
            this Task<TSource[]> source,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(source, comparer, Enumerable.Distinct, cancellationToken);
        }

        /// <summary>
        /// Except
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> Except<TSource>(
            this Task<TSource[]> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(first, second, Enumerable.Except, cancellationToken);
        }

        /// <summary>
        /// Except
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> Except<TSource>(
            this Task<TSource[]> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(first, second, comparer, Enumerable.Except, cancellationToken);
        }

        /// <summary>
        /// Intersect
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> Intersect<TSource>(
            this Task<TSource[]> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(first, second, Enumerable.Intersect, cancellationToken);
        }

        /// <summary>
        /// Intersect
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> Intersect<TSource>(
            this Task<TSource[]> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(first, second, comparer, Enumerable.Intersect, cancellationToken);
        }

        /// <summary>
        /// Join
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
        public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(
            this Task<TOuter[]> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(outer, inner, outerKeySelector, innerKeySelector, resultSelector, Enumerable.Join, cancellationToken);
        }

        /// <summary>
        /// Join
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
        public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(
            this Task<TOuter[]> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer, Enumerable.Join, cancellationToken);
        }

        /// <summary>
        /// Of type
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> OfType<T, TResult>(
            this Task<T[]> source,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.OfType<TResult>, cancellationToken);
        }

        /// <summary>
        /// Reverse
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> Reverse<TSource>(
            this Task<TSource[]> source,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Reverse, cancellationToken);
        }

        /// <summary>
        /// Union
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> Union<TSource>(
            this Task<TSource[]> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(first, second, Enumerable.Union, cancellationToken);
        }

        /// <summary>
        /// Union
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> Union<TSource>(
            this Task<TSource[]> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(first, second, comparer, Enumerable.Union, cancellationToken);
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> Where<TSource>(
            this Task<TSource[]> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Where, cancellationToken);
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> Where<TSource>(
            this Task<TSource[]> source,
            Func<TSource, int, bool> predicate,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Where, cancellationToken);
        }

        /// <summary>
        /// Zip
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="resultSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this Task<TFirst[]> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromTaskEnumerable(first, second, resultSelector, Enumerable.Zip, cancellationToken);
        }
    }
}