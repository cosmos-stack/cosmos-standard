using System;
using Cosmos.Judgments;

// ReSharper disable InconsistentNaming

namespace Cosmos.Conversions.Core {
    internal static partial class XConv {
        public static X To<O, X>(O from, X defaultVal = default, CastingContext context = null, IObjectMapper mapper = null) {
            var oType = typeof(O);
            var xType = typeof(X);
            var oTypeNullableFlag = TypeJudgment.IsNullableType(oType);
            var xTypeNullableFlag = TypeJudgment.IsNullableType(xType);

            context ??= CastingContext.DefaultContext;

            if (xType.IsValueType && defaultVal is null)
                defaultVal = Activator.CreateInstance<X>();

            if (from is null) {
                return defaultVal;
            }

            if (oType == xType) {
                return from.AsOrDefault(defaultVal);
            }

            if (from is string strFrom) {
                return FromStringTo(strFrom, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is DateTime dtFrom) {
                return FromDateTimeTo(dtFrom, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is bool boolFrom) {
                return FromBooleanTo(boolFrom, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (TypeHelper.IsEnumType(oType)) {
                return FromEnumTo(oType, from, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (TypeHelper.IsNullableNumericType(oType) || TypeHelper.IsNumericType(oType)) {
                return FromNumericTo(oType, oTypeNullableFlag, from, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is Guid guid) {
                return FromGuidTo(guid, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (TypeHelper.IsNullableGuidType(oType)) {
                return FromNullableGuidTo(from.As<Guid?>(), context, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is IConvertible) {
                return Convert.ChangeType(from, xType).As<X>();
            }

            if (oType == TypeClass.ObjectClass) {
                return FromObjTo(from, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (xType == TypeClass.ObjectClass) {
                return from.As<X>();
            }

            if (xType.IsAssignableFrom(oType)) {
                return from.As<X>();
            }

            if (mapper != null) {
                return mapper.MapTo<O, X>(from);
            }

            try {
                return from.As<X>();
            } catch {
                try {
                    return Mapper.DefaultMapper.Instance.MapTo<O, X>(from);
                } catch {
                    return xTypeNullableFlag ? default : defaultVal;
                }
            }
        }

        public static object To(object from, Type sourceType, Type targetType,
            object defaultVal = default, CastingContext context = null, IObjectMapper mapper = null) {
            var oType = sourceType;
            var xType = targetType;
            var oTypeNullableFlag = TypeJudgment.IsNullableType(oType);
            var xTypeNullableFlag = TypeJudgment.IsNullableType(xType);

            context ??= CastingContext.DefaultContext;

            if (xType.IsValueType && defaultVal is null)
                defaultVal = Activator.CreateInstance(xType);

            if (from is null) {
                return defaultVal;
            }

            if (oType == xType) {
                return from.AsOrDefault(defaultVal);
            }

            if (from is string strFrom) {
                return FromStringTo(strFrom, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is DateTime dtFrom) {
                return FromDateTimeTo(dtFrom, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is bool boolFrom) {
                return FromBooleanTo(boolFrom, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (TypeHelper.IsEnumType(oType)) {
                return FromEnumTo(oType, from, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (TypeHelper.IsNullableNumericType(oType) || TypeHelper.IsNumericType(oType)) {
                return FromNumericTo(oType, oTypeNullableFlag, from, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is Guid guid) {
                return FromGuidTo(guid, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (TypeHelper.IsNullableGuidType(oType)) {
                return FromNullableGuidTo(from.As<Guid?>(), context, xType, xTypeNullableFlag, defaultVal);
            }

            if (from is IConvertible) {
                return Convert.ChangeType(from, xType);
            }

            if (oType == TypeClass.ObjectClass) {
                return FromObjTo(from, oType, context, xType, xTypeNullableFlag, defaultVal);
            }

            if (xType == TypeClass.ObjectClass) {
                return Convert.ChangeType(from, xType);
            }

            if (xType.IsAssignableFrom(oType)) {
                return from;
            }

            if (mapper != null) {
                return mapper.MapTo(oType, xType, from);
            }

            try {
                return Convert.ChangeType(from, xType, context.FormatProvider).AsOrDefault(defaultVal);
            } catch {
                try {
                    return Mapper.DefaultMapper.Instance.MapTo(oType, xType, from);
                } catch {
                    return xTypeNullableFlag ? default : defaultVal;
                }
            }
        }
    }
}