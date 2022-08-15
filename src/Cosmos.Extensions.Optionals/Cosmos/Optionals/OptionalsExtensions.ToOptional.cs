namespace Cosmos.Optionals;

/// <summary>
/// Extensions for optional
/// </summary>
public static partial class OptionalsExtensions
{
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
}