using System;

namespace Cosmos.Dependency
{
    public class RegisterProxyDescriptor
    {
        public Type ServiceType { get; set; }

        public Type ImplementationType { get; set; }

        public Type ImplementationTypeSelf { get; set; }

        public object InstanceOfImplementation { get; set; }

        public Func<object> InstanceFuncForImplementation { get; set; }

        public RegisterProxyType ProxyType { get; set; }

        public RegisterProxyLifetimeType LifetimeType { get; set; }

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

        public static RegisterProxyDescriptor Create<TImplementationSelf>(RegisterProxyLifetimeType lifetimeType)
        {
            return new RegisterProxyDescriptor
            {
                ImplementationTypeSelf = typeof(TImplementationSelf),
                ProxyType = RegisterProxyType.TypeSelf,
                LifetimeType = lifetimeType
            };
        }

        public static RegisterProxyDescriptor Create(object instance, RegisterProxyLifetimeType lifetimeType)
        {
            return new RegisterProxyDescriptor
            {
                InstanceOfImplementation = instance,
                ProxyType = RegisterProxyType.InstanceSelf,
                LifetimeType = lifetimeType
            };
        }

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
