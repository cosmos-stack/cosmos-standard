using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class ListExtensions
    {
        public static List<string> ToStringList<T>(this IEnumerable<T> me, Func<T, string> stringConverter)
            => me.Select(stringConverter).ToList();
    }
}
