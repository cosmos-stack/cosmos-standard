using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    public static partial class BaseTypeExtensions
    {
        /// <summary>
        /// Fill
        /// </summary>
        /// <param name="original"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string Fill(this string original, params object[] values)
        {
            var s = original.Replace("\\n", Environment.NewLine)
               .Replace("<br>", Environment.NewLine)
               .Replace("<BR>", Environment.NewLine);

            return string.Format(s, values);
        }
    }
}