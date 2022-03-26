using System.Reflection;
using Cosmos.Reflection;
using TinyMapper.Core.DataStructures;

namespace TinyMapper.Mappers.Classes.Members;

internal sealed class MappingMember
{
    public MappingMember(MemberInfo source, MemberInfo target, TypePairInfo typePair)
    {
        Source = source;
        Target = target;
        TypePair = typePair;
    }

    public MemberInfo Source { get; }
    public MemberInfo Target { get; }
    public TypePairInfo TypePair { get; }
}