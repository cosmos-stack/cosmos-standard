namespace Cosmos.Conversions {
    /// <summary>
    /// Interface for conversion try
    /// </summary>
    public interface IConversionTry<in TFrom, TTo> {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        bool Is(TFrom from, out TTo to);
    }
}