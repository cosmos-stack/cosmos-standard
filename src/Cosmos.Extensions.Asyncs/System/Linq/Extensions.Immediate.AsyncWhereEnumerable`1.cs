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
        public static Task<TSource> Aggregate<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, TSource, TSource> func, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, func, Enumerable.Aggregate, cancellationToken);
        }

        public static Task<TAccumulate> Aggregate<TSource, TAccumulate>(this Task<AsyncWhereEnumerable<TSource>> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, seed, func, Enumerable.Aggregate, cancellationToken);
        }

        public static Task<TResult> Aggregate<TSource, TAccumulate, TResult>(this Task<AsyncWhereEnumerable<TSource>> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, seed, func, resultSelector, Enumerable.Aggregate, cancellationToken);
        }

        public static Task<bool> All<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.All, cancellationToken);
        }

        public static Task<bool> Any<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Any, cancellationToken);
        }

        public static Task<bool> Any<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Any, cancellationToken);
        }

        public static Task<double> Average(this Task<AsyncWhereEnumerable<int>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        public static Task<double?> Average(this Task<AsyncWhereEnumerable<int?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        public static Task<double> Average(this Task<AsyncWhereEnumerable<long>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        public static Task<double?> Average(this Task<AsyncWhereEnumerable<long?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        public static Task<float> Average(this Task<AsyncWhereEnumerable<float>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        public static Task<float?> Average(this Task<AsyncWhereEnumerable<float?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        public static Task<double> Average(this Task<AsyncWhereEnumerable<double>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        public static Task<double?> Average(this Task<AsyncWhereEnumerable<double?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        public static Task<decimal> Average(this Task<AsyncWhereEnumerable<decimal>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        public static Task<decimal?> Average(this Task<AsyncWhereEnumerable<decimal?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Average, cancellationToken);
        }

        public static Task<double> Average<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        public static Task<double?> Average<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        public static Task<double> Average<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        public static Task<double?> Average<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        public static Task<float> Average<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        public static Task<float?> Average<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        public static Task<double> Average<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        public static Task<double?> Average<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        public static Task<decimal> Average<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        public static Task<decimal?> Average<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Average, cancellationToken);
        }

        public static Task<bool> Contains<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, TSource value, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, value, Enumerable.Contains, cancellationToken);
        }

        public static Task<bool> Contains<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, TSource value, IEqualityComparer<TSource> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, value, comparer, Enumerable.Contains, cancellationToken);
        }

        public static Task<int> Count<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Count, cancellationToken);
        }

        public static Task<int> Count<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Count, cancellationToken);
        }

        public static Task<TSource> ElementAt<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, int index, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, index, Enumerable.ElementAt, cancellationToken);
        }

        public static Task<TSource> ElementAtOrDefault<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, int index, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, index, Enumerable.ElementAtOrDefault, cancellationToken);
        }

        public static Task<TSource> First<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.First, cancellationToken);
        }

        public static Task<TSource> First<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.First, cancellationToken);
        }

        public static Task<TSource> FirstOrDefault<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.FirstOrDefault, cancellationToken);
        }

        public static Task<TSource> FirstOrDefault<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.FirstOrDefault, cancellationToken);
        }

        public static Task<TSource> Last<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Last, cancellationToken);
        }

        public static Task<TSource> Last<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Last, cancellationToken);
        }

        public static Task<TSource> LastOrDefault<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.LastOrDefault, cancellationToken);
        }

        public static Task<TSource> LastOrDefault<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.LastOrDefault, cancellationToken);
        }

        public static Task<long> LongCount<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.LongCount, cancellationToken);
        }

        public static Task<long> LongCount<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.LongCount, cancellationToken);
        }

        public static Task<int> Max(this Task<AsyncWhereEnumerable<int>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        public static Task<int?> Max(this Task<AsyncWhereEnumerable<int?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        public static Task<long> Max(this Task<AsyncWhereEnumerable<long>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        public static Task<long?> Max(this Task<AsyncWhereEnumerable<long?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        public static Task<double> Max(this Task<AsyncWhereEnumerable<double>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        public static Task<double?> Max(this Task<AsyncWhereEnumerable<double?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        public static Task<float> Max(this Task<AsyncWhereEnumerable<float>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        public static Task<float?> Max(this Task<AsyncWhereEnumerable<float?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        public static Task<decimal> Max(this Task<AsyncWhereEnumerable<decimal>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        public static Task<decimal?> Max(this Task<AsyncWhereEnumerable<decimal?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        public static Task<TSource> Max<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Max, cancellationToken);
        }

        public static Task<int> Max<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        public static Task<int?> Max<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        public static Task<long> Max<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        public static Task<long?> Max<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        public static Task<float> Max<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        public static Task<float?> Max<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        public static Task<double> Max<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        public static Task<double?> Max<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        public static Task<decimal> Max<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        public static Task<decimal?> Max<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        public static Task<TResult> Max<TSource, TResult>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, TResult> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Max, cancellationToken);
        }

        public static Task<int> Min(this Task<AsyncWhereEnumerable<int>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        public static Task<int?> Min(this Task<AsyncWhereEnumerable<int?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        public static Task<long> Min(this Task<AsyncWhereEnumerable<long>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        public static Task<long?> Min(this Task<AsyncWhereEnumerable<long?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        public static Task<float> Min(this Task<AsyncWhereEnumerable<float>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        public static Task<float?> Min(this Task<AsyncWhereEnumerable<float?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        public static Task<double> Min(this Task<AsyncWhereEnumerable<double>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        public static Task<double?> Min(this Task<AsyncWhereEnumerable<double?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        public static Task<decimal> Min(this Task<AsyncWhereEnumerable<decimal>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        public static Task<decimal?> Min(this Task<AsyncWhereEnumerable<decimal?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        public static Task<TSource> Min<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Min, cancellationToken);
        }

        public static Task<int> Min<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        public static Task<int?> Min<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        public static Task<long> Min<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        public static Task<long?> Min<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        public static Task<float> Min<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        public static Task<float?> Min<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        public static Task<double> Min<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        public static Task<double?> Min<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        public static Task<decimal> Min<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        public static Task<decimal?> Min<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        public static Task<TResult> Min<TSource, TResult>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, TResult> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Min, cancellationToken);
        }

        public static Task<bool> SequenceEqual<TSource>(this Task<AsyncWhereEnumerable<TSource>> first, IEnumerable<TSource> second, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(first, second, Enumerable.SequenceEqual, cancellationToken);
        }

        public static Task<bool> SequenceEqual<TSource>(this Task<AsyncWhereEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(first, second, comparer, Enumerable.SequenceEqual, cancellationToken);
        }

        public static Task<TSource> Single<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Single, cancellationToken);
        }

        public static Task<TSource> Single<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Single, cancellationToken);
        }

        public static Task<TSource> SingleOrDefault<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.SingleOrDefault, cancellationToken);
        }

        public static Task<TSource> SingleOrDefault<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.SingleOrDefault, cancellationToken);
        }

        public static Task<int> Sum(this Task<AsyncWhereEnumerable<int>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        public static Task<int?> Sum(this Task<AsyncWhereEnumerable<int?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        public static Task<long> Sum(this Task<AsyncWhereEnumerable<long>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        public static Task<long?> Sum(this Task<AsyncWhereEnumerable<long?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        public static Task<float> Sum(this Task<AsyncWhereEnumerable<float>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        public static Task<float?> Sum(this Task<AsyncWhereEnumerable<float?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        public static Task<double> Sum(this Task<AsyncWhereEnumerable<double>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        public static Task<double?> Sum(this Task<AsyncWhereEnumerable<double?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        public static Task<decimal> Sum(this Task<AsyncWhereEnumerable<decimal>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        public static Task<decimal?> Sum(this Task<AsyncWhereEnumerable<decimal?>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Sum, cancellationToken);
        }

        public static Task<int> Sum<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        public static Task<int?> Sum<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        public static Task<long> Sum<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        public static Task<long?> Sum<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        public static Task<float> Sum<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        public static Task<float?> Sum<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        public static Task<double> Sum<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        public static Task<double?> Sum<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        public static Task<decimal> Sum<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        public static Task<decimal?> Sum<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Sum, cancellationToken);
        }

        public static Task<TSource[]> ToArray<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.ToArray, cancellationToken);
        }

        public static Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, TKey> keySelector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, Enumerable.ToDictionary, cancellationToken);
        }

        public static Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, comparer, Enumerable.ToDictionary, cancellationToken);
        }

        public static Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, elementSelector, Enumerable.ToDictionary, cancellationToken);
        }

        public static Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, elementSelector, comparer, Enumerable.ToDictionary, cancellationToken);
        }

        public static Task<List<TSource>> ToList<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.ToList, cancellationToken);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, TKey> keySelector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, Enumerable.ToLookup, cancellationToken);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, comparer, Enumerable.ToLookup, cancellationToken);
        }

        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, elementSelector, Enumerable.ToLookup, cancellationToken);
        }

        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, keySelector, elementSelector, comparer, Enumerable.ToLookup, cancellationToken);
        }

    }
}
