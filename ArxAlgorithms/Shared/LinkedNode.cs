using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArxAlgorithms.Shared;
public class ListNode<T>
{
    public T Item { get; set; }
    public ListNode<T> Next { get; set; }

    public ListNode(T item, ListNode<T> next = null)
    {
        Item = item;
        Next = next;
    }

    public override string ToString() => $"{Item},{(Next == null ? "NULL" : Next.Item.ToString())}";
}
