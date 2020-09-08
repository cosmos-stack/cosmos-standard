using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core
{
    internal static partial class XConv
    {
        private static bool FromNumericTypeToNumericType<N, X>(N numericVal, X defaultVal, Type xType, out object result)
        {
            try
            {
                result = Convert.ChangeType(numericVal, xType);
                //return FromStringToNumericType(numericVal.ToString(), defaultVal, xType, out result);
            }
            catch
            {
                result = defaultVal;
            }

            return true;
        }

        private static bool FromNumericTypeToNullableNumericType<N>(N numericVal, Type innerType, out object result)
        {
            try
            {
                result = Convert.ChangeType(numericVal, innerType);
                //result = FromStringToNullableNumericType(numericVal.ToString(), innerType, out result);
            }
            catch
            {
                result = null;
            }

            return true;
        }
    }
}