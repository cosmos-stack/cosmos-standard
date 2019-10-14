using System;
using Cosmos.Dependency;

namespace AspectCore.Injector
{
    /// <summary>
    /// Extensions for NCC AspectCore
    /// </summary>
    public static class AspectCoreInjectorExtensions
    {
        /// <summary>
        /// Register Proxy
        /// </summary>
        /// <param name="services"></param>
        /// <param name="bag"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceContainer RegisterProxy(this IServiceContainer services, RegisterProxyBag bag)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (bag != null)
            {
                var descriptors = bag.ExportDescriptors();

                foreach (var descriptor in descriptors)
                {
                    switch (descriptor.ProxyType)
                    {
                        case RegisterProxyType.TypeToType:
                            TypeToTypeRegister(services, descriptor);
                            break;

                        case RegisterProxyType.TypeToInstance:
                            TypeToInstanceRegister(services, descriptor);
                            break;

                        case RegisterProxyType.TypeToInstanceFunc:
                            TypeToInstanceFuncRegister(services, descriptor);
                            break;

                        case RegisterProxyType.TypeSelf:
                            TypeSelfRegister(services, descriptor);
                            break;

                        case RegisterProxyType.InstanceSelf:
                            InstanceSelfRegister(services, descriptor);
                            break;

                        case RegisterProxyType.InstanceSelfFunc:
                            InstanceSelfFuncRegister(services, descriptor);
                            break;
                    }
                }
            }

            return services;
        }

        private static void TypeToTypeRegister(IServiceContainer services, RegisterProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            services.AddType(d.ServiceType, d.ImplementationType, lifetime);
        }

        private static void TypeToInstanceRegister(IServiceContainer services, RegisterProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            switch (lifetime)
            {
                case Lifetime.Singleton:
                    services.AddInstance(d.ServiceType, d.InstanceOfImplementation);
                    break;

                default:
                    throw new InvalidOperationException("Invalid operation for scoped or Transient mode.");
            }
        }

        private static void TypeToInstanceFuncRegister(IServiceContainer services, RegisterProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            services.AddDelegate(d.ServiceType, r => d.InstanceFuncForImplementation(), lifetime);
        }

        private static void TypeSelfRegister(IServiceContainer services, RegisterProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            services.AddType(d.ImplementationTypeSelf, lifetime);
        }

        private static void InstanceSelfRegister(IServiceContainer services, RegisterProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            switch (lifetime)
            {
                case Lifetime.Singleton:
                    services.AddInstance(d.InstanceOfImplementation);
                    break;

                default:
                    throw new InvalidOperationException("Invalid operation for scoped or Transient mode.");
            }
        }

        private static void InstanceSelfFuncRegister(IServiceContainer services, RegisterProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            switch (lifetime)
            {
                case Lifetime.Singleton:
                    services.AddDelegate(r => d.InstanceFuncForImplementation());
                    break;

                default:
                    throw new InvalidOperationException("Invalid operation for scoped or Transient mode.");
            }
        }
    }
}