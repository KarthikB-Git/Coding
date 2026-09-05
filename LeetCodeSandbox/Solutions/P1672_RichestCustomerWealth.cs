namespace LeetCodeTestbench.Solutions.P1672_RichestCustomerWealth;

// https://leetcode.com/problems/richest-customer-wealth/
// Difficulty: Easy
// Tags: Array, Matrix
public class Solution
{
    public int MaximumWealth(int[][] accounts)
    {
        var ans = 0;
        for (var i = 0; i < accounts.Length; i++)
        {
            var wealth = 0;
            for (var j = 0; j < accounts[i].Length; j++)
            {
                wealth += accounts[i][j];
            }
            ans = Math.Max(ans, wealth);
        }
        return ans;
    }
}
