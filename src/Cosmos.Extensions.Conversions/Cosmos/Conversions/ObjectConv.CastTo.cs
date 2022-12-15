using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;
using Cosmos.Reflection;
using Cosmos.Text;

namespace Cosmos.Conversions;

internal static class CastTypeHelper
{
    public static void Guard(Type type, [CallerArgumentExpression("type")] string parameter = null)
    {
        ArgumentNullException.ThrowIfNull(type, parameter);
    }
}

/// <summary>
/// Cosmos.Core casting extensions
/// </summary>
public static class CastingExtensions
{
    #region 0

    /// <summary>
    /// Cast <see cref="object"/> to given type.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="targetType"></param>
    /// <returns></returns>
    public static object CastTo(this object obj, Type targetType)
    {
        CastTypeHelper.Guard(targetType);
        return obj is null
            ? default
            : XConvFuncAccessor.GetCachedConvert(obj.GetType(), targetType)(obj, TypeDeterminer.GetDefaultValue(targetType), default, null);
        // return obj is null
        //     ? default
        //     : XConv.To(obj, obj.GetType(), targetType, TypeDeterminer.GetDefaultValue(targetType));
    }

    /// <summary>
    /// Cast <see cref="object"/> to given type.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="targetType"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    public static object CastTo(this object obj, Type targetType, object defaultVal)
    {
        CastTypeHelper.Guard(targetType);
        return obj is null
            ? defaultVal
            : XConvFuncAccessor.GetCachedConvert(obj.GetType(), targetType)(obj, defaultVal, default, null);
        // return obj is null
        //     ? defaultVal
        //     : XConv.To(obj, obj.GetType(), targetType, defaultVal);
    }

    /// <summary>
    /// Cast <see cref="object"/> to given type.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="sourceType"></param>
    /// <param name="targetType"></param>
    /// <returns></returns>
    public static object CastTo(this object obj, Type sourceType, Type targetType)
    {
        CastTypeHelper.Guard(sourceType);
        CastTypeHelper.Guard(targetType);
        return XConvFuncAccessor.GetCachedConvert(sourceType, targetType)(obj, TypeDeterminer.GetDefaultValue(targetType), default, null);
        // return XConv.To(obj, sourceType, targetType);
    }

    /// <summary>
    /// Cast <see cref="object"/> to given type.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="sourceType"></param>
    /// <param name="targetType"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    public static object CastTo(this object obj, Type sourceType, Type targetType, object defaultVal)
    {
        CastTypeHelper.Guard(sourceType);
        CastTypeHelper.Guard(targetType);
        return XConvFuncAccessor.GetCachedConvert(sourceType, targetType)(obj, defaultVal, default, null);
        // return XConv.To(obj, sourceType, targetType, defaultVal);
    }

    /// <summary>
    /// Cast <see cref="object"/> to the given type of <see cref="Enum"/>.
    /// </summary>
    /// <param name="fromObj"></param>
    /// <param name="enumTye"></param>
    /// <param name="validation"></param>
    /// <returns></returns>
    public static object CastTo(object fromObj, Type enumTye, EnumsNET.EnumValidation validation)
    {
        CastTypeHelper.Guard(enumTye);
        return EnumsNET.Enums.ToObject(enumTye, fromObj, validation);
    }

    /// <summary>
    /// Cast to
    /// </summary>
    /// <param name="str"></param>
    /// <param name="targetType"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    public static object CastTo(this string str, Type targetType, object defaultVal = default)
    {
        CastTypeHelper.Guard(targetType);
        var result = defaultVal;
        return str.Is(targetType, v => result = v)
            ? result
            : XConvFuncAccessor.GetCachedConvert(TypeClass.StringClazz, targetType)(str, defaultVal, default, null);
        // return str.Is(targetType, v => result = v)
        //     ? result
        //     : XConv.To(str, TypeClass.StringClazz, targetType, defaultVal);
    }

