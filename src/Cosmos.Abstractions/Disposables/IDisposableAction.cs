namespace Cosmos.Abstractions.Disposables
{
    public interface IDisposableAction
    {
        /// <summary>
        /// Invoke the disposable action
        /// </summary>
        void Invoke();
    }
}
