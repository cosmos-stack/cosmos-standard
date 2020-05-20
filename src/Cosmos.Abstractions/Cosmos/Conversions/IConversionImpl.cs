namespace Cosmos.Conversions
{
    /// <summary>
    /// Interface for conversion impl
    /// </summary>
    public interface IConversionImpl<in TFrom, TTo>
    {
        /// <summary>
        /// To
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        bool TryTo(TFrom from, out TTo to);
    }
}