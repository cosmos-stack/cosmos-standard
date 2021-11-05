using System;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosStack.Exceptions
{
    /// <summary>
    /// Try <br />
    /// Try 组件
    /// </summary>
    public static partial class Try
    {
        #region Create

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T>(Func<T> createFunction, string cause = null)
        {
            try
            {
                return LiftValue(createFunction());
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <param name="arg"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> Create<T, TResult>(Func<T, TResult> createFunction, T arg, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg));
            }
            catch (Exception ex)
            {
                return LiftException<TResult>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/>. <br />
        /// 创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T>(Func<T1, T2, T> createFunction, T1 arg1, T2 arg2, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T>(Func<T1, T2, T3, T> createFunction, T1 arg1, T2 arg2, T3 arg3, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T>(Func<T1, T2, T3, T4, T> createFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T5, T>(Func<T1, T2, T3, T4, T5, T> createFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T>(Func<T1, T2, T3, T4, T5, T6, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T7, T>(Func<T1, T2, T3, T4, T5, T6, T7, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T7, T8, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>. <br />
        /// 创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, string cause = null)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        #endregion
    }
}