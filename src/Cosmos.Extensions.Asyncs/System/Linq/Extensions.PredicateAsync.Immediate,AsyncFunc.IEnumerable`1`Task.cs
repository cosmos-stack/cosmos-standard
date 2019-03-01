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
    public static partial class PredicateAsyncExtensions
    {
        public static Task<bool> All<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.All, cancellationToken);
        }

        public static Task<bool> Any<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Any, cancellationToken);
        }

        public static Task<int> Count<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Count, cancellationToken);
        }

        public static Task<TSource> First<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.First, cancellationToken);
        }

        public static Task<TSource> FirstOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.FirstOrDefault, cancellationToken);
        }

        public static Task<TSource> Last<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Last, cancellationToken);
        }

        public static Task<TSource> LastOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.LastOrDefault, cancellationToken);
        }

        public static Task<long> LongCount<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.LongCount, cancellationToken);
        }

        public static Task<TSource> Single<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.Single, cancellationToken);
        }

        public static Task<TSource> SingleOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, predicate, Enumerable.SingleOrDefault, cancellationToken);
        }
    }
}
