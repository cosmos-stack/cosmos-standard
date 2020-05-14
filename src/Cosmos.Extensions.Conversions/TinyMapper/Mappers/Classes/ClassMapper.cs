using System;

namespace TinyMapper.Mappers.Classes {
    internal abstract class ClassMapper<TSource, TTarget> : MapperOf<TSource, TTarget> {
        protected virtual TTarget CreateTargetInstance() {
            throw new NotImplementedException();
        }

        protected abstract TTarget MapClass(TSource source, TTarget target);

        protected override TTarget MapCore(TSource source, TTarget target) {
            target ??= CreateTargetInstance();
            var result = MapClass(source, target);
            return result;
        }
    }
}