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
    /// <summary>
    /// Single Disposable Object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SingleDisposableObject<T> : IDisposable
    {
        private readonly DisposableActionField<T> _context;

        private readonly ManualResetEventSlim _slim = new ManualResetEventSlim();

        /// <summary>
        /// Create a single disposable object for such context
        /// </summary>
        /// <param name="context"></param>
        protected SingleDisposableObject(T context)
        {
            _context = new DisposableActionField<T>(Dispose, context);
        }

        /// <summary>
        /// To flag this instance is currently disposing or has been disposed.
        /// </summary>
        public bool IsDisposeStarted => _context.IsEmpty;

        /// <summary>
        /// To flag this instance is disposed, which means finished disposing.
        /// </summary>
        public bool IsDisposed => _slim.IsSet;

        /// <summary>
        /// To flag this instance is currently disposing, but not finished yet.
        /// </summary>
        public bool IsDisposing => IsDisposeStarted && !IsDisposed;

        /// <summary>
        /// The actual disposal method, call only once from <seealso cref="Dispose"/>.
        /// </summary>
        /// <param name="context"></param>
        protected abstract void Dispose(T context);

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            var context = _context.TryGetAndUnset();
            if (context == null)
            {
                _slim.Wait();
                return;
            }

            try
            {
                context.Invoke();
            }
            finally
            {
                _slim.Set();
            }
        }

        /// <summary>
        /// Attempts to update the stored context. This method returns false if this instance has already been disposed or is being disposed.
        /// </summary>
        /// <param name="contextUpdater"></param>
        /// <returns></returns>
        protected bool TryUpdateContext(Func<T, T> contextUpdater) => _context.TryUpdateContext(contextUpdater);
    }
}
