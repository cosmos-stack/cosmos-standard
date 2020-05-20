using System;
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

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IPromise<T> Create<T>(Action<Action<T>, Action<Exception>> resolver) => new Promise<T>(resolver);

        /// <summary>
        /// Resolved
        /// </summary>
        /// <param name="promisedVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IPromise<T> Resolved<T>(T promisedVal) => Promise<T>.Resolved(promisedVal);

        /// <summary>
        /// Rejected
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IPromise<T> Rejected<T>(Exception exception) => Promise<T>.Rejected(exception);
    }
}