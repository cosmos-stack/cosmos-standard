namespace Cosmos.Conversions.ObjectMappingServices;

/// <summary>
/// Object Mapper Meta Interface<br />
/// 对象映射元接口
/// </summary>
public interface IObjectMapper : IGenericObjectMapper
{
    /// <summary>
    /// Map to<br />
    /// 映射至……
    /// </summary>
    /// <param name="sourceType"></param>
    /// <param name="destinationType"></param>
    /// <param name="source"></param>
    /// <returns>映射结果</returns>
    object MapTo(Type sourceType, Type destinationType, object source);

    /// <summary>
    /// Map to<br />
    /// 映射至……
    /// </summary>
    /// <param name="sourceType"></param>
    /// <param name="destinationType"></param>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <returns>映射结果</returns>
    object MapTo(Type sourceType, Type destinationType, object source, object destination);
}