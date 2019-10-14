namespace Cosmos.Disposables
{
    /// <summary>
    /// Disposable action
    /// </summary>
    public interface IDisposableAction
    {
        /// <summary>
        /// Invoke the disposable action
        /// </summary>
        void Invoke();
    }
}