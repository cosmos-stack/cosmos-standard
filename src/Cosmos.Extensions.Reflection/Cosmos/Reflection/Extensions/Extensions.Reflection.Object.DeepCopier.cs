using DeepCopy;

// ReSharper disable once CheckNamespace
namespace Cosmos.Reflection
{
    /// <summary>
    /// Object extensions
    /// </summary>
    public static partial class ObjectExtensions
    {
        /// <summary>
        /// Deep copy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <returns></returns>
        public static T DeepCopy<T>(this T original) => DeepCopier.Copy(original);
    }
}