namespace Cosmos.Conversions
{
    /// <summary>
    /// Interface for conversion impl.<br />
    /// 带实现的转换接口。
    /// </summary>
    public interface IConversionImpl<in TFrom, TTo>
    {
        /// <summary>
        /// Try to convert.<br />
        /// 尝试转换。
        /// </summary>
        /// <param name="from">The object to be converted.</param>
        /// <param name="to">Return the converted result.</param>
        /// <returns>If the conversion is successful, return true; otherwise, return false.</returns>
        bool TryTo(TFrom from, out TTo to);
    }
}