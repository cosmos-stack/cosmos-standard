// Description: Async extension methods for LINQ (Language Integrated Query).
// Website & Documentation: https://github.com/zzzprojects/LINQ-Async
// Forum: https://github.com/zzzprojects/LINQ-Async/issues
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Collections.Generic;
using System.Linq.Async;
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
        public static Task<IEnumerable<TSource>> AsEnumerable<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.AsEnumerable, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> Cast<T, TResult>(
            this Task<AsyncWhereEnumerable<T>> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Cast<TResult>, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> Concat<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(first, second, Enumerable.Concat, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.DefaultIfEmpty, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> source,
            TSource defaultValue,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, defaultValue, Enumerable.DefaultIfEmpty, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> Distinct<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Distinct, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> Distinct<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> source,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, comparer, Enumerable.Distinct, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> Except<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(first, second, Enumerable.Except, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> Except<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(first, second, comparer, Enumerable.Except, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> Intersect<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(first, second, Enumerable.Intersect, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> Intersect<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(first, second, comparer, Enumerable.Intersect, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(
            this Task<AsyncWhereEnumerable<TOuter>> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(outer, inner, outerKeySelector, innerKeySelector, resultSelector, Enumerable.Join, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(
            this Task<AsyncWhereEnumerable<TOuter>> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer, Enumerable.Join, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> OfType<T, TResult>(
            this Task<AsyncWhereEnumerable<T>> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.OfType<TResult>, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> Reverse<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Reverse, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> Union<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(first, second, Enumerable.Union, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> Union<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> first,
            IEnumerable<TSource> second, IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(first, second, comparer, Enumerable.Union, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> Where<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Where, cancellationToken);
        }

        public static Task<IEnumerable<TSource>> Where<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> source,
            Func<TSource, int, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Where, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this Task<AsyncWhereEnumerable<TFirst>> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(first, second, resultSelector, Enumerable.Zip, cancellationToken);
        }
    }
}
