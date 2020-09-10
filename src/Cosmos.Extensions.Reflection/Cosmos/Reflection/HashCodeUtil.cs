using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Reflection
{
    public static class HashCodeUtil
    {
        public static int GetHashCode(Func<IEnumerable<object>> hashFieldValuesFunc) => InternalCalculator.GetHashCodeImpl(hashFieldValuesFunc());

        public static int GetHashCode(IEnumerable<object> hashFieldValues) => InternalCalculator.GetHashCodeImpl(hashFieldValues);

        internal static class InternalCalculator
        {
            public static int GetHashCodeImpl(IEnumerable<object> hashFieldValues)
            {
                // Naive .NET implementation
                //var offset = 17;
                //var prime = 59;
                //
                //int HashCodeAggregator(int hashCode, object value) => value == null
                //    ? hashCode * prime + 0
                //    : hashCode * prime + value.GetHashCode();

                // http://www.isthe.com/chongo/tech/comp/fnv/index.html
                const int offset = unchecked((int) 2166136261);
                const int prime = 16777619;

                int HashCodeAggregator(int hashCode, object value) => value == null
                    ? (hashCode ^ 0) * prime
                    : (hashCode ^ value.GetHashCode()) * prime;

                return hashFieldValues.Aggregate(offset, HashCodeAggregator);
            }
        }
    }
}