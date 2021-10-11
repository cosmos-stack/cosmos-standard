using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CosmosStack.Exceptions;

namespace CosmosStack
{
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfTrue(this bool @this, Action action)
        {
            if (@this)
            {
                action?.Invoke();
            }
        }

        /// <summary>
        /// If true... <br />
        /// 如果为 True...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        /// <param name="context"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfTrue<T>(this bool @this, Action<T> action, T context)
        {
            if (@this)
            {
                action?.Invoke(context);
            }
        }

        /// <summary>
        /// If false... <br />
        /// 如果为 False...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfFalse(this bool @this, Action action)
        {
            if (!@this)
            {
                action?.Invoke();
            }
        }

        /// <summary>
        /// If false... <br />
        /// 如果为 False...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        /// <param name="context"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfFalse<T>(this bool @this, Action<T> action, T context)
        {
            if (!@this)
            {
                action?.Invoke(context);
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ifttt(this bool condition, Action @this, Action that)
        {
            if (condition)
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
        /// <param name="condition"></param>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue Ifttt<TValue>(this bool condition, Func<TValue> @this, Func<TValue> @that)
        {
            if (condition)
            {
                return @this == null ? default : @this.Invoke();
            }
            else
            {
                return that == null ? default : that.Invoke();
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfTrueThenThrow(this bool @this, Exception exception)
        {
            @this.IfTrue(() => ExceptionHelper.PrepareForRethrow(exception));
        }

        /// <summary>
        /// If false then throw exception <br />
        /// 如果 False 那么就抛出异常
        /// </summary>
        /// <param name="this"></param>
        /// <param name="exception"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfFalseThenThrow(this bool @this, Exception exception)
        {
            @this.IfFalse(() => ExceptionHelper.PrepareForRethrow(exception));
        }

        #endregion

        #region If then invoke

        /// <summary>
        /// If true then invoke... <br />
        /// 如果 True 那么就执行...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IfTrueThenInvoke(this bool @this, Func<bool> func)
        {
            if (@this)
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
        /// <param name="context"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IfTrueThenInvoke<T>(this bool @this, Func<T, bool> func, T context)
        {
            if (@this)
            {
                @this = func?.Invoke(context) ?? false;
            }

            return @this;
        }

        /// <summary>
        /// If true then invoke... <br />
        /// 如果 True 那么就执行...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IfTrueThenInvoke(this bool @this, Action action)
        {
            @this.IfTrue(action);
            return @this;
        }

        /// <summary>
        /// If true then invoke... <br />
        /// 如果 True 那么就执行...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        /// <param name="context"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IfTrueThenInvoke<T>(this bool @this, Action<T> action, T context)
        {
            @this.IfTrue(action, context);
            return @this;
        }

        /// <summary>
        /// If false then invoke... <br />
        /// 如果 False 那么就执行...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IfFalseThenInvoke(this bool @this, Func<bool> func)
        {
            if (!@this)
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
        /// <param name="context"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IfFalseThenInvoke<T>(this bool @this, Func<T, bool> func, T context)
        {
            if (!@this)
            {
                @this = func?.Invoke(context) ?? false;
            }

            return @this;
        }

        /// <summary>
        /// If false then invoke... <br />
        /// 如果 False 那么就执行...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IfFalseThenInvoke(this bool @this, Action action)
        {
            @this.IfFalse(action);
            return @this;
        }

        /// <summary>
        /// If false then invoke... <br />
        /// 如果 False 那么就执行...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        /// <param name="context"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IfFalseThenInvoke<T>(this bool @this, Action<T> action, T context)
        {
            @this.IfFalse(action, context);
            return @this;
        }

        #endregion

        #region To binary

        /// <summary>
        /// To binary <br />
        /// 转换为二进制值
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static byte ToBinary(this bool @this) => Convert.ToByte(@this);

        #endregion

        #region To string

        /// <summary>
        /// If true then this, else that... <br />
        /// 如果为 True 就做这个，不然就做那个 ...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="trueString"></param>
        /// <param name="falseString"></param>
        /// <returns></returns>
        public static string ToString(this bool @this, string trueString, string falseString) =>
            @this ? trueString : falseString;

        #endregion

        #region Then

        /// <summary>
        /// Invoke and return true <br />
        /// 执行并返回 True
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool InvokeThenTrue(this Action action)
        {
            action?.Invoke();
            return true;
        }

        /// <summary>
        /// Invoke and return false <br />
        /// 执行并返回 False
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool InvokeThenFalse(this Action action)
        {
            action?.Invoke();
            return false;
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
        /// <returns></returns>
        public static bool And(this bool current, Func<bool> next)
        {
            if (!current) return false;
            return next?.Invoke() ?? false;
        }

        /// <summary>
        /// And <br />
        /// 并且
        /// </summary>
        /// <param name="current"></param>
        /// <param name="nextSet"></param>
        /// <returns></returns>
        public static bool And(this bool current, IEnumerable<Func<bool>> nextSet)
        {
            if (!current) return false;
            foreach (var next in nextSet)
                if (!(next?.Invoke() ?? false))
                    return false;
            return true;
        }

        /// <summary>
        /// And <br />
        /// 并且
        /// </summary>
        /// <param name="current"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static bool And(this bool current, bool next)
        {
            if (!current) return false;
            return next;
        }

        /// <summary>
        /// Or <br />
        /// 或者
        /// </summary>
        /// <param name="current"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static bool Or(this bool current, Func<bool> next)
        {
            if (current) return true;
            return next?.Invoke() ?? false;
        }

        /// <summary>
        /// Or <br />
        /// 或者
        /// </summary>
        /// <param name="current"></param>
        /// <param name="nextSet"></param>
        /// <returns></returns>
        public static bool Or(this bool current, IEnumerable<Func<bool>> nextSet)
        {
            if (current) return true;
            foreach (var next in nextSet)
                if (next?.Invoke() ?? false)
                    return true;
            return false;
        }

        /// <summary>
        /// Or <br />
        /// 或者
        /// </summary>
        /// <param name="current"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static bool Or(this bool current, bool next)
        {
            if (current) return true;
            return next;
        }
    }
}