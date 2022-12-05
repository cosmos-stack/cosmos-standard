namespace Cosmos.Conversions.Common.Core.FallbackMappings.CodeGenerators.Emitters;

internal interface IEmitterType : IEmitter
{
    Type ObjectType { get; }
}