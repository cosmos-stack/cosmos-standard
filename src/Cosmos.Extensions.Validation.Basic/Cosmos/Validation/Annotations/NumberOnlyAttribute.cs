using System;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Number only
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NumberOnlyAttribute : MustNumericTypeAttribute
    {
        /// <summary>
        /// Name of this Attribute/Annotation
        /// </summary>
        public override string Name => "Number-Only Annotation";
    }
}