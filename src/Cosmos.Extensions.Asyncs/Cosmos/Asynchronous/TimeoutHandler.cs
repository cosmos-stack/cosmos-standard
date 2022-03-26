namespace Cosmos.Asynchronous;

/// <summary>
/// Timeout handler <br />
/// 超时处理
/// </summary>
public class TimeoutHandler : IDisposable
{
    // ReSharper disable once InconsistentNaming
    readonly CancellationTokenSource TokenSource;

    TimeoutHandler(int delay, Action<int> onComplete)
    {
        TokenSource = new CancellationTokenSource();
        Task.Delay(delay, TokenSource.Token).ContinueWith(t =>
        {
            if (!t.IsCanceled) onComplete(delay);
        });
    }

    /// <summary>
    /// New <br />
    /// 创建一个超时处理器
    /// </summary>
    /// <param name="delay"></param>
    /// <param name="onComplete"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TimeoutHandler New(int delay, Action<int> onComplete)
    {
        return new TimeoutHandler(delay, onComplete);
    }

    /// <summary>
    /// New <br />
    /// 创建一个超时处理器
    /// </summary>
    /// <param name="delay"></param>
    /// <param name="timeout"></param>
    /// <param name="onComplete"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool New(int delay, out IDisposable timeout, Action<int> onComplete)
    {
        timeout = New(delay, onComplete);
        return true;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        TokenSource.Cancel();
    }
}