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
    public static partial class Extensions {
        /// <summary>
        /// Take async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> TakeAsync<TSource>(
            this IEnumerable<TSource> source, int count,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromEnumerable(source, count, Enumerable.Take, cancellationToken);
        }

        /// <summary>
        /// Take while async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> TakeWhileAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.TakeWhile, cancellationToken);
        }

        /// <summary>
        /// Take while async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> TakeWhileAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate,
            CancellationToken cancellationToken = default) {
            return Task.Factory.FromEnumerable(source, predicate, Enumerable.TakeWhile, cancellationToken);
        }
    }
}