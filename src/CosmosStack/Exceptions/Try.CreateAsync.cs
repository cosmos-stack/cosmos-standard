namespace Cosmos.Exceptions;

/// <summary>
/// Try <br />
/// Try 组件
/// </summary>
public static partial class Try
{
    #region Create from Task

    /// <summary>
    /// Create for asynchronous functions. <br />
    /// 为异步的 Function 创建一个 <see cref="Try{T}"/> 实例。
    /// </summary>
    /// <param name="createFunctionAsync"></param>
    /// <param name="cause"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Try<T> CreateFromTask<T>(Func<Task<T>> createFunctionAsync, string? cause = null, CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke();
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<TResult> CreateFromTask<T, TResult>(Func<T, Task<TResult>> createFunctionAsync, T arg, string? cause = null, CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<TResult>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T>(Func<T1, T2, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, string? cause = null, CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T>(Func<T1, T2, T3, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, string? cause = null, CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T>(Func<T1, T2, T3, T4, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, T4 arg4, string? cause = null, CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T5, T>(Func<T1, T2, T3, T4, T5, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, string? cause = null, CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4, arg5);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T5, T6, T>(Func<T1, T2, T3, T4, T5, T6, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, string? cause = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T5, T6, T7, T>(Func<T1, T2, T3, T4, T5, T6, T7, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, string? cause = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T5, T6, T7, T8, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, string? cause = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9,
        string? cause = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9,
        T10 arg10, string? cause = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
        T9 arg9, T10 arg10, T11 arg11, string? cause = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7,
        T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, string? cause = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6,
        T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, string? cause = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5,
        T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, string? cause = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3, T4 arg4,
        T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, string? cause = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    public static Try<T> CreateFromTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Task<T>> createFunctionAsync, T1 arg1, T2 arg2, T3 arg3,
        T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, string? cause = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            NotNull(createFunctionAsync, nameof(createFunctionAsync));
            var task = createFunctionAsync.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
            TaskGuard(task, nameof(createFunctionAsync));
            return LiftValue(ThenWaitAndUnwrapException(task, cancellationToken));
        }
        catch (Exception ex)
        {
            return LiftException<T>(ex, cause);
        }
    }

    private static TResult ThenWaitAndUnwrapException<TResult>(Task<TResult> task, CancellationToken cancellationToken)
    {
        if (task is null)
        {
            throw new ArgumentNullException(nameof(task));
        }

        try
        {
            task.Wait(cancellationToken);
            return task.Result;
        }
        catch (AggregateException ex)
        {
            throw ExceptionHelper.PrepareForRethrow(ex.InnerException);
        }
    }

    #endregion
}