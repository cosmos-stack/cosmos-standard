using System;

namespace CosmosStack.Serialization
{
    /// <summary>
    /// An interface of configuration entry for json serializer.
    /// </summary>
    public interface IJsonSerializerConfigureEntry
    {
        /// <summary>
        /// To config / use a json serializer
        /// </summary>
        /// <param name="serializer"></param>
        void ConfigureJsonSerializer(IJsonSerializer serializer);

        /// <summary>
        /// To config / use a json serializer
        /// </summary>
        /// <param name="serializerFactory"></param>
        void ConfigureJsonSerializer(Func<IJsonSerializer> serializerFactory);
    }
}