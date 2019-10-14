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
        /// Aggregate
        /// </summary>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> Aggregate<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, TSource, TSource> func, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, func, Enumerable.Aggregate, cancellationToken);
        }

        /// <summary>
        /// Aggregate
        /// </summary>
        /// <param name="source"></param>
        /// <param name="seed"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TAccumulate"></typeparam>
        /// <returns></returns>
        public static Task<TAccumulate> Aggregate<TSource, TAccumulate>(this Task<IEnumerable<TSource>> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, seed, func, Enumerable.Aggregate, cancellationToken);
        }

        /// <summary>
        /// Aggregate
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
        public static Task<TResult> Aggregate<TSource, TAccumulate, TResult>(this Task<IEnumerable<TSource>> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, seed, func, resultSelector, Enumerable.Aggregate, cancellationToken);
        }

        /// <summary>
        /// All
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> All<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.All, cancellationToken);
        }

        /// <summary>
        /// Any
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> Any<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Any, cancellationToken);
        }

        /// <summary>
        /// Any
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> Any<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Any, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double> Average(this Task<IEnumerable<int>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double?> Average(this Task<IEnumerable<int?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double> Average(this Task<IEnumerable<long>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double?> Average(this Task<IEnumerable<long?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float> Average(this Task<IEnumerable<float>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float?> Average(this Task<IEnumerable<float?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double> Average(this Task<IEnumerable<double>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double?> Average(this Task<IEnumerable<double?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal> Average(this Task<IEnumerable<decimal>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal?> Average(this Task<IEnumerable<decimal?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double?> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double?> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float?> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double?> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Average
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal?> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> Contains<TSource>(this Task<IEnumerable<TSource>> source, TSource value, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, value, Enumerable.Contains, cancellationToken);
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> Contains<TSource>(this Task<IEnumerable<TSource>> source, TSource value, IEqualityComparer<TSource> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, value, comparer, Enumerable.Contains, cancellationToken);
        }

        /// <summary>
        /// Count
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int> Count<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Count, cancellationToken);
        }

        /// <summary>
        /// Count
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int> Count<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Count, cancellationToken);
        }

        /// <summary>
        /// Element at
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> ElementAt<TSource>(this Task<IEnumerable<TSource>> source, int index, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, index, Enumerable.ElementAt, cancellationToken);
        }

        /// <summary>
        /// Element at or default
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> ElementAtOrDefault<TSource>(this Task<IEnumerable<TSource>> source, int index, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, index, Enumerable.ElementAtOrDefault, cancellationToken);
        }

        /// <summary>
        /// First
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> First<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.First, cancellationToken);
        }

        /// <summary>
        /// First
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> First<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.First, cancellationToken);
        }

        /// <summary>
        /// First or default
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> FirstOrDefault<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.FirstOrDefault, cancellationToken);
        }

        /// <summary>
        /// First or default
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> FirstOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.FirstOrDefault, cancellationToken);
        }

        /// <summary>
        /// Last
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> Last<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Last, cancellationToken);
        }

        /// <summary>
        /// Last
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> Last<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Last, cancellationToken);
        }

        /// <summary>
        /// Last or default
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> LastOrDefault<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.LastOrDefault, cancellationToken);
        }

        /// <summary>
        /// Last or default
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> LastOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.LastOrDefault, cancellationToken);
        }

        /// <summary>
        /// Long count
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long> LongCount<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.LongCount, cancellationToken);
        }

        /// <summary>
        /// Long count
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long> LongCount<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.LongCount, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int> Max(this Task<IEnumerable<int>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int?> Max(this Task<IEnumerable<int?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<long> Max(this Task<IEnumerable<long>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<long?> Max(this Task<IEnumerable<long?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double> Max(this Task<IEnumerable<double>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double?> Max(this Task<IEnumerable<double?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float> Max(this Task<IEnumerable<float>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float?> Max(this Task<IEnumerable<float?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal> Max(this Task<IEnumerable<decimal>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal?> Max(this Task<IEnumerable<decimal?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> Max<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int?> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long?> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float?> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double?> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal?> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> Max<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, TResult> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int> Min(this Task<IEnumerable<int>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int?> Min(this Task<IEnumerable<int?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<long> Min(this Task<IEnumerable<long>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<long?> Min(this Task<IEnumerable<long?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float> Min(this Task<IEnumerable<float>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float?> Min(this Task<IEnumerable<float?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double> Min(this Task<IEnumerable<double>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double?> Min(this Task<IEnumerable<double?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal> Min(this Task<IEnumerable<decimal>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal?> Min(this Task<IEnumerable<decimal?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> Min<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int?> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long?> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float?> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double?> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal?> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> Min<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, TResult> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        /// <summary>
        /// Sequence Equal
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> SequenceEqual<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(first, second, Enumerable.SequenceEqual, cancellationToken);
        }

        /// <summary>
        /// Sequence Equal
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> SequenceEqual<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(first, second, comparer, Enumerable.SequenceEqual, cancellationToken);
        }

        /// <summary>
        /// Single
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> Single<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Single, cancellationToken);
        }

        /// <summary>
        /// Single
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> Single<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Single, cancellationToken);
        }

        /// <summary>
        /// Single or default
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> SingleOrDefault<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.SingleOrDefault, cancellationToken);
        }
        
        /// <summary>
        /// Single or default
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> SingleOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.SingleOrDefault, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int> Sum(this Task<IEnumerable<int>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<int?> Sum(this Task<IEnumerable<int?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<long> Sum(this Task<IEnumerable<long>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<long?> Sum(this Task<IEnumerable<long?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float> Sum(this Task<IEnumerable<float>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<float?> Sum(this Task<IEnumerable<float?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double> Sum(this Task<IEnumerable<double>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<double?> Sum(this Task<IEnumerable<double?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal> Sum(this Task<IEnumerable<decimal>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<decimal?> Sum(this Task<IEnumerable<decimal?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<float?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<double?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<decimal?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        /// <summary>
        /// TO array
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource[]> ToArray<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.ToArray, cancellationToken);
        }

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, Enumerable.ToDictionary, cancellationToken);
        }

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, comparer, Enumerable.ToDictionary, cancellationToken);
        }

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, elementSelector, Enumerable.ToDictionary, cancellationToken);
        }

        /// <summary>
        /// To dictionary
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
        public static Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, elementSelector, comparer, Enumerable.ToDictionary, cancellationToken);
        }

        /// <summary>
        /// To list
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<List<TSource>> ToList<TSource>(this Task<IEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.ToList, cancellationToken);
        }

        /// <summary>
        /// To lookup
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, Enumerable.ToLookup, cancellationToken);
        }

        /// <summary>
        /// To lookup
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, comparer, Enumerable.ToLookup, cancellationToken);
        }

        /// <summary>
        /// To lookup
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, elementSelector, Enumerable.ToLookup, cancellationToken);
        }

        /// <summary>
        /// To lookup
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
        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, elementSelector, comparer, Enumerable.ToLookup, cancellationToken);
        }
    }
}
