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
        public static void IfTrue(this bool @this, Action action)
        {
            if (@this)
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
        public static void IfTrue<T>(this bool @this, Action<T> action, T context)
        {
            if (@this)
            {
                action?.Invoke(context);
            }
        }

        /// <summary>
        /// If false...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        public static void IfFalse(this bool @this, Action action)
        {
            if (!@this)
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
        /// If this then that...
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="this"></param>
        /// <param name="that"></param>
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
        /// If this then that...
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="condition"></param>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <returns></returns>
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
        /// If true then throw exception
        /// </summary>
        /// <param name="this"></param>
        /// <param name="exception"></param>
        public static void IfTrueThenThrow(this bool @this, Exception exception)
        {
            @this.IfTrue(() => ExceptionHelper.PrepareForRethrow(exception));
        }

        /// <summary>
        /// If false then throw exception
        /// </summary>
        /// <param name="this"></param>
        /// <param name="exception"></param>
        public static void IfFalseThenThrow(this bool @this, Exception exception)
        {
            @this.IfFalse(() => ExceptionHelper.PrepareForRethrow(exception));
        }

        #endregion

        #region If then invoke

        public static bool IfTrueThenInvoke(this bool @this, Func<bool> func)
        {
            if (@this)
            {
                @this = func?.Invoke() ?? false;
            }

            return @this;
        }

        public static bool IfTrueThenInvoke<T>(this bool @this, Func<T, bool> func, T context)
        {
            if (@this)
            {
                @this = func?.Invoke(context) ?? false;
            }

            return @this;
        }

        public static bool IfTrueThenInvoke(this bool @this, Action action)
        {
            @this.IfTrue(action);
            return @this;
        }

        public static bool IfTrueThenInvoke<T>(this bool @this, Action<T> action, T context)
        {
            @this.IfTrue(action, context);
            return @this;
        }

        public static bool IfFalseThenInvoke(this bool @this, Func<bool> func)
        {
            if (!@this)
            {
                @this = func?.Invoke() ?? false;
            }

            return @this;
        }

        public static bool IfFalseThenInvoke<T>(this bool @this, Func<T, bool> func, T context)
        {
            if (!@this)
            {
                @this = func?.Invoke(context) ?? false;
            }

            return @this;
        }

        public static bool IfFalseThenInvoke(this bool @this, Action action)
        {
            @this.IfFalse(action);
            return @this;
        }

        public static bool IfFalseThenInvoke<T>(this bool @this, Action<T> action, T context)
        {
            @this.IfFalse(action, context);
            return @this;
        }

        #endregion

        #region To binary

        /// <summary>
        /// Is binary
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static byte ToBinary(this bool @this) => Convert.ToByte(@this);

        #endregion

        #region To string

        /// <summary>
        /// If true then this, else that...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="trueString"></param>
        /// <param name="falseString"></param>
        /// <returns></returns>
        public static string ToString(this bool @this, string trueString, string falseString) =>
            @this ? trueString : falseString;

        #endregion

        #region Then

        public static bool InvokeThenTrue(this Action action)
        {
            action?.Invoke();
            return true;
        }

        public static bool InvokeThenFalse(this Action action)
        {
            action?.Invoke();
            return false;
        }

        #endregion
    }

    public static partial class FluentBooleanExtensions
    {
        public static bool And(this bool current, Func<bool> next)
        {
            if (!current) return false;
            return next?.Invoke() ?? false;
        }

        public static bool And(this bool current, IEnumerable<Func<bool>> nextSet)
        {
            if (!current) return false;
            foreach (var next in nextSet)
                if (!(next?.Invoke() ?? false))
                    return false;
            return true;
        }

        public static bool And(this bool current, bool next)
        {
            if (!current) return false;
            return next;
        }

        public static bool Or(this bool current, Func<bool> next)
        {
            if (current) return true;
            return next?.Invoke() ?? false;
        }

        public static bool Or(this bool current, IEnumerable<Func<bool>> nextSet)
        {
            if (current) return true;
            foreach (var next in nextSet)
                if (next?.Invoke() ?? false)
                    return true;
            return false;
        }

        public static bool Or(this bool current, bool next)
        {
            if (current) return true;
            return next;
        }
    }
}