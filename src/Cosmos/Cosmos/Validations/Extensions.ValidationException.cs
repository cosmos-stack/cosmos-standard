using System;

namespace Cosmos.Validations
{
    /// <summary>
    /// Validation exception extensions.
    /// </summary>
    public static class ValidationExceptionExtensions
    {
        /// <summary>
        /// Throw as ValidationException.
        /// </summary>
        /// <param name="exception"></param>
        /// <exception cref="ValidationException"></exception>
        public static void ThrowAsValidationError(this ArgumentNullException exception)
        {
            if (exception == null)
                return;

            ValidationErrors.NullAndRaise(exception);
        }

        /// <summary>
        /// Throw as ValidationException.
        /// </summary>
        /// <param name="exception"></param>
        public static void ThrowAsValidationError(this ArgumentOutOfRangeException exception)
        {
            if (exception == null)
                return;

            ValidationErrors.OutOfRangeAndRaise(exception);
        }

        /// <summary>
        /// Throw as ValidationException.
        /// </summary>
        /// <param name="exception"></param>
        public static void ThrowAsValidationError(this ArgumentInvalidException exception)
        {
            if (exception == null)
                return;

            ValidationErrors.InvalidAndRaise(exception);
        }
    }
}