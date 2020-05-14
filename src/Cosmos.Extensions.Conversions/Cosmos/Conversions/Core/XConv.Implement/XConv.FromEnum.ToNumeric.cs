using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core {
    internal static partial class XConv {
        private static bool FromEnumToNumericType<N>(Type enumType, object enumVal, N defaultVal, Type xType, out object result) {
            var valueUpdated = true;
            result = defaultVal;

            if (xType == TypeClass.ByteClass)
                result = NumericConv.EnumToByte(enumType, enumVal, NumericConv.ObjectToByte(defaultVal));
            else if (xType == TypeClass.SByteClass)
                result = NumericConv.EnumToSByte(enumType, enumVal, NumericConv.ObjectToSByte(defaultVal));
            else if (xType == TypeClass.Int16Class)
                result = NumericConv.EnumToInt16(enumType, enumVal, NumericConv.ObjectToInt16(defaultVal));
            else if (xType == TypeClass.UInt16Class)
                result = NumericConv.EnumToUInt16(enumType, enumVal, NumericConv.ObjectToUInt16(defaultVal));
            else if (xType == TypeClass.Int32Class)
                result = NumericConv.EnumToInt32(enumType, enumVal, NumericConv.ObjectToInt32(defaultVal));
            else if (xType == TypeClass.UInt32Class)
                result = NumericConv.EnumToUInt32(enumType, enumVal, NumericConv.ObjectToUInt32(defaultVal));
            else if (xType == TypeClass.Int64Class)
                result = NumericConv.EnumToInt64(enumType, enumVal, NumericConv.ObjectToInt64(defaultVal));
            else if (xType == TypeClass.UInt32Class)
                result = NumericConv.EnumToUInt64(enumType, enumVal, NumericConv.ObjectToUInt64(defaultVal));
            else
                valueUpdated = false;

            return valueUpdated;
        }

        private static bool FromEnumToNullableNumericType(Type enumType, object @enum, Type xType, out object result) {
            var valueUpdated = true;
            result = null;

            if (xType == TypeClass.ByteClass)
                result = NumericConv.EnumToNullableByte(enumType, @enum);
            else if (xType == TypeClass.SByteClass)
                result = NumericConv.EnumToNullableSByte(enumType, @enum);
            else if (xType == TypeClass.Int16Class)
                result = NumericConv.EnumToNullableInt16(enumType, @enum);
            else if (xType == TypeClass.UInt16Class)
                result = NumericConv.EnumToNullableUInt16(enumType, @enum);
            else if (xType == TypeClass.Int32Class)
                result = NumericConv.EnumToNullableInt32(enumType, @enum);
            else if (xType == TypeClass.UInt32Class)
                result = NumericConv.EnumToNullableUInt32(enumType, @enum);
            else if (xType == TypeClass.Int64Class)
                result = NumericConv.EnumToNullableInt64(enumType, @enum);
            else if (xType == TypeClass.UInt64Class)
                result = NumericConv.EnumToNullableUInt64(enumType, @enum);
            else
                valueUpdated = false;

            return valueUpdated;
        }
    }
}