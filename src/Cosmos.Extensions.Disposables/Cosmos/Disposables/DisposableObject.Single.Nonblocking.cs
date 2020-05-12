using System;

/*
 * Reference to:
 *    Nito.Disposables
 *      Author: Stephen Cleary
 *      URL: https://github.com/StephenCleary/Disposables
 *      MIT
 */

namespace Cosmos.Disposables {
    /// <summary>
    /// Single Nonblocking Disposable Object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SingleNonblockingDisposableObject<T> : IDisposable {
        private readonly DisposableActionField<T> _context;

        /// <summary>
        /// Create a single nonblocking disposable object for such context
        /// </summary>
        /// <param name="context"></param>
        protected SingleNonblockingDisposableObject(T context) {
            _context = new DisposableActionField<T>(Dispose, context);
        }

        /// <summary>
        /// To flag this instance is currently disposing or has been disposed.
        /// </summary>
        public bool IsDisposeStarted => _context.IsEmpty;

        /// <summary>
        /// The actual disposal method, call only once from <see cref="Dispose"/>
        /// </summary>
        /// <param name="context"></param>
        protected abstract void Dispose(T context);

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose() => _context.TryGetAndUnset()?.Invoke();


        /// <summary>
        /// Attempts to update the stored context. This method returns false if this instance has already been disposed or is being disposed.
        /// </summary>
        /// <param name="contextUpdater"></param>
        /// <returns></returns>
        protected bool TryUpdateContext(Func<T, T> contextUpdater) => _context.TryUpdateContext(contextUpdater);
    }
}