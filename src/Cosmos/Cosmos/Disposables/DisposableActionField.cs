using System;
using System.Threading;

/*
 * Reference to:
 *    Nito.Disposables
 *      Author: Stephen Cleary
 *      URL: https://github.com/StephenCleary/Disposables
 *      MIT
 */

namespace Cosmos.Disposables
{
    public sealed class DisposableActionField<T>
    {
        private DisposableAction<T> _field;

        public DisposableActionField(Action<T> action, T context)
        {
            _field = new DisposableAction<T>(action, context);
        }

        /// <summary>
        /// To flag this field is empty or not.
        /// </summary>
        public bool IsEmpty => Interlocked.CompareExchange(ref _field, null, null) == null;

        /// <summary>
        /// Atomically retrieves this disposable action from the field, and sets such field to <c>null</c>. May return <c>null</c>.
        /// </summary>
        /// <returns></returns>
        public IDisposableAction TryGetAndUnset() => Interlocked.Exchange(ref _field, null);

        /// <summary>
        /// Attempts to update context of disposable action stored in this field, Return <c>false</c> if the field is <c>null</c>. 
        /// </summary>
        /// <param name="contextUpdater"></param>
        /// <returns></returns>
        public bool TryUpdateContext(Func<T, T> contextUpdater)
        {
            while (true)
            {
                var origin = Interlocked.CompareExchange(ref _field, _field, _field);
                if (origin == null) return false;
                var updatedContext = new DisposableAction<T>(origin, contextUpdater);
                var ret = Interlocked.CompareExchange(ref _field, updatedContext, origin);
                if (ReferenceEquals(origin, ret)) return true;
            }
        }
    }
}
