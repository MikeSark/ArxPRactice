#nullable enable

using System.Collections;
using ArxAlgorithms.Interfaces;

namespace ArxAlgorithms.Shared;

public class MultiValueDictioanry<TK, TV> : IMultiValueDictioanry<TK, TV> where TK : notnull
{
    private readonly Dictionary<TK, HashSet<TV>> _storage = new();


    public IEnumerable<KeyValuePair<TK, TV>> Get(TK key)
    {
        if (!_storage.Keys.Contains(key))
            throw new KeyNotFoundException($"No Key found stored.");


        var hassetOfTv = _storage[key];
        foreach (var tv in hassetOfTv)
        {
            yield return new KeyValuePair<TK, TV>(key, tv);
        }
    }

    public bool TryGetValue(TK key, out IEnumerable<TV> value)
    {
        if (_storage.TryGetValue(key, out var hashSetOfTv))
        {
            value = hashSetOfTv;
            return true;
        }

        value = new HashSet<TV>();
        return false;
    }

    public bool Add(TK key, TV value)
    {
        if (!_storage.Keys.Contains(key))
        {
            _storage.Add(key, [value]);
            return true;
        }

        var hashSetOfTv = _storage[key];
        if (hashSetOfTv.Add(value))
        {
            return true;
        }

        return false;
    }

    public void Remove(TK key, TV value)
    {
        if (!_storage.Keys.Contains(key))
            return;

        var hashSetOfTv = _storage[key];
        hashSetOfTv.Remove(value);
    }


    public void Clear(TK key)
    {
        if (!_storage.Keys.Contains(key))
            _storage.Remove(key);
    }

    public bool ContainsKey(TK key)
    {
        return _storage.Keys.Contains(key);
    }

    public bool ContainsValue(TK key, TV value)
    {
        if (!_storage.Keys.Contains(key))
            return false;

        var hashSetOfTv = _storage[key];
        return hashSetOfTv.Contains(value);
    }

    public IEnumerable<TV> this[TK key]
    {
        get { yield break; }
    }

    public IEnumerable<KeyValuePair<TK, TV>> Flatten()
    {
        foreach (var item in _storage)
        {
            foreach (var hasSetList in item.Value)
            {
                yield return new KeyValuePair<TK, TV>(item.Key, hasSetList);
            }
        }
    }

    public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
    {
        foreach (var item in _storage)
        {
            foreach (var tv in item.Value)
            {
                yield return new KeyValuePair<TK, TV>(item.Key, tv);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}