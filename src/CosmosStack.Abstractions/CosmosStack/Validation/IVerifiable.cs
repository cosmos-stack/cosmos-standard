namespace CosmosStack.Validation
{
    /// <summary>
    /// A verifiable interface <br />
    /// 可验证接口
    /// </summary>
    public interface IVerifiable
    {
        /// <summary>
        /// Name of this Attribute/Annotation/VerifiableObject <br />
        /// 名称（一般用于特性、注解或可验证对象）
        /// </summary>
        string Name { get; }
    }
}