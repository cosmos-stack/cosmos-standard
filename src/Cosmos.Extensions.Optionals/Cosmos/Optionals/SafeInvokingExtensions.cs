using System;

namespace Cosmos.Optionals
{
    /// <summary>
    /// Cosmos safe invoking extensions
    /// </summary>
    public static class SafeInvokingExtensions
    {
        #region SafeInvoke
        
        /// <summary>
        /// Invoke the given <see cref="EventHandler"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="sender"></param>
        public static void SafeInvoke(this EventHandler handler, object sender) =>
            handler.SafeInvoke(sender, EventArgs.Empty);

        /// <summary>
        /// Invoke the given <see cref="EventHandler"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SafeInvoke(this EventHandler handler, object sender, EventArgs e) =>
            handler?.Invoke(sender, e);

        /// <summary>
        /// Invoke the given <see cref="EventHandler{TEventArgs}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <typeparam name="TEventArgs"></typeparam>
        /// <param name="handler"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SafeInvoke<TEventArgs>(this EventHandler<TEventArgs> handler, object sender, TEventArgs e) =>
            handler?.Invoke(sender, e);
        
        #endregion

        #region SafeActionInvoke

        /// <summary>
        /// Invoke the given <see cref="Action"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="action"></param>
        public static void SafeInvoke(this Action action) => action?.Invoke();

        /// <summary>
        /// Invoke the given <see cref="Action{T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public static void SafeInvoke<T>(this Action<T> action, T obj) => action?.Invoke(obj);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void SafeInvoke<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2) => action?.Invoke(arg1, arg2);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public static void SafeInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
            => action?.Invoke(arg1, arg2, arg3);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        public static void SafeInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => action?.Invoke(arg1, arg2, arg3, arg4);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4, T5}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        public static void SafeInvoke<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => action?.Invoke(arg1, arg2, arg3, arg4, arg5);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4, T5, T6}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        public static void SafeInvoke<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        public static void SafeInvoke<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
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
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        public static void SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
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
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        public static void SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
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
        public static void SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
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
        public static void SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
            => action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
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
        public static void SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
            => action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
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
        public static void SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
            => action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
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
        public static void SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
            => action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
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
        public static void SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
            => action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);

        /// <summary>
        /// Invoke the given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
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
        public static void SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
            => action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        
        #endregion

        #region SafeFuncInvoke

        /// <summary>
        /// Invoke the given <see cref="Func{TResult}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static TResult SafeFuncInvoke<TResult>(this Func<TResult> func) => func is null ? default : func.Invoke();

        /// <summary>
        /// Invoke the given <see cref="Func{T, TResult}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static TResult SafeFuncInvoke<T, TResult>(this Func<T, TResult> func, T arg) => func is null ? default : func.Invoke(arg);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T>(this Func<T1, T2, T> func, T1 arg1, T2 arg2) => func is null ? default : func.Invoke(arg1, arg2);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T>(this Func<T1, T2, T3, T> func, T1 arg1, T2 arg2, T3 arg3) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T>(this Func<T1, T2, T3, T4, T> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T5, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T5, T>(this Func<T1, T2, T3, T4, T5, T> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4, arg5);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T5, T6, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T5, T6, T>(this Func<T1, T2, T3, T4, T5, T6, T> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T>(this Func<T1, T2, T3, T4, T5, T6, T7, T> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        /// <param name="arg9"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);

        /// <summary>
        /// Invoke the given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="func"></param>
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
        /// <typeparam name="T"></typeparam>
        public static T SafeFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) =>
            func is null ? default : func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        
        #endregion
    }
}