namespace Cosmos.Reflection.Reflectors;

internal static class ParameterReflectorHelper
{
    public static bool HasDefaultValueByAttributes(ParameterInfo parameter)
        // parameter.HasDefaultValue will throw a FormatException when parameter is DateTime type with default value
        => (parameter.Attributes & ParameterAttributes.HasDefault) != 0;

    public static object GetDefaultValueSafely(ParameterInfo parameter)
    {
        try
        {
            // parameter.DefaultValue will throw a FormatException when parameter is DateTime type with default value
            return parameter.DefaultValue;
        }
        catch
        {
            return null;
        }
    }
}

public partial class ParameterReflector : ICustomAttributeReflectorProvider
{
    private readonly ParameterInfo _reflectionInfo;
    private readonly CustomAttributeReflector[] _customAttributeReflectors;

    public CustomAttributeReflector[] CustomAttributeReflectors => _customAttributeReflectors;

    public string Name => _reflectionInfo.Name;

    public bool HasDeflautValue { get; }

    public object DefalutValue { get; }

    public int Position { get; }

    public Type ParameterType { get; }

    private ParameterReflector(ParameterInfo reflectionInfo)
    {
        _reflectionInfo = reflectionInfo ?? throw new ArgumentNullException(nameof(reflectionInfo));
        _customAttributeReflectors = _reflectionInfo.CustomAttributes.Select(data => CustomAttributeReflector.Create(data)).ToArray();
        HasDeflautValue = ParameterReflectorHelper.HasDefaultValueByAttributes(reflectionInfo);

        if (HasDeflautValue)
            DefalutValue = ParameterReflectorHelper.GetDefaultValueSafely(reflectionInfo);

        Position = reflectionInfo.Position;
        ParameterType = reflectionInfo.ParameterType;
    }

    public ParameterInfo GetParameterInfo() => _reflectionInfo;

    public override string ToString() => $"Parameter : {_reflectionInfo}  ParameterType : {ParameterType}";
}