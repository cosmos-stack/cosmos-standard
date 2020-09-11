using System;
using Cosmos.Exceptions;

namespace Cosmos
{
    /// <summary>
    /// Boolean extensions
    /// </summary>
    public static class BooleanExtensions
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

        #region If null or whitespace

        /// <summary>
        /// If null or whitespace then...
        /// </summary>
        /// <param name="string"></param>
        /// <param name="action"></param>
        public static void IfNullOrWhiteSpace(this string @string, Action action)
        {
            if (string.IsNullOrWhiteSpace(@string))
            {
                action?.Invoke();
            }
        }

        /// <summary>
        /// If not null nor whitespace then...
        /// </summary>
        /// <param name="string"></param>
        /// <param name="action"></param>
        public static void IfNotNullNorWhiteSpace(this string @string, Action action)
        {
            if (!string.IsNullOrWhiteSpace(@string))
            {
                action?.Invoke();
            }
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
    }
}