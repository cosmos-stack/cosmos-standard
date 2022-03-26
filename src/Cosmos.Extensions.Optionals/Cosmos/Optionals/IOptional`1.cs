namespace Cosmos.Optionals;

/// <summary>
/// Interface for optional <br />
/// MayBe 组件接口
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IOptional<T> : IOptional
{
    /// <summary>
    /// Value <br />
    /// 值
    /// </summary>
    T Value { get; }

    /// <summary>
    /// Gets UnderlyingType of value <br />
    /// 获取值的底层类型
    /// </summary>
    Type UnderlyingType { get; }

    /// <summary>
    /// Contains <br />
    /// 包含
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    bool Contains(T value);

    /// <summary>
    /// Exists <br />
    /// 存在
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    bool Exists(Func<T, bool> predicate);

    /// <summary>
    /// Value or <br />
    /// 尝试获取值，或返回默认值
    /// </summary>
    /// <param name="alternative"></param>
    /// <returns></returns>
    T ValueOr(T alternative);

    /// <summary>
    /// Value or <br />
    /// 尝试获取值，或返回默认值
    /// </summary>
    /// <param name="alternativeFactory"></param>
    /// <returns></returns>
    T ValueOr(Func<T> alternativeFactory);
}