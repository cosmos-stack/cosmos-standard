using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Object extensions
    /// </summary>
    public static partial class ObjectExtensions
    {
        /// <summary>
        /// As
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T As<T>(this object @this)
        {
            return (T)@this;
        }

        /// <summary>
        /// As or default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T AsOrDefault<T>(this object @this)
        {
            try
            {
                return (T)@this;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// As or default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T AsOrDefault<T>(this object @this, T defaultValue)
        {
            try
            {
                return (T)@this;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// As or default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="defaultValueFactory"></param>
        /// <returns></returns>
        public static T AsOrDefault<T>(this object @this, Func<T> defaultValueFactory)
        {
            try
            {
                return (T)@this;
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        /// As or default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="defaultValueFactory"></param>
        /// <returns></returns>
        public static T AsOrDefault<T>(this object @this, Func<object, T> defaultValueFactory)
        {
            try
            {
                return (T)@this;
            }
            catch (Exception)
            {
                return defaultValueFactory(@this);
            }
        }
    }
}