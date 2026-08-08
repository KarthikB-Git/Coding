namespace LeetCodeTestbench.Solutions.P448_FindAllNumbersDisappearedInAnArray;

// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array
public class Solution
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int index = Math.Abs(nums[i]) - 1;
            if (nums[index] > 0)
                nums[index] = -nums[index];
        }

        List<int> ans = new();
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
                ans.Add(i + 1);
        }
        return ans;
    }
}

