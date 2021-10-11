using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CosmosStack.Asynchronous
{
    /// <summary>
    /// ValueTask factory <br />
    /// ValueTask 工厂方法
    /// </summary>
    public static class ValueTaskFactory
    {
        /// <summary>
        /// From result <br />
        /// 从给定的结果创建一个 ValueTask 包装
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<T> FromResult<T>(T result) => new(result);

        /// <summary>
        /// From exception  <br />
        /// 从给定的异常创建一个 ValueTask 包装
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<T> FromException<T>(Exception exception) => new(Tasks.FromException<T>(exception));
    }
}