using System;
using System.Threading.Tasks;

namespace Cosmos.Disposables
{
    /// <summary>
    /// Asynchronous Disable Action. <br />
    /// When the derived class of this class is disposed, the specified <see cref="Action"/> will be executed async.
    /// </summary>
    public sealed class AsynchronousDisposableAction : AsynchronousDisposeHandler, IAsynchronousDisposableAction
    {
        /// <summary>
        /// Create a new <see cref="AsynchronousDisposableAction"/> instance.
        /// </summary>
        /// <param name="action"></param>
        public AsynchronousDisposableAction(Func<ValueTask> action) : base(action) { }

        /// <inheritdoc />
        public ValueTask InvokeAsync() => OnDisposeAsync();
    }
}