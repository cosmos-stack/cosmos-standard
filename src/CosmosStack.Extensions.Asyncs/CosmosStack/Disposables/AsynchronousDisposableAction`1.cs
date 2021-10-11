using System;
using System.Threading.Tasks;

namespace CosmosStack.Disposables
{
    /// <summary>
    /// Asynchronous Generic Disposable Action. <br />
    /// When the derived class of this class is disposed, the specified <see cref="Action{T}"/> will be executed async. <br />
    /// 异步通用释放操作。 当这个类的派生类被释放时，指定的 <see cref="Action{T}"/> 将被异步执行
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class AsynchronousDisposableAction<T> : AsynchronousDisposeHandler<T>, IAsynchronousDisposableAction
    {
        /// <summary>
        /// Create a new <see cref="AsynchronousDisposableAction{T}"/> instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public AsynchronousDisposableAction(Func<T, ValueTask> action, T context) : base(action, context) { }

        /// <summary>
        /// Create a new <see cref="AsynchronousDisposableAction{T}"/> instance.
        /// </summary>
        /// <param name="originalDisposableAction"></param>
        /// <param name="contextUpdater"></param>
        public AsynchronousDisposableAction(AsynchronousDisposableAction<T> originalDisposableAction, Func<T, T> contextUpdater)
            : base(originalDisposableAction.Action, originalDisposableAction.Context, contextUpdater) { }

        /// <summary>
        /// Invoke the disposable action async with context
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ValueTask InvokeAsync() => OnDisposeAsync();
    }
}