using System.Linq;
using System.Text;

namespace System.Reflection
{
    /// <summary>
    /// Cosmos <see cref="Type"/> extensions
    /// </summary>
    public static partial class SystemTypeExtensions
    {
        #region GetFullyQualifiedName

        /// <summary>
        /// Get unique fully qualified name for <see cref="TypeInfo"/>.<br />
        /// 获取给定 <see cref="TypeInfo"/> 的完全限定名。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFullyQualifiedName(this Type type)
        {
            var sb = new StringBuilder();
            if (type.IsGenericType)
            {
                sb.Append(type.GetGenericTypeDefinition().FullName)
                    .Append("[");

                var genericArgs = type.GetGenericArguments().ToList();
                for (var i = 0; i < genericArgs.Count; i++)
                {
                    sb.Append(genericArgs[i].GetFullyQualifiedName());
                    if (i != genericArgs.Count - 1)
                        sb.Append(", ");
                }

                sb.Append("]");
            }
            else
            {
                if (!string.IsNullOrEmpty(type.FullName))
                    sb.Append(type.FullName);
                else if (!string.IsNullOrEmpty(type.Name))
                    sb.Append(type.Name);
                else
                    sb.Append(type);
            }

            return sb.ToString();
        }

        #endregion
    }
}