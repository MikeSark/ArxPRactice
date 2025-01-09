using ArxAlgorithms.Shared;

namespace ArxAlgorithms.Math;
public class AddTwoNumbersLinkedList
{
    /// <summary>
    /// This algorithm does not use a dummy head but it has to maintain a previous node.
    /// </summary>
    /// <param name="l1">The head of a linked-list containing the first number</param>
    /// <param name="l2">The head of a linked-list containing the second number</param>
    /// <returns>The head of the linked-list containing the result</returns>
    public static ListNode<int> AddTwoNumbers(ListNode<int> l1, ListNode<int> l2)
    {
        var curr = new ListNode<int>(0);
        ListNode<int> prev = null;
        var result = curr;
        var carry = 0;

        while (l1 != null || l2 != null)
        {
            var sum =
                (l1?.Item ?? 0) +
                (l2?.Item ?? 0) + carry;

            curr.Item = sum % 10;
            carry = sum / 10;

            if (prev != null)
                prev.Next = curr;

            prev = curr;
            curr = new ListNode<int>(0);

            l1 = l1?.Next;
            l2 = l2?.Next;
        }

        // Take care about a possible carry.
        if (carry > 0 && prev != null)
        {
            curr.Item = carry;
            prev.Next = curr;
        }

        return result;
    }

    /// <summary>
    /// This algorithm uses a dummy head which somewhat simplifies the algorithm.
    /// </summary>
    /// <param name="l1">The head of a linked-list containing the first number</param>
    /// <param name="l2">The head of a linked-list containing the second number</param>
    /// <returns>The head of the linked-list containing the result</returns>
    public static ListNode<int> AddTwoNumbersDummyHead(ListNode<int> l1, ListNode<int> l2)
    {
        var dummyHead = new ListNode<int>(0);
        ListNode<int> p = l1, q = l2, curr = dummyHead;
        var carry = 0;

        while (p != null || q != null)
        {
            var x = p?.Item ?? 0;
            var y = q?.Item ?? 0;

            var sum = x + y + carry;

            carry = sum / 10;

            curr.Next = new ListNode<int>(sum % 10);
            curr = curr.Next;

            p = p?.Next;

            q = q?.Next;
        }

        // Take care about a possible carry.
        if (carry == 1)
        {
            curr.Next = new ListNode<int>(1);
        }

        return dummyHead.Next;
    }
}
