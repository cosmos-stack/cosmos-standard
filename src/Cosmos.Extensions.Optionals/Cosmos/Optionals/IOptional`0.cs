namespace Cosmos.Optionals
{
    /// <summary>
    /// Interface for optional
    /// </summary>
    public interface IOptional
    {
        /// <summary>
        /// Key
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Has value
        /// </summary>
        bool HasValue { get; }
    }
}