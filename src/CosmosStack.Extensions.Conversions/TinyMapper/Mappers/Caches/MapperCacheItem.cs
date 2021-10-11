using System.Reflection;
using TinyMapper.CodeGenerators.Emitters;

namespace TinyMapper.Mappers.Caches
{
    internal sealed class MapperCacheItem
    {
        public int Id { get; set; }
        public Mapper Mapper { get; set; }

        public IEmitterType EmitMapMethod(IEmitterType sourceMember, IEmitterType targetMember)
        {
            var mapperType = typeof(Mapper);
            var mapMethod = mapperType.GetMethod(Mapper.MAP_METHOD_NAME, BindingFlags.Instance | BindingFlags.Public);
            var mappersField = mapperType.GetField(Mapper.MAPPERS_FIELD_NAME, BindingFlags.Instance | BindingFlags.NonPublic);
            var mappers = EmitField.Load(EmitThis.Load(mapperType), mappersField);
            var mapper = EmitArray.Load(mappers, Id);
            var result = EmitMethod.Call(mapMethod, mapper, sourceMember, targetMember);
            return result;
        }
    }
}