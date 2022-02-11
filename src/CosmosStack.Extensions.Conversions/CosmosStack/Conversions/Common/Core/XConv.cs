using System;
using CosmosStack.Conversions.ObjectMappingServices;
using CosmosStack.Exceptions;
using CosmosStack.ObjectMapping;
using CosmosStack.Reflection;

// ReSharper disable InconsistentNaming

namespace CosmosStack.Conversions.Common.Core
{
    internal static class XConvHelper
    {
        public static T T<T>(Func<T> func, T defaultVal)
        {
            return Try.Create(func).Recover(_ => defaultVal).Value;
        }

        public static T T<T>(Func<T> func1, Func<T> func2, T defaultVal)
        {
            return Try.Create(func1).Recover(_ => func2()).Recover(_ => defaultVal).Value;
        }

        public static bool I<T>(Func<T> func)
        {
            return Try.Create(func).IsSuccess;
        }

        public static bool D<TSource, TTarget>(
            TSource source,
            Func<TSource, bool> @is,
            TTarget defaultVal,
            Func<TSource, TTarget, TTarget> to,
            out TTarget val)
        {
            val = default;

            if (@is(source))
            {
                val = to(source, defaultVal);
                return true;
            }

            return false;
        }
    }

    internal static partial class XConv
    {
        public static X To<O, X>(O from, X defaultVal = default, CastingContext context = null, IObjectMapper mapper = null)
        {
            var oType = typeof(O);
            var xType = typeof(X);
            var oTypeNullableFlag = Types.IsNullableType(oType);
            var xTypeNullableFlag = Types.IsNullableType(xType);

            context ??= CastingContext.DefaultContext;

            if (xType.IsValueType && defaultVal is null)
                defaultVal = Activator.CreateInstance<X>();

            if (from is null)
            {
                return defaultVal;
            }

            if (oType == xType)
            {
                return from.AsOrDefault(defaultVal);
            }

            if (CustomConvertManager.TryGetConvertHandler(oType, xType, out var handler))
            {
                return (handler?.Invoke(from)).As<X>() ?? defaultVal;
            }

            if (from is string strFrom)
            {
                return FromStringTo(strFrom, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is DateTime dtFrom)
            {
                return FromDateTimeTo(dtFrom, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is bool boolFrom)
            {
                return FromBooleanTo(boolFrom, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (TypeDeterminer.IsEnumType(oType))
            {
                return FromEnumTo(oType, from, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (TypeDeterminer.IsNullableNumericType(oType) || Types.IsNumericType(oType))
            {
                return FromNumericTo(oType, oTypeNullableFlag, from, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is Guid guid)
            {
                return FromGuidTo(guid, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (TypeDeterminer.IsNullableGuidType(oType))
            {
                return FromNullableGuidTo(from.As<Guid?>(), context, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is IConvertible)
            {
                return Convert.ChangeType(from, xType).As<X>();
            }

            if (oType == TypeClass.ObjectClazz)
            {
                return FromObjTo(from, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (xType == TypeClass.ObjectClazz)
            {
                return from.As<X>();
            }

            if (xType.IsAssignableFrom(oType))
            {
                return from.As<X>();
            }

            if (mapper != null)
            {
                return mapper.MapTo<O, X>(from);
            }

            try
            {
                return from.As<X>();
            }
            catch
            {
                try
                {
                    return DefaultObjectMapper.Instance.MapTo<O, X>(from);
                }
                catch
                {
                    return xTypeNullableFlag ? default : defaultVal;
                }
            }
        }

        public static object To(object from, Type sourceType, Type targetType,
            object defaultVal = default, CastingContext context = null, IObjectMapper mapper = null)
        {
            var oType = sourceType;
            var xType = targetType;
            var oTypeNullableFlag = Types.IsNullableType(oType);
            var xTypeNullableFlag = Types.IsNullableType(xType);

            context ??= CastingContext.DefaultContext;

            if (xType.IsValueType && defaultVal is null)
                defaultVal = Activator.CreateInstance(xType);

            if (from is null)
            {
                return defaultVal;
            }

            if (oType == xType)
            {
                return from.AsOrDefault(defaultVal);
            }

            if (from is string strFrom)
            {
                return FromStringTo(strFrom, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is DateTime dtFrom)
            {
                return FromDateTimeTo(dtFrom, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is bool boolFrom)
            {
                return FromBooleanTo(boolFrom, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (TypeDeterminer.IsEnumType(oType))
            {
                return FromEnumTo(oType, from, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (TypeDeterminer.IsNullableNumericType(oType) || Types.IsNumericType(oType))
            {
                return FromNumericTo(oType, oTypeNullableFlag, from, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is Guid guid)
            {
                return FromGuidTo(guid, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (TypeDeterminer.IsNullableGuidType(oType))
            {
                return FromNullableGuidTo(from.As<Guid?>(), context, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is IConvertible)
            {
                return Convert.ChangeType(from, xType);
            }

            if (oType == TypeClass.ObjectClazz)
            {
                return FromObjTo(from, oType, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (xType == TypeClass.ObjectClazz)
            {
                return Convert.ChangeType(from, xType);
            }

            if (xType.IsAssignableFrom(oType))
            {
                return from;
            }

            if (mapper != null)
            {
                return mapper.MapTo(oType, xType, from);
            }

            try
            {
                return Convert.ChangeType(from, xType, context.FormatProvider).AsOrDefault(defaultVal);
            }
            catch
            {
                try
                {
                    return DefaultObjectMapper.Instance.MapTo(oType, xType, from);
                }
                catch
                {
                    return xTypeNullableFlag ? default : defaultVal;
                }
            }
        }
    }
}