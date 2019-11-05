using System;
using Cosmos.Validations.Abstractions;

namespace Cosmos.Validations
{
    /// <summary>
    /// Validation exception extensions
    /// </summary>
    public static class ValidationExceptionExtensions
    {
        /// <summary>
        /// To exception
        /// </summary>
        /// <param name="resultCollection"></param>
        /// <param name="appendAction"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TException ToException<TException>(this ValidationResultCollection resultCollection,
            Action<TException, ValidationResultCollection> appendAction = null)
            where TException : CosmosException, new()
        {
            if (resultCollection == null)
            {
                throw new ArgumentNullException(nameof(resultCollection));
            }

            if (typeof(TException) == typeof(ValidationException))
            {
                return ToException(resultCollection, (e, c) => appendAction?.Invoke(e as TException, c)) as TException;
            }

            var exception = CreateBasicException<TException>(resultCollection);

            appendAction?.Invoke(exception, resultCollection);

            return exception;
        }

        /// <summary>
        /// To exception
        /// </summary>
        /// <param name="resultCollection"></param>
        /// <param name="appendAction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ValidationException ToException(this ValidationResultCollection resultCollection,
            Action<ValidationException, ValidationResultCollection> appendAction = null)
        {
            if (resultCollection == null)
            {
                throw new ArgumentNullException(nameof(resultCollection));
            }

            var exception = CreatValidationException(resultCollection);

            appendAction?.Invoke(exception, resultCollection);

            return exception;
        }

        /// <summary>
        /// To exception
        /// </summary>
        /// <param name="result"></param>
        /// <param name="appendAction"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static TException ToException<TException>(
            this IValidationResult result,
            Action<TException, ValidationResultCollection> appendAction = null)
            where TException : CosmosException, new()
        {
            switch (result)
            {
                case ValidationResultCollection fluentResult:
                    return ToException(fluentResult, appendAction);
                case null:
                    throw new ArgumentNullException(nameof(result));
                default:
                    throw new ArgumentException("ValidationResultCollection's type is invalid.");
            }
        }

        /// <summary>
        /// To exception
        /// </summary>
        /// <param name="result"></param>
        /// <param name="appendAction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static ValidationException ToException(this IValidationResult result,
            Action<ValidationException, ValidationResultCollection> appendAction = null)
        {
            switch (result)
            {
                case ValidationResultCollection fluentResult:
                    return ToException(fluentResult, appendAction);
                case null:
                    throw new ArgumentNullException(nameof(result));
                default:
                    throw new ArgumentException("ValidationResultCollection's type is invalid.");
            }
        }

        private static TException CreateBasicException<TException>(IValidationResult result)
            where TException : CosmosException, new()
        {
            var exception = Types.CreateInstance<TException>(result.ErrorCode, result.ToMessage(), result.Flag);

            exception.ExtraData.Add("ValidationResultCollection", result);

            return exception;
        }

        private static ValidationException CreatValidationException(IValidationResult result)
        {
            var exception = new ValidationException(result.ErrorCode, result.ToMessage(), result.ToValidationMessages(), result.Flag);

            exception.ExtraData.Add("ValidationResultCollection", result);

            return exception;
        }

        /// <summary>
        /// Raise exception
        /// </summary>
        /// <param name="resultCollection"></param>
        /// <param name="appendAction"></param>
        /// <typeparam name="TException"></typeparam>
        public static void RaiseException<TException>(this ValidationResultCollection resultCollection,
            Action<TException, ValidationResultCollection> appendAction = null)
            where TException : CosmosException, new()
        {
            throw resultCollection.ToException(appendAction);
        }

        /// <summary>
        /// Raise exception
        /// </summary>
        /// <param name="resultCollection"></param>
        /// <param name="appendAction"></param>
        /// <exception cref="ValidationException"></exception>
        public static void RaiseException(this ValidationResultCollection resultCollection,
            Action<ValidationException, ValidationResultCollection> appendAction = null)
        {
            throw resultCollection.ToException(appendAction);
        }
    }
}