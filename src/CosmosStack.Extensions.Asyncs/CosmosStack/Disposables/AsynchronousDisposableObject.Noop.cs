using System;
using System.Threading.Tasks;
using CosmosStack.Asynchronous;

namespace CosmosStack.Disposables
{
    /// <summary>
    /// An asynchronous disposable implement which does nothing when disposed. <br />
    /// 一个异步的一次性工具，在处理时什么也不做。
    /// </summary>
    public class AsynchronousNoopDisposableObject : IDisposable
#if NETSTANDARD2_1 || NETCOREAPP3_0 || NETCOREAPP3_1
                                              , IAsyncDisposable
#endif
    {
        /// <summary>
        /// Gets a <see cref="AsynchronousNoopDisposableObject"/> cache.
        /// </summary>
        public static AsynchronousNoopDisposableObject Instance { get; } = new AsynchronousNoopDisposableObject();

        private AsynchronousNoopDisposableObject() { }

        /// <inheritdoc />
        public void Dispose() { }

        /// <summary>
        /// Dispose async
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync() => new ValueTask(Tasks.CompletedTask());
    }
}