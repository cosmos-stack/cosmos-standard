using Cosmos.Lit;

namespace Cosmos.Extensions
{
    /// <summary>
    /// LitJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// To LitJson
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToLitJson<T>(this T o)
        {
            return LitHelper.Serialize(o);
        }
    }
}
