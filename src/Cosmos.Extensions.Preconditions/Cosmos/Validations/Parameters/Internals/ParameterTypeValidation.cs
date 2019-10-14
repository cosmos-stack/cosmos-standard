using System;

namespace Cosmos.Validations.Parameters.Internals
{
    /// <summary>
    /// Parameter type validation
    /// </summary>
    public class ParameterTypeValidation : IOperationResult<bool>
    {
        /// <summary>
        /// Create a new instance of <see cref="ParameterTypeValidation"/>
        /// </summary>
        /// <param name="result"></param>
        /// <param name="parameterType"></param>
        public ParameterTypeValidation(bool result, Type parameterType)
        {
            Result = result;
            ParameterType = parameterType;
        }

        /// <summary>
        /// Result
        /// </summary>
        public bool Result { get; }

        /// <summary>
        /// Parameter type
        /// </summary>
        public Type ParameterType { get; }

        /// <summary>
        /// Convert instance of <see cref="ParameterTypeValidation"/> to <see cref="System.Boolean"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static implicit operator bool(ParameterTypeValidation result)
        {
            return result.Result;
        }
    }
}