using System;

namespace Cosmos.Disposables {
    /// <summary>
    /// An asynchronous disposable implement which does nothing when disposed.
    /// </summary>
    public class AsynchronousNoopDisposableObject : IDisposable {
        /// <summary>
        /// Gets a <see cref="AsynchronousNoopDisposableObject"/> cache.
        /// </summary>
        public static AsynchronousNoopDisposableObject Instance { get; } = new AsynchronousNoopDisposableObject();

        private AsynchronousNoopDisposableObject() { }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose() { }
    }
}