using System.Threading.Tasks;

namespace CosmosStack.Disposables
{
    /// <summary>
    /// A base class for properly implementing IAsyncDisposable but also allowing for synchronous use of IDispose.
    /// Only implementing OnDisposeAsync is enough to properly handle disposal. <br />
    /// 用于正确实现 IAsyncDisposable 但也允许同步使用 IDispose 的基类。 仅实现 OnDisposeAsync 就足以正确处理处置。
    /// </summary>
    public abstract class AsynchronousDisposableBase : DisposableStateBase
#if NETSTANDARD2_1 || NETCOREAPP3_0 || NETCOREAPP3_1
                                                     , System.IAsyncDisposable
#endif
    {
        /// <summary>
        /// Without overriding OnDispose, OnDisposeAsync will be called no matter what depending on how the object is disposed.<br />
        /// If asynchronous is true, was called by .DisposeAsync(), otherwise. <br />
        /// 在不覆盖 OnDispose 的情况下，将根据对象的处置方式调用 OnDisposeAsync。 如果异步为真，则由 .DisposeAsync() 调用，否则。
        /// </summary>
        protected abstract ValueTask OnDisposeAsync();

        /// <summary>
        /// Dispose async
        /// <br />
        /// 异步 Dispose
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync()
        {
            /*
             * Note about the BeforeDispose event:
             * Although this is asynchronous, it's not this class' responsibility to decide how subscribers will behave.
             * A subscriber should smartly defer responses when possible, or only respond in a properly synchronous non-blockin way.
             */

            if (!StartDispose())
                return new ValueTask();

            var dispose = true;
            try
            {
                var d = OnDisposeAsync();
                if (!d.IsCompletedSuccessfully)
                {
                    dispose = false;
                    return OnDisposeAsyncInternal(d);
                }
            }
            finally
            {
                if (dispose) Disposed();
            }

            return new ValueTask();
        }

        private async ValueTask OnDisposeAsyncInternal(ValueTask onDispose)
        {
            try
            {
                await onDispose;
            }
            finally
            {
                Disposed();
            }
        }
    }
}