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
        /// Select
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> Select<TSource, TResult>(
            this Task<IOrderedEnumerable<TSource>> source,
            Func<TSource, TResult> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Select, cancellationToken);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> Select<TSource, TResult>(
            this Task<IOrderedEnumerable<TSource>> source,
            Func<TSource, int, TResult> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.Select, cancellationToken);
        }

        /// <summary>
        /// Select many
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(
            this Task<IOrderedEnumerable<TSource>> source,
            Func<TSource, IEnumerable<TResult>> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.SelectMany, cancellationToken);
        }

        /// <summary>
        /// Select many
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(
            this Task<IOrderedEnumerable<TSource>> source,
            Func<TSource, int, IEnumerable<TResult>> selector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, selector, Enumerable.SelectMany, cancellationToken);
        }

        /// <summary>
        /// Select many
        /// </summary>
        /// <param name="source"></param>
        /// <param name="collectionSelector"></param>
        /// <param name="resultSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCollection"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(
            this Task<IOrderedEnumerable<TSource>> source,
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, collectionSelector, resultSelector, Enumerable.SelectMany, cancellationToken);
        }

        /// <summary>
        /// Select many
        /// </summary>
        /// <param name="source"></param>
        /// <param name="collectionSelector"></param>
        /// <param name="resultSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCollection"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(
            this Task<IOrderedEnumerable<TSource>> source,
            Func<TSource, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, collectionSelector, resultSelector, Enumerable.SelectMany, cancellationToken);
        }
    }
}