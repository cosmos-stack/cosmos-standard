namespace Cosmos.Exceptions;

/*
 * Try / Invoke async in the future
 */

/// <summary>
/// Try <br />
/// Try 组件
/// </summary>
public static partial class Try
{
    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <returns></returns>
    public static FutureInvokingBuilder2 Future(Task<Action> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder2<T> Future<T>(Task<Action<T>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder2<T1, T2> Future<T1, T2>(
        Task<Action<T1, T2>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder2<T1, T2, T3> Future<T1, T2, T3>(
        Task<Action<T1, T2, T3>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder2<T1, T2, T3, T4> Future<T1, T2, T3, T4>(
        Task<Action<T1, T2, T3, T4>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder2<T1, T2, T3, T4, T5> Future<T1, T2, T3, T4, T5>(
        Task<Action<T1, T2, T3, T4, T5>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder2<T1, T2, T3, T4, T5, T6> Future<T1, T2, T3, T4, T5, T6>(
        Task<Action<T1, T2, T3, T4, T5, T6>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder2<T1, T2, T3, T4, T5, T6, T7> Future<T1, T2, T3, T4, T5, T6, T7>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <returns></returns>
    public static FutureInvokingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8> Future<T1, T2, T3, T4, T5, T6, T7, T8>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static FutureInvokingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static FutureInvokingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static FutureInvokingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static FutureInvokingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static FutureInvokingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static FutureInvokingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static FutureInvokingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> invokeAction) => new(invokeAction);

    /// <summary>
    /// Create a new instance of <see cref="TryAction"/> in the future. <br />
    /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
    /// </summary>
    /// <param name="invokeAction"></param>
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
    public static FutureInvokingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
        Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> invokeAction) => new(invokeAction);
}