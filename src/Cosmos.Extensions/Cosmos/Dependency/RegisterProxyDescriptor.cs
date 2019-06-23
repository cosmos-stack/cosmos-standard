using System;

namespace Cosmos.Dependency
{
    /// <summary>
    /// Register proxy descriptor
    /// </summary>
    public class RegisterProxyDescriptor
    {
        /// <summary>
        /// Service type
        /// </summary>
        public Type ServiceType { get; set; }

        /// <summary>
        /// Implementation type
        /// </summary>
        public Type ImplementationType { get; set; }

        /// <summary>
        /// Implementation type self
        /// </summary>
        public Type ImplementationTypeSelf { get; set; }

        /// <summary>
        /// Instance of implementation
        /// </summary>
        public object InstanceOfImplementation { get; set; }

        /// <summary>
        /// Instance func for implementation
        /// </summary>
        public Func<object> InstanceFuncForImplementation { get; set; }

        /// <summary>
        /// Proxy type
        /// </summary>
        public RegisterProxyType ProxyType { get; set; }

        /// <summary>
        /// Lifetime type
        /// </summary>
        public RegisterProxyLifetimeType LifetimeType { get; set; }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static RegisterProxyDescriptor Create<TService, TImplementation>(RegisterProxyLifetimeType lifetimeType)
        {
            return new RegisterProxyDescriptor
            {
                ServiceType = typeof(TService),
                ImplementationType = typeof(TImplementation),
                ProxyType = RegisterProxyType.TypeToType,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="instance"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static RegisterProxyDescriptor Create<TService, TImplementation>(TImplementation instance, RegisterProxyLifetimeType lifetimeType)
        {
            return new RegisterProxyDescriptor
            {
                ServiceType = typeof(TService),
                InstanceOfImplementation = instance,
                ProxyType = RegisterProxyType.TypeToInstance,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="instance"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static RegisterProxyDescriptor Create<TService>(object instance, RegisterProxyLifetimeType lifetimeType)
        {
            return new RegisterProxyDescriptor
            {
                ServiceType = typeof(TService),
                InstanceOfImplementation = instance,
                ProxyType = RegisterProxyType.TypeToInstance,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TImplementationSelf"></typeparam>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static RegisterProxyDescriptor Create<TImplementationSelf>(RegisterProxyLifetimeType lifetimeType)
        {
            return new RegisterProxyDescriptor
            {
                ImplementationTypeSelf = typeof(TImplementationSelf),
                ProxyType = RegisterProxyType.TypeSelf,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static RegisterProxyDescriptor Create(object instance, RegisterProxyLifetimeType lifetimeType)
        {
            return new RegisterProxyDescriptor
            {
                InstanceOfImplementation = instance,
                ProxyType = RegisterProxyType.InstanceSelf,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="instanceFunc"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static RegisterProxyDescriptor Create<TService, TImplementation>(Func<TImplementation> instanceFunc, RegisterProxyLifetimeType lifetimeType)
        {
            return new RegisterProxyDescriptor
            {
                ServiceType = typeof(TService),
                ImplementationType = typeof(TImplementation),
                InstanceFuncForImplementation = () => instanceFunc(),
                ProxyType = RegisterProxyType.TypeToInstanceFunc,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="instanceFunc"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static RegisterProxyDescriptor Create<TService>(Func<object> instanceFunc, RegisterProxyLifetimeType lifetimeType)
        {
            return new RegisterProxyDescriptor
            {
                ServiceType = typeof(TService),
                InstanceFuncForImplementation = instanceFunc,
                ProxyType = RegisterProxyType.TypeToInstanceFunc,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="instanceFunc"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static RegisterProxyDescriptor Create<TImplementation>(Func<TImplementation> instanceFunc, RegisterProxyLifetimeType lifetimeType)
        {
            return new RegisterProxyDescriptor
            {
                ImplementationTypeSelf = typeof(TImplementation),
                InstanceFuncForImplementation = () => instanceFunc(),
                ProxyType = RegisterProxyType.InstanceSelfFunc,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="instanceFunc"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static RegisterProxyDescriptor Create(Func<object> instanceFunc, RegisterProxyLifetimeType lifetimeType)
        {
            return new RegisterProxyDescriptor
            {
                InstanceFuncForImplementation = instanceFunc,
                ProxyType = RegisterProxyType.InstanceSelfFunc,
                LifetimeType = lifetimeType
            };
        }
    }
}
