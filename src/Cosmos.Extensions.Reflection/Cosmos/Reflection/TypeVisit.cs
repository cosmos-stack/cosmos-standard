namespace Cosmos.Reflection;

internal static class MemberVisitHelper
{
    public static Type GetActualType(MemberInfo member)
    {
        return member switch
        {
            TypeInfo typeInfo => typeInfo.AsType(),
            Type type => type,
            FieldInfo field => field.FieldType,
            PropertyInfo property => property.PropertyType,
            MethodInfo method => method.ReturnType,
            ConstructorInfo constructor => constructor.DeclaringType,
            _ => throw new InvalidOperationException("Current MemberInfo cannot be converted to Reflector.")
        };
    }

    public static Type GetActualType(ParameterInfo parameter)
    {
        return parameter.ParameterType;
    }
}

/// <summary>
/// Type metadata visit, a meta information access entry for TypeReflections and TypeVisit. <br />
/// 类型元数据访问器，为 TypeReflections 和 TypeVisit 提供元信息的访问入口
/// </summary>
public static partial class TypeMetaVisitExtensions
{
    #region IsNumeric

    /// <summary>
    /// Determine whether the given member is a numeric type.<br />
    /// 判断给定的成员是否为数字类型。
    /// </summary>
    /// <param name="member">要检查的类型</param>
    /// <param name="options"></param>
    /// <returns>是否是数值类型</returns>
    public static bool IsNumeric(this MemberInfo member, TypeIsOptions options = TypeIsOptions.Default)
    {
        return Types.IsNumericType(MemberVisitHelper.GetActualType(member), options);
    }

    /// <summary>
    /// Determine whether the given parameter is a numeric type.<br />
    /// 判断给定的参数是否为数字类型。
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static bool IsNumeric(this ParameterInfo parameter, TypeIsOptions options = TypeIsOptions.Default)
    {
        return Types.IsNumericType(MemberVisitHelper.GetActualType(parameter), options);
    }

    #endregion

    #region IsTupleType

    /// <summary>
    /// Determine whether the given member is a tuple type.<br />
    /// 判断给定的成员是否为元组类型
    /// </summary>
    /// <param name="member"></param>
    /// <param name="ofOptions"></param>
    /// <param name="isOptions"></param>
    /// <returns></returns>
    public static bool IsTupleType(this MemberInfo member, TypeOfOptions ofOptions = TypeOfOptions.Owner, TypeIsOptions isOptions = TypeIsOptions.Default)
    {
        return Types.IsTupleType(MemberVisitHelper.GetActualType(member), ofOptions, isOptions);
    }

    /// <summary>
    /// Determine whether the given parameter is a tuple type.<br />
    /// 判断给定的参数是否为数元组类型
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="ofOptions"></param>
    /// <param name="isOptions"></param>
    /// <returns></returns>
    public static bool IsTupleType(this ParameterInfo parameter, TypeOfOptions ofOptions = TypeOfOptions.Owner, TypeIsOptions isOptions = TypeIsOptions.Default)
    {
        return Types.IsTupleType(MemberVisitHelper.GetActualType(parameter), ofOptions, isOptions);
    }

    #endregion

    #region IsStructType

    /// <summary>
    /// Determine whether the given member is a struct type.<br />
    /// 判断给定的成员是否为结构类型
    /// </summary>
    /// <param name="member"></param>
    /// <param name="isOptions"></param>
    /// <returns></returns>
    public static bool IsStructType(this MemberInfo member, TypeIsOptions isOptions = TypeIsOptions.Default)
    {
        return Types.IsStructType(MemberVisitHelper.GetActualType(member), isOptions);
    }

    /// <summary>
    /// Determine whether the given parameter is a struct type.<br />
    /// 判断给定的参数是否为数结构类型
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="isOptions"></param>
    /// <returns></returns>
    public static bool IsStructType(this ParameterInfo parameter, TypeIsOptions isOptions = TypeIsOptions.Default)
    {
        return Types.IsStructType(MemberVisitHelper.GetActualType(parameter), isOptions);
    }

    #endregion
}