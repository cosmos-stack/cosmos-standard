using System;
using System.Runtime.ExceptionServices;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Exception helper
    /// </summary>
    public static partial class ExceptionHelper
    {
        /// <summary>
        /// Prepare for rethrow
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Exception PrepareForRethrow(Exception exception)
        {
            ExceptionDispatchInfo.Capture(exception).Throw();

            // The code cannot ever get here. We just return a value to work around a badly-designed API (ExceptionDispatchInfo.Throw):
            //  https://connect.microsoft.com/VisualStudio/feedback/details/689516/exceptiondispatchinfo-api-modifications (http://www.webcitation.org/6XQ7RoJmO)
            return exception;
        }

        /// <summary>
        /// Require.
        /// </summary>
        /// <typeparam name="TException">Special type T.</typeparam>
        /// <param name="assertion">Predicate.</param>
        /// <param name="message">Error message.</param>
        public static void Raise<TException>(bool assertion, string message) where TException : Exception
        {
            if (assertion)
                return;

            Exception exception;

            if (string.IsNullOrEmpty(message))
            {
                exception = new ArgumentNullException(nameof(message));
            }
            else
            {
                exception = Reflection.Types.CreateInstance<TException>(message);
            }

            PrepareForRethrow(exception);
        }

        /// <summary>
        /// Require.
        /// </summary>
        /// <typeparam name="TException">Special type TException.</typeparam>
        /// <param name="assertion">Predicate.</param>
        /// <param name="exceptionParams">Parameters for exception.</param>
        public static void Raise<TException>(bool assertion, params object[] exceptionParams) where TException : Exception
        {
            if (assertion)
                return;

            var exception = Reflection.Types.CreateInstance<TException>(exceptionParams);

            PrepareForRethrow(exception);
        }

        /// <summary>
        /// Require.
        /// </summary>
        /// <typeparam name="TException">Special type TException.</typeparam>
        /// <param name="assertion">Predicate.</param>
        /// <param name="options">Cosmos exception options.</param>
        public static void Raise<TException>(bool assertion, ExceptionOptions options) where TException : CosmosException
        {
            if (assertion)
                return;

            Exception exception;

            if (options is null)
            {
                exception = new ArgumentNullException(nameof(options));
            }
            else
            {
                exception = Reflection.Types.CreateInstance<TException>(options);
            }

            PrepareForRethrow(exception);
        }
    }
}