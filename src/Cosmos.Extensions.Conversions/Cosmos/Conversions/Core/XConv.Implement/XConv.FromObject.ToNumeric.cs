using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core
{
    internal static partial class XConv
    {
        public static bool FromObjToNumericType<N>(object fromObj, N defaultVal, Type xType, out object result)
        {
            var valueUpdated = true;
            result = defaultVal;

            if (xType == TypeClass.ByteClass)
                result = NumericConv.ObjectToByte(fromObj, NumericConv.ObjectToByte(defaultVal));
            else if (xType == TypeClass.SByteClass)
                result = NumericConv.ObjectToSByte(fromObj, NumericConv.ObjectToSByte(defaultVal));
            else if (xType == TypeClass.Int16Class)
                result = NumericConv.ObjectToInt16(fromObj, NumericConv.ObjectToInt16(defaultVal));
            else if (xType == TypeClass.UInt16Class)
                result = NumericConv.ObjectToUInt16(fromObj, NumericConv.ObjectToUInt16(defaultVal));
            else if (xType == TypeClass.Int32Class)
                result = NumericConv.ObjectToInt32(fromObj, NumericConv.ObjectToInt32(defaultVal));
            else if (xType == TypeClass.UInt32Class)
                result = NumericConv.ObjectToUInt32(fromObj, NumericConv.ObjectToUInt32(defaultVal));
            else if (xType == TypeClass.Int64Class)
                result = NumericConv.ObjectToInt64(fromObj, NumericConv.ObjectToInt64(defaultVal));
            else if (xType == TypeClass.UInt64Class)
                result = NumericConv.ObjectToUInt64(fromObj, NumericConv.ObjectToUInt64(defaultVal));
            else if (xType == TypeClass.FloatClass)
                result = NumericConv.ObjectToFloat(fromObj, NumericConv.ObjectToFloat(defaultVal));
            else if (xType == TypeClass.DoubleClass)
                result = NumericConv.ObjectToDouble(fromObj, NumericConv.ObjectToDouble(defaultVal));
            else if (xType == TypeClass.DecimalClass)
                result = NumericConv.ObjectToDecimal(fromObj, NumericConv.ObjectToDecimal(defaultVal));
            else
                valueUpdated = false;

            return valueUpdated;
        }

        private static bool FromObjToNullableNumericType(object fromObj, Type innerType, out object result)
        {
            var valueUpdated = true;
            result = null;

            if (innerType == TypeClass.ByteClass)
                result = NumericConv.ObjectToNullableByte(fromObj);
            else if (innerType == TypeClass.SByteClass)
                result = NumericConv.ObjectToNullableSByte(fromObj);
            else if (innerType == TypeClass.Int16Class)
                result = NumericConv.ObjectToNullableInt16(fromObj);
            else if (innerType == TypeClass.UInt16Class)
                result = NumericConv.ObjectToNullableInt16(fromObj);
            else if (innerType == TypeClass.Int32Class)
                result = NumericConv.ObjectToNullableInt32(fromObj);
            else if (innerType == TypeClass.UInt32Class)
                result = NumericConv.ObjectToNullableUInt32(fromObj);
            else if (innerType == TypeClass.Int64Class)
                result = NumericConv.ObjectToNullableInt64(fromObj);
            else if (innerType == TypeClass.UInt64Class)
                result = NumericConv.ObjectToNullableUInt64(fromObj);
            else if (innerType == TypeClass.FloatClass)
                result = NumericConv.ObjectToNullableFloat(fromObj);
            else if (innerType == TypeClass.DoubleClass)
                result = NumericConv.ObjectToNullableDouble(fromObj);
            else if (innerType == TypeClass.DecimalClass)
                result = NumericConv.ObjectToNullableDecimal(fromObj);
            else
                valueUpdated = false;

            return valueUpdated;
        }
    }
}