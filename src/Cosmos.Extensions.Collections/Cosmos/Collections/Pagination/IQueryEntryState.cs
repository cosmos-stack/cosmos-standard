using System.Collections.Generic;

namespace Cosmos.Collections.Pagination
{
    /// <summary>
    /// Query entry state interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueryEntryState<out T>
    {
        /// <summary>
        /// Gets all values
        /// </summary>
        IEnumerable<T> AllValues { get; }
    }
}