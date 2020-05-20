using System;
using System.IO;
using System.Threading.Tasks;

namespace Cosmos.Serialization
{
    /// <summary> 
    /// Object Serializer Meta Interface<br />
    /// 对象序列化器元接口
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serialize<br />
        /// 序列化
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Stream SerializeToStream<T>(T o);

        /// <summary>
        /// Deserialize<br />
        /// 反序列化
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T DeserializeFromStream<T>(Stream stream);

        /// <summary>
        /// Deserialize<br />
        /// 反序列化
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object DeserializeFromStream(Stream stream, Type type);

        /// <summary>
        /// Serialize async<br />
        /// 异步序列化
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<Stream> SerializeToStreamAsync<T>(T o);

        /// <summary>
        /// Deserialize async<br />
        /// 异步反序列化
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<T> DeserializeFromStreamAsync<T>(Stream stream);

        /// <summary>
        /// Deserialize async<br />
        /// 异步反序列化
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<object> DeserializeFromStreamAsync(Stream stream, Type type);
    }
}