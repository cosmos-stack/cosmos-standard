using System;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Number only
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NumberOnlyAttribute : MustNumericTypeAttribute, IValidationParameter { }
}