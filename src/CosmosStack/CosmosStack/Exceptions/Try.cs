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

        #region Future Create

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder<T> CreateFuture<T>(Func<T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder<T, TResult> CreateFuture<T, TResult>(Func<T, TResult> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder<T1, T2, T> CreateFuture<T1, T2, T>(Func<T1, T2, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder<T1, T2, T3, T> CreateFuture<T1, T2, T3, T>(Func<T1, T2, T3, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder<T1, T2, T3, T4, T> CreateFuture<T1, T2, T3, T4, T>(Func<T1, T2, T3, T4, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T> CreateFuture<T1, T2, T3, T4, T5, T>(Func<T1, T2, T3, T4, T5, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T> CreateFuture<T1, T2, T3, T4, T5, T6, T>(Func<T1, T2, T3, T4, T5, T6, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T>(Func<T1, T2, T3, T4, T5, T6, T7, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T> createFunction) =>
            new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T> createFunction) => new(createFunction);

        #endregion

        #region Create from Task
        
        /// <summary>
        /// Create for asynchronous functions. <br />
        /// 为异步的 Function 创建一个 <see cref="Try{T}"/> 实例。
        /// </summary>
        /// <param name="createFunctionAsync"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> CreateFromTask<T>(Func<Task<T>> createFunctionAsync, string cause = null)
        {
            try
            {
                return LiftValue(CallAsyncInSync(createFunctionAsync));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex, cause);
            }
        }

        private static TResult CallAsyncInSync<TResult>(Func<Task<TResult>> taskFunc, CancellationToken cancellationToken = default)
        {
            if (taskFunc is null)
                throw new ArgumentNullException(nameof(taskFunc));

            var task = Create(taskFunc).GetValue();

            if (task is null)
                throw new InvalidOperationException($"The task factory {nameof(taskFunc)} failed to run.");

            return ThenWaitAndUnwrapException(task, cancellationToken);
        }

        private static TResult ThenWaitAndUnwrapException<TResult>(Task<TResult> task, CancellationToken cancellationToken)
        {
            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            try
            {
                task.Wait(cancellationToken);
                return task.Result;
            }
            catch (AggregateException ex)
            {
                throw ExceptionHelper.PrepareForRethrow(ex.InnerException);
            }
        }

        #endregion

        #region Lift

        /// <summary>
        /// Lifts a value. <br />
        /// 直接使用一个值生成 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> LiftValue<T>(T value) => new Success<T>(value);

        /// <summary>
        /// Lifts <br />
        /// 直接使用一个异常生成 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="cause"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> LiftException<T>(Exception ex, string cause = null) => new Failure<T>(ex, cause);

        #endregion
        
        #region Invoke

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>. <br />
        /// 调用委托，返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <param name="cause"></param>
        /// <returns></returns>
        public static TryAction Invoke(Action invokeAction, string cause = null)
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
        public static TryAction Invoke<T>(Action<T> invokeAction, T obj, string cause = null)
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
        public static TryAction Invoke<T1, T2>(Action<T1, T2> invokeAction, T1 arg1, T2 arg2, string cause = null)
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
        public static TryAction Invoke<T1, T2, T3>(Action<T1, T2, T3> invokeAction, T1 arg1, T2 arg2, T3 arg3, string cause = null)
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
        public static TryAction Invoke<T1, T2, T3, T4>(Action<T1, T2, T3, T4> invokeAction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, string cause = null)
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, string cause = null)
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, string cause = null)
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, string cause = null)
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, string cause = null)
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, string cause = null)
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, string cause = null)
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, string cause = null)
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, string cause = null)
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, string cause = null)
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, string cause = null)
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, string cause = null)
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, string cause = null)
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

        #region Future Invoke

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/> in the future. <br />
        /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <returns></returns>
        public static FutureInvokingBuilder Future(Action invokeAction) => new(invokeAction);

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/> in the future. <br />
        /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FutureInvokingBuilder<T> Future<T>(Action<T> invokeAction) => new(invokeAction);

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/> in the future. <br />
        /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static FutureInvokingBuilder<T1, T2> Future<T1, T2>(
            Action<T1, T2> invokeAction) => new(invokeAction);

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/> in the future. <br />
        /// 调用委托，预备返回一个 <see cref="TryAction"/> 实例。
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static FutureInvokingBuilder<T1, T2, T3> Future<T1, T2, T3>(
            Action<T1, T2, T3> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4> Future<T1, T2, T3, T4>(
            Action<T1, T2, T3, T4> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4, T5> Future<T1, T2, T3, T4, T5>(
            Action<T1, T2, T3, T4, T5> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6> Future<T1, T2, T3, T4, T5, T6>(
            Action<T1, T2, T3, T4, T5, T6> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7> Future<T1, T2, T3, T4, T5, T6, T7>(
            Action<T1, T2, T3, T4, T5, T6, T7> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8> Future<T1, T2, T3, T4, T5, T6, T7, T8>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> invokeAction) => new(invokeAction);

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
        public static FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Future<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> invokeAction) => new(invokeAction);

        #endregion
    }
}