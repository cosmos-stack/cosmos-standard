namespace Cosmos.Asynchronous;

/// <summary>
/// Task utilities <br />
/// 任务工具
/// </summary>
public static partial class Tasks
{
    #region CompletedTask

    /// <summary>
    /// Gets a task that has been completed successfully.
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task CompletedTask()
    {
        return Task.CompletedTask;
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
        return Task.FromCanceled<TResult>(cancellationToken);
    }

    /// <summary>
    /// From canceled
    /// </summary>
    /// <param name="exception"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Task<TResult> FromCanceled<TResult>(OperationCanceledException exception)
    {
        return Task.FromCanceled<TResult>(exception.CancellationToken);
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
        return Task.FromException<TResult>(exception);
    }

    #endregion
}