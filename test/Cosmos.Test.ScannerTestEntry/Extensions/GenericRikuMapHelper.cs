using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Test.ScannerTest0;

namespace Cosmos.Test.ScannerTestEntry.Extensions
{
    internal class GenericRikuMapHelper
    {
        private readonly ConcurrentDictionary<(Type, int), bool> MatchedCached = new ConcurrentDictionary<(Type, int), bool>();

        public bool IsMatchedEntityMappingRule(Type type, List<Type> bodyTypes)
        {
            if (type == null)
                return false;

            if (bodyTypes == null || !bodyTypes.Any())
                return false;

            if (CheckCache(type, bodyTypes, out var ret))
                return ret;

            if (!typeof(IMap).IsAssignableFrom(type))
                return CacheAndReturn(type, bodyTypes, false);

            var bodyType = type.GetRawType(typeof(MapBase<>));

            if (bodyType == null)
                return CacheAndReturn(type, bodyTypes, false);

            return CacheAndReturn(type, bodyTypes, bodyTypes.Contains(bodyType));
        }

        private bool CheckCache(Type type, IEnumerable<Type> bodyTypes, out bool ret)
        {
            var hashCode = bodyTypes.GetHashCode();
            return MatchedCached.TryGetValue((type, hashCode), out ret);
        }

        private bool CacheAndReturn(Type type, IEnumerable<Type> bodyTypes, bool result)
        {
            var hashCode = bodyTypes.GetHashCode();
            MatchedCached.TryAdd((type, hashCode), result);
            return result;
        }
    }
}
