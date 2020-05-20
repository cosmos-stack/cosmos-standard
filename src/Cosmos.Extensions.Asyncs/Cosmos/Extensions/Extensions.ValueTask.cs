#if !NET451
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Asynchronous {
    /// <summary>
    /// ValueTask extensions
    /// </summary>
    public static partial class TaskExtensions {
        /// <summary>
        /// Run in AsyncContext
        /// </summary>
        /// <param name="task"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T RunInContext<T>(this in ValueTask<T> task) => task.AsTask().RunInContext();
    }
}

#endif