    /// <summary>
    /// Cast to
    /// </summary>
    /// <param name="str"></param>
    /// <param name="targetType"></param>
    /// <param name="defaultVal"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public static object CastTo(this string str, Type targetType, CastingContext context, object defaultVal = default)
    {
        CastTypeHelper.Guard(targetType);
        var result = defaultVal;
        context ??= CastingContext.DefaultContext;
        return str.Is(targetType, v => result = v)
            ? result
            : XConvFuncAccessor.GetCachedConvert(TypeClass.StringClazz, targetType)(str, defaultVal, context, null);
        // return str.Is(targetType, v => result = v)
        //     ? result
        //     : XConv.To(str, TypeClass.StringClazz, targetType, defaultVal, context);
    }

    /// <summary>
    /// Cast to
    /// </summary>
    /// <param name="str"></param>
    /// <param name="targetType"></param>
    /// <param name="defaultVal"></param>
    /// <param name="contextAct"></param>
    /// <returns></returns>
    public static object CastTo(this string str, Type targetType, Action<CastingContext> contextAct, object defaultVal = default)
    {
        CastTypeHelper.Guard(targetType);
        var result = defaultVal;
        var context = new CastingContext();
        contextAct?.Invoke(context);
        return str.Is(targetType, v => result = v)
            ? result
            : XConvFuncAccessor.GetCachedConvert(TypeClass.StringClazz, targetType)(str, defaultVal, context, null);
        // return str.Is(targetType, v => result = v)
        //     ? result
        //     : XConv.To(str, TypeClass.StringClazz, targetType, defaultVal, context);
    }

    /// <summary>
    /// Cast to nullable
    /// </summary>
    /// <param name="str"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static object CastToNullable(this string str, Type type)
    {
        CastTypeHelper.Guard(type);
        object result = default;
        return str.IsNullable(type, v => result = v, () => result = null)
            ? result
            : null;
    }

    /// <summary>
    /// Cast to nullable
    /// </summary>
    /// <param name="str"></param>
    /// <param name="type"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public static object CastToNullable(this string str, Type type, CastingContext context)
    {
        CastTypeHelper.Guard(type);
        object result = default!;
        context ??= CastingContext.DefaultContext;
        return str.IsNullable(type, context, v => result = v, () => result = null)
            ? result
            : null;
    }

    /// <summary>
    /// Cast to nullable
    /// </summary>
    /// <param name="str"></param>
    /// <param name="type"></param>
    /// <param name="contextAct"></param>
    /// <returns></returns>
    public static object CastToNullable(this string str, Type type, Action<CastingContext> contextAct)
    {
        CastTypeHelper.Guard(type);
        object result = default!;
        return str.IsNullable(type, contextAct, v => result = v, () => result = null)
            ? result
            : null;
    }

    #endregion

    #region 1

    /// <summary>
    /// Convert object to given type.
    /// </summary>
    /// <param name="obj"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T CastTo<T>(this object obj)
    {
        return obj is null
            ? default
            : XConvFuncAccessor.GetCachedConvert<T>(obj.GetType())(obj, default, default, null);
        // return obj is null
        //     ? default
        //     : XConv.To(obj, obj.GetType(), typeof(T)).As<T>();
    }

    /// <summary>
    /// Convert object to given type.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T CastTo<T>(this object obj, T defaultVal)
    {
        return obj is null
            ? defaultVal
            :  XConvFuncAccessor.GetCachedConvert<T>(obj.GetType())(obj, defaultVal, default, null);
        // return obj is null
        //     ? defaultVal
        //     : XConv.To(obj, obj.GetType(), typeof(T), defaultVal).As<T>();
    }

    /// <summary>
    /// Cast to
    /// </summary>
    /// <param name="str"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T CastTo<T>(this string str, T defaultVal = default)
    {
        T result = default;
        return str.Is<T>(v => result = v)
            ? result
            : XConvFuncAccessor.GetCachedConvert<string, T>()(str, defaultVal, default, null);
        //return str.Is<T>(v => result = v) ? result : XConv.To(str, defaultVal);
    }

