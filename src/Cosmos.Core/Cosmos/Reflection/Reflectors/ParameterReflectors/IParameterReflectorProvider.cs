namespace Cosmos.Reflection.Reflectors;

public interface IParameterReflectorProvider
{
    ParameterReflector[] ParameterReflectors { get; }
}