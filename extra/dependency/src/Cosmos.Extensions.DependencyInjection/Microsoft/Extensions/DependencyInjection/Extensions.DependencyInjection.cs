using System;
using Cosmos.Dependency;

namespace Microsoft.Extensions.DependencyInjection {
    /// <summary>
    /// Extensions for Dependency Injection
    /// </summary>
    public static class DependencyInjectionExtensions {
        /// <summary>
        /// Add Register Proxy
        /// </summary>
        /// <param name="services"></param>
        /// <param name="bag"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddRegisterProxy(this IServiceCollection services, RegisterProxyBag bag) {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (bag != null) {
                var descriptors = bag.ExportDescriptors();

                foreach (var descriptor in descriptors) {
                    switch (descriptor.ProxyType) {
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

        private static void TypeToTypeRegister(IServiceCollection services, RegisterProxyDescriptor d) {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime) {
                case ServiceLifetime.Scoped:
                    services.AddScoped(d.ServiceType, d.ImplementationType);
                    break;

                case ServiceLifetime.Singleton:
                    services.AddSingleton(d.ServiceType, d.ImplementationType);
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(d.ServiceType, d.ImplementationType);
                    break;

                default:
                    services.AddTransient(d.ServiceType, d.ImplementationType);
                    break;
            }
        }

        private static void TypeToInstanceRegister(IServiceCollection services, RegisterProxyDescriptor d) {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime) {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(d.ServiceType, d.InstanceOfImplementation);
                    break;

                default:
                    throw new InvalidOperationException("Invalid operation for scoped or Transient mode.");
            }
        }

        private static void TypeToInstanceFuncRegister(IServiceCollection services, RegisterProxyDescriptor d) {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime) {
                case ServiceLifetime.Scoped:
                    services.AddScoped(d.ServiceType, p => d.InstanceFuncForImplementation());
                    break;

                case ServiceLifetime.Singleton:
                    services.AddSingleton(d.ServiceType, p => d.InstanceFuncForImplementation());
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(d.ServiceType, p => d.InstanceFuncForImplementation());
                    break;

                default:
                    services.AddTransient(d.ServiceType, p => d.InstanceFuncForImplementation());
                    break;
            }
        }

        private static void TypeSelfRegister(IServiceCollection services, RegisterProxyDescriptor d) {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime) {
                case ServiceLifetime.Scoped:
                    services.AddScoped(d.ImplementationTypeSelf);
                    break;

                case ServiceLifetime.Singleton:
                    services.AddSingleton(d.ImplementationTypeSelf);
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(d.ImplementationTypeSelf);
                    break;

                default:
                    services.AddTransient(d.ImplementationTypeSelf);
                    break;
            }
        }

        private static void InstanceSelfRegister(IServiceCollection services, RegisterProxyDescriptor d) {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime) {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(d.InstanceOfImplementation);
                    break;

                default:
                    throw new InvalidOperationException("Invalid operation for scoped or Transient mode.");
            }
        }

        private static void InstanceSelfFuncRegister(IServiceCollection services, RegisterProxyDescriptor d) {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime) {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(p => d.InstanceFuncForImplementation());
                    break;

                default:
                    throw new InvalidOperationException("Invalid operation for scoped or Transient mode.");
            }
        }
    }
}