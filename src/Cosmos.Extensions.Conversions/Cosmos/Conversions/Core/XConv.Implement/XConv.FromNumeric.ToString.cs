using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core
{
    internal static partial class XConv
    {
        private static bool FromNumericTypeToString<N>(N numericVal, CastingContext context, string defaultStr, out object result)
        {
            var valueUpdated = true;
            result = defaultStr;

            switch (numericVal)
            {
                case short _1:
                    result = StringConv.Int16ToString(_1, defaultStr);
                    break;
                case ushort _2:
                    result = StringConv.UInt16ToString(_2, defaultStr);
                    break;
                case int _3:
                    result = StringConv.Int32ToString(_3, defaultStr);
                    break;
                case uint _4:
                    result = StringConv.UInt32ToString(_4, defaultStr);
                    break;
                case long _5:
                    result = StringConv.Int64ToString(_5, defaultStr);
                    break;
                case ulong _6:
                    result = StringConv.UInt64ToString(_6, defaultStr);
                    break;
                case float _7:
                    result = StringConv.FloatToString(_7, context.Digits);
                    break;
                case double _8:
                    result = StringConv.DoubleToString(_8, context.Digits);
                    break;
                case decimal _9:
                    result = StringConv.DecimalToString(_9, context.Digits, defaultStr);
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

            if (oType == TypeClass.Int16NullableClass)
                result = StringConv.Int16ToString(NumericConv.ObjectToNullableInt16(numericVal), string.Empty);
            else if (oType == TypeClass.UInt16NullableClass)
                result = StringConv.UInt16ToString(NumericConv.ObjectToNullableUInt16(numericVal), string.Empty);
            else if (oType == TypeClass.Int32NullableClass)
                result = StringConv.Int32ToString(NumericConv.ObjectToNullableInt32(numericVal), string.Empty);
            else if (oType == TypeClass.UInt32NullableClass)
                result = StringConv.UInt32ToString(NumericConv.ObjectToNullableUInt32(numericVal), string.Empty);
            else if (oType == TypeClass.Int64NullableClass)
                result = StringConv.Int64ToString(NumericConv.ObjectToNullableInt64(numericVal), string.Empty);
            else if (oType == TypeClass.UInt64NullableClass)
                result = StringConv.UInt64ToString(NumericConv.ObjectToNullableUInt64(numericVal), string.Empty);
            else if (oType == TypeClass.FloatNullableClass)
                result = StringConv.FloatToString(NumericConv.ObjectToNullableFloat(numericVal), context.Digits);
            else if (oType == TypeClass.DoubleNullableClass)
                result = StringConv.DoubleToString(NumericConv.ObjectToNullableDouble(numericVal), context.Digits);
            else if (oType == TypeClass.DecimalNullableClass)
                result = StringConv.DecimalToString(NumericConv.ObjectToNullableDecimal(numericVal), context.Digits, string.Empty);
            else
                valueUpdated = false;

            return valueUpdated;
        }
    }
}