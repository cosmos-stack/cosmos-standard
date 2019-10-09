using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Dependency
{
    /// <summary>
    /// Lifetime extensions
    /// </summary>
    public static class LifetimeExtensions
    {
        /// <summary>
        /// To Microsoft Lifetime
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
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