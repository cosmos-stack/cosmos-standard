using System;
using Cosmos.Abstractions.Disposables;

namespace Cosmos.Disposables
{
    public sealed class DisposableAction : IDisposableAction, IDisposable
    {
        private readonly Action _action;

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