// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core;

internal static partial class XConv
{
    private static bool FromGuidToString(Guid guid, CastingContext context, string defaultStr, out object result)
    {
        result = StrConvX.GuidToString(guid, context, defaultStr);
        return true;
    }

    private static bool FromNullableGuidToString(Guid? guid, CastingContext context, out object result)
    {
        result = StrConvX.GuidToString(guid, context);
        return true;
    }
}