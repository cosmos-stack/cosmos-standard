namespace Cosmos;

/// <summary>
/// Opt result<br />
/// 操作结果接口
/// </summary>
/// <typeparam name="T">指定的操作结果的类型</typeparam>
public interface IOperationResult<out T>
{
    /// <summary>
    /// Gets operation result<br />
    /// 获取操作结果
    /// </summary>
    T Result { get; }
}