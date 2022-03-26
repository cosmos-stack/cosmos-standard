using System.Reflection.Emit;

namespace TinyMapper.Reflection;

internal interface IDynamicAssembly
{
    TypeBuilder DefineType(string typeName, Type parentType);
    void Save();
}