using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Judgments
{
    /// <summary>
    /// Assertion Judgment
    /// </summary>
    public static class AssertionJudgment
    {
        /// <summary>
        /// Require.
        /// </summary>
        /// <typeparam name="TException">Special type T.</typeparam>
        /// <param name="assertion">Predicate.</param>
        /// <param name="message">Error message.</param>
        public static void Require<TException>(bool assertion, string message) where TException : Exception
        {
            if (assertion)
                return;

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            var exception = Types.CreateInstance<TException>(message);
            throw exception;
        }

        /// <summary>
        /// Require.
        /// </summary>
        /// <typeparam name="TException">Special type TException.</typeparam>
        /// <param name="assertion">Predicate.</param>
        /// <param name="exceptionParams">Parameters for exception.</param>
        public static void Require2<TException>(bool assertion, params object[] exceptionParams) where TException : Exception
        {
            if (assertion)
                return;

            var exception = Types.CreateInstance<TException>(exceptionParams);
            throw exception;
        }

        /// <summary>
        /// Require.
        /// </summary>
        /// <typeparam name="TException">Special type TException.</typeparam>
        /// <param name="assertion">Predicate.</param>
        /// <param name="options">Cosmos exception options.</param>
        public static void Require3<TException>(bool assertion, CosmosExceptionOptions options) where TException : CosmosException
        {
            if (assertion)
                return;

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var exception = Types.CreateInstance<TException>(options);
            throw exception;
        }
    }
}
