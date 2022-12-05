using System.Reflection.Emit;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.Reflection;

internal interface IDynamicAssembly
{
    TypeBuilder DefineType(string typeName, Type parentType);
    void Save();
}