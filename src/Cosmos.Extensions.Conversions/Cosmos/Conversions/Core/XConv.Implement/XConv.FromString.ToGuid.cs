// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core {
    internal static partial class XConv {
        private static bool FromStringToGuid<G>(string from, G defaultVal, out object result) {
            result = GuidConv.StringToGuid(from, GuidConv.ObjToGuid(defaultVal));
            return true;
        }

        private static bool FromStringToNullableGuid(string from, out object result) {
            result = GuidConv.StringToNullableGuid(from);
            return true;
        }
    }
}