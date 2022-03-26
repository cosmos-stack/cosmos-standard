using Cosmos.Exceptions;

namespace Cosmos;

/// <summary>
/// Boolean extensions <br />
/// 布尔值扩展
/// </summary>
public static partial class BooleanExtensions
{
    #region If

    /// <summary>
    /// If true... <br />
    /// 如果为 True...
    /// </summary>
    /// <param name="this"></param>
    /// <param name="action"></param>
    public static void IfTrue<T>(this BooleanVal<T> @this, Action<T> action)
    {
        if (@this.Value)
        {
            action?.Invoke(@this.Object);
        }
    }

    /// <summary>
    /// If false... <br />
    /// 如果为 False...
    /// </summary>
    /// <param name="this"></param>
    /// <param name="action"></param>
    public static void IfFalse<T>(this BooleanVal<T> @this, Action<T> action)
    {
        if (!@this.Value)
        {
            action?.Invoke(@this.Object);
        }
    }

    #endregion

    #region If this then that

    /// <summary>
    /// If this then that... <br />
    /// 如果这样那么就那样
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="this"></param>
    /// <param name="that"></param>
    public static void Ifttt<T>(this BooleanVal<T> condition, Action @this, Action that)
    {
        if (condition.Value)
        {
            @this?.Invoke();
        }
        else
        {
            that?.Invoke();
        }
    }

    /// <summary>
    /// If this then that... <br />
    /// 如果这样那么就那样
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="condition"></param>
    /// <param name="this"></param>
    /// <param name="that"></param>
    /// <returns></returns>
    public static TValue Ifttt<T, TValue>(this BooleanVal<T> condition, Func<T, TValue> @this, Func<T, TValue> @that)
    {
        if (condition.Value)
        {
            return @this is null ? default : @this.Invoke(condition.Object);
        }
        else
        {
            return that is null ? default : that.Invoke(condition.Object);
        }
    }

    #endregion

    #region If this then throw

    /// <summary>
    /// If true then throw exception <br />
    /// 如果 True 那么就抛出异常
    /// </summary>
    /// <param name="this"></param>
    /// <param name="exception"></param>
    public static void IfTrueThenThrow<T>(this BooleanVal<T> @this, Exception exception)
    {
        @this.IfTrue(_ => ExceptionHelper.PrepareForRethrow(exception));
    }

    /// <summary>
    /// If true then throw exception <br />
    /// 如果 True 那么就抛出异常
    /// </summary>
    /// <param name="this"></param>
    /// <param name="exceptionFunc"></param>
    public static void IfTrueThenThrow<T>(this BooleanVal<T> @this, Func<T, Exception> exceptionFunc)
    {
        @this.IfTrue(val => ExceptionHelper.PrepareForRethrow(exceptionFunc.Invoke(val)));
    }

    /// <summary>
    /// If false then throw exception <br />
    /// 如果 False 那么就抛出异常
    /// </summary>
    /// <param name="this"></param>
    /// <param name="exception"></param>
    public static void IfFalseThenThrow<T>(this BooleanVal<T> @this, Exception exception)
    {
        @this.IfFalse(_ => ExceptionHelper.PrepareForRethrow(exception));
    }

    /// <summary>
    /// If false then throw exception <br />
    /// 如果 False 那么就抛出异常
    /// </summary>
    /// <param name="this"></param>
    /// <param name="exceptionFunc"></param>
    public static void IfFalseThenThrow<T>(this BooleanVal<T> @this, Func<T, Exception> exceptionFunc)
    {
        @this.IfFalse(val => ExceptionHelper.PrepareForRethrow(exceptionFunc.Invoke(val)));
    }

    #endregion

    #region If then invoke

    /// <summary>
    /// If true then invoke... <br />
    /// 如果 True 那么就执行...
    /// </summary>
    /// <param name="this"></param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> IfTrueThenInvoke<T>(this BooleanVal<T> @this, Func<bool> func)
    {
        if (@this.Value)
        {
            @this = func?.Invoke() ?? false;
        }

        return @this;
    }

    /// <summary>
    /// If true then invoke... <br />
    /// 如果 True 那么就执行...
    /// </summary>
    /// <param name="this"></param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> IfTrueThenInvoke<T>(this BooleanVal<T> @this, Func<T, bool> func)
    {
        if (@this.Value)
        {
            @this = func?.Invoke(@this.Object) ?? false;
        }

        return @this;
    }

    /// <summary>
    /// If false then invoke... <br />
    /// 如果 False 那么就执行...
    /// </summary>
    /// <param name="this"></param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> IfFalseThenInvoke<T>(this BooleanVal<T> @this, Func<bool> func)
    {
        if (!@this.Value)
        {
            @this = func?.Invoke() ?? false;
        }

        return @this;
    }

