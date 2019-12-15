using System;
using System.Diagnostics.CodeAnalysis;
using Cosmos.Validations;

namespace Cosmos.Judgments {
    /// <summary>
    /// Assertion Judgment
    /// </summary>
    public static class AssertionJudgment {
        /// <summary>
        /// Require.
        /// </summary>
        /// <typeparam name="TException">Special type T.</typeparam>
        /// <param name="assertion">Predicate.</param>
        /// <param name="message">Error message.</param>
        public static void Require<TException>(bool assertion, string message) where TException : Exception {
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
        public static void Require2<TException>(bool assertion, params object[] exceptionParams) where TException : Exception {
            if (assertion)
                return;

            var exception = Types.CreateInstance<TException>(exceptionParams);
            throw exception;
        }

        /// <summary>
        /// Require.
        /// </summary>
        /// <param name="assertion"></param>
        /// <param name="exceptionParams"></param>
        /// <typeparam name="TException"></typeparam>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static void Require2Validation<TException>(bool assertion, params object[] exceptionParams) where TException : Exception {
            if (assertion)
                return;

            var exception = Types.CreateInstance<TException>(exceptionParams);

            throw exception switch {
                ArgumentNullException __exception_01       => (Exception) ValidationErrors.Null(__exception_01),
                ArgumentOutOfRangeException __exception_02 => ValidationErrors.OutOfRange(__exception_02),
                ArgumentInvalidException __exception_03    => ValidationErrors.Invalid(__exception_03),
                _                                          => exception
            };
        }

        /// <summary>
        /// Require.
        /// </summary>
        /// <typeparam name="TException">Special type TException.</typeparam>
        /// <param name="assertion">Predicate.</param>
        /// <param name="options">Cosmos exception options.</param>
        public static void Require3<TException>(bool assertion, CosmosExceptionOptions options) where TException : CosmosException {
            if (assertion)
                return;

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var exception = Types.CreateInstance<TException>(options);
            throw exception;
        }
    }
}