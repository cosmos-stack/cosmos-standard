using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// Extensions for optional
    /// </summary>
    public static class OptionalExtensions {

        #region Maybe

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Maybe<T> ToMaybe<T>(this T value) {
            return Optional.Some(value);
        }

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static Either<T, TException> ToMaybe<T, TException>(this T value) {
            return Optional.Some<T, TException>(value);
        }

        #endregion

        #region Some

        /// <summary>
        /// To some
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IOptional<T> Some<T>(this T value,
            OptionalType type = OptionalType.ReferenceType) {
            return type == OptionalType.ReferenceType
                ? Optional.Wrapped.Some(value)
                : Optional.Some(value) as IOptional<T>;
        }

        /// <summary>
        /// To some
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IOptional<T> Some<T>(this T value, Func<T, bool> predicate,
            OptionalType type = OptionalType.ReferenceType) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return predicate(value) ? value.Some(type) : value.None(type);
        }

        /// <summary>
        /// To some
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static IOptional<T, TException> Some<T, TException>(this T value,
            OptionalType type = OptionalType.ReferenceType) {
            return type == OptionalType.ReferenceType
                ? Optional.Wrapped.Some<T, TException>(value)
                : Optional.Some<T, TException>(value) as IOptional<T, TException>;
        }

        /// <summary>
        /// To some
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="exception"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IOptional<T, TException> Some<T, TException>(this T value, Func<T, bool> predicate, TException exception,
            OptionalType type = OptionalType.ReferenceType) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return predicate(value) ? value.Some<T, TException>(type) : value.None(exception, type);
        }

        /// <summary>
        /// To some
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="exceptionFactory"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IOptional<T, TException> Some<T, TException>(this T value, Func<T, bool> predicate, Func<TException> exceptionFactory,
            OptionalType type = OptionalType.ReferenceType) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return predicate(value) ? value.Some<T, TException>(type) : value.None(exceptionFactory(), type);
        }

        /// <summary>
        /// To some
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="exceptionFactory"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IOptional<T, TException> Some<T, TException>(this T value, Func<T, bool> predicate, Func<T, TException> exceptionFactory,
            OptionalType type = OptionalType.ReferenceType) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return predicate(value) ? value.Some<T, TException>(type) : value.None(exceptionFactory(value), type);
        }

        #endregion

        #region Some not null

        /// <summary>
        /// To some not null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IOptional<T> SomeNotNull<T>(this T value,
            OptionalType type = OptionalType.ReferenceType) {
            return value.Some(val => val != null, type);
        }

        /// <summary>
        /// To some not null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exception"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static IOptional<T, TException> SomeNotNull<T, TException>(this T value, TException exception,
            OptionalType type = OptionalType.ReferenceType) {
            return value.Some(val => val != null, exception, type);
        }

        /// <summary>
        /// To some not null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exceptionFactory"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IOptional<T, TException> SomeNotNull<T, TException>(this T value, Func<TException> exceptionFactory,
            OptionalType type = OptionalType.ReferenceType) {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return value.Some(val => val != null, exceptionFactory, type);
        }

        /// <summary>
        /// To some not null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exceptionFactory"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IOptional<T, TException> SomeNotNull<T, TException>(this T value, Func<T, TException> exceptionFactory,
            OptionalType type = OptionalType.ReferenceType) {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return value.Some(val => val != null, exceptionFactory, type);
        }

        #endregion

        #region None

        /// <summary>
        /// To none
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IOptional<T> None<T>(this T value,
            OptionalType type = OptionalType.ReferenceType) {
            return type == OptionalType.ReferenceType
                ? Optional.Wrapped.None<T>()
                : Optional.None<T>() as IOptional<T>;
        }

        /// <summary>
        /// To none
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exception"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static IOptional<T, TException> None<T, TException>(this T value, TException exception,
            OptionalType type = OptionalType.ReferenceType) {
            return type == OptionalType.ReferenceType
                ? Optional.Wrapped.None<T, TException>(exception)
                : Optional.None<T, TException>(exception) as IOptional<T, TException>;
        }

        /// <summary>
        /// To none
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IOptional<T> None<T>(this T value, Func<T, bool> predicate,
            OptionalType type = OptionalType.ReferenceType) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return value.Some(val => !predicate(val), type);
        }

        /// <summary>
        /// To none
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="exception"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IOptional<T, TException> None<T, TException>(this T value, Func<T, bool> predicate, TException exception,
            OptionalType type = OptionalType.ReferenceType) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return value.Some(val => !predicate(val), exception, type);
        }

        /// <summary>
        /// To none
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="exceptionFactory"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IOptional<T, TException> None<T, TException>(this T value, Func<T, bool> predicate, Func<TException> exceptionFactory,
            OptionalType type = OptionalType.ReferenceType) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return value.Some(val => !predicate(val), exceptionFactory, type);
        }

        /// <summary>
        /// To none
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="exceptionFactory"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IOptional<T, TException> None<T, TException>(this T value, Func<T, bool> predicate, Func<T, TException> exceptionFactory,
            OptionalType type = OptionalType.ReferenceType) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return value.Some(val => !predicate(val), exceptionFactory, type);
        }

        #endregion

        #region To Optional

        /// <summary>
        /// To optional
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IOptional<T> ToOptional<T>(this T? value,
            OptionalType type = OptionalType.ReferenceType) where T : struct {
            return value.HasValue
                ? type == OptionalType.ReferenceType
                    ? Optional.Wrapped.Some(value.Value)
                    : Optional.Some(value.Value) as IOptional<T>
                : type == OptionalType.ReferenceType
                    ? Optional.Wrapped.None<T>()
                    : Optional.None<T>() as IOptional<T>;
        }

        /// <summary>
        /// To optional
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exception"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static IOptional<T, TException> ToOptional<T, TException>(this T? value, TException exception,
            OptionalType type = OptionalType.ReferenceType) where T : struct {
            return value.HasValue
                ? type == OptionalType.ReferenceType
                    ? Optional.Wrapped.Some<T, TException>(value.Value)
                    : Optional.Some<T, TException>(value.Value) as IOptional<T, TException>
                : type == OptionalType.ReferenceType
                    ? Optional.Wrapped.None<T, TException>(exception)
                    : Optional.None<T, TException>(exception) as IOptional<T, TException>;
        }

        /// <summary>
        /// To optional
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exceptionFactory"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IOptional<T, TException> ToOptional<T, TException>(this T? value, Func<TException> exceptionFactory,
            OptionalType type = OptionalType.ReferenceType) where T : struct {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return value.HasValue
                ? type == OptionalType.ReferenceType
                    ? Optional.Wrapped.Some<T, TException>(value.Value)
                    : Optional.Some<T, TException>(value.Value) as IOptional<T, TException>
                : type == OptionalType.ReferenceType
                    ? Optional.Wrapped.None<T, TException>(exceptionFactory())
                    : Optional.None<T, TException>(exceptionFactory()) as IOptional<T, TException>;
        }

        #endregion

        #region Value or exception

        /// <summary>
        /// Value or exception
        /// </summary>
        /// <param name="optional"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TImpl"></typeparam>
        /// <returns></returns>
        public static T ValueOrException<T, TImpl>(this Optional<T, T, TImpl> optional) {
            return optional.HasValue ? optional.Value : optional.Exception;
        }

        #endregion

        #region Value or throw

        /// <summary>
        /// Value or throw
        /// </summary>
        /// <param name="optional"></param>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static T ValueOrThrow<T, TException>(this IOptional<T> optional, TException exception)
            where TException : Exception {
            if (optional.HasValue)
                return optional.Value;
            throw exception;
        }

        /// <summary>
        /// Value or throw
        /// </summary>
        /// <param name="optional"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static T ValueOrThrow<T, TException>(this IOptional<T, TException> optional)
            where TException : Exception {
            if (optional.HasValue)
                return optional.Value;
            throw optional.Exception;
        }

        #endregion

        #region Flatten

        /// <summary>
        /// Flatten
        /// </summary>
        /// <param name="optional"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TImpl"></typeparam>
        /// <returns></returns>
        public static Maybe<T> Flatten<T, TImpl>(this IOptionalImpl<Maybe<T>, TImpl> optional) {
            return optional.FlatMap(innerOptional => innerOptional);
        }

        /// <summary>
        /// Flatten
        /// </summary>
        /// <param name="optional"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TImpl"></typeparam>
        /// <returns></returns>
        public static Either<T, TException> Flatten<T, TException, TImpl>(this IOptionalImpl<Either<T, TException>, TException, TImpl> optional) {
            return optional.FlatMap(innerOptional => innerOptional);
        }

        #endregion

        #region Is Optional Type

        /// <summary>
        /// Is optional type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsOptionalType(this Type type) {
            return !(type is null) && typeof(IOptional).IsAssignableFrom(type);

        }

        #endregion

    }
}