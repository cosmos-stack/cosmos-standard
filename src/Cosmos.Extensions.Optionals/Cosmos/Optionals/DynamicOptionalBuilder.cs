using System.Diagnostics.CodeAnalysis;
using Cosmos.Optionals.DynamicOptionals;

namespace Cosmos.Optionals;

/// <summary>
/// Dynamic optional builder <br />
/// 动态 MayBe 组件构建器
/// </summary>
public class DynamicOptionalBuilder : IDynamicOptionalBuilder
{
    private readonly Dictionary<string, dynamic> _dynamicDictionary;
    private readonly List<string> _queueLikeList;
    private object _dynamicLockObj = new();

    private DynamicOptionalBuilder()
    {
        _dynamicDictionary = new Dictionary<string, dynamic>();
        _queueLikeList = new List<string>();
    }

    private DynamicOptionalBuilder(DynamicOptionalObject dynamicOptionalObject)
    {
        _dynamicDictionary = new Dictionary<string, dynamic>(dynamicOptionalObject.InternalDynamicDictionary);
        _queueLikeList = new List<string>(dynamicOptionalObject.InternalQueueLikeList);
    }

    /// <summary>
    /// Create the dynamic optional builder <br />
    /// 创建一个动态 MayBe 组件构建器
    /// </summary>
    /// <returns></returns>
    public static DynamicOptionalBuilder Create() => new();

    internal static DynamicOptionalBuilder Returns(DynamicOptionalObject dynamicOptionalObject) => new(dynamicOptionalObject);

    internal static DynamicOptionalBuilder Returns(IDictionary<string, dynamic> dynamicDictionary, IEnumerable<string> queueLikeList) =>
        Returns(new DynamicOptionalObject(dynamicDictionary, queueLikeList));

    /// <inheritdoc />
    public IDynamicOptionalBuilder May(dynamic value, string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));
        lock (_dynamicLockObj)
        {
            if (_queueLikeList.Contains(key))
                throw new InvalidOperationException("Key has been repeated in the dictionary.");
            _queueLikeList.Add(key);
            _dynamicDictionary.Add(key, value);
        }

        return this;
    }

    /// <inheritdoc />
    public IDynamicOptionalBuilder SilenceMay(dynamic value, string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));
        lock (_dynamicLockObj)
        {
            if (_queueLikeList.Contains(key))
            {
                _dynamicDictionary[key] = value;
            }
            else
            {
                _queueLikeList.Add(key);
                _dynamicDictionary.Add(key, value);
            }
        }

        return this;
    }

    /// <summary>
    /// Build <br />
    /// 构建
    /// </summary>
    /// <returns></returns>
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")]
    public DynamicMaybe Build()
    {
        var dynamicObj = new DynamicOptionalObject(_dynamicDictionary, _queueLikeList);

        return new DynamicMaybe(dynamicObj);
    }
}