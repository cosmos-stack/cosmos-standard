using System;
using Cosmos.Conversions.StringDeterminers;

namespace Cosmos.Conversions {
    /// <summary>
    /// GUID Converter
    /// </summary>
    public static class GuidConverter {
        /// <summary>
        /// To GUID
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid ToGuid(object obj) {
            if (obj is null)
                return Guid.Empty;

            if (obj is string str && StringGuidDeterminer.Is(str))
                return StringGuidDeterminer.To(str);

            str = obj.ToString();
            if (StringGuidDeterminer.Is(str))
                return StringGuidDeterminer.To(str);

            return Guid.TryParse(str, out var guid) ? guid : Guid.Empty;
        }

        /// <summary>
        /// To nullable GUID
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid? ToNullableGuid(object obj) {
            if (obj is null)
                return null;

            if (obj is string str && StringGuidDeterminer.Is(str))
                return StringGuidDeterminer.To(str);

            str = obj.ToString();
            if (StringGuidDeterminer.Is(str))
                return StringGuidDeterminer.To(str);

            if (Guid.TryParse(str, out var guid))
                return guid;

            return null;
        }
    }
}