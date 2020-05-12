using System;

namespace Cosmos.Disposables {
    /// <summary>
    /// Disable Action. <br />
    /// When the derived class of this class is disposed, the specified <see cref="Action"/> will be executed.
    /// </summary>
    public sealed class DisposableAction : IDisposableAction, IDisposable {
        private readonly Action _action;

        /// <summary>
        /// Create a new <see cref="DisposableAction"/> instance.
        /// </summary>
        /// <param name="action"></param>
        public DisposableAction(Action action) {
            _action = action;
        }

        /// <inheritdoc />
        public void Invoke() => _action?.Invoke();

        /// <inheritdoc />
        public void Dispose() {
            Invoke();
        }

        internal Action InternalAction => _action;

        /// <summary>
        /// Get a cached instance of <see cref="NoopDisposableAction"/>.
        /// </summary>
        public static IDisposable Noop => NoopDisposableAction.Instance;
    }
}