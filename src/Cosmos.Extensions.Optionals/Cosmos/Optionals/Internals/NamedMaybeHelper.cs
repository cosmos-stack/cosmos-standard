using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Optionals.Internals
{
    internal static class NamedMaybeHelper
    {
        public static bool IsDefaultKey(string key)
        {
            return 0 == string.CompareOrdinal(key, NamedMaybeConstants.KEY);
        }

        public static string FixedKey(string key, int expectKey)
        {
            return IsDefaultKey(key) ? GetKey(expectKey) : key;
        }

        private static string GetKey(int number)
        {
            return number switch
            {
                0 => NamedMaybeConstants.KEY,
                1 => NamedMaybeConstants.KEY2,
                2 => NamedMaybeConstants.KEY3,
                3 => NamedMaybeConstants.KEY4,
                4 => NamedMaybeConstants.KEY5,
                5 => NamedMaybeConstants.KEY6,
                6 => NamedMaybeConstants.KEY7,
                7 => throw new ArgumentOutOfRangeException(nameof(number), "Index is must be between 0 and 6"),
                _ => throw new ArgumentException("Index is must be between 0 and 6")
            };
        }

        public static Dictionary<string, int> CreateIndexCache(int requiredNumber, params string[] keys)
        {
            if (requiredNumber <= 0 || requiredNumber >= 7)
                throw new ArgumentOutOfRangeException(nameof(requiredNumber), "Index is must be between 0 and 6");
            var result = new Dictionary<string, int>();

            if (keys is null || !keys.Any())
            {
                for (var i = 0; i < requiredNumber; ++i)
                {
                    result.Add(GetKey(i), i);
                }
            }
            else
            {
                var limitedMaxValue = keys.Length > 7 ? 7 : keys.Length;

                for (var i = 0; i < limitedMaxValue; ++i)
                {
                    var key = keys[i];
                    if (string.IsNullOrWhiteSpace(key))
                        key = GetKey(i);
                    if (result.ContainsKey(key))
                        key = GetKey(i);
                    result.Add(key, i);
                }

                if (result.Count < requiredNumber)
                {
                    var start = result.Count;
                    var need = requiredNumber - start;
                    if (need > 0)
                    {
                        for (var i = 0; i < need; ++i)
                        {
                            var key = GetKey(start + i);
                            if (result.ContainsKey(key))
                                key += "_(1)";
                            result.Add(key, start + i);
                        }
                    }
                }
            }

            return result;
        }
    }
}