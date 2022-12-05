namespace Cosmos.Reflection.Reflectors;

public partial class ParameterReflector
{
    internal static ParameterReflector Create(ParameterInfo parameterInfo)
    {
        ArgumentNullException.ThrowIfNull(parameterInfo);
        return TypeReflections.ReflectorCacheUtils<ParameterInfo, ParameterReflector>.GetOrAdd(parameterInfo, info => new ParameterReflector(info));
    }
}