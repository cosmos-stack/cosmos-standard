namespace CosmosStack.Conversions
{
    /// <summary>
    /// Interface for conversion try. <br />
    /// 带尝试的转换接口。
    /// </summary>
    public interface IConversionTry<in TFrom, TTo>
    {
        /// <summary>
        /// Check if it can be converted. <br />
        /// 检查是否可被转换。
        /// </summary>
        /// <param name="from">The object to be converted.</param>
        /// <param name="to">Return the converted result.</param>
        /// <returns>If it can be converted, return true; otherwise, return false.</returns>
        bool Is(TFrom from, out TTo to);
    }
}