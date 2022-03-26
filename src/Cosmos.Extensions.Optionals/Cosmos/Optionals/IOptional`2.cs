namespace Cosmos.Optionals;

/// <summary>
/// Interface for optional <br />
/// MayBe 组件接口
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TException"></typeparam>
public interface IOptional<T, out TException> : IOptional<T>
{
    /// <summary>
    /// Exception <br />
    /// 异常
    /// </summary>
    TException Exception { get; }

    /// <summary>
    /// Gets UnderlyingType for exception <br />
    /// 获取值的底层类型
    /// </summary>
    Type UnderlyingExceptionType { get; }

    /// <summary>
    /// Value or <br />
    /// 尝试获取值，或返回默认值
    /// </summary>
    /// <param name="alternativeFactory"></param>
    /// <returns></returns>
    T ValueOr(Func<TException, T> alternativeFactory);
}