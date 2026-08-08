namespace LeetCodeTestbench.Solutions.P1365_HowManyNumbersAreSmallerThanTheCurrentNumber;

// https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number
public class Solution
{
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        int[] ans = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            int cntr = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] < nums[i])
                {
                    cntr++;
                }
            }
            ans[i] = cntr;
        }
        return ans;
    }
}

