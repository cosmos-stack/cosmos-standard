using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Disposables {
    /// <summary>
    /// Asynchronous Single Disposable Object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AsynchronousSingleDisposableObject<T> : IDisposable {
        private readonly AsynchronousDisposableActionField<T> _context;

        private readonly ManualResetEventSlim _slim = new ManualResetEventSlim();

        /// <summary>
        /// Create a asynchronous single disposable object for such context
        /// </summary>
        /// <param name="context"></param>
        protected AsynchronousSingleDisposableObject(T context) {
            _context = new AsynchronousDisposableActionField<T>(Dispose, context);
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
        /// The actual disposal method, call only once from Dispose.
        /// </summary>
        /// <param name="context"></param>
        protected abstract void Dispose(T context);

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose() {
            var context = _context.TryGetAndUnset();
            if (context == null) {
                _slim.Wait();
                return;
            }

            try {
                Task.Run(async () => await context.InvokeAsync());
            }
            finally {
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