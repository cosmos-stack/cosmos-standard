namespace Cosmos.Reflection;

/// <summary>
/// The type collection value <br />
/// 类型集合值
/// </summary>
public class TypesVal
{
    private readonly Type[] _types;

    private TypesVal(int size)
    {
        _types = new Type[size];
        Count = size;
    }

    /// <summary>
    /// Calculate the total number of types in the type collection value. <br />
    /// 计算类型集合值中的类型总数。
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// Get all types <br />
    /// 从类型集合值中获取所有类型
    /// </summary>
    public Type[] TypeArray
    {
        get
        {
            var array = new Type[Count];
            Array.Copy(_types, array, Count);
            return array;
        }
    }

    /// <summary>
    /// Get all types <br />
    /// 从类型集合值中获取所有类型
    /// </summary>
    public IEnumerable<Type> Types => TypeArray;

    /// <summary>
    /// Get type by index
    /// </summary>
    /// <param name="index"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Type this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            return _types[index];
        }
    }

    /// <summary>
    /// According to the given type array, construct a type collection value <br />
    /// 根据给定的类型数组，构建一个类型集合值
    /// </summary>
    /// <param name="types"></param>
    /// <returns></returns>
    public static TypesVal Create(params Type[]? types)
    {
        if (types is null || types is { Length: <= 0 })
            return Empty;
        var val = new TypesVal(types.Length);
        Array.Copy(types, val._types, val.Count);
        return val;
    }

    /// <summary>
    /// Get empty type collection value <br />
    /// 获取空的类型集合值
    /// </summary>
    public static TypesVal Empty { get; } = new(0);

    /// <summary>
    /// Whether the tag is empty type collection value <br />
    /// 标记是否为空的类型集合值
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty() => Count == 0;
}