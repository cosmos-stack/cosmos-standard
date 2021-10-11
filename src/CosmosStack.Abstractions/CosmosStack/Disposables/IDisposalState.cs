namespace CosmosStack.Disposables
{
    /// <summary>
    /// Interface for disposal state <br />
    /// 可释放状态接口
    /// </summary>
    public interface IDisposalState
    {
        /// <summary>
        /// Was disposed <br />
        /// 标识是否已释放。
        /// </summary>
        bool WasDisposed { get; }
    }
}