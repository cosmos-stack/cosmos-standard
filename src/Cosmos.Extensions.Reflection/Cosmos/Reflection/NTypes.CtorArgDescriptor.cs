#if !NET451

using System;

/*
 * Author: LanX
 * 2020.01.03
 */

namespace Cosmos.Reflection
{
    /// <summary>
    /// Descriptor of argument
    /// </summary>
    public class CtorArgDescriptor
    {
        // /// <summary>
        // /// Create a new instance of <see cref="CtorArgDescriptor"/>.
        // /// </summary>
        // public CtorArgDescriptor() { }

        /// <summary>
        /// Create a new instance of <see cref="CtorArgDescriptor"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public CtorArgDescriptor(string name, object value, Type type)
        {
            Name = name;
            Value = value;
            Type = type;
        }

        /// <summary>
        /// Argument name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Argument value
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Argument type
        /// </summary>
        public Type Type { get; set; }
    }
}

#endif