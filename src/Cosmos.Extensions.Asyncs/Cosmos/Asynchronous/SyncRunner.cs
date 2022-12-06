using Cosmos.Exceptions;
using Nito.AsyncEx.Synchronous;

namespace Cosmos.Asynchronous;

/// <summary>
/// Sync runner <br />
/// 同步运行器
/// </summary>
public static class SyncRunner
{
    /// <summary>
    /// For asynchronous calling <br />
    /// 在同步环境下，调用异步的任务
    /// </summary>
    /// <param name="task"></param>
    /// <param name="cancellationToken"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForAsynchronousCalling(Task task, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(task);
        task.WaitAndUnwrapException(cancellationToken);
    }

    /// <summary>
    /// For asynchronous calling <br />
    /// 在同步环境下，调用异步的任务
    /// </summary>
    /// <param name="taskFunc"></param>
    /// <param name="cancellationToken"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForAsynchronousCalling(Func<Task> taskFunc, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(taskFunc);
        Try.Create(taskFunc).GetValue()?.WaitAndUnwrapException(cancellationToken);
    }

    /// <summary>
    /// For asynchronous calling safety <br />
    /// 在同步环境下，安全地调用异步的任务
    /// </summary>
    /// <param name="task"></param>
    /// <param name="cancellationToken"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForAsynchronousCallingSafety(Task task, CancellationToken cancellationToken = default)
    {
        task.WaitWithoutException(cancellationToken);
    }

    /// <summary>
    /// For asynchronous calling safety <br />
    /// 在同步环境下，安全地调用异步的任务
    /// </summary>
    /// <param name="taskFunc"></param>
    /// <param name="cancellationToken"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForAsynchronousCallingSafety(Func<Task> taskFunc, CancellationToken cancellationToken = default)
    {
        Try.Create(taskFunc).GetSafeValue().WaitWithoutException(cancellationToken);
    }

    /// <summary>
    /// For asynchronous calling safety and forget <br />
    /// 在同步环境下，安全地调用异步的任务，并忽略其后的结果
    /// </summary>
    /// <param name="task"></param>
    /// <param name="exceptionAction"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForAsynchronousCallingSafetyAndForget(Task task, Action<Exception> exceptionAction = null)
    {
        task.SafeFireAndForget(exceptionAction);
    }

    /// <summary>
    /// For asynchronous calling safety and forget <br />
    /// 在同步环境下，安全地调用异步的任务，并忽略其后的结果
    /// </summary>
    /// <param name="taskFunc"></param>
    /// <param name="exceptionAction"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForAsynchronousCallingSafetyAndForget(Func<Task> taskFunc, Action<Exception> exceptionAction = null)
    {
        taskFunc.Invoke().SafeFireAndForget(exceptionAction);
    }

    /// <summary>
    /// From asynchronous calling <br />
    /// 在同步环境下，安全地调用异步的任务
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="task"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TResult FromAsynchronousCalling<TResult>(Task<TResult> task, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(task);
        return task.WaitAndUnwrapException(cancellationToken);
    }

    /// <summary>
    /// From asynchronous calling <br />
    /// 在同步环境下，安全地调用异步的任务
    /// </summary>
    /// <param name="taskFunc"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static TResult FromAsynchronousCalling<TResult>(Func<Task<TResult>> taskFunc, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(taskFunc);

        var task = Try.Create(taskFunc).GetValue();

        if (task is null)
            throw new InvalidOperationException($"The task factory {nameof(taskFunc)} failed to run.");

        return task.WaitAndUnwrapException(cancellationToken);
    }

    /// <summary>
    /// From asynchronous calling safety <br />
    /// 在同步环境下，安全地调用异步的任务
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="task"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TResult FromAsynchronousCallingSafety<TResult>(Task<TResult> task, CancellationToken cancellationToken = default)
    {
        return FromAsynchronousCallingSafety(task, default(TResult), cancellationToken);
    }

    /// <summary>
    /// From asynchronous calling safety <br />
    /// 在同步环境下，安全地调用异步的任务
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="taskFunc"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TResult FromAsynchronousCallingSafety<TResult>(Func<Task<TResult>> taskFunc, CancellationToken cancellationToken = default)
    {
        return FromAsynchronousCallingSafety(taskFunc, default(TResult), cancellationToken);
    }

    /// <summary>
    /// From asynchronous calling safety <br />
    /// 在同步环境下，安全地调用异步的任务
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="task"></param>
    /// <param name="defaultValue"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static TResult FromAsynchronousCallingSafety<TResult>(Task<TResult> task, TResult defaultValue, CancellationToken cancellationToken = default)
    {
        if (task is null)
            return defaultValue;

        return Try
               .Create(() => FromAsynchronousCalling(task, cancellationToken))
               .GetSafeValue(defaultValue);
    }

    /// <summary>
    /// From asynchronous calling safety <br />
    /// 在同步环境下，安全地调用异步的任务
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="taskFunc"></param>
    /// <param name="defaultValue"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static TResult FromAsynchronousCallingSafety<TResult>(Func<Task<TResult>> taskFunc, TResult defaultValue, CancellationToken cancellationToken = default)
    {
        if (taskFunc is null)
            return defaultValue;

        var task = Try.Create(taskFunc).GetSafeValue();

        if (task is null)
            return defaultValue;

        return Try
               .Create(() => FromAsynchronousCalling(task, cancellationToken))
               .GetSafeValue(defaultValue);
    }

    /// <summary>
    /// From asynchronous calling safety <br />
    /// 在同步环境下，安全地调用异步的任务
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="task"></param>
    /// <param name="defaultValueFunc"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static TResult FromAsynchronousCallingSafety<TResult>(Task<TResult> task, Func<TResult> defaultValueFunc, CancellationToken cancellationToken = default)
    {
        if (defaultValueFunc is null)
            return default;

        if (task is null)
            return defaultValueFunc();

        return Try
               .Create(() => FromAsynchronousCalling(task, cancellationToken))
               .GetSafeValue(defaultValueFunc);
    }

    /// <summary>
    /// From asynchronous calling safety <br />
    /// 在同步环境下，安全地调用异步的任务
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="taskFunc"></param>
    /// <param name="defaultValueFunc"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static TResult FromAsynchronousCallingSafety<TResult>(Func<Task<TResult>> taskFunc, Func<TResult> defaultValueFunc, CancellationToken cancellationToken = default)
    {
        if (defaultValueFunc is null)
            return default;

        if (taskFunc is null)
            return defaultValueFunc();

        var task = Try.Create(taskFunc).GetSafeValue();

        if (task is null)
            return defaultValueFunc();

        return Try
               .Create(() => FromAsynchronousCalling(task, cancellationToken))
               .GetSafeValue(defaultValueFunc);
    }
}