namespace LeetCodeTestbench.Solutions.P1365_HowManyNumbersAreSmallerThanTheCurrentNumber;

// https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number
// Difficulty: Easy
// Tags: Array, Hash Table, Sorting, Counting Sort
public class Solution
{
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        var ans = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            var cntr = nums.Count(t => t < nums[i]);
            ans[i] = cntr;
        }
        return ans;
    }
}

