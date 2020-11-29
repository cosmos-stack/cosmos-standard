using System;

namespace Cosmos.Validation.Parameters
{
    /// <summary>
    /// Not blank
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotBlankAttribute : NotWhiteSpaceAttribute, IValidationParameter { }
}