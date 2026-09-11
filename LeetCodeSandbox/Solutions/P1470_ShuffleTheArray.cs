using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P1470_ShuffleTheArray;

// https://leetcode.com/problems/shuffle-the-array/
// Difficulty: Easy
// Tags: Array
[Problem(1470, "Shuffle The Array", Difficulty.Easy, Topic.Array)]
public class Solution
{
    public int[] Shuffle(int[] nums, int n)
    {
        var ans = new int[2*n];
        for (var i=0; i<n; i++) {
            ans[2*i] = nums[i];
            ans[2*i+1] = nums[i+n];
        }
        return ans;
    }
}
