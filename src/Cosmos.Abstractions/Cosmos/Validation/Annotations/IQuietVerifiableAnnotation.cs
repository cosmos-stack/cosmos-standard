namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// A Quiet Verify Interface
    /// </summary>
    public interface IQuietVerifiableAnnotation : IVerifiable
    {
        /// <summary>
        /// Quiet Verify
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool QuietVerify<T>(T instance);
    }
}