namespace Cosmos.Reflection.Reflectors;

public abstract partial class MemberReflector<TMemberInfo> : ICustomAttributeReflectorProvider where TMemberInfo : MemberInfo
{
    private readonly CustomAttributeReflector[] _customAttributeReflectors;

    public CustomAttributeReflector[] CustomAttributeReflectors => _customAttributeReflectors;
}