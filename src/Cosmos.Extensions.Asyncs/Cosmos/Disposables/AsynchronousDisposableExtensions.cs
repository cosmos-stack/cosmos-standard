#if !NET452
namespace Cosmos.Disposables;

public static class AsynchronousDisposableExtensions
{
    public static IAsyncDisposable ToAsyncDisposable(this IDisposable @this) => new AsyncDisposableWrapper(@this);

    private sealed class AsyncDisposableWrapper : IAsyncDisposable
    {
        private readonly IDisposable _disposable;

        public AsyncDisposableWrapper(IDisposable disposable) => _disposable = disposable;

#pragma warning disable CS1998
        public async ValueTask DisposeAsync() => _disposable.Dispose();
#pragma warning restore CS1998
    }
}
#endif