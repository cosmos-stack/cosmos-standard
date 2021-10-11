using System;

namespace CosmosStack.Conversions.Mappers
{
    /// <summary>
    /// CosmosStack default mapper
    /// </summary>
    public class DefaultMapper : IObjectMapper
    {
        /// <summary>
        /// Gets a default mapper instance.
        /// </summary>
        public static IObjectMapper Instance => DefaultMapperCache.Instance;

        /// <inheritdoc />
        public TTo MapTo<TFrom, TTo>(TFrom fromObject)
        {
            return TinyMapper.TinyMapper.Map<TFrom, TTo>(fromObject);
        }

        /// <inheritdoc />
        public TTo MapTo<TFrom, TTo>(TFrom fromObject, TTo toInstance)
        {
            return TinyMapper.TinyMapper.Map(fromObject, toInstance);
        }

        /// <inheritdoc />
        public object MapTo(Type sourceType, Type targetType, object source)
        {
            return TinyMapper.TinyMapper.Map(sourceType, targetType, source);
        }

        /// <inheritdoc />
        public object MapTo(Type sourceType, Type targetType, object source, object target)
        {
            return TinyMapper.TinyMapper.Map(sourceType, targetType, source, target);
        }
    }
}