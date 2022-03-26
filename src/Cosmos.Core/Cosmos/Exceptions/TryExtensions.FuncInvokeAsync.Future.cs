namespace Cosmos.Exceptions;

/*
 * TryEx / Factory extensions - TryFuncFutureInvoke
 */

/// <summary>
/// Try extensions. <br />
/// Try 组件扩展
/// </summary>
public static partial class TryExtensions
{
    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<TResult> TryFuncFutureInvoke<TResult>(this Func<Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T, TResult> TryFuncFutureInvoke<T, TResult>(this Func<T, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, TResult> TryFuncFutureInvoke<T1, T2, TResult>(
        this Func<T1, T2, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, TResult> TryFuncFutureInvoke<T1, T2, T3, TResult>(
        this Func<T1, T2, T3, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, TResult>(
        this Func<T1, T2, T3, T4, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, TResult>(
        this Func<T1, T2, T3, T4, T5, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
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
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
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
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
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
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
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
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
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
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
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
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task<TResult>> func) => Try.CreateFuture(func);

    /// <summary>
    /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
    /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
    /// </summary>
    /// <param name="func"></param>
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
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Task<TResult>> func) => Try.CreateFuture(func);
}