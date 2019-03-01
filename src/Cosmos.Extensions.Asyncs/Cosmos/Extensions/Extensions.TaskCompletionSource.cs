using System;
using System.Threading;
using System.Threading.Tasks;

/*
 * Reference to:
 *      i3arnon/AsyncUtilities
 *          Author: Bar Arnon
 *          Url: https://github.com/i3arnon/AsyncUtilities
 *          MIT
 */

namespace Cosmos.Extensions
{
    public static class TaskCompletionSourceExtensions
    {
        #region TryCompleteFromCompletedTask

        public static bool TryCompleteFromCompletedTask<TResult>(
            this TaskCompletionSource<TResult> taskCompletionSource,
            Task<TResult> completedTask)
        {
            if (taskCompletionSource == null) throw new ArgumentNullException(nameof(taskCompletionSource));
            if (completedTask == null) throw new ArgumentNullException(nameof(completedTask));

            switch (completedTask.Status)
            {
                case TaskStatus.Faulted:
                    return taskCompletionSource.TrySetException(completedTask.Exception.InnerExceptions);

                case TaskStatus.Canceled:
                    return taskCompletionSource.TrySetCanceled();

                case TaskStatus.RanToCompletion:
                    return taskCompletionSource.TrySetResult(completedTask.Result);

                default:
                    throw new ArgumentException("Argument must be a completed task", nameof(completedTask));
            }
        }

        #endregion

        #region ContinueWithSynchronously

        public static Task ContinueWithSynchronously(this Task task, Action<Task> continuationAction)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            if (continuationAction == null) throw new ArgumentNullException(nameof(continuationAction));

            return task.ContinueWith(
                continuationAction,
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }

        public static Task ContinueWithSynchronously(this Task task, Action<Task, object> continuationAction, object state)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            if (continuationAction == null) throw new ArgumentNullException(nameof(continuationAction));

            return task.ContinueWith(
                continuationAction,
                state,
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }

        public static Task<TResult> ContinueWithSynchronously<TResult>(this Task task, Func<Task, TResult> continuationFunc)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            if (continuationFunc == null) throw new ArgumentNullException(nameof(continuationFunc));

            return task.ContinueWith(
                continuationFunc,
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }

        public static Task<TResult> ContinueWithSynchronously<TResult>(this Task task, Func<Task, object, TResult> continuationFunc, object state)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            if (continuationFunc == null) throw new ArgumentNullException(nameof(continuationFunc));

            return task.ContinueWith(
                continuationFunc,
                state,
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }

        public static Task ContinueWithSynchronously<TResult>(this Task<TResult> task, Action<Task<TResult>> continuationAction)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            if (continuationAction == null) throw new ArgumentNullException(nameof(continuationAction));

            return task.ContinueWith(
                continuationAction,
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }

        public static Task ContinueWithSynchronously<TResult>(this Task<TResult> task, Action<Task<TResult>, object> continuationAction, object state)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            if (continuationAction == null) throw new ArgumentNullException(nameof(continuationAction));

            return task.ContinueWith(
                continuationAction,
                state,
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }

        public static Task<TNewResult> ContinueWithSynchronously<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, TNewResult> continuationFunc)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            if (continuationFunc == null) throw new ArgumentNullException(nameof(continuationFunc));

            return task.ContinueWith(
                continuationFunc,
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }


        public static Task<TNewResult> ContinueWithSynchronously<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, object, TNewResult> continuationFunc, object state)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            if (continuationFunc == null) throw new ArgumentNullException(nameof(continuationFunc));

            return task.ContinueWith(
                continuationFunc,
                state,
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }

        #endregion

        #region ToCancellationTokenSource

        public static CancellationTokenSource ToCancellationTokenSource(this Task task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            var cancellationTokenSource = new CancellationTokenSource();
            task.ContinueWithSynchronously((_, @this) => ((CancellationTokenSource)@this).Cancel(), cancellationTokenSource);
            return cancellationTokenSource;
        }

        #endregion
    }
}
