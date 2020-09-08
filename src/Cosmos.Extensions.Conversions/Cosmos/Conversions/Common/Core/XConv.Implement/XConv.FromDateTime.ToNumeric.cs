using System;
using Cosmos.Reflection;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core
{
    internal static partial class XConv
    {
        private static bool FromDateTimeToNumericType<N>(DateTime dateTime, N defaultVal, Type xType, out object result)
        {
            var valueUpdated = true;
            if (xType == TypeClass.Int64Clazz || xType == TypeClass.DecimalClazz)
            {
                result = dateTime.Ticks;
            }
            else
            {
                result = defaultVal;
                valueUpdated = false;
            }

            return valueUpdated;
        }

        private static bool FromDateTimeToNullableNumericType(DateTime dateTime, Type innerType, out object result)
        {
            var valueUpdated = true;

            if (innerType == TypeClass.Int64Clazz || innerType == TypeClass.DecimalClazz)
            {
                result = dateTime.Ticks;
            }
            else
            {
                result = null;
                valueUpdated = false;
            }

            return valueUpdated;
        }
    }
}