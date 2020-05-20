namespace Cosmos
{
    /// <summary>
    /// Type Converter Meta Interface<br />
    /// 类型转换元接口
    /// </summary>
    /// <typeparam name="TFrom">自何类型开始转换</typeparam>
    /// <typeparam name="TTo">转换至何类型</typeparam>
    public interface ITypeConverter<in TFrom, out TTo>
    {
        /// <summary>
        /// To<br />
        /// 类型转换至……
        /// </summary>
        /// <param name="from">被转换的对象</param>
        /// <returns>类型转换的结果</returns>
        TTo To(TFrom from);
    }
}