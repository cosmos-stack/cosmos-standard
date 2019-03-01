using RSG;

namespace Cosmos.Asynchronous.Promise
{
    public static class Promises
    {
        public static IPromise<T> Create<T>() => new Promise<T>();
    }
}
