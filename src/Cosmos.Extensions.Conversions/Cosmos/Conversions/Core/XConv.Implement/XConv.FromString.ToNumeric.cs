using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core {
    internal static partial class XConv {
        private static bool FromStringToNumericType<N>(string from, N defaultVal, Type xType, out object result) {
            var valueUpdated = true;
            result = defaultVal;

            if (xType == TypeClass.ByteClass)
                result = NumericConv.StringToByte(from, NumericConv.ObjectToByte(defaultVal));
            else if (xType == TypeClass.SByteClass)
                result = NumericConv.StringToSByte(from, NumericConv.ObjectToSByte(defaultVal));
            else if (xType == TypeClass.Int16Class)
                result = NumericConv.StringToInt16(from, NumericConv.ObjectToInt16(defaultVal));
            else if (xType == TypeClass.UInt16Class)
                result = NumericConv.StringToUInt16(from, NumericConv.ObjectToUInt16(defaultVal));
            else if (xType == TypeClass.Int32Class)
                result = NumericConv.StringToInt32(from, NumericConv.ObjectToInt32(defaultVal));
            else if (xType == TypeClass.UInt32Class)
                result = NumericConv.StringToUInt32(from, NumericConv.ObjectToUInt32(defaultVal));
            else if (xType == TypeClass.Int64Class)
                result = NumericConv.StringToInt64(from, NumericConv.ObjectToInt64(defaultVal));
            else if (xType == TypeClass.UInt64Class)
                result = NumericConv.StringToUInt64(from, NumericConv.ObjectToUInt64(defaultVal));
            else if (xType == TypeClass.FloatClass)
                result = NumericConv.StringToFloat(from, NumericConv.ObjectToFloat(defaultVal));
            else if (xType == TypeClass.DoubleClass)
                result = NumericConv.StringToDouble(from, NumericConv.ObjectToDouble(defaultVal));
            else if (xType == TypeClass.DecimalClass)
                result = NumericConv.StringToDecimal(from, NumericConv.ObjectToDecimal(defaultVal));
            else
                valueUpdated = false;

            return valueUpdated;
        }

        private static bool FromStringToNullableNumericType(string from, Type innerType, out object result) {
            var valueUpdated = true;
            result = null;

            if (innerType == TypeClass.ByteClass)
                result = NumericConv.StringToNullableByte(from);
            else if (innerType == TypeClass.SByteClass)
                result = NumericConv.StringToNullableSByte(from);
            else if (innerType == TypeClass.Int16Class)
                result = NumericConv.StringToNullableInt16(from);
            else if (innerType == TypeClass.UInt16Class)
                result = NumericConv.StringToNullableInt16(from);
            else if (innerType == TypeClass.Int32Class)
                result = NumericConv.StringToNullableInt32(from);
            else if (innerType == TypeClass.UInt32Class)
                result = NumericConv.StringToNullableUInt32(from);
            else if (innerType == TypeClass.Int64Class)
                result = NumericConv.StringToNullableInt64(from);
            else if (innerType == TypeClass.UInt64Class)
                result = NumericConv.StringToNullableUInt64(from);
            else if (innerType == TypeClass.FloatClass)
                result = NumericConv.StringToNullableFloat(from);
            else if (innerType == TypeClass.DoubleClass)
                result = NumericConv.StringToNullableDouble(from);
            else if (innerType == TypeClass.DecimalClass)
                result = NumericConv.StringToNullableDecimal(from);
            else
                valueUpdated = false;

            return valueUpdated;
        }
    }
}