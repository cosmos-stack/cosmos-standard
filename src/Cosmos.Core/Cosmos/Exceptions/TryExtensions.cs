namespace Cosmos.Exceptions;

/*
 * TryEx / LINQ extensions
 */

/// <summary>
/// Try extensions. <br />
/// Try 组件扩展
/// </summary>
public static partial class TryExtensions
{
    /// <summary>
    /// Select <br />
    /// 选择
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Try<TResult> Select<TSource, TResult>(this Try<TSource> source, Func<TSource, TResult> selector)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);
        return source.Bind(val => Try.LiftValue(selector(val)));
    }

    /// <summary>
    /// Select many <br />
    /// 选择
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Try<TResult> SelectMany<TSource, TResult>(this Try<TSource> source, Func<TSource, Try<TResult>> selector)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);
        return source.Bind(selector);
    }

    /// <summary>
    /// Select many <br />
    /// 选择
    /// </summary>
    /// <param name="source"></param>
    /// <param name="convert"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TIntermediate"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Try<TResult> SelectMany<TSource, TIntermediate, TResult>(this Try<TSource> source,
        Func<TSource, Try<TIntermediate>> convert, Func<TSource, TIntermediate, TResult> selector)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(convert);
        ArgumentNullException.ThrowIfNull(selector);
        return source.Bind(val => convert(val).Select(interVal => selector(val, interVal)));
    }

    /// <summary>
    /// Where <br />
    /// 条件筛选
    /// </summary>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static Try<TSource> Where<TSource>(this Try<TSource> source, Func<TSource, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
        return source.Bind(val => predicate(val) ? source : Try.LiftException<TSource>(new InvalidOperationException("Predicate not satisfied")));
    }
}