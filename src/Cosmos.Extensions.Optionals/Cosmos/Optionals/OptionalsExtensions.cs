namespace Cosmos.Optionals;

/// <summary>
/// Extensions for optional
/// </summary>
public static partial class OptionalsExtensions
{
    #region Maybe

    /// <summary>
    /// Maybe
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<T> AsOptionals<T>(this T value) => Optional.Some(value);

    /// <summary>
    /// Maybe
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Either<T, TException> AsOptionals<T, TException>(this T value) => Optional.Some<T, TException>(value);

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
        OptionalType type = OptionalType.ReferenceType)
    {
        return type == OptionalType.ReferenceType
            ? Optional.Wrapped.Some(value)
            : Optional.Some(value);
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
        OptionalType type = OptionalType.ReferenceType)
    {
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
        OptionalType type = OptionalType.ReferenceType)
    {
        return type != OptionalType.ReferenceType
            ? Optional.Some<T, TException>(value)
            : Optional.Wrapped.Some<T, TException>(value);
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
        OptionalType type = OptionalType.ReferenceType)
    {
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
        OptionalType type = OptionalType.ReferenceType)
    {
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
        OptionalType type = OptionalType.ReferenceType)
    {
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
        OptionalType type = OptionalType.ReferenceType)
    {
        return value.Some(val => val is not null, type);
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
        OptionalType type = OptionalType.ReferenceType)
    {
        return value.Some(val => val is not null, exception, type);
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
        OptionalType type = OptionalType.ReferenceType)
    {
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));
        return value.Some(val => val is not null, exceptionFactory, type);
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
        OptionalType type = OptionalType.ReferenceType)
    {
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));
        return value.Some(val => val is not null, exceptionFactory, type);
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
        OptionalType type = OptionalType.ReferenceType)
    {
        return type == OptionalType.ReferenceType
            ? Optional.Wrapped.None<T>()
            : Optional.None<T>();
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
        OptionalType type = OptionalType.ReferenceType)
    {
        return type != OptionalType.ReferenceType
            ? Optional.None<T, TException>(exception)
            : Optional.Wrapped.None<T, TException>(exception);
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
        OptionalType type = OptionalType.ReferenceType)
    {
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
        OptionalType type = OptionalType.ReferenceType)
    {
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
        OptionalType type = OptionalType.ReferenceType)
    {
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
        OptionalType type = OptionalType.ReferenceType)
    {
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));
        return value.Some(val => !predicate(val), exceptionFactory, type);
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
    public static T ValueOrException<T, TImpl>(this Optional<T, T, TImpl> optional) =>
        optional.HasValue ? optional.Value : optional.Exception;

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
        where TException : Exception
    {
        if (optional.HasValue)
            return optional.Value;
        throw exception ?? throw new OptionalValueMissingException();
    }

    /// <summary>
    /// Value or throw
    /// </summary>
    /// <param name="optional"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    public static T ValueOrThrow<T, TException>(this IOptional<T, TException> optional)
        where TException : Exception
    {
        if (optional.HasValue)
            return optional.Value;
        throw optional.Exception ?? throw new OptionalValueMissingException();
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
    public static Maybe<T> Flatten<T, TImpl>(this IOptionalImpl<Maybe<T>, TImpl> optional) =>
        optional.FlatMap(innerOptional => innerOptional);

    /// <summary>
    /// Flatten
    /// </summary>
    /// <param name="optional"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TImpl"></typeparam>
    /// <returns></returns>
    public static Either<T, TException> Flatten<T, TException, TImpl>(this IOptionalImpl<Either<T, TException>, TException, TImpl> optional) =>
        optional.FlatMap(innerOptional => innerOptional);

    #endregion

    #region Is Optional Type

    /// <summary>
    /// Is optional type
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsOptionalType(this Type type)
    {
        return !(type is null) && typeof(IOptional).IsAssignableFrom(type);
    }

    #endregion

    #region Unsafe Optional value

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
    public static T ValueOrFailure<T>(this Maybe<T> option) =>
        option.HasValue ? option.Value : throw new OptionalValueMissingException();

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
    public static T ValueOrFailure<T, TException>(this Either<T, TException> option) =>
        option.HasValue ? option.Value : throw new OptionalValueMissingException();

    /// <summary>
    /// Return the value of the given <see cref="Maybe{T}"/>, if null then raise an <see cref="OptionalValueMissingException"/> with the given error message.<br />
    /// 返回给定 <see cref="Maybe{T}"/> 的值，如果不存在该值则抛出一个使用给定异常信息的 <see cref="OptionalValueMissingException"/> 异常。
    /// </summary>
    /// <param name="option"></param>
    /// <param name="errorMessage"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="OptionalValueMissingException"></exception>
    public static T ValueOrFailure<T>(this Maybe<T> option, string errorMessage) =>
        option.HasValue ? option.Value : throw new OptionalValueMissingException(errorMessage);

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
    public static T ValueOrFailure<T>(this Maybe<T> option, Func<string> errorMessageFactory)
    {
        if (errorMessageFactory is null)
            throw new ArgumentNullException(nameof(errorMessageFactory));
        return option.HasValue ? option.Value : throw new OptionalValueMissingException(errorMessageFactory());
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
    public static T ValueOrFailure<T, TException>(this Either<T, TException> option, string errorMessage) =>
        option.HasValue ? option.Value : throw new OptionalValueMissingException(errorMessage);

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
    public static T ValueOrFailure<T, TException>(this Either<T, TException> option, Func<TException, string> errorMessageFactory)
    {
        if (errorMessageFactory is null)
            throw new ArgumentNullException(nameof(errorMessageFactory));
        return option.HasValue ? option.Value : throw new OptionalValueMissingException(errorMessageFactory(option.Exception));
    }

    #endregion

    #region String None

    /// <summary>
    /// None if empty
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Maybe<string> NoneIfEmpty(this string str) =>
        string.IsNullOrEmpty(str)
            ? Optional.None<string>()
            : Optional.Some(str);

    /// <summary>
    /// None if whitespace
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Maybe<string> NoneIfWhitespace(this string str) =>
        string.IsNullOrWhiteSpace(str)
            ? Optional.None<string>()
            : Optional.Some(str);

    #endregion

    #region Try parse string to Enum

    /// <summary>
    /// Try parse
    /// </summary>
    /// <param name="value"></param>
    /// <param name="ignoreCase"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    public static Maybe<TEnum> TryParse<TEnum>(this string value, bool ignoreCase = false) where TEnum : struct =>
        Enum.TryParse(value, ignoreCase, out TEnum outValue) ? Optional.Some(outValue) : Optional.None<TEnum>();

    #endregion
}