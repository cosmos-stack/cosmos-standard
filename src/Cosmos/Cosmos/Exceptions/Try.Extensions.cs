using System;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Cosmos Try extensions.
    /// </summary>
    public static class TryExtensions
    {
        #region LINQ extensions

        /// <summary>
        /// Select
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
        /// Select many
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
        /// Select many
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
        /// Where
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

        public static TryAction TryInvoke(this Action action, string cause = null) => Try.Invoke(action, cause);

        public static TryAction TryInvoke<T>(this Action<T> action, T obj, string cause = null) => Try.Invoke(action, obj, cause);

        public static TryAction TryInvoke<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2, string cause = null) => Try.Invoke(action, arg1, arg2, cause);

        public static TryAction TryInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, cause);

        public static TryAction TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, string cause = null)
            => Try.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16, cause);

        #endregion

        #region Factory extensions - TryActionFutureInvoke

        public static FutureInvokingBuilder TryFutureInvoke(this Action action) => Try.Future(action);

        public static FutureInvokingBuilder<T> TryFutureInvoke<T>(this Action<T> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2> TryFutureInvoke<T1, T2>(
            this Action<T1, T2> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3> TryFutureInvoke<T1, T2, T3>(
            this Action<T1, T2, T3> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4> TryFutureInvoke<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4, T5> TryFutureInvoke<T1, T2, T3, T4, T5>(
            this Action<T1, T2, T3, T4, T5> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6> TryFutureInvoke<T1, T2, T3, T4, T5, T6>(
            this Action<T1, T2, T3, T4, T5, T6> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7>(
            this Action<T1, T2, T3, T4, T5, T6, T7> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) => Try.Future(action);

        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> TryFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) => Try.Future(action);

        #endregion

        #region Factory extensions - TryFuncInvoke

        public static Try<TResult> TryFuncInvoke<TResult>(this Func<TResult> func, string cause = null) => Try.Create(func, cause);

        public static Try<TResult> TryFuncInvoke<T, TResult>(this Func<T, TResult> func, T arg, string cause = null) => Try.Create(func, arg, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 arg1, T2 arg2, string cause = null)
            => Try.Create(func, arg1, arg2, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 arg1, T2 arg2, T3 arg3, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, cause);

        public static Try<TResult> TryFuncInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, string cause = null)
            => Try.Create(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16, cause);

        #endregion

        #region Factory extensions - TryFuncFutureInvoke

        public static FutureCreatingBuilder<TResult> TryFuncFutureInvoke<TResult>(this Func<TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T, TResult> TryFuncFutureInvoke<T, TResult>(this Func<T, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, TResult> TryFuncFutureInvoke<T1, T2, TResult>(
            this Func<T1, T2, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, TResult> TryFuncFutureInvoke<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, TResult>(
            this Func<T1, T2, T3, T4, T5, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func) => Try.CreateFuture(func);

        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> TryFuncFutureInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func) => Try.CreateFuture(func);

        #endregion
    }
}