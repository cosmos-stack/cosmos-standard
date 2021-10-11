// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace

namespace CosmosStack.Conversions.Common.Core
{
    internal static partial class XConv
    {
        private static bool FromStringToGuid<G>(string from, G defaultVal, out object result)
        {
            result = GuidConvX.StringToGuid(from, GuidConvX.ObjToGuid(defaultVal));
            return true;
        }

        private static bool FromStringToNullableGuid(string from, out object result)
        {
            result = GuidConvX.StringToNullableGuid(from);
            return true;
        }
    }
}