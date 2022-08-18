using Cosmos.Reflection.Reflectors;

namespace Cosmos.Reflection;

public static partial class TypeReflections { }

/// <summary>
/// Reflection Utilities. <br />
/// 反射工具
/// </summary>
public static partial class TypeReflectionsExtensions
{
    private static readonly Attribute[] empty = InternalArray.ForEmpty<Attribute>();

    public static Attribute[] GetAttributes(this ICustomAttributeReflectorProvider customAttributeReflectorProvider)
    {
        if (customAttributeReflectorProvider is null)
            throw new ArgumentNullException(nameof(customAttributeReflectorProvider));

        var customAttributeReflectors = customAttributeReflectorProvider.CustomAttributeReflectors;
        var customAttributeLength = customAttributeReflectors.Length;

        if (customAttributeLength == 0)
            return empty;

        var attrs = new Attribute[customAttributeLength];
        for (var i = 0; i < customAttributeLength; i++)
        {
            attrs[i] = customAttributeReflectors[i].Invoke();
        }

        return attrs;
    }

    public static Attribute[] GetAttributes(this ICustomAttributeReflectorProvider customAttributeReflectorProvider, Type attributeType)
    {
        if (attributeType is null) throw new ArgumentNullException(nameof(attributeType));
        var attributeReflectors = customAttributeReflectorProvider != null
            ? customAttributeReflectorProvider.CustomAttributeReflectors
            : throw new ArgumentNullException(nameof(customAttributeReflectorProvider));
        var length = attributeReflectors.Length;
        if (length == 0) return empty;
        var holder = new Attribute[length];
        var counter = 0;
        var attrToken = attributeType.TypeHandle;
        for (var i = 0; i < length; i++)
        {
            var reflector = attributeReflectors[i];
            if (reflector._tokens.Contains(attrToken))
                holder[counter++] = reflector.Invoke();
        }

        if (length == counter)
            return holder;

        var attrs = new Attribute[counter];
        Array.Copy(holder, attrs, counter);
        return attrs;
    }

    public static TAttribute[] GetAttributes<TAttribute>(this ICustomAttributeReflectorProvider customAttributeReflectorProvider) where TAttribute : Attribute
    {
        if (customAttributeReflectorProvider is null)
            throw new ArgumentNullException(nameof(customAttributeReflectorProvider));

        var customAttributeReflectors = customAttributeReflectorProvider.CustomAttributeReflectors;
        var customAttributeLength = customAttributeReflectors.Length;
        if (customAttributeLength == 0)
            return InternalArray.ForEmpty<TAttribute>();

        var checkedAttrs = new TAttribute[customAttributeLength];
        var @checked = 0;
        var attrToken = typeof(TAttribute).TypeHandle;
        for (var i = 0; i < customAttributeLength; i++)
        {
            var reflector = customAttributeReflectors[i];
            if (reflector._tokens.Contains(attrToken))
                checkedAttrs[@checked++] = (TAttribute)reflector.Invoke();
        }

        if (customAttributeLength == @checked)
            return checkedAttrs;

        var attrs = new TAttribute[@checked];
        Array.Copy(checkedAttrs, attrs, @checked);
        return attrs;
    }

    public static Attribute GetAttribute(this ICustomAttributeReflectorProvider customAttributeReflectorProvider, Type attributeType)
    {
        if (attributeType is null)
            throw new ArgumentNullException(nameof(attributeType));
        var attributeReflectors = customAttributeReflectorProvider != null
            ? customAttributeReflectorProvider.CustomAttributeReflectors
            : throw new ArgumentNullException(nameof(customAttributeReflectorProvider));
        var length = attributeReflectors.Length;
        if (length == 0) return default;
        var attrToken = attributeType.TypeHandle;
        for (var i = 0; i < length; i++)
        {
            if (attributeReflectors[i]._tokens.Contains(attrToken))
                return attributeReflectors[i].Invoke();
        }

        return default;
    }

    public static TAttribute GetAttribute<TAttribute>(this ICustomAttributeReflectorProvider customAttributeReflectorProvider) where TAttribute : Attribute
    {
        return (TAttribute)GetAttribute(customAttributeReflectorProvider, typeof(TAttribute));
    }

    public static bool IsAttributeDefined(this ICustomAttributeReflectorProvider customAttributeReflectorProvider, Type attributeType)
    {
        if (attributeType is null) throw new ArgumentNullException(nameof(attributeType));
        var attributeReflectors = customAttributeReflectorProvider != null
            ? customAttributeReflectorProvider.CustomAttributeReflectors
            : throw new ArgumentNullException(nameof(customAttributeReflectorProvider));
        var length = attributeReflectors.Length;
        if (length == 0) return false;
        var attrToken = attributeType.TypeHandle;
        for (var i = 0; i < length; i++)
        {
            if (attributeReflectors[i]._tokens.Contains(attrToken))
                return true;
        }

        return false;
    }

    public static bool IsAttributeDefined<TAttribute>(this ICustomAttributeReflectorProvider customAttributeReflectorProvider) where TAttribute : Attribute
    {
        return IsAttributeDefined(customAttributeReflectorProvider, typeof(TAttribute));
    }
}