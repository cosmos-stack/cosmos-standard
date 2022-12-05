using System.Reflection;
using Cosmos.Conversions.Common.Core.FallbackMappings.Core.Extensions;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.CodeGenerators.Emitters;

internal sealed class EmitNewObj : IEmitterType
{
    private EmitNewObj(Type objectType)
    {
        ObjectType = objectType;
    }

    public Type ObjectType { get; }

    public void Emit(CodeGenerator generator)
    {
        ConstructorInfo ctor = ObjectType.GetDefaultCtor();
        generator.EmitNewObject(ctor);
    }

    public static IEmitterType NewObj(Type objectType)
    {
        return new EmitNewObj(objectType);
    }
}