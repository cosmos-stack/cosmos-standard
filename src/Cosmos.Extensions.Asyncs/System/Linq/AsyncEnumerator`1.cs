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
    /// Async enumerator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncEnumerator<T> : IEnumerator<T>
    {
        /// <summary>
        /// Create a new instance of <see cref="AsyncEnumerator{T}"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        public AsyncEnumerator(IEnumerator<T> source, CancellationToken cancellationToken)
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
        public IEnumerator<T> Source { get; set; }

        /// <inheritdoc />
        public T Current => Source.Current;

        object IEnumerator.Current => Source.Current;

        /// <inheritdoc />
        public void Dispose()
        {
            Source.Dispose();
        }

        /// <inheritdoc />
        public bool MoveNext()
        {
            CancellationToken.ThrowIfCancellationRequested();
            return Source.MoveNext();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Source.Reset();
        }
    }
}