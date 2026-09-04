namespace LeetCodeTestbench.Solutions.P645_SetMismatch;

// https://leetcode.com/problems/set-mismatch/
// Difficulty: Easy
// Tags: Array, Hash Table, Bit Manipulation, Sorting
public class Solution
{
    public int[] FindErrorNums(int[] nums)
    {
        var ans = new int[2];
        var arr = new Dictionary<int, bool>();
        foreach (var i in nums)
        {
            if (!arr.TryGetValue(i, out var _))
            {
                arr.Add(i, true);
            }
            else
            {
                ans[0] = i;
            }
        }
        for (var i = 1; i <= nums.Length; i++)
        {
            if (arr.ContainsKey(i)) continue;
            ans[1] = i;
            break;
        }
        return ans;
    }
}