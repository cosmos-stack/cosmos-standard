using System.Reflection.Emit;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.CodeGenerators.Emitters;

internal sealed class EmitNull : IEmitterType
{
    private EmitNull()
    {
        ObjectType = typeof(object);
    }

    public Type ObjectType { get; }

    public void Emit(CodeGenerator generator)
    {
        generator.Emit(OpCodes.Ldnull);
    }

    public static IEmitterType Load()
    {
        return new EmitNull();
    }
}