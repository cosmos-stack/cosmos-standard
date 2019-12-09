using System;
using Cosmos.Dependency;

namespace Autofac {
    /// <summary>
    /// Extensions for Autofac
    /// </summary>
    public static class RegisterTypesExtensions {
        /// <summary>
        /// Register Proxy
        /// </summary>
        /// <param name="services"></param>
        /// <param name="bag"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ContainerBuilder RegisterProxy(this ContainerBuilder services, RegisterProxyBag bag) {
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

        private static void TypeToTypeRegister(ContainerBuilder services, RegisterProxyDescriptor d) {
            var builder = services.RegisterType(d.ImplementationType).As(d.ServiceType);
            switch (d.LifetimeType) {
                case RegisterProxyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case RegisterProxyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case RegisterProxyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }

        private static void TypeToInstanceRegister(ContainerBuilder services, RegisterProxyDescriptor d) {
            var builder = services.RegisterInstance(d.InstanceOfImplementation).As(d.ServiceType);
            switch (d.LifetimeType) {
                case RegisterProxyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case RegisterProxyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case RegisterProxyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }

        private static void TypeToInstanceFuncRegister(ContainerBuilder services, RegisterProxyDescriptor d) {
            var builder = services.Register(c => d.InstanceFuncForImplementation()).As(d.ServiceType);

            switch (d.LifetimeType) {
                case RegisterProxyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case RegisterProxyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case RegisterProxyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }

        private static void TypeSelfRegister(ContainerBuilder services, RegisterProxyDescriptor d) {
            var builder = services.RegisterType(d.ImplementationTypeSelf);
            switch (d.LifetimeType) {
                case RegisterProxyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case RegisterProxyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case RegisterProxyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }

        private static void InstanceSelfRegister(ContainerBuilder services, RegisterProxyDescriptor d) {
            var builder = services.RegisterInstance(d.InstanceOfImplementation);
            switch (d.LifetimeType) {
                case RegisterProxyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case RegisterProxyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case RegisterProxyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }

        private static void InstanceSelfFuncRegister(ContainerBuilder services, RegisterProxyDescriptor d) {
            var builder = services.RegisterInstance(d.InstanceFuncForImplementation());
            switch (d.LifetimeType) {
                case RegisterProxyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case RegisterProxyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case RegisterProxyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }
    }
}