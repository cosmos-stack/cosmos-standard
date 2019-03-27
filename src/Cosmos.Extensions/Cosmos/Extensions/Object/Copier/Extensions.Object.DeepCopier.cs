using DeepCopy;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class ObjectExtensions
    {
        public static T DeepCopy<T>(this T original)
        {
            return DeepCopier.Copy(original);
        }
    }
}