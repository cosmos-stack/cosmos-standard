namespace Cosmos.IdUtils
{
    /// <summary>
    /// Trace Maker Interface
    /// </summary>
    public interface ITraceIdMaker
    {
        /// <summary>
        /// Create Id
        /// </summary>
        /// <returns></returns>
        string CreateId();
    }
}