using System;
using System.Collections.Generic;

namespace Cosmos.Dependency
{
    public class RegisterProxyBag
    {
        private readonly List<RegisterProxyDescriptor> _descriptors = new List<RegisterProxyDescriptor>();

        public void Register(RegisterProxyDescriptor descriptor)
        {
            if (descriptor == null)
                throw new ArgumentNullException(nameof(descriptor));

            _descriptors.Add(descriptor);
        }

        public IReadOnlyList<RegisterProxyDescriptor> ExportDescriptors() => _descriptors.AsReadOnly();

        public static RegisterProxyBag Create() => new RegisterProxyBag();
    }
}
