using System.Threading.Tasks;

namespace Cosmos.Disposables {
    /// <summary>
    /// Asynchronous Disposable action<br />
    /// 异步释放 Action 接口
    /// </summary>
    public interface IAsynchronousDisposableAction {
        /// <summary>
        /// Invoke the disposable action async<br />
        /// 执行异步释放工作
        /// </summary>
        Task InvokeAsync();
    }
}