    /// <summary>
    /// Cast to
    /// </summary>
    /// <param name="str"></param>
    /// <param name="context"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T CastTo<T>(this string str, CastingContext context, T defaultVal = default)
    {
        T result = default;
        return str.Is<T>(v => result = v)
            ? result
            : XConvFuncAccessor.GetCachedConvert<string, T>()(str, defaultVal, context, null);
        //return str.Is<T>(context, v => result = v) ? result : XConv.To(str, defaultVal, context);
    }

    /// <summary>
    /// Cast to
    /// </summary>
    /// <param name="str"></param>
    /// <param name="contextAct"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T CastTo<T>(this string str, Action<CastingContext> contextAct, T defaultVal = default)
    {
        T result = default;
        var context = new CastingContext();
        contextAct?.Invoke(context);
        return str.Is<T>(v => result = v)
            ? result
            : XConvFuncAccessor.GetCachedConvert<string, T>()(str, defaultVal, context, null);
        //return str.Is<T>(context, v => result = v) ? result : XConv.To(str, defaultVal, context);
    }

    /// <summary>
    /// Cast to nullable
    /// </summary>
    /// <param name="str"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? CastToNullable<T>(this string str) where T : struct
    {
        T? result = default;
        return str.IsNullable<T>(v => result = v, () => result = null) ? result : null;
    }

    /// <summary>
    /// Cast to nullable
    /// </summary>
    /// <param name="str"></param>
    /// <param name="context"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? CastToNullable<T>(this string str, CastingContext context) where T : struct
    {
        T? result = default;
        context ??= CastingContext.DefaultContext;
        return str.IsNullable<T>(context, v => result = v, () => result = null) ? result : null;
    }

    /// <summary>
    /// Cast to nullable
    /// </summary>
    /// <param name="str"></param>
    /// <param name="contextAct"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? CastToNullable<T>(this string str, Action<CastingContext> contextAct) where T : struct
    {
        T? result = default;
        var context = new CastingContext();
        contextAct?.Invoke(context);
        return str.IsNullable<T>(context, v => result = v, () => result = null) ? result : null;
    }

    #endregion

    #region 2

    /// <summary>
    /// Cast <see cref="object"/> to the TEnum.
    /// </summary>
    /// <param name="fromObj"></param>
    /// <param name="validation"></param>
    /// <typeparam name="TObject"></typeparam>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    public static TEnum CastTo<TObject, TEnum>(TObject fromObj, EnumsNET.EnumValidation validation) where TEnum : struct, Enum
    {
        return fromObj is null
            ? default
            : EnumsNET.Enums.ToObject<TEnum>(fromObj, validation);
    }

    /// <summary>
    /// Cast to
    /// </summary>
    /// <param name="fromObj"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="TFrom"></typeparam>
    /// <typeparam name="TTo"></typeparam>
    /// <returns></returns>
    public static TTo CastTo<TFrom, TTo>(TFrom fromObj, TTo defaultVal = default)
    {
        var handler = XConvFuncAccessor.GetCachedConvert<TFrom, TTo>();
        return handler(fromObj, defaultVal, default, null);
        //return XConv.To(fromObj, defaultVal);
    }

    /// <summary>
    /// Cast to
    /// </summary>
    /// <param name="fromObj"></param>
    /// <param name="context"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="TFrom"></typeparam>
    /// <typeparam name="TTo"></typeparam>
    /// <returns></returns>
    public static TTo CastTo<TFrom, TTo>(TFrom fromObj, CastingContext context, TTo defaultVal = default)
    {
        var handler = XConvFuncAccessor.GetCachedConvert<TFrom, TTo>();
        return handler(fromObj, defaultVal, context, null);
        // return XConv.To(fromObj, defaultVal, context);
    }

    #endregion
}