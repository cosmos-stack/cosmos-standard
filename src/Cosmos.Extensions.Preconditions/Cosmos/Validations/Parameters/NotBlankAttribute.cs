using System;

namespace Cosmos.Validations.Parameters {
    /// <summary>
    /// Not blank
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotBlankAttribute : NotWhiteSpaceAttribute, IValidationParameter { }
}