namespace Cosmos.Collections.Internals;

internal class CastingReadOnlyDictionaryWrapper<TFromKey, TFromValue, TToKey, TToValue> :
    IReadOnlyDictionary<TToKey, TToValue>
    where TFromKey : TToKey
    where TFromValue : TToValue
{
    private readonly IReadOnlyDictionary<TFromKey, TFromValue> _source;

    internal CastingReadOnlyDictionaryWrapper(IReadOnlyDictionary<TFromKey, TFromValue> source)
    {
        _source = source ?? throw new ArgumentNullException(nameof(source));
    }

    public IEnumerator<KeyValuePair<TToKey, TToValue>> GetEnumerator()
    {
        return _source.Select(p => new KeyValuePair<TToKey, TToValue>(p.Key, p.Value)).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int Count => _source.Count;

    public bool ContainsKey(TToKey key) => _source.ContainsKey((TFromKey) key);

    public bool TryGetValue(TToKey key, out TToValue value)
    {
        var result = _source.TryGetValue((TFromKey) key, out var typedValue);

        value = typedValue;

        return result;
    }

    public TToValue this[TToKey key] => _source[(TFromKey) key];

    public IEnumerable<TToKey> Keys => _source.Keys.Cast<TToKey>();

    public IEnumerable<TToValue> Values => _source.Keys.Cast<TToValue>();
}