using Cosmos.Reflection;

// ReSharper disable InconsistentNaming
namespace Cosmos.Conversions.Common.Core;

internal static partial class XConv
{
    private static bool FromNumericTypeToString<N>(N numericVal, CastingContext context, string defaultStr, out object result)
    {
        var valueUpdated = true;
        result = defaultStr;

        switch (numericVal)
        {
            case short _1:
                result = StrConvX.Int16ToString(_1, context.NumericConvOptions, defaultStr);
                break;
            case ushort _2:
                result = StrConvX.UInt16ToString(_2, context.NumericConvOptions, defaultStr);
                break;
            case int _3:
                result = StrConvX.Int32ToString(_3, context.NumericConvOptions, defaultStr);
                break;
            case uint _4:
                result = StrConvX.UInt32ToString(_4, context.NumericConvOptions, defaultStr);
                break;
            case long _5:
                result = StrConvX.Int64ToString(_5, context.NumericConvOptions, defaultStr);
                break;
            case ulong _6:
                result = StrConvX.UInt64ToString(_6, context.NumericConvOptions, defaultStr);
                break;
            case float _7:
                result = StrConvX.FloatToString(_7, context.Digits, context.NumericConvOptions);
                break;
            case double _8:
                result = StrConvX.DoubleToString(_8, context.Digits, context.NumericConvOptions);
                break;
            case decimal _9:
                result = StrConvX.DecimalToString(_9, context.Digits, context.NumericConvOptions, defaultStr);
                break;
            default:
                valueUpdated = false;
                break;
        }

        return valueUpdated;
    }

    private static bool FromNullableNumericTypeToString(object numericVal, Type oType, CastingContext context, out object result)
    {
        var valueUpdated = true;
        result = null;

        if (oType == TypeClass.Int16NullableClazz)
            result = StrConvX.Int16ToString(NumConvX.ObjectToNullableInt16(numericVal), context.NumericConvOptions, string.Empty);
        else if (oType == TypeClass.UInt16NullableClazz)
            result = StrConvX.UInt16ToString(NumConvX.ObjectToNullableUInt16(numericVal), context.NumericConvOptions, string.Empty);
        else if (oType == TypeClass.Int32NullableClazz)
            result = StrConvX.Int32ToString(NumConvX.ObjectToNullableInt32(numericVal), context.NumericConvOptions, string.Empty);
        else if (oType == TypeClass.UInt32NullableClazz)
            result = StrConvX.UInt32ToString(NumConvX.ObjectToNullableUInt32(numericVal), context.NumericConvOptions, string.Empty);
        else if (oType == TypeClass.Int64NullableClazz)
            result = StrConvX.Int64ToString(NumConvX.ObjectToNullableInt64(numericVal), context.NumericConvOptions, string.Empty);
        else if (oType == TypeClass.UInt64NullableClazz)
            result = StrConvX.UInt64ToString(NumConvX.ObjectToNullableUInt64(numericVal), context.NumericConvOptions, string.Empty);
        else if (oType == TypeClass.FloatNullableClazz)
            result = StrConvX.FloatToString(NumConvX.ObjectToNullableFloat(numericVal), context.Digits, context.NumericConvOptions);
        else if (oType == TypeClass.DoubleNullableClazz)
            result = StrConvX.DoubleToString(NumConvX.ObjectToNullableDouble(numericVal), context.Digits, context.NumericConvOptions);
        else if (oType == TypeClass.DecimalNullableClazz)
            result = StrConvX.DecimalToString(NumConvX.ObjectToNullableDecimal(numericVal), context.Digits, context.NumericConvOptions, string.Empty);
        else
            valueUpdated = false;

        return valueUpdated;
    }
}