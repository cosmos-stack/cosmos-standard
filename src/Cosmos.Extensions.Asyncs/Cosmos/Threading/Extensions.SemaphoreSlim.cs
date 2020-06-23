using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Threading
{
    /// <summary>
    /// Extensions for SemaphoreSlim
    /// </summary>
    public static class SemaphoreSlimExtensions
    {
        /// <summary>
        /// Executes an action within the context of a a Semaphore.
        /// </summary>
        /// <param name="target">The semaphore instance</param>
        /// <param name="closure">The action to execute.</param>
        public static void Execute(this Semaphore target, Action closure)
        {
            if (target is null)
                throw new ArgumentNullException(nameof(target));
            if (closure is null)
                throw new ArgumentNullException(nameof(closure));

            Contract.EndContractBlock();

            try
            {
                target.WaitOne();
                closure();
            }
            finally
            {
                try
                {
                    target.Release();
                }
                catch (SemaphoreFullException sfEx)
                {
                    Debug.WriteLine(sfEx.ToString());
                }
            }
        }

        /// <summary>
        /// Executes an action within the context of a a SemaphoreSlim.
        /// </summary>
        /// <param name="target">The semaphore instance</param>
        /// <param name="closure">The action to execute.</param>
        public static void Execute(this SemaphoreSlim target, Action closure)
        {
            if (target is null)
                throw new ArgumentNullException(nameof(target));
            if (closure is null)
                throw new ArgumentNullException(nameof(closure));

            Contract.EndContractBlock();

            try
            {
                target.Wait();
                closure();
            }
            finally
            {
                try
                {
                    target.Release();
                }
                catch (SemaphoreFullException sfEx)
                {
                    Debug.WriteLine(sfEx.ToString());
                }
            }
        }

        /// <summary>
        /// Executes a function within the context of a a Semaphore.
        /// </summary>
        /// <typeparam name="T">Type of the result.</typeparam>
        /// <param name="target">The semaphore instance</param>
        /// <param name="closure">The function to execute.</param>
        /// <returns>The value of the function.</returns>
        public static T Execute<T>(this Semaphore target, Func<T> closure)
        {
            if (target is null)
                throw new ArgumentNullException(nameof(target));
            if (closure is null)
                throw new ArgumentNullException(nameof(closure));

            Contract.EndContractBlock();

            try
            {
                target.WaitOne();
                return closure();
            }
            finally
            {
                try
                {
                    target.Release();
                }
                catch (SemaphoreFullException sfEx)
                {
                    Debug.WriteLine(sfEx.ToString());
                }
            }
        }

        /// <summary>
        /// Executes a function within the context of a a SemaphoreSlim.
        /// </summary>
        /// <typeparam name="T">Type of the result.</typeparam>
        /// <param name="target">The semaphore instance</param>
        /// <param name="closure">The function to execute.</param>
        /// <returns>The value of the function.</returns>
        public static T Execute<T>(this SemaphoreSlim target, Func<T> closure)
        {
            if (target is null)
                throw new ArgumentNullException(nameof(target));
            if (closure is null)
                throw new ArgumentNullException(nameof(closure));

            Contract.EndContractBlock();

            try
            {
                target.Wait();
                return closure();
            }
            finally
            {
                try
                {
                    target.Release();
                }
                catch (SemaphoreFullException sfEx)
                {
                    Debug.WriteLine(sfEx.ToString());
                }
            }
        }

        /// <summary>
        /// Executes a task within the context of a a SemaphoreSlim.
        /// </summary>
        /// <typeparam name="T">Type of the result.</typeparam>
        /// <param name="target">The semaphore instance</param>
        /// <param name="closure">The function to execute as a task.</param>
        /// <returns>A task containing the result.</returns>
        public static async Task<T> ExecuteAsync<T>(this SemaphoreSlim target, Func<T> closure)
        {
            if (target is null)
                throw new ArgumentNullException(nameof(target));
            if (closure is null)
                throw new ArgumentNullException(nameof(closure));

            Contract.EndContractBlock();

            try
            {
                await target.WaitAsync().ConfigureAwait(false);
                return closure();
            }
            finally
            {
                try
                {
                    target.Release();
                }
                catch (SemaphoreFullException sfEx)
                {
                    Debug.WriteLine(sfEx.ToString());
                }
            }
        }

        /// <summary>
        /// Executes a task within the context of a a SemaphoreSlim.
        /// </summary>
        /// <typeparam name="T">Type of the result.</typeparam>
        /// <param name="target">The semaphore instance</param>
        /// <param name="task">The task being waited on.</param>
        /// <returns>The task provided.</returns>
        public static async Task<T> TaskExecuteAsync<T>(this SemaphoreSlim target, Task<T> task)
        {
            if (target is null)
                throw new ArgumentNullException(nameof(target));
            if (task is null)
                throw new ArgumentNullException(nameof(task));

            Contract.EndContractBlock();

            try
            {
                await target.WaitAsync().ConfigureAwait(false);
                return await task;
            }
            finally
            {
                try
                {
                    target.Release();
                }
                catch (SemaphoreFullException sfEx)
                {
                    Debug.WriteLine(sfEx.ToString());
                }
            }
        }

        /// <summary>
        /// Executes a task within the context of a a SemaphoreSlim.
        /// </summary>
        /// <typeparam name="T">Type of the result.</typeparam>
        /// <param name="target">The semaphore instance</param>
        /// <param name="task">The task being waited on.</param>
        /// <returns>The task provided.</returns>
        public static async Task<T> ExecuteAsync<T>(this SemaphoreSlim target, ValueTask<T> task)
        {
            if (target is null)
                throw new ArgumentNullException(nameof(target));

            Contract.EndContractBlock();

            try
            {
                await target.WaitAsync().ConfigureAwait(false);
                return await task;
            }
            finally
            {
                try
                {
                    target.Release();
                }
                catch (SemaphoreFullException sfEx)
                {
                    Debug.WriteLine(sfEx.ToString());
                }
            }
        }
    }
}