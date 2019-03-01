// Description: Async extension methods for LINQ (Language Integrated Query).
// Website & Documentation: https://github.com/zzzprojects/LINQ-Async
// Forum: https://github.com/zzzprojects/LINQ-Async/issues
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        public static Task<T>[] OrderByCompletion<T>(this IEnumerable<Task<T>> tasks)
        {
            //Credit to: https://github.com/NeoLegends/AsyncLinq

            var taskArray = tasks.ToArray();

            var numTasks = taskArray.Length;
            var tcs = new TaskCompletionSource<T>[numTasks];
            var ret = new Task<T>[numTasks];

            var lastIndex = -1;

            for (var i = 0; i != numTasks; ++i)
            {
                tcs[i] = new TaskCompletionSource<T>();
                ret[i] = tcs[i].Task;
                taskArray[i].ContinueWith(Continuation, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
            }

            return ret;

            void Continuation(Task<T> task)
            {
                var index = Interlocked.Increment(ref lastIndex);
                tcs[index].TryCompleteFromCompletedTask(task);
            }
        }

        internal static bool TryCompleteFromCompletedTask<TResult>(this TaskCompletionSource<TResult> @this, Task<TResult> task)
        {
            Contract.Requires(@this != null);
            Contract.Requires(task != null);
            Contract.Requires(task.IsCompleted);

            if (task.IsFaulted)
            {
                Contract.Assume(task.Exception != null);
                Contract.Assume(task.Exception.InnerExceptions != null);
                Contract.Assume(Contract.ForAll(task.Exception.InnerExceptions, x => x != null));
                return @this.TrySetException(task.Exception.InnerExceptions);
            }

            if (task.IsCanceled)
                return @this.TrySetCanceled();

            return @this.TrySetResult(task.Result);
        }
    }
}
