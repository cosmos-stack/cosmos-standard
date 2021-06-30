using System.Linq;

namespace Cosmos.Collections.Pagination
{
    /// <summary>
    /// Empty page
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EmptyPage<T> : EnumerablePage<T>
    {
        /// <summary>
        /// Create a new instance of <see cref="EmptyPage{T}"/>
        /// </summary>
        public EmptyPage() : base(Enumerable.Empty<T>(), 1, 0, 0) { }
    }
}