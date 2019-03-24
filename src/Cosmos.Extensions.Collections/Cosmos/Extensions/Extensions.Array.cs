using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static class ArrayExtensions
    {
        public static TElement[] ToSafeArray<TElement>(this IEnumerable<TElement> source) => source as TElement[] ?? source.ToArray();
    }
}