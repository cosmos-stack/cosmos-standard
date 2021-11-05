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
        #region Future Create from Task

        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{T}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder2<T> CreateFuture<T>(Func<Task<T>> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder2<T, TResult> CreateFuture<T, TResult>(Func<T, Task<TResult>> createFunction) => new(createFunction);

        /// <summary>
        /// Create a new instance of <see cref="Try{TResult}"/> in the future. <br />
        /// 预备创建一个新的 <see cref="Try{TResult}"/> 实例
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FutureCreatingBuilder2<T1, T2, T> CreateFuture<T1, T2, T>(Func<T1, T2, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T> CreateFuture<T1, T2, T3, T>(Func<T1, T2, T3, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T> CreateFuture<T1, T2, T3, T4, T>(Func<T1, T2, T3, T4, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T> CreateFuture<T1, T2, T3, T4, T5, T>(Func<T1, T2, T3, T4, T5, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T> CreateFuture<T1, T2, T3, T4, T5, T6, T>(Func<T1, T2, T3, T4, T5, T6, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T>(Func<T1, T2, T3, T4, T5, T6, T7, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<T>> createFunction) =>
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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task<T>> createFunction) => new(createFunction);

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
        public static FutureCreatingBuilder2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T> CreateFuture<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Task<T>> createFunction) => new(createFunction);

        #endregion
    }
}