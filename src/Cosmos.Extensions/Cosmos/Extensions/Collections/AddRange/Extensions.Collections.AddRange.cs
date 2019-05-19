using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class CollectionExtensions
    {
        public static void AddRange<T>(this List<T> source, IEnumerable<T> collection, int limit)
        {
            if (limit <= 0)
            {
                source.AddRange(collection);
                return;
            }

            var counter = 0;
            foreach (var item in collection)
            {
                if (counter >= limit)
                    break;

                source.Add(item);
                ++counter;
            }
        }
    }
}
