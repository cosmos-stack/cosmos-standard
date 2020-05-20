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
    public static partial class PredicateAsyncExtensions
    {
        /// <summary>
        /// All
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> All<TSource>(this Task<List<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return source.AsEnumerable(cancellationToken).All(predicate, cancellationToken);
        }

        /// <summary>
        /// Any
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<bool> Any<TSource>(this Task<List<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return source.AsEnumerable(cancellationToken).Any(predicate, cancellationToken);
        }

        /// <summary>
        /// Count
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<int> Count<TSource>(this Task<List<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return source.AsEnumerable(cancellationToken).Count(predicate, cancellationToken);
        }

        /// <summary>
        /// First
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> First<TSource>(this Task<List<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return source.AsEnumerable(cancellationToken).First(predicate, cancellationToken);
        }

        /// <summary>
        /// First or default
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> FirstOrDefault<TSource>(this Task<List<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return source.AsEnumerable(cancellationToken).FirstOrDefault(predicate, cancellationToken);
        }

        /// <summary>
        /// Last
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> Last<TSource>(this Task<List<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return source.AsEnumerable(cancellationToken).Last(predicate, cancellationToken);
        }

        /// <summary>
        /// Last or default
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> LastOrDefault<TSource>(this Task<List<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return source.AsEnumerable(cancellationToken).LastOrDefault(predicate, cancellationToken);
        }

        /// <summary>
        /// Long count
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<long> LongCount<TSource>(this Task<List<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return source.AsEnumerable(cancellationToken).LongCount(predicate, cancellationToken);
        }

        /// <summary>
        /// Single
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> Single<TSource>(this Task<List<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return source.AsEnumerable(cancellationToken).Single(predicate, cancellationToken);
        }

        /// <summary>
        /// Single or default
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<TSource> SingleOrDefault<TSource>(this Task<List<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return source.AsEnumerable(cancellationToken).SingleOrDefault(predicate, cancellationToken);
        }
    }
}