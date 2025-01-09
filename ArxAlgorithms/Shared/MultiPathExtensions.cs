using ArxAlgorithms.Interfaces;

namespace ArxAlgorithms.Shared;

public static class MultiPathExtensions
{
    public static IMultiValueDictioanry<TKey, TValue> Union<TKey, TValue>(this IMultiValueDictioanry<TKey, TValue> first, IMultiValueDictioanry<TKey, TValue> second) where TKey : notnull
    {
        var result = new MultiValueDictioanry<TKey, TValue>();
        foreach (var kvp in first)
            result.Add(kvp.Key, kvp.Value);

        foreach (var kvp in second)
            result.Add(kvp.Key, kvp.Value);

        return result;
    }

    public static IMultiValueDictioanry<TKey, TValue> Intersection<TKey, TValue>(this IMultiValueDictioanry<TKey, TValue> first, IMultiValueDictioanry<TKey, TValue> second) where TKey : notnull
    {
        var result = new MultiValueDictioanry<TKey, TValue>();
        foreach (var kvp in first)
        {
            if (second.ContainsKey(kvp.Key))
            {
                result.Add(kvp.Key, kvp.Value);
            }
        }


        foreach (var kvp in second)
        {
            if (first.ContainsKey(kvp.Key))
            {
                result.Add(kvp.Key, kvp.Value);
            }
        }

        return result;
    }

    public static IMultiValueDictioanry<TKey, TValue> Difference<TKey, TValue>(this IMultiValueDictioanry<TKey, TValue> first, IMultiValueDictioanry<TKey, TValue> second) where TKey : notnull
    {
        var result = new MultiValueDictioanry<TKey, TValue>();
        foreach (var kvp in first)
        {
            if (!second.ContainsKey(kvp.Key))
            {
                result.Add(kvp.Key, kvp.Value);
            }
        }

        return result;
    }

    public static IMultiValueDictioanry<TKey, TValue> SymmetricDifference<TKey, TValue>(this IMultiValueDictioanry<TKey, TValue> first, IMultiValueDictioanry<TKey, TValue> second) where TKey : notnull
    {
        var result = new MultiValueDictioanry<TKey, TValue>();
        foreach (var kvp in first)
        {
            if (!second.ContainsKey(kvp.Key))
            {
                result.Add(kvp.Key, kvp.Value);
            }
        }

        foreach (var kvp in second)
        {
            if (!first.ContainsKey(kvp.Key))
            {
                result.Add(kvp.Key, kvp.Value);
            }
        }

        return result;
    }
}