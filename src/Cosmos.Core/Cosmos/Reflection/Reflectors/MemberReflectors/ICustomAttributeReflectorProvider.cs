namespace Cosmos.Reflection.Reflectors;

public interface ICustomAttributeReflectorProvider
{
    CustomAttributeReflector[] CustomAttributeReflectors { get; }
}