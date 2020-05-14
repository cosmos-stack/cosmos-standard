using System;

namespace TinyMapper.Mappers.Types.Convertible {
    internal sealed class ConvertibleTypeMapper : Mapper {
        private readonly Func<object, object> _converter;

        public ConvertibleTypeMapper(Func<object, object> converter) {
            _converter = converter;
        }

        protected override object MapCore(object source, object target) {
            if (_converter is null)
                return source;
            if (source is null)
                return target;
            return _converter(source);
        }
    }
}