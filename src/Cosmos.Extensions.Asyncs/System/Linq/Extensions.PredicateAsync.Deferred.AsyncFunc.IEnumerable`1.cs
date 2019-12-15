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
 *  Author: default
 *  URL: https://github.com/zzzprojects/LINQ-Async
 *  MIT
 */

namespace System.Linq {
    public static partial class PredicateAsyncExtensions {
        /// <summary>
        /// Skip while async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> SkipWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromWhereEnumerable(source, predicate, Enumerable.SkipWhile, cancellationToken);
        }

        /// <summary>
        /// Skip while async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> SkipWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromWhereEnumerable(source, predicate, Enumerable.SkipWhile, cancellationToken);
        }

        /// <summary>
        /// Skip while
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> SkipWhile<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromWhereTaskEnumerable(source, predicate, Enumerable.SkipWhile, cancellationToken);
        }

        /// <summary>
        /// Skip while
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> SkipWhile<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromWhereTaskEnumerable(source, predicate, Enumerable.SkipWhile, cancellationToken);
        }

        /// <summary>
        /// Where async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> WhereAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromWhereEnumerable(source, predicate, Enumerable.Where, cancellationToken);
        }

        /// <summary>
        /// Where async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> WhereAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromWhereEnumerable(source, predicate, Enumerable.Where, cancellationToken);
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> Where<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromWhereTaskEnumerable(source, predicate, Enumerable.Where, cancellationToken);
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> Where<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromWhereTaskEnumerable(source, predicate, Enumerable.Where, cancellationToken);
        }
    }
}