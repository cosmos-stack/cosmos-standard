using System.Threading;

namespace Cosmos.Asynchronous
{
    public interface ICancellationTokenProvider
    {
        CancellationToken GetCancellationToken();
    }

    public sealed class NullCancellationTokenProvider : ICancellationTokenProvider
    {
        public CancellationToken GetCancellationToken() => default;
    }
}