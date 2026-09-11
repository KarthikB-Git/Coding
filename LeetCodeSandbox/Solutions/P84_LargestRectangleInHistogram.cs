using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P84_LargestRectangleInHistogram;

// https://leetcode.com/problems/largest-rectangle-in-histogram/
// Difficulty: Hard
// Tags: Array, Stack, Monotonic Stack, Range Minimum/Maximum Query
[Problem(84, "Largest Rectangle In Histogram", Difficulty.Hard, Topic.Array, Topic.Stack, Topic.MonotonicStack, Topic.Other)]
public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        var ans = 0;
        var shtack = new Stack<(int h, int i)>();
        for (var i = 0; i < heights.Length; i++)
        {
            var start = i;
            while (shtack.Count > 0 && shtack.Peek().h > heights[i])
            {
                var (ht, ind) = shtack.Pop();
                ans = Math.Max(ans, ht * (i - ind));
                start = ind;
            }
            shtack.Push((heights[i],start));
        }

        while (shtack.Count > 0)
        {
            var (ht, ind) = shtack.Pop();
            ans = Math.Max(ans, ht * (heights.Length - ind));
        }
        return ans;
    }
}

