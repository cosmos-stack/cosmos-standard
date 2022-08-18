using Cosmos.Reflection.Reflectors.Internals;

namespace Cosmos.Reflection.Reflectors;

public partial class ParameterReflector
{
    internal static ParameterReflector Create(ParameterInfo parameterInfo)
    {
        if (parameterInfo is null)
            throw new ArgumentNullException(nameof(parameterInfo));
        return TypeReflections.ReflectorCacheUtils<ParameterInfo, ParameterReflector>.GetOrAdd(parameterInfo, info => new ParameterReflector(info));
    }
}