using System;
using System.Collections.Generic;

namespace Cosmos.Dependency
{
    /// <summary>
    /// Register proxy bag
    /// </summary>
    public class RegisterProxyBag
    {
        private readonly List<RegisterProxyDescriptor> _descriptors = new List<RegisterProxyDescriptor>();

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="descriptor"></param>
        public void Register(RegisterProxyDescriptor descriptor)
        {
            if (descriptor == null)
                throw new ArgumentNullException(nameof(descriptor));

            _descriptors.Add(descriptor);
        }

        /// <summary>
        /// Export Descriptors
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<RegisterProxyDescriptor> ExportDescriptors() => _descriptors.AsReadOnly();

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        public static RegisterProxyBag Create() => new RegisterProxyBag();
    }
}
