namespace LeetCodeTestbench.Solutions.P1929_ConcatenationOfArray;

// https://leetcode.com/problems/concatenation-of-array
// Difficulty: Easy
// Tags: Array, Simulation
public class Solution
{
    public int[] GetConcatenation(int[] nums)
    {
        var n = nums.Length;
        var ans = new int[n*2];
        for (var i=0; i<n; i++) {
            ans[i] = nums[i];
            ans[i+n] = nums[i];
        }
        return ans;
    }
}
