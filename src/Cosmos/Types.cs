using System;
using System.Linq;
using AspectCore.Extensions.Reflection;

namespace Cosmos
{
    public static class Types
    {
        #region Of

        /// <summary>
        /// Get type
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type Of<T>() => Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

        /// <summary>
        /// Get types
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static Type[] Of(object[] objs)
        {
            if (objs == null)
                return null;
            if (!objs.Contains(null))
                return Type.GetTypeArray(objs);
            var types = new Type[objs.Length];
            for (var i = 0; i < objs.Length; i++)
                types[i] = objs[i].GetType();
            return types;
        }

        #endregion

        #region DefaultValue

        public static T DefaultValue<T>() => TypeDefault.Of<T>();

        #endregion

        #region GenericImplementation and raw type

        public static bool IsGenericImplementation(Type type, Type genericType)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (genericType == null)
                throw new ArgumentNullException(nameof(genericType));

            if (!genericType.IsGenericType)
                return false;

            bool testFlag;

            //Testing interface
            testFlag = type.GetInterfaces().Any(_checkRawGenericType);
            if (testFlag) return true;

            //Testing class
            while (type != null && type != TypeClass.ObjectClass)
            {
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

        public static bool IsGenericImplementation<TGot, TGeneric>() => IsGenericImplementation(typeof(TGot), typeof(TGeneric));

        public static Type GetRawTypeFromGenericClass(Type type, Type genericType)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (genericType == null)
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

        public static Type GetRawTypeFromGenericClass<TGot, TGeneric>() => GetRawTypeFromGenericClass(typeof(TGot), typeof(TGeneric));

        #endregion

        #region CreateInstance

        public static TInstance CreateInstance<TInstance>(params object[] args)
        {
            if (args == null || args.Length == 0)
                return CreateInstanceCore<TInstance>();
            return CreateInstanceCore<TInstance>(args);
        }

        public static TInstance CreateInstance<TInstance>(Type type, params object[] args)
        {
            var instance = CreateInstance(type, args);
            return instance is TInstance ret ? ret : default(TInstance);
        }

        public static object CreateInstance(Type type, params object[] args)
        {
            if (args == null || args.Length == 0)
                return CreateInstanceCore(type);
            return CreateInstanceCore(type, args);
        }

        private static TInstance CreateInstanceCore<TInstance>()
        {
            var instance = CreateInstanceCore(typeof(TInstance));
            return instance is TInstance ret ? ret : default(TInstance);
        }

        private static TInstance CreateInstanceCore<TInstance>(object[] args)
        {
            var instance = CreateInstanceCore(typeof(TInstance), args);
            return instance is TInstance ret ? ret : default(TInstance);
        }

        private static object CreateInstanceCore(Type type)
        {
            var constructorInfo = type.GetConstructors().FirstOrDefault(x => !x.GetParameters().Any());
            return constructorInfo?.GetReflector().Invoke();
        }

        private static object CreateInstanceCore(Type type, object[] args)
        {
            var constructorInfo = type.GetConstructor(Of(args));
            return constructorInfo?.GetReflector().Invoke(args);
        }

        #endregion
    }
}