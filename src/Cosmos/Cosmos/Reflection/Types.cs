using System;
using System.Linq;
using System.Reflection;
using AspectCore.Extensions.Reflection;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Type Utilities
    /// </summary>
    public static partial class Types
    {

        #region GenericImplementation and raw type

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <param name="type">The given type</param>
        /// <param name="genericType">The generic type</param>
        /// <returns></returns>
        public static bool IsGenericImplementation(Type type, Type genericType)
        {
            return IsGenericImplementation(type, genericType, out _);
        }

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <returns></returns>
        public static bool IsGenericImplementation<TGot, TGeneric>() => IsGenericImplementation(typeof(TGot), typeof(TGeneric));

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <param name="type">The given type</param>
        /// <param name="genericType">The generic type</param>
        /// <param name="genericArguments"></param>
        /// <returns></returns>
        public static bool IsGenericImplementation(Type type, Type genericType, out Type[] genericArguments)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (genericType is null)
                throw new ArgumentNullException(nameof(genericType));

            if (!genericType.IsGenericType)
            {
                genericArguments = null;
                return false;
            }

            // ReSharper disable once JoinDeclarationAndInitializer
            bool testFlag;

            //Testing interface
            testFlag = type.GetInterfaces().Any(_checkRawGenericType);
            if (testFlag)
            {
                genericArguments = type.GetGenericArguments();
                return true;
            }

            //Testing class
            while (type != null && type != TypeClass.ObjectClazz)
            {
                testFlag = _checkRawGenericType(type);
                if (testFlag)
                {
                    genericArguments = type.GetGenericArguments();
                    return true;
                }

                type = type.BaseType;
            }

            //no matched for any classed or interfaces
            genericArguments = null;
            return false;

            // To check such type equals to specific type of class or interface
            // 检查给定的这个 test 类型是否等于指定类 Class 或接口 Interface 的类型 Type
            // ReSharper disable once InconsistentNaming
            bool _checkRawGenericType(Type test)
                => genericType == (test.IsGenericType ? test.GetGenericTypeDefinition() : test);
        }

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <param name="genericArguments"></param>
        /// <returns></returns>
        public static bool IsGenericImplementation<TGot, TGeneric>(out Type[] genericArguments)
        {
            return IsGenericImplementation(typeof(TGot), typeof(TGeneric), out genericArguments);
        }

        /// <summary>
        /// Get the original type. <br />
        /// When type inherits from genericType, gets the first type parameter in the genericType corresponding to the type.
        /// </summary>
        /// <param name="type">The given type</param>
        /// <param name="genericType">The generic type</param>
        /// <returns></returns>
        public static Type GetRawTypeFromGenericClass(Type type, Type genericType)
        {
            return TypeReflections.GetRawTypeFromGenericClass(type, genericType);
        }

        /// <summary>
        /// Get the original type. <br />
        /// When type inherits from genericType, gets the first type parameter in the genericType corresponding to the type.
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <returns></returns>
        public static Type GetRawTypeFromGenericClass<TGot, TGeneric>()
        {
            return TypeReflections.GetRawTypeFromGenericClass<TGot, TGeneric>();
        }

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
            return CreateInstance(type, args) is TInstance ret ? ret : default;
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

        /// <summary>
        /// Create instance with no param
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <returns></returns>
        public static TInstance CreateInstanceWithoutParam<TInstance>()
        {
            return CreateInstanceCore<TInstance>();
        }

        private static TInstance CreateInstanceCore<TInstance>() =>
            CreateInstanceCore(typeof(TInstance)) is TInstance ret ? ret : default;

        private static TInstance CreateInstanceCore<TInstance>(object[] args) =>
            CreateInstanceCore(typeof(TInstance), args) is TInstance ret ? ret : default;

        private static object CreateInstanceCore(Type type, params object[] args) =>
            args is null || args.Length == 0
                ? type.GetConstructors().FirstOrDefault(x => !x.GetParameters().Any())?.GetReflector().Invoke()
                : type.GetConstructor(Of(args))?.GetReflector().Invoke(args);

        #endregion
    }
}