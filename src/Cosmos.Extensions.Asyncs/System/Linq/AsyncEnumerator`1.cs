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
    public class AsyncEnumerator<T> : IEnumerator<T>
    {
        public AsyncEnumerator(IEnumerator<T> source, CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
            Source = source;
        }

        public CancellationToken CancellationToken { get; set; }

        public IEnumerator<T> Source { get; set; }

        public T Current => Source.Current;

        object IEnumerator.Current => Source.Current;

        public void Dispose()
        {
            Source.Dispose();
        }

        public bool MoveNext()
        {
            CancellationToken.ThrowIfCancellationRequested();
            return Source.MoveNext();
        }

        public void Reset()
        {
            Source.Reset();
        }
    }
}
