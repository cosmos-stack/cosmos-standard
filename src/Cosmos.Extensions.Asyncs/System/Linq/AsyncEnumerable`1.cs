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

namespace System.Linq {
    /// <summary>
    /// Async Enumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncEnumerable<T> : IEnumerable<T> {
        /// <summary>
        /// Create a new instance of <see cref="AsyncEnumerable{T}"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        public AsyncEnumerable(IEnumerable<T> source, CancellationToken cancellationToken) {
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
        public IEnumerable<T> Source { get; set; }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator() {
            return new AsyncEnumerator<T>(Source.GetEnumerator(), CancellationToken);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return new AsyncEnumerator<T>(Source.GetEnumerator(), CancellationToken);
        }

        /// <summary>
        /// Create from...
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static AsyncEnumerable<T> CreateFrom(IEnumerable<T> source, CancellationToken cancellationToken) {
            return new AsyncEnumerable<T>(source, cancellationToken);
        }
    }
}