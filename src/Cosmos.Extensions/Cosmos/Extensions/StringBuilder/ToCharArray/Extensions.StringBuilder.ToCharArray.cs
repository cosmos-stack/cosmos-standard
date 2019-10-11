using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// To char array
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static char[] ToCharArray(this StringBuilder builder)
        {
            var results = new char[builder.Length];

            builder.CopyTo(0, results, 0, builder.Length);

            return results;
        }
    }
}
