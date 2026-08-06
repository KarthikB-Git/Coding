namespace LeetCodeTestbench.Solutions.P0001_TwoSum;

// https://leetcode.com/problems/two-sum/
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var seen = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (seen.TryGetValue(target - nums[i], out int j))
                return new[] { j, i };

            seen[nums[i]] = i;
        }

        throw new ArgumentException("No two sum solution");
    }
}
