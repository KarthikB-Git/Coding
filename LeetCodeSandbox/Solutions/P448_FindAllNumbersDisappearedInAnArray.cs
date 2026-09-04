namespace LeetCodeTestbench.Solutions.P448_FindAllNumbersDisappearedInAnArray;

// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array
// Difficulty: Easy
// Tags: Array, Hash Table
public class Solution
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            var index = Math.Abs(nums[i]) - 1;
            if (nums[index] > 0)
                nums[index] = -nums[index];
        }

        List<int> ans = [];
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
                ans.Add(i + 1);
        }
        return ans;
    }
}