    /// <summary>
    /// If false then invoke... <br />
    /// 如果 False 那么就执行...
    /// </summary>
    /// <param name="this"></param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> IfFalseThenInvoke<T>(this BooleanVal<T> @this, Func<T, bool> func)
    {
        if (!@this.Value)
        {
            @this = func?.Invoke(@this.Object) ?? false;
        }

        return @this;
    }

    #endregion
}

/// <summary>
/// Fluent Boolean extensions <br />
/// 流畅布尔值扩展
/// </summary>
public static partial class FluentBooleanExtensions
{
    /// <summary>
    /// And <br />
    /// 并且
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <param name="context"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> And<T>(this bool current, Func<bool> next, T context)
    {
        if (!current) return false.ToBooleanVal(context);
        return (next?.Invoke() ?? false).ToBooleanVal(context);
    }

    /// <summary>
    /// And <br />
    /// 并且
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> And<T>(this bool current, Func<(bool, T)> next)
    {
        if (!current) return false;
        return next?.Invoke() ?? false.ToBooleanVal<T>();
    }

    /// <summary>
    /// And <br />
    /// 并且
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> And<T>(this bool current, Func<BooleanVal<T>> next)
    {
        if (!current) return false;
        return next?.Invoke() ?? false.ToBooleanVal<T>();
    }

    /// <summary>
    /// And <br />
    /// 并且
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <param name="context"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> And<T>(this bool current, Func<T, BooleanVal<T>> next, T context)
    {
        if (!current) return false.ToBooleanVal(context);
        return next?.Invoke(context) ?? false.ToBooleanVal(context);
    }

    /// <summary>
    /// And <br />
    /// 并且
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> And<T>(this BooleanVal<T> current, Func<(bool, T)> next)
    {
        if (!current.Value) return current; // means false
        return next?.Invoke() ?? current;
    }

    /// <summary>
    /// And <br />
    /// 并且
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> And<T>(this BooleanVal<T> current, Func<BooleanVal<T>> next)
    {
        if (!current.Value) return current; // means false
        return next?.Invoke() ?? current;
    }

    /// <summary>
    /// And <br />
    /// 并且
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> And<T>(this BooleanVal<T> current, Func<T, BooleanVal<T>> next)
    {
        if (!current.Value) return current; // means false
        return next?.Invoke(current.Object) ?? current;
    }

    /// <summary>
    /// And <br />
    /// 并且
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <param name="context"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> And<T>(this bool current, bool next, T context)
    {
        if (!current) return false.ToBooleanVal(context);
        return next.ToBooleanVal(context);
    }

    /// <summary>
    /// Or <br />
    /// 或者
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <param name="context"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> Or<T>(this bool current, Func<bool> next, T context)
    {
        if (current) return true.ToBooleanVal(context);
        return (next?.Invoke() ?? false).ToBooleanVal(context);
    }

    /// <summary>
    /// Or <br />
    /// 或者
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> Or<T>(this bool current, Func<(bool, T)> next)
    {
        if (current) return true;
        return next?.Invoke() ?? false.ToBooleanVal<T>();
    }

    /// <summary>
    /// Or <br />
    /// 或者
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> Or<T>(this bool current, Func<BooleanVal<T>> next)
    {
        if (current) return true;
        return next?.Invoke() ?? false.ToBooleanVal<T>();
    }

    /// <summary>
    /// Or <br />
    /// 或者
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <param name="context"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> Or<T>(this bool current, Func<T, BooleanVal<T>> next, T context)
    {
        if (current) return true.ToBooleanVal(context);
        return next?.Invoke(context) ?? false.ToBooleanVal(context);
    }

    /// <summary>
    /// Or <br />
    /// 或者
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> Or<T>(this BooleanVal<T> current, Func<(bool, T)> next)
    {
        if (current.Value) return current; // means true
        return next?.Invoke() ?? false.ToBooleanVal(current.Object);
    }

    /// <summary>
    /// Or <br />
    /// 或者
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> Or<T>(this BooleanVal<T> current, Func<BooleanVal<T>> next)
    {
        if (current.Value) return current; // means true
        return next?.Invoke() ?? false.ToBooleanVal(current.Object);
    }

    /// <summary>
    /// Or <br />
    /// 或者
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> Or<T>(this BooleanVal<T> current, Func<T, BooleanVal<T>> next)
    {
        if (current.Value) return current; // means true
        return next?.Invoke(current.Object) ?? false.ToBooleanVal(current.Object);
    }

    /// <summary>
    /// Or <br />
    /// 或者
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    /// <param name="context"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static BooleanVal<T> Or<T>(this bool current, bool next, T context)
    {
        if (current) return true.ToBooleanVal(context);
        return next.ToBooleanVal(context);
    }
}