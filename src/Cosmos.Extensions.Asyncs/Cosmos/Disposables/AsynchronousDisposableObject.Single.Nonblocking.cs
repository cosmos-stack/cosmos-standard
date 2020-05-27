using System;
using System.Threading.Tasks;

namespace Cosmos.Disposables
{
    /// <summary>
    /// Asynchronous Single Nonblocking Disposable Object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AsynchronousSingleNonblockingDisposableObject<T> : IDisposable
    {
        private readonly AsynchronousDisposableActionField<T> _context;

        /// <summary>
        /// Create a single nonblocking disposable object for such context
        /// </summary>
        /// <param name="context"></param>
        protected AsynchronousSingleNonblockingDisposableObject(T context)
        {
            _context = new AsynchronousDisposableActionField<T>(Dispose, context);
        }

        /// <summary>
        /// To flag this instance is currently disposing or has been disposed.
        /// </summary>
        public bool IsDisposeStarted => _context.IsEmpty;

        /// <summary>
        /// The actual disposal method, call only once from Dispose
        /// </summary>
        /// <param name="context"></param>
        protected abstract void Dispose(T context);

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            var action = _context.TryGetAndUnset();

            if (action != null)
            {
                Task.Run(async () => await action.InvokeAsync());
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