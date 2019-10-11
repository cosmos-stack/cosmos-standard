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
        /// Aggregate async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> AggregateAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, TSource> func,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, func, Enumerable.Aggregate, cancellationToken);
        }

        /// <summary>
        /// Aggregate async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="seed"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TAccumulate"></typeparam>
        /// <returns></returns>
        public static Task<TAccumulate> AggregateAsync<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, seed, func, Enumerable.Aggregate, cancellationToken);
        }

        /// <summary>
        /// Aggregate async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="seed"></param>
        /// <param name="func"></param>
        /// <param name="resultSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TAccumulate"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> AggregateAsync<TSource, TAccumulate, TResult>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, seed, func, resultSelector, Enumerable.Aggregate,
                cancellationToken);
        }

        /// <summary>
        /// All async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> AllAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.All, cancellationToken);
        }

        /// <summary>
        /// Any async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> AnyAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Any, cancellationToken);
        }

        /// <summary>
        /// Any async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> AnyAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.Any, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double> AverageAsync(
            this IEnumerable<int> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double?> AverageAsync(
            this IEnumerable<int?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double> AverageAsync(
            this IEnumerable<long> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double?> AverageAsync(
            this IEnumerable<long?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float> AverageAsync(
            this IEnumerable<float> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float?> AverageAsync(
            this IEnumerable<float?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double> AverageAsync(
            this IEnumerable<double> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double?> AverageAsync(
            this IEnumerable<double?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal> AverageAsync(
            this IEnumerable<decimal> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal?> AverageAsync(
            this IEnumerable<decimal?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double> AverageAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double?> AverageAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double> AverageAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, long> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double?> AverageAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, long?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float> AverageAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, float> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float?> AverageAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, float?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double> AverageAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, double> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double?> AverageAsync<TSource>(this IEnumerable<TSource> source,
            Func<TSource, double?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal> AverageAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, decimal> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal?> AverageAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, decimal?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Contains async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> ContainsAsync<TSource>(
            this IEnumerable<TSource> source,
            TSource value,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, value, Enumerable.Contains, cancellationToken);
        }

        /// <summary>
        /// Contains async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> ContainsAsync<TSource>(
            this IEnumerable<TSource> source,
            TSource value,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, value, comparer, Enumerable.Contains, cancellationToken);
        }

        /// <summary>
        /// Count async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int> CountAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Count, cancellationToken);
        }

        /// <summary>
        /// Count async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int> CountAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.Count, cancellationToken);
        }

        /// <summary>
        /// Element at async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> ElementAtAsync<TSource>(
            this IEnumerable<TSource> source,
            int index,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, index, Enumerable.ElementAt, cancellationToken);
        }

        /// <summary>
        /// Element at or default async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> ElementAtOrDefaultAsync<TSource>(
            this IEnumerable<TSource> source,
            int index,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, index, Enumerable.ElementAtOrDefault, cancellationToken);
        }

        /// <summary>
        /// First async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> FirstAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.First, cancellationToken);
        }

        /// <summary>
        /// First async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> FirstAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.First, cancellationToken);
        }

        /// <summary>
        /// First or default async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> FirstOrDefaultAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.FirstOrDefault, cancellationToken);
        }

        /// <summary>
        /// First or default async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> FirstOrDefaultAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.FirstOrDefault, cancellationToken);
        }

        /// <summary>
        /// Last async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> LastAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Last, cancellationToken);
        }

        /// <summary>
        /// Last async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> LastAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.Last, cancellationToken);
        }

        /// <summary>
        /// Last or default async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> LastOrDefaultAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.LastOrDefault, cancellationToken);
        }

        /// <summary>
        /// Last or default async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> LastOrDefaultAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.LastOrDefault, cancellationToken);
        }

        /// <summary>
        /// Long count async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long> LongCountAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.LongCount, cancellationToken);
        }

        /// <summary>
        /// Long count async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long> LongCountAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.LongCount, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int> MaxAsync(
            this IEnumerable<int> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int?> MaxAsync(
            this IEnumerable<int?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<long> MaxAsync(
            this IEnumerable<long> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<long?> MaxAsync(
            this IEnumerable<long?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double> MaxAsync(
            this IEnumerable<double> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double?> MaxAsync(
            this IEnumerable<double?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float> MaxAsync(
            this IEnumerable<float> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float?> MaxAsync(
            this IEnumerable<float?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal> MaxAsync(
            this IEnumerable<decimal> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal?> MaxAsync(
            this IEnumerable<decimal?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> MaxAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int> MaxAsync<TSource>(
            this IEnumerable<TSource> source, Func<TSource, int> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int?> MaxAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long> MaxAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, long> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long?> MaxAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, long?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float> MaxAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, float> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float?> MaxAsync<TSource>(
            this IEnumerable<TSource> source, Func<TSource, float?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double> MaxAsync<TSource>(
            this IEnumerable<TSource> source, Func<TSource, double> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double?> MaxAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, double?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal> MaxAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, decimal> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal?> MaxAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, decimal?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> MaxAsync<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int> MinAsync(
            this IEnumerable<int> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int?> MinAsync(
            this IEnumerable<int?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<long> MinAsync(
            this IEnumerable<long> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<long?> MinAsync(
            this IEnumerable<long?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float> MinAsync(
            this IEnumerable<float> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float?> MinAsync(
            this IEnumerable<float?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double> MinAsync(
            this IEnumerable<double> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double?> MinAsync(
            this IEnumerable<double?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal> MinAsync(
            this IEnumerable<decimal> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal?> MinAsync(
            this IEnumerable<decimal?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> MinAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int> MinAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int?> MinAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long> MinAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, long> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long?> MinAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, long?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float> MinAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, float> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float?> MinAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, float?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double> MinAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, double> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double?> MinAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, double?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal> MinAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, decimal> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal?> MinAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, decimal?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> MinAsync<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Sequence equal async
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> SequenceEqualAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, Enumerable.SequenceEqual, cancellationToken);
        }

        /// <summary>
        /// Sequence equal async
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> SequenceEqualAsync<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(first, second, comparer, Enumerable.SequenceEqual, cancellationToken);
        }

        /// <summary>
        /// Single async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> SingleAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Single, cancellationToken);
        }

        /// <summary>
        /// Single async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> SingleAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.Single, cancellationToken);
        }

        /// <summary>
        /// Single or default async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> SingleOrDefaultAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.SingleOrDefault, cancellationToken);
        }

        /// <summary>
        /// Single or default async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> SingleOrDefaultAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.SingleOrDefault, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int> SumAsync(
            this IEnumerable<int> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int?> SumAsync(
            this IEnumerable<int?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<long> SumAsync(
            this IEnumerable<long> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<long?> SumAsync(
            this IEnumerable<long?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float> SumAsync(
            this IEnumerable<float> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float?> SumAsync(
            this IEnumerable<float?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double> SumAsync(
            this IEnumerable<double> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double?> SumAsync(
            this IEnumerable<double?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal> SumAsync(
            this IEnumerable<decimal> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal?> SumAsync(
            this IEnumerable<decimal?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int> SumAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int?> SumAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long> SumAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, long> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long?> SumAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, long?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float> SumAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, float> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float?> SumAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, float?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double> SumAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, double> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double?> SumAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, double?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal> SumAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, decimal> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal?> SumAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, decimal?> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// To array async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource[]> ToArrayAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.ToArray, cancellationToken);
        }

        /// <summary>
        /// To dictionary async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, Enumerable.ToDictionary, cancellationToken);
        }

        /// <summary>
        /// To dictionary async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, comparer, Enumerable.ToDictionary,
                cancellationToken);
        }

        /// <summary>
        /// To dictionary async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, elementSelector, Enumerable.ToDictionary,
                cancellationToken);
        }

        /// <summary>
        /// To dictionary async
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
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, elementSelector, comparer, Enumerable.ToDictionary,
                cancellationToken);
        }

        /// <summary>
        /// To list async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<List<TSource>> ToListAsync<TSource>(
            this IEnumerable<TSource> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, Enumerable.ToList, cancellationToken);
        }

        /// <summary>
        /// To lookup async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Task<ILookup<TKey, TSource>> ToLookupAsync<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, Enumerable.ToLookup, cancellationToken);
        }

        /// <summary>
        /// To lookup async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Task<ILookup<TKey, TSource>> ToLookupAsync<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, comparer, Enumerable.ToLookup, cancellationToken);
        }

        /// <summary>
        /// To lookup async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static Task<ILookup<TKey, TElement>> ToLookupAsync<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, elementSelector, Enumerable.ToLookup, cancellationToken);
        }

        /// <summary>
        /// To lookup async
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
        public static Task<ILookup<TKey, TElement>> ToLookupAsync<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromEnumerable(source, keySelector, elementSelector, comparer, Enumerable.ToLookup, cancellationToken);
        }
    }
}
