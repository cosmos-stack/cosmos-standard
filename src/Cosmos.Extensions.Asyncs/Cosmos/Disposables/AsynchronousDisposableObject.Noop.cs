using System;
using System.Threading.Tasks;
using Cosmos.Asynchronous;

namespace Cosmos.Disposables
{
    /// <summary>
    /// An asynchronous disposable implement which does nothing when disposed.
    /// </summary>
    public class AsynchronousNoopDisposableObject : IDisposable
#if NETSTANDARD2_1
                                                  , System.IAsyncDisposable
#endif
    {
        /// <summary>
        /// Gets a <see cref="AsynchronousNoopDisposableObject"/> cache.
        /// </summary>
        public static AsynchronousNoopDisposableObject Instance { get; } = new AsynchronousNoopDisposableObject();

        private AsynchronousNoopDisposableObject() { }

        /// <inheritdoc />
        public void Dispose() { }

        /// <inheritdoc />
        public ValueTask DisposeAsync() => new ValueTask(Tasks.CompletedTask());
    }
}