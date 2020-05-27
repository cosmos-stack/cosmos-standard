using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DeepCopy
{
    /// <inheritdoc />
    internal sealed class ReferenceEqualsComparer : IEqualityComparer<object>
    {
        /// <summary>
        /// Gets an instance of this class.
        /// </summary>
        public static ReferenceEqualsComparer Instance { get; } = new ReferenceEqualsComparer();

        /// <inheritdoc />
        bool IEqualityComparer<object>.Equals(object x, object y)
        {
            // ReSharper disable once RedundantNameQualifier
            return object.ReferenceEquals(x, y);
        }

        /// <inheritdoc />
        int IEqualityComparer<object>.GetHashCode(object obj)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            return obj is null ? 0 : RuntimeHelpers.GetHashCode(obj);
        }
    }
}