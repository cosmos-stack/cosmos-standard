using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Dependency
{
    public static class LifetimeExtensions
    {
        public static ServiceLifetime ToMsLifetime(this RegisterProxyLifetimeType type)
        {
            switch (type)
            {
                case RegisterProxyLifetimeType.Scoped:
                    return ServiceLifetime.Scoped;

                case RegisterProxyLifetimeType.Singleton:
                    return ServiceLifetime.Singleton;

                case RegisterProxyLifetimeType.Transient:
                    return ServiceLifetime.Transient;

                default:
                    return ServiceLifetime.Transient;
            }
        }
    }
}
