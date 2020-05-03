using System;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Judgments;
using Cosmos.Optionals;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// Conversion extensions
    /// </summary>
    public static partial class ConversionExtensions {
        private static readonly CastingContext DefaultContext = new CastingContext();

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <returns></returns>
        public static TTo CastTo<TFrom, TTo>(TFrom fromObj, TTo defaultVal = default) => CastTo(fromObj, DefaultContext, defaultVal);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="context"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <returns></returns>
        public static TTo CastTo<TFrom, TTo>(TFrom fromObj, CastingContext context, TTo defaultVal = default) {
            var targetObjType = typeof(TTo);
            var sourceObjType = typeof(TFrom);

            if (fromObj is string fromStr) {
                return fromStr.CastTo(targetObjType, context, defaultVal).As<TTo>();
            }

            if (targetObjType == typeof(string)) {
                var defaultStr = defaultVal.SafeString();
                switch (fromObj) {
                    case short _0:
                        return _0.CastToString(defaultStr).As<TTo>();
                    case ushort _1:
                        return _1.CastToString(defaultStr).As<TTo>();
                    case int _2:
                        return _2.CastToString(defaultStr).As<TTo>();
                    case uint _3:
                        return _3.CastToString(defaultStr).As<TTo>();
                    case long _4:
                        return _4.CastToString(defaultStr).As<TTo>();
                    case ulong _5:
                        return _5.CastToString(defaultStr).As<TTo>();
                    case float _6:
                        return _6.CastToString(defaultStr).As<TTo>();
                    case double _7:
                        return _7.CastToString(defaultStr).As<TTo>();
                    case decimal _8:
                        return _8.CastToString(defaultStr).As<TTo>();
                    case DateTime _9: {
                        var format = context.Format;
                        if (string.IsNullOrWhiteSpace(format))
                            format = "yyyy-MM-dd HH:mm:ss";
                        return context.DateTimeFormatStyles switch {
                            DateTimeFormatStyles.Normal    => _9.ToString(format, context.FormatProvider).As<TTo>(),
                            DateTimeFormatStyles.Date      => _9.ToDateString().As<TTo>(),
                            DateTimeFormatStyles.Time      => _9.ToTimeString().As<TTo>(),
                            DateTimeFormatStyles.DateTime  => _9.ToDateTimeString().As<TTo>(),
                            DateTimeFormatStyles.LongDate  => _9.ToLongDateString().As<TTo>(),
                            DateTimeFormatStyles.LongTime  => _9.ToLongTimeString().As<TTo>(),
                            DateTimeFormatStyles.ShortDate => _9.ToShortDateString().As<TTo>(),
                            DateTimeFormatStyles.ShortTime => _9.ToShortTimeString().As<TTo>(),
                            DateTimeFormatStyles.Local     => _9.ToLocalTime().ToString(format, context.FormatProvider).As<TTo>(),
                            DateTimeFormatStyles.Universal => _9.ToUniversalTime().ToString(format, context.FormatProvider).As<TTo>(),
                            _                              => _9.ToString(format, context.FormatProvider).As<TTo>()
                        };
                    }
                    case Guid _10:
                        return _10.ToString(context.GuidFormatStyles.X(), context.FormatProvider).As<TTo>();
                    case bool _11:
                        return _11.ToString("true", "false").CastTo<TTo>();
                    case Encoding _12:
                        return _12.EncodingName.CastTo<TTo>();
                    default:
                        return fromObj.CastToString().As<TTo>();
                }
            }

            if (sourceObjType.IsEnum && TypeJudgment.IsNumericType(targetObjType)) {
                return CastEnumToNumericProxy(sourceObjType, fromObj, targetObjType, defaultVal);
            }

            if (TypeJudgment.IsNumericType(sourceObjType) && targetObjType.IsEnum) {
                return EnumsNET.Enums.GetMember(targetObjType, fromObj).Value.As<TTo>();
            }

            try {
                return Convert.ChangeType(fromObj, targetObjType, context.FormatProvider).AsOrDefault(defaultVal);
            } catch {
                return defaultVal;
            }
        }

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="validation"></param>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <returns></returns>
        public static TTo CastTo<TFrom, TTo>(TFrom fromObj, EnumValidation validation = EnumValidation.None) where TTo : struct, Enum =>
            EnumsNET.Enums.ToObject<TTo>(fromObj, validation);
    }
}