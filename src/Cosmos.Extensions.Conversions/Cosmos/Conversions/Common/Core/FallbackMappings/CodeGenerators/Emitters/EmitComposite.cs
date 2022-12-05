using Cosmos.Conversions.Common.Core.FallbackMappings.Core.Extensions;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.CodeGenerators.Emitters;

internal sealed class EmitComposite : IEmitter
{
    private readonly List<IEmitter> _nodes = new();

    public void Emit(CodeGenerator generator)
    {
        _nodes.ForEach(x => x.Emit(generator));
    }

    public EmitComposite Add(IEmitter node)
    {
        if (node.IsNotNull())
        {
            _nodes.Add(node);
        }

        return this;
    }
}