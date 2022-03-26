using System.Reflection;
using TinyMapper.Core.DataStructures;

namespace TinyMapper.Core.Extensions;

internal static class MemberInfoExtensions
{
    public static Option<TAttribute> GetAttribute<TAttribute>(this MemberInfo value)
        where TAttribute : Attribute
    {
        return value.GetCustomAttributes(true)
                    .FirstOrDefault(x => x is TAttribute)
                    .ToType<TAttribute>();
    }

    public static List<TAttribute> GetAttributes<TAttribute>(this MemberInfo value)
        where TAttribute : Attribute
    {
        return value.GetCustomAttributes(true).OfType<TAttribute>().ToList();
    }

    public static Type GetMemberType(this MemberInfo value)
    {
        if (value.IsField())
        {
            return ((FieldInfo) value).FieldType;
        }

        if (value.IsProperty())
        {
            return ((PropertyInfo) value).PropertyType;
        }

        if (value.IsMethod())
        {
            return ((MethodInfo) value).ReturnType;
        }

        throw new NotSupportedException();
    }

    public static bool IsField(this MemberInfo value)
    {
        return value is FieldInfo;
    }

    public static bool IsProperty(this MemberInfo value)
    {
        return value is PropertyInfo;
    }

    private static bool IsMethod(this MemberInfo value)
    {
        return value is MethodInfo;
    }
}