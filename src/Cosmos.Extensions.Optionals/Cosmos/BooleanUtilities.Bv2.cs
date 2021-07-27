using System;
using System.Collections.Generic;
using Cosmos.Exceptions;

namespace Cosmos
{
    /// <summary>
    /// Boolean extensions
    /// </summary>
    public static partial class BooleanExtensions
    {
        #region If

        /// <summary>
        /// If true...
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
        /// If true...
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
        /// If false...
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
        /// If false...
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
        /// If this then that...
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
        /// If this then that...
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
        /// If true then throw exception
        /// </summary>
        /// <param name="this"></param>
        /// <param name="exception"></param>
        public static void IfTrueThenThrow(this BooleanVal2 @this, Exception exception)
        {
            @this.IfTrue(() => ExceptionHelper.PrepareForRethrow(exception));
        }

        /// <summary>
        /// If false then throw exception
        /// </summary>
        /// <param name="this"></param>
        /// <param name="exception"></param>
        public static void IfFalseThenThrow(this BooleanVal2 @this, Exception exception)
        {
            @this.IfFalse(() => ExceptionHelper.PrepareForRethrow(exception));
        }

        #endregion

        #region If then invoke

        public static BooleanVal2 IfTrueThenInvoke(this BooleanVal2 @this, Func<BooleanVal2> func)
        {
            if (@this is not null && @this.IsT0())
            {
                @this = func?.Invoke() ?? BooleanVal2.FalseVal;
            }

            return @this;
        }

        public static BooleanVal2 IfTrueThenInvoke<T>(this BooleanVal2 @this, Func<T, BooleanVal2> func, T context)
        {
            if (@this is not null && @this.IsT0())
            {
                @this = func?.Invoke(context) ?? BooleanVal2.FalseVal;
            }

            return @this;
        }

        public static BooleanVal2 IfTrueThenInvoke(this BooleanVal2 @this, Action action)
        {
            @this.IfTrue(action);
            return @this;
        }

        public static BooleanVal2 IfTrueThenInvoke<T>(this BooleanVal2 @this, Action<T> action, T context)
        {
            @this.IfTrue(action, context);
            return @this;
        }

        public static BooleanVal2 IfFalseThenInvoke(this BooleanVal2 @this, Func<BooleanVal2> func)
        {
            if (@this is not null && @this.IsT1())
            {
                @this = func?.Invoke() ?? BooleanVal2.FalseVal;
            }

            return @this;
        }

        public static BooleanVal2 IfFalseThenInvoke<T>(this BooleanVal2 @this, Func<T, BooleanVal2> func, T context)
        {
            if (@this is not null && @this.IsT1())
            {
                @this = func?.Invoke(context) ?? BooleanVal2.FalseVal;
            }

            return @this;
        }

        public static BooleanVal2 IfFalseThenInvoke(this BooleanVal2 @this, Action action)
        {
            @this.IfFalse(action);
            return @this;
        }

        public static BooleanVal2 IfFalseThenInvoke<T>(this BooleanVal2 @this, Action<T> action, T context)
        {
            @this.IfFalse(action, context);
            return @this;
        }

        #endregion
    }

    public static partial class FluentBooleanExtensions
    {
        public static BooleanVal2 And(this BooleanVal2 current, Func<BooleanVal2> next)
        {
            if (current is null)
                return BooleanVal2.FalseVal;
            if (current.IsT1())
                return BooleanVal2.FalseVal;
            return next?.Invoke() ?? BooleanVal2.FalseVal;
        }

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

        public static BooleanVal2 And(this BooleanVal2 current, BooleanVal2 next)
        {
            if (current is null)
                return BooleanVal2.FalseVal;
            if (current.IsT1())
                return BooleanVal2.FalseVal;
            return next;
        }

        public static BooleanVal2 Or(this BooleanVal2 current, Func<BooleanVal2> next)
        {
            if (current is null)
                return BooleanVal2.FalseVal;
            if (current.IsT0())
                return BooleanVal2.TrueVal;
            return next?.Invoke() ?? BooleanVal2.FalseVal;
        }

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