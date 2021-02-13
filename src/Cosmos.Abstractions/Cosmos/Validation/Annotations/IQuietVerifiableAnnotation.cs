using System;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// A Quiet Verify Interface
    /// </summary>
    public interface IQuietVerifiableAnnotation : IVerifiable
    {
        /// <summary>
        /// Gets or sets message<br />
        /// 消息
        /// </summary>
        public string ErrorMessage { get; set; }
        
        /// <summary>
        /// Quiet Verify
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool QuietVerify<T>(T instance);

        /// <summary>
        /// Quiet Verify
        /// </summary>
        /// <param name="type"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool QuietVerify(Type type,object instance);
    }
}