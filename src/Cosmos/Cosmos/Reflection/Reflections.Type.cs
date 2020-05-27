using System;
using System.Reflection;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Reflection Utilities.
    /// </summary>
    public static partial class Reflections
    {
        #region GetUnderlyingType

        /// <summary>
        /// Get underlying type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Type GetUnderlyingType<T>()
        {
            var type = typeof(T);
            return Nullable.GetUnderlyingType(type) ?? type;
        }

        /// <summary>
        /// Get underlying type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetUnderlyingType(Type type)
        {
            if (type is null)
                return null;
            return Nullable.GetUnderlyingType(type) ?? type;
        }

        /// <summary>
        /// Get underlying type.
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static Type GetUnderlyingType(TypeInfo typeInfo)
        {
            if (typeInfo is null)
                return null;
            var type = typeInfo.AsType();
            return Nullable.GetUnderlyingType(type) ?? type;
        }

        #endregion

        #region GenericImplementation and raw type

        /// <summary>
        /// Get the original type. <br />
        /// When type inherits from genericType, gets the first type parameter in the genericType corresponding to the type.
        /// </summary>
        /// <param name="type">The given type</param>
        /// <param name="genericType">The generic type</param>
        /// <returns></returns>
        public static Type GetRawTypeFromGenericClass(Type type, Type genericType)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (genericType is null)
                throw new ArgumentNullException(nameof(genericType));

            if (!genericType.IsGenericType)
                return null;

            while (type != null && type != TypeClass.ObjectClass)
            {
                var testFlag = _checkRawGenericType(type);
                if (testFlag)
                {
                    return type.GenericTypeArguments.Length > 0
                        ? type.GenericTypeArguments[0]
                        : null;
                }

                type = type.BaseType;
            }

            return null;

            // To check such type equals to specific type of class or interface
            // ReSharper disable once InconsistentNaming
            bool _checkRawGenericType(Type test)
                => genericType == (test.IsGenericType ? test.GetGenericTypeDefinition() : test);
        }

        /// <summary>
        /// Get the original type. <br />
        /// When type inherits from genericType, gets the first type parameter in the genericType corresponding to the type.
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <returns></returns>
        public static Type GetRawTypeFromGenericClass<TGot, TGeneric>() => GetRawTypeFromGenericClass(typeof(TGot), typeof(TGeneric));

        #endregion
    }
}