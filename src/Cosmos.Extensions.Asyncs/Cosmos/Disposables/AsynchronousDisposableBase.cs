using System.Threading.Tasks;

namespace Cosmos.Disposables
{
    /// <summary>
    /// A base class for properly implementing IAsyncDisposable but also allowing for synchronous use of IDispose.
    /// Only implementing OnDisposeAsync is enough to properly handle disposal.
    /// </summary>
    public abstract class AsynchronousDisposableBase : DisposableStateBase
#if NETSTANDARD2_1 || NETCOREAPP3_0 || NETCOREAPP3_1
                                                     , System.IAsyncDisposable
#endif
    {
        /// <summary>
        /// Without overriding OnDispose, OnDisposeAsync will be called no matter what depending on how the object is disposed.<br />
        /// If asynchronous istrue, was called by .DisposeAsync(), otherwise.
        /// </summary>
        protected abstract ValueTask OnDisposeAsync();

        /// <summary>
        /// Dispose async
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