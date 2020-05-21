using System.Collections.Generic;
using System.Linq;

namespace TinyMapper.Mappers
{
    internal abstract class Mapper
    {
        public const string MAP_METHOD_NAME = "Map";
        public const string MAPPERS_FIELD_NAME = "_mappers";

        // ReSharper disable once InconsistentNaming
        protected Mapper[] _mappers;

        public void AddMappers(IEnumerable<Mapper> mappers)
        {
            _mappers = mappers.ToArray();
        }

        public void UpdateRootMapper(int mapperId, Mapper mapper)
        {
            if (_mappers is null) return;

            for (var i = 0; i < _mappers.Length; i++)
            {
                if (i == mapperId)
                {
                    _mappers[i] ??= mapper;
                    return;
                }
            }
        }

        public object Map(object source, object target = null)
        {
            return MapCore(source, target);
        }

        protected abstract object MapCore(object source, object target);
    }
}