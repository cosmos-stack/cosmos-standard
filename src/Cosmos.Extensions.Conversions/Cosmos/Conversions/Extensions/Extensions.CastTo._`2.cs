using System;
using Cosmos.Conversions.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions {
    /// <summary>
    /// Extensions for CastTo opts
    /// </summary>
    public static partial class CastToExtensions {

        /// <summary>
        /// Cast <see cref="object"/> to the TEnum.
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="validation"></param>
        /// <typeparam name="TObject"></typeparam>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static TEnum CastTo<TObject, TEnum>(TObject fromObj, EnumsNET.EnumValidation validation) where TEnum : struct, Enum =>
            EnumsNET.Enums.ToObject<TEnum>(fromObj, validation);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <returns></returns>
        public static TTo CastTo<TFrom, TTo>(TFrom fromObj, TTo defaultVal = default) => XConv.To(fromObj, defaultVal);

        /// <summary>
        /// Cast to
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="context"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <returns></returns>
        public static TTo CastTo<TFrom, TTo>(TFrom fromObj, CastingContext context, TTo defaultVal = default) => XConv.To(fromObj, defaultVal, context);
    }
}