namespace Cosmos.Disposables
{
    /// <summary>
    /// Interface for disposal state
    /// </summary>
    public interface IDisposalState
    {
        /// <summary>
        /// Was disposed
        /// </summary>
        bool WasDisposed { get; }
    }
}