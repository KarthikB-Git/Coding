namespace LeetCodeTestbench.Solutions.P485_MaxConsecutiveOnes;

// https://leetcode.com/problems/max-consecutive-ones
// Difficulty: Easy
// Tags: Array
public class Solution
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int cnt = 0, max = 0;
        foreach (var n in nums)
        {
            if (n == 1)
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
