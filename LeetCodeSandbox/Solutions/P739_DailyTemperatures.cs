namespace LeetCodeTestbench.Solutions.P739_DailyTemperatures;

// https://leetcode.com/problems/daily-temperatures/
// Difficulty: Medium
// Tags: Array, Stack, Monotonic Stack
public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var ans = new int[temperatures.Length];
        var stack = new Stack<int>();
        for (var i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
            {
                var j = stack.Pop();
                ans[j] = i - j;
            }
            stack.Push(i);
        }
        return ans;
    }
}

