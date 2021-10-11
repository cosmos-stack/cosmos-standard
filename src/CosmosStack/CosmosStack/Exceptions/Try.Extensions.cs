using System;
using System.Collections.Generic;

namespace CosmosStack.Exceptions
{
    /// <summary>
    /// Try extensions. <br />
    /// Try 组件扩展
    /// </summary>
    public static class TryExtensions
    {
        #region LINQ extensions

        /// <summary>
        /// Select <br />
        /// 选择
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> Select<TSource, TResult>(this Try<TSource> source, Func<TSource, TResult> selector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));
            return source.Bind(val => Try.LiftValue(selector(val)));
        }

        /// <summary>
        /// Select many <br />
        /// 选择
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> SelectMany<TSource, TResult>(this Try<TSource> source, Func<TSource, Try<TResult>> selector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));
            return source.Bind(selector);
        }

        /// <summary>
        /// Select many <br />
        /// 选择
        /// </summary>
        /// <param name="source"></param>
        /// <param name="convert"></param>
        /// <param name="selector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TIntermediate"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> SelectMany<TSource, TIntermediate, TResult>(this Try<TSource> source,
            Func<TSource, Try<TIntermediate>> convert, Func<TSource, TIntermediate, TResult> selector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (convert is null)
                throw new ArgumentNullException(nameof(convert));
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));
            return source.Bind(val => convert(val).Select(interVal => selector(val, interVal)));
        }

        /// <summary>
        /// Where <br />
        /// 条件筛选
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Try<TSource> Where<TSource>(this Try<TSource> source, Func<TSource, bool> predicate)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return source.Bind(val => predicate(val) ? source : Try.LiftException<TSource>(new InvalidOperationException("Predicate not satisfied")));
        }

        #endregion

        #region Factory extensions - TryActionInvoke

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="cause"></param>
        /// <returns></returns>
        public static TryAction TryInvoke(this Action action, string cause = null) => Try.Invoke(action, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="TryAction"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="obj"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static TryAction TryInvoke<T>(this Action<T> action, T obj, string cause = null) => Try.Invoke(action, obj, cause);

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
        public static TryAction TryInvoke<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2, string cause = null) => Try.Invoke(action, arg1, arg2, cause);

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
        public static TryAction TryInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3, string cause = null) => Try.Invoke(action, arg1, arg2, arg3, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, cause);

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
        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16, cause);

        #endregion

        #region Factory extensions - TryActionFutureInvoke

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

        #endregion

        #region Factory extensions - TryFuncInvoke

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
        /// </summary>
        /// <param name="func"></param>
        /// <param name="cause"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<TResult>(this Func<TResult> func, string cause = null) => Try.Create(func, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T, TResult>(this Func<T, TResult> func, T arg, string cause = null) => Try.Create(func, arg, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 arg1, T2 arg2, string cause = null)
            => Try.Create(func, arg1, arg2, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 arg1, T2 arg2, T3 arg3, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
        /// </summary>
        /// <param name="func"></param>
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
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
        /// </summary>
        /// <param name="func"></param>
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
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
        /// </summary>
        /// <param name="func"></param>
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
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
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
        /// <param name="cause"></param>
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
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
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
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
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
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
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
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
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
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
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
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
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
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
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
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, cause);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 尝试调用委托，返回一个 <see cref="Try{TResult}"/> 实例。
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
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16, cause);

        #endregion

        #region Factory extensions - TryFuncFutureInvoke

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
        /// </summary>
        /// <param name="func"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder<TResult> TryFuncFutureInvoke<TResult>(this Func<TResult> func) => Try.CreateFuture(func);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
        /// </summary>
        /// <param name="func"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder<T, TResult> TryFuncFutureInvoke<T, TResult>(this Func<T, TResult> func) => Try.CreateFuture(func);

        /// <summary>
        /// Try to invoke and create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 尝试调用委托，预备返回一个 <see cref="Try{TResult}"/> 实例。
        /// </summary>
        /// <param name="func"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder<T1, T2, TResult> TryFuncFutureInvoke<T1, T2, TResult>(
            this Func<T1, T2, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, TResult> TryFuncFutureInvoke<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, TResult>(
            this Func<T1, T2, T3, T4, T5, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func) => Try.CreateFuture(func);

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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func) => Try.CreateFuture(func);

        #endregion

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
        public static IEnumerable<TryAction> ToTryInvokeRange<T>(this IEnumerable<T> coll, Action<T> invokeAction, string cause = null)
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
        public static IEnumerable<TryAction> ToTryInvokeRange<T1, T2>(this IEnumerable<T1> coll, Action<T1, T2> invokeAction, Func<int, T2> arg2Func, string cause = null)
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
            Func<int, T2> arg2Func, Func<int, T3> arg3Func, string cause = null)
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
            Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, string cause = null)
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
            Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, string cause = null)
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
            Func<int, T2> arg2Func, Func<int, T3> arg3Func, Func<int, T4> arg4Func, Func<int, T5> arg5Func, Func<int, T6> arg6Func, string cause = null)
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
            Func<int, T7> arg7Func, string cause = null)
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
            Func<int, T7> arg7Func, Func<int, T8> arg8Func, string cause = null)
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
            Func<int, T7> arg7Func, Func<int, T8> arg8Func, Func<int, T9> arg9Func, string cause = null)
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
            Func<int, T7> arg7Func, Func<int, T8> arg8Func, Func<int, T9> arg9Func, Func<int, T10> arg10Func, string cause = null)
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
            Func<int, T7> arg7Func, Func<int, T8> arg8Func, Func<int, T9> arg9Func, Func<int, T10> arg10Func, Func<int, T11> arg11Func, string cause = null)
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
            Func<int, T12> arg12Func, string cause = null)
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
            Func<int, T12> arg12Func, Func<int, T13> arg13Func, string cause = null)
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
            Func<int, T12> arg12Func, Func<int, T13> arg13Func, Func<int, T14> arg14Func, string cause = null)
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
            Func<int, T12> arg12Func, Func<int, T13> arg13Func, Func<int, T14> arg14Func, Func<int, T15> arg15Func, string cause = null)
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
            Func<int, T12> arg12Func, Func<int, T13> arg13Func, Func<int, T14> arg14Func, Func<int, T15> arg15Func, Func<int, T16> arg16Func, string cause = null)
        {
            return Try.InvokeRange(coll, invokeAction, arg2Func, arg3Func, arg4Func, arg5Func, arg6Func, arg7Func,
                arg8Func, arg9Func, arg10Func, arg11Func, arg12Func, arg13Func, arg14Func, arg15Func, arg16Func, cause);
        }

        #endregion
    }
}