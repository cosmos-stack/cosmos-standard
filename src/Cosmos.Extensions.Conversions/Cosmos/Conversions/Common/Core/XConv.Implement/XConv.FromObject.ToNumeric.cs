using Cosmos.Reflection;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core;

internal static partial class XConv
{
    public static bool FromObjToNumericType<N>(object fromObj, N defaultVal, Type xType, out object result)
    {
        var valueUpdated = true;
        result = defaultVal;

        if (xType == TypeClass.ByteClazz)
            result = NumConvX.ObjectToByte(fromObj, NumConvX.ObjectToByte(defaultVal));
        else if (xType == TypeClass.SByteClazz)
            result = NumConvX.ObjectToSByte(fromObj, NumConvX.ObjectToSByte(defaultVal));
        else if (xType == TypeClass.Int16Clazz)
            result = NumConvX.ObjectToInt16(fromObj, NumConvX.ObjectToInt16(defaultVal));
        else if (xType == TypeClass.UInt16Clazz)
            result = NumConvX.ObjectToUInt16(fromObj, NumConvX.ObjectToUInt16(defaultVal));
        else if (xType == TypeClass.Int32Clazz)
            result = NumConvX.ObjectToInt32(fromObj, NumConvX.ObjectToInt32(defaultVal));
        else if (xType == TypeClass.UInt32Clazz)
            result = NumConvX.ObjectToUInt32(fromObj, NumConvX.ObjectToUInt32(defaultVal));
        else if (xType == TypeClass.Int64Clazz)
            result = NumConvX.ObjectToInt64(fromObj, NumConvX.ObjectToInt64(defaultVal));
        else if (xType == TypeClass.UInt64Clazz)
            result = NumConvX.ObjectToUInt64(fromObj, NumConvX.ObjectToUInt64(defaultVal));
        else if (xType == TypeClass.FloatClazz)
            result = NumConvX.ObjectToFloat(fromObj, NumConvX.ObjectToFloat(defaultVal));
        else if (xType == TypeClass.DoubleClazz)
            result = NumConvX.ObjectToDouble(fromObj, NumConvX.ObjectToDouble(defaultVal));
        else if (xType == TypeClass.DecimalClazz)
            result = NumConvX.ObjectToDecimal(fromObj, NumConvX.ObjectToDecimal(defaultVal));
        else
            valueUpdated = false;

        return valueUpdated;
    }

    private static bool FromObjToNullableNumericType(object fromObj, Type innerType, out object result)
    {
        var valueUpdated = true;
        result = null;

        if (innerType == TypeClass.ByteClazz)
            result = NumConvX.ObjectToNullableByte(fromObj);
        else if (innerType == TypeClass.SByteClazz)
            result = NumConvX.ObjectToNullableSByte(fromObj);
        else if (innerType == TypeClass.Int16Clazz)
            result = NumConvX.ObjectToNullableInt16(fromObj);
        else if (innerType == TypeClass.UInt16Clazz)
            result = NumConvX.ObjectToNullableInt16(fromObj);
        else if (innerType == TypeClass.Int32Clazz)
            result = NumConvX.ObjectToNullableInt32(fromObj);
        else if (innerType == TypeClass.UInt32Clazz)
            result = NumConvX.ObjectToNullableUInt32(fromObj);
        else if (innerType == TypeClass.Int64Clazz)
            result = NumConvX.ObjectToNullableInt64(fromObj);
        else if (innerType == TypeClass.UInt64Clazz)
            result = NumConvX.ObjectToNullableUInt64(fromObj);
        else if (innerType == TypeClass.FloatClazz)
            result = NumConvX.ObjectToNullableFloat(fromObj);
        else if (innerType == TypeClass.DoubleClazz)
            result = NumConvX.ObjectToNullableDouble(fromObj);
        else if (innerType == TypeClass.DecimalClazz)
            result = NumConvX.ObjectToNullableDecimal(fromObj);
        else
            valueUpdated = false;

        return valueUpdated;
    }
}