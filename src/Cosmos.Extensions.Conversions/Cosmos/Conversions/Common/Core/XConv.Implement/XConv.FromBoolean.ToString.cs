// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core;

internal static partial class XConv
{
    public static bool FromBooleanToString(bool oVal, CastingContext context, out object result)
    {
        result = oVal.ToString(context.TrueString, context.FalseString);
        return true;
    }
}