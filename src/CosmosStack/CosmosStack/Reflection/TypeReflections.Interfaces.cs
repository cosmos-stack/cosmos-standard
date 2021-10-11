using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CosmosStack.Reflection
{
    /// <summary>
    /// Interface options <br />
    /// 接口选项
    /// </summary>
    public enum InterfaceOptions
    {
        /// <summary>
        /// Default <br />
        /// 默认
        /// </summary>
        Default = 0,
        
        /// <summary>
        /// Ignore generic args <br />
        /// 忽略泛型参数
        /// </summary>
        IgnoreGenericArgs = 1
    }

    /// <summary>
    /// Reflection Utilities. <br />
    /// 反射工具
    /// </summary>
    public static partial class TypeReflections
    {
        #region IsInterfaceDefined

        /// <summary>
        /// To determine whether the given Interface is defined.<br />
        /// 判断给定的接口是否定义。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="interfaceType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool IsInterfaceDefined(Type type, Type interfaceType, InterfaceOptions options = InterfaceOptions.Default)
        {
            if (type is null || interfaceType is null)
                return false;

            if (!interfaceType.IsInterface)
                return false;

            var sourceInterfaceTypes = type.GetInterfaces();

            return options switch
            {
                InterfaceOptions.Default => sourceInterfaceTypes.Contains(interfaceType),
                InterfaceOptions.IgnoreGenericArgs => IsInterfaceDefinedImpl(sourceInterfaceTypes, interfaceType),
                _ => sourceInterfaceTypes.Contains(interfaceType)
            };
        }

        /// <summary>
        /// To determine whether the given Interface is defined.<br />
        /// 判断给定的接口是否定义。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInterfaceDefined<TInterface>(Type type, InterfaceOptions options = InterfaceOptions.Default)
        {
            return IsInterfaceDefined(type, typeof(TInterface), options);
        }

        private static bool IsInterfaceDefinedImpl(IEnumerable<Type> sourceInterfaceTypes, Type interfaceType)
        {
            if (!interfaceType.IsGenericType)
                return sourceInterfaceTypes.Contains(interfaceType);

            Type sourceGenericTypeDefinition,
                interfaceGenericTypeDefinition = interfaceType.GetGenericTypeDefinition();

            foreach (var sourceInterfaceType in sourceInterfaceTypes)
            {
                if (!sourceInterfaceType.IsGenericType) 
                    continue;
                
                if (sourceInterfaceType == interfaceType)
                    return true;

                sourceGenericTypeDefinition = sourceInterfaceType.GetGenericTypeDefinition();
                if (sourceGenericTypeDefinition == interfaceGenericTypeDefinition)
                    return true;
            }

            return false;
        }

        #endregion
    }
}