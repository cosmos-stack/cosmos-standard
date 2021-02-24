using System;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Must positive or zero, alias of <see cref="NotNegativeAttribute"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class MustPositiveOrZeroAttribute : NotNegativeAttribute
    {
        /// <summary>
        /// Name of this Attribute/Annotation
        /// </summary>
        public override string Name => "Must-Positive-Or-Zero Annotation";
    }
}