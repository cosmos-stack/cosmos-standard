namespace Cosmos.Validation
{
    /// <summary>
    /// A verifiable interface
    /// </summary>
    public interface IVerifiable
    {
        /// <summary>
        /// Name of this Attribute/Annotation/VerifiableObject
        /// </summary>
        string Name { get; }
    }
}