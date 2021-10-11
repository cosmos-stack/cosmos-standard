using System.Threading;

namespace CosmosStack.Asynchronous
{
    /// <summary>
    /// An interface for cancellation token provider  <br />
    /// 取消凭据提供者程序接口
    /// </summary>
    public interface ICancellationTokenProvider
    {
        CancellationToken GetCancellationToken();
    }

    /// <summary>
    /// Null Cancellation Token Provider <br />
    /// 空的凭据提供者程序
    /// </summary>
    public sealed class NullCancellationTokenProvider : ICancellationTokenProvider
    {
        public CancellationToken GetCancellationToken() => default;
    }
}