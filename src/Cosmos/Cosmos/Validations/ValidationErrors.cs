using System;
using System.Collections.Generic;

namespace Cosmos.Validations
{
    /// <summary>
    /// Validation Error Utilities
    /// </summary>
    public static class ValidationErrors
    {
        private const long NULL_ERROR_CODE = 11001;
        private const string NULL_FLAG = "VAL_NULL";

        private const long OOR_ERROR_CODE = 11002; //OOR - Out of range
        private const string OOR_FLAG = "VAL_OOR";

        private const long INVL_ERROR_CODE = 11003; //INVL - Invalid
        private const string INVL_FLAG = "VAL_INVL";

        #region Null

        /// <summary>
        /// Returns an instance of <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static ValidationException Null(string paramName)
        {
            var exception = new ArgumentNullException(paramName);

            return new ValidationException(NULL_ERROR_CODE, exception.Message, NULL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ValidationException Null(string paramName, string message)
        {
            var exception = new ArgumentNullException(paramName, message);

            return new ValidationException(NULL_ERROR_CODE, exception.Message, NULL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public static ValidationException Null(string message, Exception innerException)
        {
            var exception = new ArgumentNullException(message, innerException);

            return new ValidationException(NULL_ERROR_CODE, exception.Message, NULL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static ValidationException Null(ArgumentNullException exception)
        {
            return new ValidationException(NULL_ERROR_CODE, exception.Message, NULL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentNullException"/> and raise.
        /// </summary>
        /// <returns></returns>
        public static void NullAndRaise()
        {
            var exception = new ArgumentNullException();

            throw new ValidationException(NULL_ERROR_CODE, exception.Message, NULL_FLAG, exception);
        }


        /// <summary>
        /// Returns an instance of <see cref="ArgumentNullException"/> and raise.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static void NullAndRaise(string paramName)
        {
            var exception = new ArgumentNullException(paramName);

            throw new ValidationException(NULL_ERROR_CODE, exception.Message, NULL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentNullException"/> and raise.
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void NullAndRaise(string paramName, string message)
        {
            var exception = new ArgumentNullException(paramName, message);

            throw new ValidationException(NULL_ERROR_CODE, exception.Message, NULL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentNullException"/> and raise.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public static void NullAndRaise(string message, Exception innerException)
        {
            var exception = new ArgumentNullException(message, innerException);

            throw new ValidationException(NULL_ERROR_CODE, exception.Message, NULL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentNullException"/> and raise.
        /// </summary>
        /// <param name="exception"></param>
        /// <exception cref="ValidationException"></exception>
        public static void NullAndRaise(ArgumentNullException exception)
        {
            throw new ValidationException(NULL_ERROR_CODE, exception.Message, NULL_FLAG, exception);
        }

        #endregion

        #region Out of range

        /// <summary>
        /// Returns an instance of <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="actualValue"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ValidationException OutOfRange(string paramName, object actualValue, string message)
        {
            var exception = new ArgumentOutOfRangeException(paramName, actualValue, message);

            return new ValidationException(OOR_ERROR_CODE, exception.Message, OOR_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ValidationException OutOfRange(string paramName, string message)
        {
            var exception = new ArgumentOutOfRangeException(paramName, message);

            return new ValidationException(OOR_ERROR_CODE, exception.Message, OOR_FLAG, exception);
        }


        /// <summary>
        /// Returns an instance of <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static ValidationException OutOfRange(string paramName)
        {
            var exception = new ArgumentOutOfRangeException(paramName);

            return new ValidationException(OOR_ERROR_CODE, exception.Message, OOR_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public static ValidationException OutOfRange(string message, Exception innerException)
        {
            var exception = new ArgumentOutOfRangeException(message, innerException);

            return new ValidationException(OOR_ERROR_CODE, exception.Message, OOR_FLAG, exception);
        }


        /// <summary>
        /// Returns an instance of <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static ValidationException OutOfRange(ArgumentOutOfRangeException exception)
        {
            return new ValidationException(OOR_ERROR_CODE, exception.Message, OOR_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentOutOfRangeException"/> and raise.
        /// </summary>
        /// <returns></returns>
        public static void OutOfRangeAndRaise()
        {
            var exception = new ArgumentOutOfRangeException();

            throw new ValidationException(OOR_ERROR_CODE, exception.Message, OOR_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentOutOfRangeException"/> and raise.
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="actualValue"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void OutOfRangeAndRaise(string paramName, object actualValue, string message)
        {
            var exception = new ArgumentOutOfRangeException(paramName, actualValue, message);

            throw new ValidationException(OOR_ERROR_CODE, exception.Message, OOR_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentOutOfRangeException"/> and raise.
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void OutOfRangeAndRaise(string paramName, string message)
        {
            var exception = new ArgumentOutOfRangeException(paramName, message);

            throw new ValidationException(OOR_ERROR_CODE, exception.Message, OOR_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentOutOfRangeException"/> and raise.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static void OutOfRangeAndRaise(string paramName)
        {
            var exception = new ArgumentOutOfRangeException(paramName);

            throw new ValidationException(OOR_ERROR_CODE, exception.Message, OOR_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentOutOfRangeException"/> and raise.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public static void OutOfRangeAndRaise(string message, Exception innerException)
        {
            var exception = new ArgumentOutOfRangeException(message, innerException);

            throw new ValidationException(OOR_ERROR_CODE, exception.Message, OOR_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentOutOfRangeException"/> and raise.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static void OutOfRangeAndRaise(ArgumentOutOfRangeException exception)
        {
            throw new ValidationException(OOR_ERROR_CODE, exception.Message, OOR_FLAG, exception);
        }

        #endregion

        #region Invalid

        /// <summary>
        /// Returns an instance of <see cref="ArgumentInvalidException"/>.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static ValidationException Invalid(string paramName)
        {
            var exception = new ArgumentInvalidException(paramName);

            throw new ValidationException(INVL_ERROR_CODE, exception.Message, INVL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentInvalidException"/>.
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ValidationException Invalid(string paramName, string message)
        {
            var exception = new ArgumentInvalidException(paramName, message);

            throw new ValidationException(INVL_ERROR_CODE, exception.Message, INVL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentInvalidException"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public static ValidationException Invalid(string message, Exception innerException)
        {
            var exception = new ArgumentInvalidException(message, innerException);

            throw new ValidationException(INVL_ERROR_CODE, exception.Message, INVL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentInvalidException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static ValidationException Invalid(ArgumentInvalidException exception)
        {
            throw new ValidationException(INVL_ERROR_CODE, exception.Message, INVL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentInvalidException"/> and raise.
        /// </summary>
        /// <returns></returns>
        public static void InvalidAndRaise()
        {
            var exception = new ArgumentInvalidException();

            throw new ValidationException(INVL_ERROR_CODE, exception.Message, INVL_FLAG, exception);
        }


        /// <summary>
        /// Returns an instance of <see cref="ArgumentInvalidException"/> and raise.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static void InvalidAndRaise(string paramName)
        {
            var exception = new ArgumentInvalidException(paramName);

            throw new ValidationException(INVL_ERROR_CODE, exception.Message, INVL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentInvalidException"/> and raise.
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void InvalidAndRaise(string paramName, string message)
        {
            var exception = new ArgumentInvalidException(paramName, message);

            throw new ValidationException(INVL_ERROR_CODE, exception.Message, INVL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentInvalidException"/> and raise.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public static void InvalidAndRaise(string message, Exception innerException)
        {
            var exception = new ArgumentInvalidException(message, innerException);

            throw new ValidationException(INVL_ERROR_CODE, exception.Message, INVL_FLAG, exception);
        }

        /// <summary>
        /// Returns an instance of <see cref="ArgumentInvalidException"/> and raise.
        /// </summary>
        /// <param name="exception"></param>
        /// <exception cref="ValidationException"></exception>
        public static void InvalidAndRaise(ArgumentInvalidException exception)
        {
            throw new ValidationException(INVL_ERROR_CODE, exception.Message, INVL_FLAG, exception);
        }

        #endregion

    }
}