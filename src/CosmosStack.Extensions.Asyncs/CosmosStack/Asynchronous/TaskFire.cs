using System;
using System.Threading.Tasks;
using CosmosStack.Exceptions;

/*
 * Reference to
 *     https://github.com/brminnick/AsyncAwaitBestPractices
 *     Author:Brandon Minnick
 *     MIT
 */

namespace CosmosStack.Asynchronous
{
    public static class TaskFire
    {
        private static Action<Exception> _globalExceptionAction;
        private static bool _shouldAlwaysRethrowException;

        /// <summary>
        /// Safety execute the Task without waiting for it to complete before moving to the next line of code; commonly known as "Fire and Forget".<br />
        /// Inspired by John Thiriet's blog post, "Removing Async Void": https://jhonthiriet.com/removing-async-void/.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="exceptionAction"></param>
        /// <param name="continueOnCapturedContext"></param>
        public static void SafeFireAndForget(Task task, Action<Exception> exceptionAction = null,
            bool continueOnCapturedContext = false)
        {
            HandleSafeFireAndForget(task, continueOnCapturedContext, exceptionAction);
        }

        /// <summary>
        /// Safety execute the Task without waiting for it to complete before moving to the next line of code; commonly known as "Fire and Forget".<br />
        /// Inspired by John Thiriet's blog post, "Removing Async Void": https://jhonthiriet.com/removing-async-void/.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="exceptionAction"></param>
        /// <param name="continueOnCapturedContext"></param>
        /// <typeparam name="TException"></typeparam>
        public static void SafeFireAndForget<TException>(Task task, Action<TException> exceptionAction = null,
            bool continueOnCapturedContext = false)
            where TException : Exception
        {
            HandleSafeFireAndForget(task, continueOnCapturedContext, exceptionAction);
        }

        /// <summary>
        /// Initialize SafeFireAndForget
        /// </summary>
        /// <param name="shouldAlwaysRethrowException"></param>
        public static void Initialize(bool shouldAlwaysRethrowException = false)
        {
            _shouldAlwaysRethrowException = shouldAlwaysRethrowException;
        }

        /// <summary>
        /// Remove the default action for SafeFireAndForget
        /// </summary>
        public static void RemoveDefaultExceptionHandling()
        {
            _globalExceptionAction = null;
        }

        /// <summary>
        /// Set the default action for SafeFireAndForget to handle every exception
        /// </summary>
        /// <param name="exceptionAction"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetDefaultExceptionHanding(Action<Exception> exceptionAction)
        {
            if (exceptionAction is null)
                throw new ArgumentNullException(nameof(exceptionAction));
            _globalExceptionAction = exceptionAction;
        }

        internal static async void HandleSafeFireAndForget<TException>(Task task, bool continueOnCapturedContext, Action<TException> exceptionAction)
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

        internal static void HandleException<TException>(TException exception, Action<TException> exceptionAction)
            where TException : Exception
        {
            _globalExceptionAction?.Invoke(exception);
            exceptionAction?.Invoke(exception);
        }
        
        internal static async void HandleSafeFireAndForget<TException>(ValueTask task, bool continueOnCapturedContext, Action<TException> exceptionAction)
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

    public static class TaskFireExtensions
    {
        /// <summary>
        /// Safety execute the Task without waiting for it to complete before moving to the next line of code; commonly known as "Fire and Forget".<br />
        /// Inspired by John Thiriet's blog post, "Removing Async Void": https://jhonthiriet.com/removing-async-void/.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="exceptionAction"></param>
        /// <param name="continueOnCapturedContext"></param>
        public static void SafeFireAndForget(this Task task, Action<Exception> exceptionAction = null,
            bool continueOnCapturedContext = false)
        {
            TaskFire.SafeFireAndForget(task, exceptionAction, continueOnCapturedContext);
        }

        /// <summary>
        /// Safety execute the Task without waiting for it to complete before moving to the next line of code; commonly known as "Fire and Forget".<br />
        /// Inspired by John Thiriet's blog post, "Removing Async Void": https://jhonthiriet.com/removing-async-void/.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="exceptionAction"></param>
        /// <param name="continueOnCapturedContext"></param>
        /// <typeparam name="TException"></typeparam>
        public static void SafeFireAndForget<TException>(this Task task, Action<TException> exceptionAction = null,
            bool continueOnCapturedContext = false)
            where TException : Exception
        {
            TaskFire.SafeFireAndForget(task, exceptionAction, continueOnCapturedContext);
        }
    }
}