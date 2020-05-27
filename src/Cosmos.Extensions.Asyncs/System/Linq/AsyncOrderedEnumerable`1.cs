// Description: Async extension methods for LINQ (Language Integrated Query).
// Website & Documentation: https://github.com/zzzprojects/LINQ-Async
// Forum: https://github.com/zzzprojects/LINQ-Async/issues
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Collections;
using System.Collections.Generic;
using System.Threading;

/*
 * Reference to:
 *  ZZZProjects/LINQ-Async
 *  Author: JonathanMagnan
 *  URL: https://github.com/zzzprojects/LINQ-Async
 *  MIT
 */

namespace System.Linq
{
    /// <summary>
    /// Async ordered enumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncOrderedEnumerable<T> : IOrderedEnumerable<T>
    {
        /// <summary>
        /// Create a new instance of <see cref="AsyncOrderedEnumerable{T}"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        public AsyncOrderedEnumerable(IOrderedEnumerable<T> source, CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
            Source = source;
        }

        /// <summary>
        /// CancellationToken
        /// </summary>
        public CancellationToken CancellationToken { get; set; }

        /// <summary>
        /// Source
        /// </summary>
        public IOrderedEnumerable<T> Source { get; set; }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            return new AsyncEnumerator<T>(Source.GetEnumerator(), CancellationToken);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new AsyncEnumerator<T>(Source.GetEnumerator(), CancellationToken);
        }

        /// <inheritdoc />
        public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            return Source.CreateOrderedEnumerable(keySelector, comparer, descending);
        }

        /// <summary>
        /// Create from...
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static AsyncOrderedEnumerable<T> CreateFrom(IOrderedEnumerable<T> source, CancellationToken cancellationToken)
        {
            return new AsyncOrderedEnumerable<T>(source, cancellationToken);
        }
    }
}