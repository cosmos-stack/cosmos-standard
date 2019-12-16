using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Asynchronous {
    /// <summary>
    /// Task utilities
    /// </summary>
    public static class Tasks {

        #region CompletedTask

#if NET451
        // ReSharper disable once InconsistentNaming
        private static readonly Task _completedTask = Task.FromResult(true);
#endif
        /// <summary>
        /// Gets a task that has been completed successfully.
        /// </summary>
        /// <returns></returns>
        public static Task CompletedTask() {
#if NET451
            return _completedTask;
#else
            return Task.CompletedTask;
#endif
        }

        #endregion

        #region From Canceled

        /// <summary>
        /// From canceled
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromCanceled<TResult>(CancellationToken cancellationToken) {
#if NET451
            var tcs = new TaskCompletionSource<TResult>();
            tcs.SetCanceled();
            return tcs.Task;
#else
            return Task.FromCanceled<TResult>(cancellationToken);
#endif
        }

        /// <summary>
        /// From canceled
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromCanceled<TResult>(OperationCanceledException exception) {
#if NET451
            var tcs = new TaskCompletionSource<TResult>();
            tcs.SetException(exception);
            tcs.SetCanceled();
            return tcs.Task;
#else
            return Task.FromCanceled<TResult>(exception.CancellationToken);
#endif
        }

        #endregion

        #region From Exception

        /// <summary>
        /// From exception
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromException<TResult>(Exception exception) {
#if NET451
            var tcs = new TaskCompletionSource<TResult>();
            tcs.TrySetException(exception);
            return tcs.Task;
#else
            return Task.FromException<TResult>(exception);
#endif
        }

        #endregion

    }
}