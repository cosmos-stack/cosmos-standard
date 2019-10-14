namespace Cosmos
{
    /// <summary>
    /// Opt result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOperationResult<T>
    {
        /// <summary>
        /// Operation result
        /// </summary>
        T Result { get; }
    }
}