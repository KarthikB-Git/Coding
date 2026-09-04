namespace LeetCodeTestbench.Solutions.P645_SetMismatch;

// https://leetcode.com/problems/set-mismatch/
// Difficulty: Easy
// Tags: Array, Hash Table, Bit Manipulation, Sorting
public class Solution
{
    public int[] FindErrorNums(int[] nums)
    {
        int[] ans = new int[2];
        Dictionary<int, bool> arr = new Dictionary<int, bool>();
        foreach (int i in nums)
        {
            if (!arr.TryGetValue(i, out bool val))
            {
                arr.Add(i, true);
            }
            else
            {
                ans[0] = i;
            }
        }
        for (int i = 1; i <= nums.Length; i++)
        {
            if (!arr.ContainsKey(i))
            {
                ans[1] = i;
                break;
            }
        }
        return ans;
    }
}