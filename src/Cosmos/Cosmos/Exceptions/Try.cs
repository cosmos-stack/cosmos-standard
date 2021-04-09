using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Try
    /// </summary>
    public static class Try
    {
        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T>(Func<T> createFunction)
        {
            try
            {
                return LiftValue(createFunction());
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/>.
        /// </summary>
        /// <param name="createFunction"></param>
        /// <param name="arg"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> Create<T, TResult>(Func<T, TResult> createFunction, T arg)
        {
            try
            {
                return LiftValue(createFunction(arg));
            }
            catch (Exception ex)
            {
                return LiftException<TResult>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/>.
        /// </summary>
        /// <param name="createFunction"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T>(Func<T1, T2, T> createFunction, T1 arg1, T2 arg2)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
        /// </summary>
        /// <param name="createFunction"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T1, T2, T3, T>(Func<T1, T2, T3, T> createFunction, T1 arg1, T2 arg2, T3 arg3)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static Try<T> Create<T1, T2, T3, T4, T>(Func<T1, T2, T3, T4, T> createFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static Try<T> Create<T1, T2, T3, T4, T5, T>(Func<T1, T2, T3, T4, T5, T> createFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T>(Func<T1, T2, T3, T4, T5, T6, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
        /// </summary>
        /// <param name="createFunction"></param>
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
        public static Try<T> Create<T1, T2, T3, T4, T5, T6, T7, T>(Func<T1, T2, T3, T4, T5, T6, T7, T> createFunction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
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
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            try
            {
                return LiftValue(createFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create for asynchronous functions.
        /// </summary>
        /// <param name="createFunctionAsync"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> CreateFromTask<T>(Func<Task<T>> createFunctionAsync)
        {
            try
            {
                return LiftValue(CallAsyncInSync(createFunctionAsync));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Lifts a value.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> LiftValue<T>(T value) => new Success<T>(value);

        /// <summary>
        /// Lifts
        /// </summary>
        /// <param name="ex"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> LiftException<T>(Exception ex) => new Failure<T>(ex);

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

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <returns></returns>
        public static TryAction Invoke(Action invokeAction)
        {
            try
            {
                invokeAction();
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TryAction Invoke<T>(Action<T> invokeAction, T obj)
        {
            try
            {
                invokeAction(obj);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public static TryAction Invoke<T1, T2>(Action<T1, T2> invokeAction, T1 arg1, T2 arg2)
        {
            try
            {
                invokeAction(arg1, arg2);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3>(Action<T1, T2, T3> invokeAction, T1 arg1, T2 arg2, T3 arg3)
        {
            try
            {
                invokeAction(arg1, arg2, arg3);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4>(Action<T1, T2, T3, T4> invokeAction, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> invokeAction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4, arg5);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> invokeAction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4, arg5, arg6);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
        /// </summary>
        /// <param name="invokeAction"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> invokeAction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
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
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> invokeAction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
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
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> invokeAction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
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
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> invokeAction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
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
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> invokeAction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
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
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> invokeAction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
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
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> invokeAction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
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
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> invokeAction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
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
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> invokeAction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="TryAction"/>.
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
        /// <returns></returns>
        public static TryAction Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> invokeAction,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            try
            {
                invokeAction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
                return new SuccessAction(invokeAction.GetHashCode());
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, invokeAction?.GetHashCode() ?? 0);
            }
        }
    }
}