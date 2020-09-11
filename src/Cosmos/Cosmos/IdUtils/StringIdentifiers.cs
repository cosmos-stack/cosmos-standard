using System;
using System.Text;
using Cosmos.Text;

namespace Cosmos.IdUtils
{
    public static class StringIdentifiers
    {
        /// <summary>
        /// To valid identifier
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string ToValidIdentifier(string original)
        {
            original = original.ToCapitalCase();

            if (original.Length == 0)
                return "_";

            var res = new StringBuilder(original.Length + 1);
            if (!char.IsLetter(original[0]) && original[0] != '_')
                res.Append('_');

            for (var i = 0; i < original.Length; i++)
            {
                var c = original[i];
                if (char.IsLetterOrDigit(c) || c == '_')
                    res.Append(c);
                else
                    res.Append('_');
            }

            return res.ToString().ReplaceRecursive("__", "_").Trim('_');
        }
    }
}