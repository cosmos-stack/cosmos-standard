using System;

namespace Cosmos.Domain {
    /// <summary>
    /// Entity map ignore scanning
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityMapIgnoreScanningAttribute : Attribute { }
}