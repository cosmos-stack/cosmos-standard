using System;
using System.Threading;
using System.Threading.Tasks;

#if !NET451
using Nito.AsyncEx.Synchronous;
#endif

namespace Cosmos.Asynchronous {
    /// <summary>
    /// Sync runner
    /// </summary>
    public static class SyncRunner {
        /// <summary>
        /// For asynchronous calling
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        public static void ForAsynchronousCalling(Task task, CancellationToken cancellationToken = default) {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            task.WaitAndUnwrapException(cancellationToken);
        }

        /// <summary>
        /// For asynchronous calling safety
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        public static void ForAsynchronousCallingSafety(Task task, CancellationToken cancellationToken = default) {
            task?.WaitWithoutException(cancellationToken);
        }

        /// <summary>
        /// From asynchronous calling
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static TResult FromAsynchronousCalling<TResult>(Task<TResult> task, CancellationToken cancellationToken = default) {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            return task.WaitAndUnwrapException(cancellationToken);
        }

        /// <summary>
        /// From asynchronous calling safety
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static TResult FromAsynchronousCallingSafety<TResult>(Task<TResult> task, CancellationToken cancellationToken = default) {
            return FromAsynchronousCallingSafety(task, default(TResult), cancellationToken);
        }

        /// <summary>
        /// From asynchronous calling safety
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="task"></param>
        /// <param name="defaultValue"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static TResult FromAsynchronousCallingSafety<TResult>(Task<TResult> task, TResult defaultValue, CancellationToken cancellationToken = default) {
            if (task == null)
                return defaultValue;

            try {
                return FromAsynchronousCalling(task, cancellationToken);
            } catch {
                return defaultValue;
            }
        }
    }
}