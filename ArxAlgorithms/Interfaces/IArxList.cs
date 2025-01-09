namespace ArxAlgorithms.Interfaces;

public interface IArxList<T>
{
    public T Minimum { get; set; }
    public T Maximum { get; set; }

    public void Add(T value);
    public void Remove(T value);
    public bool Contains(T value);
    public void Clear();

    public T this[int index] { get; set; }
}