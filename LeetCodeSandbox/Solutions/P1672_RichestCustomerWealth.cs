namespace LeetCodeTestbench.Solutions.P1672_RichestCustomerWealth;

// https://leetcode.com/problems/richest-customer-wealth/
// Difficulty: Easy
// Tags: Array, Matrix
public class Solution
{
    public int MaximumWealth(int[][] accounts)
    {
        return accounts.Max(c => c.Sum());
    }
}
