#if !NET452
using System;
using System.Threading.Tasks;

namespace CosmosStack.Disposables
{
    public static class AsynchronousDisposableExtensions
    {
        public static IAsyncDisposable ToAsyncDisposable(this IDisposable @this) => new AsyncDisposableWrapper(@this);

        private sealed class AsyncDisposableWrapper : IAsyncDisposable
        {
            private readonly IDisposable _disposable;

            public AsyncDisposableWrapper(IDisposable disposable) => _disposable = disposable;

            public async ValueTask DisposeAsync() => _disposable.Dispose();
        }
    }
}
#endif