// Description: Async extension methods for LINQ (Language Integrated Query).
// Website & Documentation: https://github.com/zzzprojects/LINQ-Async
// Forum: https://github.com/zzzprojects/LINQ-Async/issues
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

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

namespace System.Linq {
    public static partial class PredicateAsyncExtensions {
        /// <summary>
        /// Skip while
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> SkipWhile<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate,
            CancellationToken cancellationToken = default) {
            return source.AsEnumerable(cancellationToken).SkipWhile(predicate, cancellationToken);
        }

        /// <summary>
        /// Skip while
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> SkipWhile<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate,
            CancellationToken cancellationToken = default) {
            return source.AsEnumerable(cancellationToken).SkipWhile(predicate, cancellationToken);
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> Where<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate,
            CancellationToken cancellationToken = default) {
            return source.AsEnumerable(cancellationToken).Where(predicate, cancellationToken);
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> Where<TSource>(this Task<AsyncWhereEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate,
            CancellationToken cancellationToken = default) {
            return source.AsEnumerable(cancellationToken).Where(predicate, cancellationToken);
        }
    }
}