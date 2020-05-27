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

namespace System.Linq
{
    public static partial class Extensions
    {
        /// <summary>
        /// Order By Predicate Completion
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> OrderByPredicateCompletion<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> source,
            bool value = true,
            CancellationToken cancellationToken = default)
        {
            var sourceState = (AsyncWhereEnumerable<TSource>) source.AsyncState;
            sourceState.OrderByPredicateCompletion = value;
            return source;
        }

        /// <summary>
        /// Start Predicate Concurrently
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<TSource>> StartPredicateConcurrently<TSource>(
            this Task<AsyncWhereEnumerable<TSource>> source,
            bool value = true,
            CancellationToken cancellationToken = default)
        {
            var sourceState = (AsyncWhereEnumerable<TSource>) source.AsyncState;
            sourceState.StartPredicateConcurrently = value;
            return source;
        }
    }
}