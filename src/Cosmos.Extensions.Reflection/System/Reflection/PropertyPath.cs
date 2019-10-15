using System.Collections.Generic;
using System.Diagnostics;

namespace System.Reflection
{
    /// <summary>
    /// Property path
    /// </summary>
    public class PropertyPath
    {
        internal PropertyPath() : this(null) { }

        internal PropertyPath(PropertyPath root)
        {
            // If the root is null, assign the path.
            if (root == null)
            {
                // Assign path.
                _path = new Queue<PropertyInfo>();

                // Set the root.
                Root = this;
            }
            else
                // Root is root.
                Root = root;

            // Root must not be null.
            Debug.Assert(Root != null);
        }

        private readonly Queue<PropertyInfo> _path;

        /// <summary>
        /// Root
        /// </summary>
        public PropertyPath Root { get; }

        /// <summary>
        /// Path
        /// </summary>
        public IEnumerable<PropertyInfo> Path => Root._path;

        /// <summary>
        /// Append
        /// </summary>
        /// <param name="property"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected void Append(PropertyInfo property)
        {
            // Validate parameters.
            if (property == null) throw new ArgumentNullException(nameof(property));

            // Push.
            Root._path.Enqueue(property);
        }

        /// <summary>
        /// Of
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PropertyPath<T> Of<T>()
        {
            // Create a new instance.
            return new PropertyPath<T>();
        }
    }
}