using Cosmos.Lit;

namespace Cosmos.Extensions
{
    public static partial class Extensions
    {
        public static string ToLitJson<T>(this T o)
        {
            return LitHelper.Serialize(o);
        }
    }
}
