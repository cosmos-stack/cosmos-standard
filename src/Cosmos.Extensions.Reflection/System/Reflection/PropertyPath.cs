using System.Collections.Generic;
using System.Diagnostics;

namespace System.Reflection {
    /// <summary>
    /// Property path
    /// </summary>
    public class PropertyPath {
        internal PropertyPath() : this(null) { }

        internal PropertyPath(PropertyPath root) {
            if (root == null) {
                _path = new Queue<PropertyInfo>();
                Root = this;
            }
            else {
                Root = root;
            }

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
        protected void Append(PropertyInfo property) {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            Root._path.Enqueue(property);
        }

        /// <summary>
        /// Of
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PropertyPath<T> Of<T>() => new PropertyPath<T>();
    }
}