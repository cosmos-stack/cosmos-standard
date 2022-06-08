namespace Cosmos.Asynchronous;

/// <summary>
/// Task utilities <br />
/// 任务工具
/// </summary>
public static partial class Tasks
{
    #region CompletedTask

#if NET451 || NET452
        // ReSharper disable once InconsistentNaming
        private static readonly Task _completedTask = Task.FromResult(true);
#endif

    /// <summary>
    /// Gets a task that has been completed successfully.
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task CompletedTask()
    {
#if NET451 || NET452
        return _completedTask;
#else
        return Task.CompletedTask;
#endif
    }

    #endregion

    #region From Canceled

    /// <summary>
    /// From canceled
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Task<TResult> FromCanceled<TResult>(CancellationToken cancellationToken)
    {
#if NET451 || NET452
        var tcs = new TaskCompletionSource<TResult>();
        tcs.SetCanceled();
        return tcs.Task;
#else
        return Task.FromCanceled<TResult>(cancellationToken);
#endif
    }

    /// <summary>
    /// From canceled
    /// </summary>
    /// <param name="exception"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Task<TResult> FromCanceled<TResult>(OperationCanceledException exception)
    {
#if NET451 || NET452
        var tcs = new TaskCompletionSource<TResult>();
        tcs.SetException(exception);
        tcs.SetCanceled();
        return tcs.Task;
#else
        return Task.FromCanceled<TResult>(exception.CancellationToken);
#endif
    }

    #endregion

    #region From Exception

    /// <summary>
    /// From exception
    /// </summary>
    /// <param name="exception"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Task<TResult> FromException<TResult>(Exception exception)
    {
        if (exception is null)
            throw new ArgumentNullException(nameof(exception), "exception is null");
#if NET451 || NET452
        var tcs = new TaskCompletionSource<TResult>();
        tcs.TrySetException(exception);
        return tcs.Task;
#else
        return Task.FromException<TResult>(exception);
#endif
    }

    #endregion
}