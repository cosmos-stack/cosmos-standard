namespace CosmosStack.Conversions.ObjectMappingServices
{
    /// <summary>
    /// Object Generic Mapper Meta Interface<br />
    /// 对象泛型映射元接口
    /// </summary>
    public interface IGenericObjectMapper
    {
        /// <summary>
        /// Map to<br />
        /// 映射至……
        /// </summary>
        /// <typeparam name="TSource">从何种类型开始映射</typeparam>
        /// <typeparam name="TDestination">映射至何种类型</typeparam>
        /// <param name="source">被映射的对象</param>
        /// <returns>映射结果</returns>
        TDestination MapTo<TSource, TDestination>(TSource source);

        /// <summary>
        /// Map to<br />
        /// 映射至……
        /// </summary>
        /// <typeparam name="TSource">从何种类型开始映射</typeparam>
        /// <typeparam name="TDestination">映射至何种类型</typeparam>
        /// <param name="source">被映射的对象</param>
        /// <param name="destination">映射至的对象</param>
        /// <returns>映射结果，将返回 <paramref name="destination"/> 实例</returns>
        TDestination MapTo<TSource, TDestination>(TSource source, TDestination destination);
    }
}