using System;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosStack.Disposables
{
    /// <summary>
    /// Asynchronous Single Disposable Object <br />
    /// 异步单一可释放对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AsynchronousSingleDisposableObject<T> : AsynchronousDisposableBase
    {
        private readonly AsynchronousDisposableActionField<T> _context;

        private readonly ManualResetEventSlim _slim = new();

        /// <summary>
        /// Create a asynchronous single disposable object for such context
        /// </summary>
        /// <param name="context"></param>
        protected AsynchronousSingleDisposableObject(T context)
        {
            _context = new AsynchronousDisposableActionField<T>(DisposeAsync, context);
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
        protected abstract ValueTask DisposeAsync(T context);

        /// <summary>
        /// On Dispose async
        /// </summary>
        protected override async ValueTask OnDisposeAsync()
        {
            var context = _context.TryGetAndUnset();
            if (context == null)
            {
                _slim.Wait();
                return;
            }

            try
            {
                await context.InvokeAsync();
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