using Cosmos.Reflection;

// ReSharper disable InconsistentNaming
namespace Cosmos.Conversions.Common.Core;

internal static partial class XConv
{
    private static bool FromStringToNumericType<N>(string from, N defaultVal, Type xType, out object result)
    {
        var valueUpdated = true;
        result = defaultVal;

        if (xType == TypeClass.ByteClazz)
            result = NumConvX.StringToByte(from, NumConvX.ObjectToByte(defaultVal));
        else if (xType == TypeClass.SByteClazz)
            result = NumConvX.StringToSByte(from, NumConvX.ObjectToSByte(defaultVal));
        else if (xType == TypeClass.Int16Clazz)
            result = NumConvX.StringToInt16(from, NumConvX.ObjectToInt16(defaultVal));
        else if (xType == TypeClass.UInt16Clazz)
            result = NumConvX.StringToUInt16(from, NumConvX.ObjectToUInt16(defaultVal));
        else if (xType == TypeClass.Int32Clazz)
            result = NumConvX.StringToInt32(from, NumConvX.ObjectToInt32(defaultVal));
        else if (xType == TypeClass.UInt32Clazz)
            result = NumConvX.StringToUInt32(from, NumConvX.ObjectToUInt32(defaultVal));
        else if (xType == TypeClass.Int64Clazz)
            result = NumConvX.StringToInt64(from, NumConvX.ObjectToInt64(defaultVal));
        else if (xType == TypeClass.UInt64Clazz)
            result = NumConvX.StringToUInt64(from, NumConvX.ObjectToUInt64(defaultVal));
        else if (xType == TypeClass.FloatClazz)
            result = NumConvX.StringToFloat(from, NumConvX.ObjectToFloat(defaultVal));
        else if (xType == TypeClass.DoubleClazz)
            result = NumConvX.StringToDouble(from, NumConvX.ObjectToDouble(defaultVal));
        else if (xType == TypeClass.DecimalClazz)
            result = NumConvX.StringToDecimal(from, NumConvX.ObjectToDecimal(defaultVal));
        else
            valueUpdated = false;

        return valueUpdated;
    }

    private static bool FromStringToNullableNumericType(string from, Type innerType, out object result)
    {
        var valueUpdated = true;
        result = null;

        if (innerType == TypeClass.ByteClazz)
            result = NumConvX.StringToNullableByte(from);
        else if (innerType == TypeClass.SByteClazz)
            result = NumConvX.StringToNullableSByte(from);
        else if (innerType == TypeClass.Int16Clazz)
            result = NumConvX.StringToNullableInt16(from);
        else if (innerType == TypeClass.UInt16Clazz)
            result = NumConvX.StringToNullableInt16(from);
        else if (innerType == TypeClass.Int32Clazz)
            result = NumConvX.StringToNullableInt32(from);
        else if (innerType == TypeClass.UInt32Clazz)
            result = NumConvX.StringToNullableUInt32(from);
        else if (innerType == TypeClass.Int64Clazz)
            result = NumConvX.StringToNullableInt64(from);
        else if (innerType == TypeClass.UInt64Clazz)
            result = NumConvX.StringToNullableUInt64(from);
        else if (innerType == TypeClass.FloatClazz)
            result = NumConvX.StringToNullableFloat(from);
        else if (innerType == TypeClass.DoubleClazz)
            result = NumConvX.StringToNullableDouble(from);
        else if (innerType == TypeClass.DecimalClazz)
            result = NumConvX.StringToNullableDecimal(from);
        else
            valueUpdated = false;

        return valueUpdated;
    }
}