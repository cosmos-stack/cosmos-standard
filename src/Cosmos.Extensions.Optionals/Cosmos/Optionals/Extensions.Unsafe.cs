using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// Unsafe extensions for optional
    /// </summary>
    public static class UnsafeOptionalExtensions {
        /// <summary>
        /// TO nullable
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? ToNullable<T>(this Maybe<T> option) where T : struct {
            return option.HasValue ? option.Value : default(T?);
        }

        /// <summary>
        /// Value or default
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ValueOrDefault<T>(this Maybe<T> option) {
            return option.HasValue ? option.Value : default;
        }

        /// <summary>
        /// Value or failure
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="OptionalValueMissingException"></exception>
        public static T ValueOrFailure<T>(this Maybe<T> option) {
            if (option.HasValue) {
                return option.Value;
            }

            throw new OptionalValueMissingException();
        }

        /// <summary>
        /// To nullable
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static T? ToNullable<T, TException>(this Either<T, TException> option) where T : struct {
            return option.HasValue ? option.Value : default(T?);
        }

        /// <summary>
        /// Value or default
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static T ValueOrDefault<T, TException>(this Either<T, TException> option) {
            return option.HasValue ? option.Value : default;
        }

        /// <summary>
        /// Value or failure
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="OptionalValueMissingException"></exception>
        public static T ValueOrFailure<T, TException>(this Either<T, TException> option) {
            if (option.HasValue) {
                return option.Value;
            }

            throw new OptionalValueMissingException();
        }

        /// <summary>
        /// Value or failure
        /// </summary>
        /// <param name="option"></param>
        /// <param name="errorMessage"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="OptionalValueMissingException"></exception>
        public static T ValueOrFailure<T>(this Maybe<T> option, string errorMessage) {
            if (option.HasValue) {
                return option.Value;
            }

            throw new OptionalValueMissingException(errorMessage);
        }

        /// <summary>
        /// Value or failure
        /// </summary>
        /// <param name="option"></param>
        /// <param name="errorMessageFactory"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="OptionalValueMissingException"></exception>
        public static T ValueOrFailure<T>(this Maybe<T> option, Func<string> errorMessageFactory) {
            if (errorMessageFactory is null)
                throw new ArgumentNullException(nameof(errorMessageFactory));

            if (option.HasValue) {
                return option.Value;
            }

            throw new OptionalValueMissingException(errorMessageFactory());
        }

        /// <summary>
        /// Value or failure
        /// </summary>
        /// <param name="option"></param>
        /// <param name="errorMessage"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="OptionalValueMissingException"></exception>
        public static T ValueOrFailure<T, TException>(this Either<T, TException> option, string errorMessage) {
            if (option.HasValue) {
                return option.Value;
            }

            throw new OptionalValueMissingException(errorMessage);
        }

        /// <summary>
        /// Value or failure
        /// </summary>
        /// <param name="option"></param>
        /// <param name="errorMessageFactory"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="OptionalValueMissingException"></exception>
        public static T ValueOrFailure<T, TException>(this Either<T, TException> option, Func<TException, string> errorMessageFactory) {
            if (errorMessageFactory is null)
                throw new ArgumentNullException(nameof(errorMessageFactory));

            if (option.HasValue) {
                return option.Value;
            }

            throw new OptionalValueMissingException(errorMessageFactory(option.Exception));
        }
    }
}