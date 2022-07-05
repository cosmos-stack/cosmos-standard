namespace Cosmos.Optionals;

/// <summary>
/// Base optional for Some and None. <br />
/// MayBe 组件 Some 和 None 的基类
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TException"></typeparam>
/// <typeparam name="TImpl"></typeparam>
public abstract class Optional<T, TException, TImpl> : IOptionalImpl<T, TException, TImpl>
{
    /// <summary>
    /// Internal Either instance
    /// </summary>
    protected readonly Either<T, TException> Either;

    internal Either<T, TException> InternalPointer => Either;

    /// <summary>
    /// Create a new instance of <see cref="Optional{T,TImpl}"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="exception"></param>
    /// <param name="hasValue"></param>
    protected Optional(T value, TException exception, bool hasValue)
    {
        Either = new Either<T, TException>(value, exception, hasValue);
    }

    /// <summary>
    /// Create a new instance of <see cref="Optional{T, TImpl}"/>.
    /// </summary>
    /// <param name="either"></param>
    protected Optional(Either<T, TException> either)
    {
        Either = either;
    }

    /// <inheritdoc />
    public virtual bool HasValue => Either.HasValue;

#if NETFRAMEWORK
    public bool HasNoValue => !HasValue;
#endif

    /// <inheritdoc />
    public virtual T Value => Either.Value;

    /// <inheritdoc />
    public string Key => Either.Key;

    /// <inheritdoc />
    public virtual Type UnderlyingType => Either.UnderlyingType;

    /// <inheritdoc />
    public TException Exception => Either.Exception;

    /// <inheritdoc />
    public virtual Type UnderlyingExceptionType => Either.UnderlyingExceptionType;

    /// <inheritdoc />
    public bool Contains(T value) => Either.Contains(value);

    /// <inheritdoc />
    public bool Exists(Func<T, bool> predicate) => Either.Exists(predicate);

    /// <inheritdoc />
    public T ValueOr(T alternative) => Either.ValueOr(alternative);

    /// <inheritdoc />
    public T ValueOr(Func<T> alternativeFactory) => Either.ValueOr(alternativeFactory);

    /// <inheritdoc />
    public T ValueOr(Func<TException, T> alternativeFactory) => Either.ValueOr(alternativeFactory);

    /// <inheritdoc />
    public abstract bool Equals(T other);

    /// <summary>
    /// Equals
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public abstract bool Equals(TImpl other);

    /// <inheritdoc />
    public abstract int CompareTo(T other);

    /// <summary>
    /// Compare to
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public abstract int CompareTo(TImpl other);

    /// <inheritdoc />
    public abstract TImpl Or(T alternative);

    /// <inheritdoc />
    public abstract TImpl Or(Func<T> alternativeFactory);

    /// <inheritdoc />
    public abstract TImpl Or(Func<TException, T> alternativeFactory);

    /// <inheritdoc />
    public abstract TImpl Else(TImpl alternativeOption);

    /// <inheritdoc />
    public abstract TImpl Else(Func<TImpl> alternativeOptionFactory);

    /// <inheritdoc />
    public abstract TImpl Else(Func<TException, TImpl> alternativeOptionFactory);

    /// <inheritdoc />
    public Maybe<T> WithoutException() => Either.WithoutException();

    /// <inheritdoc />
    public TResult Match<TResult>(Func<T, TResult> someFactory, Func<TException, TResult> noneFactory) => Either.Match(someFactory, noneFactory);

    /// <inheritdoc />
    public void Match(Action<T> someAct, Action<TException> noneAct) => Either.Match(someAct, noneAct);

    /// <inheritdoc />
    public void MatchSome(Action<T> someAct) => Either.MatchSome(someAct);

    /// <inheritdoc />
    public void MatchNone(Action<TException> noneAct) => Either.MatchNone(noneAct);

    /// <inheritdoc />
    public Either<TResult, TException> Map<TResult>(Func<T, TResult> mapping) => Either.Map(mapping);

    /// <inheritdoc />
    public Either<T, TExceptionResult> MapException<TExceptionResult>(Func<TException, TExceptionResult> mapping) => Either.MapException(mapping);

    /// <inheritdoc />
    public Either<TResult, TException> FlatMap<TResult>(Func<T, Either<TResult, TException>> mapping) => Either.FlatMap(mapping);

    /// <inheritdoc />
    public Either<TResult, TException> FlatMap<TResult>(Func<T, Maybe<TResult>> mapping, TException exception) => Either.FlatMap(mapping, exception);

    /// <inheritdoc />
    public Either<TResult, TException> FlatMap<TResult>(Func<T, Maybe<TResult>> mapping, Func<TException> exceptionFactory) => Either.FlatMap(mapping, exceptionFactory);

    /// <inheritdoc />
    public abstract TImpl Filter(bool condition, TException exception);

    /// <inheritdoc />
    public abstract TImpl Filter(bool condition, Func<TException> exceptionFactory);

    /// <inheritdoc />
    public abstract TImpl Filter(Func<T, bool> predicate, TException exception);

    /// <inheritdoc />
    public abstract TImpl Filter(Func<T, bool> predicate, Func<TException> exceptionFactory);

    /// <inheritdoc />
    public abstract TImpl NotNull(TException exception);

    /// <inheritdoc />
    public abstract TImpl NotNull(Func<TException> exceptionFactory);
}