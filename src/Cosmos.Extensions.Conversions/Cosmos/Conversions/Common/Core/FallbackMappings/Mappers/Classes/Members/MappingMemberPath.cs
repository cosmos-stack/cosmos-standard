using System.Reflection;
using Cosmos.Conversions.Common.Core.FallbackMappings.Core.Extensions;
using Cosmos.Reflection;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.Mappers.Classes.Members;

internal sealed class MappingMemberPath
{
    public MappingMemberPath(List<MemberInfo> source, List<MemberInfo> target)
#if NETFRAMEWORK
        : this(source, target, new TypePairOf(source[source.Count - 1].GetMemberType(), target[target.Count - 1].GetMemberType())) { }
#else
        : this(source, target, new TypePairOf(source[^1].GetMemberType(), target[^1].GetMemberType())) { }
#endif

    public MappingMemberPath(MemberInfo source, MemberInfo target)
        : this(new List<MemberInfo> { source }, new List<MemberInfo> { target }, new TypePairOf(source.GetMemberType(), target.GetMemberType())) { }

    public MappingMemberPath(MemberInfo source, MemberInfo target, TypePairOf typePair)
        : this(new List<MemberInfo> { source }, new List<MemberInfo> { target }, typePair) { }

    public MappingMemberPath(List<MemberInfo> source, List<MemberInfo> target, TypePairOf typePair)
    {
        Source = source;
        OneLevelSource = source.Count == 1;
        OneLevelTarget = target.Count == 1;
        Target = target;
        TypePair = typePair;
        Tail = new MappingMember(source[source.Count - 1], target[target.Count - 1], typePair);
        Head = new MappingMember(source[0], target[0], new TypePairOf(source[0].GetMemberType(), target[0].GetMemberType()));
    }

    public bool OneLevelSource { get; }
    public bool OneLevelTarget { get; }
    public List<MemberInfo> Source { get; }
    public List<MemberInfo> Target { get; }
    public TypePairOf TypePair { get; }
    public MappingMember Tail { get; }
    public MappingMember Head { get; }
}