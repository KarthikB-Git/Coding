using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P1475_FinalPricesWithASpecialDiscountInAShop;

// https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop/
// Difficulty: Easy
// Tags: Array, Stack, Monotonic Stack
[Problem(1475, "Final Prices With ASpecial Discount In AShop", Difficulty.Easy, Topic.Array, Topic.Stack, Topic.MonotonicStack)]
public class Solution
{
    public int[] FinalPrices(int[] prices)
    {
        var ans = new int[prices.Length];
        for (var i = 0; i < prices.Length; i++)
        {
            ans[i] = prices[i];
            for (var j = i + 1; j < prices.Length; j++)
            {
                if (prices[i] < prices[j]) continue;
                ans[i] -= prices[j];
                break;
            }
        }
        return ans;
    }
}

