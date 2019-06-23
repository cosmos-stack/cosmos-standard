using System;

namespace Cosmos.Disposables
{
    /// <summary>
    /// Disable Action. <br />
    /// When the derived class of this class is disposed, the specified <see cref="Action"/> will be executed.
    /// </summary>
    public sealed class DisposableAction : IDisposableAction, IDisposable
    {
        private readonly Action _action;

        /// <summary>
        /// Create a new <see cref="DisposableAction"/> instance.
        /// </summary>
        /// <param name="action"></param>
        public DisposableAction(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// Invoke the disposable action
        /// </summary>
        public void Invoke() => _action?.Invoke();

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Invoke();
        }

        internal Action InternalAction => _action;
    }
}