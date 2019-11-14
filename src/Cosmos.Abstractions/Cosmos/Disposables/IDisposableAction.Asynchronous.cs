using System.Threading.Tasks;

namespace Cosmos.Disposables
{
    /// <summary>
    /// Asynchronous Disposable action
    /// </summary>
    public interface IAsynchronousDisposableAction
    {
        /// <summary>
        /// Invoke the disposable action async
        /// </summary>
        Task InvokeAsync();
    }
}