namespace Cosmos.Reflection.Reflectors;

public partial class MethodReflector
{
    internal static MethodReflector Create(MethodInfo reflectionInfo, CallOptions callOption)
    {
        if (reflectionInfo is null)
            throw new ArgumentNullException(nameof(reflectionInfo));
        return TypeReflections.ReflectorCacheUtils<PairOf<MethodInfo, CallOptions>, MethodReflector>.GetOrAdd(new PairOf<MethodInfo, CallOptions>(reflectionInfo, callOption), CreateInternal);

        MethodReflector CreateInternal(PairOf<MethodInfo, CallOptions> item)
        {
            var methodInfo = item.Item1;
            if (methodInfo.ContainsGenericParameters)
                return new OpenGenericMethodReflector(methodInfo);

            if (methodInfo.IsStatic)
                return new StaticMethodReflector(methodInfo);

            if (methodInfo.DeclaringType.GetTypeInfo().IsValueType || callOption == CallOptions.Call)
                return new CallMethodReflector(methodInfo);

            return new MethodReflector(methodInfo);
        }
    }
}