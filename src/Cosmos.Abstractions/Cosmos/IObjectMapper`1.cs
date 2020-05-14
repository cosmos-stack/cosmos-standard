namespace Cosmos {
    /// <summary>
    /// Object Generic Mapper Meta Interface<br />
    /// 对象泛型映射元接口
    /// </summary>
    public interface IGenericObjectMapper {
        /// <summary>
        /// Map to<br />
        /// 映射至……
        /// </summary>
        /// <typeparam name="TFrom">从何种类型开始映射</typeparam>
        /// <typeparam name="TTo">映射至何种类型</typeparam>
        /// <param name="fromObject">被映射的对象</param>
        /// <returns>映射结果</returns>
        TTo MapTo<TFrom, TTo>(TFrom fromObject);

        /// <summary>
        /// Map to<br />
        /// 映射至……
        /// </summary>
        /// <typeparam name="TFrom">从何种类型开始映射</typeparam>
        /// <typeparam name="TTo">映射至何种类型</typeparam>
        /// <param name="fromObject">被映射的对象</param>
        /// <param name="toInstance">映射至的对象</param>
        /// <returns>映射结果，将返回 <paramref name="toInstance"/> 实例</returns>
        TTo MapTo<TFrom, TTo>(TFrom fromObject, TTo toInstance);
    }
}