using System;
using System.Threading.Tasks;

namespace CosmosStack.Exceptions
{
    /// <summary>
    /// Try extensions. <br />
    /// Try 组件扩展
    /// </summary>
    public static partial class TryExtensions
    {
    #region Factory extensions - TryActionInvokeAsync

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="cause"></param>
        /// <returns></returns>
        public static async Task<TryAction> TryInvokeAsync(this Task<Action> action, string cause = null) => await Try.InvokeAsync(action, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="obj"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<TryAction> TryInvokeAsync<T>(this Task<Action<T>> action, T obj, string cause = null) => await Try.InvokeAsync(action, obj, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static async Task<TryAction> TryInvokeAsync<T1, T2>(this Task<Action<T1, T2>> action, T1 arg1, T2 arg2, string cause = null) => await Try.InvokeAsync(action, arg1, arg2, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3>(this Task<Action<T1, T2, T3>> action, T1 arg1, T2 arg2, T3 arg3, string cause = null) => await Try.InvokeAsync(action, arg1, arg2, arg3, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4>(this Task<Action<T1, T2, T3, T4>> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4, T5>(this Task<Action<T1, T2, T3, T4, T5>> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, arg5, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4, T5, T6>(this Task<Action<T1, T2, T3, T4, T5, T6>> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, arg5, arg6, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4, T5, T6, T7>(this Task<Action<T1, T2, T3, T4, T5, T6, T7>> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
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
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8>(this Task<Action<T1, T2, T3, T4, T5, T6, T7, T8>> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
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
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
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
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
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
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
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
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
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
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
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
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
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
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
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
        public static async Task<TryAction> TryInvokeAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Task<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, string cause = null)
            => await Try.InvokeAsync(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16, cause);

        #endregion
    }
}