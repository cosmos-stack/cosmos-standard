using System;

namespace Cosmos.Conversions {
    /// <summary>
    /// GUID Converter
    /// </summary>
    public static class GuidConversion {
        /// <summary>
        /// To GUID
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid ToGuid(object obj) {
            if (obj is null)
                return Guid.Empty;

            if (obj is string str && Internals.StringGuidHelper.Is(str))
                return Internals.StringGuidHelper.To(str);

            str = obj.ToString();
            if (Internals.StringGuidHelper.Is(str))
                return Internals.StringGuidHelper.To(str);

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

            if (obj is string str && Internals.StringGuidHelper.Is(str))
                return Internals.StringGuidHelper.To(str);

            str = obj.ToString();
            if (Internals.StringGuidHelper.Is(str))
                return Internals.StringGuidHelper.To(str);

            if (Guid.TryParse(str, out var guid))
                return guid;

            return null;
        }
    }
}