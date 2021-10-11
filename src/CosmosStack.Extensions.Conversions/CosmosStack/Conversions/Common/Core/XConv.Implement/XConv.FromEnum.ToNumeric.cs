using System;
using CosmosStack.Reflection;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace CosmosStack.Conversions.Common.Core
{
    internal static partial class XConv
    {
        private static bool FromEnumToNumericType<N>(Type enumType, object enumVal, N defaultVal, Type xType, out object result)
        {
            var valueUpdated = true;
            result = defaultVal;

            if (xType == TypeClass.ByteClazz)
                result = NumConvX.EnumToByte(enumType, enumVal, NumConvX.ObjectToByte(defaultVal));
            else if (xType == TypeClass.SByteClazz)
                result = NumConvX.EnumToSByte(enumType, enumVal, NumConvX.ObjectToSByte(defaultVal));
            else if (xType == TypeClass.Int16Clazz)
                result = NumConvX.EnumToInt16(enumType, enumVal, NumConvX.ObjectToInt16(defaultVal));
            else if (xType == TypeClass.UInt16Clazz)
                result = NumConvX.EnumToUInt16(enumType, enumVal, NumConvX.ObjectToUInt16(defaultVal));
            else if (xType == TypeClass.Int32Clazz)
                result = NumConvX.EnumToInt32(enumType, enumVal, NumConvX.ObjectToInt32(defaultVal));
            else if (xType == TypeClass.UInt32Clazz)
                result = NumConvX.EnumToUInt32(enumType, enumVal, NumConvX.ObjectToUInt32(defaultVal));
            else if (xType == TypeClass.Int64Clazz)
                result = NumConvX.EnumToInt64(enumType, enumVal, NumConvX.ObjectToInt64(defaultVal));
            else if (xType == TypeClass.UInt32Clazz)
                result = NumConvX.EnumToUInt64(enumType, enumVal, NumConvX.ObjectToUInt64(defaultVal));
            else
                valueUpdated = false;

            return valueUpdated;
        }

        private static bool FromEnumToNullableNumericType(Type enumType, object @enum, Type xType, out object result)
        {
            var valueUpdated = true;
            result = null;

            if (xType == TypeClass.ByteClazz)
                result = NumConvX.EnumToNullableByte(enumType, @enum);
            else if (xType == TypeClass.SByteClazz)
                result = NumConvX.EnumToNullableSByte(enumType, @enum);
            else if (xType == TypeClass.Int16Clazz)
                result = NumConvX.EnumToNullableInt16(enumType, @enum);
            else if (xType == TypeClass.UInt16Clazz)
                result = NumConvX.EnumToNullableUInt16(enumType, @enum);
            else if (xType == TypeClass.Int32Clazz)
                result = NumConvX.EnumToNullableInt32(enumType, @enum);
            else if (xType == TypeClass.UInt32Clazz)
                result = NumConvX.EnumToNullableUInt32(enumType, @enum);
            else if (xType == TypeClass.Int64Clazz)
                result = NumConvX.EnumToNullableInt64(enumType, @enum);
            else if (xType == TypeClass.UInt64Clazz)
                result = NumConvX.EnumToNullableUInt64(enumType, @enum);
            else
                valueUpdated = false;

            return valueUpdated;
        }
    }
}