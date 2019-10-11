// Description: Async extension methods for LINQ (Language Integrated Query).
// Website & Documentation: https://github.com/zzzprojects/LINQ-Async
// Forum: https://github.com/zzzprojects/LINQ-Async/issues
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /// As enumerable
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Task<IEnumerable<TSource>> AsEnumerable<TSource>(
            this Task<ReadOnlyCollection<TSource>> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.AsEnumerable, cancellationToken);
        }
    }
}
