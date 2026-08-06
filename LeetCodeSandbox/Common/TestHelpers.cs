namespace LeetCodeTestbench.Common;

// xUnit [InlineData] attributes can only hold compile-time constants,
// so ListNode/TreeNode test inputs get built inside the test method
// body instead, using these helpers.
public static class TestHelpers
{
    public static ListNode? BuildList(params int[] values)
    {
        ListNode? head = null;
        ListNode? tail = null;

        foreach (var v in values)
        {
            var node = new ListNode(v);
            if (head is null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail!.Next = node;
                tail = node;
            }
        }

        return head;
    }

    public static int[] ToArray(ListNode? head)
    {
        var result = new List<int>();
        while (head is not null)
        {
            result.Add(head.Val);
            head = head.Next;
        }
        return result.ToArray();
    }

    // Level-order build, matching how LeetCode prints tree inputs.
    // null marks a missing child, e.g. BuildTree(3, 9, 20, null, null, 15, 7)
    public static TreeNode? BuildTree(params int?[] values)
    {
        if (values.Length == 0 || values[0] is null)
            return null;

        var root = new TreeNode(values[0]!.Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int i = 1;

        while (queue.Count > 0 && i < values.Length)
        {
            var node = queue.Dequeue();

            if (i < values.Length && values[i] is int leftVal)
            {
                node.Left = new TreeNode(leftVal);
                queue.Enqueue(node.Left);
            }
            i++;

            if (i < values.Length && values[i] is int rightVal)
            {
                node.Right = new TreeNode(rightVal);
                queue.Enqueue(node.Right);
            }
            i++;
        }

        return root;
    }
}
