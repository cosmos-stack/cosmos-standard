#if NET451

using System;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Exceptions;

// ReSharper disable once CheckNamespace
namespace Cosmos.Asynchronous {
    /// <summary>
    /// Extensions for task
    /// </summary>
    public static partial class TaskExtensions {
        /// <summary>
        /// Wait and unwrap exception
        /// </summary>
        /// <param name="task"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void WaitAndUnwrapException(this Task task) {
            if (task is null)
                throw new ArgumentNullException(nameof(task));
            task.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Wait and unwrap exception
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void WaitAndUnwrapException(this Task task, CancellationToken cancellationToken) {
            if (task is null)
                throw new ArgumentNullException(nameof(task));
            try {
                task.Wait(cancellationToken);
            } catch (AggregateException ex) {
                throw ExceptionHelper.PrepareForRethrow(ex.InnerException);
            }
        }

        /// <summary>
        /// Wait and unwrap exception
        /// </summary>
        /// <param name="task"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TResult WaitAndUnwrapException<TResult>(this Task<TResult> task) {
            if (task is null)
                throw new ArgumentNullException(nameof(task));
            return task.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Wait and unwrap exception
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static TResult WaitAndUnwrapException<TResult>(this Task<TResult> task, CancellationToken cancellationToken) {
            if (task is null)
                throw new ArgumentNullException(nameof(task));
            try {
                task.Wait(cancellationToken);
                return task.Result;
            } catch (AggregateException ex) {
                throw ExceptionHelper.PrepareForRethrow(ex.InnerException);
            }
        }

        /// <summary>
        /// Wait without exception
        /// </summary>
        /// <param name="task"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void WaitWithoutException(this Task task) {
            if (task is null)
                throw new ArgumentNullException(nameof(task));
            try {
                task.Wait();
            } catch (AggregateException) { }
        }

        /// <summary>
        /// Wait without exception
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void WaitWithoutException(this Task task, CancellationToken cancellationToken) {
            if (task is null)
                throw new ArgumentNullException(nameof(task));
            try {
                task.Wait(cancellationToken);
            } catch (AggregateException) {
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
}

#endif