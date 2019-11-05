using System;
using System.Threading.Tasks;

namespace Cosmos.Disposables
{
    /// <summary>
    /// Asynchronous Generic Disable Action. <br />
    /// When the derived class of this class is disposed, the specified <see cref="Action{T}"/> will be executed async.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class AsynchronousDisposableAction<T> : IAsynchronousDisposableAction, IDisposable
    {
        private readonly Action<T> _action;
        private readonly T _context;

        /// <summary>
        /// Create a new <see cref="AsynchronousDisposableAction{T}"/> instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public AsynchronousDisposableAction(Action<T> action, T context)
        {
            _action = action;
            _context = context;
        }
        
        /// <summary>
        /// Create a new <see cref="AsynchronousDisposableAction{T}"/> instance.
        /// </summary>
        /// <param name="originalDisposableAction"></param>
        /// <param name="contextUpdater"></param>
        public AsynchronousDisposableAction(AsynchronousDisposableAction<T> originalDisposableAction, Func<T, T> contextUpdater)
        {
            _action = originalDisposableAction._action;
            _context = contextUpdater(originalDisposableAction._context);
        }

        /// <summary>
        /// Invoke the disposable action async with context
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task InvokeAsync()
        {
            return Task.Run(() => _action?.Invoke(_context));
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Task.Run(async () => await InvokeAsync());
        }
    }
}