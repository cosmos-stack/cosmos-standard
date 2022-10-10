namespace Cosmos.Reflection;

/// <summary>
/// Type visit, an advanced TypeReflections utility. <br />
/// 类型访问器，一个高级的 TypeReflections 工具。
/// </summary>
public static partial class TypeVisit
{
    /// <summary>
    /// To create a new dynamic type with the given property collection. <br />
    /// 使用给定的属性集合创建一个动态类型
    /// </summary>
    /// <param name="properties"></param>
    /// <returns></returns>
    public static Type CreateDynamicType(IDictionary<string, Type> properties)
    {
        return TypeFactory.CreateType(properties);
    }
}