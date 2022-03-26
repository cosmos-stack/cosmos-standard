namespace Cosmos.Exceptions;

/*
 * TryEx / Factory extensions - TryActionFutureInvoke
 */

/// <summary>
/// Try extensions. <br />
/// Try 组件扩展
/// </summary>
public static partial class TryExtensions
{
    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public static FutureInvokingBuilder TryFutureInvoke(this Action action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder<T> TryFutureInvoke<T>(this Action<T> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder<T1, T2> TryFutureInvoke<T1, T2>(
        this Action<T1, T2> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder<T1, T2, T3> TryFutureInvoke<T1, T2, T3>(
        this Action<T1, T2, T3> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder<T1, T2, T3, T4> TryFutureInvoke<T1, T2, T3, T4>(
        this Action<T1, T2, T3, T4> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder<T1, T2, T3, T4, T5> TryFutureInvoke<T1, T2, T3, T4, T5>(
        this Action<T1, T2, T3, T4, T5> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6> TryFutureInvoke<T1, T2, T3, T4, T5, T6>(
        this Action<T1, T2, T3, T4, T5, T6> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7>(
        this Action<T1, T2, T3, T4, T5, T6, T7> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
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
    public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
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
    public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
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
    public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
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
    public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
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
    public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
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
    public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
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
    public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) => Try.Future(action);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="action"></param>
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
    public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) => Try.Future(action);
}