using System;
using System.Collections.Generic;
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
        public static void IfTrue(this BooleanVal2 @this, Action action)
        {
            if (@this is not null && @this.IsT0())
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
        public static void IfTrue<T>(this BooleanVal2 @this, Action<T> action, T context)
        {
            if (@this is not null && @this.IsT0())
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
        public static void IfFalse(this BooleanVal2 @this, Action action)
        {
            if (@this is not null && @this.IsT1())
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
        public static void IfFalse<T>(this BooleanVal2 @this, Action<T> action, T context)
        {
            if (@this is not null && @this.IsT1())
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
        public static void Ifttt(this BooleanVal2 condition, Action @this, Action that)
        {
            condition?.Switch(
                _ => @this?.Invoke(),
                _ => that?.Invoke());
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
        public static TValue Ifttt<TValue>(this BooleanVal2 condition, Func<TValue> @this, Func<TValue> @that)
        {
            if (condition is null)
                return default;
            return condition.Match(
                _ => @this is null ? default : @this.Invoke(),
                _ => that is null ? default : that.Invoke());
        }

        #endregion

        #region If this then throw

        /// <summary>
        /// If true then throw exception <br />
        /// 如果 True 那么就抛出异常
        /// </summary>
        /// <param name="this"></param>
        /// <param name="exception"></param>
        public static void IfTrueThenThrow(this BooleanVal2 @this, Exception exception)
        {
            @this.IfTrue(() => ExceptionHelper.PrepareForRethrow(exception));
        }

        /// <summary>
        /// If false then throw exception <br />
        /// 如果 False 那么就抛出异常
        /// </summary>
        /// <param name="this"></param>
        /// <param name="exception"></param>
        public static void IfFalseThenThrow(this BooleanVal2 @this, Exception exception)
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
        public static BooleanVal2 IfTrueThenInvoke(this BooleanVal2 @this, Func<BooleanVal2> func)
        {
            if (@this is not null && @this.IsT0())
            {
                @this = func?.Invoke() ?? BooleanVal2.FalseVal;
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
        public static BooleanVal2 IfTrueThenInvoke<T>(this BooleanVal2 @this, Func<T, BooleanVal2> func, T context)
        {
            if (@this is not null && @this.IsT0())
            {
                @this = func?.Invoke(context) ?? BooleanVal2.FalseVal;
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
        public static BooleanVal2 IfTrueThenInvoke(this BooleanVal2 @this, Action action)
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
        public static BooleanVal2 IfTrueThenInvoke<T>(this BooleanVal2 @this, Action<T> action, T context)
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
        public static BooleanVal2 IfFalseThenInvoke(this BooleanVal2 @this, Func<BooleanVal2> func)
        {
            if (@this is not null && @this.IsT1())
            {
                @this = func?.Invoke() ?? BooleanVal2.FalseVal;
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
        public static BooleanVal2 IfFalseThenInvoke<T>(this BooleanVal2 @this, Func<T, BooleanVal2> func, T context)
        {
            if (@this is not null && @this.IsT1())
            {
                @this = func?.Invoke(context) ?? BooleanVal2.FalseVal;
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
        public static BooleanVal2 IfFalseThenInvoke(this BooleanVal2 @this, Action action)
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
        public static BooleanVal2 IfFalseThenInvoke<T>(this BooleanVal2 @this, Action<T> action, T context)
        {
            @this.IfFalse(action, context);
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
        /// <returns></returns>
        public static BooleanVal2 And(this BooleanVal2 current, Func<BooleanVal2> next)
        {
            if (current is null)
                return BooleanVal2.FalseVal;
            if (current.IsT1())
                return BooleanVal2.FalseVal;
            return next?.Invoke() ?? BooleanVal2.FalseVal;
        }

        /// <summary>
        /// And <br />
        /// 并且
        /// </summary>
        /// <param name="current"></param>
        /// <param name="nextSet"></param>
        /// <returns></returns>
        public static BooleanVal2 And(this BooleanVal2 current, IEnumerable<Func<BooleanVal2>> nextSet)
        {
            if (current is null)
                return BooleanVal2.FalseVal;
            if (current.IsT1())
                return BooleanVal2.FalseVal;
            foreach (var next in nextSet)
                if (!(next?.Invoke() ?? false))
                    return BooleanVal2.FalseVal;
            return BooleanVal2.TrueVal;
        }

        /// <summary>
        /// And <br />
        /// 并且
        /// </summary>
        /// <param name="current"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static BooleanVal2 And(this BooleanVal2 current, BooleanVal2 next)
        {
            if (current is null)
                return BooleanVal2.FalseVal;
            if (current.IsT1())
                return BooleanVal2.FalseVal;
            return next;
        }

        /// <summary>
        /// Or <br />
        /// 或者
        /// </summary>
        /// <param name="current"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static BooleanVal2 Or(this BooleanVal2 current, Func<BooleanVal2> next)
        {
            if (current is null)
                return BooleanVal2.FalseVal;
            if (current.IsT0())
                return BooleanVal2.TrueVal;
            return next?.Invoke() ?? BooleanVal2.FalseVal;
        }

        /// <summary>
        /// Or <br />
        /// 或者
        /// </summary>
        /// <param name="current"></param>
        /// <param name="nextSet"></param>
        /// <returns></returns>
        public static BooleanVal2 Or(this BooleanVal2 current, IEnumerable<Func<BooleanVal2>> nextSet)
        {
            if (current is null)
                return BooleanVal2.FalseVal;
            if (current.IsT0())
                return BooleanVal2.TrueVal;
            foreach (var next in nextSet)
                if (next?.Invoke() ?? false)
                    return BooleanVal2.TrueVal;
            return BooleanVal2.FalseVal;
        }

        /// <summary>
        /// Or <br />
        /// 或者
        /// </summary>
        /// <param name="current"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static BooleanVal2 Or(this BooleanVal2 current, BooleanVal2 next)
        {
            if (current is null)
                return BooleanVal2.FalseVal;
            if (current.IsT1())
                return BooleanVal2.TrueVal;
            return next;
        }
    }
}