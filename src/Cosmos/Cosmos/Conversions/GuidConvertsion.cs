using System;

namespace Cosmos.Conversions {
    /// <summary>
    /// GUID Converter
    /// </summary>
    public static class GuidConversion {
        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid ToGuid(object obj) {
            if (obj is null) {
                return Guid.Empty;
            }

            return Guid.TryParse(obj.ToString(), out var ret) ? ret : Guid.Empty;
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref=" Guid"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid? ToNullableGuid(object obj) {
            if (obj is null) {
                return null;
            }

            if (Guid.TryParse(obj.ToString(), out var ret)) {
                return ret;
            }

            return null;
        }
    }
}