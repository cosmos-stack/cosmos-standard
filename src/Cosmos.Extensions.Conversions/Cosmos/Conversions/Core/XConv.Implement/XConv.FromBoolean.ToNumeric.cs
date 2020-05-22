using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core
{
    internal static partial class XConv
    {
        private static bool FromBooleanToNumericType<N>(bool oVal, CastingContext context, Type xType, out object result)
        {
            if (xType == TypeClass.ByteClass)
                result = oVal.ToBinary();
            else
                result = oVal ? context.NumericTrue.As<N>() : context.NumericFalse.As<N>();
            return true;
        }

        private static bool FromBooleanToNumericType(bool oVal, CastingContext context, Type xType, out object result)
        {
            if (xType == TypeClass.ByteClass)
            {
                result = oVal.ToBinary();
            }
            else
            {
                var midNumeric = oVal ? context.NumericTrue : context.NumericFalse;
                result = Convert.ChangeType(midNumeric, xType);
            }

            return true;
        }

        private static bool FromBooleanToNullableNumericType(bool oVal, CastingContext context, Type innerType, out object result)
        {
            if (innerType == TypeClass.ByteClass)
            {
                result = oVal.ToBinary();
            }
            else
            {
                var midNumeric = oVal ? context.NumericTrue : context.NumericFalse;
                result = Convert.ChangeType(midNumeric, innerType);
            }

            return true;
        }
    }
}