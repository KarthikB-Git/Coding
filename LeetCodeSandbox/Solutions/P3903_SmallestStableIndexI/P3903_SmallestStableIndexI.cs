using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P3903_SmallestStableIndexI;

// https://leetcode.com/problems/smallest-stable-index-i/
// Difficulty: Easy
// Tags: Array, Prefix Sum
[Problem(3903, "Smallest Stable Index I", Difficulty.Easy, Topic.Array, Topic.PrefixSum)]
public class Solution
{
    public int FirstStableIndex(int[] nums, int k)
    {
        var n = nums.Length;
        var suffixMin = new int[n];
        suffixMin[n - 1] = nums[n - 1];
        for (var i = n - 2; i >= 0; i--)
        {
            suffixMin[i] = Math.Min(nums[i], suffixMin[i + 1]);
        }

        var prefixMax = int.MinValue;
        for (var i = 0; i < n; i++)
        {
            prefixMax = Math.Max(prefixMax, nums[i]);
            if (prefixMax - suffixMin[i] <= k)
            {
                return i;
            }
        }

        return -1;
    }
}

