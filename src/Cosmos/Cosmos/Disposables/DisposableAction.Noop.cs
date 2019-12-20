using System;

namespace Cosmos.Disposables {
    /// <summary>
    /// A disposable action implement which does nothing when disposed.
    /// </summary>
    public class NoopDisposableAction : IDisposableAction, IDisposable {
        /// <summary>
        /// Gets a <see cref="NoopDisposableAction"/> cache.
        /// </summary>
        public static NoopDisposableAction Instance { get; } = new NoopDisposableAction();

        private NoopDisposableAction() { }

        /// <inheritdoc />
        public void Invoke() { }

        /// <inheritdoc />
        public void Dispose() { }
    }
}