namespace Cosmos.Collections {
    /// <summary>
    /// Set and range result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SetAddRangeResult<T> {

        #region Constructor.

        /// <summary>
        /// Create a new instance of <see cref="SetAddRangeResult{T}"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="added"></param>
        public SetAddRangeResult(T item, bool added) {
            // Set values.
            Item = item;
            Added = added;
        }

        #endregion

        #region Instance, read-only state.

        /// <summary>
        /// Gets item
        /// </summary>
        public T Item { get; }

        /// <summary>
        /// Addod or not...
        /// </summary>
        public bool Added { get; }

        #endregion

    }
}