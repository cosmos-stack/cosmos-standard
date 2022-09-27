// ReSharper disable InconsistentNaming
namespace Cosmos.Conversions.Common.Core;

internal static partial class XConv
{
    private static bool FromStringToEnum<TEnum>(string from, TEnum defaultVal, out object result)
    {
        result = EnumConvX.StringToEnum(from, typeof(TEnum), defaultVal);
        return true;
    }

    private static bool FromStringToEnum(string from, Type enumType, object defaultVal, out object result)
    {
        result = EnumConvX.StringToEnum(from, enumType, defaultVal);
        return true;
    }

    private static bool FromStringToNullableEnum(string from, Type enumType, out object result)
    {
        result = EnumConvX.StringToNullableEnum(from, enumType);
        return true;
    }
}