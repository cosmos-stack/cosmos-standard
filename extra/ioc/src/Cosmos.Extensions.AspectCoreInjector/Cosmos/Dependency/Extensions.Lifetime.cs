using AspectCore.Injector;

namespace Cosmos.Dependency
{
    public static class LifetimeExtensions
    {
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
