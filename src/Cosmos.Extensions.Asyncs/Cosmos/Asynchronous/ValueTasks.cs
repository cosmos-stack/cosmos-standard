using System.Threading.Tasks;

namespace Cosmos.Asynchronous {
    /// <summary>
    /// ValueTask utilities
    /// </summary>
    public static class ValueTasks {
        /// <summary>
        /// Create a new ValueTask instance from given result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ValueTask<T> Create<T>(T result) => ValueTaskFactory.FromResult(result);
    }
}