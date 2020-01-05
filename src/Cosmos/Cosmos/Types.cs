using System;
using System.Linq;

namespace Cosmos {
    /// <summary>
    /// Type Utilities
    /// </summary>
    public static partial class Types {

        #region Of

        /// <summary>
        /// Get type
        /// </summary>
        /// <typeparam name="T">Special type T</typeparam>
        public static Type Of<T>() => Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

        /// <summary>
        /// Get types
        /// </summary>
        /// <param name="objColl">Object array</param>
        /// <returns></returns>
        public static Type[] Of(object[] objColl) {
            if (objColl is null)
                return null;
            if (!objColl.Contains(null))
                return Type.GetTypeArray(objColl);
            var types = new Type[objColl.Length];
            for (var i = 0; i < objColl.Length; i++)
                types[i] = objColl[i].GetType();
            return types;
        }

        #endregion

        #region DefaultValue

        /// <summary>
        /// Get default value of special type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DefaultValue<T>() => TypeDefault.Of<T>();

        #endregion

        #region GenericImplementation and raw type

        /// <summary>
        /// To judge the given type is assignable to the generic type or not.
        /// </summary>
        /// <param name="type">The given type</param>
        /// <param name="genericType">The generic type</param>
        /// <returns></returns>
        public static bool IsGenericImplementation(Type type, Type genericType) {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (genericType is null)
                throw new ArgumentNullException(nameof(genericType));

            if (!genericType.IsGenericType)
                return false;

            bool testFlag;

            //Testing interface
            testFlag = type.GetInterfaces().Any(_checkRawGenericType);
            if (testFlag) return true;

            //Testing class
            while (type != null && type != TypeClass.ObjectClass) {
                testFlag = _checkRawGenericType(type);
                if (testFlag) return true;
                type = type.BaseType;
            }

            //no matched for any classed or interfaces
            return false;

            // To check such type equals to specific type of class or interface
            // ReSharper disable once InconsistentNaming
            bool _checkRawGenericType(Type test)
                => genericType == (test.IsGenericType ? test.GetGenericTypeDefinition() : test);
        }

        /// <summary>
        /// To judge the given type is assignable to the generic type or not.
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <returns></returns>
        public static bool IsGenericImplementation<TGot, TGeneric>() => IsGenericImplementation(typeof(TGot), typeof(TGeneric));

        /// <summary>
        /// Get the original type. <br />
        /// When type inherits from genericType, gets the first type parameter in the genericType corresponding to the type.
        /// </summary>
        /// <param name="type">The given type</param>
        /// <param name="genericType">The generic type</param>
        /// <returns></returns>
        public static Type GetRawTypeFromGenericClass(Type type, Type genericType) {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (genericType is null)
                throw new ArgumentNullException(nameof(genericType));

            if (!genericType.IsGenericType)
                return null;

            while (type != null && type != TypeClass.ObjectClass) {
                var testFlag = _checkRawGenericType(type);
                if (testFlag) {
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