namespace LeetCodeTestbench.Solutions.P485_MaxConsecutiveOnes;

// https://leetcode.com/problems/max-consecutive-ones
// Difficulty: Easy
// Tags: Array
public class Solution
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int cnt = 0, max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                cnt += 1;
                if (max < cnt) max = cnt;
            }
            else
            {
                // reset the counter
                cnt = 0;
            }
        }
        return max;
    }
}
