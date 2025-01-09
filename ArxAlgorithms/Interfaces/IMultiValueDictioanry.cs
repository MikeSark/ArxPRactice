#nullable enable

namespace ArxAlgorithms.Interfaces;

public interface IMultiValueDictioanry<TK, TV> : IEnumerable<KeyValuePair<TK, TV>>
{
    IEnumerable<KeyValuePair<TK, TV>> Get(TK key);
    public bool TryGetValue(TK key, out IEnumerable<TV> value);
    public bool Add(TK key, TV value);
    public void Remove(TK key, TV value);
    public void Clear(TK key);
    public bool ContainsKey(TK key);
    public bool ContainsValue(TK key, TV value);
    IEnumerable<TV> this[TK key] { get; }
    IEnumerable<KeyValuePair<TK, TV>> Flatten();
}