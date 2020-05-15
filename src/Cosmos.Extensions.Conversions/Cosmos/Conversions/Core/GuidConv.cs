using System;
using Cosmos.Conversions.Determiners;

namespace Cosmos.Conversions.Core {
    internal static class GuidConv {
        public static Guid ObjToGuid(object obj, Guid defaultVal = default) {
            return ObjToNullableGuid(obj) ?? defaultVal;
        }

        public static Guid StringToGuid(string str, Guid defaultVal = default) {
            return StringToNullableGuid(str) ?? defaultVal;
        }

        public static Guid? ObjToNullableGuid(object obj) {
            if (obj is null)
                return null;
            if (obj is string str)
                return StringToNullableGuid(str);
            return StringToNullableGuid(obj.ToString());
        }

        public static Guid? StringToNullableGuid(string str) {
            if (StringGuidDeterminer.Is(str))
                return StringGuidDeterminer.To(str);
            if (Guid.TryParse(str, out var guid))
                return guid;
            return null;
        }
    }
}