using DeepCopy;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class ObjectExtensions
    {
        /// <summary>
        /// Deep copy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <returns></returns>
        public static T DeepCopy<T>(this T original)
        {
            return DeepCopier.Copy(original);
        }
    }
}