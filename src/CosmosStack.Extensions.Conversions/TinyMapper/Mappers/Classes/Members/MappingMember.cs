using System.Reflection;
using TinyMapper.Core.DataStructures;

namespace TinyMapper.Mappers.Classes.Members
{
    internal sealed class MappingMember
    {
        public MappingMember(MemberInfo source, MemberInfo target, TypePair typePair)
        {
            Source = source;
            Target = target;
            TypePair = typePair;
        }

        public MemberInfo Source { get; }
        public MemberInfo Target { get; }
        public TypePair TypePair { get; }
    }
}