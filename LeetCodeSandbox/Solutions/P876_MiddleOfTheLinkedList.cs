using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P876_MiddleOfTheLinkedList;

// https://leetcode.com/problems/middle-of-the-linked-list/
// Difficulty: Easy
// Tags: Linked List, Two Pointers
public class Solution
{
    public ListNode MiddleNode(ListNode head)
    {
        var ans = head;
        var last = head;
        while (last is { Next: not null })
        {
            ans = ans?.Next;
            last = last.Next.Next;
        }
        return ans!;
    }
}

