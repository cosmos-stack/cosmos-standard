using System.Text;
using Cosmos.Collections;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    /// <summary>
    /// StringBuilder extensions
    /// </summary>
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Reverse
        /// </summary>
        /// <param name="builder"></param>
        public static void Reverse(this StringBuilder builder)
        {
            if (builder is null || builder.Length == 0)
                return;

            var destination = new char[builder.Length];
            builder.CopyTo(0, destination, 0, builder.Length);
            destination.Reverse();

            builder.Clear();
            builder.Append(destination);
        }

        /// <summary>
        /// Reverse <see cref="StringBuilder"/>
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static StringBuilder ToReverseBuilder(this StringBuilder builder)
        {
            if (builder is null || builder.Length == 0)
                return builder;
            var destination = new char[builder.Length];
            builder.CopyTo(0, destination, 0, builder.Length);
            destination.Reverse();
            return new StringBuilder().Append(destination);
        }

        /// <summary>
        /// Reverse string
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static string ToReverseString(this StringBuilder builder)
        {
            if (builder is null || builder.Length == 0)
                return string.Empty;
            return builder.ToReverseBuilder().ToString();
        }
    }
}