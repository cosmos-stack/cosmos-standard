using System;

namespace Cosmos.Validation.Parameters
{
    /// <summary>
    /// Between, alias of <see cref="NotOutOfRangeAttribute"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class BetweenAttribute : NotOutOfRangeAttribute, IValidationParameter { }
}