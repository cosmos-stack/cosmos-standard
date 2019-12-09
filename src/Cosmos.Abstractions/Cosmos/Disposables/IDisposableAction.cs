namespace Cosmos.Disposables {
    /// <summary>
    /// Disposable action<br />
    /// 同步释放 Action 接口
    /// </summary>
    public interface IDisposableAction {
        /// <summary>
        /// Invoke the disposable action<br />
        /// 执行同步释放工作
        /// </summary>
        void Invoke();
    }
}