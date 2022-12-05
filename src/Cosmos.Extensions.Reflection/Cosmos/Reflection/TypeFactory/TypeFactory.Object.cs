using Cosmos.Dynamic;

namespace Cosmos.Reflection;

internal static partial class TypeFactory
{
    /// <summary>
    /// Create an instance for DynamicType
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static object CreateObject(IDictionary<string, object> values)
    {
        var properties = values.ToDictionary(_ => _.Key, _ => _.Value.GetType());
        var type = CreateType(properties);
        var @object = (DynamicBase)Activator.CreateInstance(type)!;
        foreach (var item in values)
        {
            @object.SetPropertyValue(item.Key, item.Value);
        }

        return @object;
    }
}