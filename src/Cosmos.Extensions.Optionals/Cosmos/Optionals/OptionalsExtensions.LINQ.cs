namespace Cosmos.Optionals;

/// <summary>
/// Extensions for optional
/// </summary>
public static partial class OptionalsExtensions
{
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
        ArgumentNullException.ThrowIfNull(selector);
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
        ArgumentNullException.ThrowIfNull(selector);
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
        ArgumentNullException.ThrowIfNull(collectionSelector);
        ArgumentNullException.ThrowIfNull(resultSelector);
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
        ArgumentNullException.ThrowIfNull(predicate);
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
        ArgumentNullException.ThrowIfNull(selector);
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
        ArgumentNullException.ThrowIfNull(selector);
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
        ArgumentNullException.ThrowIfNull(collectionSelector);
        ArgumentNullException.ThrowIfNull(resultSelector);
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
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);
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
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);
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
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(collectionSelector);
        ArgumentNullException.ThrowIfNull(resultSelector);
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
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
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
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);
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
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);
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
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(collectionSelector);
        ArgumentNullException.ThrowIfNull(resultSelector);
        return source.FlatMapAsync(src => collectionSelector(src).MapAsync(elem => resultSelector(src, elem)));
    }

    #endregion
}