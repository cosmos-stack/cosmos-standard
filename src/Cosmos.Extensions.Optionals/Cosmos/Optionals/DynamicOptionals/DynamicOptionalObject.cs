using System.Collections.ObjectModel;
using System.Dynamic;
using System.Text;

namespace Cosmos.Optionals.DynamicOptionals;

/// <summary>
/// Dynamic optional object <br />
/// 动态可选对象
/// </summary>
public class DynamicOptionalObject
{
    private readonly Dictionary<string, dynamic> _dynamicDictionary;
    private readonly IList<string> _queueLikeList;

    /// <summary>
    /// Dynamic optional object
    /// </summary>
    /// <param name="dynamicDictionary"></param>
    /// <param name="queueLikeList"></param>
    public DynamicOptionalObject(IDictionary<string, dynamic> dynamicDictionary, IEnumerable<string> queueLikeList)
    {
        if (dynamicDictionary is not null)
        {
            _dynamicDictionary = new Dictionary<string, dynamic>(dynamicDictionary);
            _queueLikeList = new List<string>(queueLikeList);
        }
        else
        {
            _dynamicDictionary = new Dictionary<string, dynamic>();
            _queueLikeList = new List<string>();
        }
    }

    #region Internal

    internal IReadOnlyDictionary<string, dynamic> InternalDynamicDictionary => _dynamicDictionary;

    internal IList<string> InternalQueueLikeList => _queueLikeList;

    #endregion

    #region Indexer

    /// <summary>
    /// Indexer <br />
    /// 索引器
    /// </summary>
    /// <param name="index"></param>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public dynamic this[int index]
    {
        get
        {
            if (index < 0 || index >= _queueLikeList.Count)
                throw new IndexOutOfRangeException($"Index value {index} is out of range.");
            return this[_queueLikeList[index]];
        }
    }

    /// <summary>
    /// Indexer
    /// </summary>
    /// <param name="key"></param>
    public dynamic this[string key] => _dynamicDictionary.TryGetValue(key, out var result) ? result : default!;

    #endregion

    #region Get dynamic object

    /// <summary>
    /// Get dynamic object <br />
    /// 获取动态对象
    /// </summary>
    /// <returns></returns>
    public dynamic GetDynamicObject()
    {
        dynamic dynamicObject = new ExpandoObject();
        foreach (var item in _dynamicDictionary)
        {
            dynamicObject[item.Key] = item.Value;
        }

        return dynamicObject;
    }

    #endregion

    #region Enumerable

    /// <summary>
    /// To enumerable
    /// </summary>
    /// <returns></returns>
    public IEnumerable<KeyValuePair<string, dynamic>> ToEnumerable()
    {
        return _dynamicDictionary;
    }

    /// <summary>
    /// Get enumrtator
    /// </summary>
    /// <returns></returns>
    public IEnumerator<KeyValuePair<string, dynamic>> GetEnumerator()
    {
        return _dynamicDictionary.GetEnumerator();
    }

    #endregion

    #region Contains / Exists

    /// <summary>
    /// Contains
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool Contains(string key)
    {
        return _queueLikeList.Contains(key) && _dynamicDictionary.ContainsKey(key);
    }

    /// <summary>
    /// Exists
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public bool Exists(Func<string, bool> predicate)
    {
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        return _queueLikeList.Any(predicate) && _dynamicDictionary.Keys.Any(predicate);
    }

    #endregion

    #region Keys / Values

    public string Key
    {
        get
        {
            var sb = new StringBuilder();
            foreach (var key in Keys)
            {
                sb.Append($"{key}-");
            }

            return sb.Length > 0 ? sb.ToString(0, sb.Length - 1) : "EmptyDynamicOptional";
        }
    }

    /// <summary>
    /// Gets keys
    /// </summary>
    public IEnumerable<string> Keys => new ReadOnlyCollection<string>(_queueLikeList);

    /// <summary>
    /// Gets values
    /// </summary>
    public IEnumerable<dynamic> Values => new ReadOnlyCollection<dynamic>(_dynamicDictionary.Values.ToList());

    #endregion
}