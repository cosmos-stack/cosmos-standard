using System;
using Cosmos.Abstractions.Disposables;

namespace Cosmos.Disposables
{
    public sealed class DisposableAction<T> : IDisposableAction, IDisposable
    {
        private readonly Action<T> _action;
        private readonly T _context;

        public DisposableAction(Action<T> action, T context)
        {
            _action = action;
            _context = context;
        }

        public DisposableAction(DisposableAction<T> originalDisposableAction, Func<T, T> contextUpdater)
        {
            _action = originalDisposableAction._action;
            _context = contextUpdater(originalDisposableAction._context);
        }

        /// <summary>
        /// Invoke the disposable action with context
        /// </summary>
        public void Invoke() => _action?.Invoke(_context);

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Invoke();
        }
    }
}
