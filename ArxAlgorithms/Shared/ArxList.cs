using ArxAlgorithms.Interfaces;

namespace ArxAlgorithms.Shared;

public class ArxList<T> : IArxList<T>
{
    private readonly List<T> _storage = new List<T>();

    public T Minimum { get; set; } = default!;
    public T Maximum { get; set; } = default!;

    public void Add(T value)
    {
        if (Minimum == null || Comparer<T>.Default.Compare(value, Minimum) <= 0 || IsDefaultValue(Minimum))
        {
            Minimum = value;
        }

        if (Maximum == null || Comparer<T>.Default.Compare(value, Maximum) > 0)
        {
            Maximum = value;
        }

        _storage.Add(value);
    }

    public void Remove(T value) { }

    public bool Contains(T value)
    {
        return false;
    }

    public void Clear() { }

    public T this[int index]
    {
        get => default;
        set { }
    }


    public void PrintAll()
    {
        foreach (var item in _storage)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine($"Minimum :{Minimum}");
        Console.WriteLine($"Maximum :{Maximum}");
    }



    public bool IsDefaultValue(T value)
    {
        Console.WriteLine($"The type of T is: {typeof(T)}");

        // Check for specific types
        if (typeof(T) == typeof(int))
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }
        else if (typeof(T) == typeof(string))
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }
        else
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }
    }

}