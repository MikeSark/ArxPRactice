namespace ArxAlgorithms.Shared;

public class Node
{
    public int Data;
    public Node? Left;
    public Node? Right;

    public Node(int data)
    {
        Data = data;
        Left = Right = null;
    }
}