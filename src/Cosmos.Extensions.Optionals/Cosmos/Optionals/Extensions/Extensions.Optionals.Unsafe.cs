using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Optionals {
    /// <summary>
    /// Unsafe extensions for optional
    /// </summary>
    public static partial class OptionalsExtensions {
        /// <summary>
        /// Convert <see cref="Maybe{T}"/> to nullable version of <typeparamref name="T"/><br />
        /// 将指定的 <see cref="Maybe{T}"/> 转换为可空版本。
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? ToNullable<T>(this Maybe<T> option) where T : struct =>
            option.HasValue ? option.Value : default(T?);

        /// <summary>
        /// Return the value of the given <see cref="Maybe{T}"/>, if null then returns the default value.<br />
        /// 返回给定 <see cref="Maybe{T}"/> 的值，如果不存在该值则返回默认值。
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ValueOrDefault<T>(this Maybe<T> option) =>
            option.HasValue ? option.Value : default;

        /// <summary>
        /// Return the value of the given <see cref="Maybe{T}"/>, if null then raise an <see cref="OptionalValueMissingException"/>.<br />
        /// 返回给定 <see cref="Maybe{T}"/> 的值，如果不存在该值则抛出一个 <see cref="OptionalValueMissingException"/> 异常。
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
        /// Convert <see cref="Either{T, TException}"/> to nullable version of <typeparamref name="T"/><br />
        /// 将指定的 <see cref="Either{T, TException}"/> 转换为可空版本。
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static T? ToNullable<T, TException>(this Either<T, TException> option) where T : struct =>
            option.HasValue ? option.Value : default(T?);

        /// <summary>
        /// Return the value of the given <see cref="Either{T, TException}"/>, if null then returns the default value.<br />
        /// 返回给定 <see cref="Either{T, TException}"/> 的值，如果不存在该值则返回默认值。
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static T ValueOrDefault<T, TException>(this Either<T, TException> option) =>
            option.HasValue ? option.Value : default;

        /// <summary>
        /// Return the value of the given <see cref="Either{T, TException}"/>, if null then raise an <see cref="OptionalValueMissingException"/>.<br />
        /// 返回给定 <see cref="Either{T, TException}"/> 的值，如果不存在该值则抛出一个 <see cref="OptionalValueMissingException"/> 异常。
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
        /// Return the value of the given <see cref="Maybe{T}"/>, if null then raise an <see cref="OptionalValueMissingException"/> with the given error message.<br />
        /// 返回给定 <see cref="Maybe{T}"/> 的值，如果不存在该值则抛出一个使用给定异常信息的 <see cref="OptionalValueMissingException"/> 异常。
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
        /// Return the value of the given <see cref="Maybe{T}"/>, if null then raise an <see cref="OptionalValueMissingException"/> with the given error message.<br />
        /// 返回给定 <see cref="Maybe{T}"/> 的值，如果不存在该值则抛出一个使用给定异常信息的 <see cref="OptionalValueMissingException"/> 异常。
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
        /// Return the value of the given <see cref="Either{T, TException}"/>, if null then raise an <see cref="OptionalValueMissingException"/> with the given error message.<br />
        /// 返回给定 <see cref="Either{T, TException}"/> 的值，如果不存在该值则抛出一个使用给定异常信息的 <see cref="OptionalValueMissingException"/> 异常。
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
        /// Return the value of the given <see cref="Either{T, TException}"/>, if null then raise an <see cref="OptionalValueMissingException"/> with the given error message.<br />
        /// 返回给定 <see cref="Either{T, TException}"/> 的值，如果不存在该值则抛出一个使用给定异常信息的 <see cref="OptionalValueMissingException"/> 异常。
        /// </summary>
        /// <param name="option"></param>
        /// <param name="errorMessageFactory"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="OptionalValueMissingException"></exception>
        public static T ValueOrFailure<T, TException>(this Either<T, TException> option, Func<TException, string> errorMessageFactory) {
            if (errorMessageFactory is null) {
                throw new ArgumentNullException(nameof(errorMessageFactory));
            }

            if (option.HasValue) {
                return option.Value;
            }

            throw new OptionalValueMissingException(errorMessageFactory(option.Exception));
        }
    }
}