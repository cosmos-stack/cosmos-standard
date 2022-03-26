namespace Cosmos.Optionals;

/// <summary>
/// Interface for Dynamic optional <br />
/// 动态 MayBe 组件接口
/// </summary>
public interface IDynamicOptional
{
    /// <summary>
    /// Key <br />
    /// 键
    /// </summary>
    string Key { get; }

    /// <summary>
    /// Has value <br />
    /// 标记是否有值
    /// </summary>
    bool HasValue { get; }

    /// <summary>
    /// Value <br />
    /// 值
    /// </summary>
    dynamic Value { get; }

    /// <summary>
    /// Contains <br />
    /// 包含
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    bool Contains(string key);

    /// <summary>
    /// Exists <br />
    /// 存在
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    bool Exists(Func<string, bool> predicate);

    /// <summary>
    /// Value or <br />
    /// 尝试获取值，或返回默认值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="alternative"></param>
    /// <returns></returns>
    dynamic ValueOr(string key, dynamic alternative);

    /// <summary>
    /// Value or <br />
    /// 尝试获取值，或返回默认值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="alternativeFactory"></param>
    /// <returns></returns>
    dynamic ValueOr(string key, Func<dynamic> alternativeFactory);

    /// <summary>
    /// Or <br />
    /// 如果当前 MayBe 组件为 False，则使用给定的替换值，并返回新的 MayBe 组件
    /// </summary>
    /// <param name="key"></param>
    /// <param name="alternative"></param>
    /// <returns></returns>
    Maybe<dynamic> Or(string key, dynamic alternative);

    /// <summary>
    /// Or <br />
    /// 如果当前 MayBe 组件为 False，则使用给定的替换值，并返回新的 MayBe 组件
    /// </summary>
    /// <param name="key"></param>
    /// <param name="alternativeFactory"></param>
    /// <returns></returns>
    Maybe<dynamic> Or(string key, Func<dynamic> alternativeFactory);

    /// <summary>
    /// Else <br />
    /// 如果当前 MayBe 组件为 False，则使用给定的替换的 MayBe 组件
    /// </summary>
    /// <param name="key"></param>
    /// <param name="alternativeMaybe"></param>
    /// <returns></returns>
    Maybe<dynamic> Else(string key, Maybe<dynamic> alternativeMaybe);

    /// <summary>
    /// Else <br />
    /// 如果当前 MayBe 组件为 False，则使用给定的替换的 MayBe 组件
    /// </summary>
    /// <param name="key"></param>
    /// <param name="alternativeMaybeFactory"></param>
    /// <returns></returns>
    Maybe<dynamic> Else(string key, Func<Maybe<dynamic>> alternativeMaybeFactory);

    /// <summary>
    /// Convert to dynamic object <br />
    /// 转换为动态对象
    /// </summary>
    /// <returns></returns>
    dynamic ToDynamicObject();

    /// <summary>
    /// Gets keys <br />
    /// 获取键集合
    /// </summary>
    IEnumerable<string> Keys { get; }

    /// <summary>
    /// Gets values <br />
    /// 获取值集合
    /// </summary>
    IEnumerable<dynamic> Values { get; }

    /// <summary>
    /// Join <br />
    /// 组合
    /// </summary>
    /// <param name="value"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    DynamicMaybe Join(dynamic value, string key);

    /// <summary>
    /// Where <br />
    /// 筛选
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    DynamicMaybe Where(Func<string, dynamic, bool> predicate);

    /// <summary>
    /// Where <br />
    /// 筛选
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    DynamicMaybe Where(Func<dynamic, bool> predicate);

    /// <summary>
    /// Select <br />
    /// 选择
    /// </summary>
    /// <param name="selector"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    IEnumerable<T> Select<T>(Func<string, dynamic, T> selector);

    /// <summary>
    /// To Dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <returns></returns>
    IDictionary<string, dynamic> ToDictionary();

    /// <summary>
    /// To Dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    IDictionary<T, V> ToDictionary<T, V>(Func<KeyValuePair<string, dynamic>, T> keySelector, Func<KeyValuePair<string, dynamic>, V> valueSelector);
}