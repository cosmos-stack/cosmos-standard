using AspectCore.Injector;

namespace Cosmos.Dependency
{
    /// <summary>
    /// Extensions for lifetime
    /// </summary>
    public static class LifetimeExtensions
    {
        /// <summary>
        /// To NCC AspectCore lifetime
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Lifetime ToAspectCoreLifetime(this RegisterProxyLifetimeType type)
        {
            switch (type)
            {
                case RegisterProxyLifetimeType.Scoped:
                    return Lifetime.Scoped;

                case RegisterProxyLifetimeType.Singleton:
                    return Lifetime.Singleton;

                case RegisterProxyLifetimeType.Transient:
                    return Lifetime.Transient;

                default:
                    return Lifetime.Transient;
            }
        }
    }
}