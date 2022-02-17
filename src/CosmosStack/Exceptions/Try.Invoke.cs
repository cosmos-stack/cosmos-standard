namespace Cosmos.Exceptions;

/// <summary>
/// Try <br />
/// Try 组件
/// </summary>
public static partial class Try
{
    #region Invoke

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static TryAction Invoke(Action invokeAction, string? cause = null)
    {
        try
        {
            invokeAction();
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <param name="obj"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static TryAction Invoke<T>(Action<T> invokeAction, T obj, string? cause = null)
    {
        try
        {
            invokeAction(obj);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static TryAction Invoke<T1, T2>(Action<T1, T2> invokeAction, T1 arg1, T2 arg2, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static TryAction Invoke<T1, T2, T3>(Action<T1, T2, T3> invokeAction, T1 arg1, T2 arg2, T3 arg3, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static TryAction Invoke<T1, T2, T3, T4>(Action<T1, T2, T3, T4> invokeAction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static TryAction Invoke<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> invokeAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4, arg5);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static TryAction Invoke<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> invokeAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <param name="arg7"></param>
    /// <param name="cause"></param>
    /// <returns></returns>
    public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> invokeAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> invokeAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> invokeAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> invokeAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
        Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> invokeAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
        Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> invokeAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
        Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> invokeAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
        Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> invokeAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
        Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> invokeAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/>. <br />
    /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
        Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> invokeAction,
        T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, string? cause = null)
    {
        try
        {
            invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
            return new SuccessAction(invokeAction.GetHashCode());
        }
        catch (Exception ex)
        {
            return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0, cause);
        }
    }

    #endregion
}