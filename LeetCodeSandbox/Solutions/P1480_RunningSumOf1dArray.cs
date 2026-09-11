using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P1480_RunningSumOf1dArray;

// https://leetcode.com/problems/running-sum-of-1d-array/
// Difficulty: Easy
// Tags: Array, Prefix Sum
[Problem(1480, "Running Sum Of1d Array", Difficulty.Easy, Topic.Array, Topic.PrefixSum)]
public class Solution
{
    public int[] RunningSum(int[] nums)
    {
        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            nums[i] = sum;
        }

        return nums;
    }
}

