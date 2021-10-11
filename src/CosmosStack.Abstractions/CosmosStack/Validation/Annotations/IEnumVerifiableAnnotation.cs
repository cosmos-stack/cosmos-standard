using System;

namespace CosmosStack.Validation.Annotations
{
    /// <summary>
    /// Use this interface for the enumeration validator to allow the use of custom validation logic in the
    /// enumeration component, enumeration enhancement component, or verification component. <br />
    /// 将该接口用于枚举验证器，以便允许在枚举组件、枚举增强组件或验证组件中使用自定义的验证逻辑。 
    /// </summary>
    public interface IEnumVerifiableAnnotation<TEnum> : IVerifiable where TEnum : struct, Enum
    {
        /// <summary>
        /// Verify that the given value is valid. <br />
        /// 验证给定的值是否有效。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Verify(TEnum value);
    }
}