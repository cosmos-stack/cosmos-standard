using System.Reflection.Emit;
using Cosmos.Conversions.Common.Core.FallbackMappings.Core.DataStructures;
using Cosmos.Conversions.Common.Core.FallbackMappings.Core.Extensions;
using Cosmos.Reflection;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.CodeGenerators.Emitters;

internal sealed class EmitLocalVariable : IEmitterType
{
    private readonly Option<LocalBuilder> _localBuilder;

    private EmitLocalVariable(LocalBuilder localBuilder)
    {
        _localBuilder = localBuilder.ToOption();
        ObjectType = localBuilder.LocalType;
    }

    public Type ObjectType { get; }

    public void Emit(CodeGenerator generator)
    {
        _localBuilder.Where(x => Types.IsValueType(x.LocalType))
                     .Do(x => generator.Emit(OpCodes.Ldloca, x.LocalIndex))
                     .Do(x => generator.Emit(OpCodes.Initobj, x.LocalType));
    }

    public static IEmitterType Declare(LocalBuilder localBuilder)
    {
        return new EmitLocalVariable(localBuilder);
    }
}