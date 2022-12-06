
/*
 * Reference to:
 *      i3arnon/AsyncUtilities
 *          Author: Bar Arnon
 *          Url: https://github.com/i3arnon/AsyncUtilities
 *          MIT
 */

namespace Cosmos.Asynchronous;

/// <summary>
/// TaskCompletionSource extensions
/// </summary>
public static partial class TaskExtensions
{
    #region TryCompleteFromCompletedTask

    /// <summary>
    /// Try CompleteFromCompletedTask
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="taskCompletionSource"></param>
    /// <param name="completedTask"></param>
    /// <returns></returns>
    public static bool TryCompleteFromCompletedTask<TResult>(
        this TaskCompletionSource<TResult> taskCompletionSource,
        Task<TResult> completedTask)
    {
        ArgumentNullException.ThrowIfNull(taskCompletionSource);
        ArgumentNullException.ThrowIfNull(completedTask);

        switch (completedTask.Status)
        {
            case TaskStatus.Faulted:
                // ReSharper disable once PossibleNullReferenceException
                return taskCompletionSource.TrySetException(completedTask.Exception!.InnerExceptions);

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

    /// <summary>
    /// Continue With Synchronously
    /// </summary>
    /// <param name="task"></param>
    /// <param name="continuationAction"></param>
    /// <returns></returns>
    public static Task ContinueWithSynchronously(this Task task, Action<Task> continuationAction)
    {
        ArgumentNullException.ThrowIfNull(task);
        ArgumentNullException.ThrowIfNull(continuationAction);

        return task.ContinueWith(
            continuationAction,
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }

    /// <summary>
    /// Continue With Synchronously
    /// </summary>
    /// <param name="task"></param>
    /// <param name="continuationAction"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    public static Task ContinueWithSynchronously(this Task task, Action<Task, object> continuationAction, object state)
    {
        ArgumentNullException.ThrowIfNull(task);
        ArgumentNullException.ThrowIfNull(continuationAction);

        return task.ContinueWith(
            continuationAction,
            state,
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }

    /// <summary>
    /// Continue With Synchronously
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="task"></param>
    /// <param name="continuationFunc"></param>
    /// <returns></returns>
    public static Task<TResult> ContinueWithSynchronously<TResult>(this Task task, Func<Task, TResult> continuationFunc)
    {
        ArgumentNullException.ThrowIfNull(task);
        ArgumentNullException.ThrowIfNull(continuationFunc);

        return task.ContinueWith(
            continuationFunc,
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }

    /// <summary>
    /// Continue With Synchronously
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="task"></param>
    /// <param name="continuationFunc"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    public static Task<TResult> ContinueWithSynchronously<TResult>(this Task task, Func<Task, object, TResult> continuationFunc, object state)
    {
        ArgumentNullException.ThrowIfNull(task);
        ArgumentNullException.ThrowIfNull(continuationFunc);

        return task.ContinueWith(
            continuationFunc,
            state,
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }

    /// <summary>
    /// Continue With Synchronously
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="task"></param>
    /// <param name="continuationAction"></param>
    /// <returns></returns>
    public static Task ContinueWithSynchronously<TResult>(this Task<TResult> task, Action<Task<TResult>> continuationAction)
    {
        ArgumentNullException.ThrowIfNull(task);
        ArgumentNullException.ThrowIfNull(continuationAction);

        return task.ContinueWith(
            continuationAction,
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }

    /// <summary>
    /// Continue With Synchronously
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="task"></param>
    /// <param name="continuationAction"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    public static Task ContinueWithSynchronously<TResult>(this Task<TResult> task, Action<Task<TResult>, object> continuationAction, object state)
    {
        ArgumentNullException.ThrowIfNull(task);
        ArgumentNullException.ThrowIfNull(continuationAction);

        return task.ContinueWith(
            continuationAction,
            state,
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }

    /// <summary>
    /// Continue With Synchronously
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TNewResult"></typeparam>
    /// <param name="task"></param>
    /// <param name="continuationFunc"></param>
    /// <returns></returns>
    public static Task<TNewResult> ContinueWithSynchronously<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, TNewResult> continuationFunc)
    {
        ArgumentNullException.ThrowIfNull(task);
        ArgumentNullException.ThrowIfNull(continuationFunc);

        return task.ContinueWith(
            continuationFunc,
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }

    /// <summary>
    /// Continue With Synchronously
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TNewResult"></typeparam>
    /// <param name="task"></param>
    /// <param name="continuationFunc"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    public static Task<TNewResult> ContinueWithSynchronously<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, object, TNewResult> continuationFunc,
        object state)
    {
        ArgumentNullException.ThrowIfNull(task);
        ArgumentNullException.ThrowIfNull(continuationFunc);

        return task.ContinueWith(
            continuationFunc,
            state,
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }

    #endregion

    #region ToCancellationTokenSource

    /// <summary>
    /// To CancellationTokenSource
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    public static CancellationTokenSource ToCancellationTokenSource(this Task task)
    {
        ArgumentNullException.ThrowIfNull(task);
        var cancellationTokenSource = new CancellationTokenSource();
        task.ContinueWithSynchronously((_, @this) => ((CancellationTokenSource) @this!).Cancel(), cancellationTokenSource);
        return cancellationTokenSource;
    }

    #endregion
}