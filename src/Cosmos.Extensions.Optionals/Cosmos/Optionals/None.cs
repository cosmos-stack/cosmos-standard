namespace Cosmos.Optionals;

/// <summary>
/// None <br />
/// 无
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class None<T> : Optional<T, None<T>>, IEquatable<None<T>>, IComparable<None<T>>
{
    internal None() : base(default, false) { }

    #region Equals

    /// <inheritdoc />
    public override bool Equals(T other)
    {
        if (other is null)
            return true;
        return Internal.Equals(other);
    }

    /// <summary>
    /// Equals
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public override bool Equals(None<T> other)
    {
        if (other is null)
            return false;
        return Internal.Equals(other.Internal);
    }

    #endregion

    #region CompareTo

    /// <inheritdoc />
    public override int CompareTo(T other)
    {
        if (other is null)
            return 0;
        return Internal.CompareTo(other);
    }

    /// <summary>
    /// Compare to
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public override int CompareTo(None<T> other)
    {
        if (other is null)
            return 1;
        return Internal.CompareTo(other.Internal);
    }

    #endregion

    #region Explicit operator

    /// <summary>
    /// Convert maybe to none
    /// </summary>
    /// <param name="some"></param>
    /// <returns></returns>
    public static explicit operator None<T>(Some<T> some)
    {
        return Optional.Wrapped.None<T>();
    }

    /// <summary>
    /// Convert maybe to none
    /// </summary>
    /// <param name="maybe"></param>
    /// <returns></returns>
    public static explicit operator None<T>(Maybe<T> maybe)
    {
        return maybe.ToWrappedNone();
    }

    #endregion

    #region Or / Else

    /// <inheritdoc />
    public override None<T> Or(T alternative) => default;

    /// <inheritdoc />
    public override None<T> Or(Func<T> alternativeFactory) => this;

    /// <inheritdoc />
    public override None<T> Else(None<T> alternativeMaybe) => alternativeMaybe;

    /// <inheritdoc />
    public override None<T> Else(Func<None<T>> alternativeMaybeFactory) => this;

    #endregion

    #region Filter

    /// <inheritdoc />
    public override None<T> Filter(bool condition) => this;

    /// <inheritdoc />
    public override None<T> Filter(Func<T, bool> predicate) => this;

    #endregion

    #region Not null

    /// <inheritdoc />
    public override None<T> NotNull() => default;

    #endregion
}