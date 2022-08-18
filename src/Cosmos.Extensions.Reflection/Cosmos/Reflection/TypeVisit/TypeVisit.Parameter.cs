using Cosmos.Reflection.Reflectors;

namespace Cosmos.Reflection;

/// <summary>
/// Type visit, an advanced TypeReflections utility. <br />
/// 类型访问器，一个高级的 TypeReflections 工具。
/// </summary>
public static partial class TypeVisit
{
    public static bool HasDefaultValueByAttributes(ParameterInfo parameter)
        => ParameterReflectorHelper.HasDefaultValueByAttributes(parameter);

    public static object GetDefaultValueSafely(ParameterInfo parameter)
        => ParameterReflectorHelper.GetDefaultValueSafely(parameter);
}

/// <summary>
/// Type visit extensions <br />
/// 类型访问器扩展
/// </summary>
public static partial class TypeVisitExtensions
{
    public static bool HasDefaultValueByAttributes(this ParameterInfo parameter)
        => ParameterReflectorHelper.HasDefaultValueByAttributes(parameter);

    public static object DefaultValueSafely(this ParameterInfo parameter)
        => ParameterReflectorHelper.GetDefaultValueSafely(parameter);
}