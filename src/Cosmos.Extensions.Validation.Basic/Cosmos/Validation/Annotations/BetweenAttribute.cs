using System;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Between, alias of <see cref="NotOutOfRangeAttribute"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class BetweenAttribute : NotOutOfRangeAttribute, IValidationAnnotation { }
}