using System.Collections;
using AspectCore.Extensions.Reflection;

namespace Cosmos.Reflection;

/// <summary>
/// An attribute collection <br />
/// 特性集合
/// </summary>
public sealed class AttributeCollection : IList<Attribute>, IReadOnlyList<Attribute>
{
    #region Empty

    internal static readonly AttributeCollection Empty = new(Array.Empty<Attribute>());

    #endregion

    private readonly Attribute[] _attributes;

    internal AttributeCollection(Attribute[] attributes)
    {
        _attributes = attributes;
    }

    public Attribute this[int index] => _attributes[index];

    /// <summary>
    /// The number of attributes. <br />
    /// 特性的数量
    /// </summary>
    public int Count => _attributes.Length;

    /// <summary>
    /// Determine whether the specified Attribute type is included. <br />
    /// 判断给定的特性是否存在于此
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    public bool Has<TAttribute>() where TAttribute : Attribute => Get<TAttribute>() is not null;

    /// <summary>
    /// Determine whether the specified Attribute type is included. <br />
    /// 判断给定的特性类型是否存在于此
    /// </summary>
    /// <param name="typeOfAttribute"></param>
    /// <returns></returns>
    public bool Has(Type typeOfAttribute) => Get(typeOfAttribute) is not null;

    /// <summary>
    /// Get the first instance of the specified Attribute type. <br />
    /// 获得给定的特性的实例
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    public TAttribute Get<TAttribute>() where TAttribute : Attribute
    {
        foreach (var attribute in _attributes)
        {
            if (attribute is TAttribute castedAttr)
            {
                return castedAttr;
            }
        }

        return null;
    }

    /// <summary>
    /// Get the first instance of the specified Attribute type. <br />
    /// 获得给定的特性类型的实例
    /// </summary>
    /// <param name="typeOfAttribute"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public Attribute Get(Type typeOfAttribute)
    {
        if (typeOfAttribute is null)
            throw new ArgumentNullException(nameof(typeOfAttribute));
        return _attributes.FirstOrDefault(typeOfAttribute.IsInstanceOfType);
    }

    /// <summary>
    /// Get all instances of the specified Attribute type. <br />
    /// 获得所有给定的特性的实例
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    public IEnumerable<TAttribute> GetAll<TAttribute>() where TAttribute : Attribute
    {
        foreach (var attribute in _attributes)
        {
            if (attribute is TAttribute castedAttr)
            {
                yield return castedAttr;
            }
        }
    }

    /// <summary>
    /// Get all instances of the specified Attribute type. <br />
    /// 获得所有给定的特性类型的实例
    /// </summary>
    /// <param name="typeOfAttribute"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public IEnumerable<Attribute> GetAll(Type typeOfAttribute)
    {
        if (typeOfAttribute is null)
            throw new ArgumentNullException(nameof(typeOfAttribute));

        foreach (var attribute in _attributes)
        {
            if (typeOfAttribute.IsInstanceOfType(attribute))
            {
                yield return attribute;
            }
        }
    }

    public IEnumerator<Attribute> GetEnumerator() => ((IEnumerable<Attribute>)_attributes).GetEnumerator();

    bool ICollection<Attribute>.IsReadOnly => true;

    bool ICollection<Attribute>.Contains(Attribute item) => ((ICollection<Attribute>)_attributes).Contains(item);

    void ICollection<Attribute>.CopyTo(Attribute[] array, int arrayIndex) => _attributes.CopyTo(array, arrayIndex);

    int IList<Attribute>.IndexOf(Attribute item) => ((IList<Attribute>)_attributes).IndexOf(item);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    Attribute IList<Attribute>.this[int index]
    {
        get => _attributes[index];
        set => throw new NotSupportedException();
    }

    void ICollection<Attribute>.Add(Attribute item) => throw new NotSupportedException();

    void ICollection<Attribute>.Clear() => throw new NotSupportedException();

    bool ICollection<Attribute>.Remove(Attribute item) => throw new NotSupportedException();

    void IList<Attribute>.Insert(int index, Attribute item) => throw new NotSupportedException();

    void IList<Attribute>.RemoveAt(int index) => throw new NotSupportedException();

    #region Of

    /// <summary>
    /// Create an instance of <see cref="AttributeCollection"/> by the given type.
    /// 根据给定的类型，解析并返回特性集合
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static AttributeCollection Of(Type type)
    {
        if (type is null)
            throw new ArgumentNullException(nameof(type));
        return type.GetReflector().GetCustomAttributes().JoinToCollection();
    }

    /// <summary>
    /// Create an instance of <see cref="AttributeCollection"/> by the given type.
    /// 根据给定的类型，解析并返回特性集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static AttributeCollection Of<T>() => Of(typeof(T));

    /// <summary>
    /// Create an instance of <see cref="AttributeCollection"/> by the given attribute collection.
    /// 根据给定的特性集合，返回特性集合实例
    /// </summary>
    /// <param name="attributes"></param>
    /// <returns></returns>
    public static AttributeCollection OfAttributes(Attribute[] attributes)
    {
        return new(attributes);
    }

    /// <summary>
    /// Create an instance of <see cref="AttributeCollection"/> by the given attribute collection.
    /// 根据给定的特性集合，返回特性集合实例
    /// </summary>
    /// <param name="attributes"></param>
    /// <returns></returns>
    public static AttributeCollection OfAttributes(IEnumerable<Attribute> attributes)
    {
        return new(attributes.ToArray());
    }

    #endregion
}

/// <summary>
/// Extensions for attribute collection
/// </summary>
public static class AttributeCollectionExtensions
{
    /// <summary>
    /// Convert attribute collection into <see cref="AttributeCollection"/>. <br />
    /// 将特性集合转换为 AttributeCollection
    /// </summary>
    /// <param name="attributes"></param>
    /// <returns></returns>
    public static AttributeCollection JoinToCollection(this IEnumerable<Attribute> attributes)
    {
        return AttributeCollection.OfAttributes(attributes);
    }

    /// <summary>
    /// Convert attribute collection into <see cref="AttributeCollection"/>. <br />
    /// 将特性集合转换为 AttributeCollection
    /// </summary>
    /// <param name="attributes"></param>
    /// <returns></returns>
    public static AttributeCollection JoinToCollection(this Attribute[] attributes)
    {
        return AttributeCollection.OfAttributes(attributes);
    }
}