namespace Cosmos.Exceptions;

/// <summary>
/// Try extensions. <br />
/// Try 组件扩展
/// </summary>
public static partial class TryExtensions
{
    #region Factory extensions - ToTryInvoke

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T>(this IEnumerable<T> coll, Action<T> invokeAction, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2>(this IEnumerable<T1> coll, Action<T1, T2> invokeAction, Func<int, T2> arg2Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3>(this IEnumerable<T1> coll, Action<T1, T2, T3> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4>(this IEnumerable<T1> coll, Action<T1, T2, T3, T4> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="arg5Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4, T5>(this IEnumerable<T1> coll, Action<T1, T2, T3, T4, T5> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="arg5Func"></param>
    /// <param name="arg6Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4, T5, T6>(this IEnumerable<T1> coll, Action<T1, T2, T3, T4, T5, T6> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, Func<int, T6> arg6Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, arg6Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="arg5Func"></param>
    /// <param name="arg6Func"></param>
    /// <param name="arg7Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4, T5, T6, T7>(this IEnumerable<T1> coll, Action<T1, T2, T3, T4, T5, T6, T7> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, Func<int, T6> arg6Func,
        Func<int, T7> arg7Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, arg6Func, arg7Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="arg5Func"></param>
    /// <param name="arg6Func"></param>
    /// <param name="arg7Func"></param>
    /// <param name="arg8Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4, T5, T6, T7, T8>(this IEnumerable<T1> coll, Action<T1, T2, T3, T4, T5, T6, T7, T8> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, Func<int, T6> arg6Func,
        Func<int, T7> arg7Func, Func<int, T8> arg8Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, arg6Func, arg7Func, arg8Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="arg5Func"></param>
    /// <param name="arg6Func"></param>
    /// <param name="arg7Func"></param>
    /// <param name="arg8Func"></param>
    /// <param name="arg9Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEnumerable<T1> coll, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, Func<int, T6> arg6Func,
        Func<int, T7> arg7Func, Func<int, T8> arg8Func, Func<int, T9> arg9Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, arg6Func, arg7Func,
            arg8Func, arg9Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="arg5Func"></param>
    /// <param name="arg6Func"></param>
    /// <param name="arg7Func"></param>
    /// <param name="arg8Func"></param>
    /// <param name="arg9Func"></param>
    /// <param name="arg10Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    /// <typeparam name="T10"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IEnumerable<T1> coll, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, Func<int, T6> arg6Func,
        Func<int, T7> arg7Func, Func<int, T8> arg8Func, Func<int, T9> arg9Func, Func<int, T10> arg10Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, arg6Func, arg7Func,
            arg8Func, arg9Func, arg10Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="arg5Func"></param>
    /// <param name="arg6Func"></param>
    /// <param name="arg7Func"></param>
    /// <param name="arg8Func"></param>
    /// <param name="arg9Func"></param>
    /// <param name="arg10Func"></param>
    /// <param name="arg11Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    /// <typeparam name="T10"></typeparam>
    /// <typeparam name="T11"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IEnumerable<T1> coll, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, Func<int, T6> arg6Func,
        Func<int, T7> arg7Func, Func<int, T8> arg8Func, Func<int, T9> arg9Func, Func<int, T10> arg10Func, Func<int, T11> arg11Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, arg6Func, arg7Func,
            arg8Func, arg9Func, arg10Func, arg11Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="arg5Func"></param>
    /// <param name="arg6Func"></param>
    /// <param name="arg7Func"></param>
    /// <param name="arg8Func"></param>
    /// <param name="arg9Func"></param>
    /// <param name="arg10Func"></param>
    /// <param name="arg11Func"></param>
    /// <param name="arg12Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    /// <typeparam name="T10"></typeparam>
    /// <typeparam name="T11"></typeparam>
    /// <typeparam name="T12"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IEnumerable<T1> coll, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, Func<int, T6> arg6Func,
        Func<int, T7> arg7Func, Func<int, T8> arg8Func, Func<int, T9> arg9Func, Func<int, T10> arg10Func, Func<int, T11> arg11Func,
        Func<int, T12> arg12Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, arg6Func, arg7Func,
            arg8Func, arg9Func, arg10Func, arg11Func, arg12Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="arg5Func"></param>
    /// <param name="arg6Func"></param>
    /// <param name="arg7Func"></param>
    /// <param name="arg8Func"></param>
    /// <param name="arg9Func"></param>
    /// <param name="arg10Func"></param>
    /// <param name="arg11Func"></param>
    /// <param name="arg12Func"></param>
    /// <param name="arg13Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    /// <typeparam name="T10"></typeparam>
    /// <typeparam name="T11"></typeparam>
    /// <typeparam name="T12"></typeparam>
    /// <typeparam name="T13"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IEnumerable<T1> coll, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, Func<int, T6> arg6Func,
        Func<int, T7> arg7Func, Func<int, T8> arg8Func, Func<int, T9> arg9Func, Func<int, T10> arg10Func, Func<int, T11> arg11Func,
        Func<int, T12> arg12Func, Func<int, T13> arg13Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, arg6Func, arg7Func,
            arg8Func, arg9Func, arg10Func, arg11Func, arg12Func, arg13Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="arg5Func"></param>
    /// <param name="arg6Func"></param>
    /// <param name="arg7Func"></param>
    /// <param name="arg8Func"></param>
    /// <param name="arg9Func"></param>
    /// <param name="arg10Func"></param>
    /// <param name="arg11Func"></param>
    /// <param name="arg12Func"></param>
    /// <param name="arg13Func"></param>
    /// <param name="arg14Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    /// <typeparam name="T10"></typeparam>
    /// <typeparam name="T11"></typeparam>
    /// <typeparam name="T12"></typeparam>
    /// <typeparam name="T13"></typeparam>
    /// <typeparam name="T14"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IEnumerable<T1> coll, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, Func<int, T6> arg6Func,
        Func<int, T7> arg7Func, Func<int, T8> arg8Func, Func<int, T9> arg9Func, Func<int, T10> arg10Func, Func<int, T11> arg11Func,
        Func<int, T12> arg12Func, Func<int, T13> arg13Func, Func<int, T14> arg14Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, arg6Func, arg7Func,
            arg8Func, arg9Func, arg10Func, arg11Func, arg12Func, arg13Func, arg14Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="arg5Func"></param>
    /// <param name="arg6Func"></param>
    /// <param name="arg7Func"></param>
    /// <param name="arg8Func"></param>
    /// <param name="arg9Func"></param>
    /// <param name="arg10Func"></param>
    /// <param name="arg11Func"></param>
    /// <param name="arg12Func"></param>
    /// <param name="arg13Func"></param>
    /// <param name="arg14Func"></param>
    /// <param name="arg15Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    /// <typeparam name="T10"></typeparam>
    /// <typeparam name="T11"></typeparam>
    /// <typeparam name="T12"></typeparam>
    /// <typeparam name="T13"></typeparam>
    /// <typeparam name="T14"></typeparam>
    /// <typeparam name="T15"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IEnumerable<T1> coll, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, Func<int, T6> arg6Func,
        Func<int, T7> arg7Func, Func<int, T8> arg8Func, Func<int, T9> arg9Func, Func<int, T10> arg10Func, Func<int, T11> arg11Func,
        Func<int, T12> arg12Func, Func<int, T13> arg13Func, Func<int, T14> arg14Func, Func<int, T15> arg15Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, arg6Func, arg7Func,
            arg8Func, arg9Func, arg10Func, arg11Func, arg12Func, arg13Func, arg14Func, arg15Func, cause);
    }

    /// <summary>
    /// Create a set of instance of <see cref="TryAction"/>. <br />
    /// 尝试调用委托，预备返回一组 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="invokeAction"></param>
    /// <param name="arg2Func"></param>
    /// <param name="arg3Func"></param>
    /// <param name="arg4Func"></param>
    /// <param name="arg5Func"></param>
    /// <param name="arg6Func"></param>
    /// <param name="arg7Func"></param>
    /// <param name="arg8Func"></param>
    /// <param name="arg9Func"></param>
    /// <param name="arg10Func"></param>
    /// <param name="arg11Func"></param>
    /// <param name="arg12Func"></param>
    /// <param name="arg13Func"></param>
    /// <param name="arg14Func"></param>
    /// <param name="arg15Func"></param>
    /// <param name="arg16Func"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    /// <typeparam name="T10"></typeparam>
    /// <typeparam name="T11"></typeparam>
    /// <typeparam name="T12"></typeparam>
    /// <typeparam name="T13"></typeparam>
    /// <typeparam name="T14"></typeparam>
    /// <typeparam name="T15"></typeparam>
    /// <typeparam name="T16"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IEnumerable<T1> coll,
        Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> invokeAction,
        Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, Func<int, T6> arg6Func,
        Func<int, T7> arg7Func, Func<int, T8> arg8Func, Func<int, T9> arg9Func, Func<int, T10> arg10Func, Func<int, T11> arg11Func,
        Func<int, T12> arg12Func, Func<int, T13> arg13Func, Func<int, T14> arg14Func, Func<int, T15> arg15Func, Func<int, T16> arg16Func, string? cause = null)
    {
        return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, arg6Func, arg7Func,
            arg8Func, arg9Func, arg10Func, arg11Func, arg12Func, arg13Func, arg14Func, arg15Func, arg16Func, cause);
    }

    #endregion
}