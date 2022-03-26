namespace Cosmos.Optionals;

/// <summary>
/// Extensions for optional
/// </summary>
public static class OptionalsExtensions
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

    #region To Optional

    /// <summary>
    /// To optional
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IOptional<T> ToOptional<T>(this T? value,
        OptionalType type = OptionalType.ReferenceType) where T : struct
    {
        return value.HasValue
            ? type == OptionalType.ReferenceType
                ? Optional.Wrapped.Some(value.Value)
                : Optional.Some(value.Value)
            : type == OptionalType.ReferenceType
                ? Optional.Wrapped.None<T>()
                : Optional.None<T>();
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
        OptionalType type = OptionalType.ReferenceType) where T : struct
    {
        return value.HasValue
            ? type == OptionalType.ReferenceType
                ? Optional.Wrapped.Some<T, TException>(value.Value)
                : Optional.Some<T, TException>(value.Value)
            : type == OptionalType.ReferenceType
                ? Optional.Wrapped.None<T, TException>(exception)
                : Optional.None<T, TException>(exception);
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
        OptionalType type = OptionalType.ReferenceType) where T : struct
    {
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));
        return value.HasValue
            ? type == OptionalType.ReferenceType
                ? Optional.Wrapped.Some<T, TException>(value.Value)
                : Optional.Some<T, TException>(value.Value)
            : type == OptionalType.ReferenceType
                ? Optional.Wrapped.None<T, TException>(exceptionFactory())
                : Optional.None<T, TException>(exceptionFactory());
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

    #region Linq sync

    /// <summary>
    /// Select
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<TResult> Select<TSource, TResult>(this Maybe<TSource> source, Func<TSource, TResult> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));
        return source.Map(selector);
    }

    /// <summary>
    /// Select many
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<TResult> SelectMany<TSource, TResult>(this Maybe<TSource> source, Func<TSource, Maybe<TResult>> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));
        return source.FlatMap(selector);
    }

    /// <summary>
    /// Select many
    /// </summary>
    /// <param name="source"></param>
    /// <param name="collectionSelector"></param>
    /// <param name="resultSelector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCollection"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<TResult> SelectMany<TSource, TCollection, TResult>(
        this Maybe<TSource> source,
        Func<TSource, Maybe<TCollection>> collectionSelector,
        Func<TSource, TCollection, TResult> resultSelector)
    {
        if (collectionSelector is null)
            throw new ArgumentNullException(nameof(collectionSelector));
        if (resultSelector is null)
            throw new ArgumentNullException(nameof(resultSelector));
        return source.FlatMap(src => collectionSelector(src).Map(elem => resultSelector(src, elem)));
    }

    /// <summary>
    /// Where
    /// </summary>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<TSource> Where<TSource>(this Maybe<TSource> source, Func<TSource, bool> predicate)
    {
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        return source.Filter(predicate);
    }

    /// <summary>
    /// Select
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Either<TResult, TException> Select<TSource, TException, TResult>(this Either<TSource, TException> source, Func<TSource, TResult> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));
        return source.Map(selector);
    }

    /// <summary>
    /// Select many
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Either<TResult, TException> SelectMany<TSource, TException, TResult>(
        this Either<TSource, TException> source,
        Func<TSource, Either<TResult, TException>> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));
        return source.FlatMap(selector);
    }

    /// <summary>
    /// Select many
    /// </summary>
    /// <param name="source"></param>
    /// <param name="collectionSelector"></param>
    /// <param name="resultSelector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TCollection"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Either<TResult, TException> SelectMany<TSource, TException, TCollection, TResult>(
        this Either<TSource, TException> source,
        Func<TSource, Either<TCollection, TException>> collectionSelector,
        Func<TSource, TCollection, TResult> resultSelector)
    {
        if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
        if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));
        return source.FlatMap(src => collectionSelector(src).Map(elem => resultSelector(src, elem)));
    }

    #endregion

    #region Linq async

    /// <summary>
    /// Select
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<Maybe<TResult>> Select<TSource, TResult>(this Task<Maybe<TSource>> source, Func<TSource, TResult> selector)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (selector is null) throw new ArgumentNullException(nameof(selector));
        return source.MapAsync(selector);
    }

    /// <summary>
    /// Select many
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<Maybe<TResult>> SelectMany<TSource, TResult>(this Task<Maybe<TSource>> source, Func<TSource, Task<Maybe<TResult>>> selector)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (selector is null) throw new ArgumentNullException(nameof(selector));
        return source.FlatMapAsync(selector);
    }

    /// <summary>
    /// Select many
    /// </summary>
    /// <param name="source"></param>
    /// <param name="collectionSelector"></param>
    /// <param name="resultSelector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCollection"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<Maybe<TResult>> SelectMany<TSource, TCollection, TResult>(
        this Task<Maybe<TSource>> source,
        Func<TSource, Task<Maybe<TCollection>>> collectionSelector,
        Func<TSource, TCollection, TResult> resultSelector)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
        if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));
        return source.FlatMapAsync(src => collectionSelector(src).MapAsync(elem => resultSelector(src, elem)));
    }

    /// <summary>
    /// Where
    /// </summary>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<Maybe<TSource>> Where<TSource>(this Task<Maybe<TSource>> source, Func<TSource, bool> predicate)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));
        return source.FilterAsync(predicate);
    }

    /// <summary>
    /// Select
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<Either<TResult, TException>> Select<TSource, TException, TResult>(this Task<Either<TSource, TException>> source, Func<TSource, TResult> selector)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (selector is null) throw new ArgumentNullException(nameof(selector));
        return source.MapAsync(selector);
    }

    /// <summary>
    /// Select many
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<Either<TResult, TException>> SelectMany<TSource, TException, TResult>(
        this Task<Either<TSource, TException>> source,
        Func<TSource, Task<Either<TResult, TException>>> selector)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (selector is null) throw new ArgumentNullException(nameof(selector));
        return source.FlatMapAsync(selector);
    }

    /// <summary>
    /// Select many
    /// </summary>
    /// <param name="source"></param>
    /// <param name="collectionSelector"></param>
    /// <param name="resultSelector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TCollection"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<Either<TResult, TException>> SelectMany<TSource, TException, TCollection, TResult>(
        this Task<Either<TSource, TException>> source,
        Func<TSource, Task<Either<TCollection, TException>>> collectionSelector,
        Func<TSource, TCollection, TResult> resultSelector)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
        if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));
        return source.FlatMapAsync(src => collectionSelector(src).MapAsync(elem => resultSelector(src, elem)));
    }

    #endregion

    #region Collections sync

    /// <summary>
    /// Flattens a sequence of maybe into a sequence containing all inner values.
    /// Empty elements are discarded.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<T> MapValues<T>(this IEnumerable<Maybe<T>> source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        foreach (var maybe in source)
            if (maybe.HasValue)
                yield return maybe.Value;
    }

    /// <summary>
    /// Flattens a sequence of either into a sequence containing all inner values.
    /// Empty elements and their exceptional values are discarded.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<T> MapValues<T, TException>(this IEnumerable<Either<T, TException>> source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        foreach (var either in source)
            if (either.HasValue)
                yield return either.Value;
    }

    /// <summary>
    /// Flattens a sequence of optionals into a sequence containing all exceptional values.
    /// Non-empty elements and their values are discarded.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<TException> MapExceptions<T, TException>(this IEnumerable<Either<T, TException>> source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        foreach (var either in source)
            if (!either.HasValue)
                yield return either.Exception;
    }

    /// <summary>
    /// Returns the value associated with the specified key if such exists.
    /// A dictionary lookup will be used if available, otherwise falling
    /// back to a linear scan of the enumerable.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="key"></param>
    /// <param name="type"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IOptional<T> FindOrNone<TKey, T>(this IEnumerable<KeyValuePair<TKey, T>> source, TKey key, OptionalType type = OptionalType.ReferenceType)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (source is IDictionary<TKey, T> dictionary)
            return dictionary.TryGetValue(key, out var value) ? value.Some(type) : value.None(type);
        if (source is IReadOnlyDictionary<TKey, T> readOnlyDictionary)
            return readOnlyDictionary.TryGetValue(key, out var value) ? value.Some(type) : value.None(type);
        return source
               .FirstOrNone(pair => EqualityComparer<TKey>.Default.Equals(pair.Key, key))
               .Map(pair => pair.Value);
    }

    /// <summary>
    /// Returns the first element of a sequence if such exists.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> FirstOrNone<T>(this IEnumerable<T> source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (source is IList<T> list)
        {
            if (list.Count > 0)
                return list[0].AsOptionals();
        }
        else if (source is IReadOnlyList<T> readOnlyList)
        {
            if (readOnlyList.Count > 0)
                return readOnlyList[0].AsOptionals();
        }
        else
        {
            using var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
                return enumerator.Current.AsOptionals();
        }

        return Optional.None<T>();
    }

    /// <summary>
    /// Returns the first element of a sequence, satisfying a specified predicate,
    /// if such exists.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> FirstOrNone<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        foreach (var element in source)
        {
            if (predicate(element))
                return element.AsOptionals();
        }

        return Optional.None<T>();
    }

    /// <summary>
    /// Returns the last element of a sequence if such exists.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> LastOrNone<T>(this IEnumerable<T> source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (source is IList<T> list)
        {
            var count = list.Count;
            if (count > 0)
                return list[count].AsOptionals();
        }
        else if (source is IReadOnlyList<T> readOnlyList)
        {
            var count = readOnlyList.Count;
            if (count > 0)
                return readOnlyList[count].AsOptionals();
        }
        else
        {
            using var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                T t;
                do
                {
                    t = enumerator.Current;
                } while (enumerator.MoveNext());

                return t.AsOptionals();
            }
        }

        return Optional.None<T>();
    }

    /// <summary>
    /// Returns the last element of a sequence, satisfying a specified predicate,
    /// if such exists.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> LastOrNone<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        if (source is IList<T> list)
        {
            for (var i = list.Count - 1; i >= 0; --i)
            {
                var result = list[i];
                if (predicate(result))
                    return result.AsOptionals();
            }
        }
        else if (source is IReadOnlyList<T> readOnlyList)
        {
            for (var i = readOnlyList.Count - 1; i >= 0; --i)
            {
                var result = readOnlyList[i];
                if (predicate(result))
                    return result.AsOptionals();
            }
        }
        else
        {
            using var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var result = enumerator.Current;
                if (predicate(result))
                {
                    while (enumerator.MoveNext())
                    {
                        var element = enumerator.Current;
                        if (predicate(element))
                        {
                            result = element;
                        }
                    }

                    return result.AsOptionals();
                }
            }
        }

        return Optional.None<T>();
    }

    /// <summary>
    /// Returns a single element from a sequence, if it exists
    /// and is the only element in the sequence.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> SingleOrNone<T>(this IEnumerable<T> source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (source is IList<T> list)
        {
            switch (list.Count)
            {
                case 0: return Optional.None<T>();
                case 1: return list[0].AsOptionals();
            }
        }
        else if (source is IReadOnlyList<T> readOnlyList)
        {
            switch (readOnlyList.Count)
            {
                case 0: return Optional.None<T>();
                case 1: return readOnlyList[0].AsOptionals();
            }
        }
        else
        {
            using var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
                return Optional.None<T>();
            var result = enumerator.Current;
            if (!enumerator.MoveNext())
                return result.AsOptionals();
        }

        return Optional.None<T>();
    }

    /// <summary>
    /// Returns a single element from a sequence, satisfying a specified predicate,
    /// if it exists and is the only element in the sequence.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> SingleOrNone<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                var result = enumerator.Current;
                if (predicate(result))
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                            return Optional.None<T>();
                    }

                    return result.AsOptionals();
                }
            }
        }

        return Optional.None<T>();
    }

    /// <summary>
    /// Returns an element at a specified position in a sequence if such exists.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="index"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> ElementAtOrNone<T>(this IEnumerable<T> source, int index)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (index >= 0)
        {
            if (source is IList<T> list)
            {
                if (index < list.Count)
                {
                    return list[index].AsOptionals();
                }
            }
            else if (source is IReadOnlyList<T> readOnlyList)
            {
                if (index < readOnlyList.Count)
                {
                    return readOnlyList[index].AsOptionals();
                }
            }
            else
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (index == 0)
                    {
                        return enumerator.Current.AsOptionals();
                    }

                    index--;
                }
            }
        }

        return Optional.None<T>();
    }

    #endregion

    #region Collections Maybe async

    /// <summary>
    /// May async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="mapping"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static Task<Maybe<TResult>> MapAsync<T, TResult>(this Maybe<T> option, Func<T, Task<TResult>> mapping)
    {
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        return option.Map(mapping).Match(
            someFactory: async valueTask =>
            {
                if (valueTask is null) throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                var value = await valueTask.ConfigureAwait(continueOnCapturedContext: false);
                return value.AsOptionals();
            },
            noneFactory: () => Task.FromResult(Optional.None<TResult>())
        );
    }

    /// <summary>
    /// Map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<TResult>> MapAsync<T, TResult>(this Task<Maybe<T>> optionTask, Func<T, TResult> mapping, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.Map(mapping);
    }

    /// <summary>
    /// Map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<TResult>> MapAsync<T, TResult>(this Task<Maybe<T>> optionTask, Func<T, Task<TResult>> mapping, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.MapAsync(mapping).ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="mapping"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static Task<Maybe<TResult>> FlatMapAsync<T, TResult>(this Maybe<T> option, Func<T, Task<Maybe<TResult>>> mapping)
    {
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        return option.Map(mapping).Match(
            someFactory: resultOptionTask =>
            {
                if (resultOptionTask is null) throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                return resultOptionTask;
            },
            noneFactory: () => Task.FromResult(Optional.None<TResult>())
        );
    }

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<TResult>> FlatMapAsync<T, TResult>(this Task<Maybe<T>> optionTask, Func<T, Maybe<TResult>> mapping, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.FlatMap(mapping);
    }

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<TResult>> FlatMapAsync<T, TResult>(this Task<Maybe<T>> optionTask, Func<T, Task<Maybe<TResult>>> mapping,
        bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.FlatMapAsync(mapping).ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="mapping"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<Maybe<TResult>> FlatMapAsync<T, TResult, TException>(this Maybe<T> option, Func<T, Task<Either<TResult, TException>>> mapping)
    {
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        return option.FlatMapAsync(async value =>
        {
            var resultOptionTask = mapping(value) ?? throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
            var resultOption = await (resultOptionTask).ConfigureAwait(false);
            return resultOption.WithoutException();
        });
    }

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<TResult>> FlatMapAsync<T, TResult, TException>(this Task<Maybe<T>> optionTask, Func<T, Either<TResult, TException>> mapping,
        bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.FlatMap(mapping);
    }

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<TResult>> FlatMapAsync<T, TResult, TException>(this Task<Maybe<T>> optionTask, Func<T, Task<Either<TResult, TException>>> mapping,
        bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.FlatMapAsync(mapping).ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Filter async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static Task<Maybe<T>> FilterAsync<T>(this Maybe<T> option, Func<T, Task<bool>> predicate)
    {
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        return option.Match(
            someFactory: async value =>
            {
                var predicateTask = predicate(value);
                if (predicateTask is null) throw new InvalidOperationException($"{nameof(predicate)} must not return a null task.");

                var condition = await predicateTask.ConfigureAwait(continueOnCapturedContext: false);
                return option.Filter(condition);
            },
            noneFactory: () => Task.FromResult(option)
        );
    }

    /// <summary>
    /// Filter async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="predicate"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<T>> FilterAsync<T>(this Task<Maybe<T>> optionTask, Func<T, bool> predicate, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.Filter(predicate);
    }

    /// <summary>
    /// Filter async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="predicate"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<T>> FilterAsync<T>(this Task<Maybe<T>> optionTask, Func<T, Task<bool>> predicate, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.FilterAsync(predicate).ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Not null async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<Maybe<T>> NotNullAsync<T>(this Task<Maybe<T>> optionTask)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        return optionTask.FilterAsync(value => value != null);
    }

    /// <summary>
    /// Or async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="alternativeFactory"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static async Task<Maybe<T>> OrAsync<T>(this Maybe<T> option, Func<Task<T>> alternativeFactory)
    {
        if (alternativeFactory is null)
            throw new ArgumentNullException(nameof(alternativeFactory));

        if (option.HasValue) return option;

        var alternativeTask = alternativeFactory();
        if (alternativeTask is null)
            throw new InvalidOperationException($"{nameof(alternativeFactory)} must not return a null task.");

        var alternative = await alternativeTask.ConfigureAwait(continueOnCapturedContext: false);
        return alternative.AsOptionals();
    }

    /// <summary>
    /// Or async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="alternativeFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<T>> OrAsync<T>(this Task<Maybe<T>> optionTask, Func<T> alternativeFactory, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (alternativeFactory is null)
            throw new ArgumentNullException(nameof(alternativeFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.Or(alternativeFactory);
    }

    /// <summary>
    /// Or async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="alternativeFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<T>> OrAsync<T>(this Task<Maybe<T>> optionTask, Func<Task<T>> alternativeFactory, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (alternativeFactory is null)
            throw new ArgumentNullException(nameof(alternativeFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.OrAsync(alternativeFactory).ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Else async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="alternativeOptionFactory"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static async Task<Maybe<T>> ElseAsync<T>(this Maybe<T> option, Func<Task<Maybe<T>>> alternativeOptionFactory)
    {
        if (alternativeOptionFactory is null)
            throw new ArgumentNullException(nameof(alternativeOptionFactory));

        if (option.HasValue) return option;

        var alternativeOptionTask = alternativeOptionFactory();
        if (alternativeOptionTask is null)
            throw new InvalidOperationException($"{nameof(alternativeOptionFactory)} must not return a null task.");

        return await alternativeOptionTask.ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Else async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="alternativeOptionFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<T>> ElseAsync<T>(this Task<Maybe<T>> optionTask, Func<Maybe<T>> alternativeOptionFactory, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (alternativeOptionFactory is null)
            throw new ArgumentNullException(nameof(alternativeOptionFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.Else(alternativeOptionFactory);
    }

    /// <summary>
    /// Else async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="alternativeOptionFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<T>> ElseAsync<T>(this Task<Maybe<T>> optionTask, Func<Task<Maybe<T>>> alternativeOptionFactory, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (alternativeOptionFactory is null)
            throw new ArgumentNullException(nameof(alternativeOptionFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.ElseAsync(alternativeOptionFactory).ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// With exception async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="exception"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    public static Task<Either<T, TException>> WithExceptionAsync<T, TException>(this Task<Maybe<T>> optionTask, TException exception) =>
        optionTask.WithExceptionAsync(() => exception);

    /// <summary>
    /// With exception async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="exceptionFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<T, TException>> WithExceptionAsync<T, TException>(this Task<Maybe<T>> optionTask, Func<TException> exceptionFactory,
        bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.WithException(exceptionFactory());
    }

    /// <summary>
    /// Flatten async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<T>> FlattenAsync<T>(this Task<Maybe<Maybe<T>>> optionTask)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));

        var option = await optionTask.ConfigureAwait(continueOnCapturedContext: false);
        return option.Flatten();
    }

    #endregion

    #region Collections either async

    /// <summary>
    /// Map async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="mapping"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static Task<Either<TResult, TException>> MapAsync<T, TException, TResult>(this Either<T, TException> option, Func<T, Task<TResult>> mapping)
    {
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));

        return option.Map(mapping).Match(
            someFactory: async valueTask =>
            {
                if (valueTask is null)
                    throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                var value = await valueTask.ConfigureAwait(continueOnCapturedContext: false);
                return value.AsOptionals<TResult, TException>();
            },
            noneFactory: exception => Task.FromResult(Optional.None<TResult, TException>(exception))
        );
    }

    /// <summary>
    /// Map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<TResult, TException>> MapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask, Func<T, TResult> mapping,
        bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.Map(mapping);
    }

    /// <summary>
    /// Map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<TResult, TException>> MapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask, Func<T, Task<TResult>> mapping,
        bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.MapAsync(mapping).ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Map exception async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="mapping"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TExceptionResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Task<Either<T, TExceptionResult>> MapExceptionAsync<T, TException, TExceptionResult>(this Either<T, TException> option,
        Func<TException, Task<TExceptionResult>> mapping)
    {
        return option.MapException(mapping).Match(
            someFactory: value => Task.FromResult(Optional.Some<T, TExceptionResult>(value)),
            noneFactory: async exceptionTask =>
            {
                if (exceptionTask is null)
                    throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                var exception = await exceptionTask.ConfigureAwait(continueOnCapturedContext: false);
                return Optional.None<T, TExceptionResult>(exception);
            }
        );
    }

    /// <summary>
    /// Map exception async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TExceptionResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<T, TExceptionResult>> MapExceptionAsync<T, TException, TExceptionResult>(this Task<Either<T, TException>> optionTask,
        Func<TException, TExceptionResult> mapping, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.MapException(mapping);
    }

    /// <summary>
    /// Map exception async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TExceptionResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<T, TExceptionResult>> MapExceptionAsync<T, TException, TExceptionResult>(this Task<Either<T, TException>> optionTask,
        Func<TException, Task<TExceptionResult>> mapping, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.MapExceptionAsync(mapping).ConfigureAwait(false);
    }

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="mapping"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(
        this Either<T, TException> option, Func<T, Task<Either<TResult, TException>>> mapping)
    {
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));

        return option.Map(mapping).Match(
            someFactory: resultOptionTask =>
            {
                if (resultOptionTask is null)
                    throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                return resultOptionTask;
            },
            noneFactory: exception => Task.FromResult(Optional.None<TResult, TException>(exception))
        );
    }

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask,
        Func<T, Either<TResult, TException>> mapping, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.FlatMap(mapping);
    }

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask,
        Func<T, Task<Either<TResult, TException>>> mapping, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.FlatMapAsync(mapping).ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="mapping"></param>
    /// <param name="exception"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Either<T, TException> option, Func<T, Task<Maybe<TResult>>> mapping,
        TException exception) =>
        option.FlatMapAsync(mapping, () => exception);

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="mapping"></param>
    /// <param name="exceptionFactory"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Either<T, TException> option, Func<T, Task<Maybe<TResult>>> mapping,
        Func<TException> exceptionFactory)
    {
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));

        return option.FlatMapAsync(async value =>
        {
            var resultOptionTask = mapping(value) ?? throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
            var resultOption = await (resultOptionTask).ConfigureAwait(false);
            return resultOption.WithException(exceptionFactory());
        });
    }

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="exception"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask, Func<T, Maybe<TResult>> mapping,
        TException exception, bool executeOnCapturedContext = false) =>
        optionTask.FlatMapAsync(mapping, () => exception, executeOnCapturedContext);

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="exceptionFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask, Func<T, Maybe<TResult>> mapping,
        Func<TException> exceptionFactory, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.FlatMap(mapping, exceptionFactory);
    }

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="exception"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask, Func<T, Task<Maybe<TResult>>> mapping,
        TException exception, bool executeOnCapturedContext = false) =>
        optionTask.FlatMapAsync(mapping, () => exception, executeOnCapturedContext);

    /// <summary>
    /// Flat map async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="mapping"></param>
    /// <param name="exceptionFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask,
        Func<T, Task<Maybe<TResult>>> mapping, Func<TException> exceptionFactory, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.FlatMapAsync(mapping, exceptionFactory).ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Filter async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    public static Task<Either<T, TException>> FilterAsync<T, TException>(this Either<T, TException> option, Func<T, Task<bool>> predicate, TException exception) =>
        option.FilterAsync(predicate, () => exception);

    /// <summary>
    /// Filter async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptionFactory"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static Task<Either<T, TException>> FilterAsync<T, TException>(this Either<T, TException> option, Func<T, Task<bool>> predicate, Func<TException> exceptionFactory)
    {
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));

        return option.Match(
            someFactory: async value =>
            {
                var predicateTask = predicate(value);
                if (predicateTask is null)
                    throw new InvalidOperationException($"{nameof(predicate)} must not return a null task.");

                var condition = await predicateTask.ConfigureAwait(continueOnCapturedContext: false);
                return option.Filter(condition, exceptionFactory);
            },
            noneFactory: _ => Task.FromResult(option)
        );
    }

    /// <summary>
    /// filter  async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    public static Task<Either<T, TException>> FilterAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<T, bool> predicate, TException exception,
        bool executeOnCapturedContext = false) =>
        optionTask.FilterAsync(predicate, () => exception, executeOnCapturedContext);

    /// <summary>
    /// Filter async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptionFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<T, TException>> FilterAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<T, bool> predicate,
        Func<TException> exceptionFactory, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.Filter(predicate, exceptionFactory);
    }

    /// <summary>
    /// Filter async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    public static Task<Either<T, TException>> FilterAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<T, Task<bool>> predicate, TException exception,
        bool executeOnCapturedContext = false) =>
        optionTask.FilterAsync(predicate, () => exception, executeOnCapturedContext);

    /// <summary>
    /// Filter async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptionFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<T, TException>> FilterAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<T, Task<bool>> predicate,
        Func<TException> exceptionFactory, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.FilterAsync(predicate, exceptionFactory).ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Not null async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="exception"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    public static Task<Either<T, TException>> NotNullAsync<T, TException>(this Task<Either<T, TException>> optionTask, TException exception) =>
        optionTask.NotNullAsync(() => exception);

    /// <summary>
    /// Not null async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="exceptionFactory"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<Either<T, TException>> NotNullAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<TException> exceptionFactory)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));
        return optionTask.FilterAsync(value => value != null, exceptionFactory);
    }

    /// <summary>
    /// Or async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="alternativeFactory"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static async Task<Either<T, TException>> OrAsync<T, TException>(this Either<T, TException> option, Func<Task<T>> alternativeFactory)
    {
        if (alternativeFactory is null)
            throw new ArgumentNullException(nameof(alternativeFactory));

        if (option.HasValue) return option;

        var alternativeTask = alternativeFactory();
        if (alternativeTask is null)
            throw new InvalidOperationException($"{nameof(alternativeFactory)} must not return a null task.");

        var alternative = await alternativeTask.ConfigureAwait(continueOnCapturedContext: false);
        return alternative.AsOptionals<T, TException>();
    }

    /// <summary>
    /// Or async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="alternativeFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<T, TException>> OrAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<T> alternativeFactory,
        bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (alternativeFactory is null)
            throw new ArgumentNullException(nameof(alternativeFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.Or(alternativeFactory);
    }

    /// <summary>
    /// Or async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="alternativeFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<T, TException>> OrAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<Task<T>> alternativeFactory,
        bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (alternativeFactory is null)
            throw new ArgumentNullException(nameof(alternativeFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.OrAsync(alternativeFactory).ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Else async
    /// </summary>
    /// <param name="option"></param>
    /// <param name="alternativeOptionFactory"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static async Task<Either<T, TException>> ElseAsync<T, TException>(this Either<T, TException> option, Func<Task<Either<T, TException>>> alternativeOptionFactory)
    {
        if (alternativeOptionFactory is null)
            throw new ArgumentNullException(nameof(alternativeOptionFactory));

        if (option.HasValue) return option;

        var alternativeOptionTask = alternativeOptionFactory();
        if (alternativeOptionTask is null)
            throw new InvalidOperationException($"{nameof(alternativeOptionFactory)} must not return a null task.");

        return await alternativeOptionTask.ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Else async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="alternativeOptionFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<T, TException>> ElseAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<Either<T, TException>> alternativeOptionFactory,
        bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (alternativeOptionFactory is null)
            throw new ArgumentNullException(nameof(alternativeOptionFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.Else(alternativeOptionFactory);
    }

    /// <summary>
    /// Else async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <param name="alternativeOptionFactory"></param>
    /// <param name="executeOnCapturedContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<T, TException>> ElseAsync<T, TException>(this Task<Either<T, TException>> optionTask,
        Func<Task<Either<T, TException>>> alternativeOptionFactory, bool executeOnCapturedContext = false)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));
        if (alternativeOptionFactory is null)
            throw new ArgumentNullException(nameof(alternativeOptionFactory));

        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return await option.ElseAsync(alternativeOptionFactory).ConfigureAwait(continueOnCapturedContext: false);
    }

    /// <summary>
    /// Without exception async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<T>> WithoutExceptionAsync<T, TException>(this Task<Either<T, TException>> optionTask)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));

        var option = await optionTask.ConfigureAwait(false);
        return option.WithoutException();
    }

    /// <summary>
    /// Flatten async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Either<T, TException>> FlattenAsync<T, TException>(this Task<Either<Either<T, TException>, TException>> optionTask)
    {
        if (optionTask is null)
            throw new ArgumentNullException(nameof(optionTask));

        var option = await optionTask.ConfigureAwait(continueOnCapturedContext: false);
        return option.Flatten();
    }

    #endregion
}