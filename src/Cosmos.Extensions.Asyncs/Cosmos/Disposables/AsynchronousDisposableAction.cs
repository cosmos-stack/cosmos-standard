using System;
using System.Threading.Tasks;

namespace Cosmos.Disposables {
    /// <summary>
    /// Asynchronous Disable Action. <br />
    /// When the derived class of this class is disposed, the specified <see cref="Action"/> will be executed async.
    /// </summary>
    public sealed class AsynchronousDisposableAction : IAsynchronousDisposableAction, IDisposable {
        private readonly Action _action;

        /// <summary>
        /// Create a new <see cref="AsynchronousDisposableAction"/> instance.
        /// </summary>
        /// <param name="action"></param>
        public AsynchronousDisposableAction(Action action) {
            _action = action;
        }

        /// <inheritdoc />
        public Task InvokeAsync() {
            return Task.Run(() => _action?.Invoke());
        }

        /// <inheritdoc />
        public void Dispose() {
            Task.Run(async () => await InvokeAsync());
        }

        internal Action InternalAction => _action;
    }
}