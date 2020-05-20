using System;
using System.Threading.Tasks;

namespace Cosmos.Asynchronous
{
    /// <summary>
    /// ValueTask factory
    /// </summary>
    public static class ValueTaskFactory
    {
        /// <summary>
        /// From result
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ValueTask<T> FromResult<T>(T result) => new ValueTask<T>(result);

        /// <summary>
        /// From exception
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ValueTask<T> FromException<T>(Exception exception) => new ValueTask<T>(Tasks.FromException<T>(exception));
    }
}