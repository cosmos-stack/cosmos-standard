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
        public static Task<IEnumerable<TSource>> AsEnumerableAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.AsEnumerable, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> ConcatAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, Enumerable.Concat, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> DefaultIfEmptyAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.DefaultIfEmpty, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> DefaultIfEmptyAsync<TSource>(
            this IEnumerable<TSource> source,
            TSource defaultValue,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, defaultValue, Enumerable.DefaultIfEmpty, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> DistinctAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Distinct, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> DistinctAsync<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, comparer, Enumerable.Distinct, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> ExceptAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, Enumerable.Except, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> ExceptAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, comparer, Enumerable.Except, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> IntersectAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, Enumerable.Intersect, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> IntersectAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, comparer, Enumerable.Intersect, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> JoinAsync<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(outer, inner, outerKeySelector, innerKeySelector, resultSelector, Enumerable.Join, cancellationToken);
        }

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

        public static Task<IEnumerable<TSource>> ReverseAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Reverse, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> UnionAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, Enumerable.Union, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> UnionAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, comparer, Enumerable.Union, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> WhereAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.Where, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> WhereAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.Where, cancellationToken);
        }

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
