using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P1672_RichestCustomerWealth;

// https://leetcode.com/problems/richest-customer-wealth/
// Difficulty: Easy
// Tags: Array, Matrix
[Problem(1672, "Richest Customer Wealth", Difficulty.Easy, Topic.Array, Topic.Matrix)]
public class Solution
{
    public int MaximumWealth(int[][] accounts)
    {
        return accounts.Max(c => c.Sum());
    }
}
