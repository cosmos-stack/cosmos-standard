namespace Cosmos.Optionals;

/// <summary>
/// Interface for optional <br />
/// MayBe 组件接口
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TImpl"></typeparam>
public interface IOptionalImpl<T, TImpl> : IOptional<T>, IEquatable<T>, IComparable<T>
{
    /// <summary>
    /// Or <br />
    /// 如果当前 MayBe 组件为 False，则使用给定的替换值，并返回新的 MayBe 组件
    /// </summary>
    /// <param name="alternative"></param>
    /// <returns></returns>
    TImpl Or(T alternative);

    /// <summary>
    /// Or <br />
    /// 如果当前 MayBe 组件为 False，则使用给定的替换值，并返回新的 MayBe 组件
    /// </summary>
    /// <param name="alternativeFactory"></param>
    /// <returns></returns>
    TImpl Or(Func<T> alternativeFactory);

    /// <summary>
    /// Else <br />
    /// 如果当前 MayBe 组件为 False，则使用给定的替换的 MayBe 组件
    /// </summary>
    /// <param name="alternativeMaybe"></param>
    /// <returns></returns>
    TImpl Else(TImpl alternativeMaybe);

    /// <summary>
    /// Else <br />
    /// 如果当前 MayBe 组件为 False，则使用给定的替换的 MayBe 组件
    /// </summary>
    /// <param name="alternativeMaybeFactory"></param>
    /// <returns></returns>
    TImpl Else(Func<TImpl> alternativeMaybeFactory);

    /// <summary>
    /// With exception <br />
    /// 置入一个异常
    /// </summary>
    /// <param name="exception"></param>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    Either<T, TException> WithException<TException>(TException exception);

    /// <summary>
    /// With exception <br />
    /// 置入一个异常
    /// </summary>
    /// <param name="exceptionFactory"></param>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    object WithException<TException>(Func<TException> exceptionFactory);

    /// <summary>
    /// Match <br />
    /// 命中，若 MayBe 组件为 True 则调用 <see cref="someFactory"/>，不然则调用 <see cref="noneFactory"/>.
    /// </summary>
    /// <param name="someFactory"></param>
    /// <param name="noneFactory"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    TResult Match<TResult>(Func<T, TResult> someFactory, Func<TResult> noneFactory);

    /// <summary>
    /// Match <br />
    /// 命中，若 MayBe 组件为 True 则调用 <see cref="someAct"/>，不然则调用 <see cref="noneAct"/>.
    /// </summary>
    /// <param name="someAct"></param>
    /// <param name="noneAct"></param>
    void Match(Action<T> someAct, Action noneAct);

    /// <summary>
    /// Match maybe <br />
    /// 命中，若 MayBe 组件为 True 则调用
    /// </summary>
    /// <param name="maybeAct"></param>
    void MatchMaybe(Action<T> maybeAct);

    /// <summary>
    /// Match none <br />
    /// 命中，若 MayBe 组件为 False 则调用
    /// </summary>
    /// <param name="noneAct"></param>
    void MatchNone(Action noneAct);

    /// <summary>
    /// Map <br />
    /// 映射
    /// </summary>
    /// <param name="mapping"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    Maybe<TResult> Map<TResult>(Func<T, TResult> mapping);

    /// <summary>
    /// Flat map <br />
    /// 映射
    /// </summary>
    /// <param name="mapping"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    Maybe<TResult> FlatMap<TResult>(Func<T, Maybe<TResult>> mapping);

    /// <summary>
    /// Flat map <br />
    /// 映射
    /// </summary>
    /// <param name="mapping"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    Maybe<TResult> FlatMap<TResult, TException>(Func<T, Either<TResult, TException>> mapping);

    /// <summary>
    /// Filter <br />
    /// 过滤
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
    TImpl Filter(bool condition);

    /// <summary>
    /// Filter <br />
    /// 过滤
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    TImpl Filter(Func<T, bool> predicate);

    /// <summary>
    /// Not null <br />
    /// 不为空
    /// </summary>
    /// <returns></returns>
    TImpl NotNull();
}