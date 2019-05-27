using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringBuilderExtensions
    {
        public static void Reverse(this StringBuilder builder)
        {
            if (builder == null || builder.Length == 0)
                return;

            var destination = new char[builder.Length];
            builder.CopyTo(0, destination, 0, builder.Length);
            destination.Reverse();

            builder.Clear();
            builder.Append(destination);
        }

        public static StringBuilder ToReverseBuilder(this StringBuilder builder)
        {
            if (builder == null || builder.Length == 0)
                return builder;

            var destination = new char[builder.Length];
            builder.CopyTo(0, destination, 0, builder.Length);
            destination.Reverse();
            return new StringBuilder().Append(destination);
        }

        public static string ToReverseString(this StringBuilder builder)
        {
            if (builder == null || builder.Length == 0)
                return string.Empty;
            return builder.ToReverseBuilder().ToString();
        }
    }
}
