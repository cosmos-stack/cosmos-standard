using System;
using System.Threading;
using System.Threading.Tasks;
using Nito.AsyncEx.Synchronous;

namespace Cosmos.Asynchronous
{
    public static class SyncRunner
    {
        public static void ForAsynchronousCalling(Task task, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            task.WaitAndUnwrapException(cancellationToken);
        }

        public static void ForAsynchronousCallingSafety(Task task, CancellationToken cancellationToken = default(CancellationToken))
        {
            task?.WaitWithoutException(cancellationToken);
        }

        public static TResult FromAsynchronousCalling<TResult>(Task<TResult> task, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            return task.WaitAndUnwrapException(cancellationToken);
        }

        public static TResult FromAsynchronousCallingSafety<TResult>(Task<TResult> task, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromAsynchronousCallingSafety(task, default(TResult), cancellationToken);
        }

        public static TResult FromAsynchronousCallingSafety<TResult>(Task<TResult> task, TResult defaultValue, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (task == null)
                return defaultValue;

            try
            {
                return FromAsynchronousCalling(task, cancellationToken);
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
