using System.Reflection;
using Cosmos.Reflection;
using TinyMapper.Core.DataStructures;
using TinyMapper.Core.Extensions;

namespace TinyMapper.Mappers.Classes.Members;

internal sealed class MappingMemberPath
{
    public MappingMemberPath(List<MemberInfo> source, List<MemberInfo> target)
        : this(source, target, new TypePairInfo(source[^1].GetMemberType(), target[^1].GetMemberType())) { }

    public MappingMemberPath(MemberInfo source, MemberInfo target)
        : this(new List<MemberInfo> {source}, new List<MemberInfo> {target}, new TypePairInfo(source.GetMemberType(), target.GetMemberType())) { }

    public MappingMemberPath(MemberInfo source, MemberInfo target, TypePairInfo typePair)
        : this(new List<MemberInfo> {source}, new List<MemberInfo> {target}, typePair) { }

    public MappingMemberPath(List<MemberInfo> source, List<MemberInfo> target, TypePairInfo typePair)
    {
        Source = source;
        OneLevelSource = source.Count == 1;
        OneLevelTarget = target.Count == 1;
        Target = target;
        TypePair = typePair;
        Tail = new MappingMember(source[source.Count - 1], target[target.Count - 1], typePair);
        Head = new MappingMember(source[0], target[0], new TypePairInfo(source[0].GetMemberType(), target[0].GetMemberType()));
    }

    public bool OneLevelSource { get; }
    public bool OneLevelTarget { get; }
    public List<MemberInfo> Source { get; }
    public List<MemberInfo> Target { get; }
    public TypePairInfo TypePair { get; }
    public MappingMember Tail { get; }
    public MappingMember Head { get; }
}