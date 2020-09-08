using System;

namespace Cosmos.Conversions.Mappers
{
    /// <summary>
    /// Default mapping binder
    /// </summary>
    public static class DefaultMappingBinder
    {
        /// <summary>
        /// Bind
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        public static void Bind<TSource, TTarget>()
        {
            TinyMapper.TinyMapper.Bind<TSource, TTarget>();
        }

        /// <summary>
        /// Bind
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        public static void Bind<TSource, TTarget>(Action<IDefaultBindingConfig<TSource, TTarget>> bindingConfigure)
        {
            TinyMapper.TinyMapper.Bind(bindingConfigure);
        }

        /// <summary>
        /// Bind
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="targetType"></param>
        public static void Bind(Type sourceType, Type targetType)
        {
            TinyMapper.TinyMapper.Bind(sourceType, targetType);
        }

        /// <summary>
        /// Has bound
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <returns></returns>
        public static bool HasBound<TSource, TTarget>()
        {
            return TinyMapper.TinyMapper.BindingExists<TSource, TTarget>();
        }

        /// <summary>
        /// Has bound
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static bool HasBound(Type sourceType, Type targetType)
        {
            return TinyMapper.TinyMapper.BindingExists(sourceType, targetType);
        }
    }
}