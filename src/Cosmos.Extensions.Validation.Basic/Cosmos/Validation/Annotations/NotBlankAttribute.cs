using System;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Not blank
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotBlankAttribute : NotWhiteSpaceAttribute
    {
        /// <summary>
        /// Name of this Attribute/Annotation
        /// </summary>
        public override string Name => "Not-Blank Annotation";
    }
}