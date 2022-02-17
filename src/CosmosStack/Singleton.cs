namespace Cosmos;

/// <summary>
/// Provide a unified singleton management portal. <br />
/// 单例管理器
/// </summary>
public class Singleton
{
    static Singleton()
    {
        AllSingletons = new Dictionary<Type, object?>();
    }

    /// <summary>
    /// All singleton objects <br />
    /// 获取所有单例实例
    /// </summary>
    public static IDictionary<Type, object?> AllSingletons { get; }
}

/// <summary>
/// Provide a unified singleton management portal and a copy of itself. <br />
/// 单例管理器的派生类，指定了某种类型，形成具体类型的单例获取入口。
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : Singleton
{
    private static T? _instance;

    /// <summary>
    /// Singleton instance <br />
    /// 获取单例
    /// </summary>
    public static T? Instance
    {
        get => _instance;
        set
        {
            _instance = value;
            AllSingletons[typeof(T)] = value;
        }
    }
}

/// <summary>
/// Provide a unified singleton management portal and a copy of itself. <br />
/// 单例管理器的派生类，指定了某种类型，形成具体类型的单例获取入口。
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonList<T> : Singleton<IList<T>>
{
    static SingletonList()
    {
        Singleton<IList<T>>.Instance = new List<T>();
    }

    /// <summary>
    /// Get a singleton of the specified type T <br />
    /// 获取给定单例的集合（单例实例）
    /// </summary>
    public new static IList<T>? Instance => Singleton<IList<T>>.Instance;
}

/// <summary>
/// Provide a unified singleton management portal and a copy of itself <br />
/// 单例管理器的派生类，指定了某种类型，形成具体类型的单例获取入口。
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
public class SingletonDictionary<TKey, TValue> : Singleton<IDictionary<TKey, TValue>> where TKey : notnull
{
    static SingletonDictionary()
    {
        Singleton<Dictionary<TKey, TValue>>.Instance = new Dictionary<TKey, TValue>();
    }

    /// <summary>
    /// Get a singleton of the specified type T <br />
    /// 获取给定单例的字典（单例实例）
    /// </summary>
    public new static IDictionary<TKey, TValue>? Instance => Singleton<Dictionary<TKey, TValue>>.Instance;
}