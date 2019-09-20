using RSG;

namespace Cosmos.Asynchronous.Promise
{
    /// <summary>
    /// Promises Utilities
    /// </summary>
    public static class Promises
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IPromise<T> Create<T>() => new Promise<T>();
    }
}
