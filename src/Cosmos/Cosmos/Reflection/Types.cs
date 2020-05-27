using System;
using System.Linq;
using System.Reflection;
using AspectCore.Extensions.Reflection;
using Cosmos.Judgments;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Type Utilities
    /// </summary>
    public static partial class Types
    {
        #region Of

        /// <summary>
        /// Get type
        /// </summary>
        /// <typeparam name="T">Special type T</typeparam>
        public static Type Of<T>() => Reflections.GetUnderlyingType<T>();

        /// <summary>
        /// Get types
        /// </summary>
        /// <param name="objColl">Object array</param>
        /// <returns></returns>
        public static Type[] Of(object[] objColl)
        {
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
        public static bool IsGenericImplementation(Type type, Type genericType) => TypeJudgment.IsGenericImplementation(type, genericType);

        /// <summary>
        /// To judge the given type is assignable to the generic type or not.
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <returns></returns>
        public static bool IsGenericImplementation<TGot, TGeneric>() => TypeJudgment.IsGenericImplementation<TGot, TGeneric>();

        /// <summary>
        /// Get the original type. <br />
        /// When type inherits from genericType, gets the first type parameter in the genericType corresponding to the type.
        /// </summary>
        /// <param name="type">The given type</param>
        /// <param name="genericType">The generic type</param>
        /// <returns></returns>
        public static Type GetRawTypeFromGenericClass(Type type, Type genericType) => Reflections.GetRawTypeFromGenericClass(type, genericType);

        /// <summary>
        /// Get the original type. <br />
        /// When type inherits from genericType, gets the first type parameter in the genericType corresponding to the type.
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <returns></returns>
        public static Type GetRawTypeFromGenericClass<TGot, TGeneric>() => Reflections.GetRawTypeFromGenericClass<TGot, TGeneric>();

        #endregion

        #region Enum Type

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="mayNullable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsEnumType<T>(bool mayNullable = false) => TypeJudgment.IsEnumType<T>(mayNullable);

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mayNullable"></param>
        /// <returns></returns>
        public static bool IsEnumType(Type type, bool mayNullable = false) => TypeJudgment.IsEnumType(type, mayNullable);

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <param name="mayNullable"></param>
        /// <returns></returns>
        public static bool IsEnumType(TypeInfo typeInfo, bool mayNullable = false) => TypeJudgment.IsEnumType(typeInfo, mayNullable);

        #endregion

        #region Numeric Type

        /// <summary>
        /// Is numeric type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNumericType<T>() => TypeJudgment.IsNumericType<T>();

        /// <summary>
        /// Is numeric type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNumericType(Type type) => TypeJudgment.IsNumericType(type);

        /// <summary>
        /// Is numeric type
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static bool IsNumericType(TypeInfo typeInfo) => TypeJudgment.IsNumericType(typeInfo);

        #endregion

        #region Nullable Type

        /// <summary>
        /// Is nullable type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullableType<T>() => TypeJudgment.IsNullableType<T>();

        /// <summary>
        /// Is nullable type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullableType(Type type) => TypeJudgment.IsNullableType(type);

        /// <summary>
        /// Is nullable type
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static bool IsNullableType(TypeInfo typeInfo) => TypeJudgment.IsNullableType(typeInfo);

        #endregion

        #region CreateInstance

        /// <summary>
        /// Create instance
        /// </summary>
        /// <typeparam name="TInstance">Special type you need to return.</typeparam>
        /// <param name="args">Arguments for such type's constructor</param>
        /// <returns>Instance of special type</returns>
        public static TInstance CreateInstance<TInstance>(params object[] args)
        {
            return CreateInstanceCore<TInstance>(args);
        }

        /// <summary>
        /// Create instance
        /// </summary>
        /// <typeparam name="TInstance">Special type you need to return.</typeparam>
        /// <param name="type">Special type</param>
        /// <param name="args">Arguments for such type's constructor</param>
        /// <returns>Instance of special type</returns>
        public static TInstance CreateInstance<TInstance>(Type type, params object[] args)
        {
            return CreateInstance(type, args) is TInstance ret ? ret : TypeDefault.Of<TInstance>();
        }

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="type">Special type</param>
        /// <param name="args">Arguments for such type's constructor</param>
        /// <returns>Instance of special type</returns>
        public static object CreateInstance(Type type, params object[] args)
        {
            return CreateInstanceCore(type, args);
        }

        private static TInstance CreateInstanceCore<TInstance>() =>
            CreateInstanceCore(typeof(TInstance)) is TInstance ret ? ret : TypeDefault.Of<TInstance>();

        private static TInstance CreateInstanceCore<TInstance>(object[] args) =>
            CreateInstanceCore(typeof(TInstance), args) is TInstance ret ? ret : TypeDefault.Of<TInstance>();

        private static object CreateInstanceCore(Type type, params object[] args) =>
            args is null || args.Length == 0
                ? type.GetConstructors().FirstOrDefault(x => !x.GetParameters().Any())?.GetReflector().Invoke()
                : type.GetConstructor(Of(args))?.GetReflector().Invoke(args);

        #endregion
    }
}