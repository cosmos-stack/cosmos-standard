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
        public static void IfTrue(this BooleanVal3 @this, Action action)
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
        public static void IfTrue<T>(this BooleanVal3 @this, Action<T> action, T context)
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
        public static void IfFalse(this BooleanVal3 @this, Action action)
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
        public static void IfFalse<T>(this BooleanVal3 @this, Action<T> action, T context)
        {
            if (@this is not null && @this.IsT1())
            {
                action?.Invoke(context);
            }
        }

        /// <summary>
        /// If null...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        public static void IfNull(this BooleanVal3 @this, Action action)
        {
            if (@this is null || @this.IsT2())
            {
                action?.Invoke();
            }
        }

        /// <summary>
        /// If null...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public static void IfNull<T>(this BooleanVal3 @this, Action<T> action, T context)
        {
            if (@this is null || @this.IsT2())
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
        public static void Ifttt(this BooleanVal3 condition, Action @this, Action that)
        {
            condition?.Switch(
                _ => @this?.Invoke(),
                _ => that?.Invoke(),
                _ => { });
        }

        /// <summary>
        /// If this then that...
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <param name="else"></param>
        public static void Ifttt(this BooleanVal3 condition, Action @this, Action that, Action @else)
        {
            condition?.Switch(
                _ => @this?.Invoke(),
                _ => that?.Invoke(),
                _ => @else?.Invoke());
        }

        /// <summary>
        /// If this then that...
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="condition"></param>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static TValue Ifttt<TValue>(this BooleanVal3 condition, Func<TValue> @this, Func<TValue> that)
        {
            if (condition is null)
                return default;
            return condition.Match(
                _ => @this is null ? default : @this.Invoke(),
                _ => that is null ? default : that.Invoke(),
                _ => default);
        }

        /// <summary>
        /// If this then that...
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="condition"></param>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static TValue Ifttt<TValue>(this BooleanVal3 condition, Func<TValue> @this, Func<TValue> that, Func<TValue> @else)
        {
            if (condition is null)
                return default;
            return condition.Match(
                _ => @this is null ? default : @this.Invoke(),
                _ => that is null ? default : that.Invoke(),
                _ => @else is null ? default : @else.Invoke());
        }

        #endregion

        #region If this then throw

        /// <summary>
        /// If true then throw exception
        /// </summary>
        /// <param name="this"></param>
        /// <param name="exception"></param>
        public static void IfTrueThenThrow(this BooleanVal3 @this, Exception exception)
        {
            @this.IfTrue(() => ExceptionHelper.PrepareForRethrow(exception));
        }

        /// <summary>
        /// If false then throw exception
        /// </summary>
        /// <param name="this"></param>
        /// <param name="exception"></param>
        public static void IfFalseThenThrow(this BooleanVal3 @this, Exception exception)
        {
            @this.IfFalse(() => ExceptionHelper.PrepareForRethrow(exception));
        }

        /// <summary>
        /// If null then throw exception
        /// </summary>
        /// <param name="this"></param>
        /// <param name="exception"></param>
        public static void IfNullThenThrow(this BooleanVal3 @this, Exception exception)
        {
            @this.IfNull(() => ExceptionHelper.PrepareForRethrow(exception));
        }

        #endregion

        #region If then invoke

        public static BooleanVal3 IfTrueThenInvoke(this BooleanVal3 @this, Func<BooleanVal3> func)
        {
            if (@this is not null && @this.IsT0())
            {
                @this = func?.Invoke() ?? BooleanVal3.FalseVal;
            }

            return @this;
        }

        public static BooleanVal3 IfTrueThenInvoke<T>(this BooleanVal3 @this, Func<T, BooleanVal3> func, T context)
        {
            if (@this is not null && @this.IsT0())
            {
                @this = func?.Invoke(context) ?? BooleanVal3.FalseVal;
            }

            return @this;
        }

        public static BooleanVal3 IfTrueThenInvoke(this BooleanVal3 @this, Action action)
        {
            @this.IfTrue(action);
            return @this;
        }

        public static BooleanVal3 IfTrueThenInvoke<T>(this BooleanVal3 @this, Action<T> action, T context)
        {
            @this.IfTrue(action, context);
            return @this;
        }

        public static BooleanVal3 IfFalseThenInvoke(this BooleanVal3 @this, Func<BooleanVal3> func)
        {
            if (@this is not null && @this.IsT1())
            {
                @this = func?.Invoke() ?? BooleanVal3.FalseVal;
            }

            return @this;
        }

        public static BooleanVal3 IfFalseThenInvoke<T>(this BooleanVal3 @this, Func<T, BooleanVal3> func, T context)
        {
            if (@this is not null && @this.IsT1())
            {
                @this = func?.Invoke(context) ?? BooleanVal3.FalseVal;
            }

            return @this;
        }

        public static BooleanVal3 IfFalseThenInvoke(this BooleanVal3 @this, Action action)
        {
            @this.IfFalse(action);
            return @this;
        }

        public static BooleanVal3 IfFalseThenInvoke<T>(this BooleanVal3 @this, Action<T> action, T context)
        {
            @this.IfFalse(action, context);
            return @this;
        }

        public static BooleanVal3 IfNullThenInvoke(this BooleanVal3 @this, Func<BooleanVal3> func)
        {
            if (@this is null || @this.IsT2())
            {
                @this = func?.Invoke() ?? BooleanVal3.FalseVal;
            }

            return @this;
        }

        public static BooleanVal3 IfNullThenInvoke<T>(this BooleanVal3 @this, Func<T, BooleanVal3> func, T context)
        {
            if (@this is null || @this.IsT2())
            {
                @this = func?.Invoke(context) ?? BooleanVal3.FalseVal;
            }

            return @this;
        }

        public static BooleanVal3 IfNullThenInvoke(this BooleanVal3 @this, Action action)
        {
            @this.IfNull(action);
            return @this;
        }

        public static BooleanVal3 IfNullThenInvoke<T>(this BooleanVal3 @this, Action<T> action, T context)
        {
            @this.IfNull(action, context);
            return @this;
        }

        #endregion
    }

    public static partial class FluentBooleanExtensions
    {
        public static BooleanVal3 And(this BooleanVal3 current, Func<BooleanVal3> next)
        {
            if (current is null)
                return BooleanVal3.FalseVal;
            if (current.IsT1())
                return BooleanVal3.FalseVal;
            if (current.IsT2())
                return BooleanVal3.FalseVal;
            return next?.Invoke() ?? BooleanVal3.FalseVal;
        }

        public static BooleanVal3 And(this BooleanVal3 current, IEnumerable<Func<BooleanVal3>> nextSet)
        {
            if (current is null)
                return BooleanVal3.FalseVal;
            if (current.IsT1())
                return BooleanVal3.FalseVal;
            if (current.IsT2())
                return BooleanVal3.FalseVal;
            foreach (var next in nextSet)
            {
                var nextVal = next?.Invoke();
                if (nextVal is null)
                    return BooleanVal3.FalseVal;
                if (nextVal.IsT1())
                    return BooleanVal3.FalseVal;
                if (nextVal.IsT2())
                    return BooleanVal3.FalseVal;
            }

            return BooleanVal3.TrueVal;
        }

        public static BooleanVal3 And(this BooleanVal3 current, BooleanVal3 next)
        {
            if (current is null)
                return BooleanVal3.FalseVal;
            if (current.IsT1())
                return BooleanVal3.FalseVal;
            if (current.IsT2())
                return BooleanVal3.FalseVal;
            return next;
        }

        public static BooleanVal3 Or(this BooleanVal3 current, Func<BooleanVal3> next)
        {
            if (current is null)
                return BooleanVal3.FalseVal;
            if (current.IsT0())
                return BooleanVal3.TrueVal;
            return next?.Invoke() ?? BooleanVal3.FalseVal;
        }

        public static BooleanVal3 Or(this BooleanVal3 current, IEnumerable<Func<BooleanVal3>> nextSet)
        {
            if (current is null)
                return BooleanVal3.FalseVal;
            if (current.IsT0())
                return BooleanVal3.TrueVal;
            foreach (var next in nextSet)
            {
                var nextVal = next?.Invoke();
                if (nextVal is not null && nextVal.IsT0())
                    return BooleanVal3.TrueVal;
            }
            return BooleanVal3.FalseVal;
        }

        public static BooleanVal3 Or(this BooleanVal3 current, BooleanVal3 next)
        {
            if (current is null)
                return BooleanVal3.FalseVal;
            if (current.IsT1())
                return BooleanVal3.TrueVal;
            return next;
        }
    }
}