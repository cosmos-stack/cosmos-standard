using System;

namespace CosmosStack.Asynchronous
{
    /// <summary>
    /// Interface for cancellable.<br />
    /// 可取消接口
    /// </summary>
    public interface ICancellable : IDisposable
    {
        /// <summary>
        /// Returns true if cancelled. <br />
        /// Returns false if already run or already cancelled or unable to cancel. <br />
        /// 当取消时返回 true，当已在运行、已取消或无法取消时返回 false。
        /// </summary>
        /// <returns></returns>
        bool Cancel();
    }
}