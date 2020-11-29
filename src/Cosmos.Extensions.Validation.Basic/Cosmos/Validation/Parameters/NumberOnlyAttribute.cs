using System;

namespace Cosmos.Validation.Parameters
{
    /// <summary>
    /// Number only
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NumberOnlyAttribute : MustNumericTypeAttribute, IValidationParameter { }
}