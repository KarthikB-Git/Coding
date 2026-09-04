namespace LeetCodeTestbench.Solutions.P739_DailyTemperatures;

// https://leetcode.com/problems/daily-temperatures/
// Difficulty: Medium
// Tags: Array, Stack, Monotonic Stack
public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] ans = new int[temperatures.Length];
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
            {
                int j = stack.Pop();
                ans[j] = i - j;
            }
            stack.Push(i);
        }
        return ans;
    }
}

