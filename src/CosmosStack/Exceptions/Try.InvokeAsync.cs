namespace Cosmos.Exceptions;

/// <summary>
/// Try <br />
/// Try 组件
/// </summary>
public static partial class Try
{
    #region InvokeAsync

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync(Task<Action> InvokeAsyncAction, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction();
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="obj"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T>(Task<Action<T>> InvokeAsyncAction, T obj, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(obj);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2>(Task<Action<T1, T2>> InvokeAsyncAction, T1 arg1, T2 arg2, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3>(Task<Action<T1, T2, T3>> InvokeAsyncAction, T1 arg1, T2 arg2, T3 arg3, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4>(Task<Action<T1, T2, T3, T4>> InvokeAsyncAction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4, T5>(Task<Action<T1, T2, T3, T4, T5>> InvokeAsyncAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4, arg5);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4, T5, T6>(Task<Action<T1, T2, T3, T4, T5, T6>> InvokeAsyncAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="arg7"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4, T5, T6, T7>(Task<Action<T1, T2, T3, T4, T5, T6, T7>> InvokeAsyncAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="arg7"></param>
    /// <param name="arg8"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8>(Task<Action<T1, T2, T3, T4, T5, T6, T7, T8>> InvokeAsyncAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="arg7"></param>
    /// <param name="arg8"></param>
    /// <param name="arg9"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> InvokeAsyncAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="arg7"></param>
    /// <param name="arg8"></param>
    /// <param name="arg9"></param>
    /// <param name="arg10"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> InvokeAsyncAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="arg7"></param>
    /// <param name="arg8"></param>
    /// <param name="arg9"></param>
    /// <param name="arg10"></param>
    /// <param name="arg11"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> InvokeAsyncAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="arg7"></param>
    /// <param name="arg8"></param>
    /// <param name="arg9"></param>
    /// <param name="arg10"></param>
    /// <param name="arg11"></param>
    /// <param name="arg12"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> InvokeAsyncAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="arg7"></param>
    /// <param name="arg8"></param>
    /// <param name="arg9"></param>
    /// <param name="arg10"></param>
    /// <param name="arg11"></param>
    /// <param name="arg12"></param>
    /// <param name="arg13"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> InvokeAsyncAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="arg7"></param>
    /// <param name="arg8"></param>
    /// <param name="arg9"></param>
    /// <param name="arg10"></param>
    /// <param name="arg11"></param>
    /// <param name="arg12"></param>
    /// <param name="arg13"></param>
    /// <param name="arg14"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> InvokeAsyncAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="arg7"></param>
    /// <param name="arg8"></param>
    /// <param name="arg9"></param>
    /// <param name="arg10"></param>
    /// <param name="arg11"></param>
    /// <param name="arg12"></param>
    /// <param name="arg13"></param>
    /// <param name="arg14"></param>
    /// <param name="arg15"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> InvokeAsyncAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="InvokeAsyncAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="arg7"></param>
    /// <param name="arg8"></param>
    /// <param name="arg9"></param>
    /// <param name="arg10"></param>
    /// <param name="arg11"></param>
    /// <param name="arg12"></param>
    /// <param name="arg13"></param>
    /// <param name="arg14"></param>
    /// <param name="arg15"></param>
    /// <param name="arg16"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static async Task<TryAction> InvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> InvokeAsyncAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, string? cause = null)
    {
        try
        {
            TaskGuard(InvokeAsyncAction, nameof(InvokeAsyncAction));
            var invokeAction = await InvokeAsyncAction;
            NotNull(invokeAction, nameof(invokeAction));
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
            return new SuccessAction(InvokeAsyncAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, InvokeAsyncAction?.GetHashCode() ?? 0, cause);
        }
    }

    #endregion
}