#if !NET451
using System;
using System.Threading.Tasks;
using Nito.AsyncEx;

// ReSharper disable once CheckNamespace
namespace Cosmos.Asynchronous
{
    /// <summary>
    /// Task extensions
    /// </summary>
    public static partial class TaskExtensions
    {
        /// <summary>
        /// Run in AsyncContext
        /// </summary>
        /// <param name="task"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RunInContext(this Task task)
        {
            if (task is null)
                throw new ArgumentNullException(nameof(task));
            AsyncContext.Run(() => task);
        }

        /// <summary>
        /// Run in AsyncContext
        /// </summary>
        /// <param name="task"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T RunInContext<T>(this Task<T> task)
        {
            if (task is null)
                throw new ArgumentNullException(nameof(task));
            return AsyncContext.Run(() => task);
        }
    }
}

#endif