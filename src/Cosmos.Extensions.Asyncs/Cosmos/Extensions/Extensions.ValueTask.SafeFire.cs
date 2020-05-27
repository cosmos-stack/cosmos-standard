/*
 * Reference to
 *     https://github.com/brminnick/AsyncAwaitBestPractices
 *     Author:Brandon Minnick
 *     MIT
 */

using System;
using System.Threading.Tasks;
using Cosmos.Exceptions;

// ReSharper disable once CheckNamespace
namespace Cosmos.Asynchronous
{
    /// <summary>
    /// Extensions for task
    /// </summary>
    public static partial class TaskExtensions
    {
        /// <summary>
        /// Safety execute the ValueTask without waiting for it to complete before moving to the next line of code; commonly known as "Fire and Forget".<br />
        /// Inspired by John Thiriet's blog post, "Removing Async Void": https://jhonthiriet.com/removing-async-void/.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="exceptionAction"></param>
        /// <param name="continueOnCapturedContext"></param>
        public static void SafeFireAndForget(this ValueTask task, Action<Exception> exceptionAction = null,
            bool continueOnCapturedContext = false)
        {
            HandleSafeFireAndForget(task, continueOnCapturedContext, exceptionAction);
        }

        /// <summary>
        /// Safety execute the ValueTask without waiting for it to complete before moving to the next line of code; commonly known as "Fire and Forget".<br />
        /// Inspired by John Thiriet's blog post, "Removing Async Void": https://jhonthiriet.com/removing-async-void/.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="exceptionAction"></param>
        /// <param name="continueOnCapturedContext"></param>
        /// <typeparam name="TException"></typeparam>
        public static void SafeFireAndForget<TException>(this ValueTask task, Action<TException> exceptionAction = null,
            bool continueOnCapturedContext = false)
            where TException : Exception
        {
            HandleSafeFireAndForget(task, continueOnCapturedContext, exceptionAction);
        }
        
        private static async void HandleSafeFireAndForget<TException>(ValueTask task, bool continueOnCapturedContext, Action<TException> exceptionAction)
            where TException : Exception
        {
            try
            {
                await task.ConfigureAwait(continueOnCapturedContext);
            }
            catch (TException ex) when (_globalExceptionAction != null || exceptionAction != null)
            {
                HandleException(ex, exceptionAction);
                if (_shouldAlwaysRethrowException)
                    ExceptionHelper.PrepareForRethrow(ex);
            }
        }
    }
}