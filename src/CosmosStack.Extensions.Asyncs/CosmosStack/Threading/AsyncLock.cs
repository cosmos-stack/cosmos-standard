using System;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosStack.Threading
{
    /// <summary>
    /// AsyncLock <br />
    /// 异步锁
    /// </summary>
    public sealed class AsyncLock : IDisposable
    {
        private readonly SemaphoreSlim _mutex = new(1, 1);

        /// <summary>
        /// Lock
        /// </summary>
        /// <returns></returns>
        public IDisposable Lock()
        {
            _mutex.Wait();
            return new AsyncLockReleaser(_mutex);
        }

        /// <summary>
        /// Lock async
        /// </summary>
        /// <returns></returns>
        public Task<IDisposable> LockAsync()
        {
            return LockAsync(CancellationToken.None);
        }

        /// <summary>
        /// Lock async
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IDisposable> LockAsync(CancellationToken cancellationToken)
        {
            return LockAsync(TimeSpan.Zero, cancellationToken);
        }

        /// <summary>
        /// Lock async
        /// </summary>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IDisposable> LockAsync(TimeSpan timeout, CancellationToken cancellationToken)
        {
            if (timeout <= TimeSpan.Zero)
            {
                await _mutex.WaitAsync(cancellationToken);
            }
            else
            {
                await _mutex.WaitAsync(timeout, cancellationToken);
            }

            return new AsyncLockReleaser(_mutex);
        }

        public void Dispose()
        {
            _mutex.Dispose();
        }

        private struct AsyncLockReleaser : IDisposable
        {
            private readonly SemaphoreSlim _semaphoreSlim;

            public AsyncLockReleaser(SemaphoreSlim semaphoreSlim)
            {
                _semaphoreSlim = semaphoreSlim;
            }

            public void Dispose()
            {
                _semaphoreSlim.Release();
            }
        }
    }
}