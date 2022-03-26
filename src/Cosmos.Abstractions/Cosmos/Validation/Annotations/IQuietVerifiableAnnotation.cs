namespace Cosmos.Validation.Annotations;

/// <summary>
/// A Quiet Verify Interface <br />
/// 静默验证接口
/// </summary>
public interface IQuietVerifiableAnnotation : IVerifiable
{
    /// <summary>
    /// Gets or sets message<br />
    /// 消息
    /// </summary>
    public string ErrorMessage { get; set; }

    /// <summary>
    /// Quiet Verify <br />
    /// 静默验证
    /// </summary>
    /// <param name="instance"></param>
    /// <returns></returns>
    bool QuietVerify<T>(T instance);

    /// <summary>
    /// Quiet Verify <br />
    /// 静默验证
    /// </summary>
    /// <param name="type"></param>
    /// <param name="instance"></param>
    /// <returns></returns>
    bool QuietVerify(Type type, object instance);
}